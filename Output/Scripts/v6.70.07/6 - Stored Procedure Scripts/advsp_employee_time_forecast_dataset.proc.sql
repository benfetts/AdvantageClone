IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_employee_time_forecast_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_employee_time_forecast_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_employee_time_forecast_dataset]
(
	@post_period varchar(6),
	@office_code varchar(4),
	@emp_code varchar(6),
	@user_id varchar(6)

)
AS

BEGIN

--SELECT @office_code

DECLARE @start_date smalldatetime
DECLARE @end_date smalldatetime

IF @post_period IS NOT NULL BEGIN
	SET @start_date = (SELECT d.PPSRTDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@post_period AS varchar(6)) ) 
	SET @end_date =	(SELECT d.PPENDDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@post_period AS varchar(6)) ) 
END 
ELSE BEGIN
	SET @start_date = '01-01-1900'
	SET @end_date = '01-01-1900'
END



DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@user_id)

INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
VALUES(@user_id, @start_date, @end_date)
	

SELECT [ID] = NEWID(), 		
	EmployeeTimeForecastID,
	EmployeeTimeForecastDescription,
	EmployeeTimeForecastComment,
	RevisionNumber,

	OfficeCode,
	OfficeName,

	PostPeriod,

	CreatedBy,
	ModifiedBy,
	ApprovedBy,

	AssignedEmployee,

	EmployeeTitle,
	EmployeeCode,
	EmployeeName,
	EmployeeOfficeName,

	--ClientCode,
	--ClientDescription,
	--DivisionCode,
	--DivisionDescription,
	--ProductCode,
	--ProductDescription,

	ForecastedDirectHours =	SUM(ForecastedDirectHours),
	ForecastedAgencyHours = SUM(ForecastedAgencyHours),
	ForecastedNewBusinessHours = SUM(ForecastedNewBusinessHours),
	TotalForecastedDirectHours = SUM(ForecastedDirectHours + ForecastedAgencyHours + ForecastedNewBusinessHours),

	BillRate,
	--CostRate,

	TotalForecastedRevenue = SUM((ForecastedDirectHours + ForecastedAgencyHours + ForecastedNewBusinessHours) * BillRate),
	TotalForecastedIndirectHours = SUM(TotalForecastedIndirectHours),
	TotalForecastedHours = SUM(ForecastedDirectHours + ForecastedAgencyHours + ForecastedNewBusinessHours + TotalForecastedIndirectHours),	--(Is the sum of the total forecasted direct hours and total forecasted indirect hours)
	TotalAvailableHours = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = MAX(ETF_UNION.EMP_CODE) AND WS.WORK_DATE BETWEEN @start_date and @end_date AND USERID = @user_id), --(Hours worked per day, days worked, work days in month) 
	DirectHoursGoalByEmployee = ISNULL((SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = MAX(ETF_UNION.EMP_CODE) AND WS.WORK_DATE BETWEEN @start_date and @end_date AND USERID = @user_id) * (ISNULL(MAX(DIRECT_HRS_PER),0.000000) * .01),0), 
	BillableHoursGoalByEmployee = MAX(BillableHoursGoalByEmployee),
	--AvailableToForecastedVariance = (=Total available hours - Total Forecasted Hours)
	AvailableToForecastedVariance = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = MAX(ETF_UNION.EMP_CODE) AND WS.WORK_DATE BETWEEN @start_date and @end_date AND USERID = @user_id) - (SUM(ForecastedDirectHours) + SUM(ForecastedAgencyHours) + SUM(ForecastedNewBusinessHours) + SUM(TotalForecastedIndirectHours))

