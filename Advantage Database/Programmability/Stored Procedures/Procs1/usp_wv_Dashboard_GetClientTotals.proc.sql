if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetClientTotals]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetClientTotals]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetClientTotals]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Client varchar(6),
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int, @TotalBilled as decimal(12,2), @WIP as decimal(15,2), @MUD AS decimal(15,2),
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

--Billed Amount by period
SELECT @sql = 'SELECT @TotalBilled = ISNULL(SUM(BILLED_AMT),0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			SELECT @sql = @sql + ' WHERE REC_TYPE = ''B'''				
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
		End
	if @Client <> ''
		Begin
			SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
		End
	if @EmpCode <> ''
		Begin
			SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
		End
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client varchar(6),	@Office varchar(4000),	@Dept varchar(4000), @TotalBilled as decimal(12,2) OUTPUT, @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Office,	@Dept, @TotalBilled OUTPUT, @EmployeeCode 
SET @sql = ''

--Markup Amount by period
SELECT @sql = 'SELECT @MUD = ISNULL(SUM(MARK_UP_DOWN_AMT),0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			SELECT @sql = @sql + ' WHERE REC_TYPE = ''B'''				
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'
		End
	if @Client <> ''
		Begin
			SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
		End
	if @EmpCode <> ''
		Begin
			SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
		End
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client varchar(6),	@Office varchar(4000),	@Dept varchar(4000), @MUD as decimal(15,2) OUTPUT, @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Office,	@Dept, @MUD OUTPUT, @EmployeeCode
SET @sql = ''

--WIP Amount
SELECT @sql = 'SELECT @WIP = SUM(ISNULL(DASH_DATA_EMP_TIME.WIP_AMT,0)) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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
			if @Client <> ''
				Begin
					SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End
			if @EmpCode <> ''
				Begin
					SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client varchar(6),	@Office varchar(4000),	@Dept varchar(4000) , @WIP as decimal(15,2) OUTPUT, @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Office,	@Dept, @WIP OUTPUT, @EmployeeCode
SET @sql = ''

SELECT @sql = 'SELECT SUM(ISNULL(DASH_DATA_EMP_TIME.BILLABLE_AMT,0)) AS Billable, '
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' @TotalBilled AS Billed,'
					End
				Else
					Begin
						SELECT @sql = @sql + ' SUM(ISNULL(DASH_DATA_EMP_TIME.BILLED_AMT,0)) AS Billed,'
					End 
				SELECT @sql = @sql + ' SUM(ISNULL(DASH_DATA_EMP_TIME.DIRECT_NONBILL_AMT,0)) AS [Non Billable],
			    SUM(ISNULL(DIRECT_AGENCY_AMT,0)) AS Agency, SUM(ISNULL(DIRECT_NEW_BUS_AMT,0)) AS [New Business], '
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' @MUD AS [Write Up/Down],'
					End
				Else
					Begin
						SELECT @sql = @sql + ' SUM(ISNULL(MARK_UP_DOWN_AMT,0)) AS [Write Up/Down],'
					End 
				SELECT @sql = @sql + ' ISNULL(@WIP,0) AS WIP
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
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End
			if @StartDate <> '' and @EndDate <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate) AND (DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate)'
				End
			if @Client <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.CLIENT = @Client)'
				End

--SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME'
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Client varchar(6),	@Office varchar(4000), @Dept varchar(4000), @TotalBilled as decimal(12,2), @WIP as decimal(15,2), @MUD as decimal(15,2), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Client, @Office, @Dept, @TotalBilled, @WIP, @MUD, @EmployeeCode 









