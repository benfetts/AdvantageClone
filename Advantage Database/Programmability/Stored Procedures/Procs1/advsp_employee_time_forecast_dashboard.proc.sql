IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_employee_time_forecast_dashboard]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_employee_time_forecast_dashboard] 
GO


CREATE PROCEDURE [dbo].[advsp_employee_time_forecast_dashboard] 
(
@start_period int = 195101,
@end_period int = 219912,
@dept varchar(4),
@IncludeAlternate bit,
@includeJobDetail bit,
@EmployeeCode varchar(6),
@Alternate varchar(100),
@IncludeSupervised bit,
@ByMonth bit,
@ViewType smallint,
@UserID varchar(100),
@ByClient bit, 
@ByType bit,
@ForecastOnly bit
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @start_date smalldatetime, @end_date smalldatetime, @StartPPMonth int, @StartPPYear int, @EndPPMonth int, @EndPPYear int

	--Temp variables to store starting and ending dates for periods - modified 10/1/10
	--@start_date
	SET @start_date = (SELECT d.PPSRTDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@start_period AS varchar(6)) ) 
	--SET @StartPPMonth = (SELECT d.PPGLMONTH FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@start_period AS varchar(6)) ) 
	--SET @StartPPYear = (SELECT d.PPGLYEAR FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@start_period AS varchar(6)) ) 
			
	----SELECT @start_date
	----@end_date
	SET @end_date =	(SELECT d.PPENDDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@end_period AS varchar(6)) )
	--SET @EndPPMonth = (SELECT d.PPGLMONTH FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@end_period AS varchar(6)) ) 
	--SET @EndPPYear = (SELECT d.PPGLYEAR FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@end_period AS varchar(6)) ) 

	--SET @end_date = CAST(@EndPPMonth AS VARCHAR(2)) + '/1/' + CAST(@EndPPYear AS VARCHAR(4))

	--SET @start_date = CAST(@StartPPMonth AS VARCHAR(2)) + '/1/' + CAST(@StartPPYear AS VARCHAR(4))
	--SET @end_date = DateAdd(day, -1, DateAdd(month, DateDiff(month, 0, @end_date)+1, 0))
			
	--SELECT @start_date,@end_date
	
	if @dept = '' 
	BEGIN
		SET @dept = NULL
	END

	DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

	INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
	VALUES(@UserID, @start_date, @end_date)
	
	--SELECT * FROM W_EMP_STD_HOURS_DTL WHERE EMP_CODE = 'ama'
	
	--Main data table	
	CREATE TABLE #emp_time_forecast(
		OfficeName					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OfficeCode					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DepartmentName				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		DepartmentCode				varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		Employee					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientName					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		IsAlternateEmployee			bit,
		ForecastHours				decimal(19,2),
		ForecastAmount				decimal(19,2),
		JobNumber					int,
		JobComponentNumber			smallint,
		SalesClass					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		SalesClassCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	
		AccountExecutive			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AccountExecutiveCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,		
		ActualHours					decimal(19,2),
		ActualAmount				decimal(19,2),
		EmployeeTitleID				int, 
		JobAndJobComponent			varchar(1000),
		DirectType					varchar(2),
		[Month]						varchar(3),
		MonthNumber					smallint,
		[Year]  					int,
		ClientHours					decimal(19,2),
		AgencyHours					decimal(19,2),
		NewBusinessHours			decimal(19,2),
		IndirectHours				decimal(19,2),
		IndirectCategory			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BillableHours				decimal(19,2))

	CREATE TABLE #emp_time_actuals(		
		Employee					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JobNumber					int,
		JobComponentNumber			smallint,		
		ActualHours					decimal(19,2),
		ActualAmount				decimal(19,2))

	CREATE TABLE #emp_time_hours(		
		HoursType     			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Hours]					decimal(19,2))

	CREATE TABLE #emp_time_np_hours(	
		Category     			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Hours]					decimal(19,2))
	
	--INSERT INTO #emp_time_hours (HoursType, [Hours]) Values('Direct', 0)
	INSERT INTO #emp_time_hours (HoursType, [Hours]) Values('Agency', 0)
	INSERT INTO #emp_time_hours (HoursType, [Hours]) Values('Client', 0)
	INSERT INTO #emp_time_hours (HoursType, [Hours]) Values('New Business', 0)
	INSERT INTO #emp_time_hours (HoursType, [Hours]) Values('Indirect', 0)

	

	IF @EmployeeCode <> ''
	BEGIN
		--if @ByMonth = 0
		--BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3), PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
				INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
				INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = ETF_OFFDTLJC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ETF_OFFDTLJC.JOB_COMPONENT_NBR 
				INNER JOIN JOB_LOG J ON JOB_COMPONENT.JOB_NUMBER = J.JOB_NUMBER
		
				WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLEMP.EMP_CODE = @EmployeeCode --AND ETF_OFFDTLJC_EMP.HOURS > 0
				--GROUP BY ETF_OFFDTL.OFFICE_CODE, ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC.CL_CODE
		--END
		
		INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], ClientHours, AgencyHours, NewBusinessHours)
		SELECT EMP_CODE, EMP_TIME_DTL.JOB_NUMBER, JOB_COMPONENT_NBR, EMP_TIME_DTL.EMP_HOURS,EMP_TIME_DTL.TOTAL_BILL + EMP_TIME_DTL.EXT_MARKUP_AMT,0,0, 
				CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL'
				END,
				CASE WHEN MONTH(EMP_DATE) = 1 THEN 'Jan'
					 WHEN MONTH(EMP_DATE) = 2 THEN 'Feb'
					 WHEN MONTH(EMP_DATE) = 3 THEN 'Mar'
					 WHEN MONTH(EMP_DATE) = 4 THEN 'Apr'
					 WHEN MONTH(EMP_DATE) = 5 THEN 'May'
					 WHEN MONTH(EMP_DATE) = 6 THEN 'Jun'
					 WHEN MONTH(EMP_DATE) = 7 THEN 'Jul'
					 WHEN MONTH(EMP_DATE) = 8 THEN 'Aug'
					 WHEN MONTH(EMP_DATE) = 9 THEN 'Sep'
					 WHEN MONTH(EMP_DATE) = 10 THEN 'Oct'
					 WHEN MONTH(EMP_DATE) = 11 THEN 'Nov'
					 WHEN MONTH(EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_DATE), YEAR(EMP_DATE),
			    CASE WHEN CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL' END IN ('BL','NB') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN agy.CL_CODE IS NOT NULL THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN c.NEW_BUSINESS = 1 THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
				FROM EMP_TIME_DTL INNER JOIN
					 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
					 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
					 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
					 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
				WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date AND EMP_CODE = @EmployeeCode
						AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
									 WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END
		
		--if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 3 OR @ViewType = 4
		--BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectCategory, IndirectHours)
			SELECT EMP_TIME.EMP_CODE, 0, 0, EMP_HOURS,0,0,0,'IN',
					CASE WHEN MONTH(EMP_TIME.EMP_DATE) = 1 THEN 'Jan'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 2 THEN 'Feb'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 3 THEN 'Mar'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 4 THEN 'Apr'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 5 THEN 'May'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 6 THEN 'Jun'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 7 THEN 'Jul'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 8 THEN 'Aug'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 9 THEN 'Sep'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 10 THEN 'Oct'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 11 THEN 'Nov'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_TIME_NP.CATEGORY, EMP_HOURS
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
						TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_TIME.EMP_CODE = @EmployeeCode AND EMP_HOURS > 0
		--END		
		
		if @IncludeAlternate = 1
		BEGIN
			INSERT INTO #emp_time_forecast (Employee,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, EmployeeTitleID, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLAE.[DESCRIPTION], ETF_OFFDTLJC_AE.HOURS, ETF_OFFDTLAE.BILL_RATE*ETF_OFFDTLJC_AE.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,1, ETF_OFFDTLAE.EMPLOYEE_TITLE_ID,SUBSTRING(PPDESC, 1, 3) AS PPDESC, PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLAE ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLAE.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_AE ON (ETF_OFFDTLAE.ETF_OFFDTLAE_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLAE_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLJC_ID)
				INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
				--INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = ETF_OFFDTLJC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ETF_OFFDTLJC.JOB_COMPONENT_NBR 
				--INNER JOIN JOB_LOG J ON JOB_COMPONENT.JOB_NUMBER = J.JOB_NUMBER
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLJC_AE.HOURS > 0 --AND ETF_OFFDTLAE.[DESCRIPTION] = @Alternate
		END

		if @IncludeSupervised = 1
		BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3) AS PPDESC, PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
				INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
				INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = ETF_OFFDTLJC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ETF_OFFDTLJC.JOB_COMPONENT_NBR 
				INNER JOIN JOB_LOG J ON JOB_COMPONENT.JOB_NUMBER = J.JOB_NUMBER
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period  AND ETF_OFFDTLEMP.EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode)

			INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], ClientHours, AgencyHours, NewBusinessHours, BillableHours)
			SELECT EMP_CODE, EMP_TIME_DTL.JOB_NUMBER, JOB_COMPONENT_NBR, EMP_TIME_DTL.EMP_HOURS,EMP_TIME_DTL.TOTAL_BILL + EMP_TIME_DTL.EXT_MARKUP_AMT,0,0, 
				CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL'
				END,
				CASE WHEN MONTH(EMP_DATE) = 1 THEN 'Jan'
					 WHEN MONTH(EMP_DATE) = 2 THEN 'Feb'
					 WHEN MONTH(EMP_DATE) = 3 THEN 'Mar'
					 WHEN MONTH(EMP_DATE) = 4 THEN 'Apr'
					 WHEN MONTH(EMP_DATE) = 5 THEN 'May'
					 WHEN MONTH(EMP_DATE) = 6 THEN 'Jun'
					 WHEN MONTH(EMP_DATE) = 7 THEN 'Jul'
					 WHEN MONTH(EMP_DATE) = 8 THEN 'Aug'
					 WHEN MONTH(EMP_DATE) = 9 THEN 'Sep'
					 WHEN MONTH(EMP_DATE) = 10 THEN 'Oct'
					 WHEN MONTH(EMP_DATE) = 11 THEN 'Nov'
					 WHEN MONTH(EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_DATE), YEAR(EMP_DATE),
			   CASE WHEN CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL' END IN ('BL','NB') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN agy.CL_CODE IS NOT NULL THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN c.NEW_BUSINESS = 1 THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL' END NOT IN ('NB', 'AG') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
					FROM EMP_TIME_DTL INNER JOIN
						 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
						 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
						 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
						 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
					WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date AND EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode)
							AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
									   WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END

			--if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 4
			--BEGIN											

			 INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectCategory, IndirectHours)
			 SELECT EMP_TIME.EMP_CODE, 0, 0, EMP_HOURS,0,0,0,'IN',
					CASE WHEN MONTH(EMP_TIME.EMP_DATE) = 1 THEN 'Jan'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 2 THEN 'Feb'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 3 THEN 'Mar'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 4 THEN 'Apr'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 5 THEN 'May'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 6 THEN 'Jun'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 7 THEN 'Jul'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 8 THEN 'Aug'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 9 THEN 'Sep'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 10 THEN 'Oct'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 11 THEN 'Nov'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_TIME_NP.CATEGORY, EMP_HOURS
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE 
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_TIME.EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode) AND EMP_HOURS > 0

			--END
		END

	END
	ELSE
	BEGIN
		--if @ByMonth = 0
		--BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3) AS PPDESC, PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
				INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
				INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = ETF_OFFDTLJC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ETF_OFFDTLJC.JOB_COMPONENT_NBR 
				INNER JOIN JOB_LOG J ON JOB_COMPONENT.JOB_NUMBER = J.JOB_NUMBER
		
				WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period --AND ETF_OFFDTLJC_EMP.HOURS > 0
				--GROUP BY ETF_OFFDTL.OFFICE_CODE, ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC.CL_CODE
		--END	
		
		INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], ClientHours, AgencyHours, NewBusinessHours)
		SELECT EMP_CODE, EMP_TIME_DTL.JOB_NUMBER, JOB_COMPONENT_NBR, EMP_TIME_DTL.EMP_HOURS,EMP_TIME_DTL.TOTAL_BILL + EMP_TIME_DTL.EXT_MARKUP_AMT,0,0, 
				CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL'
				END,
				CASE WHEN MONTH(EMP_DATE) = 1 THEN 'Jan'
					 WHEN MONTH(EMP_DATE) = 2 THEN 'Feb'
					 WHEN MONTH(EMP_DATE) = 3 THEN 'Mar'
					 WHEN MONTH(EMP_DATE) = 4 THEN 'Apr'
					 WHEN MONTH(EMP_DATE) = 5 THEN 'May'
					 WHEN MONTH(EMP_DATE) = 6 THEN 'Jun'
					 WHEN MONTH(EMP_DATE) = 7 THEN 'Jul'
					 WHEN MONTH(EMP_DATE) = 8 THEN 'Aug'
					 WHEN MONTH(EMP_DATE) = 9 THEN 'Sep'
					 WHEN MONTH(EMP_DATE) = 10 THEN 'Oct'
					 WHEN MONTH(EMP_DATE) = 11 THEN 'Nov'
					 WHEN MONTH(EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_DATE), YEAR(EMP_DATE),
			    CASE WHEN CASE
					WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
					WHEN c.NEW_BUSINESS = 1 THEN 'NW'
					WHEN EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1 AND ISNULL(EMP_TIME_DTL.FEE_TIME, 0) = 0 THEN 'NB'
					ELSE 'BL' END IN ('BL','NB') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN agy.CL_CODE IS NOT NULL THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END,
				CASE WHEN c.NEW_BUSINESS = 1 THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
				FROM EMP_TIME_DTL INNER JOIN
					 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
					 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
					 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
					 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
				WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date
						AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
									   WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END

		--if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 3 OR @ViewType = 4
		--BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectCategory, IndirectHours)
			SELECT EMP_TIME.EMP_CODE, 0, 0, EMP_HOURS,0,0,0,'IN',
					CASE WHEN MONTH(EMP_TIME.EMP_DATE) = 1 THEN 'Jan'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 2 THEN 'Feb'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 3 THEN 'Mar'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 4 THEN 'Apr'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 5 THEN 'May'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 6 THEN 'Jun'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 7 THEN 'Jul'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 8 THEN 'Aug'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 9 THEN 'Sep'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 10 THEN 'Oct'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 11 THEN 'Nov'
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_TIME_NP.CATEGORY, EMP_HOURS
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
						TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_HOURS > 0
		--END		

		if @IncludeAlternate = 1
		BEGIN
			INSERT INTO #emp_time_forecast (Employee,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, EMployeeTitleID, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLAE.[DESCRIPTION], ETF_OFFDTLJC_AE.HOURS, ETF_OFFDTLAE.BILL_RATE*ETF_OFFDTLJC_AE.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,1, ETF_OFFDTLAE.EMPLOYEE_TITLE_ID,SUBSTRING(PPDESC, 1, 3) AS PPDESC, PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLAE ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLAE.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_AE ON (ETF_OFFDTLAE.ETF_OFFDTLAE_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLAE_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLJC_ID)
				INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
				INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = ETF_OFFDTLJC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ETF_OFFDTLJC.JOB_COMPONENT_NBR 
				INNER JOIN JOB_LOG J ON JOB_COMPONENT.JOB_NUMBER = J.JOB_NUMBER
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLJC_AE.HOURS > 0
		END

	END

	

	--UPDATE #emp_time_forecast
	--SET OfficeCode = (SELECT OFFICE_CODE FROM JOB_LOG WHERE JOB_NUMBER = JobNumber)
	
	--UPDATE #emp_time_forecast
	--SET OfficeName = (SELECT OFFICE_NAME FROM OFFICE WHERE OFFICE_CODE = OfficeCode)

	--UPDATE #emp_time_forecast
	--SET ClientCode = (SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = JobNumber),
	--    SalesClassCode = (SELECT SC_CODE FROM JOB_LOG WHERE JOB_NUMBER = JobNumber)

	--UPDATE #emp_time_forecast
	--SET ClientName = (SELECT CL_NAME FROM CLIENT WHERE CL_CODE = ClientCode)

	--UPDATE #emp_time_forecast
	--SET DepartmentCode = (SELECT DP_TM_CODE FROM EMPLOYEE WHERE EMP_CODE = EmployeeCode)

	--UPDATE #emp_time_forecast
	--SET DepartmentName = (SELECT DP_TM_DESC FROM DEPT_TEAM WHERE DP_TM_CODE = DepartmentCode)

	--UPDATE #emp_time_forecast
	--SET SalesClass = (SELECT SC_DESCRIPTION FROM SALES_CLASS WHERE SC_CODE = SalesClassCode)

	--UPDATE #emp_time_forecast
	--SET Employee = (SELECT EMP_FNAME + ' ' + EMP_LNAME FROM EMPLOYEE WHERE EMP_CODE = EmployeeCode)
	--WHERE Employee IS NULL

	--UPDATE #emp_time_forecast
	--SET AccountExecutiveCode = (SELECT EMP_CODE FROM JOB_COMPONENT WHERE JOB_NUMBER = JobNumber AND JOB_COMPONENT_NBR = JobComponentNumber)

	--UPDATE #emp_time_forecast
	--SET AccountExecutive = (SELECT EMP_FNAME + ' ' + EMP_LNAME FROM EMPLOYEE WHERE EMP_CODE = AccountExecutiveCode)	

	UPDATE #emp_time_forecast
	SET IsAlternateEmployee = 0 
	WHERE IsAlternateEmployee IS NULL
	
	--UPDATE #emp_time_forecast
	--SET DepartmentCode = (SELECT DP_TM_CODE FROM EMPLOYEE_TITLE WHERE EMPLOYEE_TITLE_ID = EMployeeTitleID)
	--WHERE DepartmentCode IS NULL AND IsAlternateEmployee = 1

	--UPDATE #emp_time_forecast
	--SET DepartmentName = (SELECT DP_TM_DESC FROM DEPT_TEAM WHERE DP_TM_CODE = DepartmentCode)
	--WHERE DepartmentName IS NULL AND IsAlternateEmployee = 1

	--UPDATE #emp_time_forecast
	--SET JobAndJobComponent = (SELECT RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + ' | ' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 6) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC
	--							FROM JOB_COMPONENT WHERE JOB_NUMBER = JobNumber AND JOB_COMPONENT_NBR = JobComponentNumber)	

	
	--	UPDATE #emp_time_forecast
	--	SET ClientHours = CASE WHEN DirectType = 'BL' THEN ActualHours ELSE 0 END

	--	UPDATE #emp_time_forecast
	--	SET AgencyHours = CASE WHEN DirectType = 'AG' THEN ActualHours ELSE 0 END
	
	--	UPDATE #emp_time_forecast
	--	SET NewBusinessHours = CASE WHEN DirectType = 'NW' THEN ActualHours ELSE 0 END

	--	UPDATE #emp_time_forecast
	--	SET IndirectHours = CASE WHEN DirectType = 'IN' THEN ActualHours ELSE 0 END
	
	
	
	--SELECT @Alternate
	--SELECT * FROM #emp_time_forecast
	if @includeJobDetail = 1
	BEGIN
		iF @Alternate <> ''
		BEGIN
			SELECT A.* FROM (
			SELECT ClientCode,
				   ClientName = REPLACE(ClientName,'''',''),
				   JobNumber,
				   JobComponentNumber,
				   JobAndJobComponent,
				   SalesClassCode,
				   Salesclass,
				   AccountExecutiveCode,
				   AccountExecutive,
				   IsAlternateEmployee,
				   ForecastedHours = SUM(ForecastHours),
				   ActualHours = SUM(ActualHours),
				   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
				   ForecastedAmount = SUM(ForecastAmount),
				   ActualAmount = SUM(ActualAmount),
				   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
			FROM #emp_time_forecast ETF					
			WHERE Employee = @Alternate AND (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept))
			GROUP BY ClientCode,
				   ClientName,
				   JobNumber,
				   JobComponentNumber,
				   JobAndJobComponent,
				   SalesClassCode,
				   Salesclass,
				   AccountExecutiveCode,
				   AccountExecutive,
				   IsAlternateEmployee) AS A --WHERE A.ForecastedHours > 0
		END
		ELSE
		BEGIN
			SELECT A.* FROM (
			SELECT ClientCode,
				   ClientName = REPLACE(ClientName,'''',''),
				   JobNumber,
				   JobComponentNumber,
				   JobAndJobComponent,
				   SalesClassCode,
				   Salesclass,
				   AccountExecutiveCode,
				   AccountExecutive,
				   IsAlternateEmployee,
				   ForecastedHours = SUM(ForecastHours),
				   ActualHours = SUM(ActualHours),
				   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
				   ForecastedAmount = SUM(ForecastAmount),
				   ActualAmount = SUM(ActualAmount),
				   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
			FROM #emp_time_forecast ETF		
			WHERE EmployeeCode = @EmployeeCode AND (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept))
			GROUP BY ClientCode,
				   ClientName,
				   JobNumber,
				   JobComponentNumber,
				   JobAndJobComponent,
				   SalesClassCode,
				   Salesclass,
				   AccountExecutiveCode,
				   AccountExecutive,
				   IsAlternateEmployee) AS A --WHERE A.ForecastedHours > 0
		END

		
	END
	ELSE
	BEGIN
		if @ViewType = 0
		BEGIN
			if @ByMonth = 1
			BEGIN
				SELECT [Month],MonthNumber,
					   ForecastedHours = ISNULL(SUM(ForecastHours),0),
					   ActualHours = ISNULL(SUM(ActualHours),0),
					   VarianceHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(ForecastHours),0), 			   
					   ForecastedAmount = ISNULL(SUM(ForecastAmount),0),
					   ActualAmount = ISNULL(SUM(ActualAmount),0),
					   VarianceAmount = ISNULL(SUM(ActualAmount),0) - ISNULL(SUM(ForecastAmount),0), 
					   DirectHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0),
					   ClientHours = ISNULL(SUM(ClientHours),0),
					   AgencyHours = ISNULL(SUM(AgencyHours),0),
					   NewBusinessHours = ISNULL(SUM(NewBusinessHours),0),
					   IndirectHours = ISNULL(SUM(IndirectHours),0)
				FROM #emp_time_forecast ETF	 LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode 
				WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY [Month], MonthNumber, [Year]
				ORDER BY [Year], MonthNumber
			END
			ELSE
			BEGIN
				SELECT A.* FROM (
				SELECT OfficeCode = E.OFFICE_CODE,
					   OfficeName = O.OFFICE_NAME,
					   DepartmentName = D.DP_TM_DESC,
					   DepartmentCode = E.DP_TM_CODE,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   IsAlternateEmployee,
					   ForecastedHours = ISNULL(SUM(ForecastHours),0),
					   ActualHours = ISNULL(SUM(ActualHours),0),
					   VarianceHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(ForecastHours),0), 			   
					   ForecastedAmount = ISNULL(SUM(ForecastAmount),0),
					   ActualAmount = ISNULL(SUM(ActualAmount),0),
					   VarianceAmount = ISNULL(SUM(ActualAmount),0) - ISNULL(SUM(ForecastAmount),0)	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE					
				GROUP BY E.OFFICE_CODE,
					   O.OFFICE_NAME,
					   E.DP_TM_CODE,
					   D.DP_TM_DESC,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   JL.CL_CODE,
					   C.CL_NAME,			   
					   IsAlternateEmployee) AS A WHERE (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) AND ClientCode IS NOT NULL
				ORDER BY A.ClientName
			END
		END

		IF @ViewType = 1 or @ViewType = 2 or @ViewType = 3 or @ViewType = 4
		BEGIN
			if @ByClient = 1
			BEGIN
				SELECT A.* FROM (
				SELECT 
					   ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),		   
					   ActualHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0)
				FROM #emp_time_forecast ETF LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE	LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode 
			    WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) --AND ClientCode IS NOT NULL			
				GROUP BY JL.CL_CODE,
					   C.CL_NAME) AS A WHERE ClientCode IS NOT NULL
			    ORDER BY A.ClientCode
			END
			ELSE IF @ByType = 1
			BEGIN

				UPDATE #emp_time_hours SET [Hours] = ISNULL((SELECT SUM(ActualHours) - SUM(IndirectHours) 
															 From #emp_time_forecast ETF LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode
															 WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) AND ActualHours > 0),0)
				WHERE HoursType = 'Direct'
				UPDATE #emp_time_hours SET [Hours] = ISNULL((SELECT SUM(AgencyHours) 
															 From #emp_time_forecast ETF LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode
															 WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) AND ETF.DirectType = 'AG'),0)
				WHERE HoursType = 'Agency'
				UPDATE #emp_time_hours SET [Hours] = ISNULL((SELECT SUM(ClientHours) 
															 From #emp_time_forecast ETF LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode
															 WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) AND ETF.DirectType = 'BL' OR ETF.DirectType = 'NB'),0)
				WHERE HoursType = 'Client'
				UPDATE #emp_time_hours SET [Hours] = ISNULL((SELECT SUM(NewBusinessHours) 
															 From #emp_time_forecast ETF LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode
															 WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) AND ETF.DirectType = 'NW'),0)
				WHERE HoursType = 'New Business'
				--UPDATE #emp_time_hours SET [Hours] = ISNULL((SELECT SUM(IndirectHours) From #emp_time_forecast ETF WHERE ETF.DirectType = 'IN'),0)
				--WHERE HoursType = 'Indirect'

				SELECT * FROM #emp_time_hours
				WHERE HoursType <> 'Indirect'
				
			END
			--ELSE IF @IndirectOnly = 1
			--BEGIN
			--	INSERT INTO #emp_time_np_hours
			--	SELECT IndirectCategory, SUM(ActualHours) FROM #emp_time_forecast
			--	WHERE DirectType = 'IN'
			--	GROUP BY IndirectCategory

			--	SELECT * FROM #emp_time_np_hours

			--END
			ELSE 
			BEGIN	
				--UPDATE #emp_time_forecast SET ClientCode = (SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = JobNumber)
				--SELECT * FROM #emp_time_forecast

				--SELECT   
				--	   ActualHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0),	
				--	   ClientHours = ISNULL(SUM(ClientHours),0),
				--	   AgencyHours = ISNULL(SUM(AgencyHours),0),
				--	   NewBusinessHours = ISNULL(SUM(NewBusinessHours),0),
				--	   IndirectHours = ISNULL(SUM(IndirectHours),0),
				--	   RequiredHours = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode),
				--	   TotalHours = ISNULL(SUM(ActualHours),0)
				--FROM #emp_time_forecast ETF	LEFT OUTER JOIN 
				--     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode GROUP BY EmployeeCode

				INSERT INTO #emp_time_np_hours
				SELECT TC.[DESCRIPTION], SUM(ActualHours) FROM #emp_time_forecast LEFT OUTER JOIN TIME_CATEGORY TC ON TC.CATEGORY = #emp_time_forecast.IndirectCategory	LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = #emp_time_forecast.EmployeeCode
				WHERE DirectType = 'IN' AND (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY TC.[DESCRIPTION]

				SELECT 
					'TotalsRow' AS Employee,
					SUM(A.ActualHours) AS ActualHours,	
					SUM(A.ClientHours) AS ClientHours,
					SUM(A.AgencyHours) AS AgencyHours,
					SUM(A.NewBusinessHours) AS NewBusinessHours,
					SUM(A.IndirectHours) AS IndirectHours,
					SUM(A.RequiredHours) AS RequiredHours,
					SUM(A.TotalHours) AS TotalHours
				FROM (
				SELECT   
					   ActualHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0),	
					   ClientHours = ISNULL(SUM(ClientHours),0),
					   AgencyHours = ISNULL(SUM(AgencyHours),0),
					   NewBusinessHours = ISNULL(SUM(NewBusinessHours),0),
					   IndirectHours = ISNULL(SUM(IndirectHours),0),
					   RequiredHours = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode),
					   TotalHours = ISNULL(SUM(ActualHours),0)
				FROM #emp_time_forecast ETF	LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) GROUP BY EmployeeCode) AS A
				UNION	
				SELECT Category,0,0,0,0,[Hours],0,0 FROM #emp_time_np_hours
				

			END
			
		END
		
		

		
	END
	
	DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

	DROP TABLE #emp_time_actuals
	DROP TABLE #emp_time_forecast
	DROP TABLE #emp_time_hours
	DROP TABLE #emp_time_np_hours

END