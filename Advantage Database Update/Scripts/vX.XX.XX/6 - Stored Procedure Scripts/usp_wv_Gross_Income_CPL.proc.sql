IF EXISTS (SELECT
    *
  FROM dbo.sysobjects
  WHERE id = OBJECT_ID(N'[dbo].[usp_wv_Gross_Income_CPL]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [dbo].[usp_wv_Gross_Income_CPL]
GO

CREATE PROCEDURE [dbo].[usp_wv_Gross_Income_CPL] 
@StartPeriod varchar(6),
@EndPeriod varchar(6),
@Standard int,
@IncludeOffice bit = 1, 
@IncludeClient bit = 1, 
@IncludeDivision bit = 1, 
@IncludeProduct bit = 1, 
@IncludeType bit = 1, 
@IncludeSalesClass bit = 1, 
@IncludePostPeriod bit = 1, 
@IncludeYear bit = 1, 
@IncludeCampaign bit = 1, 
@IncludeAE bit = 1, 
@IncludeProductUDF bit = 1,
@IncludeManualInvoices bit = 1, 
@IncludeGLEntries bit = 1, 
@IncludeBilledIncomeRec bit = 1,
@IncludeCREntries bit = 1,
@CoopOption int,
@HoursCost int,
@FTEAllocation int,
@OverheadSet varchar(20),
@UserId varchar(100),
@ExcludeNewBusiness bit = 0,
@DirectExpenseOperatingOnly bit = 1,
@OfficeCodeList varchar(MAX) = NULL, 	
@ClientCodeList varchar(max),
@ClientDivisionCodeList varchar(max),
@ClientDivisionProductCodeList varchar(max),

@StartPeriod1 varchar(6) = NULL,
@EndPeriod1 varchar(6) = NULL,
@StartPeriod2 varchar(6) = NULL,
@EndPeriod2 varchar(6) = NULL

AS
    
	DECLARE @StartDate smalldatetime, @EndDate smalldatetime, @OverheadFactor decimal(12,3), @FTE decimal(12,3)
	DECLARE @paramlist nvarchar(MAX)
	DECLARE @sql 		nvarchar(MAX)
	DECLARE @sql_sum	nvarchar(MAX)
	DECLARE @sql_from 	nvarchar(MAX)
	DECLARE @sql_where	nvarchar(MAX)
	DECLARE @sql_groupby varchar(MAX)

	DECLARE @MinStartPeriod varchar(6)
	DECLARE @MaxEndPeriod varchar(6)

	DECLARE @max_cnt int
	DECLARE @cnt int

	SET @MinStartPeriod = @StartPeriod
	SET @MaxEndPeriod = @EndPeriod 

	SET @max_cnt = 1
	SET @cnt = 1

	IF @StartPeriod1 IS NOT NULL AND @StartPeriod1 > ''
		SET @max_cnt = @max_cnt + 1
	IF @StartPeriod2 IS NOT NULL AND @StartPeriod2 > ''
		SET @max_cnt = @max_cnt + 1

  WHILE @cnt <= @max_cnt
  BEGIN

	IF @cnt = 1 BEGIN
		SET @StartPeriod = @StartPeriod
		SET @EndPeriod = @EndPeriod
	END

	IF @cnt = 2 BEGIN
		SET @StartPeriod = @StartPeriod1
		SET @EndPeriod = @EndPeriod1
	END

	IF @cnt = 3 BEGIN
		SET @StartPeriod = @StartPeriod2
		SET @EndPeriod = @EndPeriod2
	END

	SELECT @StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @StartPeriod

	SELECT @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @EndPeriod

	SELECT @OverheadFactor = ISNULL(CAST(AGY_SETTINGS_VALUE AS DECIMAL(12,3)),0)
	FROM AGY_SETTINGS
	WHERE AGY_SETTINGS_CODE = 'OVERHEAD_FACTOR'

	SELECT @FTE = ISNULL(CAST(AGY_SETTINGS_VALUE AS DECIMAL(12,3)),0)
	FROM AGY_SETTINGS
	WHERE AGY_SETTINGS_CODE = 'FTE_BASIS'

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @RestrictionsOffice AS INTEGER, @Restrictions INT

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

    SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);
		
	CREATE TABLE #GROSS_INCOME_CPL 
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[OfficeDescription] varchar(30),
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	    [ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Type] varchar(3),
		[SalesClassCode] varchar(6),
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6), 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6),
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6),
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50),
		[Industry] varchar(100),
		[Specialty] varchar(100),
		[RegionCode] varchar(20),
		[Region] varchar(40),
		[Revenue] decimal(14, 2),
		[NumberOfEmployees] int,
		[Source] varchar(100),
		[BilledHours] decimal(18, 2),
		[BilledQuantity] decimal(18, 2),
		[BilledFee] decimal(18, 2),
		[BilledTime] decimal(18, 2),
		[BilledCommission] decimal(18, 2),
		[BilledCostOfSales] decimal(18, 2),
		[BilledIncomeRec] decimal(18,2),
		[ManualSale] decimal(18,2), 
		[ManualCOS] decimal(18,2),
		[GLSales] decimal(18,2),
		[GLCostOfSales] decimal(18,2),
		[BilledTotal] decimal(18,2),
		[BilledCostTotal] decimal(18,2),
		[TotalGrossIncome] decimal(18,2),
		[Hours] decimal(15, 2),
		[DirectServiceCost] decimal(15, 2),
		[DirectServiceBillAmount] decimal(15, 2),
		[DirectExpense] decimal(15, 2),
		[GLDirectExpense] decimal(18,2),
		[TotalDirectCosts] decimal(15, 2),
		[TotalIncome] decimal(15, 2),
		[Overhead] decimal(15, 2),
		[IncomeLessOverhead] decimal(15, 2),
		[FTE] decimal(15,2),
		[CRClientSales] decimal(18,2),
		[CRClientCostOfSales] decimal(18,2),
		[CRClientDirectExpense] decimal(18,2),
		[NonbillableAPSales] decimal(18,2),
		[NonbillableAPCostOfSales] decimal(18,2),
		[BudgetFee] decimal(15, 2),
		[BudgetTime] decimal(15, 2),
		[BudgetCommission] decimal(15, 2),
		[BudgetCostOfSales] decimal(15, 2),
		[BudgetDirectServiceCost] decimal(15, 2),
		[BudgetDirectExpense] decimal(15, 2),
		[BudgetSummaryBilling] decimal(15,2),
		[BudgetSummaryCOS] decimal(15,2),
		[BudgetSummaryIncome] decimal(15,2),
		[BudgetBillingAmount] decimal(15, 2),
		[BudgetCOSAmount] decimal(15, 2),
		[BudgetGrossIncome] decimal(15, 2),
		[BudgetDirectCost] decimal(15, 2),
		[BudgetIncome] decimal(15, 2),
		[BudgetVarianceFee] decimal(15, 2),
		[BudgetVarianceTIme] decimal(15, 2),
		[BudgetVarianceCommission] decimal(15, 2),
		[BudgetVarianceCostOfSales] decimal(15, 2),
		[BudgetVarianceDirectServiceCost] decimal(15, 2),
		[BudgetVarianceDirectExpense] decimal(15, 2),
		[BudgetVarianceGrossIncome] decimal(15, 2),
		[BudgetVarianceIncome] decimal(15, 2),
		[BudgetVarianceBilling] decimal(15,2),
		[BudgetVarianceDirectCost] decimal(15,2),
		[ForecastFee] decimal(15, 2),
		[ForecastTime] decimal(15, 2),
		[ForecastCommission] decimal(15, 2),
		[ForecastCostOfSales] decimal(15, 2),
		[ForecastDirectServiceCost] decimal(15, 2),
		[ForecastDIrectExpense] decimal(15, 2),
		[ForecastGrossIncome] decimal(15, 2),
		[ForecastIncome] decimal(15, 2),
		[BFVarianceFee] decimal(15, 2),
		[BFVarianceTIme] decimal(15, 2),
		[BFVarianceCommission] decimal(15, 2),
		[BFVarianceCostOfSales] decimal(15, 2),
		[BFVarianceDirectServiceCost] decimal(15, 2),
		[BFVarianceDirectExpense] decimal(15, 2),
		[BFVarianceGrossIncome] decimal(15, 2),
		[BFVarianceIncome] decimal(15, 2)
    );

	CREATE TABLE #GROSS_INCOME_CPL_TOTAL --MASTER TABLE TO RETURN
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[OfficeDescription] varchar(30),
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	    [ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Type] varchar(3),
		[SalesClassCode] varchar(6),
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6), 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6),
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6),
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50),
		[Industry] varchar(100),
		[Specialty] varchar(100),
		[RegionCode] varchar(20),
		[Region] varchar(40),
		[Revenue] decimal(14, 2),
		[NumberOfEmployees] int,
		[Source] varchar(100),
		[BilledHours] decimal(18, 2),
		[BilledQuantity] decimal(18, 2),
		[BilledFee] decimal(18, 2),
		[BilledTime] decimal(18, 2),
		[BilledCommission] decimal(18, 2),
		[BilledCostOfSales] decimal(18, 2),
		[BilledIncomeRec] decimal(18,2),
		[ManualSale] decimal(18,2), 
		[ManualCOS] decimal(18,2),
		[GLSales] decimal(18,2),
		[GLCostOfSales] decimal(18,2),
		[BilledTotal] decimal(18,2),
		[BilledCostTotal] decimal(18,2),
		[TotalGrossIncome] decimal(18,2),
		[Hours] decimal(15, 2),
		[DirectServiceCost] decimal(15, 2),
		[DirectServiceBillAmount] decimal(15, 2),
		[DirectExpense] decimal(15, 2),
		[GLDirectExpense] decimal(18,2),
		[TotalDirectCosts] decimal(15, 2),
		[TotalIncome] decimal(15, 2),
		[Overhead] decimal(15, 2),
		[IncomeLessOverhead] decimal(15, 2),
		[FTE] decimal(15,2),
		[CRClientSales] decimal(18,2),
		[CRClientCostOfSales] decimal(18,2),
		[CRClientDirectExpense] decimal(18,2),
		[NonbillableAPSales] decimal(18,2),
		[NonbillableAPCostOfSales] decimal(18,2),
		[BudgetFee] decimal(15, 2),
		[BudgetTime] decimal(15, 2),
		[BudgetCommission] decimal(15, 2),
		[BudgetCostOfSales] decimal(15, 2),
		[BudgetDirectServiceCost] decimal(15, 2),
		[BudgetDirectExpense] decimal(15, 2),
		[BudgetSummaryBilling] decimal(15,2),
		[BudgetSummaryCOS] decimal(15,2),
		[BudgetSummaryIncome] decimal(15,2),
		[BudgetBillingAmount] decimal(15, 2),
		[BudgetCOSAmount] decimal(15, 2),
		[BudgetGrossIncome] decimal(15, 2),
		[BudgetDirectCost] decimal(15, 2),
		[BudgetIncome] decimal(15, 2),
		[BudgetVarianceFee] decimal(15, 2),
		[BudgetVarianceTIme] decimal(15, 2),
		[BudgetVarianceCommission] decimal(15, 2),
		[BudgetVarianceCostOfSales] decimal(15, 2),
		[BudgetVarianceDirectServiceCost] decimal(15, 2),
		[BudgetVarianceDirectExpense] decimal(15, 2),
		[BudgetVarianceGrossIncome] decimal(15, 2),
		[BudgetVarianceIncome] decimal(15, 2),
		[BudgetVarianceBilling] decimal(15,2),
		[BudgetVarianceDirectCost] decimal(15,2),
		[ForecastFee] decimal(15, 2),
		[ForecastTime] decimal(15, 2),
		[ForecastCommission] decimal(15, 2),
		[ForecastCostOfSales] decimal(15, 2),
		[ForecastDirectServiceCost] decimal(15, 2),
		[ForecastDIrectExpense] decimal(15, 2),
		[ForecastGrossIncome] decimal(15, 2),
		[ForecastIncome] decimal(15, 2),
		[BFVarianceFee] decimal(15, 2),
		[BFVarianceTime] decimal(15, 2),
		[BFVarianceCommission] decimal(15, 2),
		[BFVarianceCostOfSales] decimal(15, 2),
		[BFVarianceDirectServiceCost] decimal(15, 2),
		[BFVarianceDirectExpense] decimal(15, 2),
		[BFVarianceGrossIncome] decimal(15, 2),
		[BFVarianceIncome] decimal(15, 2),
		[SumofTotalGrossIncomeOffice] decimal(15, 2),
		[SumofDirectServiceCostOffice] decimal(15, 2),
		[SumofTotalGrossIncomeOfficeYear] decimal(15, 2),
		[SumofDirectServiceCostOfficeYear] decimal(15, 2),
		[SumofClientBilledTotal] decimal(18,2),
		[SumofClientTotalGrossIncome] decimal(18,2),
		[SumofClientOverhead] decimal(18,2),
		[SumofClientNetProfit] decimal(15, 2),
		[SumofIncomeLessOverheadClient] decimal(19, 2)
    );          
		 
	CREATE TABLE #CPL_OH_ACCOUNTS
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[GLACode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
    );

	CREATE TABLE #CPL_OH_AMOUNTS
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[RecType] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	    [ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Type] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF2] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF3] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF4] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Industry] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Specialty] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[RegionCode] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Region] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Revenue] decimal(14, 2),
		[NumberOfEmployees] int,
		[Source] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Overhead] decimal(15, 2),
		[Hours] decimal(15, 2),
		[DirectServiceCost] decimal(15, 2),
		[DirectExpense] decimal(15, 2),
		[TotalDirectCosts] decimal(15, 2)
    );

	CREATE TABLE #CPL_OH_AMOUNTS_DETAIL
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	    [ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Type] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF2] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF3] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF4] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Industry] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Specialty] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[RegionCode] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Region] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Revenue] decimal(14, 2),
		[NumberOfEmployees] int,
		[Source] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DetailHours] decimal(15, 2),
		[DetailHoursCost] decimal(15, 2)
    );

	CREATE TABLE #CPL_OH_AMOUNTS_TOTAL
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[HoursTotal] decimal(15, 2),
		[HoursCostTotal] decimal(15, 2)
    );

	CREATE TABLE #CPL_OH_AMOUNTS_DSC_PERC
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OfficeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ClientDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DivisionDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	    [ProductDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Type] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF2] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF3] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[ProductUDF4] varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Industry] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Specialty] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[RegionCode] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Region] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Revenue] decimal(14, 2),
		[NumberOfEmployees] int,
		[Source] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DirectServiceHoursPercentage] decimal(20, 10),
		[DirectServiceCostPercentage] decimal(20, 10)
    );

	CREATE TABLE #CPL_OH_AMOUNTS_OVERHEAD
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[OHToAlloc] decimal(15, 2),
		[OHTotal] decimal(15, 2)
    );

	CREATE TABLE #CPL_OH_OFFICES
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
    );

	CREATE TABLE #TOTALS 
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[OfficeCode] varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
		[OfficeDescription] varchar(30),
		[ClientCode] varchar(6),
		[ClientDescription] varchar(40),
		[DivisionCode] varchar(6),
		[DivisionDescription] varchar(40),
		[ProductCode] varchar(6),
	    [ProductDescription] varchar(40),
		[Type] varchar(3),
		[SalesClassCode] varchar(6),
		[SalesClassDescription] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6), 
		[CampaignName] varchar(128),
		[PostingPeriod] varchar(6),
		[PostingPeriodYear] int,
		[PostingPeriodMonth] smallint,
		[Year] int,
		[DefaultAECode] varchar(6),
		[DefaultAEName] varchar(100),
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50),
		[TotalOffice] decimal(18, 2),
		[TotalOfficeYear] decimal(18, 2),
		[TotalDSCOffice] decimal(18, 2),
		[TotalDSCOfficeYear] decimal(18, 2)
    );          

	--BIlled Information
	IF @CoopOption = 2
	BEGIN
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(AR.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 
			CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 'M' ELSE 'P' END, ISNULL(AR.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(AR.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
			AR.SALE_POST_PERIOD,  SUBSTRING(AR.SALE_POST_PERIOD, 1, 4), SUBSTRING(AR.SALE_POST_PERIOD, 5, 2),(SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AR.SALE_POST_PERIOD) AS [YEAR],
			ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
			ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			CASE WHEN AR.FNC_TYPE = 'E' THEN
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE ISNULL(AR.HRS_QTY,0) END END AS BILLED_HOURS,
			CASE WHEN AR.FNC_TYPE = 'V' OR AR.FNC_TYPE = 'I' THEN
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE ISNULL(AR.HRS_QTY,0) END END AS BILLED_QUANTITY,
			CASE WHEN AR.FNC_TYPE = 'I' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.ADDITIONAL_AMT,0) ELSE 0 END END AS BILLED_FEE_IO,
			CASE WHEN AR.FNC_TYPE = 'E' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE 0 END END AS BILLED_TIME,
			CASE WHEN AR.FNC_TYPE = 'V' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0) ELSE 0 END END AS BILLED_COMMISSION,
			CASE WHEN AR.FNC_TYPE = 'V' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE 0 END END AS BILLED_COST,
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM AR_SUMMARY AR INNER JOIN
			 PRODUCT P ON P.PRD_CODE = AR.PRD_CODE AND P.DIV_CODE = AR.DIV_CODE AND P.CL_CODE = AR.CL_CODE INNER JOIN
			 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
			 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
			 OFFICE O ON O.OFFICE_CODE = AR.OFFICE_CODE INNER JOIN
			 SALES_CLASS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			 JOB_COMPONENT JC ON AR.JOB_NUMBER = JC.JOB_NUMBER AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
			 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
			 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = AR.CMP_IDENTIFIER LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID
		WHERE AR.SALE_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND (AR.AR_INV_SEQ IN (0,99)) AND AR.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (AR.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
				
	END
	ELSE
	BEGIN
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(AR.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 
			CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 'M' ELSE 'P' END, ISNULL(AR.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(AR.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''), 
			AR.SALE_POST_PERIOD, SUBSTRING(AR.SALE_POST_PERIOD, 1, 4), SUBSTRING(AR.SALE_POST_PERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AR.SALE_POST_PERIOD) AS [YEAR],
			ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
			ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			CASE WHEN AR.FNC_TYPE = 'E' THEN 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE ISNULL(AR.HRS_QTY,0) END END AS BILLED_HOURS,
			CASE WHEN AR.FNC_TYPE = 'V' OR AR.FNC_TYPE = 'I' THEN
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE ISNULL(AR.HRS_QTY,0) END END AS BILLED_QUANTITY,
			CASE WHEN AR.FNC_TYPE = 'I' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.ADDITIONAL_AMT,0) ELSE 0 END END AS BILLED_FEE_IO,
			CASE WHEN AR.FNC_TYPE = 'E' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN 0 ELSE 0 END END AS BILLED_TIME,
			CASE WHEN AR.FNC_TYPE = 'V' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0) ELSE 0 END END AS BILLED_COMMISSION,
			CASE WHEN AR.FNC_TYPE = 'V' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE 0 END END AS BILLED_COST,
			--CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'I' THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END AS BILLED_FEE_IO,
			--CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'E' THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_TIME,
			--CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_COMMISSION,
			--CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END AS BILLED_COST,
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM AR_SUMMARY AR INNER JOIN
			 PRODUCT P ON P.PRD_CODE = AR.PRD_CODE AND P.DIV_CODE = AR.DIV_CODE AND P.CL_CODE = AR.CL_CODE INNER JOIN
			 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
			 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
			 OFFICE O ON O.OFFICE_CODE = AR.OFFICE_CODE INNER JOIN
			 SALES_CLASS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			 JOB_COMPONENT JC ON AR.JOB_NUMBER = JC.JOB_NUMBER AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
			 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
			 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = AR.CMP_IDENTIFIER LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID
		WHERE AR.SALE_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND (AR.AR_INV_SEQ <> 99 OR AR.AR_INV_SEQ NOT IN (0,99)) AND AR.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (AR.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	END	
   
    --Emp time hours and direct service cost	
    INSERT INTO #GROSS_INCOME_CPL
	  SELECT ISNULL(JOB_LOG.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(JOB_LOG.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(JOB_LOG.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(JOB_LOG.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 'P' AS TYPE, ISNULL(JOB_LOG.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
		   (SELECT PPPERIOD FROM POSTPERIOD PP WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE AND PPGLMONTH <> 99),SUBSTRING((SELECT PPPERIOD FROM POSTPERIOD PP WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE AND PPGLMONTH <> 99), 1, 4), SUBSTRING((SELECT PPPERIOD FROM POSTPERIOD PP WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE AND PPGLMONTH <> 99), 5, 2),
		   (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE AND PPGLMONTH <> 99),		   
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM([HoursPosted]), SUM(DIrectServiceCost), SUM(TotalBill), --HP.EMP_DATE,
		   0,0,0,0,0,0,
		   SUM(FTE),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	FROM JOB_COMPONENT INNER JOIN		 
		 (SELECT 
			ETD.JOB_NUMBER, 
			ETD.JOB_COMPONENT_NBR,
			[HoursPosted] = SUM(ETD.EMP_HOURS),
			CASE WHEN @Standard = 1 THEN ISNULL(SUM(ETD.TOTAL_COST),0) ELSE ISNULL(SUM(ETD.ALT_COST_AMT),0) END AS DIrectServiceCost,
			CASE WHEN @FTE > 0 THEN (ISNULL(SUM(ETD.EMP_HOURS),0)) / (@FTE) ELSE 0 END AS FTE,
			ET.EMP_DATE, 
			SUM(TOTAL_BILL) AS TotalBill
		FROM 
			[dbo].[EMP_TIME] AS ET INNER JOIN 
			[dbo].[EMP_TIME_DTL] AS ETD ON ET.ET_ID = ETD.ET_ID
		WHERE ET.EMP_DATE BETWEEN @StartDate AND @EndDate
		GROUP BY 
			ETD.JOB_NUMBER, 
			ETD.JOB_COMPONENT_NBR,ET.EMP_DATE) AS HP ON HP.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
											HP.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
		 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
		 PRODUCT P ON P.PRD_CODE = JOB_LOG.PRD_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE AND P.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = JOB_LOG.SC_CODE LEFT OUTER JOIN 
		 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
		 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = JOB_LOG.PRD_CODE AND CP.DIV_CODE = JOB_LOG.DIV_CODE AND CP.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = JOB_LOG.PRD_CODE AND A.DIV_CODE = JOB_LOG.DIV_CODE AND A.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID											
	WHERE JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (JOB_LOG.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	GROUP BY JOB_LOG.OFFICE_CODE, O.OFFICE_NAME, JOB_LOG.CL_CODE, C.CL_NAME, JOB_LOG.DIV_CODE, D.DIV_NAME, JOB_LOG.PRD_CODE, P.PRD_DESCRIPTION, JOB_LOG.SC_CODE, SC_DESCRIPTION,JOB_LOG.CMP_IDENTIFIER, CAMP.CMP_CODE, CAMP.CMP_NAME, HP.EMP_DATE,
			 AE.EMP_CODE, EMP.EMP_FNAME,EMP.EMP_MI,EMP.EMP_LNAME,P.USER_DEFINED1,P.USER_DEFINED2,P.USER_DEFINED3,P.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]
	
	--Direct Expense (Nonbillable AP)
	INSERT INTO #GROSS_INCOME_CPL
	SELECT ISNULL(JOB_LOG.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(JOB_LOG.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(JOB_LOG.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(JOB_LOG.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 'P' AS TYPE, ISNULL(JOB_LOG.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
		   AP_PRODUCTION.POST_PERIOD, SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4), SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD) AS [YEAR],
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ISNULL([AP_PROD_EXT_AMT],0)+ISNULL([EXT_NONRESALE_TAX],0) AS DirectExpense,
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	FROM AP_PRODUCTION INNER JOIN 
		 GLACCOUNT ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE INNER JOIN 		 	
		 JOB_COMPONENT ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN 
		 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
		 PRODUCT P ON P.PRD_CODE = JOB_LOG.PRD_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE AND P.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = JOB_LOG.SC_CODE LEFT OUTER JOIN 
		 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
		 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = JOB_LOG.PRD_CODE AND CP.DIV_CODE = JOB_LOG.DIV_CODE AND CP.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = JOB_LOG.PRD_CODE AND A.DIV_CODE = JOB_LOG.DIV_CODE AND A.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID							
	WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1 AND
		  1 = CASE WHEN @DirectExpenseOperatingOnly = 1 AND ((GLACCOUNT.GLATYPE) In ('14')) THEN 1
		           WHEN @DirectExpenseOperatingOnly = 0 AND ((GLACCOUNT.GLATYPE) In ('9','14','15')) THEN 1 ELSE 0 END
		  AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
		  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
		  (JOB_LOG.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

	--Nonbillable AP Sales
	INSERT INTO #GROSS_INCOME_CPL
	SELECT ISNULL(JOB_LOG.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(JOB_LOG.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(JOB_LOG.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(JOB_LOG.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 'P' AS TYPE, ISNULL(JOB_LOG.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
		   AP_PRODUCTION.POST_PERIOD, SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4), SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD) AS [YEAR],
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		   0,0,0,0,0,0,0,0,0,(ISNULL([AP_PROD_EXT_AMT],0)+ISNULL([EXT_NONRESALE_TAX],0)) * -1 AS NBSales,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	FROM AP_PRODUCTION INNER JOIN 
		 GLACCOUNT ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE INNER JOIN 		 	
		 JOB_COMPONENT ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN 
		 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
		 PRODUCT P ON P.PRD_CODE = JOB_LOG.PRD_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE AND P.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = JOB_LOG.SC_CODE LEFT OUTER JOIN 
		 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
		 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = JOB_LOG.PRD_CODE AND CP.DIV_CODE = JOB_LOG.DIV_CODE AND CP.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = JOB_LOG.PRD_CODE AND A.DIV_CODE = JOB_LOG.DIV_CODE AND A.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID							
	WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1 AND ((GLACCOUNT.GLATYPE) In ('8')) AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (JOB_LOG.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

	--Nonbillable AP Cost of Sales
	INSERT INTO #GROSS_INCOME_CPL
	SELECT ISNULL(JOB_LOG.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(JOB_LOG.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(JOB_LOG.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(JOB_LOG.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), 'P' AS TYPE, ISNULL(JOB_LOG.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
		   AP_PRODUCTION.POST_PERIOD, SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4), SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD) AS [YEAR],
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		   0,0,0,0,0,0,0,0,0,0,ISNULL([AP_PROD_EXT_AMT],0)+ISNULL([EXT_NONRESALE_TAX],0) AS NBCostofSales,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	FROM AP_PRODUCTION INNER JOIN 
		 GLACCOUNT ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE INNER JOIN 		 	
		 JOB_COMPONENT ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN 
		 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
		 PRODUCT P ON P.PRD_CODE = JOB_LOG.PRD_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE AND P.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = JOB_LOG.SC_CODE LEFT OUTER JOIN 
		 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
		 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = JOB_LOG.PRD_CODE AND CP.DIV_CODE = JOB_LOG.DIV_CODE AND CP.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = JOB_LOG.PRD_CODE AND A.DIV_CODE = JOB_LOG.DIV_CODE AND A.CL_CODE = JOB_LOG.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID							
	WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1 AND ((GLACCOUNT.GLATYPE) In ('13')) AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (JOB_LOG.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	
	--Budget
	INSERT INTO #GROSS_INCOME_CPL
	SELECT ISNULL(BD.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(BD.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(BD.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(BD.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), ISNULL(BUDGET_TYPE,'P'), ISNULL(BD.SC_CODE,'B'), ISNULL(SC_DESCRIPTION,'Budget'), '','','',
	       BD.BUDGET_PERIOD, SUBSTRING(BD.BUDGET_PERIOD, 1, 4), SUBSTRING(BD.BUDGET_PERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = BD.BUDGET_PERIOD) AS [YEAR],
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		   CASE WHEN CATEGORY_CODE = 'fee' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetFee,
		   CASE WHEN CATEGORY_CODE = 'lab' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetTime,
		   CASE WHEN CATEGORY_CODE = 'com' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetCommission,
		   CASE WHEN CATEGORY_CODE = 'cos' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetCostOfSales,
		   CASE WHEN CATEGORY_CODE = 'dsc' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetDirectServiceCost,
		   CASE WHEN CATEGORY_CODE = 'de' THEN ISNULL(SUM(BUDGET_VALUE),0) ELSE 0 END AS BudgetDirectExpense,
		   CASE WHEN CATEGORY_CODE = 'S' THEN ISNULL(SUM(BILLING_AMOUNT),0) ELSE 0 END AS BudgetSummaryBilling,
		   CASE WHEN CATEGORY_CODE = 'S' THEN ISNULL(SUM(BILLING_AMOUNT),0) - ISNULL(SUM(INCOME_AMOUNT),0) ELSE 0 END AS BudgetSummaryCOS,
		   CASE WHEN CATEGORY_CODE = 'S' THEN ISNULL(SUM(INCOME_AMOUNT),0) ELSE 0 END AS BudgetSummaryIncome,
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	FROM BUDGET B INNER JOIN
	 V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR LEFT OUTER JOIN
		 PRODUCT P ON P.PRD_CODE = BD.PRD_CODE AND P.DIV_CODE = BD.DIV_CODE AND P.CL_CODE = BD.CL_CODE LEFT OUTER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE LEFT OUTER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = BD.OFFICE_CODE LEFT OUTER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = BD.SC_CODE LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = BD.PRD_CODE AND CP.DIV_CODE = BD.DIV_CODE AND CP.CL_CODE = BD.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = BD.PRD_CODE AND A.DIV_CODE = BD.DIV_CODE AND A.CL_CODE = BD.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID							
    WHERE B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL --AND BUDGET_VALUE > 0
		AND BD.BUDGET_PERIOD BETWEEN @StartPeriod AND @EndPeriod AND BD.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (BD.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND BD.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND BD.CL_CODE + '|' + BD.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND BD.CL_CODE + '|' + BD.DIV_CODE + '|' + BD.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	GROUP BY BD.OFFICE_CODE, O.OFFICE_NAME, BD.CL_CODE, C.CL_NAME, BD.DIV_CODE, D.DIV_NAME, BD.PRD_CODE, P.PRD_DESCRIPTION, BUDGET_TYPE,
			 BD.SC_CODE, SC_DESCRIPTION,BD.BUDGET_PERIOD, CATEGORY_CODE,AE.EMP_CODE, EMP.EMP_FNAME,EMP.EMP_MI,EMP.EMP_LNAME,P.USER_DEFINED1,P.USER_DEFINED2,P.USER_DEFINED3,P.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

	UPDATE #GROSS_INCOME_CPL
	SET ClientDescription = (SELECT CL_NAME FROM CLIENT WHERE CLIENT.CL_CODE = #GROSS_INCOME_CPL.ClientCode)
	WHERE #GROSS_INCOME_CPL.ClientCode <> '' AND #GROSS_INCOME_CPL.ClientCode <> '*' AND #GROSS_INCOME_CPL.ClientDescription = ''

	UPDATE #GROSS_INCOME_CPL
	SET DivisionDescription = (SELECT DIV_NAME FROM DIVISION WHERE DIVISION.CL_CODE = #GROSS_INCOME_CPL.ClientCode AND DIVISION.DIV_CODE = #GROSS_INCOME_CPL.DivisionCode)
	WHERE #GROSS_INCOME_CPL.DivisionCode <> '' AND #GROSS_INCOME_CPL.DivisionCode <> '*' AND #GROSS_INCOME_CPL.DivisionDescription = ''

	UPDATE #GROSS_INCOME_CPL
	SET ProductDescription = (SELECT PRD_DESCRIPTION FROM PRODUCT WHERE PRODUCT.CL_CODE = #GROSS_INCOME_CPL.ClientCode AND PRODUCT.DIV_CODE = #GROSS_INCOME_CPL.DivisionCode AND PRODUCT.PRD_CODE = #GROSS_INCOME_CPL.ProductCode)
	WHERE #GROSS_INCOME_CPL.ProductCode <> '' AND #GROSS_INCOME_CPL.ProductCode <> '*' AND #GROSS_INCOME_CPL.ProductDescription = ''

	--Actuals
	INSERT INTO #GROSS_INCOME_CPL
	SELECT ISNULL(AA.OFFICE_CODE,''), ISNULL(O.OFFICE_NAME,''), ISNULL(AA.CL_CODE,''), ISNULL(C.CL_NAME,''), ISNULL(AA.DIV_CODE,''), ISNULL(D.DIV_NAME,''), ISNULL(AA.PRD_CODE,''), ISNULL(P.PRD_DESCRIPTION,''), ISNULL(AA.ACTUALS_TYPE,'P'), ISNULL(AA.SC_CODE,''), ISNULL(SC_DESCRIPTION,''), ISNULL(JL.CMP_IDENTIFIER,''), ISNULL(CAMP.CMP_CODE,''), ISNULL(CAMP.CMP_NAME,''),
		   AA.PPERIOD, SUBSTRING(AA.PPERIOD, 1, 4), SUBSTRING(AA.PPERIOD, 5, 2), (SELECT PPGLYEAR FROM POSTPERIOD PP WHERE PP.PPPERIOD = AA.PPERIOD) AS [YEAR],
		   ISNULL(AE.EMP_CODE,''), COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),ISNULL(P.USER_DEFINED1,''),ISNULL(P.USER_DEFINED2,''),ISNULL(P.USER_DEFINED3,''),ISNULL(P.USER_DEFINED4,''),
		   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		   CASE WHEN CATEGORY_CODE = 'fee' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastFee,
		   CASE WHEN CATEGORY_CODE = 'lab' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastTime,
		   CASE WHEN CATEGORY_CODE = 'com' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastCommission,
		   CASE WHEN CATEGORY_CODE = 'cos' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastCostOfSales,
		   CASE WHEN CATEGORY_CODE = 'dsc' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastDirectServiceCost,
		   CASE WHEN CATEGORY_CODE = 'de' THEN ISNULL(SUM(AA.AMOUNT),0) ELSE 0 END AS ForecastDirectExpense,
		   0,0,0,0,0,0,0,0,0,0
	FROM ACTUALS_ACC AA INNER JOIN
		 PRODUCT P ON P.PRD_CODE = AA.PRD_CODE AND P.DIV_CODE = AA.DIV_CODE AND P.CL_CODE = AA.CL_CODE INNER JOIN
		 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
		 OFFICE O ON O.OFFICE_CODE = AA.OFFICE_CODE INNER JOIN
		 SALES_CLASS SC ON SC.SC_CODE = AA.SC_CODE LEFT OUTER JOIN
		 JOB_COMPONENT JC ON AA.JOB_NUMBER = JC.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
		 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
		 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
		 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
		 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN
		 COMPANY_PROFILE CP ON CP.PRD_CODE = AA.PRD_CODE AND CP.DIV_CODE = AA.DIV_CODE AND CP.CL_CODE = AA.CL_CODE LEFT OUTER JOIN
		 ACTIVITY A ON A.PRD_CODE = AA.PRD_CODE AND A.DIV_CODE = AA.DIV_CODE AND A.CL_CODE = AA.CL_CODE LEFT OUTER JOIN
		 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
		 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
		 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
		 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
	WHERE (AA.PPERIOD BETWEEN @StartPeriod AND @EndPeriod)
		  AND (ACTUAL_GRP IN (0)) AND AA.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND C.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (AA.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AA.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AA.CL_CODE + '|' + AA.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AA.CL_CODE + '|' + AA.DIV_CODE + '|' + AA.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	GROUP BY AA.OFFICE_CODE, O.OFFICE_NAME, AA.CL_CODE, C.CL_NAME, AA.DIV_CODE, D.DIV_NAME, AA.PRD_CODE, P.PRD_DESCRIPTION, AA.ACTUALS_TYPE, AA.SC_CODE, SC_DESCRIPTION,JL.CMP_IDENTIFIER, CAMP.CMP_CODE, CAMP.CMP_NAME,
		   AA.PPERIOD, CATEGORY_CODE, AE.EMP_CODE, EMP.EMP_FNAME,EMP.EMP_MI,EMP.EMP_LNAME,P.USER_DEFINED1,P.USER_DEFINED2,P.USER_DEFINED3,P.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

	--Manual Invoices
	IF @IncludeManualInvoices = 1
	BEGIN
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(ACCT_REC.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(ACCT_REC.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(ACCT_REC.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(ACCT_REC.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), CASE WHEN [REC_TYPE] = 'M' THEN 'M' ELSE 'P' END, ISNULL(ACCT_REC.SC_CODE,''), 
			   ISNULL(SALES_CLASS.SC_DESCRIPTION,''), 0 AS CampaignID,'' AS CampaignCode, '' AS CampaignName,ACCT_REC.AR_POST_PERIOD, SUBSTRING(ACCT_REC.AR_POST_PERIOD, 1, 4), SUBSTRING(ACCT_REC.AR_POST_PERIOD, 5, 2), POSTPERIOD.PPGLYEAR, ISNULL(AE.EMP_CODE,''), 
			   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name],ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
			   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			   0,0,0,0,0,0,0, SUM([AR_INV_AMOUNT]-(ISNULL([AR_STATE_AMT],0)+ISNULL([AR_COUNTY_AMT],0)+ISNULL([AR_CITY_AMT],0))) AS ManualSale,
			   --CASE WHEN SUM([AR_INV_AMOUNT]) = 0 THEN CASE WHEN SUM([AR_SALE_AMT]) IS NULL THEN 0 ELSE SUM([AR_SALE_AMT]) END ELSE SUM([AR_INV_AMOUNT]-(ISNULL([AR_STATE_AMT],0)+ISNULL([AR_COUNTY_AMT],0)+ISNULL([AR_CITY_AMT],0))) END AS ManualSale,
				--Sum(IIF([AR_INV_AMOUNT]=0,IIF([AR_SALE_AMT] Is Null,0,[AR_SALE_AMT]),[AR_INV_AMOUNT]-(Nz([AR_STATE_AMT],0)+Nz([AR_COUNTY_AMT],0)+Nz([AR_CITY_AMT],0)))) AS ManualSale, 
			   Sum(ISNULL([AR_COS_AMT],0)) AS ManualCOS,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM ACCT_REC INNER JOIN 
			 OFFICE ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT JOIN 
			 SALES_CLASS ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE INNER JOIN 
			 POSTPERIOD ON ACCT_REC.AR_POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN 
			 CLIENT ON ACCT_REC.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN 
			 DIVISION ON (ACCT_REC.DIV_CODE = DIVISION.DIV_CODE) AND (ACCT_REC.CL_CODE = DIVISION.CL_CODE) LEFT OUTER JOIN 
			 PRODUCT ON (ACCT_REC.PRD_CODE = PRODUCT.PRD_CODE) AND (ACCT_REC.DIV_CODE = PRODUCT.DIV_CODE) AND (ACCT_REC.CL_CODE = PRODUCT.CL_CODE) LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = ACCT_REC.PRD_CODE AND CP.DIV_CODE = ACCT_REC.DIV_CODE AND CP.CL_CODE = ACCT_REC.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = ACCT_REC.PRD_CODE AND A.DIV_CODE = ACCT_REC.DIV_CODE AND A.CL_CODE = ACCT_REC.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
		WHERE (ACCT_REC.AR_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND (ACCT_REC.MANUAL_INV = 1) AND ACCT_REC.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (ACCT_REC.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ACCT_REC.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ACCT_REC.CL_CODE + '|' + ACCT_REC.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ACCT_REC.CL_CODE + '|' + ACCT_REC.DIV_CODE + '|' + ACCT_REC.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		GROUP BY ACCT_REC.OFFICE_CODE, OFFICE.OFFICE_NAME, ACCT_REC.CL_CODE, CLIENT.CL_NAME, ACCT_REC.DIV_CODE, DIVISION.DIV_NAME, ACCT_REC.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
			 CASE WHEN [REC_TYPE] = 'M' THEN 'M' ELSE 'P' END,ACCT_REC.SC_CODE, SALES_CLASS.SC_DESCRIPTION,ACCT_REC.AR_POST_PERIOD,POSTPERIOD.PPGLYEAR, AE.EMP_CODE,
			 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]
	END
	
	--GL Entries
	IF @IncludeGLEntries = 1
	BEGIN
		--GL Entry Sales
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(GLENTTRL.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(GLENTTRL.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(GLENTTRL.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'G' AS Type, 
			   ISNULL(GLENTTRL.GLETSOURCE,''), ISNULL(GLSOURCE.GLSRDESC,''), 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName, GLENTHDR.GLEHPP, SUBSTRING(GLENTHDR.GLEHPP, 1, 4), SUBSTRING(GLENTHDR.GLEHPP, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
			   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
			   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
			   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			   0,0,0,0,0,0,0,0,0,Sum([GLETAMT]*-1) AS [GL Entry Sales],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN  
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE	LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = GLENTTRL.PRD_CODE AND CP.DIV_CODE = GLENTTRL.DIV_CODE AND CP.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = GLENTTRL.PRD_CODE AND A.DIV_CODE = GLENTTRL.DIV_CODE AND A.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
		WHERE (((GLENTTRL.GLETSOURCE) IN ('JE','RJ','IJ','BD','BV')) AND ((GLACCOUNT.GLATYPE) In ('8'))  AND ((AGENCY_CLIENTS.CL_CODE) Is Null)--AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
				AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod)) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, 
			 PRODUCT.PRD_DESCRIPTION, GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE,
			 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			  PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--GL Entry Cost of Sales 
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(GLENTTRL.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(GLENTTRL.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(GLENTTRL.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'G' AS Type,
			   ISNULL(GLENTTRL.GLETSOURCE,''), ISNULL(GLSOURCE.GLSRDESC,''), 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName, GLENTHDR.GLEHPP, SUBSTRING(GLENTHDR.GLEHPP, 1, 4), SUBSTRING(GLENTHDR.GLEHPP, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
			   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
			   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
			   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			   0,0,0,0,0,0,0,0,0,0,SUM(GLENTTRL.GLETAMT) AS [GL Entry Cost],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = GLENTTRL.PRD_CODE AND CP.DIV_CODE = GLENTTRL.DIV_CODE AND CP.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = GLENTTRL.PRD_CODE AND A.DIV_CODE = GLENTTRL.DIV_CODE AND A.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		 
		WHERE (((GLENTTRL.GLETSOURCE) In ('JE','BD','RJ','BV','IJ','OR')) AND ((GLACCOUNT.GLATYPE)='13')  AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
				AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
			 GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
			 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--GL Entry Direct Expense 
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(GLENTTRL.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(GLENTTRL.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(GLENTTRL.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'G' AS Type,
			   ISNULL(GLENTTRL.GLETSOURCE,''), ISNULL(GLSOURCE.GLSRDESC,''), 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName, GLENTHDR.GLEHPP, SUBSTRING(GLENTHDR.GLEHPP, 1, 4), SUBSTRING(GLENTHDR.GLEHPP, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
			   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
			   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
			   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(GLENTTRL.GLETAMT) AS [GL Entry Direct Expense],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = GLENTTRL.PRD_CODE AND CP.DIV_CODE = GLENTTRL.DIV_CODE AND CP.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = GLENTTRL.PRD_CODE AND A.DIV_CODE = GLENTTRL.DIV_CODE AND A.CL_CODE = GLENTTRL.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
		WHERE (((GLENTTRL.GLETSOURCE) In ('JE','RJ','IJ')) AND
		        1 = CASE WHEN @DirectExpenseOperatingOnly = 1 AND ((GLACCOUNT.GLATYPE) In ('14')) THEN 1
		                 WHEN @DirectExpenseOperatingOnly = 0 AND ((GLACCOUNT.GLATYPE) In ('9','14','15')) THEN 1 ELSE 0 END 
			    AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
				AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
			 GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
			 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]
	END
	
	--Billed Income Rec
	IF @IncludeBilledIncomeRec = 1
	BEGIN
		INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(AR_SUMMARY.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR_SUMMARY.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR_SUMMARY.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR_SUMMARY.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), ISNULL([MEDIA_TYPE],'P'), 
			   ISNULL(AR_SUMMARY.SC_CODE,''), ISNULL(SALES_CLASS.SC_DESCRIPTION,''), ISNULL(AR_SUMMARY.CMP_IDENTIFIER,0), ISNULL(CAMPAIGN.CMP_CODE,''), ISNULL(CAMPAIGN.CMP_NAME,''), AR_SUMMARY.SALE_POST_PERIOD, SUBSTRING(AR_SUMMARY.SALE_POST_PERIOD, 1, 4), SUBSTRING(AR_SUMMARY.SALE_POST_PERIOD, 5, 2), POSTPERIOD.PPGLYEAR, ISNULL(AE.EMP_CODE,''), 
			   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''), 
			   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
			   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
			   0,0,0,0,0,0,Sum(ISNULL([AB_SALE_AMT],0)) AS BilledIncomeRec,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		FROM AR_SUMMARY INNER JOIN 
			 OFFICE ON AR_SUMMARY.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT JOIN 
			 AGENCY_CLIENTS ON AR_SUMMARY.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 POSTPERIOD ON AR_SUMMARY.SALE_POST_PERIOD = POSTPERIOD.PPPERIOD LEFT JOIN 
			 SALES_CLASS ON AR_SUMMARY.SC_CODE = SALES_CLASS.SC_CODE LEFT JOIN 
			 CAMPAIGN ON AR_SUMMARY.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER INNER JOIN 
			 CLIENT ON AR_SUMMARY.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (AR_SUMMARY.DIV_CODE = DIVISION.DIV_CODE) AND (AR_SUMMARY.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (AR_SUMMARY.PRD_CODE = PRODUCT.PRD_CODE) AND (AR_SUMMARY.DIV_CODE = PRODUCT.DIV_CODE) AND (AR_SUMMARY.CL_CODE = PRODUCT.CL_CODE) LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 COMPANY_PROFILE CP ON CP.PRD_CODE = AR_SUMMARY.PRD_CODE AND CP.DIV_CODE = AR_SUMMARY.DIV_CODE AND CP.CL_CODE = AR_SUMMARY.CL_CODE LEFT OUTER JOIN
			 ACTIVITY A ON A.PRD_CODE = AR_SUMMARY.PRD_CODE AND A.DIV_CODE = AR_SUMMARY.DIV_CODE AND A.CL_CODE = AR_SUMMARY.CL_CODE LEFT OUTER JOIN
			 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
			 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
			 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
			 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		 
		WHERE (((AR_SUMMARY.FNC_TYPE)='R') AND ((AR_SUMMARY.SALE_POST_PERIOD) Between @StartPeriod AND @EndPeriod) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (AR_SUMMARY.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE + '|' + AR_SUMMARY.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE + '|' + AR_SUMMARY.DIV_CODE + '|' + AR_SUMMARY.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		GROUP BY AR_SUMMARY.OFFICE_CODE, OFFICE.OFFICE_NAME, AR_SUMMARY.CL_CODE, CLIENT.CL_NAME, AR_SUMMARY.DIV_CODE, DIVISION.DIV_NAME, AR_SUMMARY.PRD_CODE, PRODUCT.PRD_DESCRIPTION, 
			 ISNULL([MEDIA_TYPE],'P'), AR_SUMMARY.SC_CODE, SALES_CLASS.SC_DESCRIPTION, AR_SUMMARY.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, AR_SUMMARY.SALE_POST_PERIOD, 
			 POSTPERIOD.PPGLYEAR, AE.EMP_CODE, COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''), 
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]
	END

	IF @IncludeCREntries = 1
	BEGIN
		--CR Client Detail Sales
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
					0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT*-1) AS [CR Sales],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM AR_SUMMARY AR) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE (((GLACCOUNT.GLATYPE) In ('8')) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--CR Client Detail Cost of Sales
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
					0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Cost of Sales],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM AR_SUMMARY AR) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE (((GLACCOUNT.GLATYPE) In ('13')) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--CR Client Detail Direct Expense
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
				   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Direct Expense],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM AR_SUMMARY AR) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE ( 1 = CASE WHEN @DirectExpenseOperatingOnly = 1 AND ((GLACCOUNT.GLATYPE) In ('14')) THEN 1
							 WHEN @DirectExpenseOperatingOnly = 0 AND ((GLACCOUNT.GLATYPE) In ('9','14','15')) THEN 1 ELSE 0 END AND 
					((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
		AND (CR_CLIENT.[STATUS] IS NULL OR CR_CLIENT.[STATUS] <> 'D')
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]


		--CR Client Detail Sales - Manual Invoices
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
					0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT*-1) AS [CR Sales],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM ACCT_REC AR WHERE MANUAL_INV = 1) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE (((GLACCOUNT.GLATYPE) In ('8')) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--CR Client Detail Cost of Sales - Manual Invoices
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
					0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Cost of Sales],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM ACCT_REC AR WHERE MANUAL_INV = 1) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE (((GLACCOUNT.GLATYPE) In ('13')) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

		--CR Client Detail Direct Expense - Manual Invoices
		INSERT INTO #GROSS_INCOME_CPL
			SELECT ISNULL(PRODUCT.OFFICE_CODE,''), ISNULL(OFFICE.OFFICE_NAME,''), ISNULL(AR.CL_CODE,''), ISNULL(CLIENT.CL_NAME,''), ISNULL(AR.DIV_CODE,''), ISNULL(DIVISION.DIV_NAME,''), ISNULL(AR.PRD_CODE,''), ISNULL(PRODUCT.PRD_DESCRIPTION,''), 'CR' AS Type, 'CR', 'Cash Receipts', 0 AS CampaignID, '' AS CampaignCode, '' AS CampaignName,
				   CR_CLIENT.POST_PERIOD, SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4), SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2), [POSTPERIOD].[PPGLYEAR], ISNULL(AE.EMP_CODE,''), 
				   COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') AS [Default AE Name], 
				   ISNULL(PRODUCT.USER_DEFINED1,''),ISNULL(PRODUCT.USER_DEFINED2,''), ISNULL(PRODUCT.USER_DEFINED3,''), ISNULL(PRODUCT.USER_DEFINED4,''),
				   ISNULL(I.[DESCRIPTION],''), ISNULL(S.[DESCRIPTION],''), ISNULL(CP.REGION_CODE,''),ISNULL(R.REGION_DESC,''),ISNULL(CP.REVENUE,0),ISNULL(CP.NUM_EMPLOYEES,0),ISNULL(SO.[DESCRIPTION],''),
				   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Direct Expense],0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM CR_CLIENT_DTL INNER JOIN 
				 CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN 
				 GLACCOUNT ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE INNER JOIN 
				 POSTPERIOD ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD LEFT OUTER JOIN
				 (SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, AR_INV_NBR, AR_INV_SEQ, AR_TYPE FROM ACCT_REC AR WHERE MANUAL_INV = 1) AS AR
					 ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT OUTER JOIN
				 --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
				 AGENCY_CLIENTS ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
				 CLIENT ON AR.CL_CODE = CLIENT.CL_CODE INNER JOIN 
				 DIVISION ON (AR.DIV_CODE = DIVISION.DIV_CODE) AND (AR.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
				 PRODUCT ON (AR.PRD_CODE = PRODUCT.PRD_CODE) AND (AR.DIV_CODE = PRODUCT.DIV_CODE) AND (AR.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
				 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
				 COMPANY_PROFILE CP ON CP.PRD_CODE = AR.PRD_CODE AND CP.DIV_CODE = AR.DIV_CODE AND CP.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 ACTIVITY A ON A.PRD_CODE = AR.PRD_CODE AND A.DIV_CODE = AR.DIV_CODE AND A.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
				 INDUSTRY I ON I.INDUSTRY_ID = CP.INDUSTRY_ID LEFT OUTER JOIN
				 SPECIALTY S ON S.SPECIALTY_ID = CP.SPECIALTY_ID LEFT OUTER JOIN
				 REGION R ON R.REGION_CODE = CP.REGION_CODE LEFT OUTER JOIN
				 [SOURCE] SO ON SO.SOURCE_ID = A.SOURCE_ID		
			WHERE ( 1 = CASE WHEN @DirectExpenseOperatingOnly = 1 AND ((GLACCOUNT.GLATYPE) In ('14')) THEN 1
							 WHEN @DirectExpenseOperatingOnly = 0 AND ((GLACCOUNT.GLATYPE) In ('9','14','15')) THEN 1 ELSE 0 END AND 
					((AGENCY_CLIENTS.CL_CODE) Is Null)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
					AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod) AND
			  1 = CASE WHEN @ExcludeNewBusiness = 1 AND CLIENT.[NEW_BUSINESS] = 1 THEN 0 ELSE 1 END AND 
			  (PRODUCT.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ',')) OR @OfficeCodeList IS NULL)
		AND (CR_CLIENT.[STATUS] IS NULL OR CR_CLIENT.[STATUS] <> 'D')
			  --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
			  --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
			  --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
			GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, AR.CL_CODE, CLIENT.CL_NAME, AR.DIV_CODE, DIVISION.DIV_NAME, AR.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
				 CR_CLIENT.POST_PERIOD, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
				 COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
				 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4,I.[DESCRIPTION],S.[DESCRIPTION],CP.REGION_CODE,R.REGION_DESC,CP.REVENUE,CP.NUM_EMPLOYEES,SO.[DESCRIPTION]

	END

	


	IF @FTEAllocation = 2
	BEGIN
		--Overhead Accounts
		INSERT INTO #CPL_OH_ACCOUNTS
		SELECT [GLACODE]
		FROM OH_ACCOUNTS, GLACCOUNT 
		WHERE OH_CODE = @OverheadSet AND [GLACODE] BETWEEN [OH_FROM] And [OH_TO]	

		--SELECT * FROM #CPL_OH_ACCOUNTS

		--Overhead GL Amounts
		INSERT INTO #CPL_OH_AMOUNTS
		SELECT 'OH' AS RecType, Null AS OfficeCode, Null, Null AS ClientCode, Null, Null AS DivisionCode, Null, Null AS ProductCode, Null, Null AS Type, Null AS SalesClassCode, Null, Null AS CampaignID, Null AS CampaignCode, Null,
		 GLSUMMARY.GLSPP AS PostingPeriod, SUBSTRING(GLSUMMARY.GLSPP, 1, 4), CASE WHEN SUBSTRING(GLSUMMARY.GLSPP, 5, 2) = 'YE' THEN 99 ELSE SUBSTRING(GLSUMMARY.GLSPP, 5, 2) END, POSTPERIOD.PPGLYEAR AS [Year], Null AS DefaultAECode, Null, '' AS ProductUDF1, '' AS ProductUDF2, '' AS ProductUDF3, '' AS ProductUDF4,
		 Null AS [Industry], Null AS [Specialty], Null AS [RegionCode], Null AS [Region], Null AS [Revenue], Null AS [NumberOfEmployees], Null AS [Source],
		 Sum([GLSDEBIT]+[GLSCREDIT]) AS Overhead,
		 Sum(0) AS Hours, Sum(0) AS DirectServiceCost, Sum(0) AS DirectExpense, Sum(0) AS TotalDirectCosts
		FROM (#CPL_OH_ACCOUNTS INNER JOIN GLSUMMARY ON #CPL_OH_ACCOUNTS.[GLACode] = GLSUMMARY.GLSCODE) INNER JOIN POSTPERIOD ON GLSUMMARY.GLSPP = POSTPERIOD.PPPERIOD
		WHERE (GLSUMMARY.GLSPP BETWEEN @StartPeriod AND @EndPeriod)
		GROUP BY GLSUMMARY.GLSPP, POSTPERIOD.PPGLYEAR

		--Direct Service Cost
		INSERT INTO #CPL_OH_AMOUNTS
		SELECT 'DSC' AS RecType, OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], 
			   SalesClassCode, SalesClassDescription, CampaignID, CampaignCode, CampaignName, PostingPeriod, PostingPeriodYear, PostingPeriodMonth, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4, 
			   [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source],
			   0 AS Overhead, Sum([Hours]) AS SumOfHours, Sum(DirectServiceCost) AS SumOfDirectServiceCost, 0 AS DirectExpense, Sum(DirectServiceCost) AS Total
		FROM #GROSS_INCOME_CPL
		WHERE OfficeCode IN (SELECT OFF_CODE FROM OFF_ASSIGN WHERE OH_SET_ID = @OverheadSet)
		GROUP BY OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], SalesClassCode, SalesClassDescription,
				 CampaignID, CampaignCode, CampaignName, PostingPeriod, PostingPeriodYear, PostingPeriodMonth, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
				 [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source]

		--Direct Expense
		INSERT INTO #CPL_OH_AMOUNTS
		SELECT 'DE' AS RecType, OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type],
			   SalesClassCode, SalesClassDescription, CampaignID, CampaignCode, CampaignName, PostingPeriod, PostingPeriodYear, PostingPeriodMonth, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
			   [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source],
			   Sum(0) AS Overhead, (0) AS Hours, (0) AS DirectServiceCost, Sum(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS SumOfDirectExpense, Sum(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS Total
		FROM #GROSS_INCOME_CPL
		--WHERE DirectExpense <> 0
		GROUP BY OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], SalesClassCode, SalesClassDescription,
				 CampaignID, CampaignCode, CampaignName, PostingPeriod, PostingPeriodYear, PostingPeriodMonth, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
				 [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source]

		--SELECT * FROM #CPL_OH_AMOUNTS
		--SELECT * FROM #GROSS_INCOME_CPL

		--Direct Service Cost Detail
		INSERT INTO #CPL_OH_AMOUNTS_DETAIL
		SELECT PostingPeriod AS Period, OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], SalesClassCode, SalesClassDescription,
			   CampaignID, CampaignCode, CampaignName, Max(PostingPeriod) AS PostingPeriod, Max(PostingPeriodYear), Max(PostingPeriodMonth), [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
			   [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source],
			   Sum([Hours]) AS DetailHrs, Sum(DirectServiceCost) AS DetailHrsCost
		FROM #CPL_OH_AMOUNTS
		WHERE (RecType='DSC')
		GROUP BY PostingPeriod, PostingPeriodYear, PostingPeriodMonth, OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], SalesClassCode, SalesClassDescription,
				 CampaignID, CampaignCode, CampaignName, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
				 [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source]

		--Direct Service Cost Total
		INSERT INTO #CPL_OH_AMOUNTS_TOTAL
		SELECT PostingPeriod AS Period, Sum([Hours]) AS HoursTotal, Sum(DirectServiceCost) AS HoursCostTotal
		FROM #CPL_OH_AMOUNTS
		WHERE (RecType='DSC')
		GROUP BY PostingPeriod

		--SELECT * FROM #CPL_OH_AMOUNTS_DETAIL
		--SELECT * FROM #CPL_OH_AMOUNTS_TOTAL

		--Direct Service Cost Percentage
		INSERT INTO #CPL_OH_AMOUNTS_DSC_PERC
		SELECT #CPL_OH_AMOUNTS_DETAIL.Period, OfficeCode, OfficeDescription, ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription, [Type], SalesClassCode, SalesClassDescription,
			   CampaignID, CampaignCode, CampaignName, PostingPeriod, PostingPeriodYear, PostingPeriodMonth, [Year], DefaultAECode, DefaultAEName, ProductUDF1, ProductUDF2, ProductUDF3, ProductUDF4,
			   [Industry], [Specialty], [RegionCode], [Region], [Revenue], [NumberOfEmployees], [Source],
			   CASE WHEN #CPL_OH_AMOUNTS_TOTAL.HoursTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHours/#CPL_OH_AMOUNTS_TOTAL.HoursTotal ELSE 0 END AS DirectServiceHoursPercentage,
			   CASE WHEN #CPL_OH_AMOUNTS_TOTAL.HoursCostTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHoursCost/#CPL_OH_AMOUNTS_TOTAL.HoursCostTotal ELSE 0 END AS DirectServiceCostPercentage
		FROM #CPL_OH_AMOUNTS_DETAIL INNER JOIN #CPL_OH_AMOUNTS_TOTAL ON #CPL_OH_AMOUNTS_DETAIL.Period = #CPL_OH_AMOUNTS_TOTAL.Period

		--SELECT * FROM #CPL_OH_AMOUNTS_DSC_PERC

		--Overhead Amount Total
		INSERT INTO #CPL_OH_AMOUNTS_OVERHEAD
		SELECT PostingPeriod AS Period, Sum(Overhead-TotalDirectCosts) AS OHToAlloc, Sum(Overhead) AS OHTotal
		FROM #CPL_OH_AMOUNTS
		GROUP BY PostingPeriod

		--SELECT * FROM #CPL_OH_AMOUNTS_OVERHEAD

		--Overhead	
		IF @HoursCost = 1
		BEGIN
			INSERT INTO #GROSS_INCOME_CPL
			SELECT DSP.OfficeCode, DSP.OfficeDescription, DSP.ClientCode, DSP.ClientDescription, DSP.DivisionCode, DSP.DivisionDescription, DSP.ProductCode, DSP.ProductDescription, DSP.[Type], DSP.SalesClassCode, DSP.SalesClassDescription,
				   DSP.CampaignID, DSP.CampaignCode, DSP.CampaignName, DSP.PostingPeriod, DSP.PostingPeriodYear, DSP.PostingPeriodMonth, DSP.[Year], DSP.DefaultAECode, DSP.DefaultAEName, DSP.ProductUDF1, DSP.ProductUDF2, DSP.ProductUDF3, DSP.ProductUDF4,
				   DSP.[Industry], DSP.[Specialty], DSP.[RegionCode], DSP.[Region], DSP.[Revenue], DSP.[NumberOfEmployees], DSP.[Source],
					   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,#CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceHoursPercentage,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM #CPL_OH_AMOUNTS_DSC_PERC DSP INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
		END
		IF @HoursCost = 2
		BEGIN
			INSERT INTO #GROSS_INCOME_CPL
			SELECT DSP.OfficeCode, DSP.OfficeDescription, DSP.ClientCode, DSP.ClientDescription, DSP.DivisionCode, DSP.DivisionDescription, DSP.ProductCode, DSP.ProductDescription, DSP.[Type], DSP.SalesClassCode, DSP.SalesClassDescription,
				   DSP.CampaignID, DSP.CampaignCode, DSP.CampaignName, DSP.PostingPeriod, DSP.PostingPeriodYear, DSP.PostingPeriodMonth, DSP.[Year], DSP.DefaultAECode, DSP.DefaultAEName, DSP.ProductUDF1, DSP.ProductUDF2, DSP.ProductUDF3, DSP.ProductUDF4,
				   DSP.[Industry], DSP.[Specialty], DSP.[RegionCode], DSP.[Region], DSP.[Revenue], DSP.[NumberOfEmployees], DSP.[Source],
					   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,#CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceCostPercentage,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			FROM #CPL_OH_AMOUNTS_DSC_PERC DSP INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
		END
		--INSERT INTO #GROSS_INCOME_CPL
		--SELECT DSP.OfficeCode, DSP.OfficeDescription, DSP.ClientCode, DSP.ClientDescription, DSP.DivisionCode, DSP.DivisionDescription, DSP.ProductCode, DSP.ProductDescription, DSP.[Type], DSP.SalesClassCode, DSP.SalesClassDescription,
		--	   DSP.CampaignID, DSP.CampaignCode, DSP.CampaignName, DSP.PostingPeriod, DSP.[Year], DSP.DefaultAECode, DSP.DefaultAEName, DSP.ProductUDF1, DSP.ProductUDF2, DSP.ProductUDF3, DSP.ProductUDF4,
		--		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,#CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceCostPercentage,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		--FROM #CPL_OH_AMOUNTS_DSC_PERC DSP INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
	END

	

	--SELECT * FROM #CPL_OH_AMOUNTS

	--SELECT * FROM #GROSS_INCOME_CPL

	SET @sql = 'INSERT INTO #GROSS_INCOME_CPL_TOTAL SELECT'
	IF @IncludeOffice = 1
	BEGIN
		SET @sql = @sql+' [OfficeCode],[OfficeDescription],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [OfficeCode],'''' AS [OfficeDescription],'
	END
	IF @IncludeClient = 1
	BEGIN
		SET @sql = @sql+' [ClientCode],[ClientDescription],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [ClientCode],'''' AS [ClientDescription],'
	END
	IF @IncludeDivision = 1
	BEGIN
		SET @sql = @sql+' [DivisionCode],[DivisionDescription],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [DivisionCode],'''' AS [DivisionDescription],'
	END
	IF @IncludeProduct = 1
	BEGIN
		SET @sql = @sql+' [ProductCode],[ProductDescription],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [ProductCode],'''' AS [ProductDescription],'
	END
	IF @IncludeType = 1
	BEGIN
		SET @sql = @sql+' [Type],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [Type],'
	END
	IF @IncludeSalesClass = 1
	BEGIN
		SET @sql = @sql+' [SalesClassCode],[SalesClassDescription],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [SalesClassCode],'''' AS [SalesClassDescription],'
	END
	IF @IncludeCampaign = 1
	BEGIN
		SET @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
	END
	IF @IncludePostPeriod = 1
	BEGIN
		SET @sql = @sql+' [PostingPeriod],[PostingPeriodYear],[PostingPeriodMonth],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [PostingPeriod],0 AS [PostingPeriodYear],0 AS [PostingPeriodMonth],'
	END
	IF @IncludeYear = 1
	BEGIN
		SET @sql = @sql+' [Year],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' 0 AS [Year],'
	END
	IF @IncludeAE = 1
	BEGIN
		SET @sql = @sql+' [DefaultAECode],[DefaultAEName],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [DefaultAECode],'''' AS [DefaultAEName],'
	END
	IF @IncludeProductUDF = 1
	BEGIN
		SET @sql = @sql+' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
	END
	ELSE
	BEGIN
		SET @sql = @sql+' '''' AS [ProductUDF1],'''' AS [ProductUDF2],'''' AS [ProductUDF3],'''' AS [ProductUDF4],'
	END

	SET @sql = @sql + ' [Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source],ISNULL(SUM([BilledHours]),0),ISNULL(SUM([BilledQuantity]),0),SUM([BilledFee]),SUM([BilledTime]),SUM([BilledCommission]),SUM([BilledCostOfSales]),SUM([BilledIncomeRec]),SUM([ManualSale]),SUM([ManualCOS]),SUM([GLSales]),SUM([GLCostofSales]),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])+SUM([NonbillableAPSales])+SUM([CRClientSales])),
				(SUM([BilledCostOfSales])+SUM([ManualCOS])+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales])),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales])),SUM([Hours]),SUM([DirectServiceCost]),SUM([DirectServiceBillAmount]),SUM([DirectExpense]),SUM([GLDirectExpense]),(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense])),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense])),
				CASE WHEN ' + CAST(@FTEAllocation AS VARCHAR(2)) + ' = 2 THEN SUM(Overhead) ELSE (SUM([DirectServiceCost]) * ' + CAST(@OverheadFactor AS VARCHAR(20)) + ') END,
				CASE WHEN ' + CAST(@FTEAllocation AS VARCHAR(2)) + ' = 2 THEN ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-(SUM(Overhead))) 
				ELSE ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-(SUM([DirectServiceCost]) * ' + CAST(@OverheadFactor AS VARCHAR(20)) + ')) END,
				CASE WHEN ' + CAST(@FTE AS VARCHAR(20)) + ' > 0 THEN (SUM([Hours])) / ' + CAST(@FTE AS VARCHAR(20)) + ' ELSE 0 END,SUM([CRClientSales]),SUM([CRClientCostOfSales]),SUM([CRClientDirectExpense]),SUM([NonbillableAPSales]),SUM([NonbillableAPCostOfSales]),
				SUM([BudgetFee]),SUM([BudgetTime]),SUM([BudgetCommission]),SUM([BudgetCostOfSales]),SUM([BudgetDirectServiceCost]),SUM([BudgetDirectExpense]),
				SUM([BudgetSummaryBilling]),SUM([BudgetSummaryCOS]),SUM([BudgetSummaryIncome]),(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetCostOfSales])+SUM([BudgetSummaryBilling])),(SUM([BudgetCostOfSales])+SUM([BudgetSummaryCOS])),
				(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome])),(SUM([BudgetDirectServiceCost])+SUM([BudgetDirectExpense])),
				(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome]))-(SUM([BudgetDirectServiceCost])+SUM([BudgetDirectExpense])),
				(SUM([BilledFee])-SUM([BudgetFee])),
				[BudgetVarianceTIme] = (SUM([BilledTime])-SUM([BudgetTime])),
				(SUM([BilledCommission])-SUM([BudgetCommission])),
				(SUM([BilledCostOfSales])+SUM([ManualCOS])+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]))-(SUM([BudgetCostOfSales])+SUM([BudgetSummaryCOS])),
				(SUM([DirectServiceCost])-SUM([BudgetDirectServiceCost])),
				((SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-SUM([BudgetDirectExpense])),
				((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome]))),
				((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-((SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome]))-(SUM([BudgetDirectServiceCost])+SUM([BudgetDirectExpense])))),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])+SUM([NonbillableAPSales])+SUM([CRClientSales]))-(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetCostOfSales])+SUM([BudgetSummaryBilling])),
				(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-SUM([BudgetDirectCost]), 
				SUM([ForecastFee]),SUM([ForecastTime]),SUM([ForecastCommission]),SUM([ForecastCostOfSales]),SUM([ForecastDirectServiceCost]),SUM([ForecastDIrectExpense]),
				(SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission])),
				(SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission]))-(SUM([ForecastDirectServiceCost])+SUM([ForecastDIrectExpense])),
				(SUM([ForecastFee])-SUM([BudgetFee])),
				[BFVarianceTIme] = (SUM([ForecastTime])-SUM([BudgetTime])),
				(SUM([ForecastCommission])-SUM([BudgetCommission])),
				[BFVarianceCostOfSales] = (SUM([ForecastCostOfSales])-(SUM([BudgetCostOfSales])+SUM([BudgetSummaryCOS]))),
				(SUM([ForecastDirectServiceCost])-SUM([BudgetDirectServiceCost])),
				[BFVarianceDirectExpense] = (SUM([ForecastDirectExpense])-SUM([BudgetDIrectExpense])),
				((SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission]))-(SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome]))),
				((SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission]))-(SUM([ForecastDirectServiceCost])+SUM([ForecastDirectExpense]))-((SUM([BudgetFee])+SUM([BudgetTime])+SUM([BudgetCommission])+SUM([BudgetSummaryIncome]))-(SUM([BudgetDirectServiceCost])+SUM([BudgetDIrectExpense])))),0,0,0,0
				,NULL,NULL,NULL,NULL,NULL'

	SET @sql = @sql + ' FROM #GROSS_INCOME_CPL '
	IF @RestrictionsOffice > 0
	BEGIN
		SET @sql = @sql + ' INNER JOIN EMP_OFFICE ON #GROSS_INCOME_CPL.OfficeCode = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
	END

    IF @Restrictions > 0
    BEGIN
      SET @sql = @sql + ' INNER JOIN SEC_CLIENT ON #GROSS_INCOME_CPL.ClientCode = SEC_CLIENT.CL_CODE AND #GROSS_INCOME_CPL.DivisionCode = SEC_CLIENT.DIV_CODE AND #GROSS_INCOME_CPL.ProductCode = SEC_CLIENT.PRD_CODE'
    END

	IF @ClientCodeList IS NULL
	BEGIN
	 SET @ClientCodeList = ''
	END

	IF @ClientDivisionCodeList IS NULL
	BEGIN
	 SET @ClientDivisionCodeList = ''
	END

	IF @ClientDivisionProductCodeList IS NULL
	BEGIN
	 SET @ClientDivisionProductCodeList = ''
	END

	SET @sql_where = ''
	SET @sql_where = @sql_where + ' WHERE (''' + @ClientCodeList + ''' = '''' OR (''' + @ClientCodeList + ''' <> '''' AND ClientCode IN (SELECT * FROM dbo.udf_split_list(''' + @ClientCodeList + ''', '',''))))
				  AND (''' + @ClientDivisionCodeList + ''' = '''' OR (''' + @ClientDivisionCodeList + ''' <> '''' AND ClientCode + ''|'' + DivisionCode IN (SELECT * FROM dbo.udf_split_list(''' + @ClientDivisionCodeList + ''', '',''))))
				  AND (''' + @ClientDivisionProductCodeList + ''' = '''' OR (''' + @ClientDivisionProductCodeList + ''' <> '''' AND ClientCode + ''|'' + DivisionCode + ''|'' + ProductCode IN (SELECT * FROM dbo.udf_split_list(''' + @ClientDivisionProductCodeList + ''', '',''))))'

    IF @Restrictions > 0
    BEGIN
      SET @sql_where = @sql_where + ' AND (UPPER(SEC_CLIENT.[USER_ID]) = UPPER(''' + @UserId + ''') AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0))'
    END

	SET @sql_groupby = 'GROUP BY'
	IF @IncludeOffice = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [OfficeCode],[OfficeDescription],'
	END
	IF @IncludeClient = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [ClientCode],[ClientDescription],'
	END
	IF @IncludeDivision = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [DivisionCode],[DivisionDescription],'
	END
	IF @IncludeProduct = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [ProductCode],[ProductDescription],'
	END
	IF @IncludeType = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [Type],'
	END
	IF @IncludeSalesClass = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [SalesClassCode],[SalesClassDescription],'
	END
	IF @IncludeCampaign = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [CampaignID],[CampaignCode],[CampaignName],'
	END
	IF @IncludePostPeriod = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [PostingPeriod],[PostingPeriodYear],[PostingPeriodMonth],'
	END
	IF @IncludeYear = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [Year],'
	END
	IF @IncludeAE = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [DefaultAECode],[DefaultAEName],'
	END
	IF @IncludeProductUDF = 1
	BEGIN
		SET @sql_groupby = @sql_groupby+' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
	END

	SET @sql_groupby = @sql_groupby+' [Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source]'

	IF @sql_groupby <> 'GROUP BY'
	BEGIN
		 IF @sql_groupby LIKE '%,'
		 BEGIN
			Set @sql_groupby = LEFT(@sql_groupby, LEN(@sql_groupby)-1)
		 END
	 
		-- SELECT @paramlist = '@OverheadFactor decimal(12,3), @FTE decimal(12,3), @FTEAllocation int'
		 --SET @sql = @sql+@sql_groupby 
		 PRINT @sql_where
		 EXEC (@sql+@sql_where+@sql_groupby)
		 --EXEC sp_executesql N''' + @sql + @sql_groupby + ''', @paramlist, @OverheadFactor, @FTE
	 
	END
	ELSE
	BEGIN
		PRINT @sql_where
		EXEC (@sql+@sql_where)
		--SELECT @paramlist = '@OverheadFactor decimal(12,3), @FTE decimal(12,3), @FTEAllocation int'

		 --EXEC sp_executesql @sql, @paramlist, @OverheadFactor, @FTE
	END
	--SELECT * FROM #GROSS_INCOME_CPL

	DECLARE @Sum decimal(18,2)

	Set @Sum = 0
	SET @sql = ''
	--IF @IncludeOffice = 1
	--BEGIN
		SET @sql = 'INSERT INTO #TOTALS SELECT'

		SET @sql = @sql+' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','
		SET @sql = @sql+' SUM(TotalGrossIncome),0,SUM([DirectServiceCost]),0 FROM #GROSS_INCOME_CPL_TOTAL '

		SET @sql_groupby = ''
		SET @sql_groupby = 'GROUP BY'	
		SET @sql_groupby = @sql_groupby+' [OfficeCode],[OfficeDescription]'
	
			PRINT @sql
			EXEC (@sql+@sql_groupby)

		UPDATE #GROSS_INCOME_CPL_TOTAL
		SET SumofTotalGrossIncomeOffice = (SELECT [TotalOffice] FROM #TOTALS T WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

		UPDATE #GROSS_INCOME_CPL_TOTAL
		SET SumofDirectServiceCostOffice = (SELECT [TotalDSCOffice] FROM #TOTALS T WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)
	
	--END
	--IF @IncludeClient = 1
	--BEGIN
	--	SET @sql = @sql+' [ClientCode],[ClientDescription],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [ClientCode],'''' AS [ClientDescription],'
	--END
	--IF @IncludeDivision = 1
	--BEGIN
	--	SET @sql = @sql+' [DivisionCode],[DivisionDescription],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [DivisionCode],'''' AS [DivisionDescription],'
	--END
	--IF @IncludeProduct = 1
	--BEGIN
	--	SET @sql = @sql+' [ProductCode],[ProductDescription],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [ProductCode],'''' AS [ProductDescription],'
	--END
	--IF @IncludeType = 1
	--BEGIN
	--	SET @sql = @sql+' [Type],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [Type],'
	--END
	--IF @IncludeSalesClass = 1
	--BEGIN
	--	SET @sql = @sql+' [SalesClassCode],[SalesClassDescription],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [SalesClassCode],'''' AS [SalesClassDescription],'
	--END
	--IF @IncludeCampaign = 1
	--BEGIN
	--	SET @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
	--END
	IF @IncludePostPeriod = 1
	BEGIN
		SET @sql = 'INSERT INTO #TOTALS SELECT'

		SET @sql = @sql+' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',[PostingPeriodYear],0,0,'''','''','''','''','''','''','
		SET @sql = @sql+' 0,SUM(TotalGrossIncome), 0,SUM([DirectServiceCost]) FROM #GROSS_INCOME_CPL_TOTAL '

		SET @sql_groupby = ''
		SET @sql_groupby = 'GROUP BY'	
		SET @sql_groupby = @sql_groupby+' [OfficeCode],[OfficeDescription],[PostingPeriodYear]'
	
			PRINT @sql
			EXEC (@sql+@sql_groupby)

		UPDATE #GROSS_INCOME_CPL_TOTAL
		SET SumofTotalGrossIncomeOfficeYear = (SELECT [TotalOfficeYear] FROM #TOTALS T WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode AND T.[PostingPeriodYear] = #GROSS_INCOME_CPL_TOTAL.[PostingPeriodYear])

		UPDATE #GROSS_INCOME_CPL_TOTAL
		SET SumofDirectServiceCostOfficeYear = (SELECT [TotalDSCOfficeYear] FROM #TOTALS T WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode AND T.[PostingPeriodYear] = #GROSS_INCOME_CPL_TOTAL.[PostingPeriodYear])
	
		SET @sql = @sql+' [PostingPeriod],'
	END
	--IF @IncludeYear = 1
	--BEGIN
	--	DELETE FROM #TOTALS
	--	SET @sql = ''
	--	SET @sql = 'INSERT INTO #TOTALS SELECT'

	--	SET @sql = @sql+' '''','''','''','''','''','''','''','''','''','''','''',0,'''','''','''',[Year],'''','''','''','''','''','''','
	--	SET @sql = @sql+' SUM(TotalGrossIncome) FROM #GROSS_INCOME_CPL_TOTAL '

	--	SET @sql_groupby = ''
	--	SET @sql_groupby = 'GROUP BY'
	--	SET @sql_groupby = @sql_groupby+' [Year]'
	
	--		PRINT @sql
	--		EXEC (@sql+@sql_groupby)

	--	UPDATE #GROSS_INCOME_CPL_TOTAL
	--	SET SumofTotalGrossIncomeYear = (SELECT [Total] FROM #TOTALS T WHERE T.[Year] = #GROSS_INCOME_CPL_TOTAL.[Year])
	
	--END
	--IF @IncludeAE = 1
	--BEGIN
	--	SET @sql = @sql+' [DefaultAECode],[DefaultAEName],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [DefaultAECode],'''' AS [DefaultAEName],'
	--END
	--IF @IncludeProductUDF = 1
	--BEGIN
	--	SET @sql = @sql+' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
	--END
	--ELSE
	--BEGIN
	--	SET @sql = @sql+' '''' AS [ProductUDF1],'''' AS [ProductUDF2],'''' AS [ProductUDF3],'''' AS [ProductUDF4],'
	--END

	--SET @sql = @sql+' SUM(TotalGrossIncome) FROM #GROSS_INCOME_CPL_TOTAL '

	--SET @sql_groupby = ''
	--SET @sql_groupby = 'GROUP BY'
	--IF @IncludeOffice = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [OfficeCode],[OfficeDescription],'
	--END
	--IF @IncludeClient = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [ClientCode],[ClientDescription],'
	--END
	--IF @IncludeDivision = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [DivisionCode],[DivisionDescription],'
	--END
	--IF @IncludeProduct = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [ProductCode],[ProductDescription],'
	--END
	--IF @IncludeType = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [Type],'
	--END
	--IF @IncludeSalesClass = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [SalesClassCode],[SalesClassDescription],'
	--END
	--IF @IncludeCampaign = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [CampaignID],[CampaignCode],[CampaignName],'
	--END
	--IF @IncludePostPeriod = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [PostingPeriod],'
	--END
	--IF @IncludeYear = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [Year],'
	--END
	--IF @IncludeAE = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [DefaultAECode],[DefaultAEName],'
	--END
	--IF @IncludeProductUDF = 1
	--BEGIN
	--	SET @sql_groupby = @sql_groupby+' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
	--END

	--IF @sql_groupby <> 'GROUP BY'
	--BEGIN
	--	 IF @sql_groupby LIKE '%,'
	--	 BEGIN
	--		Set @sql_groupby = LEFT(@sql_groupby, LEN(@sql_groupby)-1)
	--	 END
	 	
	--	 PRINT @sql
	--	 EXEC (@sql+@sql_groupby)
	
	 
	--END
	--ELSE
	--BEGIN
	--    PRINT @sql
	--	EXEC (@sql)
	
	--END

	--INSERT INTO #TOTALS
	--SELECT [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],
	--			[Type],[SalesClassCode],[SalesClassDescription],[CampaignID],[CampaignCode],[CampaignName],[PostingPeriod],[Year],[DefaultAECode],[DefaultAEName],
	--			[ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],
	--			SUM(TotalGrossIncome) 
	--FROM #GROSS_INCOME_CPL_TOTAL
	--GROUP BY [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],
	--			[Type],[SalesClassCode],[SalesClassDescription],[CampaignID],[CampaignCode],[CampaignName],[PostingPeriod],[Year],[DefaultAECode],[DefaultAEName],
	--			[ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4]

	--SELECT * FROM #TOTALS
		IF @cnt = 1
		BEGIN

			SELECT *
			INTO #Temp 
			FROM #GROSS_INCOME_CPL_TOTAL

		END

		IF @cnt = 2
		BEGIN

			SELECT *
			INTO #Temp1
			FROM #GROSS_INCOME_CPL_TOTAL
				
		END

		IF @cnt = 3
		BEGIN

			SELECT *
			INTO #Temp2 
			FROM #GROSS_INCOME_CPL_TOTAL
				
		END

		SET @cnt = @cnt + 1

    	DROP TABLE #GROSS_INCOME_CPL;
		DROP TABLE #GROSS_INCOME_CPL_TOTAL;
		DROP TABLE #CPL_OH_AMOUNTS;
		DROP TABLE #CPL_OH_ACCOUNTS;
		DROP TABLE #CPL_OH_AMOUNTS_DETAIL;
		DROP TABLE #CPL_OH_AMOUNTS_TOTAL;        
		DROP TABLE #CPL_OH_AMOUNTS_DSC_PERC;
		DROP TABLE #CPL_OH_AMOUNTS_OVERHEAD;
		DROP TABLE #CPL_OH_OFFICES;
		DROP TABLE #TOTALS;

	END /* While END */    
	
