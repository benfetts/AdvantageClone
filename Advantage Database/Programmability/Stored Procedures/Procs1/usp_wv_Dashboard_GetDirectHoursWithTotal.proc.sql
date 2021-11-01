if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetDirectHoursWithTotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetDirectHoursWithTotal]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetDirectHoursWithTotal]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Include int,
	@Month int,
	@CurrentDate varchar(12),
	@YearValue varchar(2),
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000),  @StdHours as decimal(9,3), @PPMonth int, @PPEndDate datetime, @TimeOff decimal(9,3), @DirectHrsPct decimal(7,4), @NumberRecords int, @RowCount int,
		@emp_code varchar(6), @DirectHrsGoal decimal(9,3),
		@RestrictionsOffice Int,
		@EmployeeCode varchar(6)

Select @EmployeeCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmployeeCode

CREATE TABLE #direct(
	RowID int IDENTITY(1, 1), 
	EMP_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	STD_HOURS decimal(9,3),
	DIRECT_HRS_PER decimal(7,4),
	TIME_OFF decimal(9,3),
	DIRECT_HRS_GOAL decimal(9,3))

SELECT @PPMonth = PPGLMONTH, @PPEndDate = PPENDDATE
FROM POSTPERIOD
WHERE PPSRTDATE <= @CurrentDate AND PPENDDATE >= @CurrentDate

--DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)
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
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @PPEndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate, @EmployeeCode
		End
		--SELECT @StdHours = SUM(STD_HRS) 
		--FROM W_EMP_STD_HOURS_DTL
		--WHERE UPPER(USERID) = UPPER(@UserID)
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
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate, @EmployeeCode
		End
		--SELECT @StdHours = SUM(STD_HRS) 
		--FROM W_EMP_STD_HOURS_DTL
		--WHERE UPPER(USERID) = UPPER(@UserID)
	End
End

SET @sql = ''

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


if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, (@StdHours - @TimeOff) * (@DirectHrsPct * 0.010000) AS TOTAL_HOURS, SUM(DIRECT_HOURS) AS DIRECT
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
		End
	Else
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, (@StdHours - @TimeOff) * (@DirectHrsPct * 0.010000) AS TOTAL_HOURS, SUM(DIRECT_HOURS) AS DIRECT
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
		End	
End
Else
Begin
	--SELECT * FROM #direct
	SELECT @DirectHrsGoal = ISNULL(SUM(DIRECT_HRS_GOAL),0) FROM #direct
	if @IsGauge = 1
	Begin
		SELECT @sql = 'SELECT @DirectHrsGoal AS TOTAL_HOURS, SUM(DIRECT_HOURS) AS DIRECT 
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			if @StartDate <> '' and @EndDate <> ''
				Begin
					SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				End

		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @DirectHrsGoal decimal(9,3), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @DirectHrsGoal, @EmployeeCode 
	End
	Else
	Begin
		SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, @DirectHrsGoal AS TOTAL_HOURS, SUM(DIRECT_HOURS) AS DIRECT 
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			if @StartDate <> '' and @EndDate <> ''
				Begin
					SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				End

		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @DirectHrsGoal decimal(9,3), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @DirectHrsGoal, @EmployeeCode 	
	END
End



