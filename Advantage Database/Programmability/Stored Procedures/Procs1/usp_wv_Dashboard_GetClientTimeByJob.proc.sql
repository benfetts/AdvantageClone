if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetClientTimeByJob]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetClientTimeByJob]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetClientTimeByJob]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Client varchar(6),
	@Division varchar(6),
	@Product varchar(6),
	@JobNumber int,
	@JobComp int,
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

CREATE TABLE #emp(
	RowID int IDENTITY(1, 1), 
	JOB_NUMBER int,
	JOB_COMPONENT_NBR int,
	BILLED decimal(15,2),
	BILLED_AMT decimal(15,2))

CREATE TABLE #wip(
	RowID int IDENTITY(1, 1), 
	JOB_NUMBER int,
	JOB_COMPONENT_NBR int,
	WIP_HOURS decimal(15,2),
	WIP_AMT decimal(15,2))

CREATE TABLE #mud(
	RowID int IDENTITY(1, 1), 
	JOB_NUMBER int,
	JOB_COMPONENT_NBR int,
	MARK_UP_DOWN_HRS decimal(15,5),
	MARK_UP_DOWN_AMT decimal(15,2))

SELECT @sql = 'INSERT INTO #emp
	SELECT DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR, SUM(BILLED_HOURS), SUM(BILLED_AMT) FROM DASH_DATA_EMP_TIME 
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
			if @Client <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End
			if @Division <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DIVISION = @Division)'
				End
			if @Product <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.PRODUCT = @Product)'
				End
			if @JobNumber <> 0 and @JobComp <> 0
				Begin
				   SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.JOB_NUMBER = @JobNumber AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = @JobComp'	
				End		
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @JobNumber int, @JobComp int, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Product, @Division, @JobNumber, @JobComp,  @Office, @Dept, @EmployeeCode
SET @sql = ''
--SELECT * FROM #emp

SELECT @sql = 'INSERT INTO #mud
	SELECT DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR, SUM(MARK_UP_DOWN_HRS), SUM(MARK_UP_DOWN_AMT) FROM DASH_DATA_EMP_TIME 
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
			if @Client <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End
			if @Division <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DIVISION = @Division)'
				End
			if @Product <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.PRODUCT = @Product)'
				End
			if @JobNumber <> 0 and @JobComp <> 0
				Begin
				   SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.JOB_NUMBER = @JobNumber AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = @JobComp'	
				End		
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @JobNumber int, @JobComp int, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Product, @Division, @JobNumber, @JobComp,  @Office, @Dept, @EmployeeCode
SET @sql = ''

SELECT @sql = 'INSERT INTO #wip
	SELECT DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR, SUM(DASH_DATA_EMP_TIME.WIP_HOURS) AS WIP_HOURS, SUM(DASH_DATA_EMP_TIME.WIP_AMT) AS WIP_AMT FROM DASH_DATA_EMP_TIME 
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
			if @Client <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End
			if @Division <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DIVISION = @Division)'
				End
			if @Product <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.PRODUCT = @Product)'
				End
			if @JobNumber <> 0 and @JobComp <> 0
				Begin
				   SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.JOB_NUMBER = @JobNumber AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = @JobComp'	
				End	
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.JOB_NUMBER, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @JobNumber int, @JobComp int, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Product, @Division, @JobNumber, @JobComp,  @Office, @Dept, @EmployeeCode
SET @sql = ''
--SELECT * FROM #emp