--SELECT @max_cnt '@max_cnt', @MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod

  IF @max_cnt IN (1,2) BEGIN

	SELECT OfficeCode, ClientCode, 0.00 SumofClientBilledTotal, 0.00 SumofClientTotalGrossIncome, 0.00 SumofIncomeLessOverheadClient 
	INTO #Temp4
	FROM #Temp

  END

  IF @max_cnt = 1 BEGIN

	SELECT OfficeCode, ClientCode, 0.00 SumofClientBilledTotal, 0.00 SumofClientTotalGrossIncome, 0.00 SumofIncomeLessOverheadClient
	INTO #Temp3
	FROM #Temp

  END

  IF @max_cnt IN (1,2,3) BEGIN

	UPDATE #Temp
	SET SumofClientBilledTotal = (SELECT
		SUM([BilledTotal])
	FROM #Temp B
	WHERE B.ClientCode = #Temp.ClientCode)

	UPDATE #Temp
	SET SumofClientTotalGrossIncome = (SELECT
		SUM([TotalGrossIncome])
	FROM #Temp B
	WHERE B.ClientCode = #Temp.ClientCode)

	UPDATE #Temp
	SET SumofIncomeLessOverheadClient = (SELECT
		SUM([IncomeLessOverhead])
	FROM #Temp B
	WHERE B.ClientCode = #Temp.ClientCode)

	--SELECT DISTINCT OfficeCode, ClientCode, SumofTotalBilledClient, SumofTotalGrossIncomeClient, SumofOverheadClient FROM #Temp2

	IF @max_cnt = 1 BEGIN
		SELECT Distinct 1, A.*,
			@MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod, ISNULL(A.SumofClientBilledTotal,0) PeriodClientBilledTotal, ISNULL(A.SumofClientTotalGrossIncome,0) PeriodClientTotalGrossIncome, ISNULL(A.SumofIncomeLessOverheadClient,0) PeriodClientNetProfit,
			ISNULL(@StartPeriod1, ' ') PP1Start, ISNULL(@EndPeriod1, ' ') PP1End, ISNULL(B.SumofClientBilledTotal,0.00) PP1ClientBilledTotal, ISNULL(B.SumofClientTotalGrossIncome,0.00) PP1ClientTotalGrossIncome, ISNULL(B.SumofIncomeLessOverheadClient,0.00) PP1ClientNetProfit,
			ISNULL(@StartPeriod2, ' ') PP2Start, ISNULL(@EndPeriod2, ' ') PP2End, ISNULL(C.SumofClientBilledTotal,0.00) PP2ClientBilledTotal, ISNULL(C.SumofClientTotalGrossIncome,0.00) PP2ClientTotalGrossIncome, ISNULL(C.SumofIncomeLessOverheadClient,0.00) PP2ClientNetProfit
		FROM #Temp A   
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp3  
			) B 
			ON A.OfficeCode = B.OfficeCode AND A.ClientCode = B.ClientCode
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp4  
			) C
			ON A.OfficeCode = C.OfficeCode AND A.ClientCode = C.ClientCode
		ORDER BY A.OfficeCode, A.ClientCode
	END

	IF @max_cnt = 2 BEGIN

		UPDATE #Temp1
		SET SumofClientBilledTotal = (SELECT
			SUM([BilledTotal])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		UPDATE #Temp1
		SET SumofClientTotalGrossIncome = (SELECT
			SUM([TotalGrossIncome])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		UPDATE #Temp1
		SET SumofIncomeLessOverheadClient = (SELECT
			SUM([IncomeLessOverhead])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		SELECT Distinct 2, A.*,
			@MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod, ISNULL(A.SumofClientBilledTotal,0) PeriodClientBilledTotal, ISNULL(A.SumofClientTotalGrossIncome,0) PeriodClientTotalGrossIncome, ISNULL(A.SumofIncomeLessOverheadClient,0) PeriodClientNetProfit,
			ISNULL(@StartPeriod1, ' ') PP1Start, ISNULL(@EndPeriod1, ' ') PP1End, ISNULL(B.SumofClientBilledTotal,0.00) PP1ClientBilledTotal, ISNULL(B.SumofClientTotalGrossIncome,0.00) PP1ClientTotalGrossIncome, ISNULL(B.SumofIncomeLessOverheadClient,0.00) PP1ClientNetProfit,
			ISNULL(@StartPeriod2, ' ') PP2Start, ISNULL(@EndPeriod2, ' ') PP2End, ISNULL(C.SumofClientBilledTotal,0.00) PP2ClientBilledTotal, ISNULL(C.SumofClientTotalGrossIncome,0.00) PP2ClientTotalGrossIncome, ISNULL(C.SumofIncomeLessOverheadClient,0.00) PP2ClientNetProfit
		FROM #Temp A   
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp1  
			) B 
			ON A.OfficeCode = B.OfficeCode AND A.ClientCode = B.ClientCode
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp4  
			) C
			ON A.OfficeCode = C.OfficeCode AND A.ClientCode = C.ClientCode
		ORDER BY A.OfficeCode, A.ClientCode
	END

	IF @max_cnt = 3 BEGIN

		UPDATE #Temp1
		SET SumofClientBilledTotal = (SELECT
			SUM([BilledTotal])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		UPDATE #Temp1
		SET SumofClientTotalGrossIncome = (SELECT
			SUM([TotalGrossIncome])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		UPDATE #Temp1
		SET SumofIncomeLessOverheadClient = (SELECT
			SUM([IncomeLessOverhead])
		FROM #Temp1 B
		WHERE B.ClientCode = #Temp1.ClientCode)

		UPDATE #Temp2
		SET SumofClientBilledTotal = (SELECT
			SUM([BilledTotal])
		FROM #Temp2 B
		WHERE B.ClientCode = #Temp2.ClientCode)

		UPDATE #Temp2
		SET SumofClientTotalGrossIncome = (SELECT
			SUM([TotalGrossIncome])
		FROM #Temp2 B
		WHERE B.ClientCode = #Temp2.ClientCode)

		UPDATE #Temp2
		SET SumofIncomeLessOverheadClient = (SELECT
			SUM([IncomeLessOverhead])
		FROM #Temp2 B
		WHERE B.ClientCode = #Temp2.ClientCode)

		UPDATE #Temp2
		SET SumofClientNetProfit = 0
		WHERE SumofClientNetProfit IS NULL

		SELECT Distinct 3, A.*,
			@MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod, ISNULL(A.SumofClientBilledTotal,0) PeriodClientBilledTotal, ISNULL(A.SumofClientTotalGrossIncome,0) PeriodClientTotalGrossIncome, ISNULL(A.SumofIncomeLessOverheadClient,0) PeriodClientNetProfit,
			ISNULL(@StartPeriod1, ' ') PP1Start, ISNULL(@EndPeriod1, ' ') PP1End, ISNULL(B.SumofClientBilledTotal,0.00) PP1ClientBilledTotal, ISNULL(B.SumofClientTotalGrossIncome,0.00) PP1ClientTotalGrossIncome, ISNULL(B.SumofIncomeLessOverheadClient,0.00) PP1ClientNetProfit,
			ISNULL(@StartPeriod2, ' ') PP2Start, ISNULL(@EndPeriod2, ' ') PP2End, ISNULL(C.SumofClientBilledTotal,0.00) PP2ClientBilledTotal, ISNULL(C.SumofClientTotalGrossIncome,0.00) PP2ClientTotalGrossIncome, ISNULL(C.SumofIncomeLessOverheadClient,0.00) PP2ClientNetProfit
			--ISNULL(@StartPeriod1, ' ') StartPeriod1, ISNULL(@EndPeriod1, ' ') EndPeriod1, ISNULL(B.SumofClientBilledTotal,0.00) Period1ClientBilledTotal, ISNULL(B.SumofClientTotalGrossIncome,0.00) Period1ClientTotalGrossIncome, ISNULL(B.SumofIncomeLessOverheadClient,0.00) Period1ClientNetProfit,
			--ISNULL(@StartPeriod2, ' ') StartPeriod2, ISNULL(@EndPeriod2, ' ') EndPeriod2, ISNULL(C.SumofClientBilledTotal,0.00) Period2ClientBilledTotal, ISNULL(C.SumofClientTotalGrossIncome,0.00) Period2ClientTotalGrossIncome, ISNULL(C.SumofIncomeLessOverheadClient,0.00) Period2ClientNetProfit
		FROM #Temp A   
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp1  
			) B 
			ON A.OfficeCode = B.OfficeCode AND A.ClientCode = B.ClientCode
		LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofClientBilledTotal, SumofClientTotalGrossIncome, SumofIncomeLessOverheadClient FROM #Temp2  
			) C
			ON A.OfficeCode = C.OfficeCode AND A.ClientCode = C.ClientCode
		ORDER BY A.OfficeCode, A.ClientCode
	END

	--SELECT
	--*, Overhead
	--FROM #Temp A
	--ORDER BY A.OfficeCode, A.ClientCode, A.JobNumber, A.OrderNumber, A.LineNumber

	--SELECT
	--*, Overhead
	--FROM #Temp1 A
	--ORDER BY A.OfficeCode, A.ClientCode, A.JobNumber

	--SELECT
	--*, Overhead
	--FROM #Temp2 A
	--ORDER BY A.OfficeCode, A.ClientCode, A.JobNumber
  END

GO

GRANT EXECUTE ON [usp_wv_Gross_Income_CPL] TO PUBLIC AS dbo

GO

