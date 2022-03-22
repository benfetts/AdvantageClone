IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_employee_time_forecast_do]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_employee_time_forecast_do] 
GO


CREATE PROCEDURE [dbo].[advsp_employee_time_forecast_do] 
(
@start_period int = 195101,
@end_period int = 219912,
@dept varchar(4),
@IncludeAlternate bit,
@includeJobDetail bit,
@EmployeeCode varchar(6),
@Alternate varchar(100),
@IncludeSupervised bit,
@ViewType smallint,
@ForecastOnly bit,
@UserID varchar(100),
@Summary bit
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @start_date smalldatetime, @end_date smalldatetime, @StartPPMonth int, @StartPPYear int, @EndPPMonth int, @EndPPYear int, @MonthCount int

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

	--SET @end_date = @EndPPMonth + '/1/' + @EndPPYear

	--SET @start_date = @StartPPMonth + '/1/' + @StartPPYear
	--SET @end_date = DateAdd(day, -1, DateAdd(month, DateDiff(month, 0, @end_date)+1, 0))
			
	--SELECT @start_date,@end_date
	
	if @dept = '' 
	BEGIN
		SET @dept = NULL
	END

	if @ViewType = 1
	BEGIN
		DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)

		INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
		VALUES(@UserID, @start_date, @end_date)
	END
	
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
		[Year]						int,
		ClientHours					decimal(19,2),
		AgencyHours					decimal(19,2),
		NewBusinessHours			decimal(19,2),
		IndirectHours				decimal(19,2),
		StandardHours				decimal(19,2),
		BillableHours				decimal(19,2),
		CurrentMonth				bit,
		IndirectFlag				int)

	CREATE TABLE #emp_time_actuals(		
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ActualHours					decimal(19,2))

	CREATE TABLE #emp_time_client(		
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientHours					decimal(19,2))
		
	CREATE TABLE #emp_time_actuals_current(		
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ActualHours					decimal(19,2))

	CREATE TABLE #emp_time_client_current(		
		EmployeeCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientHours					decimal(19,2))
	
	

	IF @EmployeeCode <> ''
	BEGIN
		INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
		SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3), PPGLMONTH, PPGLYEAR
		FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
			INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
			INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
			INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
			INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLEMP.EMP_CODE = @EmployeeCode --AND ETF_OFFDTLJC_EMP.HOURS > 0
			--GROUP BY ETF_OFFDTL.OFFICE_CODE, ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC.CL_CODE

		INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount,DirectType, [Month], MonthNumber, [Year], ClientHours, AgencyHours, NewBusinessHours, BillableHours)
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
					ELSE 'BL' END NOT IN ('NB', 'AG', 'NW') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
				FROM EMP_TIME_DTL INNER JOIN
					 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
					 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
					 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
					 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
				WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date AND EMP_CODE = @EmployeeCode
						AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
					               WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END

		if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 4
		BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectHours, IndirectFlag)
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
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_HOURS, VAC_SICK_FLAG
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
						TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_TIME.EMP_CODE = @EmployeeCode AND EMP_HOURS > 0
		END		

		if @IncludeAlternate = 1
		BEGIN
			INSERT INTO #emp_time_forecast (Employee,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, EmployeeTitleID, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLAE.[DESCRIPTION], ETF_OFFDTLJC_AE.HOURS, ETF_OFFDTLAE.BILL_RATE*ETF_OFFDTLJC_AE.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,1, ETF_OFFDTLAE.EMPLOYEE_TITLE_ID,SUBSTRING(PPDESC, 1, 3), PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLAE ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLAE.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_AE ON (ETF_OFFDTLAE.ETF_OFFDTLAE_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLAE_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLJC_ID)
			INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLJC_AE.HOURS > 0 --AND ETF_OFFDTLAE.[DESCRIPTION] = @Alternate
		END

		if @IncludeSupervised = 1
		BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3), PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
			INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLEMP.EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode)

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
					ELSE 'BL' END NOT IN ('NB', 'AG', 'NW') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
					FROM EMP_TIME_DTL INNER JOIN
						 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
						 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
						 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
						 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
					WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date AND EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode)
							AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
									   WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END

			if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 4
			BEGIN											

			 INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectHours, IndirectFlag)
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
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_HOURS, VAC_SICK_FLAG
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
						TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_TIME.EMP_CODE IN (SELECT EMP_CODE FROM EMPLOYEE WHERE SUPERVISOR_CODE = @EmployeeCode AND EMP_CODE <> @EmployeeCode) AND EMP_HOURS > 0

			END
		END

	END
	ELSE
	BEGIN
		INSERT INTO #emp_time_forecast (EmployeeCode,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, [Month], MonthNumber, [Year])
		SELECT ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC_EMP.HOURS, ETF_OFFDTLEMP.BILL_RATE*ETF_OFFDTLJC_EMP.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,0,SUBSTRING(PPDESC, 1, 3), MONTH(POSTPERIOD.PPSRTDATE), YEAR(POSTPERIOD.PPENDDATE)--PPGLMONTH, PPGLYEAR
		FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
			INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
			INNER JOIN ETF_OFFDTLEMP ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLEMP.ETF_OFFDTL_ID) 
			INNER JOIN ETF_OFFDTLJC_EMP ON (ETF_OFFDTLEMP.ETF_OFFDTLEMP_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLEMP_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_EMP.ETF_OFFDTLJC_ID)
			INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period --AND ETF_OFFDTLJC_EMP.HOURS > 0
			--GROUP BY ETF_OFFDTL.OFFICE_CODE, ETF_OFFDTLEMP.EMP_CODE, ETF_OFFDTLJC.CL_CODE
		--SELECT * FROM #emp_time_forecast

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
					ELSE 'BL' END NOT IN ('NB', 'AG', 'NW') THEN EMP_TIME_DTL.EMP_HOURS ELSE 0 END
				FROM EMP_TIME_DTL INNER JOIN
					 EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
					 JOB_LOG AS j ON j.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER LEFT OUTER JOIN 
					 dbo.AGENCY_CLIENTS AS agy ON j.CL_CODE = agy.CL_CODE LEFT OUTER JOIN 
					 dbo.CLIENT AS c ON j.CL_CODE = c.CL_CODE	
				WHERE (EMP_TIME_DTL.EMP_HOURS <> 0) AND EMP_DATE BETWEEN @start_date AND @end_date 
					  AND 1 = CASE WHEN @ForecastOnly = 1 AND CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR) + '|' + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR) IN (SELECT CAST(JobNumber AS VARCHAR) + '|' + CAST(JobComponentNumber AS VARCHAR) FROM #emp_time_forecast) THEN 1
					               WHEN @ForecastOnly = 0 THEN 1 ELSE 0 END

		if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 4
		BEGIN
			INSERT INTO #emp_time_forecast (EmployeeCode, JobNumber, JobComponentNumber, ActualHours, ActualAmount,ForecastHours,ForecastAmount, DirectType, [Month], MonthNumber, [Year], IndirectHours, IndirectFlag)
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
						 WHEN MONTH(EMP_TIME.EMP_DATE) = 12 THEN 'Dec' END, MONTH(EMP_TIME.EMP_DATE), YEAR(EMP_TIME.EMP_DATE), EMP_HOURS, VAC_SICK_FLAG
					FROM EMP_TIME_NP INNER JOIN
						EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
						EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE  LEFT OUTER JOIN
						TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
					WHERE (EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND EMP_HOURS > 0
		END								
		
		if @IncludeAlternate = 1
		BEGIN
			INSERT INTO #emp_time_forecast (Employee,ForecastHours,ForecastAmount,JobNumber,JobComponentNumber, ActualHours, ActualAmount, IsAlternateEmployee, EMployeeTitleID, [Month], MonthNumber, [Year])
			SELECT ETF_OFFDTLAE.[DESCRIPTION], ETF_OFFDTLJC_AE.HOURS, ETF_OFFDTLAE.BILL_RATE*ETF_OFFDTLJC_AE.HOURS,ETF_OFFDTLJC.JOB_NUMBER, ETF_OFFDTLJC.JOB_COMPONENT_NBR,0,0,1, ETF_OFFDTLAE.EMPLOYEE_TITLE_ID,SUBSTRING(PPDESC, 1, 3), PPGLMONTH, PPGLYEAR
			FROM (((ETF_OFFDTL INNER JOIN ETF_HDR ON ETF_OFFDTL.ETF_ID = ETF_HDR.ETF_ID) 
				INNER JOIN ETF_OFFDTLJC ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLJC.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLAE ON ETF_OFFDTL.ETF_OFFDTL_ID = ETF_OFFDTLAE.ETF_OFFDTL_ID) 
				INNER JOIN ETF_OFFDTLJC_AE ON (ETF_OFFDTLAE.ETF_OFFDTLAE_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLAE_ID) AND (ETF_OFFDTLJC.ETF_OFFDTLJC_ID = ETF_OFFDTLJC_AE.ETF_OFFDTLJC_ID)
			INNER JOIN POSTPERIOD ON ETF_HDR.PPPERIOD = POSTPERIOD.PPPERIOD 
		
			WHERE (((ETF_OFFDTL.APPROVED)='True')) AND ETF_HDR.PPPERIOD BETWEEN @start_period AND @end_period AND ETF_OFFDTLJC_AE.HOURS > 0
		END

	END	

	--SELECT * FROM #emp_time_forecast

	--UPDATE #emp_time_forecast
	--SET OfficeCode = (SELECT OFFICE_CODE FROM EMPLOYEE WHERE EMP_CODE = EmployeeCode)
	--WHERE OfficeCode IS NULL
	
	--UPDATE #emp_time_forecast
	--SET OfficeName = (SELECT OFFICE_NAME FROM OFFICE WHERE OFFICE_CODE = OfficeCode)
	--WHERE OfficeName IS NULL

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
	--SET JobAndJobComponent = (SELECT RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC
	--							FROM JOB_COMPONENT WHERE JOB_NUMBER = JobNumber AND JOB_COMPONENT_NBR = JobComponentNumber)	

	
	--if @ViewType = 1 OR @ViewType = 2 OR @ViewType = 4
	--BEGIN
	--	UPDATE #emp_time_forecast
	--	SET ClientHours = CASE WHEN DirectType = 'BL' THEN ActualHours ELSE 0 END

	--	UPDATE #emp_time_forecast
	--	SET AgencyHours = CASE WHEN DirectType = 'AG' THEN ActualHours ELSE 0 END
	
	--	UPDATE #emp_time_forecast
	--	SET NewBusinessHours = CASE WHEN DirectType = 'NW' THEN ActualHours ELSE 0 END

	--	UPDATE #emp_time_forecast
	--	SET IndirectHours = CASE WHEN DirectType = 'IN' THEN ActualHours ELSE 0 END

	--	UPDATE #emp_time_forecast
	--	SET BillableHours = CASE WHEN DirectType = 'BL' OR DirectType = 'AG' OR DirectType = 'NW' THEN ActualHours ELSE 0 END
	--END

	if @ViewType = 4
	BEGIN
		UPDATE #emp_time_forecast
		SET CurrentMonth = 1
		WHERE MonthNumber = MONTH(@end_date) AND [Year] = YEAR(@end_date)

		UPDATE #emp_time_forecast
		SET CurrentMonth = 0
		WHERE CurrentMonth IS NULL
	END
	

	--SELECT MONTH(@end_date)
	--SELECT @Alternate
	--SELECT * FROM #emp_time_forecast WHERE EmployeeCode = 'ama'
	if @includeJobDetail = 1
	BEGIN
		if @Summary = 1
		BEGIN
			iF @Alternate <> ''
			BEGIN
				SELECT A.* FROM (
				SELECT EmployeeCode,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   JobNumber,
					   JobComponentNumber,
					   JobAndJobComponent = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   SalesClassCode = JL.SC_CODE,
					   Salesclass = SC.SC_DESCRIPTION,
					   AccountExecutiveCode = JC.EMP_CODE,
					   AccountExecutive = EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 JOB_COMPONENT JC ON JC.JOB_NUMBER = ETF.JobNumber AND JC.JOB_COMPONENT_NBR = ETF.JobComponentNumber LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
				     EMPLOYEE EAE ON EAE.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
					 SALES_CLASS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE
				WHERE Employee = @Alternate AND (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY EmployeeCode,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   JobNumber,
					   JobComponentNumber,
					   RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   JL.SC_CODE,
					   SC.SC_DESCRIPTION,
					   JC.EMP_CODE,
					   EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) ORDER BY A.JobNumber, A.JobComponentNumber
			END
			ELSE
			BEGIN
				SELECT A.* FROM (
				SELECT EmployeeCode,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   JobNumber,
					   JobComponentNumber,
					   JobAndJobComponent = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   SalesClassCode = JL.SC_CODE,
					   Salesclass = SC.SC_DESCRIPTION,
					   AccountExecutiveCode = JC.EMP_CODE,
					   AccountExecutive = EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 JOB_COMPONENT JC ON JC.JOB_NUMBER = ETF.JobNumber AND JC.JOB_COMPONENT_NBR = ETF.JobComponentNumber LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
				     EMPLOYEE EAE ON EAE.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
					 SALES_CLASS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE	
				WHERE EmployeeCode = @EmployeeCode AND (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY EmployeeCode,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   JobNumber,
					   JobComponentNumber,
					   RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   JL.SC_CODE,
					   SC.SC_DESCRIPTION,
					   JC.EMP_CODE,
					   EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) ORDER BY A.JobNumber, A.JobComponentNumber
			END
		END
		ELSE
		BEGIN
			iF @Alternate <> ''
			BEGIN
				SELECT A.* FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   JobNumber,
					   JobComponentNumber,
					   JobAndJobComponent = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   SalesClassCode = JL.SC_CODE,
					   Salesclass = SC.SC_DESCRIPTION,
					   AccountExecutiveCode = JC.EMP_CODE,
					   AccountExecutive = EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 JOB_COMPONENT JC ON JC.JOB_NUMBER = ETF.JobNumber AND JC.JOB_COMPONENT_NBR = ETF.JobComponentNumber LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
				     EMPLOYEE EAE ON EAE.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
					 SALES_CLASS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE	
				WHERE Employee = @Alternate AND (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY JL.CL_CODE,
					   CL_NAME,
					   JobNumber,
					   JobComponentNumber,
					   RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   JL.SC_CODE,
					   SC.SC_DESCRIPTION,
					   JC.EMP_CODE,
					   EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) ORDER BY A.JobNumber, A.JobComponentNumber
			END
			ELSE
			BEGIN
				SELECT A.* FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   JobNumber,
					   JobComponentNumber,
					   JobAndJobComponent = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   SalesClassCode = JL.SC_CODE,
					   Salesclass = SC.SC_DESCRIPTION,
					   AccountExecutiveCode = JC.EMP_CODE,
					   AccountExecutive = EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode	LEFT OUTER JOIN
					 JOB_COMPONENT JC ON JC.JOB_NUMBER = ETF.JobNumber AND JC.JOB_COMPONENT_NBR = ETF.JobComponentNumber LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
				     EMPLOYEE EAE ON EAE.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
					 SALES_CLASS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE		
				WHERE EmployeeCode = @EmployeeCode AND (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept))
				GROUP BY JL.CL_CODE,
					   C.CL_NAME,
					   JobNumber,
					   JobComponentNumber,
					   RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JobComponentNumber), 3) + ' - ' + JC.JOB_COMP_DESC,
					   JL.SC_CODE,
					   SC.SC_DESCRIPTION,
					   JC.EMP_CODE,
					   EAE.EMP_FNAME + ' ' + EAE.EMP_LNAME,
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) ORDER BY A.JobNumber, A.JobComponentNumber
			END
		END
				
	END
	ELSE
	BEGIN	
		if @ViewType = 0
		BEGIN
			if @Summary = 1
			BEGIN
				SELECT A.* FROM (
				SELECT OfficeCode = E.OFFICE_CODE,
					   OfficeName = O.OFFICE_NAME,
					   DepartmentName = D.DP_TM_DESC,
					   DepartmentCode = E.DP_TM_CODE,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   --ClientCode,
					   --ClientName = REPLACE(ClientName,'''',''),
					   IsAlternateEmployee,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE
				GROUP BY E.OFFICE_CODE,
					   O.OFFICE_NAME,
					   E.DP_TM_CODE,
					   D.DP_TM_DESC,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   --ClientCode,
					   --ClientName,			   
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) AND (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) ORDER BY A.Employee
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
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE	
				--WHERE ClientCode IS NOT NULL						
				GROUP BY E.OFFICE_CODE,
					   O.OFFICE_NAME,
					   E.DP_TM_CODE,
					   D.DP_TM_DESC,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   JL.CL_CODE,
					   C.CL_NAME,			   
					   IsAlternateEmployee) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) AND (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) ORDER BY A.Employee
			END
			
		END		

		if @ViewType = 1
		BEGIN
			SELECT A.* FROM (
			SELECT OfficeCode = E.OFFICE_CODE,
				   OfficeName = O.OFFICE_NAME,
				   DepartmentName = D.DP_TM_DESC,
				   DepartmentCode = E.DP_TM_CODE,
				   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,	
				   ForecastedHours = ISNULL(SUM(ForecastHours),0),
				   ActualHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0),	
				   VarianceHours = SUM(ActualHours) - ISNULL(SUM(IndirectHours),0) - SUM(ForecastHours), 			   
				   ClientHours = ISNULL(SUM(ClientHours),0),
				   AgencyHours = ISNULL(SUM(AgencyHours),0),
				   NewBusinessHours = ISNULL(SUM(NewBusinessHours),0),
				   IndirectHours = ISNULL(SUM(IndirectHours),0),
				   DirectPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN ((ISNULL(SUM(ActualHours),0) - (ISNULL(SUM(IndirectHours),0))) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END,
				   ClientPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN (ISNULL(SUM(ClientHours),0)) / (ISNULL(SUM(ActualHours),0)) * 100 ELSE 0 END,
				   NewBusinessPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN ((ISNULL(SUM(NewBusinessHours),0)) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END,
				   AgencyPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN ((ISNULL(SUM(AgencyHours),0)) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END,
				   IndirectPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN ((ISNULL(SUM(IndirectHours),0)) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END, 
				   RequiredHours = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode),
				   DirectHoursGoal = ((SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode) - ((SELECT ISNULL(SUM(IndirectHours),0) FROM #emp_time_forecast EF WHERE EF.EmployeeCode = ETF.EmployeeCode AND IndirectFlag IS NOT NULL))) * (SELECT ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000) * 0.010000 FROM EMPLOYEE WHERE EMP_CODE = ETF.EmployeeCode),
				   TotalHours = ISNULL(SUM(ActualHours),0),
				   Variance = (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode) - SUM(ActualHours),
				   RequiredPercent = CASE WHEN (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode) > 0 THEN 
										(SUM(ActualHours) / (SELECT SUM(STD_HRS) FROM W_EMP_STD_HOURS_DTL WS WHERE UPPER(USERID) = UPPER(@UserID) AND WS.EMP_CODE = ETF.EmployeeCode)) * 100 ELSE 0 END,
				   BillableHours = ISNULL(SUM(BillableHours),0),
				   BillablePercent = CASE WHEN SUM(ActualHours) > 0 THEN ((ISNULL(SUM(BillableHours),0) / (SUM(ActualHours)))) * 100 ELSE 0 END
			FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE				
			GROUP BY E.OFFICE_CODE,
					 O.OFFICE_NAME,
					 E.DP_TM_CODE,
					 D.DP_TM_DESC,
					 CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
				     EmployeeCode) AS A WHERE (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) ORDER BY A.Employee
		END

		if @ViewType = 2
		BEGIN
			SELECT A.* FROM (
			SELECT OfficeCode = E.OFFICE_CODE,
				   OfficeName = O.OFFICE_NAME,
				   DepartmentName = D.DP_TM_DESC,
				   DepartmentCode = E.DP_TM_CODE,
				   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
				   EmployeeCode,	
				   [Month],
				   MonthNumber,
				   [Year],
				   ActualHours = ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0),	
				   ClientHours = ISNULL(SUM(ClientHours),0),
				   DirectPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN ((ISNULL(SUM(ActualHours),0) - ISNULL(SUM(IndirectHours),0)) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END,
				   ClientPercent = CASE WHEN ISNULL(SUM(ActualHours),0) > 0 THEN (ISNULL(SUM(ClientHours),0) / (ISNULL(SUM(ActualHours),0))) * 100 ELSE 0 END
			FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE				
			GROUP BY E.OFFICE_CODE,
					 O.OFFICE_NAME,
					 E.DP_TM_CODE,
					 D.DP_TM_DESC,
					 CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
				   EmployeeCode,	
				   [Month],
				   MonthNumber,
				   [Year]) AS A WHERE (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) ORDER BY A.Employee,A.MonthNumber
		END

		if @ViewType = 3
		BEGIN
			if @Summary = 1
			BEGIN
				SELECT A.* FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   --DepartmentName,
					   --DepartmentCode,
					   --Employee,
					   --EmployeeCode,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE
				WHERE (@dept IS NULL OR (@dept IS NOT NULL AND E.DP_TM_CODE = @dept)) --AND ClientCode IS NOT NULL						
				GROUP BY JL.CL_CODE,
					   C.CL_NAME) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) ORDER BY A.ClientCode
			END
			ELSE
			BEGIN
				SELECT A.* FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   DepartmentName = D.DP_TM_DESC,
				       DepartmentCode = E.DP_TM_CODE,
				       Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,
					   ForecastedHours = SUM(ForecastHours),
					   ActualHours = SUM(ActualHours),
					   VarianceHours = SUM(ActualHours) - SUM(ForecastHours), 			   
					   ForecastedAmount = SUM(ForecastAmount),
					   ActualAmount = SUM(ActualAmount),
					   VarianceAmount = SUM(ActualAmount) - SUM(ForecastAmount) 	
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE
				--WHERE ClientCode IS NOT NULL						
				GROUP BY JL.CL_CODE,
					   C.CL_NAME,	
					   E.DP_TM_CODE,
					   D.DP_TM_DESC,
					   CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   EmployeeCode) AS A WHERE (ForecastedHours > 0 OR ActualHours > 0) AND (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) ORDER BY A.ClientCode
			END
			
		END

		if @ViewType = 4
		BEGIN
			DECLARE @FTE decimal(12,3), @FTE_CURRENT DECIMAL(12,3)

			SELECT @FTE = ISNULL(CAST(AGY_SETTINGS_VALUE AS DECIMAL(12,3)),0)
			FROM AGY_SETTINGS
			WHERE AGY_SETTINGS_CODE = 'FTE_BASIS'

			INSERT INTO #emp_time_actuals
			SELECT EmployeeCode,SUM(ActualHours)
			FROM #emp_time_forecast ET 
			WHERE DirectType <> 'IN'
			GROUP BY EmployeeCode

			INSERT INTO #emp_time_client
			SELECT EmployeeCode,SUM(ClientHours)
			FROM #emp_time_forecast ET
			WHERE DirectType <> 'IN'
			GROUP BY EmployeeCode

			INSERT INTO #emp_time_actuals_current
			SELECT EmployeeCode,SUM(ActualHours)
			FROM #emp_time_forecast ET 
			WHERE DirectType <> 'IN' and CurrentMonth = 1
			GROUP BY EmployeeCode

			INSERT INTO #emp_time_client_current
			SELECT EmployeeCode,SUM(ClientHours)
			FROM #emp_time_forecast ET
			WHERE DirectType <> 'IN' and CurrentMonth = 1
			GROUP BY EmployeeCode

			--SELECT * FROM #emp_time_client

			SELECT @MonthCount = DATEDIFF(MONTH, @start_date, @end_date) + 1

			SET @FTE_CURRENT = (@FTE/12)
			SET @FTE = (@FTE/12) * @MonthCount

			--SELECT @MonthCount,@FTE
			if @Summary = 1
			BEGIN
				SELECT C.ClientCode,
					   C.ClientName,
					   ActualHoursCurrent = SUM(C.ActualHoursCurrent),	
					   ClientHoursCurrent = SUM(C.ClientHoursCurrent),
					   DirectPercentCurrent = SUM(DirectPercentCurrent),
					   ClientPercentCurrent = SUM(ClientPercentCurrent),			  
					   ActualHours = SUM(C.ActualHours),	
					   ClientHours = SUM(C.ClientHours),
					   DirectPercent = SUM(DirectPercent),
					   ClientPercent = SUM(ClientPercent),
					   FTECurrent = SUM(C.FTECurrent),
					   FTETotal = SUM(C.FTETotal)
				FROM (
				SELECT B.ClientCode,
					   B.ClientName,
					   B.DepartmentName,
					   B.DepartmentCode,
					   B.Employee,
					   B.EmployeeCode,			  
					   B.ActualHoursCurrent,	
					   B.ClientHoursCurrent,
					   DirectPercentCurrent = CASE WHEN (SELECT ActualHours FROM #emp_time_actuals_current ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ActualHoursCurrent / (SELECT ActualHours FROM #emp_time_actuals_current ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,
					   ClientPercentCurrent = CASE WHEN (SELECT ClientHours FROM #emp_time_client_current ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ClientHoursCurrent / (SELECT ClientHours FROM #emp_time_client_current ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,			  
					   B.ActualHours,	
					   B.ClientHours,
					   DirectPercent = CASE WHEN (SELECT ActualHours FROM #emp_time_actuals ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ActualHours / (SELECT ActualHours FROM #emp_time_actuals ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,
					   ClientPercent = CASE WHEN (SELECT ClientHours FROM #emp_time_client ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ClientHours / (SELECT ClientHours FROM #emp_time_client ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,			  
					   B.FTECurrent,
					   B.FTETotal
				FROM (
				SELECT A.ClientCode,
					   A.ClientName,
					   A.DepartmentName,
					   A.DepartmentCode,
					   A.Employee,
					   A.EmployeeCode,			  
					   ActualHoursCurrent = SUM(A.ActualHoursCurrent),	
					   ClientHoursCurrent = SUM(A.ClientHoursCurrent),
					   --DirectPercentCurrent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN ((SUM(A.ActualHoursCurrent)) / (SUM(A.TotalActualHours) + (SELECT SUM(IndirectHours) FROM #emp_time_forecast WHERE A.EmployeeCode = #emp_time_forecast.EmployeeCode AND CurrentMonth = 1))) * 100 ELSE 0 END,
					   --ClientPercentCurrent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN (SUM(A.ClientHoursCurrent) / (SUM(A.TotalActualHours) + (SELECT SUM(IndirectHours) FROM #emp_time_forecast WHERE A.EmployeeCode = #emp_time_forecast.EmployeeCode))) * 100 ELSE 0 END,			  
					   ActualHours = SUM(ActualHours),	
					   ClientHours = SUM(ClientHours),
					   --DirectPercent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN ((SUM(ActualHours)) / (SUM(A.TotalActualHours))) * 100 ELSE 0 END,
					   --ClientPercent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN (SUM(ClientHours) / (SUM(A.TotalActualHours))) * 100 ELSE 0 END,
					   FTECurrent = CASE WHEN @FTE_CURRENT > 0 THEN SUM(A.ActualHoursCurrent) / (@FTE_CURRENT) ELSE 0 END,
					   FTETotal = CASE WHEN @FTE > 0 THEN SUM(ActualHours) / (@FTE) ELSE 0 END
				FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   DepartmentName = D.DP_TM_DESC,
				       DepartmentCode = E.DP_TM_CODE,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END ,
					   EmployeeCode,			  
					   ActualHoursCurrent = CASE WHEN CurrentMonth = 1 THEN ISNULL(ActualHours,0) - ISNULL(IndirectHours,0) ELSE 0 END,	
					   ClientHoursCurrent = CASE WHEN CurrentMonth = 1 THEN ISNULL(ClientHours,0) ELSE 0 END,
					  -- DirectPercentCurrent = CASE WHEN CurrentMonth = 1 THEN CASE WHEN ActualHours > 0 THEN ((ActualHours - IndirectHours) / (ActualHours)) * 100 ELSE 0 END ELSE 0 END,
					   --ClientPercentCurrent = CASE WHEN CurrentMonth = 1 THEN CASE WHEN ActualHours > 0 THEN (ClientHours / (ActualHours)) * 100 ELSE 0 END ELSE 0 END,			  
					   ActualHours = ISNULL(ActualHours,0) - ISNULL(IndirectHours,0),
					   ClientHours = ISNULL(ClientHours,0),
					   --DirectPercent = CASE WHEN ActualHours > 0 THEN ((ActualHours - IndirectHours) / (ActualHours)) * 100 ELSE 0 END,
					   --ClientPercent = CASE WHEN ActualHours > 0 THEN (ClientHours / (ActualHours)) * 100 ELSE 0 END,
					   TotalActualHours = ActualHours
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE		
			    WHERE ISNULL(ActualHours,0) > 0		
				) AS A WHERE (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) AND ClientCode IS NOT NULL	
				 GROUP BY A.ClientCode,
						A.ClientName,
						A.DepartmentName,
					    A.DepartmentCode,
					    A.Employee,
					    A.EmployeeCode) AS B
				 ) AS C
				 GROUP BY C.ClientCode,
					   C.ClientName
				 ORDER BY C.ClientCode
			END
			ELSE
			BEGIN				
				SELECT B.ClientCode,
					   B.ClientName,
					   B.DepartmentName,
					   B.DepartmentCode,
					   B.Employee,
					   B.EmployeeCode,			  
					   B.ActualHoursCurrent,	
					   B.ClientHoursCurrent,
					   DirectPercentCurrent = CASE WHEN (SELECT ActualHours FROM #emp_time_actuals_current ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ActualHoursCurrent / (SELECT ActualHours FROM #emp_time_actuals_current ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,
					   ClientPercentCurrent = CASE WHEN (SELECT ClientHours FROM #emp_time_client_current ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ClientHoursCurrent / (SELECT ClientHours FROM #emp_time_client_current ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,			  
					   B.ActualHours,	
					   B.ClientHours,
					   DirectPercent = CASE WHEN (SELECT ActualHours FROM #emp_time_actuals ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ActualHours / (SELECT ActualHours FROM #emp_time_actuals ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,
					   ClientPercent = CASE WHEN (SELECT ClientHours FROM #emp_time_client ET WHERE ET.EmployeeCode = B.EmployeeCode) > 0 THEN (B.ClientHours / (SELECT ClientHours FROM #emp_time_client ET WHERE ET.EmployeeCode = B.EmployeeCode)) * 100 ELSE 0 END,			  
					   B.FTECurrent,
					   B.FTETotal
				FROM (
				SELECT A.ClientCode,
					   A.ClientName,
					   A.DepartmentName,
					   A.DepartmentCode,
					   A.Employee,
					   A.EmployeeCode,			  
					   ActualHoursCurrent = SUM(A.ActualHoursCurrent),	
					   ClientHoursCurrent = SUM(A.ClientHoursCurrent),
					   --DirectPercentCurrent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN ((SUM(A.ActualHoursCurrent)) / (SUM(A.TotalActualHours) + (SELECT SUM(IndirectHours) FROM #emp_time_forecast WHERE A.EmployeeCode = #emp_time_forecast.EmployeeCode AND CurrentMonth = 1))) * 100 ELSE 0 END,
					   --ClientPercentCurrent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN (SUM(A.ClientHoursCurrent) / (SUM(A.TotalActualHours) + (SELECT SUM(IndirectHours) FROM #emp_time_forecast WHERE A.EmployeeCode = #emp_time_forecast.EmployeeCode))) * 100 ELSE 0 END,			  
					   ActualHours = SUM(ActualHours),	
					   ClientHours = SUM(ClientHours),
					   --DirectPercent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN ((SUM(ActualHours)) / (SUM(A.TotalActualHours))) * 100 ELSE 0 END,
					   --ClientPercent = CASE WHEN SUM(A.TotalActualHours) > 0 THEN (SUM(ClientHours) / (SUM(A.TotalActualHours))) * 100 ELSE 0 END,
					   FTECurrent = CASE WHEN @FTE_CURRENT > 0 THEN SUM(A.ActualHoursCurrent) / (@FTE_CURRENT) ELSE 0 END,
					   FTETotal = CASE WHEN @FTE > 0 THEN SUM(ActualHours) / (@FTE) ELSE 0 END
				FROM (
				SELECT ClientCode = JL.CL_CODE,
					   ClientName = REPLACE(C.CL_NAME,'''',''),
					   DepartmentName = D.DP_TM_DESC,
				       DepartmentCode = E.DP_TM_CODE,
					   Employee = CASE WHEN IsAlternateEmployee = 0 THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE Employee END,
					   EmployeeCode,			  
					   ActualHoursCurrent = CASE WHEN CurrentMonth = 1 THEN ISNULL(ActualHours,0) - ISNULL(IndirectHours,0) ELSE 0 END,	
					   ClientHoursCurrent = CASE WHEN CurrentMonth = 1 THEN ISNULL(ClientHours,0) ELSE 0 END,
					  -- DirectPercentCurrent = CASE WHEN CurrentMonth = 1 THEN CASE WHEN ActualHours > 0 THEN ((ActualHours - IndirectHours) / (ActualHours)) * 100 ELSE 0 END ELSE 0 END,
					   --ClientPercentCurrent = CASE WHEN CurrentMonth = 1 THEN CASE WHEN ActualHours > 0 THEN (ClientHours / (ActualHours)) * 100 ELSE 0 END ELSE 0 END,			  
					   ActualHours = ISNULL(ActualHours,0) - ISNULL(IndirectHours,0),	
					   ClientHours = ISNULL(ClientHours,0),
					   --DirectPercent = CASE WHEN ActualHours > 0 THEN ((ActualHours - IndirectHours) / (ActualHours)) * 100 ELSE 0 END,
					   --ClientPercent = CASE WHEN ActualHours > 0 THEN (ClientHours / (ActualHours)) * 100 ELSE 0 END,
					   TotalActualHours = ActualHours
				FROM #emp_time_forecast ETF LEFT OUTER JOIN 
				     EMPLOYEE E ON E.EMP_CODE = ETF.EmployeeCode LEFT OUTER JOIN
					 DEPT_TEAM D ON D.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					 JOB_LOG JL ON JL.JOB_NUMBER = ETF.JobNumber LEFT OUTER JOIN
					 CLIENT C ON C.CL_CODE = JL.CL_CODE		
			    WHERE ISNULL(ActualHours,0) > 0
				) AS A WHERE (@dept IS NULL OR (@dept IS NOT NULL AND DepartmentCode = @dept)) AND ClientCode IS NOT NULL	
				 GROUP BY A.ClientCode,
						A.ClientName,
						A.DepartmentName,
					    A.DepartmentCode,
					    A.Employee,
					    A.EmployeeCode) B
				 ORDER BY B.ClientCode
			END
			
		END
				
	END
	
	if @ViewType = 1
	BEGIN
		DELETE FROM W_EMP_STD_HOURS WHERE UPPER(USERID) = UPPER(@UserID)
	END
	
	DROP TABLE #emp_time_forecast;
	DROP TABLE #emp_time_actuals;
	DROP TABLE #emp_time_client;
	DROP TABLE #emp_time_actuals_current;
	DROP TABLE #emp_time_client_current;

END