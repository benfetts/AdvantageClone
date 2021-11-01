CREATE PROCEDURE [dbo].[advsp_media_current_status_coop_breakout_detail] ( 
	@order_status					varchar(1),						--A = all, O = open
	@start_date						datetime,
	@start_month					int,
	@start_year						int,
	@end_date						datetime,
	@end_month						int,
	@end_year						int,
	@include_internet				bit,
	@include_magazine				bit,
	@include_newspaper				bit,
	@include_outofhome				bit,
	@include_radio					bit,
	@include_television				bit
)
AS
BEGIN

	SET NOCOUNT ON;

	CREATE TABLE #order_detail(
		OrderType						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderNumber						int NOT NULL,
		LineNumber						smallint NOT NULL,
		LineDescription					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderPeriod						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderMonth						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderYear						int NULL,
		InsertionDate					smalldatetime NULL, 
		OrderEndDate					smalldatetime NULL, 
		CloseDate						smalldatetime NULL, 
		MaterialCloseDate				smalldatetime NULL, 
		ExtendedMaterialCloseDate		smalldatetime NULL, 
		ExtendedSpaceCloseDate			smalldatetime NULL, 
		JobNumber						int NULL,
		JobDescription					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JobComponentNumber				smallint NULL, 
		JobComponentDescription			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		NetTotalAmount					decimal(15,2) NULL,
		LineTotalAmount					decimal(15,2) NULL,
		BillAmount						decimal(15,2) NULL,
		AdditionalChargeAmount			decimal(15,2) NULL,
		CommissionAmount				decimal(15,2) NULL,
		RebateAmount					decimal(15,2) NULL,
		ResaleTaxAmount					decimal(15,2) NULL,
		AdNumber						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AdNumberDescription				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		LineCancelled					bit NOT NULL,
		DateToBill						smalldatetime NULL
	)
	
	DECLARE @start_period int,
			@end_period int

	SELECT @start_period = @start_year * 100 + @start_month
	SELECT @end_period = @end_year * 100 + @end_month

	--set @order_status='O'
	--set @start_date='2010-03-06 00:00:00'
	--set @end_date='2019-03-06 13:04:42.837'
	--set @include_internet=0
	--set @include_magazine=0
	--set @include_newspaper=0
	--set @include_outofhome=0
	--set @include_radio=0
	--set @include_television=1

	IF @include_internet = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'I',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.HEADLINE,
			OrderPeriod = CAST(YEAR(d.[START_DATE]) as varchar) + RIGHT('0' + CAST(MONTH(d.[START_DATE]) as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , MONTH(d.[START_DATE]), 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[START_DATE]),
			InsertionDate = d.[START_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.INTERNET_DETAIL AS d
			INNER JOIN dbo.INTERNET_HEADER AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
			AND d.[START_DATE] BETWEEN @start_date AND @end_date
	END

	IF @include_magazine = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'M',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.HEADLINE,
			OrderPeriod = CAST(YEAR(d.[START_DATE]) as varchar) + RIGHT('0' + CAST(MONTH(d.[START_DATE]) as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , MONTH(d.[START_DATE]), 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[START_DATE]),
			InsertionDate = d.[START_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.MAGAZINE_DETAIL AS d
			INNER JOIN dbo.MAGAZINE_HEADER AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
			AND d.[START_DATE] BETWEEN @start_date AND @end_date
	END

	IF @include_newspaper = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'N',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.HEADLINE,
			OrderPeriod = CAST(YEAR(d.[START_DATE]) as varchar) + RIGHT('0' + CAST(MONTH(d.[START_DATE]) as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , MONTH(d.[START_DATE]), 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[START_DATE]),
			InsertionDate = d.[START_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.NEWSPAPER_DETAIL AS d
			INNER JOIN dbo.NEWSPAPER_HEADER AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
			AND d.[START_DATE] BETWEEN @start_date AND @end_date
	END

	IF @include_outofhome = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'O',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.HEADLINE,
			OrderPeriod = CAST(YEAR(d.[POST_DATE]) as varchar) + RIGHT('0' + CAST(MONTH(d.[POST_DATE]) as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , MONTH(d.[POST_DATE]), 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[POST_DATE]),
			InsertionDate = d.[POST_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.OUTDOOR_DETAIL AS d
			INNER JOIN dbo.OUTDOOR_HEADER AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
			AND d.[POST_DATE] BETWEEN @start_date AND @end_date
	END

	IF @include_radio = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'R',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.PROGRAMMING,
			OrderPeriod = CAST(d.YEAR_NBR as varchar) + RIGHT('0' + CAST(d.MONTH_NBR as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , d.MONTH_NBR, 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[START_DATE]),
			InsertionDate = d.[START_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.RADIO_DETAIL AS d
			INNER JOIN dbo.RADIO_HDR AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
		AND d.YEAR_NBR *100 + d.MONTH_NBR BETWEEN @start_period AND @end_period
	END

	IF @include_television = 1
	BEGIN	
		INSERT INTO #order_detail
		SELECT 
			OrderType = 'T',
			OrderNumber = d.ORDER_NBR,
			LineNumber = d.LINE_NBR,
			LineDescription = d.PROGRAMMING,
			OrderPeriod = CAST(d.YEAR_NBR as varchar) + RIGHT('0' + CAST(d.MONTH_NBR as varchar), 2),
			OrderMonth = SUBSTRING(DateName( month , DateAdd( month , d.MONTH_NBR, 0 ) - 1 ), 1, 3),
			OrderYear = YEAR(d.[START_DATE]),
			InsertionDate = d.[START_DATE],
			OrderEndDate = d.END_DATE,
			CloseDate = d.CLOSE_DATE,
			MaterialCloseDate = d.MATL_CLOSE_DATE, 
			ExtendedMaterialCloseDate = d.EXT_MATL_DATE,
			ExtendedSpaceCloseDate = d.EXT_CLOSE_DATE, 
			JobNumber = d.JOB_NUMBER,
			JobDescription = jl.JOB_DESC,
			JobComponentNumber = d.JOB_COMPONENT_NBR, 
			JobComponentDescription = jc.JOB_COMP_DESC,
			NetTotalAmount = ISNULL(d.EXT_NET_AMT,0),
			LineTotalAmount = ISNULL(d.LINE_TOTAL,0),
			BillAmount = ISNULL(d.BILLING_AMT,0),
			AdditionalChargeAmount = ISNULL(d.ADDL_CHARGE,0),
			CommissionAmount = ISNULL(d.COMM_AMT,0),
			RebateAmount = ISNULL(d.REBATE_AMT,0),
			ResaleTaxAmount = ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
			AdNumber = d.AD_NUMBER,
			AdNumberDescription = an.AD_NBR_DESC,
			LineCancelled = CAST(ISNULL(d.LINE_CANCELLED,0) as bit),
			DateToBill = d.DATE_TO_BILL
		FROM dbo.TV_DETAIL AS d
			INNER JOIN dbo.TV_HDR AS h ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = d.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR
		WHERE d.ACTIVE_REV = 1 AND (@order_status = 'A' OR (@order_status = 'O' AND h.ORD_PROCESS_CONTRL NOT IN (6,12)))
		AND d.YEAR_NBR *100 + d.MONTH_NBR BETWEEN @start_period AND @end_period
	END

	SELECT
		OrderType,
		OrderNumber,
		LineNumber,
		LineDescription,
		OrderPeriod,
		OrderMonth,
		OrderYear,
		InsertionDate,
		OrderEndDate,
		CloseDate,
		MaterialCloseDate,
		ExtendedMaterialCloseDate,
		ExtendedSpaceCloseDate,
		JobNumber,
		JobDescription,
		JobComponentNumber,
		JobComponentDescription,
		NetTotalAmount,
		LineTotalAmount,
		BillAmount,
		AdditionalChargeAmount,
		CommissionAmount,
		RebateAmount,
		ResaleTaxAmount,
		AdNumber,
		AdNumberDescription,
		LineCancelled,
		DateToBill
	FROM #order_detail

END
