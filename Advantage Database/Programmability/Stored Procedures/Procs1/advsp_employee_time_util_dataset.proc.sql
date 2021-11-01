IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_employee_time_util_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_employee_time_util_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_employee_time_util_dataset]
(
	@StartDate datetime,
	@EndDate datetime,
	@UserID varchar(100),
	@Groupby varchar(10),
	@LimitWIP bit,
	@OFFICE_LIST AS varchar(MAX) = NULL,
	@DEPT_LIST AS varchar(MAX) = NULL
)
AS
BEGIN
	SET NOCOUNT OFF
	
	CREATE TABLE #months(
	RowID int IDENTITY(1, 1), 
	[Month] int,
	Startdate datetime,
	Enddate datetime)

	CREATE TABLE #emps(
	RowID int IDENTITY(1, 1), 
	EmpCode varchar(6))

	DECLARE 
	@ERR INT, @PPStart int, @PPEnd int, @StdHours as decimal(9,3), @NumberRecords int, @RowCount int, @EmpDate datetime, @NumberRecords2 int, @RowCount2 int, @EmpCode varchar(6),
		@sd datetime, @ed datetime, @Month int
	

	--SELECT @startdate, @enddate
	
	CREATE TABLE #emp_util_time_data(
		ID [int]			IDENTITY(1,1) NOT NULL,
		RecordType					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EmployeeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DepartmentCode				varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		PostPeriod					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ARPostPeriod					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EmployeeDate					smalldatetime NULL,
		ClientCode						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductCode						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JobNumber					integer NULL,
		JobComponentNumber			smallint NULL,
		FunctionCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		Category					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DirectType					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PostedHours				decimal(15,2) NULL,
		DirectHours				decimal(15,2) NULL,
		TotalCost					decimal(15,2) NULL,
		BillableHours				decimal(15,2) NULL,
		DirectNonBillableHours	decimal(15,2) NULL,
		DirectNewBusinessHours	decimal(15,2) NULL,
		DirectAgencyHours			decimal(15,2) NULL,
		BilledHours				decimal(15,2) NULL,
		WIPHours					decimal(15,2) NULL,
		NonProdHours				decimal(15,2) NULL,
		DirectAmount					decimal(15,2) NULL,
		BillableAmount				decimal(15,2) NULL,
		DirectNonbillableAmount		decimal(15,2) NULL,
		DirectNewBusinessAmount		decimal(15,2) NULL,
		DirectAgencyAmount			decimal(15,2) NULL,
		MarkUpDownAmount			decimal(15,2) NULL,
		MarkUpDownHours			decimal(15,5) NULL,
		BilledAmount					decimal(15,2) NULL,
		WIPAmount						decimal(15,2) NULL,
		[Type]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FeeTIme					tinyint NULL,
		StandardHours			decimal(9,3) NULL)

	CREATE TABLE #emp_util_time_data_total(
		ID [int]			IDENTITY(1,1) NOT NULL,
		EmployeeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DepartmentCode				varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		EmployeeDate					smalldatetime NULL,
		PostPeriod					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		StandardHours			decimal(9,3) NULL,
		DirectHoursGoal				decimal(15,2) NULL,
		BillableHoursGoal				decimal(15,2) NULL,
		BillableHours				decimal(15,2) NULL,
		BillableAmount				decimal(15,2) NULL,
		NonBillableHours	decimal(15,2) NULL,
		NonbillableAmount		decimal(15,2) NULL,
		AgencyHours		    decimal(15,2) NULL,
		AgencyAmount		decimal(15,2) NULL,
		NewBusinessHours	decimal(15,2) NULL,
		NewBusinessAmount		decimal(15,2) NULL,
		DirectHours				decimal(15,2) NULL,
		DirectAmount					decimal(15,2) NULL,
		NonDirectHours				decimal(15,2) NULL,
		TotalHours				decimal(15,2) NULL,
		Variance				decimal(15,2) NULL,
		PercentDirect				decimal(15,2) NULL,
		PercentNonDirect				decimal(15,2) NULL,
		PercentOfRequiredHours				decimal(15,2) NULL,
		PercentOfDirectHoursGoal				decimal(15,2) NULL,
		PercentOfBillableHoursGoal				decimal(15,2) NULL,
		BilledHours				decimal(15,2) NULL,
		BilledAmount					decimal(15,2) NULL,
		WIPHours					decimal(15,2) NULL,
		WIPAmount						decimal(15,2) NULL,
		WriteUpDownHours			decimal(15,5) NULL,
		WriteUpDownAmount			decimal(15,2) NULL,
		PercentBilled			decimal(15,2) NULL,
		PercentBilledOfDirectHoursGoal			decimal(15,2) NULL,
		PercentBilledOfBillableHoursGoal			decimal(15,2) NULL,
		PercentBilledOfRequiredHours			decimal(15,2) NULL,
		AverageHourlyRateBilled			decimal(15,2) NULL,
		AverageHourlyRateAchieved			decimal(15,2) NULL,
		EmployeeTimeOff			decimal(15,2) NULL)

	CREATE TABLE #standardHours(
		ID [int]			IDENTITY(1,1) NOT NULL,
		EmployeeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		StandardHours			decimal(9,3) NULL)
		
	INSERT INTO #emp_util_time_data (
	    RecordType,
		EmployeeCode,
		DepartmentCode,	
		PostPeriod,
		ARPostPeriod,
		EmployeeDate,
		ClientCode,
		DivisionCode,
		ProductCode,
		JobNumber,
		JobComponentNumber,
		FunctionCode,
		Category,
		DirectType,
		PostedHours,
		DirectHours,
		TotalCost,
		BillableHours,
		DirectNonBillableHours,
		DirectNewBusinessHours,
		DirectAgencyHours,
		BilledHours,
		WIPHours,
		NonProdHours,
		DirectAmount,
		BillableAmount,
		DirectNonbillableAmount,
		DirectNewBusinessAmount,
		DirectAgencyAmount,
		MarkUpDownAmount,
		MarkUpDownHours,
		BilledAmount,
		WIPAmount,
		[Type],
		FeeTIme)
	EXEC advsp_employee_time_util_data 1,1,'',2,NULL,NULL,@StartDate,@EndDate,1,1,0,@LimitWIP

	--SELECT * FROM #emp_util_time_data

	DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

	INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
	VALUES(@UserID, @startdate, @enddate)

	--INSERT INTO #months
	--SELECT PPGLMONTH, PPSRTDATE, PPENDDATE
	--FROM POSTPERIOD
	--WHERE PPSRTDATE >= @startdate AND PPENDDATE <= @enddate AND PPGLMONTH <> 99
	----SELECT * FROM #months

	--INSERT #emps
	--SELECT DISTINCT WS.EMP_CODE
	--FROM W_EMP_STD_HOURS_DTL WS 
	--	LEFT OUTER JOIN EMPLOYEE E ON WS.EMP_CODE = E.EMP_CODE
	--WHERE E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE >= @startdate
	----SELECT * FROM #emps

	--SELECT @NumberRecords = COUNT(*) FROM #months
	--SET @RowCount = 1

	--SELECT @NumberRecords2 = COUNT(*) FROM #emps
	--SET @RowCount2 = 1

	--WHILE @RowCount <= @NumberRecords
	--BEGIN
	--	SELECT @sd = Startdate, @ed = Enddate
	--	FROM #months
	--	WHERE RowID = @RowCount

	--	WHILE @RowCount2 <= @NumberRecords2
	--	BEGIN
	--		SELECT @EmpCode = EmpCode
	--		FROM #emps
	--		WHERE RowID = @RowCount2

	--		SELECT @StdHours = SUM(STD_HRS)
	--		FROM W_EMP_STD_HOURS_DTL WS
	--		WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = @EmpCode AND WS.WORK_DATE >= @sd AND WS.WORK_DATE <= @ed

	--		INSERT INTO #standardHours (EmployeeCode,StandardHours)
	--		VALUES(@EmpCode, ISNULL(@StdHours,0))

	--		--INSERT INTO #emp_util_time_data (
	--		--    RecordType,
	--		--	EmployeeCode,
	--		--	DepartmentCode,	
	--		--	PostPeriod,
	--		--	ARPostPeriod,
	--		--	EmployeeDate,
	--		--	ClientCode,
	--		--	DivisionCode,
	--		--	ProductCode,
	--		--	JobNumber,
	--		--	JobComponentNumber,
	--		--	FunctionCode,
	--		--	Category,
	--		--	DirectType,
	--		--	PostedHours,
	--		--	DirectHours,
	--		--	TotalCost,
	--		--	BillableHours,
	--		--	DirectNonBillableHours,
	--		--	DirectNewBusinessHours,
	--		--	DirectAgencyHours,
	--		--	BilledHours,
	--		--	WIPHours,
	--		--	NonProdHours,
	--		--	DirectAmount,
	--		--	BillableAmount,
	--		--	DirectNonbillableAmount,
	--		--	DirectNewBusinessAmount,
	--		--	DirectAgencyAmount,
	--		--	MarkUpDownAmount,
	--		--	MarkUpDownHours,
	--		--	BilledAmount,
	--		--	WIPAmount,
	--		--	[Type],
	--		--	FeeTIme,
	--		--	StandardHours)
	--		--VALUES('S',@EmpCode,NULL,NULL,NULL,@sd,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,@StdHours)

	--		if @EmpCode NOT IN (SELECT DISTINCT EmployeeCode FROM #emp_util_time_data)
	--		Begin
	--			INSERT INTO #emp_util_time_data (EmployeeCode)
	--			SELECT @EmpCode
	--		End

	--	 SET @RowCount2 = @RowCount2 + 1
	--	END		
	-- SET @RowCount2 = 1	
	-- SET @RowCount = @RowCount + 1
	--END
			
	--UPDATE DASH_DATA_EMP_TIME
			--SET STD_HOURS = (
			--SELECT STD_HRS 
			--FROM W_EMP_STD_HOURS_DTL WS
			--WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE AND WS.WORK_DATE = DASH_DATA_EMP_TIME.EMP_DATE)]

	--SELECT * FROM #standardHours
	--SELECT * FROM #emp_util_time_data

	
	--if @LimitWIP = 1
	--Begin
	--	DELETE FROM #emp_util_time_data
	--	WHERE RecordType = 'W' AND (EmployeeDate < @StartDate OR EmployeeDate > @EndDate)
	--End

	--SELECT * FROM #emp_util_time_data

    if @Groupby = 'emp'
	Begin

		INSERT INTO #emp_util_time_data_total
		SELECT EmployeeCode,NULL,NULL,NULL,
			(SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = EmployeeCode AND WS.WORK_DATE BETWEEN @StartDate and @EndDate AND USERID = @UserID),
			--ISNULL(SUM(StandardHours),0),
			0,
			0,
			ISNULL(SUM(BillableHours),0),
			ISNULL(SUM(BillableAmount),0),
			ISNULL(SUM(DirectNonBillableHours),0),
			ISNULL(SUM(DirectNonBillableAmount),0),
			ISNULL(SUM(DirectAgencyHours),0),
			ISNULL(SUM(DirectAgencyAmount),0),
			ISNULL(SUM(DirectNewBusinessHours),0),
			ISNULL(SUM(DirectNewBusinessAmount),0),
			ISNULL(SUm(DirectHours),0),
			ISNULL(SUM(DirectAmount),0),
			ISNULL(SUM(NonProdHours),0),
			0,
			0,
			0,0,0,0,0,
			ISNULL(SUM(BilledHours),0),
			ISNULL(SUM(BilledAmount),0),
			ISNULL(SUM(WIPHours),0),
			ISNULL(SUM(WIPAmount),0),
			ISNULL(SUM(MarkUpDownHours),0),
			ISNULL(SUM(MarkUpDownAmount),0),
			0,0,0,0,0,0,0
		FROM #emp_util_time_data
		GROUP BY EmployeeCode
		
		--UPDATE #emp_util_time_data_total
		--SET StandardHours = (SELECT SUM(StandardHours) FROM #standardHours WHERE EmployeeCode = #emp_util_time_data_total.EmployeeCode GROUP BY #standardHours.EmployeeCode)

		UPDATE #emp_util_time_data_total
		SET EmployeeTimeOff = (SELECT ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0) AS EMP_HOURS
								FROM EMP_TIME_NP INNER JOIN
									 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
									 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
									 TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
								WHERE (EMP_TIME.EMP_CODE = #emp_util_time_data_total.EmployeeCode) AND (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @EndDate) AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3))
		
		SET @Month = DATEDIFF(mm, @StartDate, @EndDate) + 1

		SELECT 
			[ID],
			E.OFFICE_CODE as EmployeeOffice,
			O.OFFICE_NAME as EmployeeOfficeName,
			D.DP_TM_CODE as EmployeeDepartment,
			D.DP_TM_DESC as EmployeeDepartmentName,
			EmployeeCode,
			E.EMP_FNAME + ISNULL(' ' + E.EMP_MI + '. ',' ') + E.EMP_LNAME as EmployeeName,
			E.EMP_FNAME as EmployeeFirstName,
			E.EMP_LNAME as EmployeeLastName,
			E.EMP_DATE as EmploymentDate,
			E.SUPERVISOR_CODE as SupervisorCode,
            E.EMP_TERM_DATE AS EmployeeTerminationDate,
			CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END as Supervisor,
			NULL as EmployeeDate,
			NULL as PostPeriod,
			NULL as [Month],
			NULL as [Year],
			E.STD_ANNUAL_HRS as StandardAnnualHours,
			ISNULL(StandardHours,0) as RequiredHours,
			ISNULL((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01),0) as DirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0
				ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END as BillableHoursGoal,
			BillableHours,
			BillableAmount,
			NonBillableHours,
			NonBillableAmount,
			(BillableHours + NonBillableHours) AS ClientHours,
			(BillableAmount + NonbillableAmount) AS ClientAmount,
			AgencyHours,
			AgencyAmount,
			NewBusinessHours,
			NewBusinessAmount,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours) as TotalDirectHours,
			(BillableAmount + NonbillableAmount + AgencyAmount + NewBusinessAmount) as TotalDirectAmount,
			NonDirectHours,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours) as TotalHours,
			ISNULL(StandardHours - (BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) as Variance,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentDirect,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((NonDirectHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentNonDirect,
			CASE WHEN ISNULL((StandardHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)/(StandardHours)),0) * 100 ELSE 0 END as PercentOfRequiredHours,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours))/((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01)),0) * 100 ELSE 0 END as PercentOfDirectHoursGoal,
			CASE WHEN (CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END) <> 0 THEN 
			ISNULL(((BillableHours)/(CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END)),0) * 100 ELSE 0 END as PercentOfBillableHoursGoal,
			BilledHours,
			BilledAmount,
			WIPHours,
			WIPAmount,
			WriteUpDownAmount,
			CASE WHEN ISNULL(DirectHours,0) <> 0 THEN ISNULL((BilledHours/DirectHours),0) * 100 ELSE 0 END as PercentBilled,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN (BilledHours / ((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01))) ELSE 0 END as PercentBilledOfDirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 WHEN E.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((Billedhours/ISNULL(CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END,1)),0) * 100 END as PercentBilledOfBillableHoursGoal,
			CASE WHEN StandardHours <> 0 THEN ISNULL((BilledHours/StandardHours),0) ELSE 0 END as PercentBilledOfRequiredHours,
			CASE WHEN BilledHours = 0 THEN 0 ELSE ISNULL((BilledAmount/BilledHours),0) END as AverageHourlyRateBilled,
			CASE WHEN DirectHours = 0 THEN 0 ELSE ISNULL((BilledAmount/DirectHours),0) END as AverageHourlyRateAchieved
		FROM #emp_util_time_data_total eut INNER JOIN
			 EMPLOYEE E ON E.EMP_CODE = eut.EmployeeCode LEFT OUTER JOIN
			 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
			 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
			 EMPLOYEE SUP ON E.SUPERVISOR_CODE = SUP.EMP_CODE
		WHERE (@OFFICE_LIST IS NULL OR (@OFFICE_LIST IS NOT NULL AND E.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ','))))
			  AND (@DEPT_LIST IS NULL OR (@DEPT_LIST IS NOT NULL AND E.DP_TM_CODE IN (SELECT * from dbo.udf_split_list(@DEPT_LIST, ','))))
	
	End

	if @Groupby = 'empdate'
	Begin
		INSERT INTO #emp_util_time_data_total
		SELECT EmployeeCode,NULL,EmployeeDate,NULL,
			(SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = EmployeeCode AND WS.WORK_DATE = EmployeeDate AND USERID = @UserID),
			--ISNULL(SUM(StandardHours),0),
			0,
			0,
			ISNULL(SUM(BillableHours),0),
			ISNULL(SUM(BillableAmount),0),
			ISNULL(SUM(DirectNonBillableHours),0),
			ISNULL(SUM(DirectNonBillableAmount),0),
			ISNULL(SUM(DirectAgencyHours),0),
			ISNULL(SUM(DirectAgencyAmount),0),
			ISNULL(SUM(DirectNewBusinessHours),0),
			ISNULL(SUM(DirectNewBusinessAmount),0),
			ISNULL(SUm(DirectHours),0),
			ISNULL(SUM(DirectAmount),0),
			ISNULL(SUM(NonProdHours),0),
			0,
			0,
			0,0,0,0,0,
			ISNULL(SUM(BilledHours),0),
			ISNULL(SUM(BilledAmount),0),
			ISNULL(SUM(WIPHours),0),
			ISNULL(SUM(WIPAmount),0),
			ISNULL(SUM(MarkUpDownHours),0),
			ISNULL(SUM(MarkUpDownAmount),0),
			0,0,0,0,0,0,0
		FROM #emp_util_time_data
		GROUP BY EmployeeCode,EmployeeDate

		--SELECT * FROM #emp_util_time_data
		--SELECT * FROM #emp_util_time_data_total

		--UPDATE #emp_util_time_data_total
		--SET StandardHours = (SELECT SUM(StandardHours) FROM #standardHours WHERE EmployeeCode = #emp_util_time_data_total.EmployeeCode GROUP BY #standardHours.EmployeeCode)

		UPDATE #emp_util_time_data_total
		SET EmployeeTimeOff = (SELECT ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0) AS EMP_HOURS
								FROM EMP_TIME_NP INNER JOIN
									 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
									 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
									 TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
								WHERE (EMP_TIME.EMP_CODE = #emp_util_time_data_total.EmployeeCode) AND (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @EndDate) AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3))
		
		SET @Month = DATEDIFF(mm, @StartDate, @EndDate) + 1

		SELECT 
			[ID],
			E.OFFICE_CODE as EmployeeOffice,
			O.OFFICE_NAME as EmployeeOfficeName,
			D.DP_TM_CODE as EmployeeDepartment,
			D.DP_TM_DESC as EmployeeDepartmentName,
			EmployeeCode,
			E.EMP_FNAME + ISNULL(' ' + E.EMP_MI + '. ',' ') + E.EMP_LNAME as EmployeeName,
			E.EMP_FNAME as EmployeeFirstName,
			E.EMP_LNAME as EmployeeLastName,
			E.EMP_DATE as EmploymentDate,
			E.SUPERVISOR_CODE as SupervisorCode,
            E.EMP_TERM_DATE AS EmployeeTerminationDate,
			CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END as Supervisor,
			EmployeeDate,
			(SELECT PPPERIOD FROM POSTPERIOD WHERE EmployeeDate BETWEEN PPSRTDATE AND PPENDDATE) as PostPeriod,
			(SELECT datename(month,EmployeeDate)) as [Month],
			(SELECT datepart(year,EmployeeDate)) as [Year],
			E.STD_ANNUAL_HRS as StandardAnnualHours,
			ISNULL(StandardHours,0) as RequiredHours,
			ISNULL((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01),0) as DirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0
				ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END as BillableHoursGoal,
			BillableHours,
			BillableAmount,
			NonBillableHours,
			NonBillableAmount,
			(BillableHours + NonBillableHours) AS ClientHours,
			(BillableAmount + NonbillableAmount) AS ClientAmount,
			AgencyHours,
			AgencyAmount,
			NewBusinessHours,
			NewBusinessAmount,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours) as TotalDirectHours,
			(BillableAmount + NonbillableAmount + AgencyAmount + NewBusinessAmount) as TotalDirectAmount,
			NonDirectHours,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours) as TotalHours,
			ISNULL(StandardHours - (BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) as Variance,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentDirect,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((NonDirectHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentNonDirect,
			CASE WHEN ISNULL((StandardHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)/(StandardHours)),0) * 100 ELSE 0 END as PercentOfRequiredHours,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours))/((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01)),0) * 100 ELSE 0 END as PercentOfDirectHoursGoal,
			CASE WHEN (CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END) <> 0 THEN 
			ISNULL(((BillableHours)/(CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END)),0) * 100 ELSE 0 END as PercentOfBillableHoursGoal,
			BilledHours,
			BilledAmount,
			WIPHours,
			WIPAmount,
			WriteUpDownAmount,
			CASE WHEN ISNULL(DirectHours,0) <> 0 THEN ISNULL((BilledHours/DirectHours),0) * 100 ELSE 0 END as PercentBilled,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN (BilledHours / ((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01))) ELSE 0 END as PercentBilledOfDirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 WHEN E.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((Billedhours/ISNULL(CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END,1)),0) * 100 END as PercentBilledOfBillableHoursGoal,
			CASE WHEN StandardHours <> 0 THEN ISNULL((BilledHours/StandardHours),0) ELSE 0 END as PercentBilledOfRequiredHours,
			CASE WHEN BilledHours = 0 THEN 0 ELSE ISNULL((BilledAmount/BilledHours),0) END as AverageHourlyRateBilled,
			CASE WHEN DirectHours = 0 THEN 0 ELSE ISNULL((BilledAmount/DirectHours),0) END as AverageHourlyRateAchieved
		FROM #emp_util_time_data_total eut INNER JOIN
			 EMPLOYEE E ON E.EMP_CODE = eut.EmployeeCode LEFT OUTER JOIN
			 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE  LEFT OUTER JOIN
			 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
			 EMPLOYEE SUP ON E.SUPERVISOR_CODE = SUP.EMP_CODE
		WHERE (@OFFICE_LIST IS NULL OR (@OFFICE_LIST IS NOT NULL AND E.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ','))))
			  AND (@DEPT_LIST IS NULL OR (@DEPT_LIST IS NOT NULL AND E.DP_TM_CODE IN (SELECT * from dbo.udf_split_list(@DEPT_LIST, ','))))
	
	End

	if @Groupby = 'empperiod'
	Begin
		INSERT INTO #emp_util_time_data_total
		SELECT EmployeeCode,NULL,NULL,PostPeriod,
			(SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE WS.EMP_CODE = EmployeeCode AND WS.WORK_DATE BETWEEN (SELECT PPSRTDATE FROM POSTPERIOD WHERE PPPERIOD = PostPeriod) AND (SELECT PPENDDATE FROM POSTPERIOD WHERE PPPERIOD = PostPeriod) AND USERID = @UserID),
			--ISNULL(SUM(StandardHours),0),
			0,
			0,
			ISNULL(SUM(BillableHours),0),
			ISNULL(SUM(BillableAmount),0),
			ISNULL(SUM(DirectNonBillableHours),0),
			ISNULL(SUM(DirectNonBillableAmount),0),
			ISNULL(SUM(DirectAgencyHours),0),
			ISNULL(SUM(DirectAgencyAmount),0),
			ISNULL(SUM(DirectNewBusinessHours),0),
			ISNULL(SUM(DirectNewBusinessAmount),0),
			ISNULL(SUm(DirectHours),0),
			ISNULL(SUM(DirectAmount),0),
			ISNULL(SUM(NonProdHours),0),
			0,
			0,
			0,0,0,0,0,
			ISNULL(SUM(BilledHours),0),
			ISNULL(SUM(BilledAmount),0),
			ISNULL(SUM(WIPHours),0),
			ISNULL(SUM(WIPAmount),0),
			ISNULL(SUM(MarkUpDownHours),0),
			ISNULL(SUM(MarkUpDownAmount),0),
			0,0,0,0,0,0,0
		FROM #emp_util_time_data
		GROUP BY EmployeeCode,PostPeriod

		--UPDATE #emp_util_time_data_total
		--SET StandardHours = (SELECT SUM(StandardHours) FROM #standardHours WHERE EmployeeCode = #emp_util_time_data_total.EmployeeCode GROUP BY #standardHours.EmployeeCode)

		UPDATE #emp_util_time_data_total
		SET EmployeeTimeOff = (SELECT ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0) AS EMP_HOURS
								FROM EMP_TIME_NP INNER JOIN
									 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
									 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
									 TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
								WHERE (EMP_TIME.EMP_CODE = #emp_util_time_data_total.EmployeeCode) AND (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @EndDate) AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3))

		--SELECT * FROM #emp_util_time_data_total
		SET @Month = DATEDIFF(mm, @StartDate, @EndDate) + 1

		SELECT 
			[ID],
			E.OFFICE_CODE as EmployeeOffice,
			O.OFFICE_NAME as EmployeeOfficeName,
			D.DP_TM_CODE as EmployeeDepartment,
			D.DP_TM_DESC as EmployeeDepartmentName,
			EmployeeCode,
			E.EMP_FNAME + ISNULL(' ' + E.EMP_MI + '. ',' ') + E.EMP_LNAME as EmployeeName,
			E.EMP_FNAME as EmployeeFirstName,
			E.EMP_LNAME as EmployeeLastName,
			E.EMP_DATE as EmploymentDate,
			E.SUPERVISOR_CODE as SupervisorCode,
            E.EMP_TERM_DATE AS EmployeeTerminationDate,
            CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END as Supervisor,
			NULL as EmployeeDate,
			PostPeriod as PostPeriod,
			(SELECT datename(month,PPSRTDATE) FROM POSTPERIOD WHERE PPPERIOD = PostPeriod) as [Month],
			(SELECT Cast(PPGLYEAR as int) FROM POSTPERIOD WHERE PPPERIOD = PostPeriod) as [Year],
			E.STD_ANNUAL_HRS as StandardAnnualHours,
			ISNULL(StandardHours,0) as RequiredHours,
			ISNULL((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01),0) as DirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0
				ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END as BillableHoursGoal,
			BillableHours,
			BillableAmount,
			NonBillableHours,
			NonBillableAmount,
			(BillableHours + NonBillableHours) AS ClientHours,
			(BillableAmount + NonbillableAmount) AS ClientAmount,
			AgencyHours,
			AgencyAmount,
			NewBusinessHours,
			NewBusinessAmount,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours) as TotalDirectHours,
			(BillableAmount + NonbillableAmount + AgencyAmount + NewBusinessAmount) as TotalDirectAmount,
			NonDirectHours,
			(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours) as TotalHours,
			ISNULL(StandardHours - (BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) as Variance,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentDirect,
			CASE WHEN ISNULL((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours),0) <> 0 THEN ISNULL(((NonDirectHours)/(BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)),0) * 100 ELSE 0 END as PercentNonDirect,
			CASE WHEN ISNULL((StandardHours),0) <> 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours + NonDirectHours)/(StandardHours)),0) * 100 ELSE 0 END as PercentOfRequiredHours,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN ISNULL(((BillableHours + NonBillableHours + AgencyHours + NewBusinessHours))/((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01)),0) * 100 ELSE 0 END as PercentOfDirectHoursGoal,
			CASE WHEN (CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END) <> 0 THEN 
			ISNULL(((BillableHours)/(CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 ELSE CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END END)),0) * 100 ELSE 0 END as PercentOfBillableHoursGoal,
			BilledHours,
			BilledAmount,
			WIPHours,
			WIPAmount,
			WriteUpDownAmount,
			CASE WHEN ISNULL(DirectHours,0) <> 0 THEN ISNULL((BilledHours/DirectHours),0) * 100 ELSE 0 END as PercentBilled,
			CASE WHEN (StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01) > 0 THEN (BilledHours / ((StandardHours - EmployeeTimeOff) * (ISNULL(E.DIRECT_HRS_PER,0.000000) * .01))) ELSE 0 END as PercentBilledOfDirectHoursGoal,
			CASE WHEN E.MTH_HRS_GOAL IS NULL THEN 0 WHEN E.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((Billedhours/ISNULL(CASE WHEN @Month > 1 THEN (E.MTH_HRS_GOAL * @Month) ELSE E.MTH_HRS_GOAL END,1)),0) * 100 END as PercentBilledOfBillableHoursGoal,
			CASE WHEN StandardHours <> 0 THEN ISNULL((BilledHours/StandardHours),0) ELSE 0 END as PercentBilledOfRequiredHours,
			CASE WHEN BilledHours = 0 THEN 0 ELSE ISNULL((BilledAmount/BilledHours),0) END as AverageHourlyRateBilled,
			CASE WHEN DirectHours = 0 THEN 0 ELSE ISNULL((BilledAmount/DirectHours),0) END as AverageHourlyRateAchieved
		FROM #emp_util_time_data_total eut INNER JOIN
			 EMPLOYEE E ON E.EMP_CODE = eut.EmployeeCode LEFT OUTER JOIN
			 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
			 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
			 EMPLOYEE SUP ON E.SUPERVISOR_CODE = SUP.EMP_CODE
		WHERE (@OFFICE_LIST IS NULL OR (@OFFICE_LIST IS NOT NULL AND E.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ','))))
			  AND (@DEPT_LIST IS NULL OR (@DEPT_LIST IS NOT NULL AND E.DP_TM_CODE IN (SELECT * from dbo.udf_split_list(@DEPT_LIST, ','))))
	
	End
	
	

	--SELECT * FROM #emp_util_time_data_total

	

    DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

	SET @ERR = @@Error

	--RETURN @ERR
END



