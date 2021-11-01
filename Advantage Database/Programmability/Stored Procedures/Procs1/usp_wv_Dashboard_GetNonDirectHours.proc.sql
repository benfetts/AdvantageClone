if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetNonDirectHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetNonDirectHours]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetNonDirectHours]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@UserID varchar(100)
)
AS
DECLARE @TotalNonDirect as decimal(12,2), @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000),
		@RestrictionsOffice Int,
		@EmployeeCode varchar(6)

Select @EmployeeCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmployeeCode

if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT @TotalNonDirect = SUM(NON_PROD_HOURS)
			FROM DASH_DATA_EMP_TIME
			WHERE REC_TYPE = 'N' AND EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			SELECT TIME_CATEGORY.DESCRIPTION AS CATEGORY, SUM(NON_PROD_HOURS) AS NONDIRECT, (SUM(NON_PROD_HOURS)/@TotalNonDirect) * 100 AS PERC
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN TIME_CATEGORY ON DASH_DATA_EMP_TIME.CATEGORY = TIME_CATEGORY.CATEGORY
			WHERE REC_TYPE = 'N' AND EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.CATEGORY, TIME_CATEGORY.DESCRIPTION
		End
	Else
		Begin
			SELECT @TotalNonDirect = SUM(NON_PROD_HOURS)
			FROM DASH_DATA_EMP_TIME
			WHERE REC_TYPE = 'N' AND EMP_CODE = @EmpCode
			SELECT TIME_CATEGORY.DESCRIPTION AS CATEGORY, SUM(NON_PROD_HOURS) AS NONDIRECT, (SUM(NON_PROD_HOURS)/@TotalNonDirect) * 100 AS PERC
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN TIME_CATEGORY ON DASH_DATA_EMP_TIME.CATEGORY = TIME_CATEGORY.CATEGORY
			WHERE REC_TYPE = 'N' AND EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.CATEGORY, TIME_CATEGORY.DESCRIPTION
		End	
End
Else
Begin
	SELECT @sql = 'SELECT @TotalNonDirect = SUM(NON_PROD_HOURS)
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
				SELECT @sql = @sql + ' WHERE REC_TYPE = ''N'''				
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End
			if @StartDate <> '' and @EndDate <> ''
				Begin
					SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				End
	SELECT @sql = @sql + ' SELECT TIME_CATEGORY.DESCRIPTION AS CATEGORY, SUM(NON_PROD_HOURS) AS NONDIRECT, (SUM(NON_PROD_HOURS)/@TotalNonDirect) * 100 AS PERC
				FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE 
				  LEFT OUTER JOIN TIME_CATEGORY ON DASH_DATA_EMP_TIME.CATEGORY = TIME_CATEGORY.CATEGORY'
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
				SELECT @sql = @sql + ' WHERE REC_TYPE = ''N'''			
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End
			if @StartDate <> '' and @EndDate <> ''
				Begin
					SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
				End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CATEGORY, TIME_CATEGORY.DESCRIPTION'

		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @TotalNonDirect as decimal(12,2), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @TotalNonDirect, @EmployeeCode
End




