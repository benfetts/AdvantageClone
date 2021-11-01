if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetBilledHoursWithGoal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetBilledHoursWithGoal]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetBilledHoursWithGoal]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Month int,
	@Include int,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@UserID varchar(100)
)
AS

DECLARE @TotalBilled as decimal(12,2), @StdHours as decimal(15,2), @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int,
		@RestrictionsOffice Int,
		@EmployeeCode varchar(6)

Select @EmployeeCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmployeeCode

CREATE TABLE #DATA(
	RowID int IDENTITY(1, 1), 
	GOAL decimal(18,2),
	BILLED decimal(18,2))


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

if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			If @Period = 1
				Begin
					SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0)
					FROM DASH_DATA_EMP_TIME
					WHERE REC_TYPE = 'B' AND EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
					SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC,
					 CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN @TotalBilled ELSE
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL, @TotalBilled AS BILLED
					FROM DASH_DATA_EMP_TIME INNER JOIN
						 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
					WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
					GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL
				End
			Else
				Begin
					SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC,
					 CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_HOURS), 0) ELSE
					  CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL, ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_HOURS), 0) AS BILLED
					FROM DASH_DATA_EMP_TIME INNER JOIN
						 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
					WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
					GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL
				End				
		End
	Else
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC,
			 CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_HOURS), 0) ELSE
				CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL, ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_HOURS), 0) AS BILLED
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL
		End	
End
Else
Begin
	--if @Office <> '' and @Dept <> ''
	--	Begin
	--		SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
	--			INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default
	--			INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default
	--		WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
	--			--AND EMPLOYEE.OFFICE_CODE = @Office AND DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept
	--	End
	--if @Office = '' and @Dept <> ''
	--	Begin
	--		SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
	--			INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default
	--		WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
	--			--AND DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept
	--	End
	--if @Office <> '' and @Dept = ''
	--	Begin
	--		SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
	--			INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default
	--		WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
	--			--AND EMPLOYEE.OFFICE_CODE = @Office
	--	End
	--if @Office = '' and @Dept = ''
	--	Begin
	--		if @RestrictionsOffice > 0
	--		Begin
	--			SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
	--			WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate) AND EMP_OFFICE.EMP_CODE = @EmployeeCode	
	--		End
	--		Else
	--		Begin
	--			SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
	--			WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)	
	--		End					
	--	End

	
	if @IsGauge = 1
	Begin
		if @Include = 1
			Begin
				--GOAL
				SELECT @sql = 'INSERT INTO #DATA SELECT SUM(A.GOAL) AS GOAL,0'
				--SELECT @sql = 'SELECT SUM(A.GOAL) AS GOAL, '				
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 0'
				SELECT @sql = @sql + ' ELSE CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL'
				
				SELECT @sql = @sql + ') A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode 
						
				--BILLED
				SELECT @sql = 'INSERT INTO #DATA SELECT 0,SUM(A.BILLED) AS BILLED'
				--SELECT @sql = 'SELECT SUM(A.GOAL) AS GOAL, '				
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, SUM(BILLED_HOURS) AS BILLED'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						If @Period = 1
							Begin								
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
							End
						Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
							End 
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL'
				
				SELECT @sql = @sql + ') A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode 		
							
			End
		Else
			Begin
				--GOAL
				SELECT @sql = 'INSERT INTO #DATA SELECT SUM(A.GOAL) AS GOAL,0'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC,
						CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 0'
				SELECT @sql = @sql + ' ELSE CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME INNER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
				SELECT @sql = @sql + ' WHERE 1=1 AND EMPLOYEE.EMP_TERM_DATE IS NULL'		
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End		
				if @StartDate <> '' and @EndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode			
				
				--BILLED
				SELECT @sql = 'INSERT INTO #DATA SELECT 0,SUM(A.BILLED) AS BILLED'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, SUM(BILLED_HOURS) AS BILLED'						
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME INNER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						If @Period = 1
							Begin								
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
							End
						Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
							End 
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode			
					
			End
		SELECT SUM(GOAL) AS GOAL, SUM(BILLED) AS BILLED FROM #DATA
	End
	Else
	Begin
		if @Include = 1
			Begin
				--GOAL
				SELECT @sql = 'INSERT INTO #DATA SELECT SUM(A.GOAL) AS GOAL,0'
				--SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLED) AS BILLED'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 0'
				SELECT @sql = @sql + ' ELSE CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL'--, SUM(BILLED_HOURS) AS BILLED'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL'
				
				SELECT @sql = @sql + ') A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode

				--Billed
				SELECT @sql = 'INSERT INTO #DATA SELECT 0,SUM(A.BILLED) AS BILLED'
				--SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLED) AS BILLED'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, SUM(BILLED_HOURS) AS BILLED'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						If @Period = 1
							Begin								
								SELECT @sql = @sql + ' AND REC_TYPE = ''B'' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
							End
						Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
							End 
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL'
				
				SELECT @sql = @sql + ') A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode
			End
		Else
			Begin
				--GOAL
				SELECT @sql = 'INSERT INTO #DATA SELECT SUM(A.GOAL) AS GOAL,0'
				--SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLED) AS BILLED'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC,
						CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 0'
				SELECT @sql = @sql + ' ELSE CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END END AS GOAL'--, SUM(BILLED_HOURS) AS BILLED'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						SELECT @sql = @sql + ' AND EMPLOYEE.EMP_TERM_DATE IS NULL AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode	
				
				--BILLED	
				SELECT @sql = 'INSERT INTO #DATA SELECT 0,SUM(A.BILLED) AS BILLED'
				--SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLED) AS BILLED'
				SELECT @sql = @sql + ' FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC,'
				SELECT @sql = @sql + ' SUM(BILLED_HOURS) AS BILLED'
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
							 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						If @Period = 1
							Begin								
								SELECT @sql = @sql + ' AND REC_TYPE = ''B'' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
							End
						Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
							End 
					End
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.MTH_HRS_GOAL) A'
				
				SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @TotalBilled as decimal(12,2), @PPMonth int, @EmployeeCode varchar(6)'
				print @sql
				EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @TotalBilled, @PPMonth, @EmployeeCode		

			End
		SELECT '' AS TOTAL, '' AS TOTAL, SUM(GOAL) AS GOAL, SUM(BILLED) AS BILLED FROM #DATA
	END
	


End



