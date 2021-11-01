if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetDetailHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetDetailHours]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetDetailHours]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@UserID varchar(100)
)
AS
DECLARE @Restrictions Int,
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
			SELECT SUM(DIRECT_HOURS) - SUM(DIRECT_AGENCY_HOURS) - SUM(DIRECT_NEW_BUS_HOURS) AS Client, SUM(DIRECT_AGENCY_HOURS) AS Agency,
				 SUM(DIRECT_NEW_BUS_HOURS) AS [New Business]
			FROM DASH_DATA_EMP_TIME
			WHERE EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
		End
	Else
		Begin
			SELECT SUM(DIRECT_HOURS) - SUM(DIRECT_AGENCY_HOURS) - SUM(DIRECT_NEW_BUS_HOURS) AS Client, SUM(DIRECT_AGENCY_HOURS) AS Agency,
				 SUM(DIRECT_NEW_BUS_HOURS) AS [New Business]
			FROM DASH_DATA_EMP_TIME
			WHERE EMP_CODE = @EmpCode
		End	
End
Else
Begin
	SELECT @sql = 'SELECT SUM(DIRECT_HOURS) - SUM(DIRECT_AGENCY_HOURS) - SUM(DIRECT_NEW_BUS_HOURS) AS Client, SUM(DIRECT_AGENCY_HOURS) AS Agency,
					 SUM(DIRECT_NEW_BUS_HOURS) AS [New Business]
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

		SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @EmployeeCode varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @EmployeeCode
		
End



