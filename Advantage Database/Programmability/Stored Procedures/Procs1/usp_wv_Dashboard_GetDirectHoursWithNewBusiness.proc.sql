

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetDirectHoursWithNewBusiness]
(
	@EmpCode varchar(6),
	@IsGauge tinyint,
	@StartDate varchar(12),
	@EndDate varchar(12)
)
AS
if @EmpCode <> ''
Begin
	if @StartDate <> '' and @EndDate <> ''
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
		End
	Else
		Begin
			SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'') + ' ' + isnull(EMP_MI,'') + case when EMP_MI is not null then '. ' else '' end +  isnull(EMP_LNAME,'') AS EMP_DESC, SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
			FROM DASH_DATA_EMP_TIME INNER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode
			GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME
		End	
End
Else
Begin
	if @IsGauge = 1
	Begin
		if @StartDate <> '' and @EndDate <> ''
			Begin
				SELECT SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
				FROM DASH_DATA_EMP_TIME
				WHERE DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			End
		Else
			Begin
				SELECT SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
				FROM DASH_DATA_EMP_TIME
			End		
	End
	Else
	Begin
		if @StartDate <> '' and @EndDate <> ''
			Begin
				SELECT '' AS TOTAL, '' AS TOTAL, SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
				FROM DASH_DATA_EMP_TIME
				WHERE DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate
			End
		Else
			Begin
				SELECT '' AS TOTAL, '' AS TOTAL, SUM(DIRECT_HOURS) AS DIRECT, SUM(DIRECT_NEW_BUS_HOURS) AS AGENCY
				FROM DASH_DATA_EMP_TIME
			End		
--		SELECT EMP_CODE, dbo.udf_get_empl_name(DASH_DATA_EMP_TIME.EMP_CODE, 'FML') AS EMP_DESC, SUM(DIRECT_HOURS) AS DIRECT, SUM(BILLABLE_HOURS) AS BILLABLE
--		FROM DASH_DATA_EMP_TIME
--		GROUP BY EMP_CODE
	End
		
End