SELECT @sql = 'SELECT DASH_DATA_EMP_TIME.JOB_NUMBER, JOB_LOG.JOB_DESC, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
					 SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) AS BILLABLE_HOURS, SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT) AS BILLABLE_AMOUNT, 
					 SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_HOURS) AS DIRECT_NONBILL_HOURS, SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_AMT) AS DIRECT_NONBILL_AMT,
					 (SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) + SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_HOURS)) AS TOTAL_DIRECT_HOURS,
				     (SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT) + SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_AMT)) AS TOTAL_DIRECT_AMT,'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' ISNULL(#emp.BILLED,0) AS BILLED_HOURS, ISNULL(#emp.BILLED_AMT,0) AS BILLED_AMT,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' SUM(DASH_DATA_EMP_TIME.BILLED_HOURS) AS BILLED_HOURS, SUM(DASH_DATA_EMP_TIME.BILLED_AMT) AS BILLED_AMT,'
						 End
					  SELECT @sql = @sql + ' ISNULL(#wip.WIP_HOURS,0) AS WIP_HOURS, ISNULL(#wip.WIP_AMT,0) AS WIP_AMT,'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' ISNULL(#mud.MARK_UP_DOWN_AMT,0) AS MARK_UP_DOWN_AMT,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' SUM(DASH_DATA_EMP_TIME.MARK_UP_DOWN_AMT) AS MARK_UP_DOWN_AMT,'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) <> 0 THEN (ISNULL(#mud.MARK_UP_DOWN_AMT,0)/SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT)) * 100 ELSE 0 END AS PERCENT_WRITE'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) <> 0 THEN (SUM(DASH_DATA_EMP_TIME.MARK_UP_DOWN_AMT)/SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT)) * 100 ELSE 0 END AS PERCENT_WRITE'
						 End	
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ', CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) <> 0 THEN (#emp.BILLED/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS)) * 100 ELSE 0 END AS PERCENT_BILLED'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ', CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) <> 0 THEN (SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS)) * 100 ELSE 0 END AS PERCENT_BILLED'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ', CASE WHEN #emp.BILLED = 0 THEN 0 ELSE #emp.BILLED_AMT/ISNULL(#emp.BILLED,1) END AS AVG_HOURLY_RATE_BILLED'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ', CASE WHEN SUM(DASH_DATA_EMP_TIME.BILLED_HOURS) = 0 THEN 0 ELSE SUM(DASH_DATA_EMP_TIME.BILLED_AMT)/SUM(ISNULL(DASH_DATA_EMP_TIME.BILLED_HOURS,1)) END AS AVG_HOURLY_RATE_BILLED'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ', CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) = 0 THEN 0 ELSE #emp.BILLED_AMT/SUM(ISNULL(DASH_DATA_EMP_TIME.DIRECT_HOURS,1)) END AS AVG_HOURLY_RATE_ACHIEVED'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ', CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) = 0 THEN 0 ELSE SUM(DASH_DATA_EMP_TIME.BILLED_AMT)/SUM(ISNULL(DASH_DATA_EMP_TIME.DIRECT_HOURS,1)) END AS AVG_HOURLY_RATE_ACHIEVED'
						 End	
					  SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME INNER JOIN
							JOB_COMPONENT ON DASH_DATA_EMP_TIME.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
								AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN												
							JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN 
							EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN #wip ON DASH_DATA_EMP_TIME.JOB_NUMBER = #wip.JOB_NUMBER AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = #wip.JOB_COMPONENT_NBR'
			If @Period = 1
					Begin
						SELECT @sql = @sql + ' LEFT OUTER JOIN #emp ON DASH_DATA_EMP_TIME.JOB_NUMBER = #emp.JOB_NUMBER AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = #emp.JOB_COMPONENT_NBR'
						SELECT @sql = @sql + ' LEFT OUTER JOIN #mud ON DASH_DATA_EMP_TIME.JOB_NUMBER = #mud.JOB_NUMBER AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = #mud.JOB_COMPONENT_NBR'
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
			if @Client <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End
			if @Division <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DIVISION = @Division)'
				End
			if @Product <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.PRODUCT = @Product)'
				End
			if @StartDate <> '' and @EndDate <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate) AND (DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate)'
				End
			if @JobNumber <> 0 and @JobComp <> 0
				Begin
				   SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.JOB_NUMBER = @JobNumber AND DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR = @JobComp'	
				End
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode'	
				End				

SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.JOB_NUMBER, JOB_LOG.JOB_DESC, DASH_DATA_EMP_TIME.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, #wip.WIP_HOURS, #wip.WIP_AMT'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ', #emp.BILLED, #emp.BILLED_AMT, #mud.MARK_UP_DOWN_AMT'
						 End
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @JobNumber int, @JobComp int, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Product, @Division, @JobNumber, @JobComp, @Office, @Dept, @EmployeeCode









