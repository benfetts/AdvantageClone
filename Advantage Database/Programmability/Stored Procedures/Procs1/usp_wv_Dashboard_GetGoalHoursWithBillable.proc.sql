if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetGoalHoursWithBillable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetGoalHoursWithBillable]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetGoalHoursWithBillable]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Month int,
	@Include int,
	@Office varchar(4000),
	@Dept varchar(4000),
	@YearValue varchar(2),
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
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

if @YearValue = '1'
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
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, 
			CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) 
				 WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME
		End
	Else
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, 
			CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth)
				 WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME
		End	
End
Else
Begin
	if @IsGauge = 1
	Begin
		if @Include = 1
			Begin
				
						SELECT @sql = 'SELECT SUM(A.GOAL) AS GOAL, SUM(A.BILLABLE) AS BILLABLE FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
						FROM DASH_DATA_EMP_TIME INNER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME'
						
							SELECT @sql = @sql + ') A'
						SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @PPMonth int, @EmployeeCode varchar(6)'
						print @sql
						EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @PPMonth, @EmployeeCode 			
					
			End
		Else
			Begin
				SELECT @sql = 'SELECT SUM(A.GOAL) AS GOAL, SUM(A.BILLABLE) AS BILLABLE FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
						FROM DASH_DATA_EMP_TIME INNER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME) A'
	
						SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @PPMonth int, @EmployeeCode varchar(6)'
						print @sql
						EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @PPMonth, @EmployeeCode 
				
			End		
	End
	Else
	Begin
		if @Include = 1
			Begin
				SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLABLE) AS BILLABLE FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
						FROM DASH_DATA_EMP_TIME INNER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME'
						
						SELECT @sql = @sql + ') A'
						SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @PPMonth int, @EmployeeCode varchar(6)'
						print @sql
						EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @PPMonth, @EmployeeCode 
			End
		Else
			Begin
				SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(A.GOAL) AS GOAL, SUM(A.BILLABLE) AS BILLABLE FROM
						(SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_DESC, 
						CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL, SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE
						FROM DASH_DATA_EMP_TIME INNER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
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
						SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.MTH_HRS_GOAL, EMP_FNAME, EMP_MI, EMP_LNAME) A'				
				
						SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @Month int, @PPMonth int, @EmployeeCode varchar(6)'
						print @sql
						EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @PPMonth, @EmployeeCode
			End
		

	END
	
End



