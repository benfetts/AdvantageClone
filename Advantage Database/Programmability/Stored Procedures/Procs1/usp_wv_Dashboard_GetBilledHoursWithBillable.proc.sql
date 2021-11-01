if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetBilledHoursWithBillable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetBilledHoursWithBillable]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetBilledHoursWithBillable]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@UserID varchar(100)
)
AS
DECLARE @TotalBilled as decimal(12,2), @Restrictions Int,
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
			If @Period = 1
				Begin
					SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0)
					FROM DASH_DATA_EMP_TIME
					WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
					SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, SUM(BILLABLE_HOURS) AS BILLABLE, @TotalBilled AS BILLED
					FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
					WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
					GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
				End
			Else
				Begin
					SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, SUM(BILLABLE_HOURS) AS BILLABLE, SUM(BILLED_HOURS) AS BILLED
					FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
					WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
					GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
				End			
		End
	Else
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, SUM(BILLABLE_HOURS) AS BILLABLE, ISNULL(SUM(BILLED_HOURS), 0) AS BILLED
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
		End	
End
Else
Begin
	if @Office <> '' and @Dept <> ''
		Begin
			SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
				INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default
				INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default
			WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
				AND EMPLOYEE.OFFICE_CODE = @Office AND DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept
		End
	if @Office = '' and @Dept <> ''
		Begin
			SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
				INNER JOIN charlist_to_table(@Dept, DEFAULT) c ON DASH_DATA_EMP_TIME.DP_TM_CODE = c.vstr collate database_default
			WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
				AND DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept
		End
	if @Office <> '' and @Dept = ''
		Begin
			SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
				INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default
			WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)
				AND EMPLOYEE.OFFICE_CODE = @Office
		End
	if @Office = '' and @Dept = ''
		Begin
			if @RestrictionsOffice > 0
			Begin
				SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
				WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate) AND EMP_OFFICE.EMP_CODE = @EmployeeCode	
			End
			Else
			Begin
				SELECT @TotalBilled = ISNULL(SUM(BILLED_HOURS), 0) FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE
				WHERE REC_TYPE = 'B' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)	
			End					
		End

	if @IsGauge = 1
	Begin
		SELECT @sql = 'SELECT SUM(BILLABLE_HOURS) AS BILLABLE,'
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' @TotalBilled AS BILLED'
					End
				Else
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(BILLED_HOURS), 0) AS BILLED'
					End 
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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

			SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @TotalBilled as decimal(12,2), @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @TotalBilled, @EmployeeCode
	End
	Else
	Begin
		SELECT @sql = 'SELECT '''' AS TOTAL, '''' AS TOTAL, SUM(BILLABLE_HOURS) AS BILLABLE,'
				If @Period = 1
					Begin
						SELECT @sql = @sql + ' @TotalBilled AS BILLED'
					End
				Else
					Begin
						SELECT @sql = @sql + ' SUM(BILLED_HOURS) AS BILLED'
					End 
				SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
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

			SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @Dept varchar(4000), @Office varchar(4000), @TotalBilled as decimal(12,2), @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @TotalBilled, @EmployeeCode

	End
		
End



