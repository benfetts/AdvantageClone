IF EXISTS (SELECT
    *
  FROM dbo.sysobjects
  WHERE id = OBJECT_ID(N'[dbo].[usp_wv_Gross_Income_CPL_Detail]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [dbo].[usp_wv_Gross_Income_CPL_Detail]
GO


CREATE PROCEDURE [dbo].[usp_wv_Gross_Income_CPL_Detail] 
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
@OFFICE_LIST AS varchar(max) = NULL,
@ClientCodeList varchar(max),
@ClientDivisionCodeList varchar(max),
@ClientDivisionProductCodeList varchar(max)
--@BySalesClass bit = 0
--@Summary bit
--@StartPeriod1 varchar(6) = NULL,
--@EndPeriod1 varchar(6) = NULL,
--@StartPeriod2 varchar(6) = NULL,
--@EndPeriod2 varchar(6) = NULL

AS

  DECLARE @StartDate smalldatetime,
          @EndDate smalldatetime
  DECLARE @OverheadFactor decimal(12, 3),
          @FTE decimal(12, 3)
  DECLARE @paramlist nvarchar(max)
  DECLARE @sql nvarchar(max)
  DECLARE @sql2 nvarchar(max)
  DECLARE @sql_sum nvarchar(max)
  DECLARE @sql_from nvarchar(max)
  DECLARE @sql_where nvarchar(max)
  DECLARE @sql_groupby varchar(max)
  DECLARE @BySalesClass bit = 0

  --DECLARE @MinStartPeriod varchar(6)
  --DECLARE @MaxEndPeriod varchar(6)

  DECLARE @max_cnt int
  DECLARE @cnt int

  --SET @MinStartPeriod = @StartPeriod
  --SET @MaxEndPeriod = @EndPeriod 

  SET @max_cnt = 1
  SET @cnt = 1

  --IF @StartPeriod1 IS NOT NULL
  --  SET @max_cnt = @max_cnt + 1
  --IF @StartPeriod2 IS NOT NULL
  --  SET @max_cnt = @max_cnt + 1

  DECLARE @EMP_CODE AS varchar(6)
  DECLARE @RestrictionsOffice AS integer, @Restrictions INT

  SELECT
    @OverheadFactor = ISNULL(CAST(AGY_SETTINGS_VALUE AS decimal(12, 3)), 0)
  FROM AGY_SETTINGS
  WHERE AGY_SETTINGS_CODE = 'OVERHEAD_FACTOR'

  SELECT
    @FTE = ISNULL(CAST(AGY_SETTINGS_VALUE AS decimal(12, 3)), 0)
  FROM AGY_SETTINGS
  WHERE AGY_SETTINGS_CODE = 'FTE_BASIS'

  SELECT
    @EMP_CODE = EMP_CODE
  FROM SEC_USER
  WHERE UPPER(USER_CODE) = UPPER(@UserID)

  SELECT
    @RestrictionsOffice = COUNT(*)
  FROM EMP_OFFICE
  WHERE EMP_CODE = @EMP_CODE

  SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);

  WHILE @cnt <= @max_cnt
  BEGIN

	IF @cnt = 1 BEGIN
		SET @StartPeriod = @StartPeriod
		SET @EndPeriod = @EndPeriod
	END

	SELECT
	@StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @StartPeriod

	SELECT
	@EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @EndPeriod

    CREATE TABLE #GROSS_INCOME_CPL (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [DefaultAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DefaultAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
      [JobNumber] int,
      [JobDescription] varchar(60),
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60),
      [JobStatus] varchar(10),
      [JobTypeCode] varchar(10),
      [JobTypeDescription] varchar(30),
      [SalesClassFormatCode] varchar(8),
      [ComplexityCode] varchar(8),
      [PromotionCode] varchar(8),
      [ClientReference] varchar(30),
      [ClientPO] varchar(40),
      [JobAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable1] varchar(40),
      [LabelFromUDFTable2] varchar(40),
      [LabelFromUDFTable3] varchar(40),
      [LabelFromUDFTable4] varchar(40),
      [LabelFromUDFTable5] varchar(40),
      [CompLabelFromUDFTable1] varchar(40),
      [CompLabelFromUDFTable2] varchar(40),
      [CompLabelFromUDFTable3] varchar(40),
      [CompLabelFromUDFTable4] varchar(40),
      [CompLabelFromUDFTable5] varchar(40),
      [FunctionCode] varchar(6),
      [FunctionConsolidationCode] varchar(6),
      [FunctionConsolidation] varchar(30),
      [FunctionDescription] varchar(30),
      [FunctionHeading] varchar(60),
      [FunctionType] varchar(1),
      [OrderNumber] int,
      [OrderDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [EstimatedHours] decimal(15, 2),
      [EstimateFee] decimal(15, 2),
      [EstimateTime] decimal(15, 2),
      [EstimateMarkupAmount] decimal(15, 2),
      [EstimatedCostAmount] decimal(15, 2),
      [EstimatedTotalAmount] decimal(15, 2),
      [BilledHours] decimal(18, 2),
      [BilledQuantity] decimal(18, 2),
      [BilledFee] decimal(18, 2),
      [BilledTime] decimal(18, 2),
      [BilledCommission] decimal(18, 2),
      [BilledCostOfSales] decimal(18, 2),
      [BilledIncomeRec] decimal(18, 2),
      [ManualSale] decimal(18, 2),
      [ManualCOS] decimal(18, 2),
      [GLSales] decimal(18, 2),
      [GLCostOfSales] decimal(18, 2),
      [BilledTotal] decimal(18, 2),
      [BilledCostTotal] decimal(18, 2),
      [TotalGrossIncome] decimal(18, 2),
      [Hours] decimal(15, 2),
      [DirectServiceCost] decimal(15, 2),
      [DirectServiceBillAmount] decimal(15, 2),
      [DirectExpense] decimal(15, 2),
      [GLDirectExpense] decimal(18, 2),
      [TotalDirectCosts] decimal(15, 2),
      [TotalIncome] decimal(15, 2),
      [Overhead] decimal(15, 2),
      [IncomeLessOverhead] decimal(15, 2),
      [FTE] decimal(15, 2),
      [CRClientSales] decimal(18, 2),
      [CRClientCostOfSales] decimal(18, 2),
      [CRClientDirectExpense] decimal(18, 2),
      [NonbillableAPSales] decimal(18, 2),
      [NonbillableAPCostOfSales] decimal(18, 2),
      --[BudgetFee] decimal(15, 2),
      --[BudgetTime] decimal(15, 2),
      --[BudgetCommission] decimal(15, 2),
      --[BudgetCostOfSales] decimal(15, 2),
      --[BudgetDirectServiceCost] decimal(15, 2),
      --[BudgetDirectExpense] decimal(15, 2),
      --[BudgetGrossIncome] decimal(15, 2),
      --[BudgetIncome] decimal(15, 2),
      --[BudgetVarianceFee] decimal(15, 2),
      --[BudgetVarianceTIme] decimal(15, 2),
      --[BudgetVarianceCommission] decimal(15, 2),
      --[BudgetVarianceCostOfSales] decimal(15, 2),
      --[BudgetVarianceDirectServiceCost] decimal(15, 2),
      --[BudgetVarianceDirectExpense] decimal(15, 2),
      --[BudgetVarianceGrossIncome] decimal(15, 2),
      --[BudgetVarianceIncome] decimal(15, 2),
      [ForecastFee] decimal(15, 2),
      [ForecastTime] decimal(15, 2),
      [ForecastCommission] decimal(15, 2),
      [ForecastCostOfSales] decimal(15, 2),
      [ForecastDirectServiceCost] decimal(15, 2),
      [ForecastDIrectExpense] decimal(15, 2),
      [ForecastGrossIncome] decimal(15, 2),
      [ForecastIncome] decimal(15, 2)
    --[BFVarianceFee] decimal(15, 2),
    --[BFVarianceTIme] decimal(15, 2),
    --[BFVarianceCommission] decimal(15, 2),
    --[BFVarianceCostOfSales] decimal(15, 2),
    --[BFVarianceDirectServiceCost] decimal(15, 2),
    --[BFVarianceDirectExpense] decimal(15, 2),
    --[BFVarianceGrossIncome] decimal(15, 2),
    --[BFVarianceIncome] decimal(15, 2)
    );

    CREATE TABLE #GROSS_INCOME_CPL_TOTAL --MASTER TABLE TO RETURN
    (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [JobNumber] int,
      [JobDescription] varchar(60),
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60),
      [JobStatus] varchar(10),
      [JobTypeCode] varchar(10),
      [JobTypeDescription] varchar(30),
      [SalesClassFormatCode] varchar(8),
      [ComplexityCode] varchar(8),
      [PromotionCode] varchar(8),
      [ClientReference] varchar(30),
      [ClientPO] varchar(40),
      [JobAECode] varchar(6),
      [JobAEName] varchar(100),
      [LabelFromUDFTable1] varchar(40),
      [LabelFromUDFTable2] varchar(40),
      [LabelFromUDFTable3] varchar(40),
      [LabelFromUDFTable4] varchar(40),
      [LabelFromUDFTable5] varchar(40),
      [CompLabelFromUDFTable1] varchar(40),
      [CompLabelFromUDFTable2] varchar(40),
      [CompLabelFromUDFTable3] varchar(40),
      [CompLabelFromUDFTable4] varchar(40),
      [CompLabelFromUDFTable5] varchar(40),
      [FunctionCode] varchar(6),
      [FunctionConsolidationCode] varchar(6),
      [FunctionConsolidation] varchar(30),
      [FunctionDescription] varchar(30),
      [FunctionHeading] varchar(60),
      [FunctionType] varchar(1),
      [OrderNumber] int,
      [OrderDescription] varchar(60),
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10),
      [MarketDescription] varchar(40),
      [SalesGLAccountCode] varchar(30),
      [SalesGLAccountDescription] varchar(75),
      [CostOfSalesGLAccountCode] varchar(30),
      [CostOfSalesGLAccountDescription] varchar(75),
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [BilledHours] decimal(18, 2),
      [BilledQuantity] decimal(18, 2),
      [BilledFee] decimal(18, 2),
      [BilledTime] decimal(18, 2),
      [BilledCommission] decimal(18, 2),
      [BilledCostOfSales] decimal(18, 2),
      [BilledIncomeRec] decimal(18, 2),
      [EstimatedHours] decimal(15, 2),
      [EstimateFee] decimal(15, 2),
      [EstimateTime] decimal(15, 2),
      [EstimateMarkupAmount] decimal(15, 2),
      [EstimatedCostAmount] decimal(15, 2),
      [EstimatedTotalAmount] decimal(15, 2),
      [ManualSale] decimal(18, 2),
      [ManualCOS] decimal(18, 2),
      [GLSales] decimal(18, 2),
      [GLCostOfSales] decimal(18, 2),
      [BilledTotal] decimal(18, 2),
      [BilledCostTotal] decimal(18, 2),
      [TotalGrossIncome] decimal(18, 2),
      [Hours] decimal(15, 2),
      [DirectServiceCost] decimal(15, 2),
      [DirectServiceBillAmount] decimal(15, 2),
      [DirectExpense] decimal(15, 2),
      [GLDirectExpense] decimal(18, 2),
      [TotalDirectCosts] decimal(15, 2),
      [TotalIncome] decimal(15, 2),
      [Overhead] decimal(15, 2),
      [IncomeLessOverhead] decimal(15, 2),
      [FTE] decimal(15, 2),
      [CRClientSales] decimal(18, 2),
      [CRClientCostOfSales] decimal(18, 2),
      [CRClientDirectExpense] decimal(18, 2),
      [NonbillableAPSales] decimal(18, 2),
      [NonbillableAPCostOfSales] decimal(18, 2),
      --[BudgetFee] decimal(15, 2),
      --[BudgetTime] decimal(15, 2),
      --[BudgetCommission] decimal(15, 2),
      --[BudgetCostOfSales] decimal(15, 2),
      --[BudgetDirectServiceCost] decimal(15, 2),
      --[BudgetDirectExpense] decimal(15, 2),
      --[BudgetGrossIncome] decimal(15, 2),
      --[BudgetIncome] decimal(15, 2),
      --[BudgetVarianceFee] decimal(15, 2),
      --[BudgetVarianceTIme] decimal(15, 2),
      --[BudgetVarianceCommission] decimal(15, 2),
      --[BudgetVarianceCostOfSales] decimal(15, 2),
      --[BudgetVarianceDirectServiceCost] decimal(15, 2),
      --[BudgetVarianceDirectExpense] decimal(15, 2),
      --[BudgetVarianceGrossIncome] decimal(15, 2),
      --[BudgetVarianceIncome] decimal(15, 2),
      [ForecastFee] decimal(15, 2),
      [ForecastTime] decimal(15, 2),
      [ForecastCommission] decimal(15, 2),
      [ForecastCostOfSales] decimal(15, 2),
      [ForecastDirectServiceCost] decimal(15, 2),
      [ForecastDIrectExpense] decimal(15, 2),
      [ForecastGrossIncome] decimal(15, 2),
      [ForecastIncome] decimal(15, 2),
      --[BFVarianceFee] decimal(15, 2),
      --[BFVarianceTime] decimal(15, 2),
      --[BFVarianceCommission] decimal(15, 2),
      --[BFVarianceCostOfSales] decimal(15, 2),
      --[BFVarianceDirectServiceCost] decimal(15, 2),
      --[BFVarianceDirectExpense] decimal(15, 2),
      --[BFVarianceGrossIncome] decimal(15, 2),
      --[BFVarianceIncome] decimal(15, 2),	
      [SumofTotalBilledOffice] decimal(15, 2),
      [SumofTotalBilledClient] decimal(15, 2),
      [SumofTotalBilledClientDivisionProduct] decimal(15, 2),
      [SumofTotalBilledOfficeClient] decimal(15, 2),
      [SumofTotalBilledOfficeClientDivsionProduct] decimal(15, 2),
      [SumofTotalCostOfBillingOffice] decimal(15, 2),
      [SumofTotalCostOfBillingClient] decimal(15, 2),
      [SumofTotalCostOfBillingClientDivisionProduct] decimal(15, 2),
      [SumofTotalCostOfBillingOfficeClient] decimal(15, 2),
      [SumofTotalCostOfBillingOfficeClientDivisionProduct] decimal(15, 2),
      [SumofDirectExpensesOffice] decimal(19, 2),
      [SumofDirectExpensesClient] decimal(19, 2),
      [SumofDirectServiceCostOffice] decimal(19, 2),
      [SumofDirectServiceCostOfficeCurrent] decimal(19, 2),
      [SumofDirectServiceCostClient] decimal(19, 2),
      [SumofDirectServiceCostClientCurrent] decimal(19, 2),
      [SumofTotalGrossIncomeOffice] decimal(19, 2),
      [SumofTotalGrossIncomeClient] decimal(19, 2),
      [SumofTotalBilledSalesClass] decimal(15, 2),
      [SumofTotalCostOfBillingSalesClass] decimal(15, 2),
      [SumofDirectExpensesSalesClass] decimal(19, 2),
      [SumofDirectServiceCostSalesClass] decimal(19, 2),
	  [SumofIncomeLessOverheadClient] decimal(19, 2)
    );

    CREATE TABLE #CPL_OH_ACCOUNTS (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
      [GLACode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
    );

    CREATE TABLE #CPL_OH_AMOUNTS (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [JobNumber] int,
      [JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobStatus] varchar(10),
      [JobTypeCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobTypeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesClassFormatCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ComplexityCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [PromotionCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientReference] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidationCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidation] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionHeading] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [OrderNumber] int,
      [OrderDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [Overhead] decimal(15, 2),
      [Hours] decimal(15, 2),
      [DirectServiceCost] decimal(15, 2),
      [DirectExpense] decimal(15, 2),
      [TotalDirectCosts] decimal(15, 2)
    );

    CREATE TABLE #CPL_OH_AMOUNTS_DETAIL (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [JobNumber] int,
      [JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobStatus] varchar(10),
      [JobTypeCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobTypeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesClassFormatCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ComplexityCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [PromotionCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientReference] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidationCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidation] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionHeading] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [OrderNumber] int,
      [OrderDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DetailHours] decimal(15, 2),
      [DetailHoursCost] decimal(15, 2)
    );

    CREATE TABLE #CPL_OH_AMOUNTS_TOTAL (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
      [Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [HoursTotal] decimal(15, 2),
      [HoursCostTotal] decimal(15, 2)
    );

    CREATE TABLE #CPL_OH_AMOUNTS_DSC_PERC (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [JobNumber] int,
      [JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobStatus] varchar(10),
      [JobTypeCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobTypeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesClassFormatCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ComplexityCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [PromotionCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientReference] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidationCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidation] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionHeading] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [OrderNumber] int,
      [OrderDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectServiceHoursPercentage] decimal(20, 10),
      [DirectServiceCostPercentage] decimal(20, 10)
    );

    CREATE TABLE #CPL_OH_AMOUNTS_OVERHEAD (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
      [Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [OHToAlloc] decimal(15, 2),
      [OHTotal] decimal(15, 2)
    );

    CREATE TABLE #CPL_OH_OFFICES (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
      [OfficeCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
    );

    CREATE TABLE #TOTALS (
      [ID] [int] IDENTITY (1, 1) NOT NULL,
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
      [Industry] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [Specialty] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [RegionCode] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [Region] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [Revenue] decimal(14, 2),
      [NumberOfEmployees] int,
      [Source] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobNumber] int,
      [JobDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobComponentNumber] smallint,
      [ComponentDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      --[JobStatus] varchar(10),
      [JobTypeCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobTypeDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesClassFormatCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ComplexityCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [PromotionCode] varchar(8) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientReference] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [ClientPO] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAECode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [JobAEName] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable1] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable2] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable3] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable4] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CompLabelFromUDFTable5] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidationCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionConsolidation] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionDescription] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionHeading] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [FunctionType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [OrderNumber] int,
      [OrderDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [LineNumber] smallint,
      [MediaMonth] smallint,
      [MediaYear] smallint,
      [StartDate] smalldatetime,
      [EndDate] smalldatetime,
      [MarketCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [MarketDescription] varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [SalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [CostOfSalesGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountCode] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [DirectExpenseGLAccountDescription] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
      [TotalBilledOffice] decimal(18, 2),
      [TotalBilledClient] decimal(18, 2),
      [TotalBilledClientDivisionProduct] decimal(18, 2),
      [TotalBilledOfficeClient] decimal(18, 2),
      [TotalBilledOfficeClientDivisionProduct] decimal(18, 2),
      [TotalCostOfBilingOffice] decimal(18, 2),
      [TotalCostOfBilingClient] decimal(18, 2),
      [TotalCostOfBilingClientDivisionProduct] decimal(18, 2),
      [TotalCostOfBilingOfficeClient] decimal(18, 2),
      [TotalCostOfBilingOfficeClientDivisionProduct] decimal(18, 2),
      [TotalDirectExpensesOffice] decimal(19, 2),
      [TotalDirectExpensesClient] decimal(19, 2),
      [TotalDirectServiceCostOffice] decimal(19, 2),
      [TotalDirectServiceCostClient] decimal(19, 2),
      [TotalGrossIncomeOffice] decimal(19, 2),
      [TotalGrossIncomeClient] decimal(19, 2),
      [TotalBilledSalesClass] decimal(15, 2),
      [TotalCostOfBillingSalesClass] decimal(15, 2),
      [TotalDirectExpensesSalesClass] decimal(19, 2),
      [TotalDirectServiceCostSalesClass] decimal(19, 2)

    );


    --BIlled Information
    IF @CoopOption = 2
    BEGIN
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(AR.OFFICE_CODE, ''),
          ISNULL(O.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(C.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(D.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(P.PRD_DESCRIPTION, ''),
          CASE
            WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 'M'
            ELSE 'P'
          END,
          ISNULL(AR.SC_CODE, ''),
          ISNULL(SC_DESCRIPTION, ''),
          ISNULL(AR.CMP_IDENTIFIER, ''),
          ISNULL(CAMP.CMP_CODE, ''),
          ISNULL(CAMP.CMP_NAME, ''),
          AR.SALE_POST_PERIOD,
          SUBSTRING(AR.SALE_POST_PERIOD, 1, 4),
          SUBSTRING(AR.SALE_POST_PERIOD, 5, 2),
          (SELECT
            PPGLYEAR
          FROM POSTPERIOD PP
          WHERE PP.PPPERIOD = AR.SALE_POST_PERIOD)
          AS [YEAR],
          CASE
            WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AED.EMP_CODE, '')
            ELSE ISNULL(JC.EMP_CODE, '')
          END,
          NULL,
          ISNULL(P.USER_DEFINED1, ''),
          ISNULL(P.USER_DEFINED2, ''),
          ISNULL(P.USER_DEFINED3, ''),
          ISNULL(P.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          AR.JOB_NUMBER,
          JL.JOB_DESC,
          AR.JOB_COMPONENT_NBR,
          JC.JOB_COMP_DESC,
          CASE
            WHEN AR.JOB_NUMBER IS NOT NULL THEN CASE
                WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                ELSE 'Open'
              END
          END,
          ISNULL(JC.JT_CODE, ''),
          ISNULL(JT.JT_DESC, ''),
          ISNULL(JL.FORMAT_CODE, ''),
          ISNULL(JL.COMPLEX_CODE, ''),
          ISNULL(JL.PROMO_CODE, ''),
          ISNULL(JL.JOB_CLI_REF, ''),
          ISNULL(JC.JOB_CL_PO_NBR, ''),
          ISNULL(JC.EMP_CODE, ''),
          NULL,
          ISNULL(JUDV1.UDV_DESC, ''),
          ISNULL(JUDV2.UDV_DESC, ''),
          ISNULL(JUDV3.UDV_DESC, ''),
          ISNULL(JUDV4.UDV_DESC, ''),
          ISNULL(JUDV5.UDV_DESC, ''),
          ISNULL(JCUDV1.UDV_DESC, ''),
          ISNULL(JCUDV2.UDV_DESC, ''),
          ISNULL(JCUDV3.UDV_DESC, ''),
          ISNULL(JCUDV4.UDV_DESC, ''),
          ISNULL(JCUDV5.UDV_DESC, ''),
          AR.FNC_CODE,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN AR.FNC_CODE
            ELSE CF.FNC_CODE
          END,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
            ELSE CF.FNC_DESCRIPTION
          END,
          F.FNC_DESCRIPTION,
          FH.FNC_HEADING_DESC,
          AR.FNC_TYPE,
          AR.ORDER_NBR,
          MH.ORDER_DESC,
          AR.ORDER_LINE_NBR,
          AR.MEDIA_MONTH,
          AR.MEDIA_YEAR,
          AR.[START_DATE],
          AR.END_DATE,
          CASE
            WHEN AR.MARKET_CODE IS NOT NULL THEN AR.MARKET_CODE
            ELSE JC.MARKET_CODE
          END,
          NULL,
          AR.GL_ACCT_SALE,
          NULL,
          AR.GL_ACCT_COS,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          CASE
            WHEN AR.FNC_TYPE = 'E' THEN CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE ISNULL(AR.HRS_QTY, 0)
              END
          END AS BILLED_HOURS,
          CASE
            WHEN AR.FNC_TYPE = 'V' OR
              AR.FNC_TYPE = 'I' THEN CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE ISNULL(AR.HRS_QTY, 0)
              END
          END AS BILLED_QUANTITY,
          CASE
            WHEN AR.FNC_TYPE = 'I' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.INC_ONLY_AMT, 0) + ISNULL(AR.AB_INC_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.INC_ONLY_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0) + ISNULL(AR.ADDITIONAL_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.ADDITIONAL_AMT, 0)
                ELSE 0
              END
          END AS BILLED_FEE_IO,
          CASE
            WHEN AR.FNC_TYPE = 'E' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.EMP_TIME_AMT, 0) + ISNULL(AR.AB_INC_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.EMP_TIME_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE 0
              END
          END AS BILLED_TIME,
          CASE
            WHEN AR.FNC_TYPE = 'V' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.AB_COMMISSION_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.REBATE_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.REBATE_AMT, 0)
                ELSE 0
              END
          END AS BILLED_COMMISSION,
          CASE
            WHEN AR.FNC_TYPE = 'V' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COST_AMT, 0) + ISNULL(AR.AB_COST_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
                ELSE ISNULL(AR.COST_AMT, 0) + ISNULL(AR.NET_CHARGE_AMT, 0) + ISNULL(AR.DISCOUNT_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.COST_AMT, 0) + ISNULL(AR.NET_CHARGE_AMT, 0) + ISNULL(AR.DISCOUNT_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
                ELSE 0
              END
          END AS BILLED_COST,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'I' THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END AS BILLED_FEE_IO,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'E' THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_TIME,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_COMMISSION,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END AS BILLED_COST,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM AR_SUMMARY AR
        INNER JOIN PRODUCT P
          ON P.PRD_CODE = AR.PRD_CODE
          AND P.DIV_CODE = AR.DIV_CODE
          AND P.CL_CODE = AR.CL_CODE
        INNER JOIN DIVISION D
          ON D.DIV_CODE = P.DIV_CODE
          AND D.CL_CODE = P.CL_CODE
        INNER JOIN CLIENT C
          ON C.CL_CODE = D.CL_CODE
        INNER JOIN OFFICE O
          ON O.OFFICE_CODE = AR.OFFICE_CODE
        INNER JOIN SALES_CLASS SC
          ON SC.SC_CODE = AR.SC_CODE
        LEFT OUTER JOIN JOB_COMPONENT JC
          ON AR.JOB_NUMBER = JC.JOB_NUMBER
          AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
        LEFT OUTER JOIN
        --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JC.EMP_CODE
        --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN 
        ACCOUNT_EXECUTIVE AED
          ON P.CL_CODE = AED.CL_CODE
          AND P.DIV_CODE = AED.DIV_CODE
          AND P.PRD_CODE = AED.PRD_CODE
          AND (AED.INACTIVE_FLAG = 0
          OR AED.INACTIVE_FLAG IS NULL)
          AND AED.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AED.EMP_CODE
        LEFT OUTER JOIN
        --EMPLOYEE AS EMPD ON EMPD.EMP_CODE = AED.EMP_CODE LEFT OUTER JOIN 
        JOB_LOG JL
          ON JL.JOB_NUMBER = JC.JOB_NUMBER
        LEFT OUTER JOIN CAMPAIGN AS CAMP
          ON CAMP.CMP_IDENTIFIER = AR.CMP_IDENTIFIER
        LEFT OUTER JOIN FUNCTIONS AS F
          ON F.FNC_CODE = AR.FNC_CODE
        LEFT OUTER JOIN FNC_HEADING AS FH
          ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
        LEFT OUTER JOIN FUNCTIONS AS CF
          ON CF.FNC_CODE = F.FNC_CONSOLIDATION
        LEFT OUTER JOIN V_MEDIA_HDR MH
          ON MH.ORDER_NBR = AR.ORDER_NBR
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        LEFT OUTER JOIN JOB_TYPE JT
          ON JT.JT_CODE = JC.JT_CODE
        LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
          ON JUDV1.UDV_CODE = JL.UDV1_CODE
        LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
          ON JUDV2.UDV_CODE = JL.UDV2_CODE
        LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
          ON JUDV3.UDV_CODE = JL.UDV3_CODE
        LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
          ON JUDV4.UDV_CODE = JL.UDV4_CODE
        LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
          ON JUDV5.UDV_CODE = JL.UDV5_CODE
        LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
          ON JCUDV1.UDV_CODE = JC.UDV1_CODE
        LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
          ON JCUDV2.UDV_CODE = JC.UDV2_CODE
        LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
          ON JCUDV3.UDV_CODE = JC.UDV3_CODE
        LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
          ON JCUDV4.UDV_CODE = JC.UDV4_CODE
        LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
          ON JCUDV5.UDV_CODE = JC.UDV5_CODE
        WHERE AR.SALE_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod
        AND (AR.AR_INV_SEQ IN (0, 99))
        AND AR.CL_CODE NOT IN (SELECT DISTINCT
          CL_CODE
        FROM AGENCY_CLIENTS)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   C.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (AR.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))		
    END
    ELSE
    BEGIN
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(AR.OFFICE_CODE, ''),
          ISNULL(O.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(C.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(D.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(P.PRD_DESCRIPTION, ''),
          CASE
            WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 'M'
            ELSE 'P'
          END,
          ISNULL(AR.SC_CODE, ''),
          ISNULL(SC_DESCRIPTION, ''),
          ISNULL(AR.CMP_IDENTIFIER, ''),
          ISNULL(CAMP.CMP_CODE, ''),
          ISNULL(CAMP.CMP_NAME, ''),
          AR.SALE_POST_PERIOD,
          SUBSTRING(AR.SALE_POST_PERIOD, 1, 4),
          SUBSTRING(AR.SALE_POST_PERIOD, 5, 2),
          (SELECT
            PPGLYEAR
          FROM POSTPERIOD PP
          WHERE PP.PPPERIOD = AR.SALE_POST_PERIOD)
          AS [YEAR],
          CASE
            WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AED.EMP_CODE, '')
            ELSE ISNULL(JC.EMP_CODE, '')
          END,
          NULL,
          --CASE WHEN ISNULL(AR.MEDIA_TYPE,'P') <> 'P' THEN COALESCE((RTRIM(EMPD.EMP_FNAME)+' '),'')+COALESCE((EMPD.EMP_MI+'. '),'')+COALESCE(EMPD.EMP_LNAME,'') ELSE COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,'') END,
          ISNULL(P.USER_DEFINED1, ''),
          ISNULL(P.USER_DEFINED2, ''),
          ISNULL(P.USER_DEFINED3, ''),
          ISNULL(P.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          AR.JOB_NUMBER,
          JL.JOB_DESC,
          AR.JOB_COMPONENT_NBR,
          JC.JOB_COMP_DESC,
          CASE
            WHEN AR.JOB_NUMBER IS NOT NULL THEN CASE
                WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                ELSE 'Open'
              END
          END,
          ISNULL(JC.JT_CODE, ''),
          ISNULL(JT.JT_DESC, ''),
          ISNULL(JL.FORMAT_CODE, ''),
          ISNULL(JL.COMPLEX_CODE, ''),
          ISNULL(JL.PROMO_CODE, ''),
          ISNULL(JL.JOB_CLI_REF, ''),
          ISNULL(JC.JOB_CL_PO_NBR, ''),
          ISNULL(JC.EMP_CODE, ''),
          NULL,
          ISNULL(JUDV1.UDV_DESC, ''),
          ISNULL(JUDV2.UDV_DESC, ''),
          ISNULL(JUDV3.UDV_DESC, ''),
          ISNULL(JUDV4.UDV_DESC, ''),
          ISNULL(JUDV5.UDV_DESC, ''),
          ISNULL(JCUDV1.UDV_DESC, ''),
          ISNULL(JCUDV2.UDV_DESC, ''),
          ISNULL(JCUDV3.UDV_DESC, ''),
          ISNULL(JCUDV4.UDV_DESC, ''),
          ISNULL(JCUDV5.UDV_DESC, ''),
          AR.FNC_CODE,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN AR.FNC_CODE
            ELSE CF.FNC_CODE
          END,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
            ELSE CF.FNC_DESCRIPTION
          END,
          F.FNC_DESCRIPTION,
          FH.FNC_HEADING_DESC,
          AR.FNC_TYPE,
          AR.ORDER_NBR,
          MH.ORDER_DESC,
          AR.ORDER_LINE_NBR,
          AR.MEDIA_MONTH,
          AR.MEDIA_YEAR,
          AR.[START_DATE],
          AR.END_DATE,
          CASE
            WHEN AR.MARKET_CODE IS NOT NULL THEN AR.MARKET_CODE
            ELSE JC.MARKET_CODE
          END,
          NULL,
          AR.GL_ACCT_SALE,
          NULL,
          AR.GL_ACCT_COS,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          CASE
            WHEN AR.FNC_TYPE = 'E' THEN CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE ISNULL(AR.HRS_QTY, 0)
              END
          END AS BILLED_HOURS,
          CASE
            WHEN AR.FNC_TYPE = 'V' OR
              AR.FNC_TYPE = 'I' THEN CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE ISNULL(AR.HRS_QTY, 0)
              END
          END AS BILLED_QUANTITY,
          CASE
            WHEN AR.FNC_TYPE = 'I' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.INC_ONLY_AMT, 0) + ISNULL(AR.AB_INC_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.INC_ONLY_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0) + ISNULL(AR.ADDITIONAL_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.ADDITIONAL_AMT, 0)
                ELSE 0
              END
          END AS BILLED_FEE_IO,
          CASE
            WHEN AR.FNC_TYPE = 'E' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.EMP_TIME_AMT, 0) + ISNULL(AR.AB_INC_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.EMP_TIME_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN 0
                ELSE 0
              END
          END AS BILLED_TIME,
          CASE
            WHEN AR.FNC_TYPE = 'V' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.AB_COMMISSION_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
                ELSE ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.REBATE_AMT, 0) + ISNULL(AR.AB_SALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.COMMISSION_AMT, 0) + ISNULL(AR.REBATE_AMT, 0)
                ELSE 0
              END
          END AS BILLED_COMMISSION,
          CASE
            WHEN AR.FNC_TYPE = 'V' THEN CASE
                WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COST_AMT, 0) + ISNULL(AR.AB_COST_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
                ELSE ISNULL(AR.COST_AMT, 0) + ISNULL(AR.NET_CHARGE_AMT, 0) + ISNULL(AR.DISCOUNT_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
              END
            ELSE CASE
                WHEN ISNULL(AR.MEDIA_TYPE, 'P') <> 'P' THEN ISNULL(AR.COST_AMT, 0) + ISNULL(AR.NET_CHARGE_AMT, 0) + ISNULL(AR.DISCOUNT_AMT, 0) + ISNULL(AR.NON_RESALE_AMT, 0)
                ELSE 0
              END
          END AS BILLED_COST,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'I' THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END AS BILLED_FEE_IO,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'E' THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_TIME,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END AS BILLED_COMMISSION,
          --CASE WHEN AR.AB_REC_FLAG = 2 AND AR.FNC_TYPE = 'V' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END AS BILLED_COST,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM AR_SUMMARY AR
        INNER JOIN PRODUCT P
          ON P.PRD_CODE = AR.PRD_CODE
          AND P.DIV_CODE = AR.DIV_CODE
          AND P.CL_CODE = AR.CL_CODE
        INNER JOIN DIVISION D
          ON D.DIV_CODE = P.DIV_CODE
          AND D.CL_CODE = P.CL_CODE
        INNER JOIN CLIENT C
          ON C.CL_CODE = D.CL_CODE
        INNER JOIN OFFICE O
          ON O.OFFICE_CODE = AR.OFFICE_CODE
        INNER JOIN SALES_CLASS SC
          ON SC.SC_CODE = AR.SC_CODE
        LEFT OUTER JOIN JOB_COMPONENT JC
          ON AR.JOB_NUMBER = JC.JOB_NUMBER
          AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
        LEFT OUTER JOIN
        --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JC.EMP_CODE
        --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN 
        ACCOUNT_EXECUTIVE AED
          ON P.CL_CODE = AED.CL_CODE
          AND P.DIV_CODE = AED.DIV_CODE
          AND P.PRD_CODE = AED.PRD_CODE
          AND (AED.INACTIVE_FLAG = 0
          OR AED.INACTIVE_FLAG IS NULL)
          AND AED.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AED.EMP_CODE
        LEFT OUTER JOIN
        --EMPLOYEE AS EMPD ON EMPD.EMP_CODE = AED.EMP_CODE LEFT OUTER JOIN 
        JOB_LOG JL
          ON JL.JOB_NUMBER = JC.JOB_NUMBER
        LEFT OUTER JOIN CAMPAIGN AS CAMP
          ON CAMP.CMP_IDENTIFIER = AR.CMP_IDENTIFIER
        LEFT OUTER JOIN FUNCTIONS AS F
          ON F.FNC_CODE = AR.FNC_CODE
        LEFT OUTER JOIN FNC_HEADING AS FH
          ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
        LEFT OUTER JOIN FUNCTIONS AS CF
          ON CF.FNC_CODE = F.FNC_CONSOLIDATION
        LEFT OUTER JOIN V_MEDIA_HDR MH
          ON MH.ORDER_NBR = AR.ORDER_NBR
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        LEFT OUTER JOIN JOB_TYPE JT
          ON JT.JT_CODE = JC.JT_CODE
        LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
          ON JUDV1.UDV_CODE = JL.UDV1_CODE
        LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
          ON JUDV2.UDV_CODE = JL.UDV2_CODE
        LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
          ON JUDV3.UDV_CODE = JL.UDV3_CODE
        LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
          ON JUDV4.UDV_CODE = JL.UDV4_CODE
        LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
          ON JUDV5.UDV_CODE = JL.UDV5_CODE
        LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
          ON JCUDV1.UDV_CODE = JC.UDV1_CODE
        LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
          ON JCUDV2.UDV_CODE = JC.UDV2_CODE
        LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
          ON JCUDV3.UDV_CODE = JC.UDV3_CODE
        LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
          ON JCUDV4.UDV_CODE = JC.UDV4_CODE
        LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
          ON JCUDV5.UDV_CODE = JC.UDV5_CODE
        WHERE AR.SALE_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod
        AND (AR.AR_INV_SEQ <> 99
        OR AR.AR_INV_SEQ NOT IN (0, 99))
        AND AR.CL_CODE NOT IN (SELECT DISTINCT
          CL_CODE
        FROM AGENCY_CLIENTS)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   C.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (AR.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))		
    END

    --Emp time hours and direct service cost
    --SELECT '#GROSS_INCOME_CPL'

    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(JOB_LOG.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(JOB_LOG.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(JOB_LOG.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(JOB_LOG.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P' AS TYPE,
        ISNULL(JOB_LOG.SC_CODE, ''),
        ISNULL(SC_DESCRIPTION, ''),
        ISNULL(JOB_LOG.CMP_IDENTIFIER, ''),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        (SELECT
			  PPPERIOD
			FROM POSTPERIOD PP
			WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE
			AND PPGLMONTH <> 99),
        SUBSTRING((SELECT
			  PPPERIOD
			FROM POSTPERIOD PP
			WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE
			AND PPGLMONTH <> 99), 1, 4),
        SUBSTRING((SELECT
			  PPPERIOD
			FROM POSTPERIOD PP
			WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE
			AND PPGLMONTH <> 99), 5, 2),
        (SELECT
			  PPGLYEAR
			FROM POSTPERIOD PP
			WHERE HP.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE
			AND PPGLMONTH <> 99),
        ISNULL(JOB_COMPONENT.EMP_CODE, ''), --19
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        HP.JOB_NUMBER, --32
        JOB_LOG.JOB_DESC,
        HP.JOB_COMPONENT_NBR,
        JOB_COMPONENT.JOB_COMP_DESC,
        CASE
          WHEN HP.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JOB_COMPONENT.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(JOB_LOG.FORMAT_CODE, ''),
        ISNULL(JOB_LOG.COMPLEX_CODE, ''),
        ISNULL(JOB_LOG.PROMO_CODE, ''),
        ISNULL(JOB_LOG.JOB_CLI_REF, ''),
        ISNULL(JOB_COMPONENT.JOB_CL_PO_NBR, ''),
        ISNULL(JOB_COMPONENT.EMP_CODE, ''), --44
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        HP.FNC_CODE, --56
        CASE
          WHEN CF.FNC_CODE IS NULL THEN HP.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION, --59
        FH.FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL, --Order Nbr
        NULL, --Order Desc
        NULL, --Line Nbr
        NULL, --Media Month
        NULL, --Media Year
        NULL, --Start Date --67
        NULL, --End Date
        JOB_COMPONENT.MARKET_CODE,
        M.MARKET_DESC,
        HP.GLACODE_SALES,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL, --Direct Exp GL Acct Desc
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        SUM([HoursPosted]),
        SUM(DIrectServiceCost),
        SUM(TotalBill), --HP.EMP_DATE,
        0,
        0,
        0,
        0,
        0,
        0,
        SUM(FTE),
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM JOB_COMPONENT
      INNER JOIN (SELECT
        ETD.JOB_NUMBER,
        ETD.JOB_COMPONENT_NBR,
        ETD.FNC_CODE,
        [HoursPosted] = SUM(ETD.EMP_HOURS),
        CASE
          WHEN @Standard = 1 THEN ISNULL(SUM(ETD.TOTAL_COST), 0)
          ELSE ISNULL(SUM(ETD.ALT_COST_AMT), 0)
        END AS DIrectServiceCost,
        CASE
          WHEN @FTE > 0 THEN (ISNULL(SUM(ETD.EMP_HOURS), 0)) / (@FTE)
          ELSE 0
        END AS FTE,
        ET.EMP_DATE,
        ETD.GLACODE_SALES,
        SUM(TOTAL_BILL) AS TotalBill
      FROM [dbo].[EMP_TIME] AS ET
      INNER JOIN [dbo].[EMP_TIME_DTL] AS ETD
        ON ET.ET_ID = ETD.ET_ID
      WHERE ET.EMP_DATE BETWEEN @StartDate AND @EndDate --@StartDate AND @EndDate
      GROUP BY ETD.JOB_NUMBER,
               ETD.JOB_COMPONENT_NBR,
               ETD.FNC_CODE,
               ET.EMP_DATE,
               ETD.GLACODE_SALES) AS HP
        ON HP.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
        AND HP.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
      INNER JOIN JOB_LOG
        ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
      INNER JOIN PRODUCT P
        ON P.PRD_CODE = JOB_LOG.PRD_CODE
        AND P.DIV_CODE = JOB_LOG.DIV_CODE
        AND P.CL_CODE = JOB_LOG.CL_CODE
      INNER JOIN DIVISION D
        ON D.DIV_CODE = P.DIV_CODE
        AND D.CL_CODE = P.CL_CODE
      INNER JOIN CLIENT C
        ON C.CL_CODE = D.CL_CODE
      INNER JOIN OFFICE O
        ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE
      INNER JOIN SALES_CLASS SC
        ON SC.SC_CODE = JOB_LOG.SC_CODE
      LEFT OUTER JOIN
      --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JOB_COMPONENT.EMP_CODE
      --		AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JOB_COMPONENT.EMP_CODE
      LEFT OUTER JOIN CAMPAIGN AS CAMP
        ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER
      LEFT OUTER JOIN FUNCTIONS AS F
        ON F.FNC_CODE = HP.FNC_CODE
      LEFT OUTER JOIN FNC_HEADING AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN FUNCTIONS AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN MARKET AS M
        ON M.MARKET_CODE = JOB_COMPONENT.MARKET_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = JOB_LOG.PRD_CODE
        AND CP.DIV_CODE = JOB_LOG.DIV_CODE
        AND CP.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = JOB_LOG.PRD_CODE
        AND A.DIV_CODE = JOB_LOG.DIV_CODE
        AND A.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JOB_COMPONENT.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = JOB_LOG.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = JOB_LOG.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = JOB_LOG.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = JOB_LOG.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = JOB_LOG.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JOB_COMPONENT.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JOB_COMPONENT.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JOB_COMPONENT.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JOB_COMPONENT.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JOB_COMPONENT.UDV5_CODE
      WHERE JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT
        CL_CODE
      FROM AGENCY_CLIENTS)
      AND 1 =
             CASE
               WHEN @ExcludeNewBusiness = 1 AND
                 C.[NEW_BUSINESS] = 1 THEN 0
               ELSE 1
             END
      AND (JOB_LOG.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
      --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
      --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
      --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
      GROUP BY JOB_LOG.OFFICE_CODE,
               O.OFFICE_NAME,
               JOB_LOG.CL_CODE,
               C.CL_NAME,
               JOB_LOG.DIV_CODE,
               D.DIV_NAME,
               JOB_LOG.PRD_CODE,
               P.PRD_DESCRIPTION,
               JOB_LOG.SC_CODE,
               SC_DESCRIPTION,
               JOB_LOG.CMP_IDENTIFIER,
               CAMP.CMP_CODE,
               CAMP.CMP_NAME,
               HP.EMP_DATE,
               JOB_COMPONENT.EMP_CODE,
               EMP.EMP_FNAME,
               EMP.EMP_MI,
               EMP.EMP_LNAME,
               P.USER_DEFINED1,
               P.USER_DEFINED2,
               P.USER_DEFINED3,
               P.USER_DEFINED4,
               I.[DESCRIPTION],
               S.[DESCRIPTION],
               CP.REGION_CODE,
               R.REGION_DESC,
               CP.REVENUE,
               CP.NUM_EMPLOYEES,
               SO.[DESCRIPTION],
               HP.JOB_NUMBER,
               JOB_LOG.JOB_DESC,
               HP.JOB_COMPONENT_NBR,
               JOB_COMPONENT.JOB_COMP_DESC,
               CASE
                 WHEN HP.JOB_NUMBER IS NOT NULL THEN CASE
                     WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                     ELSE 'Open'
                   END
               END,
               JOB_COMPONENT.JT_CODE,
               JT.JT_DESC,
               JOB_LOG.FORMAT_CODE,
               JOB_LOG.COMPLEX_CODE,
               JOB_LOG.PROMO_CODE,
               JOB_LOG.JOB_CLI_REF,
               JOB_COMPONENT.JOB_CL_PO_NBR,
               JOB_COMPONENT.EMP_CODE,
               JUDV1.UDV_DESC,
               JUDV2.UDV_DESC,
               JUDV3.UDV_DESC,
               JUDV4.UDV_DESC,
               JUDV5.UDV_DESC,
               JCUDV1.UDV_DESC,
               JCUDV2.UDV_DESC,
               JCUDV3.UDV_DESC,
               JCUDV4.UDV_DESC,
               JCUDV5.UDV_DESC,
               HP.FNC_CODE,
               CF.FNC_DESCRIPTION,
               CF.FNC_CODE,
               F.FNC_DESCRIPTION,
               FH.FNC_HEADING_DESC,
               F.FNC_TYPE,
               JOB_COMPONENT.MARKET_CODE,
               M.MARKET_DESC,
               HP.GLACODE_SALES

    --Direct Expense (Nonbillable AP)
    --SELECT '#GROSS_INCOME_CPL'

    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(JOB_LOG.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(JOB_LOG.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(JOB_LOG.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(JOB_LOG.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P' AS TYPE,
        ISNULL(JOB_LOG.SC_CODE, ''),
        ISNULL(SC_DESCRIPTION, ''),
        ISNULL(JOB_LOG.CMP_IDENTIFIER, ''),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        AP_PRODUCTION.POST_PERIOD,
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4),
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2),
        (SELECT
          PPGLYEAR
        FROM POSTPERIOD PP
        WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD)
        AS [YEAR],
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        AP_PRODUCTION.JOB_NUMBER,
        JOB_LOG.JOB_DESC,
        AP_PRODUCTION.JOB_COMPONENT_NBR,
        JOB_COMPONENT.JOB_COMP_DESC,
        CASE
          WHEN AP_PRODUCTION.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JOB_COMPONENT.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(JOB_LOG.FORMAT_CODE, ''),
        ISNULL(JOB_LOG.COMPLEX_CODE, ''),
        ISNULL(JOB_LOG.PROMO_CODE, ''),
        ISNULL(JOB_LOG.JOB_CLI_REF, ''),
        ISNULL(JOB_COMPONENT.JOB_CL_PO_NBR, ''),
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        AP_PRODUCTION.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN AP_PRODUCTION.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FH.FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JOB_COMPONENT.MARKET_CODE,
        M.MARKET_DESC,
        AP_PRODUCTION.GLACODE_SALES,
        NULL,
        AP_PRODUCTION.GLACODE_COS,
        NULL,
        AP_PRODUCTION.GLACODE,
        NULL,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        ISNULL([AP_PROD_EXT_AMT], 0) + ISNULL([EXT_NONRESALE_TAX], 0) AS DirectExpense,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM AP_PRODUCTION
      INNER JOIN GLACCOUNT
        ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE
      INNER JOIN JOB_COMPONENT
        ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
        AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
      INNER JOIN JOB_LOG
        ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
      INNER JOIN PRODUCT P
        ON P.PRD_CODE = JOB_LOG.PRD_CODE
        AND P.DIV_CODE = JOB_LOG.DIV_CODE
        AND P.CL_CODE = JOB_LOG.CL_CODE
      INNER JOIN DIVISION D
        ON D.DIV_CODE = P.DIV_CODE
        AND D.CL_CODE = P.CL_CODE
      INNER JOIN CLIENT C
        ON C.CL_CODE = D.CL_CODE
      INNER JOIN OFFICE O
        ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE
      INNER JOIN SALES_CLASS SC
        ON SC.SC_CODE = JOB_LOG.SC_CODE
      LEFT OUTER JOIN
      --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JOB_COMPONENT.EMP_CODE
      --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JOB_COMPONENT.EMP_CODE
      LEFT OUTER JOIN CAMPAIGN AS CAMP
        ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER
      LEFT OUTER JOIN FUNCTIONS AS F
        ON F.FNC_CODE = AP_PRODUCTION.FNC_CODE
      LEFT OUTER JOIN FNC_HEADING AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN FUNCTIONS AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN MARKET AS M
        ON M.MARKET_CODE = JOB_COMPONENT.MARKET_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = JOB_LOG.PRD_CODE
        AND CP.DIV_CODE = JOB_LOG.DIV_CODE
        AND CP.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = JOB_LOG.PRD_CODE
        AND A.DIV_CODE = JOB_LOG.DIV_CODE
        AND A.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JOB_COMPONENT.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = JOB_LOG.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = JOB_LOG.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = JOB_LOG.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = JOB_LOG.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = JOB_LOG.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JOB_COMPONENT.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JOB_COMPONENT.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JOB_COMPONENT.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JOB_COMPONENT.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JOB_COMPONENT.UDV5_CODE
      WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod
      AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1
      AND 1 =
             CASE
               WHEN @DirectExpenseOperatingOnly = 1 AND
                 ((GLACCOUNT.GLATYPE) IN ('14')) THEN 1
               WHEN @DirectExpenseOperatingOnly = 0 AND
                 ((GLACCOUNT.GLATYPE) IN ('9', '14', '15')) THEN 1
               ELSE 0
             END
      AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT
        CL_CODE
      FROM AGENCY_CLIENTS)
      AND 1 =
             CASE
               WHEN @ExcludeNewBusiness = 1 AND
                 C.[NEW_BUSINESS] = 1 THEN 0
               ELSE 1
             END
      AND (JOB_LOG.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

    --Nonbillable AP Sales
    --SELECT '#GROSS_INCOME_CPL'

    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(JOB_LOG.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(JOB_LOG.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(JOB_LOG.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(JOB_LOG.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P' AS TYPE,
        ISNULL(JOB_LOG.SC_CODE, ''),
        ISNULL(SC_DESCRIPTION, ''),
        ISNULL(JOB_LOG.CMP_IDENTIFIER, ''),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        AP_PRODUCTION.POST_PERIOD,
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4),
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2),
        (SELECT
          PPGLYEAR
        FROM POSTPERIOD PP
        WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD)
        AS [YEAR],
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        AP_PRODUCTION.JOB_NUMBER,
        JOB_LOG.JOB_DESC,
        AP_PRODUCTION.JOB_COMPONENT_NBR,
        JOB_COMPONENT.JOB_COMP_DESC,
        CASE
          WHEN AP_PRODUCTION.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JOB_COMPONENT.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(JOB_LOG.FORMAT_CODE, ''),
        ISNULL(JOB_LOG.COMPLEX_CODE, ''),
        ISNULL(JOB_LOG.PROMO_CODE, ''),
        ISNULL(JOB_LOG.JOB_CLI_REF, ''),
        ISNULL(JOB_COMPONENT.JOB_CL_PO_NBR, ''),
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        AP_PRODUCTION.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN AP_PRODUCTION.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FH.FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JOB_COMPONENT.MARKET_CODE,
        M.MARKET_DESC,
        AP_PRODUCTION.GLACODE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        (ISNULL([AP_PROD_EXT_AMT], 0) + ISNULL([EXT_NONRESALE_TAX], 0)) * -1 AS NBSales,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM AP_PRODUCTION
      INNER JOIN GLACCOUNT
        ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE
      INNER JOIN JOB_COMPONENT
        ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
        AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
      INNER JOIN JOB_LOG
        ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
      INNER JOIN PRODUCT P
        ON P.PRD_CODE = JOB_LOG.PRD_CODE
        AND P.DIV_CODE = JOB_LOG.DIV_CODE
        AND P.CL_CODE = JOB_LOG.CL_CODE
      INNER JOIN DIVISION D
        ON D.DIV_CODE = P.DIV_CODE
        AND D.CL_CODE = P.CL_CODE
      INNER JOIN CLIENT C
        ON C.CL_CODE = D.CL_CODE
      INNER JOIN OFFICE O
        ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE
      INNER JOIN SALES_CLASS SC
        ON SC.SC_CODE = JOB_LOG.SC_CODE
      LEFT OUTER JOIN
      --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JOB_COMPONENT.EMP_CODE
      --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JOB_COMPONENT.EMP_CODE
      LEFT OUTER JOIN CAMPAIGN AS CAMP
        ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER
      LEFT OUTER JOIN FUNCTIONS AS F
        ON F.FNC_CODE = AP_PRODUCTION.FNC_CODE
      LEFT OUTER JOIN FNC_HEADING AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN FUNCTIONS AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN MARKET AS M
        ON M.MARKET_CODE = JOB_COMPONENT.MARKET_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = JOB_LOG.PRD_CODE
        AND CP.DIV_CODE = JOB_LOG.DIV_CODE
        AND CP.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = JOB_LOG.PRD_CODE
        AND A.DIV_CODE = JOB_LOG.DIV_CODE
        AND A.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JOB_COMPONENT.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = JOB_LOG.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = JOB_LOG.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = JOB_LOG.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = JOB_LOG.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = JOB_LOG.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JOB_COMPONENT.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JOB_COMPONENT.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JOB_COMPONENT.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JOB_COMPONENT.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JOB_COMPONENT.UDV5_CODE
      WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod
      AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1
      AND ((GLACCOUNT.GLATYPE) IN ('8'))
      AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT
        CL_CODE
      FROM AGENCY_CLIENTS)
      AND 1 =
             CASE
               WHEN @ExcludeNewBusiness = 1 AND
                 C.[NEW_BUSINESS] = 1 THEN 0
               ELSE 1
             END
      AND (JOB_LOG.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

    --Nonbillable AP Cost of Sales
    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(JOB_LOG.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(JOB_LOG.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(JOB_LOG.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(JOB_LOG.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P' AS TYPE,
        ISNULL(JOB_LOG.SC_CODE, ''),
        ISNULL(SC_DESCRIPTION, ''),
        ISNULL(JOB_LOG.CMP_IDENTIFIER, ''),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        AP_PRODUCTION.POST_PERIOD,
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 1, 4),
        SUBSTRING(AP_PRODUCTION.POST_PERIOD, 5, 2),
        (SELECT
          PPGLYEAR
        FROM POSTPERIOD PP
        WHERE PP.PPPERIOD = AP_PRODUCTION.POST_PERIOD)
        AS [YEAR],
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        AP_PRODUCTION.JOB_NUMBER,
        JOB_LOG.JOB_DESC,
        AP_PRODUCTION.JOB_COMPONENT_NBR,
        JOB_COMPONENT.JOB_COMP_DESC,
        CASE
          WHEN AP_PRODUCTION.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JOB_COMPONENT.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(JOB_LOG.FORMAT_CODE, ''),
        ISNULL(JOB_LOG.COMPLEX_CODE, ''),
        ISNULL(JOB_LOG.PROMO_CODE, ''),
        ISNULL(JOB_LOG.JOB_CLI_REF, ''),
        ISNULL(JOB_COMPONENT.JOB_CL_PO_NBR, ''),
        ISNULL(JOB_COMPONENT.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        AP_PRODUCTION.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN AP_PRODUCTION.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FH.FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JOB_COMPONENT.MARKET_CODE,
        M.MARKET_DESC,
        NULL,
        NULL,
        AP_PRODUCTION.GLACODE,
        NULL,
        NULL,
        NULL,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        ISNULL([AP_PROD_EXT_AMT], 0) + ISNULL([EXT_NONRESALE_TAX], 0) AS NBCostofSales,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM AP_PRODUCTION
      INNER JOIN GLACCOUNT
        ON AP_PRODUCTION.GLACODE = GLACCOUNT.GLACODE
      INNER JOIN JOB_COMPONENT
        ON AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
        AND AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
      INNER JOIN JOB_LOG
        ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
      INNER JOIN PRODUCT P
        ON P.PRD_CODE = JOB_LOG.PRD_CODE
        AND P.DIV_CODE = JOB_LOG.DIV_CODE
        AND P.CL_CODE = JOB_LOG.CL_CODE
      INNER JOIN DIVISION D
        ON D.DIV_CODE = P.DIV_CODE
        AND D.CL_CODE = P.CL_CODE
      INNER JOIN CLIENT C
        ON C.CL_CODE = D.CL_CODE
      INNER JOIN OFFICE O
        ON O.OFFICE_CODE = JOB_LOG.OFFICE_CODE
      INNER JOIN SALES_CLASS SC
        ON SC.SC_CODE = JOB_LOG.SC_CODE
      LEFT OUTER JOIN
      --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JOB_COMPONENT.EMP_CODE
      --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JOB_COMPONENT.EMP_CODE
      LEFT OUTER JOIN CAMPAIGN AS CAMP
        ON CAMP.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER
      LEFT OUTER JOIN FUNCTIONS AS F
        ON F.FNC_CODE = AP_PRODUCTION.FNC_CODE
      LEFT OUTER JOIN FNC_HEADING AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN FUNCTIONS AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN MARKET AS M
        ON M.MARKET_CODE = JOB_COMPONENT.MARKET_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = JOB_LOG.PRD_CODE
        AND CP.DIV_CODE = JOB_LOG.DIV_CODE
        AND CP.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = JOB_LOG.PRD_CODE
        AND A.DIV_CODE = JOB_LOG.DIV_CODE
        AND A.CL_CODE = JOB_LOG.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JOB_COMPONENT.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = JOB_LOG.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = JOB_LOG.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = JOB_LOG.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = JOB_LOG.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = JOB_LOG.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JOB_COMPONENT.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JOB_COMPONENT.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JOB_COMPONENT.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JOB_COMPONENT.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JOB_COMPONENT.UDV5_CODE
      WHERE AP_PRODUCTION.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod
      AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1
      AND ((GLACCOUNT.GLATYPE) IN ('13'))
      AND JOB_LOG.CL_CODE NOT IN (SELECT DISTINCT
        CL_CODE
      FROM AGENCY_CLIENTS)
      AND 1 =
             CASE
               WHEN @ExcludeNewBusiness = 1 AND
                 C.[NEW_BUSINESS] = 1 THEN 0
               ELSE 1
             END
      AND (JOB_LOG.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND JOB_LOG.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND JOB_LOG.CL_CODE + '|' + JOB_LOG.DIV_CODE + '|' + JOB_LOG.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))



    --Actuals
    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(AA.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(AA.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(AA.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(AA.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        ISNULL(AA.ACTUALS_TYPE, 'P'),
        ISNULL(AA.SC_CODE, ''),
        ISNULL(SC_DESCRIPTION, ''),
        ISNULL(JL.CMP_IDENTIFIER, ''),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        AA.PPERIOD,
        SUBSTRING(AA.PPERIOD, 1, 4),
        SUBSTRING(AA.PPERIOD, 5, 2),
        (SELECT
          PPGLYEAR
        FROM POSTPERIOD PP
        WHERE PP.PPPERIOD = AA.PPERIOD)
        AS [YEAR],
        ISNULL(JC.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        AA.JOB_NUMBER,
        JL.JOB_DESC,
        AA.JOB_COMPONENT_NBR,
        JC.JOB_COMP_DESC,
        CASE
          WHEN AA.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JC.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(JL.FORMAT_CODE, ''),
        ISNULL(JL.COMPLEX_CODE, ''),
        ISNULL(JL.PROMO_CODE, ''),
        ISNULL(JL.JOB_CLI_REF, ''),
        ISNULL(JC.JOB_CL_PO_NBR, ''),
        ISNULL(JC.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        AA.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN AA.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FH.FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JC.MARKET_CODE,
        M.MARKET_DESC,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        CASE
          WHEN CATEGORY_CODE = 'fee' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastFee,
        CASE
          WHEN CATEGORY_CODE = 'lab' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastTime,
        CASE
          WHEN CATEGORY_CODE = 'com' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastCommission,
        CASE
          WHEN CATEGORY_CODE = 'cos' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastCostOfSales,
        CASE
          WHEN CATEGORY_CODE = 'dsc' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastDirectServiceCost,
        CASE
          WHEN CATEGORY_CODE = 'de' THEN ISNULL(SUM(AA.AMOUNT), 0)
          ELSE 0
        END AS ForecastDirectExpense,
        0,
        0
      FROM ACTUALS_ACC AA
      INNER JOIN PRODUCT P
        ON P.PRD_CODE = AA.PRD_CODE
        AND P.DIV_CODE = AA.DIV_CODE
        AND P.CL_CODE = AA.CL_CODE
      INNER JOIN DIVISION D
        ON D.DIV_CODE = P.DIV_CODE
        AND D.CL_CODE = P.CL_CODE
      INNER JOIN CLIENT C
        ON C.CL_CODE = D.CL_CODE
      INNER JOIN OFFICE O
        ON O.OFFICE_CODE = AA.OFFICE_CODE
      INNER JOIN SALES_CLASS SC
        ON SC.SC_CODE = AA.SC_CODE
      LEFT OUTER JOIN JOB_COMPONENT JC
        ON AA.JOB_NUMBER = JC.JOB_NUMBER
        AND AA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
      LEFT OUTER JOIN
      --ACCOUNT_EXECUTIVE AE ON AE.EMP_CODE = JC.EMP_CODE
      --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JC.EMP_CODE
      LEFT OUTER JOIN JOB_LOG JL
        ON JL.JOB_NUMBER = JC.JOB_NUMBER
      LEFT OUTER JOIN CAMPAIGN AS CAMP
        ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER
      LEFT OUTER JOIN FUNCTIONS AS F
        ON F.FNC_CODE = AA.FNC_CODE
      LEFT OUTER JOIN FNC_HEADING AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN FUNCTIONS AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN MARKET AS M
        ON M.MARKET_CODE = JC.MARKET_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = AA.PRD_CODE
        AND CP.DIV_CODE = AA.DIV_CODE
        AND CP.CL_CODE = AA.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = AA.PRD_CODE
        AND A.DIV_CODE = AA.DIV_CODE
        AND A.CL_CODE = AA.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JC.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = JL.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = JL.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = JL.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = JL.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = JL.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JC.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JC.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JC.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JC.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JC.UDV5_CODE
      WHERE (AA.PPERIOD BETWEEN @StartPeriod AND @EndPeriod)
      AND (ACTUAL_GRP IN (0))
      AND AA.CL_CODE NOT IN (SELECT DISTINCT
        CL_CODE
      FROM AGENCY_CLIENTS)
      AND 1 =
             CASE
               WHEN @ExcludeNewBusiness = 1 AND
                 C.[NEW_BUSINESS] = 1 THEN 0
               ELSE 1
             END
      AND (AA.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
      --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AA.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
      --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AA.CL_CODE + '|' + AA.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
      --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AA.CL_CODE + '|' + AA.DIV_CODE + '|' + AA.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
      GROUP BY AA.OFFICE_CODE,
               O.OFFICE_NAME,
               AA.CL_CODE,
               C.CL_NAME,
               AA.DIV_CODE,
               D.DIV_NAME,
               AA.PRD_CODE,
               P.PRD_DESCRIPTION,
               AA.ACTUALS_TYPE,
               AA.SC_CODE,
               SC_DESCRIPTION,
               JL.CMP_IDENTIFIER,
               CAMP.CMP_CODE,
               CAMP.CMP_NAME,
               AA.PPERIOD,
               CATEGORY_CODE,
               JC.EMP_CODE,
               EMP.EMP_FNAME,
               EMP.EMP_MI,
               EMP.EMP_LNAME,
               P.USER_DEFINED1,
               P.USER_DEFINED2,
               P.USER_DEFINED3,
               P.USER_DEFINED4,
               I.[DESCRIPTION],
               S.[DESCRIPTION],
               CP.REGION_CODE,
               R.REGION_DESC,
               CP.REVENUE,
               CP.NUM_EMPLOYEES,
               SO.[DESCRIPTION],
               AA.JOB_NUMBER,
               JL.JOB_DESC,
               AA.JOB_COMPONENT_NBR,
               JC.JOB_COMP_DESC,
               CASE
                 WHEN AA.JOB_NUMBER IS NOT NULL THEN CASE
                     WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                     ELSE 'Open'
                   END
               END,
               JC.JT_CODE,
               JT.JT_DESC,
               JL.FORMAT_CODE,
               JL.COMPLEX_CODE,
               JL.PROMO_CODE,
               JL.JOB_CLI_REF,
               JC.JOB_CL_PO_NBR,
               JC.EMP_CODE,
               JUDV1.UDV_DESC,
               JUDV2.UDV_DESC,
               JUDV3.UDV_DESC,
               JUDV4.UDV_DESC,
               JUDV5.UDV_DESC,
               JCUDV1.UDV_DESC,
               JCUDV2.UDV_DESC,
               JCUDV3.UDV_DESC,
               JCUDV4.UDV_DESC,
               JCUDV5.UDV_DESC,
               AA.FNC_CODE,
               CF.FNC_DESCRIPTION,
               CF.FNC_CODE,
               F.FNC_DESCRIPTION,
               FH.FNC_HEADING_DESC,
               F.FNC_TYPE,
               JC.MARKET_CODE,
               M.MARKET_DESC

    --Manual Invoices
    IF @IncludeManualInvoices = 1
    BEGIN
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(ACCT_REC.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(ACCT_REC.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(ACCT_REC.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(ACCT_REC.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          CASE
            WHEN [REC_TYPE] = 'M' THEN 'M'
            ELSE 'P'
          END,
          ISNULL(ACCT_REC.SC_CODE, ''),
          ISNULL(SALES_CLASS.SC_DESCRIPTION, ''),
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          ACCT_REC.AR_POST_PERIOD,
          SUBSTRING(ACCT_REC.AR_POST_PERIOD, 1, 4),
          SUBSTRING(ACCT_REC.AR_POST_PERIOD, 5, 2),
          POSTPERIOD.PPGLYEAR,
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          ACCT_REC.GLACODE_SALES,
          NULL,
          ACCT_REC.GLACODE_COS,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM([AR_INV_AMOUNT] - (ISNULL([AR_STATE_AMT], 0) + ISNULL([AR_COUNTY_AMT], 0) + ISNULL([AR_CITY_AMT], 0))) AS ManualSale,
          --CASE WHEN SUM([AR_INV_AMOUNT]) = 0 THEN CASE WHEN SUM([AR_SALE_AMT]) IS NULL THEN 0 ELSE SUM([AR_SALE_AMT]) END ELSE SUM([AR_INV_AMOUNT]-(ISNULL([AR_STATE_AMT],0)+ISNULL([AR_COUNTY_AMT],0)+ISNULL([AR_CITY_AMT],0))) END AS ManualSale,
          --Sum(IIf([AR_INV_AMOUNT]=0,IIf([AR_SALE_AMT] Is Null,0,[AR_SALE_AMT]),[AR_INV_AMOUNT]-(Nz([AR_STATE_AMT],0)+Nz([AR_COUNTY_AMT],0)+Nz([AR_CITY_AMT],0)))) AS ManualSale, 
          SUM(ISNULL([AR_COS_AMT], 0)) AS ManualCOS,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM ACCT_REC
        INNER JOIN OFFICE
          ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT JOIN SALES_CLASS
          ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE
        INNER JOIN POSTPERIOD
          ON ACCT_REC.AR_POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN CLIENT
          ON ACCT_REC.CL_CODE = CLIENT.CL_CODE
        LEFT OUTER JOIN DIVISION
          ON (ACCT_REC.DIV_CODE = DIVISION.DIV_CODE)
          AND (ACCT_REC.CL_CODE = DIVISION.CL_CODE)
        LEFT OUTER JOIN PRODUCT
          ON (ACCT_REC.PRD_CODE = PRODUCT.PRD_CODE)
          AND (ACCT_REC.DIV_CODE = PRODUCT.DIV_CODE)
          AND (ACCT_REC.CL_CODE = PRODUCT.CL_CODE)
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = ACCT_REC.PRD_CODE
          AND CP.DIV_CODE = ACCT_REC.DIV_CODE
          AND CP.CL_CODE = ACCT_REC.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = ACCT_REC.PRD_CODE
          AND A.DIV_CODE = ACCT_REC.DIV_CODE
          AND A.CL_CODE = ACCT_REC.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (ACCT_REC.AR_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND (ACCT_REC.MANUAL_INV = 1)
        AND ACCT_REC.CL_CODE NOT IN (SELECT DISTINCT
          CL_CODE
        FROM AGENCY_CLIENTS)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (ACCT_REC.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ACCT_REC.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ACCT_REC.CL_CODE + '|' + ACCT_REC.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ACCT_REC.CL_CODE + '|' + ACCT_REC.DIV_CODE + '|' + ACCT_REC.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY ACCT_REC.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 ACCT_REC.CL_CODE,
                 CLIENT.CL_NAME,
                 ACCT_REC.DIV_CODE,
                 DIVISION.DIV_NAME,
                 ACCT_REC.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CASE
                   WHEN [REC_TYPE] = 'M' THEN 'M'
                   ELSE 'P'
                 END,
                 ACCT_REC.SC_CODE,
                 SALES_CLASS.SC_DESCRIPTION,
                 ACCT_REC.AR_POST_PERIOD,
                 POSTPERIOD.PPGLYEAR,
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 ACCT_REC.GLACODE_SALES,
                 ACCT_REC.GLACODE_COS
    END

    --SELECT '#GROSS_INCOME_CPL'

    --GL Entries
    IF @IncludeGLEntries = 1
    BEGIN
      --GL Entry Sales
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(GLENTTRL.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(GLENTTRL.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(GLENTTRL.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'G' AS Type,
          ISNULL(GLENTTRL.GLETSOURCE, ''),
          ISNULL(GLSOURCE.GLSRDESC, ''),
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          GLENTHDR.GLEHPP,
          SUBSTRING(GLENTHDR.GLEHPP, 1, 4),
          SUBSTRING(GLENTHDR.GLEHPP, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          GLENTTRL.GLETCODE,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM([GLETAMT] * -1) AS [GL Entry Sales],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM GLENTTRL
        INNER JOIN GLENTHDR
          ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT
        INNER JOIN GLACCOUNT
          ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD
        INNER JOIN GLSOURCE
          ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE
        LEFT JOIN AGENCY_CLIENTS
          ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON GLENTTRL.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE)
          AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE)
          AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE)
          AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = GLENTTRL.PRD_CODE
          AND CP.DIV_CODE = GLENTTRL.DIV_CODE
          AND CP.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = GLENTTRL.PRD_CODE
          AND A.DIV_CODE = GLENTTRL.DIV_CODE
          AND A.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLENTTRL.GLETSOURCE) IN ('JE', 'RJ', 'IJ', 'BD', 'BV'))
        AND ((GLACCOUNT.GLATYPE) IN ('8'))
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)
        AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod))
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 GLENTTRL.CL_CODE,
                 CLIENT.CL_NAME,
                 GLENTTRL.DIV_CODE,
                 DIVISION.DIV_NAME,
                 GLENTTRL.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 GLENTTRL.GLETSOURCE,
                 GLSOURCE.GLSRDESC,
                 GLENTHDR.GLEHPP,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 GLENTTRL.GLETCODE,
                 GLACCOUNT.GLADESC

      --GL Entry Cost of Sales 
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(GLENTTRL.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(GLENTTRL.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(GLENTTRL.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'G' AS Type,
          ISNULL(GLENTTRL.GLETSOURCE, ''),
          ISNULL(GLSOURCE.GLSRDESC, ''),
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          GLENTHDR.GLEHPP,
          SUBSTRING(GLENTHDR.GLEHPP, 1, 4),
          SUBSTRING(GLENTHDR.GLEHPP, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          GLENTTRL.GLETCODE,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(GLENTTRL.GLETAMT) AS [GL Entry Cost],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM GLENTTRL
        INNER JOIN GLENTHDR
          ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT
        INNER JOIN GLACCOUNT
          ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD
        INNER JOIN GLSOURCE
          ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE
        LEFT JOIN AGENCY_CLIENTS
          ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON GLENTTRL.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE)
          AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE)
          AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE)
          AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = GLENTTRL.PRD_CODE
          AND CP.DIV_CODE = GLENTTRL.DIV_CODE
          AND CP.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = GLENTTRL.PRD_CODE
          AND A.DIV_CODE = GLENTTRL.DIV_CODE
          AND A.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLENTTRL.GLETSOURCE) IN ('JE', 'BD', 'RJ', 'BV', 'IJ', 'OR'))
        AND ((GLACCOUNT.GLATYPE) = '13')
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL))
        AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 GLENTTRL.CL_CODE,
                 CLIENT.CL_NAME,
                 GLENTTRL.DIV_CODE,
                 DIVISION.DIV_NAME,
                 GLENTTRL.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 GLENTTRL.GLETSOURCE,
                 GLSOURCE.GLSRDESC,
                 GLENTHDR.GLEHPP,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 GLENTTRL.GLETCODE,
                 GLACCOUNT.GLADESC

      --GL Entry Direct Expense 
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(GLENTTRL.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(GLENTTRL.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(GLENTTRL.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'G' AS Type,
          ISNULL(GLENTTRL.GLETSOURCE, ''),
          ISNULL(GLSOURCE.GLSRDESC, ''),
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          GLENTHDR.GLEHPP,
          SUBSTRING(GLENTHDR.GLEHPP, 1, 4),
          SUBSTRING(GLENTHDR.GLEHPP, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          'GL',
          NULL,
          NULL,
          'GL Entry',
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          GLENTTRL.GLETCODE,
          GLACCOUNT.GLADESC,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(GLENTTRL.GLETAMT) AS [GL Entry Direct Expense],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM GLENTTRL
        INNER JOIN GLENTHDR
          ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT
        INNER JOIN GLACCOUNT
          ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD
        INNER JOIN GLSOURCE
          ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE
        LEFT JOIN AGENCY_CLIENTS
          ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON GLENTTRL.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE)
          AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE)
          AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE)
          AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = GLENTTRL.PRD_CODE
          AND CP.DIV_CODE = GLENTTRL.DIV_CODE
          AND CP.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = GLENTTRL.PRD_CODE
          AND A.DIV_CODE = GLENTTRL.DIV_CODE
          AND A.CL_CODE = GLENTTRL.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLENTTRL.GLETSOURCE) IN ('JE', 'RJ', 'IJ'))
        AND 1 =
               CASE
                 WHEN @DirectExpenseOperatingOnly = 1 AND
                   ((GLACCOUNT.GLATYPE) IN ('14')) THEN 1
                 WHEN @DirectExpenseOperatingOnly = 0 AND
                   ((GLACCOUNT.GLATYPE) IN ('9', '14', '15')) THEN 1
                 ELSE 0
               END
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL))
        AND (GLENTHDR.GLEHPP BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND GLENTTRL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND GLENTTRL.CL_CODE + '|' + GLENTTRL.DIV_CODE + '|' + GLENTTRL.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 GLENTTRL.CL_CODE,
                 CLIENT.CL_NAME,
                 GLENTTRL.DIV_CODE,
                 DIVISION.DIV_NAME,
                 GLENTTRL.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 GLENTTRL.GLETSOURCE,
                 GLSOURCE.GLSRDESC,
                 GLENTHDR.GLEHPP,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 GLENTTRL.GLETCODE,
                 GLACCOUNT.GLADESC
    END

    --Billed Income Rec
    IF @IncludeBilledIncomeRec = 1
    BEGIN
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(AR_SUMMARY.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR_SUMMARY.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR_SUMMARY.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR_SUMMARY.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          ISNULL([MEDIA_TYPE], 'P'),
          ISNULL(AR_SUMMARY.SC_CODE, ''),
          ISNULL(SALES_CLASS.SC_DESCRIPTION, ''),
          ISNULL(AR_SUMMARY.CMP_IDENTIFIER, 0),
          ISNULL(CAMPAIGN.CMP_CODE, ''),
          ISNULL(CAMPAIGN.CMP_NAME, ''),
          AR_SUMMARY.SALE_POST_PERIOD,
          SUBSTRING(AR_SUMMARY.SALE_POST_PERIOD, 1, 4),
          SUBSTRING(AR_SUMMARY.SALE_POST_PERIOD, 5, 2),
          POSTPERIOD.PPGLYEAR,
          ISNULL(JC.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          AR_SUMMARY.JOB_NUMBER,
          JL.JOB_DESC,
          AR_SUMMARY.JOB_COMPONENT_NBR,
          JC.JOB_COMP_DESC,
          CASE
            WHEN AR_SUMMARY.JOB_NUMBER IS NOT NULL THEN CASE
                WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                ELSE 'Open'
              END
          END,
          ISNULL(JC.JT_CODE, ''),
          ISNULL(JT.JT_DESC, ''),
          ISNULL(JL.FORMAT_CODE, ''),
          ISNULL(JL.COMPLEX_CODE, ''),
          ISNULL(JL.PROMO_CODE, ''),
          ISNULL(JL.JOB_CLI_REF, ''),
          ISNULL(JC.JOB_CL_PO_NBR, ''),
          ISNULL(JC.EMP_CODE, ''),
          NULL,
          ISNULL(JUDV1.UDV_DESC, ''),
          ISNULL(JUDV2.UDV_DESC, ''),
          ISNULL(JUDV3.UDV_DESC, ''),
          ISNULL(JUDV4.UDV_DESC, ''),
          ISNULL(JUDV5.UDV_DESC, ''),
          ISNULL(JCUDV1.UDV_DESC, ''),
          ISNULL(JCUDV2.UDV_DESC, ''),
          ISNULL(JCUDV3.UDV_DESC, ''),
          ISNULL(JCUDV4.UDV_DESC, ''),
          ISNULL(JCUDV5.UDV_DESC, ''),
          AR_SUMMARY.FNC_CODE,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN AR_SUMMARY.FNC_CODE
            ELSE CF.FNC_CODE
          END,
          CASE
            WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
            ELSE CF.FNC_DESCRIPTION
          END,
          F.FNC_DESCRIPTION,
          FH.FNC_HEADING_DESC,
          AR_SUMMARY.FNC_TYPE,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          JC.MARKET_CODE,
          M.MARKET_DESC,
          AR_SUMMARY.GL_ACCT_SALE,
          NULL,
          AR_SUMMARY.GL_ACCT_COS,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(ISNULL([AB_SALE_AMT], 0)) AS BilledIncomeRec,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM AR_SUMMARY
        INNER JOIN OFFICE
          ON AR_SUMMARY.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT JOIN AGENCY_CLIENTS
          ON AR_SUMMARY.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN POSTPERIOD
          ON AR_SUMMARY.SALE_POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT JOIN SALES_CLASS
          ON AR_SUMMARY.SC_CODE = SALES_CLASS.SC_CODE
        LEFT JOIN CAMPAIGN
          ON AR_SUMMARY.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER
        INNER JOIN CLIENT
          ON AR_SUMMARY.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR_SUMMARY.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR_SUMMARY.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR_SUMMARY.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR_SUMMARY.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR_SUMMARY.CL_CODE = PRODUCT.CL_CODE)
        LEFT OUTER JOIN JOB_COMPONENT JC
          ON AR_SUMMARY.JOB_NUMBER = JC.JOB_NUMBER
          AND AR_SUMMARY.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
        LEFT OUTER JOIN JOB_LOG JL
          ON JL.JOB_NUMBER = JC.JOB_NUMBER
        LEFT OUTER JOIN MARKET AS M
          ON M.MARKET_CODE = JC.MARKET_CODE
        LEFT OUTER JOIN
        --ACCOUNT_EXECUTIVE AE ON JC.EMP_CODE = AE.EMP_CODE
        --	AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
        EMPLOYEE AS EMP
          ON EMP.EMP_CODE = JC.EMP_CODE
        LEFT OUTER JOIN FUNCTIONS AS F
          ON F.FNC_CODE = AR_SUMMARY.FNC_CODE
        LEFT OUTER JOIN FNC_HEADING AS FH
          ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
        LEFT OUTER JOIN FUNCTIONS AS CF
          ON CF.FNC_CODE = F.FNC_CONSOLIDATION
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR_SUMMARY.PRD_CODE
          AND CP.DIV_CODE = AR_SUMMARY.DIV_CODE
          AND CP.CL_CODE = AR_SUMMARY.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR_SUMMARY.PRD_CODE
          AND A.DIV_CODE = AR_SUMMARY.DIV_CODE
          AND A.CL_CODE = AR_SUMMARY.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        LEFT OUTER JOIN JOB_TYPE JT
          ON JT.JT_CODE = JC.JT_CODE
        LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
          ON JUDV1.UDV_CODE = JL.UDV1_CODE
        LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
          ON JUDV2.UDV_CODE = JL.UDV2_CODE
        LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
          ON JUDV3.UDV_CODE = JL.UDV3_CODE
        LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
          ON JUDV4.UDV_CODE = JL.UDV4_CODE
        LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
          ON JUDV5.UDV_CODE = JL.UDV5_CODE
        LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
          ON JCUDV1.UDV_CODE = JC.UDV1_CODE
        LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
          ON JCUDV2.UDV_CODE = JC.UDV2_CODE
        LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
          ON JCUDV3.UDV_CODE = JC.UDV3_CODE
        LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
          ON JCUDV4.UDV_CODE = JC.UDV4_CODE
        LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
          ON JCUDV5.UDV_CODE = JC.UDV5_CODE
        WHERE (((AR_SUMMARY.FNC_TYPE) = 'R')
        AND ((AR_SUMMARY.SALE_POST_PERIOD) BETWEEN @StartPeriod AND @EndPeriod)
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL))
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (AR_SUMMARY.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE + '|' + AR_SUMMARY.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR_SUMMARY.CL_CODE + '|' + AR_SUMMARY.DIV_CODE + '|' + AR_SUMMARY.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY AR_SUMMARY.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR_SUMMARY.CL_CODE,
                 CLIENT.CL_NAME,
                 AR_SUMMARY.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR_SUMMARY.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 ISNULL([MEDIA_TYPE], 'P'),
                 AR_SUMMARY.SC_CODE,
                 SALES_CLASS.SC_DESCRIPTION,
                 AR_SUMMARY.CMP_IDENTIFIER,
                 CAMPAIGN.CMP_CODE,
                 CAMPAIGN.CMP_NAME,
                 AR_SUMMARY.SALE_POST_PERIOD,
                 POSTPERIOD.PPGLYEAR,
                 JC.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 AR_SUMMARY.JOB_NUMBER,
                 JL.JOB_DESC,
                 AR_SUMMARY.JOB_COMPONENT_NBR,
                 JC.JOB_COMP_DESC,
                 CASE
                   WHEN AR_SUMMARY.JOB_NUMBER IS NOT NULL THEN CASE
                       WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
                       ELSE 'Open'
                     END
                 END,
                 JC.JT_CODE,
                 JT.JT_DESC,
                 JL.FORMAT_CODE,
                 JL.COMPLEX_CODE,
                 JL.PROMO_CODE,
                 JL.JOB_CLI_REF,
                 JC.JOB_CL_PO_NBR,
                 JC.EMP_CODE,
                 JUDV1.UDV_DESC,
                 JUDV2.UDV_DESC,
                 JUDV3.UDV_DESC,
                 JUDV4.UDV_DESC,
                 JUDV5.UDV_DESC,
                 JCUDV1.UDV_DESC,
                 JCUDV2.UDV_DESC,
                 JCUDV3.UDV_DESC,
                 JCUDV4.UDV_DESC,
                 JCUDV5.UDV_DESC,
                 AR_SUMMARY.FNC_CODE,
                 CF.FNC_DESCRIPTION,
                 CF.FNC_CODE,
                 F.FNC_DESCRIPTION,
                 FH.FNC_HEADING_DESC,
                 AR_SUMMARY.FNC_TYPE,
                 JC.MARKET_CODE,
                 M.MARKET_DESC,
                 AR_SUMMARY.GL_ACCT_SALE,
                 AR_SUMMARY.GL_ACCT_COS
    END
    --SELECT * FROM #GROSS_INCOME_CPL WHERE JobNumber = 433

    --Estimate
    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(J.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(J.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(J.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(J.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P',
        ISNULL(J.SC_CODE, ''),
        ISNULL(SC.SC_DESCRIPTION, ''),
        ISNULL(J.CMP_IDENTIFIER, 0),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        NULL,
        NULL,
        NULL,
        NULL,
        ISNULL(JC.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        EA.JOB_NUMBER,
        J.JOB_DESC,
        EA.JOB_COMPONENT_NBR,
        JC.JOB_COMP_DESC,
        CASE
          WHEN EA.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JC.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(J.FORMAT_CODE, ''),
        ISNULL(J.COMPLEX_CODE, ''),
        ISNULL(J.PROMO_CODE, ''),
        ISNULL(J.JOB_CLI_REF, ''),
        ISNULL(JC.JOB_CL_PO_NBR, ''),
        ISNULL(JC.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        ERD.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN ERD.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JC.MARKET_CODE,
        M.MARKET_DESC,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        ISNULL(ERD.EST_REV_QUANTITY, 0),
        0,
        0,
        ISNULL(ERD.EXT_MARKUP_AMT, 0),
        CASE
          WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
          WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE, 0)
          WHEN F.FNC_TYPE = 'I' THEN 0
          ELSE 0
        END,
        ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM [dbo].[ESTIMATE_APPROVAL] AS EA
      INNER JOIN [dbo].[ESTIMATE_REV_DET] AS ERD
        ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER
        AND ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR
        AND ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR
        AND ERD.EST_REV_NBR = EA.EST_REVISION_NBR
      INNER JOIN [dbo].[FUNCTIONS] AS F
        ON F.FNC_CODE = ERD.FNC_CODE
      INNER JOIN [dbo].[JOB_COMPONENT] JC
        ON JC.JOB_NUMBER = EA.JOB_NUMBER
        AND JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR
      INNER JOIN [dbo].[JOB_LOG] AS J
        ON J.JOB_NUMBER = JC.JOB_NUMBER
      INNER JOIN
      --#GROSS_INCOME_CPL AS GCPL ON GCPL.JobNumber = EA.JOB_NUMBER AND
      --							GCPL.JobComponentNumber = EA.JOB_COMPONENT_NBR INNER JOIN 
      [dbo].[PRODUCT] AS P
        ON P.CL_CODE = J.CL_CODE
        AND P.DIV_CODE = J.DIV_CODE
        AND P.PRD_CODE = J.PRD_CODE
      INNER JOIN [dbo].[DIVISION] AS D
        ON D.CL_CODE = P.CL_CODE
        AND D.DIV_CODE = P.DIV_CODE
      INNER JOIN [dbo].[CLIENT] AS C
        ON C.CL_CODE = D.CL_CODE
      LEFT OUTER JOIN [dbo].[FNC_HEADING] AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN [dbo].[FUNCTIONS] AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN [dbo].EMPLOYEE_CLOAK EMP1
        ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE
      LEFT OUTER JOIN [dbo].MARKET AS M
        ON M.MARKET_CODE = JC.MARKET_CODE
      LEFT OUTER JOIN [dbo].[OFFICE] AS O
        ON O.OFFICE_CODE = J.OFFICE_CODE
      LEFT OUTER JOIN [dbo].[SALES_CLASS] AS SC
        ON SC.SC_CODE = J.SC_CODE
      LEFT OUTER JOIN [dbo].[CAMPAIGN] AS CAMP
        ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER
      LEFT OUTER JOIN
      --  [dbo].ACCOUNT_EXECUTIVE AE ON JC.EMP_CODE = AE.EMP_CODE
      --AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JC.EMP_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = J.PRD_CODE
        AND CP.DIV_CODE = J.DIV_CODE
        AND CP.CL_CODE = J.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = J.PRD_CODE
        AND A.DIV_CODE = J.DIV_CODE
        AND A.CL_CODE = J.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JC.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = J.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = J.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = J.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = J.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = J.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JC.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JC.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JC.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JC.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JC.UDV5_CODE
      WHERE 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   C.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
      AND CAST(EA.JOB_NUMBER AS varchar(10)) + '|' + CAST(EA.JOB_COMPONENT_NBR AS varchar(3)) IN (SELECT
        CAST(JobNumber AS varchar(10)) + '|' + CAST(JobComponentNumber AS varchar(3))
      FROM #GROSS_INCOME_CPL)
      AND (J.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

    INSERT INTO #GROSS_INCOME_CPL
      SELECT
        ISNULL(J.OFFICE_CODE, ''),
        ISNULL(O.OFFICE_NAME, ''),
        ISNULL(J.CL_CODE, ''),
        ISNULL(C.CL_NAME, ''),
        ISNULL(J.DIV_CODE, ''),
        ISNULL(D.DIV_NAME, ''),
        ISNULL(J.PRD_CODE, ''),
        ISNULL(P.PRD_DESCRIPTION, ''),
        'P',
        ISNULL(J.SC_CODE, ''),
        ISNULL(SC.SC_DESCRIPTION, ''),
        ISNULL(J.CMP_IDENTIFIER, 0),
        ISNULL(CAMP.CMP_CODE, ''),
        ISNULL(CAMP.CMP_NAME, ''),
        NULL,
        NULL,
        NULL,
        NULL,
        ISNULL(JC.EMP_CODE, ''),
        COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
        ISNULL(P.USER_DEFINED1, ''),
        ISNULL(P.USER_DEFINED2, ''),
        ISNULL(P.USER_DEFINED3, ''),
        ISNULL(P.USER_DEFINED4, ''),
        ISNULL(I.[DESCRIPTION], ''),
        ISNULL(S.[DESCRIPTION], ''),
        ISNULL(CP.REGION_CODE, ''),
        ISNULL(R.REGION_DESC, ''),
        ISNULL(CP.REVENUE, 0),
        ISNULL(CP.NUM_EMPLOYEES, 0),
        ISNULL(SO.[DESCRIPTION], ''),
        EIA.JOB_NUMBER,
        J.JOB_DESC,
        EIA.JOB_COMPONENT_NBR,
        JC.JOB_COMP_DESC,
        CASE
          WHEN EIA.JOB_NUMBER IS NOT NULL THEN CASE
              WHEN JC.JOB_PROCESS_CONTRL IN (6, 12) THEN 'Closed'
              ELSE 'Open'
            END
        END,
        ISNULL(JC.JT_CODE, ''),
        ISNULL(JT.JT_DESC, ''),
        ISNULL(J.FORMAT_CODE, ''),
        ISNULL(J.COMPLEX_CODE, ''),
        ISNULL(J.PROMO_CODE, ''),
        ISNULL(J.JOB_CLI_REF, ''),
        ISNULL(JC.JOB_CL_PO_NBR, ''),
        ISNULL(JC.EMP_CODE, ''),
        NULL,
        ISNULL(JUDV1.UDV_DESC, ''),
        ISNULL(JUDV2.UDV_DESC, ''),
        ISNULL(JUDV3.UDV_DESC, ''),
        ISNULL(JUDV4.UDV_DESC, ''),
        ISNULL(JUDV5.UDV_DESC, ''),
        ISNULL(JCUDV1.UDV_DESC, ''),
        ISNULL(JCUDV2.UDV_DESC, ''),
        ISNULL(JCUDV3.UDV_DESC, ''),
        ISNULL(JCUDV4.UDV_DESC, ''),
        ISNULL(JCUDV5.UDV_DESC, ''),
        ERD.FNC_CODE,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN ERD.FNC_CODE
          ELSE CF.FNC_CODE
        END,
        CASE
          WHEN CF.FNC_CODE IS NULL THEN F.FNC_DESCRIPTION
          ELSE CF.FNC_DESCRIPTION
        END,
        F.FNC_DESCRIPTION,
        FNC_HEADING_DESC,
        F.FNC_TYPE,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        JC.MARKET_CODE,
        M.MARKET_DESC,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        ISNULL(ERD.EST_REV_QUANTITY, 0),
        0,
        0,
        ISNULL(ERD.EXT_MARKUP_AMT, 0),
        CASE
          WHEN F.FNC_TYPE = 'V' THEN ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0) - ISNULL(ERD.EXT_MARKUP_AMT, 0)
          WHEN F.FNC_TYPE = 'E' THEN ISNULL(ERD.EST_REV_QUANTITY, 0) * ISNULL(EMP1.EMP_COST_RATE, 0)
          WHEN F.FNC_TYPE = 'I' THEN 0
          ELSE 0
        END,
        ISNULL(ERD.LINE_TOTAL, 0) - ISNULL(ERD.EXT_STATE_RESALE, 0) - ISNULL(ERD.EXT_COUNTY_RESALE, 0) - ISNULL(ERD.EXT_CITY_RESALE, 0),
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      FROM [dbo].[ESTIMATE_INT_APPR] AS EIA
      INNER JOIN (SELECT
        EIA.ESTIMATE_NUMBER,
        EIA.EST_COMPONENT_NBR,
        EIA.EST_QUOTE_NBR,
        EIA.EST_REVISION_NBR
      FROM [dbo].[ESTIMATE_INT_APPR] AS EIA
      LEFT JOIN [dbo].[ESTIMATE_APPROVAL] AS EA
        ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER
        AND EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR
        AND EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR
        AND EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR
      WHERE EA.EST_APPR_BY IS NULL) AS EA
        ON EA.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER
        AND EA.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR
        AND EA.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR
        AND EA.EST_REVISION_NBR = EIA.EST_REVISION_NBR
      INNER JOIN [dbo].[ESTIMATE_REV_DET] AS ERD
        ON ERD.ESTIMATE_NUMBER = EIA.ESTIMATE_NUMBER
        AND ERD.EST_COMPONENT_NBR = EIA.EST_COMPONENT_NBR
        AND ERD.EST_QUOTE_NBR = EIA.EST_QUOTE_NBR
        AND ERD.EST_REV_NBR = EIA.EST_REVISION_NBR
      INNER JOIN [dbo].[FUNCTIONS] AS F
        ON F.FNC_CODE = ERD.FNC_CODE
      INNER JOIN [dbo].[JOB_COMPONENT] JC
        ON JC.JOB_NUMBER = EIA.JOB_NUMBER
        AND JC.JOB_COMPONENT_NBR = EIA.JOB_COMPONENT_NBR
      INNER JOIN [dbo].[JOB_LOG] AS J
        ON J.JOB_NUMBER = JC.JOB_NUMBER
      INNER JOIN
      --#GROSS_INCOME_CPL AS GCPL ON GCPL.JobNumber = EIA.JOB_NUMBER AND
      --							GCPL.JobComponentNumber = EIA.JOB_COMPONENT_NBR INNER JOIN 
      [dbo].[PRODUCT] AS P
        ON P.CL_CODE = J.CL_CODE
        AND P.DIV_CODE = J.DIV_CODE
        AND P.PRD_CODE = J.PRD_CODE
      INNER JOIN [dbo].[DIVISION] AS D
        ON D.CL_CODE = P.CL_CODE
        AND D.DIV_CODE = P.DIV_CODE
      INNER JOIN [dbo].[CLIENT] AS C
        ON C.CL_CODE = D.CL_CODE
      LEFT OUTER JOIN [dbo].[FNC_HEADING] AS FH
        ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
      LEFT OUTER JOIN [dbo].[FUNCTIONS] AS CF
        ON CF.FNC_CODE = F.FNC_CONSOLIDATION
      LEFT OUTER JOIN [dbo].EMPLOYEE_CLOAK EMP1
        ON EMP1.EMP_CODE = ERD.EST_REV_SUP_BY_CDE
      LEFT OUTER JOIN [dbo].MARKET AS M
        ON M.MARKET_CODE = JC.MARKET_CODE
      LEFT OUTER JOIN [dbo].[OFFICE] AS O
        ON O.OFFICE_CODE = J.OFFICE_CODE
      LEFT OUTER JOIN [dbo].[SALES_CLASS] AS SC
        ON SC.SC_CODE = J.SC_CODE
      LEFT OUTER JOIN [dbo].[CAMPAIGN] AS CAMP
        ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER
      LEFT OUTER JOIN
      --  [dbo].ACCOUNT_EXECUTIVE AE ON JC.EMP_CODE = AE.EMP_CODE
      --AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
      EMPLOYEE AS EMP
        ON EMP.EMP_CODE = JC.EMP_CODE
      LEFT OUTER JOIN COMPANY_PROFILE CP
        ON CP.PRD_CODE = J.PRD_CODE
        AND CP.DIV_CODE = J.DIV_CODE
        AND CP.CL_CODE = J.CL_CODE
      LEFT OUTER JOIN ACTIVITY A
        ON A.PRD_CODE = J.PRD_CODE
        AND A.DIV_CODE = J.DIV_CODE
        AND A.CL_CODE = J.CL_CODE
      LEFT OUTER JOIN INDUSTRY I
        ON I.INDUSTRY_ID = CP.INDUSTRY_ID
      LEFT OUTER JOIN SPECIALTY S
        ON S.SPECIALTY_ID = CP.SPECIALTY_ID
      LEFT OUTER JOIN REGION R
        ON R.REGION_CODE = CP.REGION_CODE
      LEFT OUTER JOIN [SOURCE] SO
        ON SO.SOURCE_ID = A.SOURCE_ID
      LEFT OUTER JOIN JOB_TYPE JT
        ON JT.JT_CODE = JC.JT_CODE
      LEFT OUTER JOIN JOB_LOG_UDV1 AS JUDV1
        ON JUDV1.UDV_CODE = J.UDV1_CODE
      LEFT OUTER JOIN JOB_LOG_UDV2 AS JUDV2
        ON JUDV2.UDV_CODE = J.UDV2_CODE
      LEFT OUTER JOIN JOB_LOG_UDV3 AS JUDV3
        ON JUDV3.UDV_CODE = J.UDV3_CODE
      LEFT OUTER JOIN JOB_LOG_UDV4 AS JUDV4
        ON JUDV4.UDV_CODE = J.UDV4_CODE
      LEFT OUTER JOIN JOB_LOG_UDV5 AS JUDV5
        ON JUDV5.UDV_CODE = J.UDV5_CODE
      LEFT OUTER JOIN JOB_CMP_UDV1 AS JCUDV1
        ON JCUDV1.UDV_CODE = JC.UDV1_CODE
      LEFT OUTER JOIN JOB_CMP_UDV2 AS JCUDV2
        ON JCUDV2.UDV_CODE = JC.UDV2_CODE
      LEFT OUTER JOIN JOB_CMP_UDV3 AS JCUDV3
        ON JCUDV3.UDV_CODE = JC.UDV3_CODE
      LEFT OUTER JOIN JOB_CMP_UDV4 AS JCUDV4
        ON JCUDV4.UDV_CODE = JC.UDV4_CODE
      LEFT OUTER JOIN JOB_CMP_UDV5 AS JCUDV5
        ON JCUDV5.UDV_CODE = JC.UDV5_CODE
      WHERE --J.CREATE_DATE BETWEEN @StartDate and @EndDate AND
      1 =
         CASE
           WHEN @ExcludeNewBusiness = 1 AND
             C.[NEW_BUSINESS] = 1 THEN 0
           ELSE 1
         END
      AND CAST(EIA.JOB_NUMBER AS varchar(10)) + '|' + CAST(EIA.JOB_COMPONENT_NBR AS varchar(3)) IN (SELECT
        CAST(JobNumber AS varchar(10)) + '|' + CAST(JobComponentNumber AS varchar(3))
      FROM #GROSS_INCOME_CPL)
      AND (J.OFFICE_CODE IN (SELECT
        *
      FROM dbo.udf_split_list(@OFFICE_LIST, ','))
      OR @OFFICE_LIST IS NULL)
    --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
    --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
    --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))			

    IF @IncludeCREntries = 1
    BEGIN
      --CR Client Detail Sales
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT * -1) AS [CR Sales],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM AR_SUMMARY AR) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLACCOUNT.GLATYPE) IN ('8'))
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC

      --CR Client Detail Cost of Sales
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Cost of Sales],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM AR_SUMMARY AR) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLACCOUNT.GLATYPE) IN ('13'))
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC

      --CR Client Detail Direct Expense
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          'CR',
          NULL,
          NULL,
          'Cash Receipts',
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Direct Expense],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM AR_SUMMARY AR) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (1 =
                  CASE
                    WHEN @DirectExpenseOperatingOnly = 1 AND
                      ((GLACCOUNT.GLATYPE) IN ('14')) THEN 1
                    WHEN @DirectExpenseOperatingOnly = 0 AND
                      ((GLACCOUNT.GLATYPE) IN ('9', '14', '15')) THEN 1
                    ELSE 0
                  END
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (CR_CLIENT.[STATUS] IS NULL OR CR_CLIENT.[STATUS] <> 'D')
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC


      --CR Client Detail Sales - Manual Invoices
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT * -1) AS [CR Sales],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM ACCT_REC AR
        WHERE MANUAL_INV = 1) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLACCOUNT.GLATYPE) IN ('8'))
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC

      --CR Client Detail Cost of Sales - Manual Invoices
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          NULL,
          NULL,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Cost of Sales],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM ACCT_REC AR
        WHERE MANUAL_INV = 1) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (((GLACCOUNT.GLATYPE) IN ('13'))
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC

      --CR Client Detail Direct Expense - Manual Invoices
      INSERT INTO #GROSS_INCOME_CPL
        SELECT
          ISNULL(PRODUCT.OFFICE_CODE, ''),
          ISNULL(OFFICE.OFFICE_NAME, ''),
          ISNULL(AR.CL_CODE, ''),
          ISNULL(CLIENT.CL_NAME, ''),
          ISNULL(AR.DIV_CODE, ''),
          ISNULL(DIVISION.DIV_NAME, ''),
          ISNULL(AR.PRD_CODE, ''),
          ISNULL(PRODUCT.PRD_DESCRIPTION, ''),
          'CR' AS Type,
          'CR',
          'Cash Receipts',
          0 AS CampaignID,
          '' AS CampaignCode,
          '' AS CampaignName,
          CR_CLIENT.POST_PERIOD,
          SUBSTRING(CR_CLIENT.POST_PERIOD, 1, 4),
          SUBSTRING(CR_CLIENT.POST_PERIOD, 5, 2),
          [POSTPERIOD].[PPGLYEAR],
          ISNULL(AE.EMP_CODE, ''),
          COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') AS [Default AE Name],
          ISNULL(PRODUCT.USER_DEFINED1, ''),
          ISNULL(PRODUCT.USER_DEFINED2, ''),
          ISNULL(PRODUCT.USER_DEFINED3, ''),
          ISNULL(PRODUCT.USER_DEFINED4, ''),
          ISNULL(I.[DESCRIPTION], ''),
          ISNULL(S.[DESCRIPTION], ''),
          ISNULL(CP.REGION_CODE, ''),
          ISNULL(R.REGION_DESC, ''),
          ISNULL(CP.REVENUE, 0),
          ISNULL(CP.NUM_EMPLOYEES, 0),
          ISNULL(SO.[DESCRIPTION], ''),
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          'CR',
          NULL,
          NULL,
          'Cash Receipts',
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          NULL,
          CR_CLIENT_DTL.GLACODE_ADJ,
          GLACCOUNT.GLADESC,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          SUM(CR_CLIENT_DTL.CR_ADJ_AMT) AS [CR Direct Expense],
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        FROM CR_CLIENT_DTL
        INNER JOIN CR_CLIENT
          ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID
          AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR
        INNER JOIN GLACCOUNT
          ON CR_CLIENT_DTL.GLACODE_ADJ = GLACCOUNT.GLACODE
        INNER JOIN POSTPERIOD
          ON CR_CLIENT.POST_PERIOD = POSTPERIOD.PPPERIOD
        LEFT OUTER JOIN (SELECT DISTINCT
          CL_CODE,
          DIV_CODE,
          PRD_CODE,
          AR_INV_NBR,
          AR_INV_SEQ,
          AR_TYPE
        FROM ACCT_REC AR
        WHERE MANUAL_INV = 1) AS AR
          ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR
          AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
          AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
        LEFT OUTER JOIN
        --AR_SUMMARY AR ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE LEFT JOIN 
        AGENCY_CLIENTS
          ON AR.CL_CODE = AGENCY_CLIENTS.CL_CODE
        INNER JOIN CLIENT
          ON AR.CL_CODE = CLIENT.CL_CODE
        INNER JOIN DIVISION
          ON (AR.DIV_CODE = DIVISION.DIV_CODE)
          AND (AR.CL_CODE = DIVISION.CL_CODE)
        INNER JOIN PRODUCT
          ON (AR.PRD_CODE = PRODUCT.PRD_CODE)
          AND (AR.DIV_CODE = PRODUCT.DIV_CODE)
          AND (AR.CL_CODE = PRODUCT.CL_CODE)
        INNER JOIN OFFICE
          ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
        LEFT OUTER JOIN ACCOUNT_EXECUTIVE AE
          ON PRODUCT.CL_CODE = AE.CL_CODE
          AND PRODUCT.DIV_CODE = AE.DIV_CODE
          AND PRODUCT.PRD_CODE = AE.PRD_CODE
          AND (AE.INACTIVE_FLAG = 0
          OR AE.INACTIVE_FLAG IS NULL)
          AND AE.DEFAULT_AE = 1
        LEFT OUTER JOIN EMPLOYEE AS EMP
          ON EMP.EMP_CODE = AE.EMP_CODE
        LEFT OUTER JOIN COMPANY_PROFILE CP
          ON CP.PRD_CODE = AR.PRD_CODE
          AND CP.DIV_CODE = AR.DIV_CODE
          AND CP.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN ACTIVITY A
          ON A.PRD_CODE = AR.PRD_CODE
          AND A.DIV_CODE = AR.DIV_CODE
          AND A.CL_CODE = AR.CL_CODE
        LEFT OUTER JOIN INDUSTRY I
          ON I.INDUSTRY_ID = CP.INDUSTRY_ID
        LEFT OUTER JOIN SPECIALTY S
          ON S.SPECIALTY_ID = CP.SPECIALTY_ID
        LEFT OUTER JOIN REGION R
          ON R.REGION_CODE = CP.REGION_CODE
        LEFT OUTER JOIN [SOURCE] SO
          ON SO.SOURCE_ID = A.SOURCE_ID
        WHERE (1 =
                  CASE
                    WHEN @DirectExpenseOperatingOnly = 1 AND
                      ((GLACCOUNT.GLATYPE) IN ('14')) THEN 1
                    WHEN @DirectExpenseOperatingOnly = 0 AND
                      ((GLACCOUNT.GLATYPE) IN ('9', '14', '15')) THEN 1
                    ELSE 0
                  END
        AND ((AGENCY_CLIENTS.CL_CODE) IS NULL)) --AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null)
        AND (CR_CLIENT.POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod)
        AND 1 =
               CASE
                 WHEN @ExcludeNewBusiness = 1 AND
                   CLIENT.[NEW_BUSINESS] = 1 THEN 0
                 ELSE 1
               END
        AND (PRODUCT.OFFICE_CODE IN (SELECT
          *
        FROM dbo.udf_split_list(@OFFICE_LIST, ','))
        OR @OFFICE_LIST IS NULL)
        --AND (CR_CLIENT.[STATUS] IS NULL OR CR_CLIENT.[STATUS] <> 'D')
        --AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
        --AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
        --AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
        GROUP BY PRODUCT.OFFICE_CODE,
                 OFFICE.OFFICE_NAME,
                 AR.CL_CODE,
                 CLIENT.CL_NAME,
                 AR.DIV_CODE,
                 DIVISION.DIV_NAME,
                 AR.PRD_CODE,
                 PRODUCT.PRD_DESCRIPTION,
                 CR_CLIENT.POST_PERIOD,
                 [POSTPERIOD].[PPGLYEAR],
                 AE.EMP_CODE,
                 COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
                 PRODUCT.USER_DEFINED1,
                 PRODUCT.USER_DEFINED2,
                 PRODUCT.USER_DEFINED3,
                 PRODUCT.USER_DEFINED4,
                 I.[DESCRIPTION],
                 S.[DESCRIPTION],
                 CP.REGION_CODE,
                 R.REGION_DESC,
                 CP.REVENUE,
                 CP.NUM_EMPLOYEES,
                 SO.[DESCRIPTION],
                 CR_CLIENT_DTL.GLACODE_ADJ,
                 GLACCOUNT.GLADESC

    END

    --SELECT '#GROSS_INCOME_CPL'

    UPDATE #GROSS_INCOME_CPL
    SET DefaultAEName = (SELECT
      COALESCE((RTRIM(EMPD.EMP_FNAME) + ' '), '') + COALESCE((EMPD.EMP_MI + '. '), '') + COALESCE(EMPD.EMP_LNAME, '')
    FROM EMPLOYEE EMPD
    WHERE EMPD.EMP_CODE = #GROSS_INCOME_CPL.DefaultAECode)
    WHERE DefaultAECode IS NOT NULL

    UPDATE #GROSS_INCOME_CPL
    SET JobAEName = (SELECT
      COALESCE((RTRIM(EMPD.EMP_FNAME) + ' '), '') + COALESCE((EMPD.EMP_MI + '. '), '') + COALESCE(EMPD.EMP_LNAME, '')
    FROM EMPLOYEE EMPD
    WHERE EMPD.EMP_CODE = #GROSS_INCOME_CPL.JobAECode)
    WHERE JobAECode IS NOT NULL

    UPDATE #GROSS_INCOME_CPL
    SET SalesGLAccountDescription = (SELECT
      GLADESC
    FROM GLACCOUNT GL
    WHERE GL.GLACODE = #GROSS_INCOME_CPL.SalesGLAccountCode)
    WHERE SalesGLAccountCode IS NOT NULL

    UPDATE #GROSS_INCOME_CPL
    SET CostOfSalesGLAccountDescription = (SELECT
      GLADESC
    FROM GLACCOUNT GL
    WHERE GL.GLACODE = #GROSS_INCOME_CPL.CostOfSalesGLAccountCode)
    WHERE CostOfSalesGLAccountCode IS NOT NULL

    UPDATE #GROSS_INCOME_CPL
    SET MarketDescription = (SELECT
      MARKET_DESC
    FROM MARKET M
    WHERE M.MARKET_CODE = #GROSS_INCOME_CPL.MarketCode)
    WHERE MarketCode IS NOT NULL

    UPDATE #GROSS_INCOME_CPL
    SET DirectExpenseGLAccountDescription = (SELECT
      GLADESC
    FROM GLACCOUNT GL
    WHERE GL.GLACODE = #GROSS_INCOME_CPL.DirectExpenseGLAccountCode)
    WHERE DirectExpenseGLAccountCode IS NOT NULL

    --SELECT * FROM #GROSS_INCOME_CPL WHERE JobNumber = 433

    --SELECT '#GROSS_INCOME_CPL'

    IF @FTEAllocation = 2
    BEGIN
      IF @BySalesClass = 1
      BEGIN
        --Overhead Accounts
        INSERT INTO #CPL_OH_ACCOUNTS
          SELECT
            [GLACODE]
          FROM OH_ACCOUNTS,
               GLACCOUNT
          WHERE OH_CODE = @OverheadSet
          AND [GLACODE] BETWEEN [OH_FROM] AND [OH_TO]

        --SELECT * FROM #CPL_OH_ACCOUNTS

        --Overhead GL Amounts
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'OH' AS RecType,
            NULL AS OfficeCode,
            NULL,
            NULL AS ClientCode,
            NULL,
            NULL AS DivisionCode,
            NULL,
            NULL AS ProductCode,
            NULL,
            NULL AS Type,
            NULL AS SalesClassCode,
            NULL,
            NULL AS CampaignID,
            NULL AS CampaignCode,
            NULL,
            GLSUMMARY.GLSPP AS PostingPeriod,
            SUBSTRING(GLSUMMARY.GLSPP, 1, 4),
            CASE
              WHEN SUBSTRING(GLSUMMARY.GLSPP, 5, 2) = 'YE' THEN 99
              ELSE SUBSTRING(GLSUMMARY.GLSPP, 5, 2)
            END,
            POSTPERIOD.PPGLYEAR AS [Year],
            NULL AS DefaultAECode,
            NULL,
            '' AS ProductUDF1,
            '' AS ProductUDF2,
            '' AS ProductUDF3,
            '' AS ProductUDF4,
            NULL AS [Industry],
            NULL AS [Specialty],
            NULL AS [RegionCode],
            NULL AS [Region],
            NULL AS [Revenue],
            NULL AS [NumberOfEmployees],
            NULL AS [Source],
            NULL AS JobNumber,
            NULL AS JobDescription,
            NULL AS JobComponentNumber,
            NULL AS ComponentDescription,
            NULL AS [JobStatus],
            NULL AS [JobTypeCode],
            NULL AS [JobTypeDescription],
            NULL AS [SalesClassFormatCode],
            NULL AS [ComplexityCode],
            NULL AS [PromotionCode],
            NULL AS [ClientReference],
            NULL AS [ClientPO],
            NULL AS [JobAECode],
            NULL AS [JobAEName],
            NULL AS [LabelFromUDFTable1],
            NULL AS [LabelFromUDFTable2],
            NULL AS [LabelFromUDFTable3],
            NULL AS [LabelFromUDFTable4],
            NULL AS [LabelFromUDFTable5],
            NULL AS [CompLabelFromUDFTable1],
            NULL AS [CompLabelFromUDFTable2],
            NULL AS [CompLabelFromUDFTable3],
            NULL AS [CompLabelFromUDFTable4],
            NULL AS [CompLabelFromUDFTable5],
            NULL AS FunctionCode,
            NULL AS FunctionConsolidationCode,
            NULL AS FunctionConsolidation,
            NULL AS FunctionDescription,
            NULL AS FunctionHeading,
            NULL AS FunctionType,
            NULL AS OrderNumber,
            NULL AS OrderDescription,
            NULL AS LineNumber,
            NULL AS MediaMonth,
            NULL AS MediaYear,
            NULL AS StartDate,
            NULL AS EndDate,
            NULL AS MarketCode,
            NULL AS MarketDescription,
            NULL AS SalesGLAccountCode,
            NULL AS SalesGLAccountDescription,
            NULL AS CostOfSalesGLAccountCode,
            NULL AS CostOfSalesGLAccountDescription,
            NULL AS DirectExpenseGLAccountCode,
            NULL AS DirectExpenseGLAccountDescription,
            SUM([GLSDEBIT] + [GLSCREDIT]) AS Overhead,
            SUM(0) AS Hours,
            SUM(0) AS DirectServiceCost,
            SUM(0) AS DirectExpense,
            SUM(0) AS TotalDirectCosts
          FROM (#CPL_OH_ACCOUNTS
          INNER JOIN GLSUMMARY
            ON #CPL_OH_ACCOUNTS.[GLACode] = GLSUMMARY.GLSCODE)
          INNER JOIN POSTPERIOD
            ON GLSUMMARY.GLSPP = POSTPERIOD.PPPERIOD
          WHERE (GLSUMMARY.GLSPP BETWEEN @StartPeriod AND @EndPeriod)
          GROUP BY GLSUMMARY.GLSPP,
                   POSTPERIOD.PPGLYEAR

        --Direct Service Cost
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'DSC' AS RecType,
            OfficeCode,
            OfficeDescription,
            NULL,
            NULL,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            0 AS Overhead,
            SUM([Hours]) AS SumOfHours,
            SUM(DirectServiceCost) AS SumOfDirectServiceCost,
            0 AS DirectExpense,
            SUM(DirectServiceCost) AS Total
          FROM #GROSS_INCOME_CPL
          WHERE OfficeCode IN (SELECT
            OFF_CODE
          FROM OFF_ASSIGN
          WHERE OH_SET_ID = @OverheadSet)
          GROUP BY OfficeCode,
                   OfficeDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription

        --Direct Expense
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'DE' AS RecType,
            OfficeCode,
            OfficeDescription,
            NULL,
            NULL,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            SUM(0) AS Overhead,
            (0) AS Hours,
            (0) AS DirectServiceCost,
            SUM(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS SumOfDirectExpense,
            SUM(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS Total
          FROM #GROSS_INCOME_CPL
          --WHERE DirectExpense <> 0
          GROUP BY OfficeCode,
                   OfficeDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription

        --SELECT * FROM #CPL_OH_AMOUNTS
        --SELECT * FROM #GROSS_INCOME_CPL

        --Direct Service Cost Detail
        INSERT INTO #CPL_OH_AMOUNTS_DETAIL
          SELECT
            PostingPeriod AS Period,
            OfficeCode,
            OfficeDescription,
            NULL,
            NULL,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            MAX(PostingPeriod) AS PostingPeriod,
            MAX(PostingPeriodYear),
            MAX(PostingPeriodMonth),
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            SUM([Hours]) AS DetailHrs,
            SUM(DirectServiceCost) AS DetailHrsCost
          FROM #CPL_OH_AMOUNTS
          WHERE (RecType = 'DSC')
          GROUP BY PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   OfficeCode,
                   OfficeDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription;

        --Direct Service Cost Total
        INSERT INTO #CPL_OH_AMOUNTS_TOTAL
          SELECT
            PostingPeriod AS Period,
            SUM([Hours]) AS HoursTotal,
            SUM(DirectServiceCost) AS HoursCostTotal
          FROM #CPL_OH_AMOUNTS
          WHERE (RecType = 'DSC')
          GROUP BY PostingPeriod

        --SELECT * FROM #CPL_OH_AMOUNTS_DETAIL
        --SELECT * FROM #CPL_OH_AMOUNTS_TOTAL

        --Direct Service Cost Percentage
        INSERT INTO #CPL_OH_AMOUNTS_DSC_PERC
          SELECT
            #CPL_OH_AMOUNTS_DETAIL.Period,
            OfficeCode,
            OfficeDescription,
            NULL,
            NULL,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            CASE
              WHEN #CPL_OH_AMOUNTS_TOTAL.HoursTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHours / #CPL_OH_AMOUNTS_TOTAL.HoursTotal
              ELSE 0
            END AS DirectServiceHoursPercentage,
            CASE
              WHEN #CPL_OH_AMOUNTS_TOTAL.HoursCostTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHoursCost / #CPL_OH_AMOUNTS_TOTAL.HoursCostTotal
              ELSE 0
            END AS DirectServiceCostPercentage
          FROM #CPL_OH_AMOUNTS_DETAIL
          INNER JOIN #CPL_OH_AMOUNTS_TOTAL
            ON #CPL_OH_AMOUNTS_DETAIL.Period = #CPL_OH_AMOUNTS_TOTAL.Period

        --SELECT * FROM #CPL_OH_AMOUNTS_DSC_PERC

        --Overhead Amount Total
        INSERT INTO #CPL_OH_AMOUNTS_OVERHEAD
          SELECT
            PostingPeriod AS Period,
            SUM(Overhead - TotalDirectCosts) AS OHToAlloc,
            SUM(Overhead) AS OHTotal
          FROM #CPL_OH_AMOUNTS
          GROUP BY PostingPeriod

        --SELECT * FROM #CPL_OH_AMOUNTS_OVERHEAD

        --Overhead	
        IF @HoursCost = 1
        BEGIN
          INSERT INTO #GROSS_INCOME_CPL
            SELECT
              DSP.OfficeCode,
              DSP.OfficeDescription,
              DSP.ClientCode,
              DSP.ClientDescription,
              DSP.DivisionCode,
              DSP.DivisionDescription,
              DSP.ProductCode,
              DSP.ProductDescription,
              DSP.[Type],
              DSP.SalesClassCode,
              DSP.SalesClassDescription,
              DSP.CampaignID,
              DSP.CampaignCode,
              DSP.CampaignName,
              DSP.PostingPeriod,
              DSP.PostingPeriodYear,
              DSP.PostingPeriodMonth,
              DSP.[Year],
              DSP.DefaultAECode,
              DSP.DefaultAEName,
              DSP.ProductUDF1,
              DSP.ProductUDF2,
              DSP.ProductUDF3,
              DSP.ProductUDF4,
              DSP.[Industry],
              DSP.[Specialty],
              DSP.[RegionCode],
              DSP.[Region],
              DSP.[Revenue],
              DSP.[NumberOfEmployees],
              DSP.[Source],
              JobNumber,
              JobDescription,
              JobComponentNumber,
              ComponentDescription,
              [JobStatus],
              [JobTypeCode],
              [JobTypeDescription],
              [SalesClassFormatCode],
              [ComplexityCode],
              [PromotionCode],
              [ClientReference],
              [ClientPO],
              [JobAECode],
              [JobAEName],
              [LabelFromUDFTable1],
              [LabelFromUDFTable2],
              [LabelFromUDFTable3],
              [LabelFromUDFTable4],
              [LabelFromUDFTable5],
              [CompLabelFromUDFTable1],
              [CompLabelFromUDFTable2],
              [CompLabelFromUDFTable3],
              [CompLabelFromUDFTable4],
              [CompLabelFromUDFTable5],
              FunctionCode,
              FunctionConsolidationCode,
              FunctionConsolidation,
              FunctionDescription,
              FunctionHeading,
              FunctionType,
              OrderNumber,
              OrderDescription,
              LineNumber,
              MediaMonth,
              MediaYear,
              StartDate,
              EndDate,
              MarketCode,
              MarketDescription,
              SalesGLAccountCode,
              SalesGLAccountDescription,
              CostOfSalesGLAccountCode,
              CostOfSalesGLAccountDescription,
              DirectExpenseGLAccountCode,
              DirectExpenseGLAccountDescription,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              #CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceHoursPercentage,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0
            FROM #CPL_OH_AMOUNTS_DSC_PERC DSP
            INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD
              ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
        END
        IF @HoursCost = 2
        BEGIN
          INSERT INTO #GROSS_INCOME_CPL
            SELECT
              DSP.OfficeCode,
              DSP.OfficeDescription,
              DSP.ClientCode,
              DSP.ClientDescription,
              DSP.DivisionCode,
              DSP.DivisionDescription,
              DSP.ProductCode,
              DSP.ProductDescription,
              DSP.[Type],
              DSP.SalesClassCode,
              DSP.SalesClassDescription,
              DSP.CampaignID,
              DSP.CampaignCode,
              DSP.CampaignName,
              DSP.PostingPeriod,
              DSP.PostingPeriodYear,
              DSP.PostingPeriodMonth,
              DSP.[Year],
              DSP.DefaultAECode,
              DSP.DefaultAEName,
              DSP.ProductUDF1,
              DSP.ProductUDF2,
              DSP.ProductUDF3,
              DSP.ProductUDF4,
              DSP.[Industry],
              DSP.[Specialty],
              DSP.[RegionCode],
              DSP.[Region],
              DSP.[Revenue],
              DSP.[NumberOfEmployees],
              DSP.[Source],
              JobNumber,
              JobDescription,
              JobComponentNumber,
              ComponentDescription,
              [JobStatus],
              [JobTypeCode],
              [JobTypeDescription],
              [SalesClassFormatCode],
              [ComplexityCode],
              [PromotionCode],
              [ClientReference],
              [ClientPO],
              [JobAECode],
              [JobAEName],
              [LabelFromUDFTable1],
              [LabelFromUDFTable2],
              [LabelFromUDFTable3],
              [LabelFromUDFTable4],
              [LabelFromUDFTable5],
              [CompLabelFromUDFTable1],
              [CompLabelFromUDFTable2],
              [CompLabelFromUDFTable3],
              [CompLabelFromUDFTable4],
              [CompLabelFromUDFTable5],
              FunctionCode,
              FunctionConsolidationCode,
              FunctionConsolidation,
              FunctionDescription,
              FunctionHeading,
              FunctionType,
              OrderNumber,
              OrderDescription,
              LineNumber,
              MediaMonth,
              MediaYear,
              StartDate,
              EndDate,
              MarketCode,
              MarketDescription,
              SalesGLAccountCode,
              SalesGLAccountDescription,
              CostOfSalesGLAccountCode,
              CostOfSalesGLAccountDescription,
              DirectExpenseGLAccountCode,
              DirectExpenseGLAccountDescription,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              #CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceHoursPercentage,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0
            FROM #CPL_OH_AMOUNTS_DSC_PERC DSP
            INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD
              ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
        END
      END
      ELSE
      BEGIN
        --Overhead Accounts
        INSERT INTO #CPL_OH_ACCOUNTS
          SELECT
            [GLACODE]
          FROM OH_ACCOUNTS,
               GLACCOUNT
          WHERE OH_CODE = @OverheadSet
          AND [GLACODE] BETWEEN [OH_FROM] AND [OH_TO]

        --SELECT * FROM #CPL_OH_ACCOUNTS

        --Overhead GL Amounts
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'OH' AS RecType,
            NULL AS OfficeCode,
            NULL,
            NULL AS ClientCode,
            NULL,
            NULL AS DivisionCode,
            NULL,
            NULL AS ProductCode,
            NULL,
            NULL AS Type,
            NULL AS SalesClassCode,
            NULL,
            NULL AS CampaignID,
            NULL AS CampaignCode,
            NULL,
            GLSUMMARY.GLSPP AS PostingPeriod,
            SUBSTRING(GLSUMMARY.GLSPP, 1, 4),
            CASE
              WHEN SUBSTRING(GLSUMMARY.GLSPP, 5, 2) = 'YE' THEN 99
              ELSE SUBSTRING(GLSUMMARY.GLSPP, 5, 2)
            END,
            POSTPERIOD.PPGLYEAR AS [Year],
            NULL AS DefaultAECode,
            NULL,
            '' AS ProductUDF1,
            '' AS ProductUDF2,
            '' AS ProductUDF3,
            '' AS ProductUDF4,
            NULL AS [Industry],
            NULL AS [Specialty],
            NULL AS [RegionCode],
            NULL AS [Region],
            NULL AS [Revenue],
            NULL AS [NumberOfEmployees],
            NULL AS [Source],
            NULL AS JobNumber,
            NULL AS JobDescription,
            NULL AS JobComponentNumber,
            NULL AS ComponentDescription,
            NULL AS [JobStatus],
            NULL AS [JobTypeCode],
            NULL AS [JobTypeDescription],
            NULL AS [SalesClassFormatCode],
            NULL AS [ComplexityCode],
            NULL AS [PromotionCode],
            NULL AS [ClientReference],
            NULL AS [ClientPO],
            NULL AS [JobAECode],
            NULL AS [JobAEName],
            NULL AS [LabelFromUDFTable1],
            NULL AS [LabelFromUDFTable2],
            NULL AS [LabelFromUDFTable3],
            NULL AS [LabelFromUDFTable4],
            NULL AS [LabelFromUDFTable5],
            NULL AS [CompLabelFromUDFTable1],
            NULL AS [CompLabelFromUDFTable2],
            NULL AS [CompLabelFromUDFTable3],
            NULL AS [CompLabelFromUDFTable4],
            NULL AS [CompLabelFromUDFTable5],
            NULL AS FunctionCode,
            NULL AS FunctionConsolidationCode,
            NULL AS FunctionConsolidation,
            NULL AS FunctionDescription,
            NULL AS FunctionHeading,
            NULL AS FunctionType,
            NULL AS OrderNumber,
            NULL AS OrderDescription,
            NULL AS LineNumber,
            NULL AS MediaMonth,
            NULL AS MediaYear,
            NULL AS StartDate,
            NULL AS EndDate,
            NULL AS MarketCode,
            NULL AS MarketDescription,
            NULL AS SalesGLAccountCode,
            NULL AS SalesGLAccountDescription,
            NULL AS CostOfSalesGLAccountCode,
            NULL AS CostOfSalesGLAccountDescription,
            NULL AS DirectExpenseGLAccountCode,
            NULL AS DirectExpenseGLAccountDescription,
            SUM([GLSDEBIT] + [GLSCREDIT]) AS Overhead,
            SUM(0) AS Hours,
            SUM(0) AS DirectServiceCost,
            SUM(0) AS DirectExpense,
            SUM(0) AS TotalDirectCosts
          FROM (#CPL_OH_ACCOUNTS
          INNER JOIN GLSUMMARY
            ON #CPL_OH_ACCOUNTS.[GLACode] = GLSUMMARY.GLSCODE)
          INNER JOIN POSTPERIOD
            ON GLSUMMARY.GLSPP = POSTPERIOD.PPPERIOD
          WHERE (GLSUMMARY.GLSPP BETWEEN @StartPeriod AND @EndPeriod)
          GROUP BY GLSUMMARY.GLSPP,
                   POSTPERIOD.PPGLYEAR

        --Direct Service Cost
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'DSC' AS RecType,
            OfficeCode,
            OfficeDescription,
            ClientCode,
            ClientDescription,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            0 AS Overhead,
            SUM([Hours]) AS SumOfHours,
            SUM(DirectServiceCost) AS SumOfDirectServiceCost,
            0 AS DirectExpense,
            SUM(DirectServiceCost) AS Total
          FROM #GROSS_INCOME_CPL
          WHERE OfficeCode IN (SELECT
            OFF_CODE
          FROM OFF_ASSIGN
          WHERE OH_SET_ID = @OverheadSet)
          GROUP BY OfficeCode,
                   OfficeDescription,
                   ClientCode,
                   ClientDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription

        --Direct Expense
        INSERT INTO #CPL_OH_AMOUNTS
          SELECT
            'DE' AS RecType,
            OfficeCode,
            OfficeDescription,
            ClientCode,
            ClientDescription,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            SUM(0) AS Overhead,
            (0) AS Hours,
            (0) AS DirectServiceCost,
            SUM(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS SumOfDirectExpense,
            SUM(DirectExpense + GLDirectExpense + CRClientDirectExpense) AS Total
          FROM #GROSS_INCOME_CPL
          --WHERE DirectExpense <> 0
          GROUP BY OfficeCode,
                   OfficeDescription,
                   ClientCode,
                   ClientDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription

        --SELECT * FROM #CPL_OH_AMOUNTS
        --SELECT * FROM #GROSS_INCOME_CPL

        --Direct Service Cost Detail
        INSERT INTO #CPL_OH_AMOUNTS_DETAIL
          SELECT
            PostingPeriod AS Period,
            OfficeCode,
            OfficeDescription,
            ClientCode,
            ClientDescription,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            MAX(PostingPeriod) AS PostingPeriod,
            MAX(PostingPeriodYear),
            MAX(PostingPeriodMonth),
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            SUM([Hours]) AS DetailHrs,
            SUM(DirectServiceCost) AS DetailHrsCost
          FROM #CPL_OH_AMOUNTS
          WHERE (RecType = 'DSC')
          GROUP BY PostingPeriod,
                   PostingPeriodYear,
                   PostingPeriodMonth,
                   OfficeCode,
                   OfficeDescription,
                   ClientCode,
                   ClientDescription,
                   DivisionCode,
                   DivisionDescription,
                   ProductCode,
                   ProductDescription,
                   [Type],
                   SalesClassCode,
                   SalesClassDescription,
                   CampaignID,
                   CampaignCode,
                   CampaignName,
                   [Year],
                   DefaultAECode,
                   DefaultAEName,
                   ProductUDF1,
                   ProductUDF2,
                   ProductUDF3,
                   ProductUDF4,
                   [Industry],
                   [Specialty],
                   [RegionCode],
                   [Region],
                   [Revenue],
                   [NumberOfEmployees],
                   [Source],
                   JobNumber,
                   JobDescription,
                   JobComponentNumber,
                   ComponentDescription,
                   [JobStatus],
                   [JobTypeCode],
                   [JobTypeDescription],
                   [SalesClassFormatCode],
                   [ComplexityCode],
                   [PromotionCode],
                   [ClientReference],
                   [ClientPO],
                   [JobAECode],
                   [JobAEName],
                   [LabelFromUDFTable1],
                   [LabelFromUDFTable2],
                   [LabelFromUDFTable3],
                   [LabelFromUDFTable4],
                   [LabelFromUDFTable5],
                   [CompLabelFromUDFTable1],
                   [CompLabelFromUDFTable2],
                   [CompLabelFromUDFTable3],
                   [CompLabelFromUDFTable4],
                   [CompLabelFromUDFTable5],
                   FunctionCode,
                   FunctionConsolidationCode,
                   FunctionConsolidation,
                   FunctionDescription,
                   FunctionHeading,
                   FunctionType,
                   OrderNumber,
                   OrderDescription,
                   LineNumber,
                   MediaMonth,
                   MediaYear,
                   StartDate,
                   EndDate,
                   MarketCode,
                   MarketDescription,
                   SalesGLAccountCode,
                   SalesGLAccountDescription,
                   CostOfSalesGLAccountCode,
                   CostOfSalesGLAccountDescription,
                   DirectExpenseGLAccountCode,
                   DirectExpenseGLAccountDescription;

        --Direct Service Cost Total
        INSERT INTO #CPL_OH_AMOUNTS_TOTAL
          SELECT
            PostingPeriod AS Period,
            SUM([Hours]) AS HoursTotal,
            SUM(DirectServiceCost) AS HoursCostTotal
          FROM #CPL_OH_AMOUNTS
          WHERE (RecType = 'DSC')
          GROUP BY PostingPeriod

        --SELECT * FROM #CPL_OH_AMOUNTS_DETAIL
        --SELECT * FROM #CPL_OH_AMOUNTS_TOTAL

        --SELECT '#CPL_OH_AMOUNTS_DSC_PERC'

        --Direct Service Cost Percentage
        INSERT INTO #CPL_OH_AMOUNTS_DSC_PERC
          SELECT
            #CPL_OH_AMOUNTS_DETAIL.Period,
            OfficeCode,
            OfficeDescription,
            ClientCode,
            ClientDescription,
            DivisionCode,
            DivisionDescription,
            ProductCode,
            ProductDescription,
            [Type],
            SalesClassCode,
            SalesClassDescription,
            CampaignID,
            CampaignCode,
            CampaignName,
            PostingPeriod,
            PostingPeriodYear,
            PostingPeriodMonth,
            [Year],
            DefaultAECode,
            DefaultAEName,
            ProductUDF1,
            ProductUDF2,
            ProductUDF3,
            ProductUDF4,
            [Industry],
            [Specialty],
            [RegionCode],
            [Region],
            [Revenue],
            [NumberOfEmployees],
            [Source],
            JobNumber,
            JobDescription,
            JobComponentNumber,
            ComponentDescription,
            [JobStatus],
            [JobTypeCode],
            [JobTypeDescription],
            [SalesClassFormatCode],
            [ComplexityCode],
            [PromotionCode],
            [ClientReference],
            [ClientPO],
            [JobAECode],
            [JobAEName],
            [LabelFromUDFTable1],
            [LabelFromUDFTable2],
            [LabelFromUDFTable3],
            [LabelFromUDFTable4],
            [LabelFromUDFTable5],
            [CompLabelFromUDFTable1],
            [CompLabelFromUDFTable2],
            [CompLabelFromUDFTable3],
            [CompLabelFromUDFTable4],
            [CompLabelFromUDFTable5],
            FunctionCode,
            FunctionConsolidationCode,
            FunctionConsolidation,
            FunctionDescription,
            FunctionHeading,
            FunctionType,
            OrderNumber,
            OrderDescription,
            LineNumber,
            MediaMonth,
            MediaYear,
            StartDate,
            EndDate,
            MarketCode,
            MarketDescription,
            SalesGLAccountCode,
            SalesGLAccountDescription,
            CostOfSalesGLAccountCode,
            CostOfSalesGLAccountDescription,
            DirectExpenseGLAccountCode,
            DirectExpenseGLAccountDescription,
            CASE
              WHEN #CPL_OH_AMOUNTS_TOTAL.HoursTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHours / #CPL_OH_AMOUNTS_TOTAL.HoursTotal
              ELSE 0
            END AS DirectServiceHoursPercentage,
            CASE
              WHEN #CPL_OH_AMOUNTS_TOTAL.HoursCostTotal > 0 THEN #CPL_OH_AMOUNTS_DETAIL.DetailHoursCost / #CPL_OH_AMOUNTS_TOTAL.HoursCostTotal
              ELSE 0
            END AS DirectServiceCostPercentage
          FROM #CPL_OH_AMOUNTS_DETAIL
          INNER JOIN #CPL_OH_AMOUNTS_TOTAL
            ON #CPL_OH_AMOUNTS_DETAIL.Period = #CPL_OH_AMOUNTS_TOTAL.Period

        --SELECT * FROM #CPL_OH_AMOUNTS_DSC_PERC

        --Overhead Amount Total
        INSERT INTO #CPL_OH_AMOUNTS_OVERHEAD
          SELECT
            PostingPeriod AS Period,
            SUM(Overhead - TotalDirectCosts) AS OHToAlloc,
            SUM(Overhead) AS OHTotal
          FROM #CPL_OH_AMOUNTS
          GROUP BY PostingPeriod

        --SELECT * FROM #CPL_OH_AMOUNTS_OVERHEAD

        --Overhead	
        IF @HoursCost = 1
        BEGIN
          INSERT INTO #GROSS_INCOME_CPL
            SELECT
              DSP.OfficeCode,
              DSP.OfficeDescription,
              DSP.ClientCode,
              DSP.ClientDescription,
              DSP.DivisionCode,
              DSP.DivisionDescription,
              DSP.ProductCode,
              DSP.ProductDescription,
              DSP.[Type],
              DSP.SalesClassCode,
              DSP.SalesClassDescription,
              DSP.CampaignID,
              DSP.CampaignCode,
              DSP.CampaignName,
              DSP.PostingPeriod,
              DSP.PostingPeriodYear,
              DSP.PostingPeriodMonth,
              DSP.[Year],
              DSP.DefaultAECode,
              DSP.DefaultAEName,
              DSP.ProductUDF1,
              DSP.ProductUDF2,
              DSP.ProductUDF3,
              DSP.ProductUDF4,
              DSP.[Industry],
              DSP.[Specialty],
              DSP.[RegionCode],
              DSP.[Region],
              DSP.[Revenue],
              DSP.[NumberOfEmployees],
              DSP.[Source],
              JobNumber,
              JobDescription,
              JobComponentNumber,
              ComponentDescription,
              [JobStatus],
              [JobTypeCode],
              [JobTypeDescription],
              [SalesClassFormatCode],
              [ComplexityCode],
              [PromotionCode],
              [ClientReference],
              [ClientPO],
              [JobAECode],
              [JobAEName],
              [LabelFromUDFTable1],
              [LabelFromUDFTable2],
              [LabelFromUDFTable3],
              [LabelFromUDFTable4],
              [LabelFromUDFTable5],
              [CompLabelFromUDFTable1],
              [CompLabelFromUDFTable2],
              [CompLabelFromUDFTable3],
              [CompLabelFromUDFTable4],
              [CompLabelFromUDFTable5],
              FunctionCode,
              FunctionConsolidationCode,
              FunctionConsolidation,
              FunctionDescription,
              FunctionHeading,
              FunctionType,
              OrderNumber,
              OrderDescription,
              LineNumber,
              MediaMonth,
              MediaYear,
              StartDate,
              EndDate,
              MarketCode,
              MarketDescription,
              SalesGLAccountCode,
              SalesGLAccountDescription,
              CostOfSalesGLAccountCode,
              CostOfSalesGLAccountDescription,
              DirectExpenseGLAccountCode,
              DirectExpenseGLAccountDescription,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              #CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceHoursPercentage,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0
            FROM #CPL_OH_AMOUNTS_DSC_PERC DSP
            INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD
              ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
        END
        IF @HoursCost = 2
        BEGIN
          INSERT INTO #GROSS_INCOME_CPL
            SELECT
              DSP.OfficeCode,
              DSP.OfficeDescription,
              DSP.ClientCode,
              DSP.ClientDescription,
              DSP.DivisionCode,
              DSP.DivisionDescription,
              DSP.ProductCode,
              DSP.ProductDescription,
              DSP.[Type],
              DSP.SalesClassCode,
              DSP.SalesClassDescription,
              DSP.CampaignID,
              DSP.CampaignCode,
              DSP.CampaignName,
              DSP.PostingPeriod,
              DSP.PostingPeriodYear,
              DSP.PostingPeriodMonth,
              DSP.[Year],
              DSP.DefaultAECode,
              DSP.DefaultAEName,
              DSP.ProductUDF1,
              DSP.ProductUDF2,
              DSP.ProductUDF3,
              DSP.ProductUDF4,
              DSP.[Industry],
              DSP.[Specialty],
              DSP.[RegionCode],
              DSP.[Region],
              DSP.[Revenue],
              DSP.[NumberOfEmployees],
              DSP.[Source],
              JobNumber,
              JobDescription,
              JobComponentNumber,
              ComponentDescription,
              [JobStatus],
              [JobTypeCode],
              [JobTypeDescription],
              [SalesClassFormatCode],
              [ComplexityCode],
              [PromotionCode],
              [ClientReference],
              [ClientPO],
              [JobAECode],
              [JobAEName],
              [LabelFromUDFTable1],
              [LabelFromUDFTable2],
              [LabelFromUDFTable3],
              [LabelFromUDFTable4],
              [LabelFromUDFTable5],
              [CompLabelFromUDFTable1],
              [CompLabelFromUDFTable2],
              [CompLabelFromUDFTable3],
              [CompLabelFromUDFTable4],
              [CompLabelFromUDFTable5],
              FunctionCode,
              FunctionConsolidationCode,
              FunctionConsolidation,
              FunctionDescription,
              FunctionHeading,
              FunctionType,
              OrderNumber,
              OrderDescription,
              LineNumber,
              MediaMonth,
              MediaYear,
              StartDate,
              EndDate,
              MarketCode,
              MarketDescription,
              SalesGLAccountCode,
              SalesGLAccountDescription,
              CostOfSalesGLAccountCode,
              CostOfSalesGLAccountDescription,
              DirectExpenseGLAccountCode,
              DirectExpenseGLAccountDescription,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              #CPL_OH_AMOUNTS_OVERHEAD.OHToAlloc * DSP.DirectServiceCostPercentage,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0
            FROM #CPL_OH_AMOUNTS_DSC_PERC DSP
            INNER JOIN #CPL_OH_AMOUNTS_OVERHEAD
              ON DSP.Period = #CPL_OH_AMOUNTS_OVERHEAD.Period
        END
      END


    END

    --SELECT * FROM #GROSS_INCOME_CPL

    --SELECT * FROM #CPL_OH_AMOUNTS

    --SELECT 'CPL_OH_AMOUNTS'

    SET @sql = 'INSERT INTO #GROSS_INCOME_CPL_TOTAL SELECT'
    IF @IncludeOffice = 1
    BEGIN
      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [OfficeCode],'''' AS [OfficeDescription],'
    END
    IF @IncludeClient = 1
    BEGIN
      SET @sql = @sql + ' [ClientCode],[ClientDescription],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [ClientCode],'''' AS [ClientDescription],'
    END
    IF @IncludeDivision = 1
      OR @IncludeProduct = 1
    BEGIN
      SET @sql = @sql + ' [DivisionCode],[DivisionDescription],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [DivisionCode],'''' AS [DivisionDescription],'
    END
    IF @IncludeProduct = 1
    BEGIN
      SET @sql = @sql + ' [ProductCode],[ProductDescription],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [ProductCode],'''' AS [ProductDescription],'
    END
    IF @IncludeType = 1
    BEGIN
      SET @sql = @sql + ' [Type],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [Type],'
    END
    IF @IncludeSalesClass = 1
    BEGIN
      SET @sql = @sql + ' [SalesClassCode],[SalesClassDescription],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [SalesClassCode],'''' AS [SalesClassDescription],'
    END
    IF @IncludeCampaign = 1
    BEGIN
      SET @sql = @sql + ' [CampaignID],[CampaignCode],[CampaignName],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
    END
    IF @IncludePostPeriod = 1
    BEGIN
      SET @sql = @sql + ' [PostingPeriod],[PostingPeriodYear],[PostingPeriodMonth],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [PostingPeriod],0 AS [PostingPeriodYear],0 AS [PostingPeriodMonth],'
    END
    IF @IncludeYear = 1
    BEGIN
      SET @sql = @sql + ' [Year],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' 0 AS [Year],'
    END
    IF @IncludeAE = 1
    BEGIN
      SET @sql = @sql + ' [DefaultAECode],[DefaultAEName],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [DefaultAECode],'''' AS [DefaultAEName],'
    END
    IF @IncludeProductUDF = 1
    BEGIN
      SET @sql = @sql + ' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
    END
    ELSE
    BEGIN
      SET @sql = @sql + ' '''' AS [ProductUDF1],'''' AS [ProductUDF2],'''' AS [ProductUDF3],'''' AS [ProductUDF4],'
    END

    --if @Summary = 1
    --Begin
    --	set @sql = @sql + '[Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source],[JobNumber],[JobDescription],[JobComponentNumber],[ComponentDescription],JobTypeCode,JobTypeDescription,salesClassFormatCode,ComplexityCode,PromotionCode,ClientReference,
    --			ClientPO,JobAECode,JobAEName,LabelFromUDFTable1,LabelFromUDFTable2,LabelFromUDFTable3,LabelFromUDFTable4,LabelFromUDFTable5,CompLabelFromUDFTable1,CompLabelFromUDFTable2,CompLabelFromUDFTable3,CompLabelFromUDFTable4,CompLabelFromUDFTable5,
    --			'''' AS FunctionCode,'''' AS FunctionConsolidationCode,'''' AS FunctionConsolidation,'''' AS FunctionDescription,'''' AS FunctionHeading,
    --            '''' AS FunctionType,[OrderNumber],[OrderDescription],[LineNumber],[MediaMonth],[MediaYear],[StartDate],[EndDate],'''' AS MarketCode,
    --            '''' AS MarketDescription,'''' AS SalesGLAccountCode,'''' AS SalesGLAccountDescription,'''' AS CostOfSalesGLAccountCode,'''' AS CostOfSalesGLAccountDescription,'
    --End
    --Else
    --Begin
    SET @sql = @sql + '[Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source],[JobNumber],[JobDescription],[JobComponentNumber],[ComponentDescription],JobStatus,JobTypeCode,JobTypeDescription,salesClassFormatCode,ComplexityCode,PromotionCode,ClientReference,
				ClientPO,JobAECode,JobAEName,LabelFromUDFTable1,LabelFromUDFTable2,LabelFromUDFTable3,LabelFromUDFTable4,LabelFromUDFTable5,CompLabelFromUDFTable1,CompLabelFromUDFTable2,CompLabelFromUDFTable3,CompLabelFromUDFTable4,CompLabelFromUDFTable5,
				[FunctionCode],[FunctionConsolidationCode],[FunctionConsolidation],[FunctionDescription],[FunctionHeading],
				[FunctionType],[OrderNumber],[OrderDescription],[LineNumber],[MediaMonth],[MediaYear],[StartDate],[EndDate],[MarketCode],[MarketDescription],[SalesGLAccountCode],[SalesGLAccountDescription],
				[CostOfSalesGLAccountCode],	[CostOfSalesGLAccountDescription],[DirectExpenseGLAccountCode],[DirectExpenseGLAccountDescription],'
    --End


    SET @sql2 = ' ISNULL(SUM([BilledHours]),0),ISNULL(SUM([BilledQuantity]),0),SUM([BilledFee]),SUM([BilledTime]),SUM([BilledCommission]),SUM([BilledCostOfSales]),SUM([BilledIncomeRec]),SUM([EstimatedHours]),SUM([EstimateFee]),SUM([EstimateTime]),SUM([EstimateMarkupAmount]),SUM([EstimatedCostAmount]),SUM([EstimatedTotalAmount]),SUM([ManualSale]),SUM([ManualCOS]),SUM([GLSales]),SUM([GLCostofSales]),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])+SUM([NonbillableAPSales])+SUM([CRClientSales])),
				(SUM([BilledCostOfSales])+SUM([ManualCOS])+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales])),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales])),SUM([Hours]),SUM([DirectServiceCost]),SUM([DirectServiceBillAmount]),SUM([DirectExpense]),SUM([GLDirectExpense]),(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense])),
				(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense])),
				CASE WHEN ' + CAST(@FTEAllocation AS varchar(2)) + ' = 2 THEN SUM(Overhead) ELSE (SUM([DirectServiceCost]) * ' + CAST(@OverheadFactor AS varchar(20)) + ') END,
				CASE WHEN ' + CAST(@FTEAllocation AS varchar(2)) + ' = 2 THEN ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-(SUM(Overhead))) 
				ELSE ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([NonbillableAPSales])+SUM([CRClientSales])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])-SUM([CRClientCostOfSales])-SUM([NonbillableAPCostOfSales]))-(SUM([DirectServiceCost])+SUM([DirectExpense])+SUM([GLDirectExpense])+SUM([CRClientDirectExpense]))-(SUM([DirectServiceCost]) * ' + CAST(@OverheadFactor AS varchar(20)) + ')) END,
				CASE WHEN ' + CAST(@FTE AS varchar(20)) + ' > 0 THEN (SUM([Hours])) / ' + CAST(@FTE AS varchar(20)) + ' ELSE 0 END,SUM([CRClientSales]),SUM([CRClientCostOfSales]),SUM([CRClientDirectExpense]),SUM([NonbillableAPSales]),SUM([NonbillableAPCostOfSales]),SUM([ForecastFee]),SUM([ForecastTime]),SUM([ForecastCommission]),SUM([ForecastCostOfSales]),SUM([ForecastDirectServiceCost]),SUM([ForecastDIrectExpense]),(SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission])),(SUM([ForecastFee])+SUM([ForecastTime])+SUM([ForecastCommission]))-(SUM([ForecastDirectServiceCost])+SUM([ForecastDIrectExpense])),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0, 0'

    SET @sql2 = @sql2 + ' FROM #GROSS_INCOME_CPL '
    IF @RestrictionsOffice > 0
    BEGIN
      SET @sql2 = @sql2 + ' INNER JOIN EMP_OFFICE ON #GROSS_INCOME_CPL.OfficeCode = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
    END

    IF @Restrictions > 0
    BEGIN
      SET @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON #GROSS_INCOME_CPL.ClientCode = SEC_CLIENT.CL_CODE AND #GROSS_INCOME_CPL.DivisionCode = SEC_CLIENT.DIV_CODE AND #GROSS_INCOME_CPL.ProductCode = SEC_CLIENT.PRD_CODE'
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
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],'
    END
    IF @IncludeClient = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [ClientCode],[ClientDescription],'
    END
    IF @IncludeDivision = 1
      OR @IncludeProduct = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [DivisionCode],[DivisionDescription],'
    END
    IF @IncludeProduct = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [ProductCode],[ProductDescription],'
    END
    IF @IncludeType = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [Type],'
    END
    IF @IncludeSalesClass = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [SalesClassCode],[SalesClassDescription],'
    END
    IF @IncludeCampaign = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [CampaignID],[CampaignCode],[CampaignName],'
    END
    IF @IncludePostPeriod = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [PostingPeriod],[PostingPeriodYear],[PostingPeriodMonth],'
    END
    IF @IncludeYear = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [Year],'
    END
    IF @IncludeAE = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [DefaultAECode],[DefaultAEName],'
    END
    IF @IncludeProductUDF = 1
    BEGIN
      SET @sql_groupby = @sql_groupby + ' [ProductUDF1],[ProductUDF2],[ProductUDF3],[ProductUDF4],'
    END

    --if @Summary = 1
    --Begin
    --	set @sql_groupby = @sql_groupby+' [Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source],[JobNumber],[JobDescription],[JobComponentNumber],[ComponentDescription],JobTypeCode,JobTypeDescription,salesClassFormatCode,ComplexityCode,PromotionCode,ClientReference,
    --			ClientPO,JobAECode,JobAEName,LabelFromUDFTable1,LabelFromUDFTable2,LabelFromUDFTable3,LabelFromUDFTable4,LabelFromUDFTable5,CompLabelFromUDFTable1,CompLabelFromUDFTable2,CompLabelFromUDFTable3,CompLabelFromUDFTable4,CompLabelFromUDFTable5,
    --			[OrderNumber],[OrderDescription],[LineNumber],[MediaMonth],[MediaYear],[StartDate],[EndDate]'
    --End
    --Else
    --Begin
    SET @sql_groupby = @sql_groupby + ' [Industry],[Specialty],[RegionCode],[Region],[Revenue],[NumberOfEmployees],[Source],[JobNumber],[JobDescription],[JobComponentNumber],[ComponentDescription],JobStatus,JobTypeCode,JobTypeDescription,salesClassFormatCode,ComplexityCode,PromotionCode,ClientReference,
				ClientPO,JobAECode,JobAEName,LabelFromUDFTable1,LabelFromUDFTable2,LabelFromUDFTable3,LabelFromUDFTable4,LabelFromUDFTable5,CompLabelFromUDFTable1,CompLabelFromUDFTable2,CompLabelFromUDFTable3,CompLabelFromUDFTable4,CompLabelFromUDFTable5,
				[FunctionCode],[FunctionConsolidationCode],[FunctionConsolidation],[FunctionDescription],[FunctionHeading],
				[FunctionType],[OrderNumber],[OrderDescription],[LineNumber],[MediaMonth],[MediaYear],[StartDate],[EndDate],[MarketCode],[MarketDescription],[SalesGLAccountCode],[SalesGLAccountDescription],
				[CostOfSalesGLAccountCode],	[CostOfSalesGLAccountDescription],[DirectExpenseGLAccountCode],[DirectExpenseGLAccountDescription]'
    --End



    IF @sql_groupby <> 'GROUP BY'
    BEGIN
      IF @sql_groupby LIKE '%,'
      BEGIN
        SET @sql_groupby = LEFT(@sql_groupby, LEN(@sql_groupby) - 1)
      END

      -- SELECT @paramlist = '@OverheadFactor decimal(12,3), @FTE decimal(12,3), @FTEAllocation int'
      --SET @sql = @sql+@sql_groupby 
      PRINT @sql2
      EXEC (@sql + @sql2 + @sql_where + @sql_groupby)
    --EXEC sp_executesql N''' + @sql + @sql_groupby + ''', @paramlist, @OverheadFactor, @FTE

    END
    ELSE
    BEGIN
      PRINT @sql
      EXEC (@sql + @sql2 + @sql_where)
    --SELECT @paramlist = '@OverheadFactor decimal(12,3), @FTE decimal(12,3), @FTEAllocation int'

    --EXEC sp_executesql @sql, @paramlist, @OverheadFactor, @FTE
    END
    --SELECT * FROM #GROSS_INCOME_CPL


    DECLARE @Sum decimal(18, 2)

    SET @Sum = 0
    SET @sql = ''

    IF @IncludeOffice = 1
    BEGIN
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS) + SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription]'

      PRINT 'OFFICE'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      --SELECT 'EXEC (@sql+@sql_groupby)'

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalBilledOffice = (SELECT
        [TotalBilledOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalCostOfBillingOffice = (SELECT
        [TotalCostOfBilingOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectExpensesOffice = (SELECT
        [TotalDirectExpensesOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostOffice = (SELECT
        [TotalDirectServiceCostOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalGrossIncomeOffice = (SELECT
        [TotalGrossIncomeOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      DELETE FROM #TOTALS
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS) + SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
      SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription]'
      PRINT 'OFFICE'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostOfficeCurrent = (SELECT
        [TotalDirectServiceCostOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)


      IF @IncludeProduct = 1
      BEGIN
        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],'''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription]'
        PRINT 'PRODUCTOFFICE'
        PRINT @sql
        EXEC (@sql + @sql_groupby)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalBilledClient = (SELECT
          [TotalBilledOfficeClientDivisionProduct]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalCostOfBillingClient = (SELECT
          [TotalCostOfBilingOfficeClientDivisionProduct]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectExpensesClient = (SELECT
          [TotalDirectExpensesClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClient = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalGrossIncomeClient = (SELECT
          [TotalGrossIncomeClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)


        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],'''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
        SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription]'
        PRINT 'PRODUCTOFFICE'
        PRINT @sql
        EXEC (@sql + @sql_groupby)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClientCurrent = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

      END
      ELSE
      BEGIN
        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],'''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription]'

        PRINT 'PRODUCTOFFICE2'
        PRINT @sql
        EXEC (@sql + @sql_groupby)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalBilledClient = (SELECT
          [TotalBilledOfficeClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalCostOfBillingClient = (SELECT
          [TotalCostOfBilingOfficeClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectExpensesClient = (SELECT
          [TotalDirectExpensesClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClient = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalGrossIncomeClient = (SELECT
          [TotalGrossIncomeClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],'''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
        SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription]'
        PRINT 'PRODUCTOFFICE2'
        PRINT @sql
        EXEC (@sql + @sql_groupby)


        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClientCurrent = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      END

    END
    ELSE
    BEGIN
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription]'
      PRINT 'NOOFFICE'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalBilledOffice = (SELECT
        [TotalBilledOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalCostOfBillingOffice = (SELECT
        [TotalCostOfBilingOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectExpensesOffice = (SELECT
        [TotalDirectExpensesOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostOffice = (SELECT
        [TotalDirectServiceCostOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalGrossIncomeOffice = (SELECT
        [TotalGrossIncomeOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)

      DELETE FROM #TOTALS
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
      SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription]'
      PRINT 'NOOFFICE'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostOfficeCurrent = (SELECT
        [TotalDirectServiceCostOffice]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode)
    END

    IF @IncludeClient = 1
      AND @IncludeOffice = 0
      AND @IncludeProduct = 0
    BEGIN
      DELETE FROM #TOTALS
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],'''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' 0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription]'
      PRINT 'CLIENT'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      --SELECT [OfficeCode],[ClientCode],[PostingPeriod], SUM(DirectServiceCost) FROM #GROSS_INCOME_CPL_TOTAL GROUP BY [OfficeCode],[ClientCode],[PostingPeriod]
      --SELECT CASE WHEN [PostingPeriod] = @EndPeriod THEN SUM(DirectServiceCost) ELSE 0 END FROM #GROSS_INCOME_CPL_TOTAL CT GROUP BY [PostingPeriod]
      --SELECT * FROM #TOTALS

      --UPDATE #TOTALS
      --SET TotalDirectServiceCostClientCurrent = (SELECT CASE WHEN [PostingPeriod] = @EndPeriod THEN SUM(DirectServiceCost) ELSE 0 END FROM #GROSS_INCOME_CPL_TOTAL CT WHERE CT.ClientCode = #TOTALS.ClientCode GROUP BY [PostingPeriod])

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalBilledClient = (SELECT
        [TotalBilledClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalCostOfBillingClient = (SELECT
        [TotalCostOfBilingClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectExpensesClient = (SELECT
        [TotalDirectExpensesClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostClient = (SELECT
        [TotalDirectServiceCostClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalGrossIncomeClient = (SELECT
        [TotalGrossIncomeClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)

      DELETE FROM #TOTALS
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],'''','''','''','''','''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' 0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
      SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription]'
      PRINT 'CLIENT'
      PRINT @sql
      EXEC (@sql + @sql_groupby)

      --SELECT * FROM #TOTALS

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostClientCurrent = (SELECT
        [TotalDirectServiceCostClient]
      FROM #TOTALS T
      WHERE T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode)
    END
    ELSE
    BEGIN
      IF @IncludeProduct = 1
        AND @IncludeOffice = 0
      BEGIN

        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],'''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '

        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription]'
        PRINT 'PRODUCT'
        --PRINT @sql
        EXEC (@sql + @sql_groupby)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalBilledClient = (SELECT
          [TotalBilledClientDivisionProduct]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalCostOfBillingClient = (SELECT
          [TotalCostOfBilingClientDivisionProduct]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectExpensesClient = (SELECT
          [TotalDirectExpensesClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClient = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofTotalGrossIncomeClient = (SELECT
          [TotalGrossIncomeClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

        DELETE FROM #TOTALS
        SET @sql = 'INSERT INTO #TOTALS SELECT'

        SET @sql = @sql + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],'''','''','''',0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
        SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
        SET @sql = @sql + ' 0,0,SUM(BilledTotal),0,0,0,0,SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),0,0,0,SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),0,SUM(DirectServiceCost),0,SUM(TotalGrossIncome),0,0,0,0 FROM #GROSS_INCOME_CPL_TOTAL '
        SET @sql = @sql + ' WHERE [PostingPeriod] = ''' + @EndPeriod + ''''
        SET @sql_groupby = ''
        SET @sql_groupby = 'GROUP BY'
        SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription]'
        PRINT 'PRODUCT'
        --PRINT @sql
        EXEC (@sql + @sql_groupby)

        UPDATE #GROSS_INCOME_CPL_TOTAL
        SET SumofDirectServiceCostClientCurrent = (SELECT
          [TotalDirectServiceCostClient]
        FROM #TOTALS T
        WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
        AND T.ClientCode = #GROSS_INCOME_CPL_TOTAL.ClientCode
        AND T.DivisionCode = #GROSS_INCOME_CPL_TOTAL.DivisionCode
        AND T.ProductCode = #GROSS_INCOME_CPL_TOTAL.ProductCode)

      END
    END

    IF @IncludeSalesClass = 1
    BEGIN
      DELETE FROM #TOTALS
      SET @sql = 'INSERT INTO #TOTALS SELECT'

      SET @sql = @sql + ' [OfficeCode],[OfficeDescription],'''','''','''','''','''','''',[Type],[SalesClassCode],[SalesClassDescription],0,'''','''','''',0,0,0,'''','''','''','''','''','''','''','''','''','''',0,0,'''',0,'''',0,'''','
      SET @sql = @sql + ' '''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''','''',0,'''',0,0,0,NULL,NULL,'''','''','''','''','''','''','''','''','
      SET @sql = @sql + ' 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SUM(BilledTotal),SUM(BilledCostOfSales) + sum(ManualCOS)+SUM([GLCostofSales])+SUM([CRClientCostOfSales])+SUM([NonbillableAPCostOfSales]),SUM(DirectExpense) + SUM(GLDirectExpense)+SUM([CRClientDirectExpense]),SUM(DirectServiceCost) FROM #GROSS_INCOME_CPL_TOTAL '

      SET @sql_groupby = ''
      SET @sql_groupby = 'GROUP BY'
      SET @sql_groupby = @sql_groupby + ' [OfficeCode],[OfficeDescription],[Type],[SalesClassCode],[SalesClassDescription]'

      PRINT @sql
      EXEC (@sql + @sql_groupby)

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalBilledSalesClass = (SELECT
        [TotalBilledSalesClass]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
      AND T.SalesClassCode = #GROSS_INCOME_CPL_TOTAL.SalesClassCode
      AND T.[Type] = #GROSS_INCOME_CPL_TOTAL.[Type])

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofTotalCostOfBillingSalesClass = (SELECT
        [TotalCostOfBillingSalesClass]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
      AND T.SalesClassCode = #GROSS_INCOME_CPL_TOTAL.SalesClassCode
      AND T.[Type] = #GROSS_INCOME_CPL_TOTAL.[Type])

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectExpensesSalesClass = (SELECT
        [TotalDirectExpensesSalesClass]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
      AND T.SalesClassCode = #GROSS_INCOME_CPL_TOTAL.SalesClassCode
      AND T.[Type] = #GROSS_INCOME_CPL_TOTAL.[Type])

      UPDATE #GROSS_INCOME_CPL_TOTAL
      SET SumofDirectServiceCostSalesClass = (SELECT
        [TotalDirectServiceCostSalesClass]
      FROM #TOTALS T
      WHERE T.OfficeCode = #GROSS_INCOME_CPL_TOTAL.OfficeCode
      AND T.SalesClassCode = #GROSS_INCOME_CPL_TOTAL.SalesClassCode
      AND T.[Type] = #GROSS_INCOME_CPL_TOTAL.[Type])

    END /* END WHILE */


    --UPDATE #GROSS_INCOME_CPL_TOTAL
    --SET SumofDirectExpenses = (SELECT SUM(DirectExpense) + SUM(GLDirectExpense) FROM #GROSS_INCOME_CPL_TOTAL)

    --SELECT * FROM #TOTALS
    --SELECT * FROM #GROSS_INCOME_CPL_TOTAL

    --INSERT INTO TEMP...
    IF @cnt = 1
    BEGIN
      SELECT
        ID,
        OfficeCode,
        OfficeDescription,
        ClientCode,
        ClientDescription,
        DivisionCode,
        DivisionDescription,
        ProductCode,
        ProductDescription,
        DefaultAECode,
        DefaultAEName,
        ProductUDF1,
        ProductUDF2,
        ProductUDF3,
        ProductUDF4,
        [Industry],
        [Specialty],
        [RegionCode],
        [Region],
        [Revenue],
        [NumberOfEmployees],
        [Source],
        [Type],
        SalesClassCode,
        SalesClassDescription,
        CampaignID,
        CampaignCode,
        CampaignName,
        PostingPeriod,
        PostingPeriodYear,
        PostingPeriodMonth,
        [Year],
        JobNumber,
        JobDescription,
        JobComponentNumber,
        ComponentDescription,
        JobStatus,
        JobTypeCode,
        JobTypeDescription,
        SalesClassFormatCode,
        ComplexityCode,
        PromotionCode,
        ClientReference,
        ClientPO,
        JobAECode,
        JobAEName,
        LabelFromUDFTable1,
        LabelFromUDFTable2,
        LabelFromUDFTable3,
        LabelFromUDFTable4,
        LabelFromUDFTable5,
        CompLabelFromUDFTable1,
        CompLabelFromUDFTable2,
        CompLabelFromUDFTable3,
        CompLabelFromUDFTable4,
        CompLabelFromUDFTable5,
        FunctionCode,
        FunctionConsolidationCode,
        FunctionConsolidation,
        FunctionDescription,
        FunctionHeading,
        FunctionType,
        OrderNumber,
        OrderDescription,
        LineNumber,
        MediaMonth,
        MediaYear,
        StartDate,
        EndDate,
        MarketCode,
        MarketDescription,
        SalesGLAccountCode,
        SalesGLAccountDescription,
        CostOfSalesGLAccountCode,
        CostOfSalesGLAccountDescription,
        DirectExpenseGLAccountCode,
        DirectExpenseGLAccountDescription,
        BilledHours,
        BilledQuantity,
        BilledFee,
        BilledTime,
        BilledCommission,
        BilledCostOfSales,
        BilledIncomeRec,
        EstimatedHours,
        EstimateFee,
        EstimateTime,
        EstimateMarkupAmount,
        EstimatedCostAmount,
        EstimatedTotalAmount,
        ManualSale,
        ManualCOS,
        GLSales,
        GLCostOfSales,
        BilledTotal,
        BilledCostTotal,
        TotalGrossIncome,
        [Hours],
        DirectServiceCost,
        DirectServiceBillAmount,
        DirectExpense,
        GLDirectExpense,
        TotalDirectCosts,
        TotalIncome,
        Overhead,
        IncomeLessOverhead,
        FTE,
        CRClientSales,
        CRClientCostOfSales,
        CRClientDirectExpense,
        NonbillableAPSales,
        NonbillableAPCostOfSales,
        ForecastFee,
        ForecastTime,
        ForecastCommission,
        ForecastCostOfSales,
        ForecastDirectServiceCost,
        ForecastDirectExpense,
        ForecastGrossIncome,
        ForecastIncome,
        SumofTotalBilledOffice,
        SumofTotalBilledClient,
        SumofTotalCostOfBillingOffice,
        SumofTotalCostOfBillingClient,
        SumofDirectExpensesOffice,
        SumofDirectExpensesClient,
        SumofDirectServiceCostOffice,
        SumofDirectServiceCostOfficeCurrent,
        SumofDirectServiceCostClient,
        SumofDirectServiceCostClientCurrent,
        SumofTotalGrossIncomeOffice,
        SumofTotalGrossIncomeClient,
        SumofTotalBilledSalesClass,
        SumofTotalCostOfBillingSalesClass,
        SumofDirectExpensesSalesClass,
        SumofDirectServiceCostSalesClass,
		SumofIncomeLessOverheadClient
	  INTO #Temp
      FROM #GROSS_INCOME_CPL_TOTAL
    --ORDER BY JobNumber 
    END

    SET @cnt = @cnt + 1

    DROP TABLE #GROSS_INCOME_CPL;
    DROP TABLE #GROSS_INCOME_CPL_TOTAL;
    DROP TABLE #CPL_OH_AMOUNTS;
    DROP TABLE #CPL_OH_AMOUNTS_DETAIL;
    DROP TABLE #CPL_OH_AMOUNTS_TOTAL;
    DROP TABLE #CPL_OH_AMOUNTS_DSC_PERC;
    DROP TABLE #CPL_OH_AMOUNTS_OVERHEAD;

    DROP TABLE #CPL_OH_ACCOUNTS;
    DROP TABLE #CPL_OH_OFFICES;
    DROP TABLE #TOTALS;

  END /* While End */

  IF @max_cnt = 1 BEGIN
	  SELECT *,
		NULL StartPeriod, NULL EndPeriod, NULL PeriodClientBilledTotal, NULL PeriodClientTotalGrossIncome, NULL PeriodClientNetProfit
		--NULL StartPeriod1, NULL EndPeriod1, NULL Period1ClientBilledTotal, NULL Period1ClientTotalGrossIncome, NULL Period1ClientNetProfit,
		--NULL StartPeriod2, NULL EndPeriod2, NULL Period2ClientBilledTotal, NULL Period2ClientTotalGrossIncome, NULL Period2ClientNetProfit
	  FROM #Temp
	  ORDER BY JobNumber  
  END

 -- IF @max_cnt = 2 BEGIN

	--UPDATE #Temp
	--SET SumofIncomeLessOverheadClient = (SELECT
	--	SUM([IncomeLessOverhead])
	--FROM #Temp B
	--WHERE B.ClientCode = #Temp.ClientCode)

	--UPDATE #Temp1
	--SET SumofIncomeLessOverheadClient = (SELECT
	--	SUM([IncomeLessOverhead])
	--FROM #Temp1 B
	--WHERE B.ClientCode = #Temp1.ClientCode)

	--SELECT Distinct A.*,
	--	@MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod, A.SumofTotalBilledClient PeriodClientBilledTotal, A.SumofTotalGrossIncomeClient PeriodClientTotalGrossIncome, A.SumofIncomeLessOverheadClient PeriodClientNetProfit,
	--	@StartPeriod1 StartPeriod1, @EndPeriod1 EndPeriod1, B.SumofTotalBilledClient Period1ClientBilledTotal, B.SumofTotalGrossIncomeClient Period1ClientTotalGrossIncome, B.SumofIncomeLessOverheadClient Period1ClientNetProfit,
	--	NULL StartPeriod2, NULL EndPeriod2, NULL Period2ClientBilledTotal, NULL Period2ClientTotalGrossIncome, NULL Period2ClientTotalOverhead, NULL Period2ClientNetProfit
	--FROM #Temp A   
	--	LEFT JOIN (SELECT DISTINCT A.OfficeCode, A.ClientCode, SumofTotalBilledClient, SumofTotalGrossIncomeClient, SumofIncomeLessOverheadClient FROM #Temp1 A 
	--	) B 
	--	ON A.OfficeCode = B.OfficeCode AND A.ClientCode = B.ClientCode
	--ORDER BY A.OfficeCode, A.ClientCode, A.JobNumber, A.OrderNumber, A.LineNumber

 -- END

 -- IF @max_cnt = 3 BEGIN

	--UPDATE #Temp
	--SET SumofIncomeLessOverheadClient = (SELECT
	--	SUM([IncomeLessOverhead])
	--FROM #Temp B
	--WHERE B.ClientCode = #Temp.ClientCode)

	--UPDATE #Temp1
	--SET SumofIncomeLessOverheadClient = (SELECT
	--	SUM([IncomeLessOverhead])
	--FROM #Temp1 B
	--WHERE B.ClientCode = #Temp1.ClientCode)

	--UPDATE #Temp2
	--SET SumofIncomeLessOverheadClient = (SELECT
	--	SUM([IncomeLessOverhead])
	--FROM #Temp1 B
	--WHERE B.ClientCode = #Temp2.ClientCode)

	----SELECT DISTINCT OfficeCode, ClientCode, SumofTotalBilledClient, SumofTotalGrossIncomeClient, SumofOverheadClient FROM #Temp2

	--SELECT Distinct A.*,
	--	@MinStartPeriod StartPeriod, @MaxEndPeriod EndPeriod, A.SumofTotalBilledClient PeriodClientBilledTotal, A.SumofTotalGrossIncomeClient PeriodClientTotalGrossIncome, A.SumofIncomeLessOverheadClient PeriodClientNetProfit,
	--	@StartPeriod1 StartPeriod1, @EndPeriod1 EndPeriod1, B.SumofTotalBilledClient Period1ClientBilledTotal, B.SumofTotalGrossIncomeClient Period1ClientTotalGrossIncome, B.SumofIncomeLessOverheadClient Period1ClientNetProfit,
	--	@StartPeriod2 StartPeriod2, @EndPeriod2 EndPeriod2, C.SumofTotalBilledClient Period2ClientBilledTotal, C.SumofTotalGrossIncomeClient Period2ClientTotalGrossIncome, C.SumofIncomeLessOverheadClient Period2ClientNetProfit
	--FROM #Temp A   
	--LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofTotalBilledClient, SumofTotalGrossIncomeClient, SumofIncomeLessOverheadClient FROM #Temp1  
	--	) B 
	--	ON A.OfficeCode = B.OfficeCode AND A.ClientCode = B.ClientCode
	--LEFT JOIN (SELECT DISTINCT OfficeCode, ClientCode, SumofTotalBilledClient, SumofTotalGrossIncomeClient, SumofIncomeLessOverheadClient FROM #Temp2  
	--	) C
	--	ON A.OfficeCode = C.OfficeCode AND A.ClientCode = C.ClientCode
	--ORDER BY A.OfficeCode, A.ClientCode, A.JobNumber, A.OrderNumber, A.LineNumber

 -- END



GO

GRANT EXECUTE ON [usp_wv_Gross_Income_CPL_Detail] TO PUBLIC AS dbo

GO