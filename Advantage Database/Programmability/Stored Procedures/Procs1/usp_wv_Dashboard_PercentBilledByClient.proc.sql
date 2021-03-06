if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_PercentBilledByClient]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_PercentBilledByClient]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_PercentBilledByClient]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int, 
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

SELECT @sql = 'SELECT DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME, SUM(ISNULL(DASH_DATA_EMP_TIME.BILLED_AMT,0)) AS PERCENT_BILLED
					 FROM DASH_DATA_EMP_TIME INNER JOIN
				 CLIENT ON DASH_DATA_EMP_TIME.CLIENT = CLIENT.CL_CODE LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			If @Period = 1
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
					End
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME'
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode 









