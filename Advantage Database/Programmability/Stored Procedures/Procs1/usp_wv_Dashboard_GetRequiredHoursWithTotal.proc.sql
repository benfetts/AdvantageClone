if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetRequiredHoursWithTotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetRequiredHoursWithTotal]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetRequiredHoursWithTotal]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@UserID varchar(100),
	@Office varchar(4000),
	@Dept varchar(4000),
	@Include int,
	@Month int,
	@CurrentDate varchar(12),
	@YearValue varchar(2)
)
AS

DECLARE @StdHours as decimal(9,3),
	    @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @PPEndDate datetime,
		@RestrictionsOffice Int,
		@EmployeeCode varchar(6)

Select @EmployeeCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmployeeCode

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
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate, @EmployeeCode
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
           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate, @EmployeeCode
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
--DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, @StdHours AS REQUIRED, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) + ISNULL(SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS), 0) AS TOTAL_HOURS
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS
		End
	Else
		Begin	
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, @StdHours AS REQUIRED, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) + ISNULL(SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS), 0) AS TOTAL_HOURS
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.STD_ANNUAL_HRS
		End	
End
Else
Begin
	if @IsGauge = 1
	Begin
		SELECT @sql = 'SELECT @StdHours AS REQUIRED, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) + ISNULL(SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS),0) AS TOTAL_HOURS 
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

		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @EmployeeCode	
	End
	Else
	Begin
		SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, @StdHours AS REQUIRED, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) + ISNULL(SUM(DASH_DATA_EMP_TIME.NON_PROD_HOURS), 0) AS TOTAL_HOURS
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
		
		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @StdHours, @EmployeeCode
	End

	
End



