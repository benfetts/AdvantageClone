if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetBillableHoursGoalWithStandard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetBillableHoursGoalWithStandard]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetBillableHoursGoalWithStandard]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Month int,
	@UserID varchar(100),
	@Include int,
	@Office varchar(4000),
	@Dept varchar(4000),
	@CurrentDate varchar(12),
	@YearValue varchar(2)
)
AS

DECLARE @StdHours as decimal(9,3), @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @PPEndDate datetime

if @YearValue = '0'
Begin
	SET @PPMonth = 12
End
Else
Begin
	SELECT @PPMonth = PPGLMONTH
	FROM POSTPERIOD
	WHERE PPSRTDATE <= @CurrentDate AND PPENDDATE >= @CurrentDate
End

SELECT @PPEndDate = PPENDDATE
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
	End
	Else
	Begin
		if @Include = 1
		Begin
			SELECT @sql = 'SELECT @StdHours = SUM(STD_HOURS)
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
				SELECT @sql = @sql + ' WHERE 1=1'
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @PPEndDate'
					End
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate
		End
		Else
		Begin
			SELECT @sql = 'SELECT @StdHours = SUM(STD_HOURS)
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
				SELECT @sql = @sql + ' WHERE EMPLOYEE.EMP_TERM_DATE IS NULL'
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @PPEndDate'
					End
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate
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
	End
	Else
	Begin
		if @Include = 1
		Begin
			SELECT @sql = 'SELECT @StdHours = SUM(STD_HOURS)
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
				SELECT @sql = @sql + ' WHERE 1=1'
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate
		End
		Else
		Begin
			SELECT @sql = 'SELECT @StdHours = SUM(STD_HOURS)
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
				SELECT @sql = @sql + ' WHERE EMPLOYEE.EMP_TERM_DATE IS NULL'
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate
		End
	End
End



--DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)


if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, 
			@StdHours AS REQUIRED, CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL 
		End
	Else
		Begin	 
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, 
			@StdHours AS REQUIRED, CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL
		End	
End
Else
Begin
	if @IsGauge = 1
	Begin
		if @Include = 1
			Begin
				SELECT @sql = 'SELECT @StdHours AS REQUIRED, ISNULL(SUM(A.GOAL), 0) AS GOAL FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, @StdHours AS REQUIRED
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
					End				
				SELECT @sql = @sql + ' WHERE 1=1'
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL'
				--		UNION SELECT EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
				--				CASE WHEN 0 = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, 0
				--		FROM EMPLOYEE WHERE EMP_CODE NOT IN (SELECT EMP_CODE FROM DASH_DATA_EMP_TIME'
				--if @Office <> ''
				--	Begin
				--		SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				--	End			
				--if @Dept <> ''
				--	Begin
				--		SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				--	End				
				--SELECT @sql = @sql + ' WHERE 1=1'
				--if @StartDate <> '' and @EndDate <> ''
				--	Begin
				--		SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				--	End
				SELECT @sql = @sql + ')) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @Month int, @PPMonth int'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @Month, @PPMonth
				
			End
		Else
			Begin
				SELECT @sql = 'SELECT @StdHours AS REQUIRED, ISNULL(SUM(A.GOAL), 0) AS GOAL FROM 
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, @StdHours AS REQUIRED
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
					End				
				SELECT @sql = @sql + ' WHERE 1=1 AND EMPLOYEE.EMP_TERM_DATE IS NULL'
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL) A '
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @Month int, @PPMonth int'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @Month, @PPMonth
			End	
		
	End
	Else
	Begin
		if @Include = 1
			Begin
				SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, @StdHours AS REQUIRED, SUM(A.GOAL) AS GOAL FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, @StdHours AS REQUIRED
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
					End				
				SELECT @sql = @sql + ' WHERE 1=1'
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL'
				--		UNION SELECT EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
				--				CASE WHEN 0 = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, 0
				--		FROM EMPLOYEE WHERE EMP_CODE NOT IN (SELECT EMP_CODE FROM DASH_DATA_EMP_TIME'
				--if @Office <> ''
				--	Begin
				--		SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				--	End			
				--if @Dept <> ''
				--	Begin
				--		SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				--	End				
				--SELECT @sql = @sql + ' WHERE 1=1'
				--if @StartDate <> '' and @EndDate <> ''
				--	Begin
				--		SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				--	End
				SELECT @sql = @sql + ')) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @Month int, @PPMonth int'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @Month, @PPMonth
				
			End
		Else
			Begin
				SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, @StdHours AS REQUIRED, SUM(A.GOAL) AS GOAL FROM 
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, @StdHours AS REQUIRED
						FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
					End				
				SELECT @sql = @sql + ' WHERE 1=1 AND EMPLOYEE.EMP_TERM_DATE IS NULL'
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS, EMPLOYEE.MTH_HRS_GOAL) A '
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @Month int, @PPMonth int'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @Month, @PPMonth
				
			End
		

	End

	
End



