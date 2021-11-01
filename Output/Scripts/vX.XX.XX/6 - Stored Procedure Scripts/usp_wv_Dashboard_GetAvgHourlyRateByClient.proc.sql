if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetAvgHourlyRateByClient]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetAvgHourlyRateByClient]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetAvgHourlyRateByClient]
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
DECLARE @TotalDirect as decimal(12,2), @Restrictions Int,
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

CREATE TABLE #client(
	RowID int IDENTITY(1, 1), 
	CLIENT varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BILLED decimal(15,2),
	BILLED_AMT decimal(15,2))

CREATE TABLE #mud(
	RowID int IDENTITY(1, 1), 
	CLIENT varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MARK_UP_DOWN_HRS decimal(15,5),
	MARK_UP_DOWN_AMT decimal(15,2))

SELECT @sql = 'INSERT INTO #client
	SELECT DASH_DATA_EMP_TIME.CLIENT, SUM(BILLED_HOURS), SUM(BILLED_AMT) FROM DASH_DATA_EMP_TIME 
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
			SELECT @sql = @sql + ' WHERE REC_TYPE = ''B'' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'			
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End						
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End	
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode 
SET @sql = ''
--SELECT * FROM #client

SELECT @sql = 'INSERT INTO #mud
	SELECT DASH_DATA_EMP_TIME.CLIENT, SUM(MARK_UP_DOWN_HRS), SUM(MARK_UP_DOWN_AMT) FROM DASH_DATA_EMP_TIME 
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
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode
SET @sql = ''
--SELECT * FROM #client

SELECT @sql = 'SELECT DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME,'
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(BILLABLE_AMT,0)) <> 0 THEN (ISNULL(#mud.MARK_UP_DOWN_AMT,0)/SUM(ISNULL(BILLABLE_AMT,0))) * 100 ELSE 0 END AS PERCENT_WRITE,'
					End	
				Else
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(BILLABLE_AMT,0)) <> 0 THEN SUM(ISNULL(MARK_UP_DOWN_AMT,0))/SUM(ISNULL(BILLABLE_AMT,0)) * 100 ELSE 0 END AS PERCENT_WRITE,'
					End	
				--'CASE WHEN SUM(ISNULL(BILLABLE_AMT,0)) <> 0 THEN SUM(ISNULL(MARK_UP_DOWN_AMT,0))/SUM(ISNULL(BILLABLE_AMT,0)) * 100 ELSE 0 END AS PERCENT_WRITE,'
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(BILLABLE_AMT,0)) <> 0 THEN ISNULL(#client.BILLED_AMT,0)/SUM(ISNULL(BILLABLE_AMT,0)) * 100 ELSE 0 END AS PERCENT_BILLED,'
					End	
				Else
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(BILLABLE_AMT,0)) <> 0 THEN SUM(ISNULL(BILLED_AMT,0))/SUM(ISNULL(BILLABLE_AMT,0)) * 100 ELSE 0 END AS PERCENT_BILLED,'
					End	
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(DIRECT_HOURS,0)) <> 0 THEN ISNULL(#client.BILLED_AMT,0)/SUM(ISNULL(DIRECT_HOURS,0)) ELSE 0 END AS AVG_RATE_ACHIEVED,'
					End	
				Else
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(DIRECT_HOURS,0)) <> 0 THEN SUM(ISNULL(BILLED_AMT,0))/SUM(ISNULL(DIRECT_HOURS,0)) ELSE 0 END AS AVG_RATE_ACHIEVED,'
					End
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' CASE WHEN ISNULL(#client.BILLED,0) <> 0 THEN ISNULL(#client.BILLED_AMT,0)/ISNULL(#client.BILLED,0) ELSE 0 END AS AVG_RATE_BILLED'
					End	
				Else
					Begin
						SELECT @sql = @sql + ' CASE WHEN SUM(ISNULL(BILLED_HOURS,0)) <> 0 THEN SUM(ISNULL(BILLED_AMT,0))/SUM(ISNULL(BILLED_HOURS,0)) ELSE 0 END AS AVG_RATE_BILLED'
					End					
			SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME INNER JOIN
				 CLIENT ON DASH_DATA_EMP_TIME.CLIENT = CLIENT.CL_CODE LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
			If @Period = 1
					Begin
						SELECT @sql = @sql + ' LEFT OUTER JOIN #client ON DASH_DATA_EMP_TIME.CLIENT = #client.CLIENT'
						SELECT @sql = @sql + ' LEFT OUTER JOIN #mud ON DASH_DATA_EMP_TIME.CLIENT = #mud.CLIENT'
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
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME'
			If @Period = 1
				Begin
					SELECT @sql = @sql + ', #client.BILLED, #client.BILLED_AMT, #mud.MARK_UP_DOWN_AMT'
				End
SELECT @sql = @sql + ' ORDER BY DASH_DATA_EMP_TIME.CLIENT'
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode





