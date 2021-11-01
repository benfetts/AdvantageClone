IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_employee_time_util]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_employee_time_util] 
GO
-- Parameters
-- @dp_tm_opt; 1=Default DP_TM_CODE, 2=Default DP_TM_CODE or Min DP_TM_CODE, 3=DP_TM_CODE from EMP_TIME_DTL
-- @sel_dp_tm_opt; 1= All DP_TM_CODE's including nulls, 2=Selected DP_TM_CODE's
-- @dp_tm_list; List of selected DP_TM_CODE's if @sel_dp_tm_opt = 2
-- @start_period; e.g. 200801 (default 195101)
-- @end_period; e.g. 200812 (default 219912)
-- @cost_opt; 1=show cost for billable client time only "BL" (default), 2=show cost for all time charges
-- @wip_opt; 1=include WIP (default), 2=exclude WIP
-- @incl_rtax; 0=do not exclude resale tax, 1=exclude resale tax (default since inception)

-- Definitions
-- Direct Type (in priority order)
--		Agency Client (AG) = AGENCY.CL_CODE	is NOT Null
--		New Business (NW)  = CLIENT.NEW_BUSINESS = 1
--		Non Billable (NB)  = EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1, and EMP_TIME_DTL.FEE_TIME = 0
--		Billable (BL)      = Everything else
-- Billed Time
--		Direct Type = Billable (BL)
--		And ((AR_INV_NBR is NOT Null, and AR_POST_PERIOD between range)
--		Or (AR_INV_NBR is Null, and PPPERIOD between range, EMP_TIME_DTL.FEE_TIME = 1))
-- WIP Time
--		WIP_FLAG = True WHERE AR_POST_PERIOD is Null, and is Billable Time (EMP_NON_BILL_FLAG = 0), and NOT Agency Client and NOT New Business,
--		and NOT Fee Time

CREATE PROCEDURE [dbo].[advsp_employee_time_util] (@sel_dp_tm_opt tinyint, @dp_tm_opt tinyint, @dp_tm_list varchar(4000), 
	@period_opt int, @start_period int = 195101, @end_period int = 219912, @start_date smalldatetime = '01/01/51', @end_date smalldatetime = '12/31/99',
	@cost_opt tinyint = 1, @wip_opt tinyint = 1, @incl_rtax tinyint = 0)
AS
BEGIN
	SET NOCOUNT ON;

	--Temp variables to store starting and ending dates for periods - modified 10/1/10
	--@start_date
	SET @start_date = 
		CASE @period_opt
			WHEN 1 THEN (SELECT d.PPSRTDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@start_period AS varchar(6)) ) 
			WHEN 2 THEN @start_date
		END
	--SELECT @start_date
	--@end_date
	SET @end_date =		
		CASE @period_opt
			WHEN 1 THEN (SELECT d.PPENDDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = Cast(@end_period AS varchar(6)) )
			WHEN 2 THEN @end_date 
		END	
	--SELECT @end_date
	--@start_period
	SET @start_period = 
		CASE @period_opt
			WHEN 1 THEN @start_period
			WHEN 2 THEN 0 
		END
	--SELECT @start_Period
	--@end_period	
	SET @end_period =		
		CASE @period_opt
			WHEN 1 THEN @end_period
			WHEN 2 THEN 0 
		END	
	--SELECT @end_period


	--Temp table to hold minimum department code for each employee
	CREATE TABLE #min_emp_dp_tm(
		EMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		MIN_DP_TM_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

	INSERT INTO #min_emp_dp_tm
	SELECT EMP_CODE, MIN(DP_TM_CODE)
	FROM dbo.EMP_DP_TM
	GROUP BY EMP_CODE

--	SELECT * FROM #min_emp_dp_tm

	--Temp Table to hold list of selected DP_TM_CODE's
	CREATE TABLE #dp_tm_codes(DP_TM_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #dp_tm_codes
	SELECT dptm.vstr
	FROM fn_charlist_to_table2(@dp_tm_list) AS dptm

--	SELECT * FROM #dp_tm_codes
	
	--Main data table	
	CREATE TABLE #emp_util_time_data(
		REC_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DP_TM_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,	--Added 11/11/08 JP
		PERIOD						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_DATE					smalldatetime NULL,
		CLIENT						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIVISION					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRODUCT						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CATEGORY					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIRECT_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
		POSTED_HOURS				decimal(15,2) NULL,
		DIRECT_HOURS				decimal(15,2) NULL,
		TOTAL_COST					decimal(15,2) NULL,
		BILLABLE_HOURS				decimal(15,2) NULL,
		DIRECT_NONBILLABLE_HOURS	decimal(15,2) NULL,
		DIRECT_NEW_BUSINESS_HOURS	decimal(15,2) NULL,
		DIRECT_AGENCY_HOURS			decimal(15,2) NULL,
		BILLED_HOURS				decimal(15,2) NULL,
		WIP_HOURS					decimal(15,2) NULL,
		NON_PROD_HOURS				decimal(15,2) NULL,
		DIRECT_AMT					decimal(15,2) NULL,
		BILLABLE_AMT				decimal(15,2) NULL,
		DIRECT_NONBILLABLE_AMT		decimal(15,2) NULL,
		DIRECT_NEW_BUSINESS_AMT		decimal(15,2) NULL,
		DIRECT_AGENCY_AMT			decimal(15,2) NULL,
		MARK_UP_DOWN_AMT			decimal(15,2) NULL,
		MARK_UP_DOWN_HRS			decimal(15,5) NULL,
		BILLED_AMT					decimal(15,2) NULL,
		WIP_AMT						decimal(15,2) NULL,
		[TYPE]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FEE_TIME					tinyint NULL)
	
	--Direct time
	--Temp table to hold direct time
	CREATE TABLE #emp_util_emp_time_direct(
		EMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PPPERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		WIP_FLAG					tinyint NULL,
		[DATE]						smalldatetime NULL,
		CLIENT						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIVISION					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRODUCT						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_HOURS					decimal(15,2) NULL,
		EMP_COST_RATE				decimal(15,2) NULL,
		DP_TM_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIRECT_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_NON_BILL_FLAG			tinyint NULL,
		AR_INV_NBR					integer NULL,
		AR_INV_SEQ					tinyint NULL,
		AR_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AB_FLAG						tinyint NULL,
		TOTAL_COST					decimal(15,2) NULL,
		TOTAL_BILL					decimal(15,2) NULL,
		EXT_MARKUP_AMT				decimal(15,2) NULL,
		EXT_STATE_RESALE			decimal(15,2) NULL,
		EXT_COUNTY_RESALE			decimal(15,2) NULL,
		EXT_CITY_RESALE				decimal(15,2) NULL,
		EXT_TOTAL_RESALE			decimal(15,2) NULL,
		LINE_TOTAL					decimal(15,2) NULL,
		AGENCY_CLIENT				tinyint NULL,
		FEE_TIME					tinyint NULL,
		BILL_RATE					decimal(15,2) NULL)

	
	--*******************************************************************************************
	INSERT INTO #emp_util_emp_time_direct		
	SELECT
		EMP_CODE = e.EMP_CODE,
		PERIOD = (SELECT PPPERIOD FROM dbo.POSTPERIOD WHERE e.EMP_DATE BETWEEN PPSRTDATE AND PPENDDATE
			AND PPGLMONTH <> 99
			AND PPGLMONTH < 13),	--Added 9/19/08 JR
		AR_PERIOD = ar.AR_POST_PERIOD,
		WIP_FLAG = 
			CASE
				WHEN ar.AR_POST_PERIOD IS NULL AND ISNULL(ed.EMP_NON_BILL_FLAG, 0) = 0 AND agy.CL_CODE IS NULL 
					AND ISNULL(c.NEW_BUSINESS,0) <> 1 AND ISNULL(ed.FEE_TIME, 0) = 0 THEN 1
				ELSE 0
			END,
		EMP_DATE = e.EMP_DATE,
		CLIENT = j.CL_CODE,
		DIVISION = j.DIV_CODE,
		PRODUCT = j.PRD_CODE,
		JOB_NUMBER = ed.JOB_NUMBER,
		JOB_COMPONENT_NBR = ed.JOB_COMPONENT_NBR,
		FNC_CODE = ed.FNC_CODE,
		EMP_HOURS = ed.EMP_HOURS,
		EMP_COST_RATE = ed.EMP_COST_RATE,
		DP_TM_CODE =	--Added 11/11/08 JP
			CASE @dp_tm_opt
				WHEN 1 THEN emp.DP_TM_CODE
				WHEN 2 THEN COALESCE(emp.DP_TM_CODE, dpm.MIN_DP_TM_CODE)
				WHEN 3 THEN ed.DP_TM_CODE
			END,
		DIRECT_TYPE = 
			CASE
				WHEN agy.CL_CODE IS NOT NULL THEN 'AG'
				WHEN c.NEW_BUSINESS = 1 THEN 'NW'
				WHEN ed.EMP_NON_BILL_FLAG = 1 AND ISNULL(ed.FEE_TIME, 0) = 0 THEN 'NB'
				ELSE 'BL'
			END,
		EMP_NON_BILL_FLAG = 
			CASE
				WHEN ed.EMP_NON_BILL_FLAG = 1 AND agy.CL_CODE IS NULL AND ISNULL(ed.FEE_TIME, 0) = 0 
					AND ISNULL(c.NEW_BUSINESS,0) = 0 THEN 1
				ELSE 0
			END,
		AR_INV_NBR = ed.AR_INV_NBR,
		AR_INV_SEQ = ed.AR_INV_SEQ,
		AR_TYPE = ed.AR_TYPE,
		AB_FLAG = ed.AB_FLAG,
		TOTAL_COST = ed.TOTAL_COST,
		TOTAL_BILL = ed.TOTAL_BILL,
		EXT_MARKUP_AMT = ed.EXT_MARKUP_AMT,
		EXT_STATE_RESALE = ed.EXT_STATE_RESALE,
		EXT_COUNTY_RESALE = ed.EXT_COUNTY_RESALE,
		EXT_CITY_RESALE	 = ed.EXT_CITY_RESALE,
		EXT_TOTAL_RESALE = ed.EXT_STATE_RESALE + ed.EXT_COUNTY_RESALE + ed.EXT_CITY_RESALE,
		LINE_TOTAL = ed.LINE_TOTAL,
		AGENCY_CLIENT = 
			CASE 
				WHEN agy.CL_CODE iS NOT NULL THEN 1
				ELSE 0
			END,
		FEE_TIME = ISNULL(ed.FEE_TIME, 0),
		BILL_RATE = ed.EMP_BILL_RATE
	FROM dbo.EMP_TIME_DTL AS ed
	INNER JOIN dbo.EMP_TIME AS e
		ON ed.ET_ID = e.ET_ID
	INNER JOIN dbo.JOB_LOG AS j
		ON ed.JOB_NUMBER = j.JOB_NUMBER
	LEFT JOIN dbo.AGENCY_CLIENTS AS agy
		ON j.CL_CODE = agy.CL_CODE
	LEFT JOIN dbo.ACCT_REC ar
		ON ed.AR_INV_NBR = ar.AR_INV_NBR
		AND ed.AR_TYPE = ar.AR_TYPE		--Added 9/19/08 JR
	INNER JOIN dbo.EMPLOYEE AS emp		--Added 9/19/08 JR
		ON e.EMP_CODE = emp.EMP_CODE	--Added 9/19/08 JR
	LEFT JOIN #dp_tm_codes AS dpc		--Modified 11/11/08 JP to use temp table instead of function		
		ON emp.DP_TM_CODE = dpc.DP_TM_CODE
	LEFT JOIN #min_emp_dp_tm AS dpm		--Reactivated 11/11/08 JP
		ON e.EMP_CODE = dpm.EMP_CODE
	LEFT JOIN dbo.CLIENT AS c
		ON j.CL_CODE = c.CL_CODE			
	WHERE e.EMP_DATE BETWEEN @start_date AND @end_date AND (ISNULL(ar.AR_INV_SEQ, 0) = 0 OR ar.AR_INV_SEQ = 99)
		AND (ed.EMP_HOURS <> 0)			--Added 11/11/08 JP
		AND ((@sel_dp_tm_opt = 1)		--Added 11/11/08 JP
		OR (@sel_dp_tm_opt = 2 AND dpc.DP_TM_CODE IS NOT NULL))	-- replaces prior code to correct dept selection 2/13/11	

--	SELECT * FROM #emp_util_emp_time_direct ORDER BY JOB_NUMBER
--	SELECT * FROM #emp_util_emp_time_direct WHERE CLIENT = 'veri' AND EMP_CODE = 'ama'

	--*******************************************************************************************
	--POSTED time from #emp_util_emp_time_direct
	INSERT INTO #emp_util_time_data
	SELECT
		REC_TYPE = 'P',
		EMP_CODE = et.EMP_CODE,
		DP_TM_CODE = et.DP_TM_CODE,	--Added 11/11/08 JP
		PERIOD = et.PPPERIOD,
		AR_PERIOD = et.AR_POST_PERIOD,
		EMP_DATE = et.[DATE],
		CLIENT = et.CLIENT,
		DIVISION = et.DIVISION,
		PRODUCT = et.PRODUCT,
		JOB_NUMBER = et.JOB_NUMBER,
		JOB_COMPONENT_NBR = et.JOB_COMPONENT_NBR,
		FNC_CODE = et.FNC_CODE,
		CATEGORY = NULL,
		DIRECT_TYPE = et.DIRECT_TYPE,
		POSTED_HOURS = et.EMP_HOURS,
		DIRECT_HOURS = et.EMP_HOURS,
		TOTAL_COST =					--Modified 7/6/10 JP 
			CASE						--Modified 1/20/11 JP
				WHEN (et.DIRECT_TYPE = 'BL' AND @cost_opt = 1) OR @cost_opt = 2 THEN et.TOTAL_COST
				ELSE 0
			END,
		BILLABLE_HOURS = 
			CASE
				WHEN et.DIRECT_TYPE = 'BL' THEN et.EMP_HOURS
				ELSE 0
			END,
		DIRECT_NONBILLABLE_HOURS = 
			CASE
				WHEN et.DIRECT_TYPE = 'NB' THEN et.EMP_HOURS
				ELSE 0
			END,
		DIRECT_NEW_BUSINESS_HOURS = 
			CASE
				WHEN et.DIRECT_TYPE = 'NW' THEN et.EMP_HOURS
				ELSE 0
			END,
		DIRECT_AGENCY_HOURS = 
			CASE
				WHEN et.DIRECT_TYPE = 'AG' THEN et.EMP_HOURS
				ELSE 0
			END,
		BILLED_HOURS = 0,
		WIP_HOURS = 0,
		NON_PROD_HOURS = 0,
		DIRECT_AMT = et.TOTAL_BILL,
		BILLABLE_AMT = 
			CASE
				WHEN et.DIRECT_TYPE = 'BL' AND @incl_rtax = 0 THEN et.TOTAL_BILL
				WHEN et.DIRECT_TYPE = 'BL' THEN et.TOTAL_BILL + et.EXT_TOTAL_RESALE
				ELSE 0
			END,
		DIRECT_NONBILLABLE_AMT = 
			CASE
				WHEN et.DIRECT_TYPE = 'NB' AND @incl_rtax = 0 THEN et.TOTAL_BILL
				WHEN et.DIRECT_TYPE = 'NB' THEN et.TOTAL_BILL + et.EXT_TOTAL_RESALE
				ELSE 0
			END,
		DIRECT_NEW_BUSINESS_AMT = 
			CASE
				WHEN et.DIRECT_TYPE = 'NW' AND @incl_rtax = 0 THEN et.TOTAL_BILL
				WHEN et.DIRECT_TYPE = 'NW' THEN et.TOTAL_BILL + et.EXT_TOTAL_RESALE
				ELSE 0
			END,
		DIRECT_AGENCY_AMT = 
			CASE
				WHEN et.DIRECT_TYPE = 'AG' AND @incl_rtax = 0 THEN et.TOTAL_BILL
				WHEN et.DIRECT_TYPE = 'AG' THEN et.TOTAL_BILL + et.EXT_TOTAL_RESALE
				ELSE 0
			END,
		MARK_UP_DOWN_AMT = 
			CASE
				WHEN et.AGENCY_CLIENT <> 0 OR et.EMP_NON_BILL_FLAG = 1 THEN 0
				ELSE et.EXT_MARKUP_AMT
			END,
		MARK_UP_DOWN_HRS =  
			CASE
				WHEN et.AGENCY_CLIENT <> 0 OR et.EMP_NON_BILL_FLAG = 1 OR et.EXT_MARKUP_AMT = 0 THEN 0
				ELSE CASE WHEN et.BILL_RATE > 0 THEN et.EXT_MARKUP_AMT / et.BILL_RATE ELSE 0 END
			END,
		BILLED_AMT = 0,
		WIP_AMT = 0,
		[TYPE] = 
			CASE
				WHEN et.DIRECT_TYPE = 'AG' THEN 'Agency Time'
				WHEN et.DIRECT_TYPE = 'NW' THEN 'New Business Time'
				ELSE 'Client Time'
			END,
		et.FEE_TIME	
	FROM #emp_util_emp_time_direct AS et
	WHERE et.[DATE] BETWEEN @start_date AND @end_date
	
	--*******************************************************************************************
	--BILLED time from #emp_util_emp_time_direct
	INSERT INTO #emp_util_time_data
	SELECT
		REC_TYPE = 'B',
		EMP_CODE = et.EMP_CODE,
		DP_TM_CODE = et.DP_TM_CODE,	--Added 11/11/08 JP
		PERIOD = et.PPPERIOD,
		AR_PERIOD = 
			CASE et.FEE_TIME
				WHEN 0 THEN et.AR_POST_PERIOD
				ELSE et.PPPERIOD
			END,
		EMP_DATE = et.[DATE],
		CLIENT = et.CLIENT,
		DIVISION = et.DIVISION,
		PRODUCT = et.PRODUCT,
		JOB_NUMBER = et.JOB_NUMBER,
		JOB_COMPONENT_NBR = et.JOB_COMPONENT_NBR,
		FNC_CODE = et.FNC_CODE,
		CATEGORY = NULL,
		DIRECT_TYPE = et.DIRECT_TYPE,
		POSTED_HOURS = 0,
		DIRECT_HOURS = 0,
		TOTAL_COST = 0,
		BILLABLE_HOURS = 0,
		DIRECT_NONBILLABLE_HOURS = 0,
		DIRECT_NEW_BUSINESS_HOURS = 0,
		DIRECT_AGENCY_HOURS = 0,
		BILLED_HOURS = et.EMP_HOURS,
		WIP_HOURS = 0,
		NON_PROD_HOURS = 0,
		DIRECT_AMT = 0,
		BILLABLE_AMT = 0,
		DIRECT_NONBILLABLE_AMT = 0,
		DIRECT_NEW_BUSINESS_AMT = 0,
		DIRECT_AGENCY_AMT = 0,
		MARK_UP_DOWN_AMT = 0,
		MARK_UP_DOWN_HRS = 0,
		BILLED_AMT = 
			CASE
				WHEN @incl_rtax = 0 THEN et.TOTAL_BILL + et.EXT_MARKUP_AMT
				ELSE et.TOTAL_BILL + et.EXT_MARKUP_AMT + et.EXT_TOTAL_RESALE
			END,
		WIP_AMT = 0,
		[TYPE] = 'Client Time',
		FEE_TIME = et.FEE_TIME
	FROM #emp_util_emp_time_direct AS et
	WHERE DIRECT_TYPE = 'BL' 
		AND ((et.AR_INV_NBR IS NOT NULL AND et.AR_POST_PERIOD BETWEEN @start_period AND @end_period) 
		OR (et.AR_INV_NBR IS NOT NULL AND et.[DATE] BETWEEN @start_date AND @end_date)		--added 6/9/10 
		OR (et.AR_INV_NBR IS NULL AND et.[DATE] BETWEEN @start_date AND @end_date AND et.FEE_TIME = 1))

	--*******************************************************************************************
	--WIP time from #emp_util_emp_time_direct
	IF @wip_opt = 1
	BEGIN
		INSERT INTO #emp_util_time_data
		SELECT
			REC_TYPE = 'W',
			EMP_CODE = et.EMP_CODE,
			DP_TM_CODE = et.DP_TM_CODE,	--Added 11/11/08 JP
			PERIOD = et.PPPERIOD,
			AR_PERIOD = et.AR_POST_PERIOD,
			EMP_DATE = et.[DATE],
			CLIENT = et.CLIENT,
			DIVISION = et.DIVISION,
			PRODUCT = et.PRODUCT,
			JOB_NUMBER = et.JOB_NUMBER,
			JOB_COMPONENT_NBR = et.JOB_COMPONENT_NBR,
			FNC_CODE = et.FNC_CODE,
			CATEGORY = NULL,
			DIRECT_TYPE = et.DIRECT_TYPE,
			POSTED_HOURS = 0,
			DIRECT_HOURS = 0,
			TOTAL_COST = 0,
			BILLABLE_HOURS = 0,
			DIRECT_NONBILLABLE_HOURS = 0,
			DIRECT_NEW_BUSINESS_HOURS = 0,
			DIRECT_AGENCY_HOURS = 0,
			BILLED_HOURS = 0,
			WIP_HOURS = et.EMP_HOURS,
			NON_PROD_HOURS = 0,
			DIRECT_AMT = 0,
			BILLABLE_AMT = 0,
			DIRECT_NONBILLABLE_AMT = 0,
			DIRECT_NEW_BUSINESS_AMT = 0,
			DIRECT_AGENCY_AMT = 0,
			MARK_UP_DOWN_AMT = 0,
			MARK_UP_DOWN_HRS = 0,
			BILLED_AMT = 0,
			WIP_AMT = 
				CASE
					WHEN @incl_rtax = 0 THEN et.TOTAL_BILL + et.EXT_MARKUP_AMT
					ELSE et.TOTAL_BILL + et.EXT_MARKUP_AMT + et.EXT_TOTAL_RESALE
				END,	
			[TYPE] = 'Client Time',
			FEE_TIME = 0
		FROM #emp_util_emp_time_direct AS et
		WHERE et.[DATE] <= @end_date AND et.WIP_FLAG = 1
	END	

	--*******************************************************************************************
	--Indirect time
	--*******************************************************************************************
	INSERT INTO #emp_util_time_data(
		REC_TYPE,
		EMP_CODE,
		DP_TM_CODE,	--Added 11/11/08 JP
		PERIOD,
		EMP_DATE,
		CATEGORY,
		DIRECT_TYPE,
		POSTED_HOURS,
		DIRECT_HOURS,	--Added 9/23/08 JR		
		TOTAL_COST,
		BILLABLE_HOURS,	--Added 9/23/08 JR		
		DIRECT_NONBILLABLE_HOURS,	--Added 9/23/08 JR
		DIRECT_NEW_BUSINESS_HOURS,
		DIRECT_AGENCY_HOURS,	--Added 9/23/08 JR
		BILLED_HOURS,	--Added 9/23/08 JR
		WIP_HOURS,	--Added 9/23/08 JR
		NON_PROD_HOURS,
		DIRECT_AMT,	--Added 9/23/08 JR
		BILLABLE_AMT,	--Added 9/23/08 JR
		DIRECT_NONBILLABLE_AMT,	--Added 9/23/08 JR
		DIRECT_NEW_BUSINESS_AMT,
		DIRECT_AGENCY_AMT,	--Added 9/23/08 JR
		MARK_UP_DOWN_AMT,	--Added 9/23/08 JR
		MARK_UP_DOWN_HRS,	--Added 9/23/08 JR
		BILLED_AMT,	--Added 9/23/08 JR
		WIP_AMT,	--Added 9/23/08 JR
		[TYPE],
		FEE_TIME)
	SELECT
		REC_TYPE = 'N',
		EMP_CODE = e.EMP_CODE,
		DP_TM_CODE =			--Added 11/11/08 JP
			CASE @dp_tm_opt
				WHEN 1 THEN emp.DP_TM_CODE
				WHEN 2 THEN COALESCE(emp.DP_TM_CODE, dpm.MIN_DP_TM_CODE)
				WHEN 3 THEN enp.DP_TM_CODE
			END,
		PERIOD = (SELECT PPPERIOD FROM dbo.POSTPERIOD WHERE e.EMP_DATE BETWEEN PPSRTDATE AND PPENDDATE
			AND PPGLMONTH <> 99
			AND PPGLMONTH <> 13),
		EMP_DATE = e.EMP_DATE,
		CATEGORY = enp.CATEGORY,
		DIRECT_TYPE = NULL,
		POSTED_HOURS = enp.EMP_HOURS,
		DIRECT_HOURS = 0,	--Added 9/23/08 JR
		TOTAL_COST = 
			CASE @cost_opt
				WHEN 1 THEN 0
				ELSE enp.TOTAL_COST	 --1/20/11 JP
			END,	
		BILLABLE_HOURS = 0,	--Added 9/23/08 JR
		DIRECT_NONBILLABLE_HOURS = 0,	--Added 9/23/08 JR
		DIRECT_NEW_BUSINESS_HOURS = 0,
		DIRECT_AGENCY_HOURS = 0,	--Added 9/23/08 JR
		BILLED_HOURS = 0,	--Added 9/23/08 JR
		WIP_HOURS = 0,	--Added 9/23/08 JR
		NON_PROD_HOURS = enp.EMP_HOURS,
		DIRECT_AMT = 0,	--Added 9/23/08 JR
		BILLABLE_AMT = 0,	--Added 9/23/08 JR
		DIRECT_NONBILLABLE_AMT = 0,	--Added 9/23/08 JR
		DIRECT_NEW_BUSINESS_AMT = 0,
		DIRECT_AGENCY_AMT = 0,	--Added 9/23/08 JR
		MARK_UP_DOWN_AMT = 0,	--Added 9/23/08 JR
		MARK_UP_DOWN_HRS = 0,	--Added 9/23/08 JR
		BILL_AMT = 0,	--Added 9/23/08 JR
		WIP_AMT = 0,	--Added 9/23/08 JR
		[TYPE] = 'Non Productive Time',
		FEE_TIME = 0
	FROM dbo.EMP_TIME_NP AS enp
	INNER JOIN dbo.EMP_TIME AS e
		ON enp.ET_ID = e.ET_ID
	INNER JOIN dbo.EMPLOYEE AS emp		--Added 11/11/08 JP
		ON e.EMP_CODE = emp.EMP_CODE	--Added 11/11/08 JP
	LEFT JOIN #dp_tm_codes AS dpc		--Modified 11/11/08 JP to use temp table instead of function		
		ON emp.DP_TM_CODE = dpc.DP_TM_CODE
	LEFT JOIN #min_emp_dp_tm AS dpm		--Reactivated 11/11/08 JP
		ON e.EMP_CODE = dpm.EMP_CODE		
	LEFT JOIN #dp_tm_codes AS dpc2			--Added 11/11/08 JP		
		ON dpm.MIN_DP_TM_CODE = dpc2.DP_TM_CODE		
	--LEFT JOIN #dp_tm_codes AS dpc3			--Added 11/11/08 JP		
	--	ON enp.DP_TM_CODE = dpc3.DP_TM_CODE	
	WHERE e.EMP_DATE BETWEEN @start_date AND @end_date	--Added 3/24/09
		AND (enp.EMP_HOURS <> 0)				--Added 11/11/08 JP		
		--AND ((@sel_dp_tm_opt = 1)			--Added 11/11/08 JP
		--OR (@sel_dp_tm_opt = 2 AND @dp_tm_opt = 1 AND dpc.DP_TM_CODE IS NOT NULL)
		--OR (@sel_dp_tm_opt = 2 AND @dp_tm_opt = 2 AND dpc2.DP_TM_CODE IS NOT NULL)
		--OR (@sel_dp_tm_opt = 2 AND @dp_tm_opt = 3 AND dpc3.DP_TM_CODE IS NOT NULL))
		--AND (ed.EMP_HOURS <> 0)			--Added 11/11/08 JP
		AND ((@sel_dp_tm_opt = 1)		--Added 11/11/08 JP
		OR (@sel_dp_tm_opt = 2 AND dpc.DP_TM_CODE IS NOT NULL))	-- replaces prior code to correct dept selection 2/13/11

END

--	SELECT * FROM #emp_util_time_data WHERE EMP_CODE = 'ama'
	SELECT * FROM #emp_util_time_data