FROM 
	(SELECT EmployeeTimeForecastID = C.ETF_ID,
			EmployeeTimeForecastDescription = A.FC_DESCRIPTION,
			EmployeeTimeForecastComment = ISNULL(B.FC_COMMENT,''), 
			RevisionNumber = B.REV_NBR,
			OfficeCode = B.OFFICE_CODE,
			OfficeName = O.OFFICE_NAME,
			PostPeriod = A.PPPERIOD,
			CreatedBy = B.USER_CREATED,
			ModifiedBy = B.USER_MODIFIED,
			ApprovedBy = B.APPROVED_BY,
			AssignedEmployee = B.USER_ASSIGNED,
			EmployeeTitle = E.EMP_TITLE,
			EmployeeCode = DE.EMP_CODE,
			EmployeeName = CASE WHEN E.EMP_MI IS NULL OR E.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(E.EMP_FNAME, '') + ' ' + ISNULL(E.EMP_LNAME, ''))) ELSE E.EMP_FNAME + ' ' + E.EMP_MI + '. ' + E.EMP_LNAME END,
			EmployeeOfficeName = P.OFFICE_NAME,
			--ClientCode = C.CL_CODE,
			--ClientDescription = CL.CL_NAME,
			--DivisionCode = C.DIV_CODE,
			--DivisionDescription = D.DIV_NAME,
			--ProductCode = C.PRD_CODE,
			--ProductDescription = P.PRD_DESCRIPTION,
			ForecastedDirectHours =	CASE
										WHEN AGENCY_CLIENTS.CL_CODE IS NULL AND ISNULL(CL.NEW_BUSINESS, 0) = 0 THEN D.[HOURS]
										ELSE 0
									END,
			ForecastedAgencyHours = CASE
										WHEN AGENCY_CLIENTS.CL_CODE IS NOT NULL THEN D.[HOURS]
										ELSE 0
									END,
			ForecastedNewBusinessHours = CASE
											WHEN CL.NEW_BUSINESS = 1 THEN D.[HOURS]
											ELSE 0
										END,
			TotalForecastedDirectHours = 0,
			BillRate = DE.BILL_RATE,
			CostRate = DE.COST_RATE,
			TotalForecastedRevenue = 0,
			TotalForecastedIndirectHours = 0,
			TotalForecastedHours  = 0,	--(Is the sum of the total forecasted direct hours and total forecasted indirect hours)
			TotalAvailableHours = 0,  --(Hours worked per day, days worked, work days in month) 
			DirectHoursGoalByEmployee = 0,
			BillableHoursGoalByEmployee = ISNULL(E.MTH_HRS_GOAL,0) * 1,
			AvailableToForecastedVariance = 0,		--(=Total available hours - Total Forecasted Hours)
			E.DIRECT_HRS_PER,
			DE.EMP_CODE
			--,DIRECT_TYPE = 
			--	CASE
			--		WHEN AGENCY_CLIENTS.CL_CODE IS NOT NULL THEN 'AG'	--'Agency Time'
			--		WHEN CL.NEW_BUSINESS = 1 THEN 'NW'					--'New Business Time'
			--		--WHEN ed.EMP_NON_BILL_FLAG = 1 AND ISNULL(ed.FEE_TIME, 0) = 0 THEN 'NB'
			--		ELSE 'BL'											--'Client Time'
			--	END

		FROM 
			dbo.ETF_HDR A JOIN 
			dbo.ETF_OFFDTL B ON A.ETF_ID = B.ETF_ID JOIN 
			dbo.ETF_OFFDTLJC C ON B.ETF_ID = C.ETF_ID AND B.ETF_OFFDTL_ID = C.ETF_OFFDTL_ID INNER JOIN
			dbo.ETF_OFFDTLJC_EMP D ON D.ETF_ID = C.ETF_ID AND D.ETF_OFFDTL_ID = C.ETF_OFFDTL_ID AND D.ETF_OFFDTLJC_ID = C.ETF_OFFDTLJC_ID  INNER JOIN
			dbo.ETF_OFFDTLEMP DE ON DE.ETF_ID = D.ETF_ID AND
										   DE.ETF_OFFDTL_ID = D.ETF_OFFDTL_ID AND 
										   DE.ETF_OFFDTLEMP_ID = D.ETF_OFFDTLEMP_ID INNER JOIN
			dbo.EMPLOYEE E ON E.EMP_CODE = DE.EMP_CODE LEFT JOIN 
			dbo.JOB_COMPONENT JC ON JC.JOB_NUMBER = C.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = C.JOB_COMPONENT_NBR INNER JOIN
			dbo.JOB_LOG J ON J.JOB_NUMBER = C.JOB_NUMBER INNER JOIN 
			dbo.CLIENT CL ON CL.CL_CODE = C.CL_CODE INNER JOIN 
			--dbo.DIVISION D ON D.CL_CODE = C.CL_CODE AND
			--				  D.DIV_CODE = C.DIV_CODE INNER JOIN 
			--dbo.PRODUCT P ON P.CL_CODE = C.CL_CODE AND
			--				 P.DIV_CODE = C.DIV_CODE AND
			--				 P.PRD_CODE = C.PRD_CODE INNER JOIN 
			dbo.OFFICE O ON O.OFFICE_CODE = B.OFFICE_CODE LEFT JOIN
			dbo.OFFICE P ON P.OFFICE_CODE = E.OFFICE_CODE LEFT JOIN
			dbo.AGENCY_CLIENTS ON C.CL_CODE = AGENCY_CLIENTS.CL_CODE
		WHERE (B.OFFICE_CODE = @office_code OR @office_code IS NULL) AND
			(A.PPPERIOD = @post_period) AND
			--(DE.EMP_CODE = @emp_code OR @emp_code IS NULL) --AND
			(B.USER_ASSIGNED = @emp_code OR @emp_code IS NULL)

	UNION ALL
	/* Indirect Time - No C/D/P */
	SELECT	EmployeeTimeForecastID = A.ETF_ID, 
			EmployeeTimeForecastDescription = A.FC_DESCRIPTION, 
			EmployeeTimeForecastComment = '', --C.CATEGORY, 
			RevisionNumber = B.REV_NBR,
			OfficeCode = B.OFFICE_CODE,
			OfficeName = O.OFFICE_NAME,
			PostPeriod = A.PPPERIOD,
			CreatedBy = B.USER_CREATED, 
			ModifiedBy = B.USER_MODIFIED, 
			ApprovedBy = B.APPROVED_BY,
			AssignedEmployee = B.USER_ASSIGNED, 
			EmployeeTitle = E.EMP_TITLE,
			EmployeeCode = E.EMP_CODE,
			EmployeeName = CASE WHEN E.EMP_MI IS NULL OR E.EMP_MI = '' THEN RTRIM(LTRIM(ISNULL(E.EMP_FNAME, '') + ' ' + ISNULL(E.EMP_LNAME, ''))) ELSE E.EMP_FNAME + ' ' + E.EMP_MI + '. ' + E.EMP_LNAME END,
			EmployeeOfficeName = P.OFFICE_NAME,
			--ClientCode = NULL,
			--ClientDescription = NULL,
			--DivisionCode = NULL,
			--DivisionDescription = NULL,
			--ProductCode = NULL,
			--ProductDescription = NULL,
			ForecastedDirectHours =	0,
			ForecastedAgencyHours = 0,
			ForecastedNewBusinessHours = 0,
			TotalForecastedDirectHours = 0,
			BillRate = D.BILL_RATE, 
			CostRate = D.COST_RATE, 
			TotalForecastedRevenue = 0,
			TotalForecastedIndirectHours = C.HOURS,
			TotalForecastedHours  = 0,	--(Is the sum of the total forecasted direct hours and total forecasted indirect hours)
			TotalAvailableHours = 0, --(Hours worked per day, days worked, work days in month) 
			DirectHoursGoalByEmployee = 0,
			BillableHoursGoalByEmployee = 0, 
			AvailableToForecastedVariance = 0,
			E.DIRECT_HRS_PER,
			E.EMP_CODE
		FROM 
			dbo.ETF_HDR A JOIN 
			dbo.ETF_OFFDTL B ON A.ETF_ID = B.ETF_ID JOIN 
			dbo.ETF_OFFDTLCAT_EMP C ON C.ETF_ID = B.ETF_ID AND C.ETF_OFFDTL_ID = B.ETF_OFFDTL_ID JOIN 
			dbo.ETF_OFFDTLEMP D ON D.ETF_ID = C.ETF_ID AND
										   D.ETF_OFFDTL_ID = C.ETF_OFFDTL_ID AND 
										   D.ETF_OFFDTLEMP_ID = C.ETF_OFFDTLEMP_ID JOIN
			dbo.EMPLOYEE E ON E.EMP_CODE = D.EMP_CODE LEFT JOIN 
			dbo.OFFICE O ON O.OFFICE_CODE = B.OFFICE_CODE LEFT JOIN 
			dbo.OFFICE P ON P.OFFICE_CODE = E.OFFICE_CODE 

		WHERE (B.OFFICE_CODE = @office_code OR @office_code IS NULL) AND
			(A.PPPERIOD = @post_period) AND
			--(E.EMP_CODE = @emp_code OR @emp_code IS NULL) AND
			(B.USER_ASSIGNED = @emp_code OR @emp_code IS NULL) AND
			(ABS(ISNULL(C.HOURS,0)) > 0)

		) ETF_UNION

GROUP BY EmployeeTimeForecastID,EmployeeTimeForecastDescription,EmployeeTimeForecastComment,
	RevisionNumber,OfficeCode,OfficeName,PostPeriod,
	CreatedBy,ModifiedBy,ApprovedBy,AssignedEmployee,
	EmployeeCode,EmployeeName,EmployeeOfficeName,EmployeeTitle,
	BillRate,CostRate

END
GO


