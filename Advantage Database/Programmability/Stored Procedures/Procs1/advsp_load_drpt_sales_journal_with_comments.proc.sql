CREATE PROCEDURE [dbo].[advsp_load_drpt_sales_journal_with_comments]
	@StartingPostPeriodCode varchar(6),
	@EndingPostPeriodCode varchar(6),
	@BreakoutCoOpBilling bit,
	@PeriodType smallint,
	@StartingInvoiceDate varchar(12),
	@EndingInvoiceDate varchar(12),
	@OFFICE_LIST varchar(MAX) = NULL,
	@CLIENT_LIST varchar(MAX) = NULL,
	@DIVISION_LIST varchar(MAX) = NULL,
	@PRODUCT_LIST varchar(MAX) = NULL,
	@USER_CODE AS varchar(100)
AS

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	if @StartingInvoiceDate = ''
	Begin
		SET @StartingInvoiceDate = NULL
	End
	if @EndingInvoiceDate = ''
	Begin
		SET @EndingInvoiceDate = NULL
	End

		DECLARE @RESTRICTIONS INT
	
		SELECT @RESTRICTIONS = COUNT(*) FROM dbo.SEC_CLIENT WHERE SEC_CLIENT.[USER_ID] = @USER_CODE

	CREATE TABLE #GL_ACCOUNTS
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[GLACODE] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[GLADESC] varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
	);

	INSERT INTO #GL_ACCOUNTS
	SELECT GLACODE, GLADESC FROM GLACCOUNT

	if @RESTRICTIONS > 0
	BEGIN
		SELECT [ID] = NEWID(),
	   [OfficeCode],
		[OfficeName],
		[ClientCode],
		[ClientName],
		[ClientAddress],
		[ClientAddress2],
		[ClientCity],
		[ClientCounty],
		[ClientState],
		[ClientZip],
		[ClientCountry],
		[ClientBillingAddress],
		[ClientBillingAddress2],
		[ClientBillingCity],
		[ClientBillingCounty],
		[ClientBillingState],
		[ClientBillingZip],
		[ClientBillingCountry],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductName],
		[ProductBillingAddress],
		[ProductBillingAddress2],
		[ProductBillingCity],
		[ProductBillingCounty],
		[ProductBillingState],
		[ProductBillingZip],
		[ProductBillingCountry],
		[DefaultAECode],
		[DefaultAEName],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[ARPostPeriod],
		[ARPostPeriodStartDate],
		[ARPostPeriodEndDate],
		[ARPostPeriodDescription],
		[ARPostPeriodGLMonth],
		[ARPostPeriodGLYear],
		[SalePostPeriod],
		[SalePostPeriodStartDate],
		[SalePostPeriodEndDate],
		[SalePostPeriodDescription],
		[SalePostPeriodGLMonth],
		[SalePostPeriodGLYear],
		[InvoiceDate],
		[InvoiceNumber],
		[InvoiceSEQ],
		[InvoiceType],
		[InvoiceDescription],
		[InvoiceAssignBy],
		[InvoiceCategory],
		[InvoiceDueDate],
		[MediaType],
		[MediaTypeDescription],
		[ManualFlag],
		[SalesClassCode],
		[SalesClassDescription],
		[CampaignID],
		[CampaignCode],
		[CampaignName],
		[ClientPO],		
		[AccountExecutiveCode],
		[AccountExecutive],
		[JobNumber],
		[JobDescription],
		[JobComponent],
		[JobComponentDescription],
		[FunctionType],
		[FunctionCode],
		[FunctionDescription],
		[FunctionHeadingDescription],
		[OrderNumber],
		[OrderLine],
		[MediaMonth],
		[MediaYear],
		[MediaStartDate],
		[MediaEndDate],
		[MediaMarket],
		[MediaMarketDescription],
		[InvoiceTotal],
		[Sales],
		[CostOfSales],
		[GrossIncome],
		CASE WHEN MediaType = 'P' THEN [DeferredSales] ELSE [DeferredSalesAR] - [DeferredSales] END AS [DeferredSales],
		CASE WHEN MediaType = 'P' THEN [DeferredCostOfSales] ELSE [DeferredCostOfSalesAR] - [DeferredCostOfSales] END AS [DeferredCostOfSales],
		CASE WHEN MediaType = 'P' THEN [DeferredGrossIncome] ELSE [DeferredGrossIncomeAR] - [DeferredGrossIncome] END AS [DeferredGrossIncome],
		[HoursOrQuantity],
		[Time],
		[IncomeOnly],
		[Commission],
		[Cost],
		[VendorTax],
		[MediaNetCharge],
		[MediaRebate],
		[MediaAdditionalCharge],
		[MediaDiscount],
		[AdvanceIncome],
		[AdvanceCommission],
		[AdvanceCost],
		[AdvanceRetainedSales],
		[AdvanceNonresaleAmount],
		[TotalBillLessResaleTax],
		[CityTax],
		[CountyTax],
		[StateTax],
		[ResaleTax],
		[TotalBill],
		[TaxAtBilling],
		[TaxCode],
		[CityTaxPct],
		[CountyTaxPct],
		[StateTaxPct],
		[GLXACT],
		[GLXACTDeferred],
		[GLAccountAR],
		[GLAccountARDescription],
		[GLAccountSales],
		[GLAccountSalesDescription],
		[GLAccountDeferredSales],
		[GLAccountDeferredSalesDescription],
		[GLAccountCostOfSales],
		[GLAccountCostOfSalesDescription],
		[GLAccountAccruedAP],
		[GLAccountAccruedAPDescription],
		[GLAccountAccruedCOS],
		[GLAccountAccruedCOSDescription],
		[GLAccountWIP],
		[GLAccountWIPDescription],
		[GLAccountCityTax],
		[GLAccountCityTaxDescription],
		[GLAccountCountyTax],
		[GLAccountCountyTaxDescription],
		[GLAccountStateTax],
		[GLAccountStateTaxDescription],
		[Converted],
		[OrderDescription],
		[VendorCode],
		[VendorName],
		[CreateDate],
		[UserID],
		[IsVoided],
		[VoidComment],
		[FiscalMonth],
		[BillingComment],
		[BillingJobComment],
		[BillingDetailComment],
		[BillingApprovalClientComment],
		[BillingApprovalFunctionComment],
		[CampaignComments],
		[ClientReference],
		[JobComment],
		[JobComponentComment],
		[EstimateNumber],
		[EstimateComponentNumber],
		[EstimateComment],
		[EstimateComponentComment],
		[EstimateQuoteComment],
		[EstimateRevisionComment],
		[EstimateFunctionComment],
		[InvoiceFooterComment],
		[BillingAddress],
		[JobTypeCode],
		[JobTypeDescription],
		[JobMediaDateToBill]
FROM (
	SELECT 		
		[OfficeCode] = SJ.[OfficeCode],
		[OfficeName] = SJ.[OfficeName],
		[ClientCode] = SJ.[ClientCode],
		[ClientName] = SJ.[ClientName],
		[ClientAddress] = SJ.[ClientAddress],
		[ClientAddress2] = SJ.[ClientAddress2],
		[ClientCity] = SJ.[ClientCity],
		[ClientCounty] = SJ.[ClientCounty],
		[ClientState] = SJ.[ClientState],
		[ClientZip] = SJ.[ClientZip],
		[ClientCountry] = SJ.[ClientCountry],
		[ClientBillingAddress] = SJ.[ClientBillingAddress],
		[ClientBillingAddress2] = SJ.[ClientBillingAddress2],
		[ClientBillingCity] = SJ.[ClientBillingCity],
		[ClientBillingCounty] = SJ.[ClientBillingCounty],
		[ClientBillingState] = SJ.[ClientBillingState],
		[ClientBillingZip] = SJ.[ClientBillingZip],
		[ClientBillingCountry] = SJ.[ClientBillingCountry],
		[DivisionCode] = SJ.[DivisionCode],
		[DivisionName] = SJ.[DivisionName],
		[ProductCode] = SJ.[ProductCode],
		[ProductName] = SJ.[ProductName],
		[ProductBillingAddress] = SJ.[ProductBillingAddress],
		[ProductBillingAddress2] = SJ.[ProductBillingAddress2],
		[ProductBillingCity] = SJ.[ProductBillingCity],
		[ProductBillingCounty] = SJ.[ProductBillingCounty],
		[ProductBillingState] = SJ.[ProductBillingState],
		[ProductBillingZip] = SJ.[ProductBillingZip],
		[ProductBillingCountry] = SJ.[ProductBillingCountry],
		[DefaultAECode] = SJ.[DefaultAECode],
		[DefaultAEName] = SJ.[DefaultAEName],
		[ProductUDF1] = SJ.[ProductUDF1],
		[ProductUDF2] = SJ.[ProductUDF2],
		[ProductUDF3] = SJ.[ProductUDF3],
		[ProductUDF4] = SJ.[ProductUDF4],
		[ARPostPeriod] = SJ.[ARPostPeriod],
		[ARPostPeriodStartDate] = SJ.[ARPostPeriodStartDate],
		[ARPostPeriodEndDate] = SJ.[ARPostPeriodEndDate],
		[ARPostPeriodDescription] = SJ.[ARPostPeriodDescription],
		[ARPostPeriodGLMonth] = SJ.[ARPostPeriodGLMonth],
		[ARPostPeriodGLYear] = SJ.[ARPostPeriodGLYear],
		[SalePostPeriod] = SJ.[SalePostPeriod],
		[SalePostPeriodStartDate] = SJ.[SalePostPeriodStartDate],
		[SalePostPeriodEndDate] = SJ.[SalePostPeriodEndDate],
		[SalePostPeriodDescription] = SJ.[SalePostPeriodDescription],
		[SalePostPeriodGLMonth] = SJ.[SalePostPeriodGLMonth],
		[SalePostPeriodGLYear] = SJ.[SalePostPeriodGLYear],
		[InvoiceDate] = SJ.[InvoiceDate],
		[InvoiceNumber] = SJ.[InvoiceNumber],
		[InvoiceSEQ] = SJ.[InvoiceSEQ],
		[InvoiceType] = SJ.[InvoiceType],
		[InvoiceDescription] = SJ.[InvoiceDescription],
		[InvoiceAssignBy] = SJ.[InvoiceAssignBy],
		[InvoiceCategory] = SJ.[InvoiceCategory],
		[InvoiceDueDate] = SJ.[InvoiceDueDate],
		[MediaType] = SJ.[MediaType],
		[MediaTypeDescription] = SJ.[MediaTypeDescription],
		[ManualFlag] = SJ.[ManualFlag],
		[SalesClassCode] = SJ.[SalesClassCode],
		[SalesClassDescription] = SJ.[SalesClassDescription],
		[CampaignID] = SJ.[CampaignID],
		[CampaignCode] = SJ.[CampaignCode],
		[CampaignName] = SJ.[CampaignName],
		[ClientPO] = SJ.[ClientPO],		
		[AccountExecutiveCode] = SJ.[AccountExecutiveCode],
		[AccountExecutive] = SJ.[AccountExecutive],
		[JobNumber] = SJ.[JobNumber],
		[JobDescription] = SJ.[JobDescription],
		[JobComponent] = SJ.[JobComponent],
		[JobComponentDescription] = SJ.[JobComponentDescription],
		[FunctionType] = SJ.[FunctionType],
		[FunctionCode] = SJ.[FunctionCode],
		[FunctionDescription] = SJ.[FunctionDescription],
		[FunctionHeadingDescription] = SJ.[FunctionHeadingDescription],
		[OrderNumber] = SJ.[OrderNumber],
		[OrderLine] = SJ.[OrderLine],
		[MediaMonth] = CAST(SJ.[MediaMonth] AS smallint),
		[MediaYear] = SJ.[MediaYear],
		[MediaStartDate] = SJ.[MediaStartDate],
		[MediaEndDate] = SJ.[MediaEndDate],
		[MediaMarket] = SJ.[MediaMarket],
		[MediaMarketDescription] = SJ.[MediaMarketDescription],
		[InvoiceTotal] = SJ.[InvoiceTotal],
		[Sales] = SJ.[Sales],
		[CostOfSales] = SJ.[CostOfSales],
		[GrossIncome] = SJ.[GrossIncome],
		[DeferredSales] = SJ.[DeferredSales],
		[DeferredSalesAR] = SJ.[DeferredSalesAR],
		[DeferredCostOfSales] = SJ.[DeferredCostOfSales],
		[DeferredCostOfSalesAR] = SJ.[DeferredCostOfSalesAR],
		[DeferredGrossIncome] = SJ.[DeferredGrossIncome],
		[DeferredGrossIncomeAR] = SJ.[DeferredGrossIncomeAR],
		[HoursOrQuantity] = SJ.[HoursOrQuantity],
		[Time] = SJ.[Time],
		[IncomeOnly] = SJ.[IncomeOnly],
		[Commission] = SJ.[Commission],
		[Cost] = SJ.[Cost],
		[VendorTax] = SJ.[VendorTax],
		[MediaNetCharge] = SJ.[MediaNetCharge],
		[MediaRebate] = SJ.[MediaRebate],
		[MediaAdditionalCharge] = SJ.[MediaAdditionalCharge],
		[MediaDiscount] = SJ.[MediaDiscount],
		[AdvanceIncome] = SJ.[AdvanceIncome],
		[AdvanceCommission] = SJ.[AdvanceCommission],
		[AdvanceCost] = SJ.[AdvanceCost],
		[AdvanceRetainedSales] = SJ.[AdvanceRetainedSales],
		[AdvanceNonresaleAmount] =SJ.[AdvanceNonresaleAmount],
		[TotalBillLessResaleTax] = SJ.[TotalBillLessResaleTax],
		[CityTax] = SJ.[CityTax],
		[CountyTax] = SJ.[CountyTax],
		[StateTax] = SJ.[StateTax],
		[ResaleTax] = SJ.[ResaleTax],
		[TotalBill] = SJ.[TotalBill],
		[TaxAtBilling] = SJ.[TaxAtBilling],
		[TaxCode] = SJ.[TaxCode],
		[CityTaxPct] = SJ.[CityTaxPct],
		[CountyTaxPct] = SJ.[CountyTaxPct],
		[StateTaxPct] = SJ.[StateTaxPct],
		[GLXACT] = SJ.[GLXACT],
		[GLXACTDeferred] = SJ.[GLXACTDeferred],
		[GLAccountAR] = SJ.[GLAccountAR],
		[GLAccountARDescription] = SJ.[GLAccountARDescription],
		[GLAccountSales] = SJ.[GLAccountSales],
		[GLAccountSalesDescription] = SJ.[GLAccountSalesDescription],
		[GLAccountDeferredSales] = SJ.[GLAccountDeferredSales],
		[GLAccountDeferredSalesDescription] = SJ.[GLAccountDeferredSalesDescription],
		[GLAccountCostOfSales] = SJ.[GLAccountCostOfSales],
		[GLAccountCostOfSalesDescription] = SJ.[GLAccountCostOfSalesDescription],
		[GLAccountAccruedAP] = SJ.[GLAccountAccruedAP],
		[GLAccountAccruedAPDescription] = SJ.[GLAccountAccruedAPDescription],
		[GLAccountAccruedCOS] = SJ.[GLAccountAccruedCOS],
		[GLAccountAccruedCOSDescription] = SJ.[GLAccountAccruedCOSDescription],
		[GLAccountWIP] = SJ.[GLAccountWIP],
		[GLAccountWIPDescription] = SJ.[GLAccountWIPDescription],
		[GLAccountCityTax] = SJ.[GLAccountCityTax],
		[GLAccountCityTaxDescription] = SJ.[GLAccountCityTaxDescription],
		[GLAccountCountyTax] = SJ.[GLAccountCountyTax],
		[GLAccountCountyTaxDescription] = SJ.[GLAccountCountyTaxDescription],
		[GLAccountStateTax] = SJ.[GLAccountStateTax],
		[GLAccountStateTaxDescription] = SJ.[GLAccountStateTaxDescription],
		[Converted] = SJ.[Converted],
		[OrderDescription] = VMH.ORDER_DESC,
		[VendorCode] = VMH.VN_CODE,
		[VendorName] = V.VN_NAME,
		[CreateDate] = SJ.CreateDate,
		[UserID] = SJ.UserID,
		[IsVoided] = CASE WHEN SJ.IsVoided = 1 THEN 'Yes' ELSE 'No' END,
		[VoidComment] = SJ.VoidComment,
		[FiscalMonth] = (SELECT TOP 1 [FISCALMTH] FROM [dbo].[GLCONFIG]),
		[BillingComment] = SJ.[BillingComment],
		[BillingJobComment] = SJ.[BillingJobComment],
		[BillingDetailComment] = SJ.[BillingDetailComment],
		[BillingApprovalClientComment] = SJ.[BillingApprovalClientComment],
		[BillingApprovalFunctionComment] = SJ.[BillingApprovalFunctionComment],
		[CampaignComments] = SJ.[CampaignComments],
		[ClientReference] = SJ.[ClientReference],
		[JobComment] = SJ.[JobComment],
		[JobComponentComment] = SJ.[JobComponentComment],
		[EstimateNumber] = SJ.[EstimateNumber],
		[EstimateComponentNumber] = SJ.[EstimateComponentNumber],
		[EstimateComment] = SJ.[EstimateComment],
		[EstimateComponentComment] = SJ.[EstimateComponentComment],
		[EstimateQuoteComment] = SJ.[EstimateQuoteComment],
		[EstimateRevisionComment] = SJ.[EstimateRevisionComment],
		[EstimateFunctionComment] = SJ.[EstimateFunctionComment],
		[InvoiceFooterComment] = SJ.[InvoiceFooterComment],
		[BillingAddress] = SJ.[BillingAddress],		
		[JobTypeCode] = SJ.[JobTypeCode],
		[JobTypeDescription] = SJ.[JobTypeDescription],
		[JobMediaDateToBill] = SJ.[JobMediaDateToBill]
	FROM
		(SELECT
			[OfficeCode] = ARS.OFFICE_CODE,
			[OfficeName] = O.OFFICE_NAME,
			[ClientCode] = ARS.CL_CODE,
			[ClientName] = C.CL_NAME,
			[ClientAddress] = C.CL_ADDRESS1,
			[ClientAddress2] = C.CL_ADDRESS2,
			[ClientCity] = C.CL_CITY,
			[ClientCounty] = C.CL_COUNTY,
			[ClientState] = C.CL_STATE,
			[ClientZip] = C.CL_ZIP,
			[ClientCountry] = C.CL_COUNTRY,
			[ClientBillingAddress] = C.CL_BADDRESS1,
			[ClientBillingAddress2] = C.CL_BADDRESS2,
			[ClientBillingCity] = C.CL_BCITY,
			[ClientBillingCounty] = C.CL_BCOUNTY,
			[ClientBillingState] = C.CL_BSTATE,
			[ClientBillingZip] = C.CL_BZIP,
			[ClientBillingCountry] = C.CL_BCOUNTRY,
			[DivisionCode] = ARS.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = ARS.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[ProductBillingAddress] = P.PRD_BILL_ADDRESS1,
			[ProductBillingAddress2] = P.PRD_BILL_ADDRESS2,
			[ProductBillingCity] = P.PRD_BILL_CITY,
			[ProductBillingCounty] = P.PRD_BILL_COUNTY,
			[ProductBillingState] = P.PRD_BILL_STATE,
			[ProductBillingZip] = P.PRD_BILL_ZIP,
			[ProductBillingCountry] = P.PRD_BILL_COUNTRY,
			[DefaultAECode] = ISNULL(AE.EMP_CODE,''),
			[DefaultAEName] = COALESCE((RTRIM(EMPAE.EMP_FNAME)+' '),'')+COALESCE((EMPAE.EMP_MI+'. '),'')+COALESCE(EMPAE.EMP_LNAME,''),
			[ProductUDF1] = ISNULL(P.USER_DEFINED1,''),
			[ProductUDF2] = ISNULL(P.USER_DEFINED2,''),
			[ProductUDF3] = ISNULL(P.USER_DEFINED3,''),
			[ProductUDF4] = ISNULL(P.USER_DEFINED4,''),
			[ARPostPeriod] =  AR.AR_POST_PERIOD,
			[SalePostPeriod] = ARS.SALE_POST_PERIOD,
			[ARPostPeriodStartDate] = PP.PPSRTDATE,
			[ARPostPeriodEndDate] = PP.PPENDDATE,
			[ARPostPeriodDescription] = PP.PPDESC,
			[ARPostPeriodGLMonth] = PP.PPGLMONTH,
			[ARPostPeriodGLYear] = PP.PPGLYEAR,
			[SalePostPeriodStartDate] = PPS.PPSRTDATE,
			[SalePostPeriodEndDate] = PPS.PPENDDATE,
			[SalePostPeriodDescription] = PPS.PPDESC,
			[SalePostPeriodGLMonth] = PPS.PPGLMONTH,
			[SalePostPeriodGLYear] = PPS.PPGLYEAR,
			[InvoiceDate] = AR.AR_INV_DATE,
			[InvoiceNumber] = ARS.AR_INV_NBR,
			[InvoiceSEQ] = ARS.AR_INV_SEQ,
			[InvoiceType] = ARS.AR_TYPE,
			[InvoiceDescription] = AR.AR_DESCRIPTION,
			[InvoiceAssignBy] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'P' AND ARS.JOB_NUMBER IS NOT NULL THEN 
										CASE WHEN INV_BY = 1 THEN 'Job'
										     WHEN INV_BY = 2 THEN 'Job Component'
											 WHEN INV_BY = 3 THEN 'Product/Sales Class'
											 WHEN INV_BY = 4 THEN 'Campaign'
											 WHEN INV_BY = 5 THEN 'Product/Client PO'
											 WHEN INV_BY = 6 THEN 'Client'
											 WHEN INV_BY = 7 THEN 'Division'
											 WHEN INV_BY = 8 THEN 'Product' ELSE '' END
									 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.JOB_NUMBER IS NULL THEN
									    CASE WHEN INV_BY = 1 THEN 'Sales Class'
										     WHEN INV_BY = 2 THEN 'Product/Client PO'
											 WHEN INV_BY = 3 THEN 'Market'
											 WHEN INV_BY = 4 THEN 'Order'
											 WHEN INV_BY = 5 THEN 'Campaign'
											 WHEN INV_BY = 6 THEN 'Media Type' ELSE '' END ELSE '' END,
			[InvoiceCategory] = ARDD.INV_CAT_DESC,
			[InvoiceDueDate] = ARDD.AR_INV_DUE_DATE,
			[MediaType] = ISNULL(ARS.MEDIA_TYPE, 'P'),
			[MediaTypeDescription] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'P' THEN 'Production'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'M' THEN 'Magazine'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'N' THEN 'Newspaper'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'O' THEN 'Outdoor'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'I' THEN 'Internet'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'R' THEN 'Radio'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'T' THEN 'Television' ELSE 'Production' END,
			[ManualFlag] = 'No',
			[SalesClassCode] = ARS.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[CampaignID] = ARS.CMP_IDENTIFIER,
			[CampaignCode] = CAMP.CMP_CODE,
			[CampaignName] = CAMP.CMP_NAME,
			[ClientPO] = ARS.CLIENT_PO,
			[AccountExecutiveCode] = JC.EMP_CODE,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
			[JobNumber] = ARS.JOB_NUMBER,
			[JobDescription] = J.JOB_DESC,
			[JobComponent] = ARS.JOB_COMPONENT_NBR,
			[JobComponentDescription] = JC.JOB_COMP_DESC,
			[FunctionType] = ARS.FNC_TYPE,
			[FunctionCode] = ARS.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionHeadingDescription] = FH.FNC_HEADING_DESC,
			[OrderNumber] = ARS.ORDER_NBR,
			[OrderLine] = ARS.ORDER_LINE_NBR,
			[MediaMonth] = ARS.MEDIA_MONTH,
			[MediaYear] = ARS.MEDIA_YEAR,
			[MediaStartDate] = ARS.[START_DATE],
			[MediaEndDate] = ARS.END_DATE,
			[MediaMarket] = ARS.MARKET_CODE,
			[MediaMarketDescription] = M.MARKET_DESC,
			[InvoiceTotal] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(AR.AR_INV_AMOUNT, 0)
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(AR.AR_INV_AMOUNT, 0) ELSE 0 END,
			--[Sales] = 0,
			--[CostOfSales] = 0,
			--[GrossIncome] = 0,
			--[DeferredSales] = 0,
			--[DeferredCostOfSales] = 0,
			--[DeferredGrossIncome] = 0,
			--[Sales] = CASE WHEN ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN
			--			CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
			--			   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' THEN 0	
			--			   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END
			--			END,

			[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
						   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0	
						   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[CostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)
								 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0
								   ELSE ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0) END,
			[GrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN (ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))) - (ARS.COST_AMT + ARS.NET_CHARGE_AMT + ARS.NON_RESALE_AMT + ARS.AB_COST_AMT)
								 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0
								 ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) END,
			[DeferredSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
								   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COMMISSION_AMT, 0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0)
								   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredSalesAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
								   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COMMISSION_AMT, 0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0)
								   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredCostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0)
										 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredCostOfSalesAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0)
										 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredGrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0))
										 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,			
			[DeferredGrossIncomeAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0))
										 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
			--			   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[CostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)
			--					 ELSE ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0) END,
			--[GrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN (ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))) - (ARS.COST_AMT + ARS.NET_CHARGE_AMT + ARS.NON_RESALE_AMT + ARS.AB_COST_AMT)
			--					 ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) END,
			--[DeferredSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--					   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[DeferredCostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--							 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[DeferredGrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--							 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[HoursOrQuantity] = ARS.HRS_QTY,
			[Time] = ARS.EMP_TIME_AMT,
			[IncomeOnly] = ARS.INC_ONLY_AMT,
			[Commission] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.COMMISSION_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.COMMISSION_AMT ELSE 0 END,
			[Cost] = ARS.COST_AMT,
			[VendorTax] = ARS.NON_RESALE_AMT,
			[MediaNetCharge] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.NET_CHARGE_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.NET_CHARGE_AMT ELSE 0 END,
			[MediaRebate] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.REBATE_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.REBATE_AMT ELSE 0 END,
			[MediaAdditionalCharge] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.ADDITIONAL_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.ADDITIONAL_AMT ELSE 0 END,
			[MediaDiscount] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.DISCOUNT_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.DISCOUNT_AMT ELSE 0 END,
			[AdvanceIncome] = ARS.AB_INC_AMT,
			[AdvanceCommission] = ARS.AB_COMMISSION_AMT,
			[AdvanceCost] = ARS.AB_COST_AMT,
			[AdvanceRetainedSales] = ARS.AB_SALE_AMT,
			[AdvanceNonresaleAmount] = ARS.AB_NONRESALE_AMT,
			[TotalBillLessResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE 0 END,
			[CityTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.CITY_TAX_AMT ELSE 0 END,
			[CountyTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.CNTY_TAX_AMT ELSE 0 END,
			[StateTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.STATE_TAX_AMT ELSE 0 END,
			[ResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE 0 END,
			[TotalBill] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) ELSE 0 END,
			[TaxAtBilling] = CASE WHEN ARS.INV_TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TaxCode] = ARS.TAX_CODE,
			[CityTaxPct] = ARS.CITY_TAX_PCT,
			[CountyTaxPct] = ARS.CNTY_TAX_PCT,
			[StateTaxPct] = ARS.STATE_TAX_PCT,
			[GLXACT] = ARS.GL_XACT,
			[GLXACTDeferred] = ARS.GL_XACT_DEF,
			[GLAccountAR] = ARS.GL_ACCT_AR,
			[GLAccountARDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_AR),
			[GLAccountSales] = ARS.GL_ACCT_SALE,
			[GLAccountSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_SALE),
			[GLAccountDeferredSales] = ARS.GL_ACCT_DEF_SALE,
			[GLAccountDeferredSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_DEF_SALE),
			[GLAccountCostOfSales] = ARS.GL_ACCT_COS,
			[GLAccountCostOfSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_COS),
			[GLAccountAccruedAP] = ARS.GL_ACCT_ACC_AP,
			[GLAccountAccruedAPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_ACC_AP),
			[GLAccountAccruedCOS] = ARS.GL_ACCT_ACC_COS,
			[GLAccountAccruedCOSDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_ACC_COS),
			[GLAccountWIP] = ARS.GL_ACCT_WIP,
			[GLAccountWIPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_WIP),
			[GLAccountCityTax] = ARS.GL_ACCT_CITY,
			[GLAccountCityTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_CITY),
			[GLAccountCountyTax] = ARS.GL_ACCT_COUNTY,
			[GLAccountCountyTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_COUNTY),
			[GLAccountStateTax] = ARS.GL_ACCT_STATE,
			[GLAccountStateTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_STATE),
			[Converted] = CASE WHEN ARS.CONVERTED = 1 THEN 'Yes' ELSE 'No' END,
			[CreateDate] = AR.CREATE_DATE,
			[UserID] = AR.USERID,
			[IsVoided] = CAST(COALESCE(AR.VOID_FLAG,0) AS BIT),
			[VoidComment] = AR.VO_COMMENT,
			[BillingComment] = CASE WHEN ISNULL(CAST(BC.BILL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BC.BILL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingJobComment] = CASE WHEN ISNULL(CAST(BCJ.JOB_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCJ.JOB_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingDetailComment] = CASE WHEN ISNULL(CAST(BCD.DTL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCD.DTL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalClientComment] = CASE WHEN ISNULL(CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalFunctionComment] = CASE WHEN ISNULL(CAST(BAD.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAD.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)) ELSE NULL END,
			[CampaignComments] = CAMP.CMP_COMMENTS,
			[ClientReference] = J.JOB_CLI_REF,
			[JobComment] = J.JOB_COMMENTS,
			[JobComponentComment] = JC.JOB_COMP_COMMENTS,
			[EstimateNumber] = ESTC.ESTIMATE_NUMBER,
			[EstimateComponentNumber] = ESTC.EST_COMPONENT_NBR,
			[EstimateComment] = CASE WHEN ISNULL(ESTC.EST_LOG_COMMENT, '') <> '' THEN ESTC.EST_LOG_COMMENT ELSE NULL END,
			[EstimateComponentComment] = CASE WHEN ISNULL(ESTC.EST_COMP_COMMENT, '') <> '' THEN ESTC.EST_COMP_COMMENT ELSE NULL END,
			[EstimateQuoteComment] = CASE WHEN ISNULL(ESTC.EST_QTE_COMMENT, '') <> '' THEN ESTC.EST_QTE_COMMENT ELSE NULL END,
			[EstimateRevisionComment] = CASE WHEN ISNULL(ESTC.EST_REV_COMMENT, '') <> '' THEN ESTC.EST_REV_COMMENT ELSE NULL END,
			[EstimateFunctionComment] = CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT, '') <> '' THEN ESTC.EST_FNC_COMMENT ELSE NULL END,
			[InvoiceFooterComment] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') <> 'P'THEN C.CL_MFOOTER ELSE C.CL_FOOTER END, -- ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER),
			[BillingAddress] = AR.BILLING_ADDRESS,
			[JobTypeCode] = JC.JT_CODE,
			[JobTypeDescription] = JT.JT_DESC,
			[JobMediaDateToBill] = JC.MEDIA_BILL_DATE
			
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									  AR.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
			[dbo].[OFFICE] AS O ON O.OFFICE_CODE = ARS.OFFICE_CODE LEFT OUTER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
									 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND
									P.DIV_CODE = ARS.DIV_CODE AND
									P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN 
		    [dbo].[ACCOUNT_EXECUTIVE] AS AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = ARS.CMP_IDENTIFIER LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ARS.JOB_NUMBER LEFT OUTER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			[dbo].[JOB_TYPE] JT ON JC.JT_CODE = JT.JT_CODE LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
			[dbo].[MARKET] AS M ON M.MARKET_CODE = ARS.MARKET_CODE LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PPS ON PPS.PPPERIOD = ARS.SALE_POST_PERIOD LEFT OUTER JOIN
			[dbo].[V_AR_INVOICE_DUE_DATES] AS ARDD ON ARDD.AR_INV_NBR = ARS.AR_INV_NBR LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMPAE ON EMPAE.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
		    [dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			(SELECT 
						BH.BA_ID,
						BH.JOB_NUMBER,
						BH.JOB_COMPONENT_NBR,
						BH.AR_INV_NBR,
						[BILL_APPROVAL_COMMENT] = BH.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] AS BH 
					WHERE BH.BA_ID = (SELECT MAX(B.BA_ID) FROM [dbo].[BILL_APPR_HDR] B WHERE B.JOB_NUMBER = BH.JOB_NUMBER AND
																						     B.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR AND
																							 B.AR_INV_NBR = BH.AR_INV_NBR 
																							 )) AS BAC ON BAC.JOB_NUMBER = ARS.JOB_NUMBER AND 
																									 BAC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND 
																									 BAC.AR_INV_NBR = ARS.AR_INV_NBR LEFT OUTER JOIN
			(SELECT 
						BH.BA_ID,
						BH.JOB_NUMBER,
						BH.JOB_COMPONENT_NBR,
						BH.AR_INV_NBR,
						BILL_APPR_DTL.FNC_CODE,
						[BILL_APPROVAL_FUNCTION_COMMENT] = BILL_APPR_DTL.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] AS BH INNER JOIN
						[dbo].[BILL_APPR_DTL] ON BILL_APPR_DTL.BA_ID = BH.BA_ID AND
												 BILL_APPR_DTL.JOB_NUMBER = BH.JOB_NUMBER AND
												 BILL_APPR_DTL.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR
					WHERE BH.BA_ID = (SELECT MAX(B.BA_ID) FROM [dbo].[BILL_APPR_HDR] B WHERE B.JOB_NUMBER = BH.JOB_NUMBER AND
																						     B.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR AND
																							 B.AR_INV_NBR = BH.AR_INV_NBR 
																							 )) AS BAD ON BAD.JOB_NUMBER = ARS.JOB_NUMBER AND 
																									 BAD.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND 
																									 BAD.AR_INV_NBR = ARS.AR_INV_NBR AND
																									 BAD.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
		    (SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_JOB] AS BCJ ON BCJ.INV_NBR = ARS.AR_INV_NBR AND
													BCJ.JOB_NUMBER = ARS.JOB_NUMBER AND
													BCJ.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_DTL] AS BCD ON BCD.INV_NBR = ARS.AR_INV_NBR AND
													BCD.JOB_NUMBER = ARS.JOB_NUMBER AND
													BCD.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND
													BCD.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
				(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EC.ESTIMATE_NUMBER,
						EC.EST_COMPONENT_NBR,
						ERD.FNC_CODE,
						EST_LOG_COMMENT = CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						EST_LOG_COMMENT_HTML = CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						EST_COMP_COMMENT = CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						EST_COMP_COMMENT_HTML = CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						EST_QTE_COMMENT = CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)),  
						EST_QTE_COMMENT_HTML = CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)),
						EST_REV_COMMENT = CAST(ER.EST_REV_COMMENT AS varchar(MAX)),  
						EST_REV_COMMENT_HTML = CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX)), 
						EST_FNC_COMMENT = dbo.[advfn_invoice_printing_estimate_function_comment](ERD.ESTIMATE_NUMBER, ERD.EST_COMPONENT_NBR, ERD.EST_QUOTE_NBR, ERD.EST_REV_NBR, ERD.FNC_CODE, 0), 
						EST_FNC_COMMENT_HTML = dbo.[advfn_invoice_printing_estimate_function_comment](ERD.ESTIMATE_NUMBER, ERD.EST_COMPONENT_NBR, ERD.EST_QUOTE_NBR, ERD.EST_REV_NBR, ERD.FNC_CODE, 1)
					FROM 
						[dbo].[JOB_COMPONENT] AS JC LEFT OUTER JOIN 
						[dbo].[ESTIMATE_APPROVAL] AS EA ON EA.JOB_NUMBER = JC.JOB_NUMBER AND 
														   EA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
						[dbo].[ESTIMATE_LOG] AS EL ON EL.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
															EC.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_QUOTE] AS EQ ON EQ.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
														EQ.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
														EQ.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_REV] AS ER ON ER.EST_REV_NBR = EA.EST_REVISION_NBR AND 
													  ER.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
													  ER.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
													  ER.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.EST_REV_NBR = ER.EST_REV_NBR AND 
														   ERD.EST_QUOTE_NBR = ER.EST_QUOTE_NBR AND 
														   ERD.EST_COMPONENT_NBR = ER.EST_COMPONENT_NBR AND 
														   ERD.ESTIMATE_NUMBER = ER.ESTIMATE_NUMBER
					GROUP BY 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EC.ESTIMATE_NUMBER,
						EC.EST_COMPONENT_NBR, 
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						ERD.FNC_CODE,
						CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT AS varchar(MAX)),
						CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))) AS ESTC ON ESTC.JOB_NUMBER = ARS.JOB_NUMBER AND
																			 ESTC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND
																			 ESTC.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN 
			(SELECT SEC_CLIENT.CL_CODE,
							SEC_CLIENT.DIV_CODE,
							SEC_CLIENT.PRD_CODE,
							SEC_CLIENT.[USER_ID],
							SEC_CLIENT.TIME_ENTRY 
					 FROM dbo.SEC_CLIENT WITH(NOLOCK)
					 WHERE SEC_CLIENT.[USER_ID] = @USER_CODE) AS SEC_CLIENT ON ARS.CL_CODE = SEC_CLIENT.CL_CODE AND
																			 ARS.DIV_CODE = SEC_CLIENT.DIV_CODE AND
																			 ARS.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE
			(
			(@BreakoutCoOpBilling = 1 AND ARS.AR_INV_SEQ <> 99)
		OR
			(@BreakoutCoOpBilling = 0 AND ARS.AR_INV_SEQ = 99 OR ARS.AR_INV_SEQ = 0)
			)
		AND
			(
			(ISNULL(ARS.MEDIA_TYPE,'P') = 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			OR
			(ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			OR
			(ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			)
			AND
			--AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode AND
			(ARS.OFFICE_CODE IN (SELECT items FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(ARS.CL_CODE IN (SELECT items FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			(ARS.CL_CODE + '|' + ARS.DIV_CODE IN (SELECT items FROM dbo.udf_split_list(@DIVISION_LIST, ',')) OR @DIVISION_LIST IS NULL) AND
			(ARS.CL_CODE + '|' + ARS.DIV_CODE + '|' + ARS.PRD_CODE IN (SELECT items FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) OR @PRODUCT_LIST IS NULL) AND
			1 = CASE WHEN @RESTRICTIONS = 0 THEN 1 WHEN SEC_CLIENT.[USER_ID] = @USER_CODE AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END

		UNION ALL
		
		SELECT
			[OfficeCode] = AR.OFFICE_CODE,
			[OfficeName] = O.OFFICE_NAME,
			[ClientCode] = AR.CL_CODE,
			[ClientName] = C.CL_NAME,
			[ClientAddress] = C.CL_ADDRESS1,
			[ClientAddress2] = C.CL_ADDRESS2,
			[ClientCity] = C.CL_CITY,
			[ClientCounty] = C.CL_COUNTY,
			[ClientState] = C.CL_STATE,
			[ClientZip] = C.CL_ZIP,
			[ClientCountry] = C.CL_COUNTRY,
			[ClientBillingAddress] = C.CL_BADDRESS1,
			[ClientBillingAddress2] = C.CL_BADDRESS2,
			[ClientBillingCity] = C.CL_BCITY,
			[ClientBillingCounty] = C.CL_BCOUNTY,
			[ClientBillingState] = C.CL_BSTATE,
			[ClientBillingZip] = C.CL_BZIP,
			[ClientBillingCountry] = C.CL_BCOUNTRY,
			[DivisionCode] = AR.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = AR.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[ProductBillingAddress] = P.PRD_BILL_ADDRESS1,
			[ProductBillingAddress2] = P.PRD_BILL_ADDRESS2,
			[ProductBillingCity] = P.PRD_BILL_CITY,
			[ProductBillingCounty] = P.PRD_BILL_COUNTY,
			[ProductBillingState] = P.PRD_BILL_STATE,
			[ProductBillingZip] = P.PRD_BILL_ZIP,
			[ProductBillingCountry] = P.PRD_BILL_COUNTRY,
			[DefaultAECode] = ISNULL(AE.EMP_CODE,''),
			[DefaultAEName] = COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			[ProductUDF1] = ISNULL(P.USER_DEFINED1,''),
			[ProductUDF2] = ISNULL(P.USER_DEFINED2,''),
			[ProductUDF3] = ISNULL(P.USER_DEFINED3,''),
			[ProductUDF4] = ISNULL(P.USER_DEFINED4,''),
			[ARPostPeriod] = AR.AR_POST_PERIOD,
			[SalePostPeriod] = AR.AR_POST_PERIOD,
			[ARPostPeriodStartDate] = PP.PPSRTDATE,
			[ARPostPeriodEndDate] = PP.PPENDDATE,
			[ARPostPeriodDescription] = PP.PPDESC,
			[ARPostPeriodGLMonth] = PP.PPGLMONTH,
			[ARPostPeriodGLYear] = PP.PPGLYEAR,
			[SalePostPeriodStartDate] = PP.PPSRTDATE,
			[SalePostPeriodEndDate] = PP.PPENDDATE,
			[SalePostPeriodDescription] = PP.PPDESC,
			[SalePostPeriodGLMonth] = PP.PPGLMONTH,
			[SalePostPeriodGLYear] = PP.PPGLYEAR,
			[InvoiceDate] = AR.AR_INV_DATE,
			[InvoiceNumber] = AR.AR_INV_NBR,
			[InvoiceSEQ] = AR.AR_INV_SEQ,
			[InvoiceType] = AR.AR_TYPE,
			[InvoiceDescription] = AR.AR_DESCRIPTION,
			[InvoiceAssignBy] = '',
			[InvoiceCategory] = ARDD.INV_CAT_DESC,
			[InvoiceDueDate] = ARDD.AR_INV_DUE_DATE,
			[MediaType] = ISNULL(AR.REC_TYPE,'P'),
			[MediaTypeDescription] = CASE WHEN ISNULL(AR.REC_TYPE, 'P') = 'P' THEN 'Production Manual Invoice'
										  WHEN ISNULL(AR.REC_TYPE, 'P') = 'M' THEN 'Media Manual Invoice' ELSE 'Production Manual Invoice' END,
			[ManualFlag] = 'Yes',
			[SalesClassCode] = AR.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[CampaignID] = NULL,
			[CampaignCode] = NULL,
			[CampaignName] = NULL,
			[ClientPO] = NULL,
			[AccountExecutiveCode] = NULL,
			[AccountExecutive] = NULL,
			[JobNumber] = NULL,
			[JobDescription] = NULL,
			[JobComponent] = NULL,
			[JobComponentDescription] = NULL,
			[FunctionType] = NULL,
			[FunctionCode] = NULL,
			[FunctionDescription] = NULL,
			[FunctionHeadingDescription] = NULL,
			[OrderNumber] = NULL,
			[OrderLine] = NULL,
			[MediaMonth] = NULL,
			[MediaYear] = NULL,
			[MediaStartDate] = NULL,
			[MediaEndDate] = NULL,
			[MediaMarket] = NULL,
			[MediaMarketDescription] = NULL,
			[InvoiceTotal] = AR.AR_INV_AMOUNT,
			[Sales] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[CostOfSales] = ISNULL(AR.AR_COS_AMT, 0),
			[GrossIncome] = (ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0))) - ISNULL(AR.AR_COS_AMT, 0),
			[DeferredSales] = 0,
			[DeferredSalesAR] = 0,
			[DeferredCostOfSales] = 0,
			[DeferredCostOfSalesAR] = 0,
			[DeferredGrossIncome] = 0,
			[DeferredGrossIncomeAR] = 0,
			[HoursOrQuantity] = 0,
			[Time] = 0,
			[IncomeOnly] = 0,
			[Commission] = ISNULL(AR.AR_COMM_AMT, 0),
			[Cost] = 0,
			[VendorTax] = 0,
			[MediaNetCharge] = 0,
			[MediaRebate] = 0,
			[MediaAdditionalCharge] = 0,
			[MediaDiscount] = 0,
			[AdvanceIncome] = 0,
			[AdvanceCommission] = 0,
			[AdvanceCost] = 0,
			[AdvanceRetainedSales] = 0,
			[AdvanceNonresaleAmount] = 0,
			[TotalBillLessResaleTax] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[CityTax] = ISNULL(AR.AR_CITY_AMT, 0),
			[CountyTax] = ISNULL(AR.AR_COUNTY_AMT, 0),
			[StateTax] = ISNULL(AR.AR_STATE_AMT, 0),
			[ResaleTax] = (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[TotalBill] = ISNULL(AR.AR_INV_AMOUNT, 0),
			[TaxAtBilling] = 'No',
			[TaxCode] = NULL,
			[CityTaxPct] = NULL,
			[CountyTaxPct] = NULL,
			[StateTaxPct] = NULL,
			[GLXACT] = AR.GLEXACT,
			[GLXACTDeferred] = NULL,
			[GLAccountAR] = AR.GLACODE_AR,
			[GLAccountARDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_AR),
			[GLAccountSales] = AR.GLACODE_SALES,
			[GLAccountSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_SALES),
			[GLAccountDeferredSales] = NULL,
			[GLAccountDeferredSalesDescription] = NULL,
			[GLAccountCostOfSales] = AR.GLACODE_COS,
			[GLAccountCostOfSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_COS),
			[GLAccountAccruedAP] = NULL,
			[GLAccountAccruedAPDescription] = NULL,
			[GLAccountAccruedCOS] = NULL,
			[GLAccountAccruedCOSDescription] = NULL,
			[GLAccountWIP] = AR.GLACODE_OFFSET,
			[GLAccountWIPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_OFFSET),
			[GLAccountCityTax] = AR.GLACODE_CITY,
			[GLAccountCityTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_CITY),
			[GLAccountCountyTax] = AR.GLACODE_COUNTY,
			[GLAccountCountyTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_COUNTY),
			[GLAccountStateTax] = AR.GLACODE_STATE,
			[GLAccountStateTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_STATE),
			[Converted] = 'No',
			[CreateDate] = AR.CREATE_DATE,
			[UserID] = AR.USERID,
			[IsVoided] = CAST(COALESCE(AR.VOID_FLAG,0) AS BIT),
			[VoidComment] = AR.VO_COMMENT,
			[BillingComment] = NULL,
			[BillingJobComment] = NULL,
			[BillingDetailComment] = NULL,
			[BillingApprovalClientComment] = NULL,
			[BillingApprovalFunctionComment] = NULL,
			[CampaignComments] = NULL,
			[ClientReference] = NULL,
			[JobComment] = NULL,
			[JobComponentComment] = NULL,
			[EstimateNumber] = NULL,
			[EstimateComponentNumber] = NULL,
			[EstimateComment] = NULL,
			[EstimateComponentComment] = NULL,
			[EstimateQuoteComment] = NULL,
			[EstimateRevisionComment] = NULL,
			[EstimateFunctionComment] = NULL,
			[InvoiceFooterComment] = NULL,
			[BillingAddress] = AR.BILLING_ADDRESS,
			[JobTypeCode] = NULL,
			[JobTypeDescription] = NULL,
			[JobMediaDateToBill] = NULL
		FROM
			[dbo].[ACCT_REC] AS AR INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND
									 D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND
									P.DIV_CODE = AR.DIV_CODE AND
									P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN 
		    [dbo].[ACCOUNT_EXECUTIVE] AS AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			[dbo].[OFFICE] AS O ON O.OFFICE_CODE = AR.OFFICE_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD LEFT OUTER JOIN
			[dbo].[V_AR_INVOICE_DUE_DATES] AS ARDD ON ARDD.AR_INV_NBR = AR.AR_INV_NBR LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
			(SELECT SEC_CLIENT.CL_CODE,
							SEC_CLIENT.DIV_CODE,
							SEC_CLIENT.PRD_CODE,
							SEC_CLIENT.[USER_ID],
							SEC_CLIENT.TIME_ENTRY 
					 FROM dbo.SEC_CLIENT WITH(NOLOCK)
					 WHERE SEC_CLIENT.[USER_ID] = @USER_CODE) AS SEC_CLIENT ON AR.CL_CODE = SEC_CLIENT.CL_CODE AND
																			 AR.DIV_CODE = SEC_CLIENT.DIV_CODE AND
																			 AR.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE
			AR.MANUAL_INV = 1 AND
			1 = CASE WHEN @BreakoutCoOpBilling = 1 THEN CASE WHEN AR.AR_INV_SEQ <> 99 THEN 1 ELSE 0 END
					 ELSE CASE WHEN AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0 THEN 1 ELSE 0 END END AND
			AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode AND
			(AR.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (AR.CL_CODE + '|' + AR.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
			1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND			
			1 = CASE WHEN @RESTRICTIONS = 0 THEN 1 WHEN SEC_CLIENT.[USER_ID] = @USER_CODE AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END) AS SJ
	LEFT OUTER JOIN [dbo].[V_MEDIA_HDR] VMH ON VMH.ORDER_NBR = SJ.OrderNumber
	LEFT OUTER JOIN [dbo].[VENDOR] V ON VMH.VN_CODE = V.VN_CODE
	WHERE 1 = CASE WHEN @StartingInvoiceDate IS NULL AND @EndingInvoiceDate IS NULL THEN 1
	               WHEN SJ.InvoiceDate BETWEEN @StartingInvoiceDate AND @EndingInvoiceDate THEN 1 ELSE 0 END
) detail
	END
	Else
	BEGIN
		SELECT [ID] = NEWID(),
	   [OfficeCode],
		[OfficeName],
		[ClientCode],
		[ClientName],
		[ClientAddress],
		[ClientAddress2],
		[ClientCity],
		[ClientCounty],
		[ClientState],
		[ClientZip],
		[ClientCountry],
		[ClientBillingAddress],
		[ClientBillingAddress2],
		[ClientBillingCity],
		[ClientBillingCounty],
		[ClientBillingState],
		[ClientBillingZip],
		[ClientBillingCountry],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductName],
		[ProductBillingAddress],
		[ProductBillingAddress2],
		[ProductBillingCity],
		[ProductBillingCounty],
		[ProductBillingState],
		[ProductBillingZip],
		[ProductBillingCountry],
		[DefaultAECode],
		[DefaultAEName],
		[ProductUDF1],
		[ProductUDF2],
		[ProductUDF3],
		[ProductUDF4],
		[ARPostPeriod],
		[ARPostPeriodStartDate],
		[ARPostPeriodEndDate],
		[ARPostPeriodDescription],
		[ARPostPeriodGLMonth],
		[ARPostPeriodGLYear],
		[SalePostPeriod],
		[SalePostPeriodStartDate],
		[SalePostPeriodEndDate],
		[SalePostPeriodDescription],
		[SalePostPeriodGLMonth],
		[SalePostPeriodGLYear],
		[InvoiceDate],
		[InvoiceNumber],
		[InvoiceSEQ],
		[InvoiceType],
		[InvoiceDescription],
		[InvoiceAssignBy],
		[InvoiceCategory],
		[InvoiceDueDate],
		[MediaType],
		[MediaTypeDescription],
		[ManualFlag],
		[SalesClassCode],
		[SalesClassDescription],
		[CampaignID],
		[CampaignCode],
		[CampaignName],
		[ClientPO],		
		[AccountExecutiveCode],
		[AccountExecutive],
		[JobNumber],
		[JobDescription],
		[JobComponent],
		[JobComponentDescription],
		[FunctionType],
		[FunctionCode],
		[FunctionDescription],
		[FunctionHeadingDescription],
		[OrderNumber],
		[OrderLine],
		[MediaMonth],
		[MediaYear],
		[MediaStartDate],
		[MediaEndDate],
		[MediaMarket],
		[MediaMarketDescription],
		[InvoiceTotal],
		[Sales],
		[CostOfSales],
		[GrossIncome],
		CASE WHEN MediaType = 'P' THEN [DeferredSales] ELSE [DeferredSalesAR] - [DeferredSales] END AS [DeferredSales],
		CASE WHEN MediaType = 'P' THEN [DeferredCostOfSales] ELSE [DeferredCostOfSalesAR] - [DeferredCostOfSales] END AS [DeferredCostOfSales],
		CASE WHEN MediaType = 'P' THEN [DeferredGrossIncome] ELSE [DeferredGrossIncomeAR] - [DeferredGrossIncome] END AS [DeferredGrossIncome],
		[HoursOrQuantity],
		[Time],
		[IncomeOnly],
		[Commission],
		[Cost],
		[VendorTax],
		[MediaNetCharge],
		[MediaRebate],
		[MediaAdditionalCharge],
		[MediaDiscount],
		[AdvanceIncome],
		[AdvanceCommission],
		[AdvanceCost],
		[AdvanceRetainedSales],
		[AdvanceNonresaleAmount],
		[TotalBillLessResaleTax],
		[CityTax],
		[CountyTax],
		[StateTax],
		[ResaleTax],
		[TotalBill],
		[TaxAtBilling],
		[TaxCode],
		[CityTaxPct],
		[CountyTaxPct],
		[StateTaxPct],
		[GLXACT],
		[GLXACTDeferred],
		[GLAccountAR],
		[GLAccountARDescription],
		[GLAccountSales],
		[GLAccountSalesDescription],
		[GLAccountDeferredSales],
		[GLAccountDeferredSalesDescription],
		[GLAccountCostOfSales],
		[GLAccountCostOfSalesDescription],
		[GLAccountAccruedAP],
		[GLAccountAccruedAPDescription],
		[GLAccountAccruedCOS],
		[GLAccountAccruedCOSDescription],
		[GLAccountWIP],
		[GLAccountWIPDescription],
		[GLAccountCityTax],
		[GLAccountCityTaxDescription],
		[GLAccountCountyTax],
		[GLAccountCountyTaxDescription],
		[GLAccountStateTax],
		[GLAccountStateTaxDescription],
		[Converted],
		[OrderDescription],
		[VendorCode],
		[VendorName],
		[CreateDate],
		[UserID],
		[IsVoided],
		[VoidComment],
		[FiscalMonth],
		[BillingComment],
		[BillingJobComment],
		[BillingDetailComment],
		[BillingApprovalClientComment],
		[BillingApprovalFunctionComment],
		[CampaignComments],
		[ClientReference],
		[JobComment],
		[JobComponentComment],
		[EstimateNumber],
		[EstimateComponentNumber],
		[EstimateComment],
		[EstimateComponentComment],
		[EstimateQuoteComment],
		[EstimateRevisionComment],
		[EstimateFunctionComment],
		[InvoiceFooterComment],
		[BillingAddress],
		[JobTypeCode],
		[JobTypeDescription],
		[JobMediaDateToBill]
FROM (
	SELECT 		
		[OfficeCode] = SJ.[OfficeCode],
		[OfficeName] = SJ.[OfficeName],
		[ClientCode] = SJ.[ClientCode],
		[ClientName] = SJ.[ClientName],
		[ClientAddress] = SJ.[ClientAddress],
		[ClientAddress2] = SJ.[ClientAddress2],
		[ClientCity] = SJ.[ClientCity],
		[ClientCounty] = SJ.[ClientCounty],
		[ClientState] = SJ.[ClientState],
		[ClientZip] = SJ.[ClientZip],
		[ClientCountry] = SJ.[ClientCountry],
		[ClientBillingAddress] = SJ.[ClientBillingAddress],
		[ClientBillingAddress2] = SJ.[ClientBillingAddress2],
		[ClientBillingCity] = SJ.[ClientBillingCity],
		[ClientBillingCounty] = SJ.[ClientBillingCounty],
		[ClientBillingState] = SJ.[ClientBillingState],
		[ClientBillingZip] = SJ.[ClientBillingZip],
		[ClientBillingCountry] = SJ.[ClientBillingCountry],
		[DivisionCode] = SJ.[DivisionCode],
		[DivisionName] = SJ.[DivisionName],
		[ProductCode] = SJ.[ProductCode],
		[ProductName] = SJ.[ProductName],
		[ProductBillingAddress] = SJ.[ProductBillingAddress],
		[ProductBillingAddress2] = SJ.[ProductBillingAddress2],
		[ProductBillingCity] = SJ.[ProductBillingCity],
		[ProductBillingCounty] = SJ.[ProductBillingCounty],
		[ProductBillingState] = SJ.[ProductBillingState],
		[ProductBillingZip] = SJ.[ProductBillingZip],
		[ProductBillingCountry] = SJ.[ProductBillingCountry],
		[DefaultAECode] = SJ.[DefaultAECode],
		[DefaultAEName] = SJ.[DefaultAEName],
		[ProductUDF1] = SJ.[ProductUDF1],
		[ProductUDF2] = SJ.[ProductUDF2],
		[ProductUDF3] = SJ.[ProductUDF3],
		[ProductUDF4] = SJ.[ProductUDF4],
		[ARPostPeriod] = SJ.[ARPostPeriod],
		[ARPostPeriodStartDate] = SJ.[ARPostPeriodStartDate],
		[ARPostPeriodEndDate] = SJ.[ARPostPeriodEndDate],
		[ARPostPeriodDescription] = SJ.[ARPostPeriodDescription],
		[ARPostPeriodGLMonth] = SJ.[ARPostPeriodGLMonth],
		[ARPostPeriodGLYear] = SJ.[ARPostPeriodGLYear],
		[SalePostPeriod] = SJ.[SalePostPeriod],
		[SalePostPeriodStartDate] = SJ.[SalePostPeriodStartDate],
		[SalePostPeriodEndDate] = SJ.[SalePostPeriodEndDate],
		[SalePostPeriodDescription] = SJ.[SalePostPeriodDescription],
		[SalePostPeriodGLMonth] = SJ.[SalePostPeriodGLMonth],
		[SalePostPeriodGLYear] = SJ.[SalePostPeriodGLYear],
		[InvoiceDate] = SJ.[InvoiceDate],
		[InvoiceNumber] = SJ.[InvoiceNumber],
		[InvoiceSEQ] = SJ.[InvoiceSEQ],
		[InvoiceType] = SJ.[InvoiceType],
		[InvoiceDescription] = SJ.[InvoiceDescription],
		[InvoiceAssignBy] = SJ.[InvoiceAssignBy],
		[InvoiceCategory] = SJ.[InvoiceCategory],
		[InvoiceDueDate] = SJ.[InvoiceDueDate],
		[MediaType] = SJ.[MediaType],
		[MediaTypeDescription] = SJ.[MediaTypeDescription],
		[ManualFlag] = SJ.[ManualFlag],
		[SalesClassCode] = SJ.[SalesClassCode],
		[SalesClassDescription] = SJ.[SalesClassDescription],
		[CampaignID] = SJ.[CampaignID],
		[CampaignCode] = SJ.[CampaignCode],
		[CampaignName] = SJ.[CampaignName],
		[ClientPO] = SJ.[ClientPO],		
		[AccountExecutiveCode] = SJ.[AccountExecutiveCode],
		[AccountExecutive] = SJ.[AccountExecutive],
		[JobNumber] = SJ.[JobNumber],
		[JobDescription] = SJ.[JobDescription],
		[JobComponent] = SJ.[JobComponent],
		[JobComponentDescription] = SJ.[JobComponentDescription],
		[FunctionType] = SJ.[FunctionType],
		[FunctionCode] = SJ.[FunctionCode],
		[FunctionDescription] = SJ.[FunctionDescription],
		[FunctionHeadingDescription] = SJ.[FunctionHeadingDescription],
		[OrderNumber] = SJ.[OrderNumber],
		[OrderLine] = SJ.[OrderLine],
		[MediaMonth] = CAST(SJ.[MediaMonth] AS smallint),
		[MediaYear] = SJ.[MediaYear],
		[MediaStartDate] = SJ.[MediaStartDate],
		[MediaEndDate] = SJ.[MediaEndDate],
		[MediaMarket] = SJ.[MediaMarket],
		[MediaMarketDescription] = SJ.[MediaMarketDescription],
		[InvoiceTotal] = SJ.[InvoiceTotal],
		[Sales] = SJ.[Sales],
		[CostOfSales] = SJ.[CostOfSales],
		[GrossIncome] = SJ.[GrossIncome],
		[DeferredSales] = SJ.[DeferredSales],
		[DeferredSalesAR] = SJ.[DeferredSalesAR],
		[DeferredCostOfSales] = SJ.[DeferredCostOfSales],
		[DeferredCostOfSalesAR] = SJ.[DeferredCostOfSalesAR],
		[DeferredGrossIncome] = SJ.[DeferredGrossIncome],
		[DeferredGrossIncomeAR] = SJ.[DeferredGrossIncomeAR],
		[HoursOrQuantity] = SJ.[HoursOrQuantity],
		[Time] = SJ.[Time],
		[IncomeOnly] = SJ.[IncomeOnly],
		[Commission] = SJ.[Commission],
		[Cost] = SJ.[Cost],
		[VendorTax] = SJ.[VendorTax],
		[MediaNetCharge] = SJ.[MediaNetCharge],
		[MediaRebate] = SJ.[MediaRebate],
		[MediaAdditionalCharge] = SJ.[MediaAdditionalCharge],
		[MediaDiscount] = SJ.[MediaDiscount],
		[AdvanceIncome] = SJ.[AdvanceIncome],
		[AdvanceCommission] = SJ.[AdvanceCommission],
		[AdvanceCost] = SJ.[AdvanceCost],
		[AdvanceRetainedSales] = SJ.[AdvanceRetainedSales],
		[AdvanceNonresaleAmount] = SJ.[AdvanceNonresaleAmount],
		[TotalBillLessResaleTax] = SJ.[TotalBillLessResaleTax],
		[CityTax] = SJ.[CityTax],
		[CountyTax] = SJ.[CountyTax],
		[StateTax] = SJ.[StateTax],
		[ResaleTax] = SJ.[ResaleTax],
		[TotalBill] = SJ.[TotalBill],
		[TaxAtBilling] = SJ.[TaxAtBilling],
		[TaxCode] = SJ.[TaxCode],
		[CityTaxPct] = SJ.[CityTaxPct],
		[CountyTaxPct] = SJ.[CountyTaxPct],
		[StateTaxPct] = SJ.[StateTaxPct],
		[GLXACT] = SJ.[GLXACT],
		[GLXACTDeferred] = SJ.[GLXACTDeferred],
		[GLAccountAR] = SJ.[GLAccountAR],
		[GLAccountARDescription] = SJ.[GLAccountARDescription],
		[GLAccountSales] = SJ.[GLAccountSales],
		[GLAccountSalesDescription] = SJ.[GLAccountSalesDescription],
		[GLAccountDeferredSales] = SJ.[GLAccountDeferredSales],
		[GLAccountDeferredSalesDescription] = SJ.[GLAccountDeferredSalesDescription],
		[GLAccountCostOfSales] = SJ.[GLAccountCostOfSales],
		[GLAccountCostOfSalesDescription] = SJ.[GLAccountCostOfSalesDescription],
		[GLAccountAccruedAP] = SJ.[GLAccountAccruedAP],
		[GLAccountAccruedAPDescription] = SJ.[GLAccountAccruedAPDescription],
		[GLAccountAccruedCOS] = SJ.[GLAccountAccruedCOS],
		[GLAccountAccruedCOSDescription] = SJ.[GLAccountAccruedCOSDescription],
		[GLAccountWIP] = SJ.[GLAccountWIP],
		[GLAccountWIPDescription] = SJ.[GLAccountWIPDescription],
		[GLAccountCityTax] = SJ.[GLAccountCityTax],
		[GLAccountCityTaxDescription] = SJ.[GLAccountCityTaxDescription],
		[GLAccountCountyTax] = SJ.[GLAccountCountyTax],
		[GLAccountCountyTaxDescription] = SJ.[GLAccountCountyTaxDescription],
		[GLAccountStateTax] = SJ.[GLAccountStateTax],
		[GLAccountStateTaxDescription] = SJ.[GLAccountStateTaxDescription],
		[Converted] = SJ.[Converted],
		[OrderDescription] = VMH.ORDER_DESC,
		[VendorCode] = VMH.VN_CODE,
		[VendorName] = V.VN_NAME,
		[CreateDate] = SJ.CreateDate,
		[UserID] = SJ.UserID,
		[IsVoided] = CASE WHEN SJ.IsVoided = 1 THEN 'Yes' ELSE 'No' END,
		[VoidComment] = SJ.VoidComment,
		[FiscalMonth] = (SELECT TOP 1 [FISCALMTH] FROM [dbo].[GLCONFIG]),
		[BillingComment] = SJ.[BillingComment],
		[BillingJobComment] = SJ.[BillingJobComment],
		[BillingDetailComment] = SJ.[BillingDetailComment],
		[BillingApprovalClientComment] = SJ.[BillingApprovalClientComment],
		[BillingApprovalFunctionComment] = SJ.[BillingApprovalFunctionComment],
		[CampaignComments] = SJ.[CampaignComments],
		[ClientReference] = SJ.[ClientReference],
		[JobComment] = SJ.[JobComment],
		[JobComponentComment] = SJ.[JobComponentComment],
		[EstimateNumber] = SJ.[EstimateNumber],
		[EstimateComponentNumber] = SJ.[EstimateComponentNumber],
		[EstimateComment] = SJ.[EstimateComment],
		[EstimateComponentComment] = SJ.[EstimateComponentComment],
		[EstimateQuoteComment] = SJ.[EstimateQuoteComment],
		[EstimateRevisionComment] = SJ.[EstimateRevisionComment],
		[EstimateFunctionComment] = SJ.[EstimateFunctionComment],
		[InvoiceFooterComment] = SJ.[InvoiceFooterComment],
		[BillingAddress] = SJ.[BillingAddress],		
		[JobTypeCode] = SJ.[JobTypeCode],
		[JobTypeDescription] = SJ.[JobTypeDescription],
		[JobMediaDateToBill] = SJ.[JobMediaDateToBill]
	FROM
		(SELECT
			[OfficeCode] = ARS.OFFICE_CODE,
			[OfficeName] = O.OFFICE_NAME,
			[ClientCode] = ARS.CL_CODE,
			[ClientName] = C.CL_NAME,
			[ClientAddress] = C.CL_ADDRESS1,
			[ClientAddress2] = C.CL_ADDRESS2,
			[ClientCity] = C.CL_CITY,
			[ClientCounty] = C.CL_COUNTY,
			[ClientState] = C.CL_STATE,
			[ClientZip] = C.CL_ZIP,
			[ClientCountry] = C.CL_COUNTRY,
			[ClientBillingAddress] = C.CL_BADDRESS1,
			[ClientBillingAddress2] = C.CL_BADDRESS2,
			[ClientBillingCity] = C.CL_BCITY,
			[ClientBillingCounty] = C.CL_BCOUNTY,
			[ClientBillingState] = C.CL_BSTATE,
			[ClientBillingZip] = C.CL_BZIP,
			[ClientBillingCountry] = C.CL_BCOUNTRY,
			[DivisionCode] = ARS.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = ARS.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[ProductBillingAddress] = P.PRD_BILL_ADDRESS1,
			[ProductBillingAddress2] = P.PRD_BILL_ADDRESS2,
			[ProductBillingCity] = P.PRD_BILL_CITY,
			[ProductBillingCounty] = P.PRD_BILL_COUNTY,
			[ProductBillingState] = P.PRD_BILL_STATE,
			[ProductBillingZip] = P.PRD_BILL_ZIP,
			[ProductBillingCountry] = P.PRD_BILL_COUNTRY,
			[DefaultAECode] = ISNULL(AE.EMP_CODE,''),
			[DefaultAEName] = COALESCE((RTRIM(EMPAE.EMP_FNAME)+' '),'')+COALESCE((EMPAE.EMP_MI+'. '),'')+COALESCE(EMPAE.EMP_LNAME,''),
			[ProductUDF1] = ISNULL(P.USER_DEFINED1,''),
			[ProductUDF2] = ISNULL(P.USER_DEFINED2,''),
			[ProductUDF3] = ISNULL(P.USER_DEFINED3,''),
			[ProductUDF4] = ISNULL(P.USER_DEFINED4,''),
			[ARPostPeriod] =  AR.AR_POST_PERIOD,
			[SalePostPeriod] = ARS.SALE_POST_PERIOD,
			[ARPostPeriodStartDate] = PP.PPSRTDATE,
			[ARPostPeriodEndDate] = PP.PPENDDATE,
			[ARPostPeriodDescription] = PP.PPDESC,
			[ARPostPeriodGLMonth] = PP.PPGLMONTH,
			[ARPostPeriodGLYear] = PP.PPGLYEAR,
			[SalePostPeriodStartDate] = PPS.PPSRTDATE,
			[SalePostPeriodEndDate] = PPS.PPENDDATE,
			[SalePostPeriodDescription] = PPS.PPDESC,
			[SalePostPeriodGLMonth] = PPS.PPGLMONTH,
			[SalePostPeriodGLYear] = PPS.PPGLYEAR,
			[InvoiceDate] = AR.AR_INV_DATE,
			[InvoiceNumber] = ARS.AR_INV_NBR,
			[InvoiceSEQ] = ARS.AR_INV_SEQ,
			[InvoiceType] = ARS.AR_TYPE,
			[InvoiceDescription] = AR.AR_DESCRIPTION,
			[InvoiceAssignBy] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'P' AND ARS.JOB_NUMBER IS NOT NULL THEN 
										CASE WHEN INV_BY = 1 THEN 'Job'
										     WHEN INV_BY = 2 THEN 'Job Component'
											 WHEN INV_BY = 3 THEN 'Product/Sales Class'
											 WHEN INV_BY = 4 THEN 'Campaign'
											 WHEN INV_BY = 5 THEN 'Product/Client PO'
											 WHEN INV_BY = 6 THEN 'Client'
											 WHEN INV_BY = 7 THEN 'Division'
											 WHEN INV_BY = 8 THEN 'Product' ELSE '' END
									 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.JOB_NUMBER IS NULL THEN
									    CASE WHEN INV_BY = 1 THEN 'Sales Class'
										     WHEN INV_BY = 2 THEN 'Product/Client PO'
											 WHEN INV_BY = 3 THEN 'Market'
											 WHEN INV_BY = 4 THEN 'Order'
											 WHEN INV_BY = 5 THEN 'Campaign'
											 WHEN INV_BY = 6 THEN 'Media Type' ELSE '' END ELSE '' END,
			[InvoiceCategory] = ARDD.INV_CAT_DESC,
			[InvoiceDueDate] = ARDD.AR_INV_DUE_DATE,
			[MediaType] = ISNULL(ARS.MEDIA_TYPE, 'P'),
			[MediaTypeDescription] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'P' THEN 'Production'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'M' THEN 'Magazine'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'N' THEN 'Newspaper'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'O' THEN 'Outdoor'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'I' THEN 'Internet'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'R' THEN 'Radio'
										  WHEN ISNULL(ARS.MEDIA_TYPE, 'P') = 'T' THEN 'Television' ELSE 'Production' END,
			[ManualFlag] = 'No',
			[SalesClassCode] = ARS.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[CampaignID] = ARS.CMP_IDENTIFIER,
			[CampaignCode] = CAMP.CMP_CODE,
			[CampaignName] = CAMP.CMP_NAME,
			[ClientPO] = ARS.CLIENT_PO,
			[AccountExecutiveCode] = JC.EMP_CODE,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
			[JobNumber] = ARS.JOB_NUMBER,
			[JobDescription] = J.JOB_DESC,
			[JobComponent] = ARS.JOB_COMPONENT_NBR,
			[JobComponentDescription] = JC.JOB_COMP_DESC,
			[FunctionType] = ARS.FNC_TYPE,
			[FunctionCode] = ARS.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionHeadingDescription] = FH.FNC_HEADING_DESC,
			[OrderNumber] = ARS.ORDER_NBR,
			[OrderLine] = ARS.ORDER_LINE_NBR,
			[MediaMonth] = ARS.MEDIA_MONTH,
			[MediaYear] = ARS.MEDIA_YEAR,
			[MediaStartDate] = ARS.[START_DATE],
			[MediaEndDate] = ARS.END_DATE,
			[MediaMarket] = ARS.MARKET_CODE,
			[MediaMarketDescription] = M.MARKET_DESC,
			[InvoiceTotal] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(AR.AR_INV_AMOUNT, 0)
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(AR.AR_INV_AMOUNT, 0) ELSE 0 END,
			--[Sales] = 0,
			--[CostOfSales] = 0,
			--[GrossIncome] = 0,
			--[DeferredSales] = 0,
			--[DeferredCostOfSales] = 0,
			--[DeferredGrossIncome] = 0,
			--[Sales] = CASE WHEN ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN
			--			CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
			--			   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' THEN 0	
			--			   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END
			--			END,

			[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
						   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0	
						   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[CostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)
								 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0
								   ELSE ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0) END,
			[GrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN (ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))) - (ARS.COST_AMT + ARS.NET_CHARGE_AMT + ARS.NON_RESALE_AMT + ARS.AB_COST_AMT)
								 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD NOT BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 0
								 ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) END,
			[DeferredSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
								   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COMMISSION_AMT, 0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0)
								   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredSalesAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
								   WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COMMISSION_AMT, 0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0)
								   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredCostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0)
										 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredCostOfSalesAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0)
										 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[DeferredGrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0))
										 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,			
			[DeferredGrossIncomeAR] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN 0
										 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0))
										 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
			--			   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[CostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)
			--					 ELSE ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0) END,
			--[GrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN (ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))) - (ARS.COST_AMT + ARS.NET_CHARGE_AMT + ARS.NON_RESALE_AMT + ARS.AB_COST_AMT)
			--					 ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) END,
			--[DeferredSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--					   ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[DeferredCostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--							 ELSE (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			--[DeferredGrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 THEN 0
			--							 ELSE (ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[HoursOrQuantity] = ARS.HRS_QTY,
			[Time] = ARS.EMP_TIME_AMT,
			[IncomeOnly] = ARS.INC_ONLY_AMT,
			[Commission] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.COMMISSION_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.COMMISSION_AMT ELSE 0 END,
			[Cost] = ARS.COST_AMT,
			[VendorTax] = ARS.NON_RESALE_AMT,
			[MediaNetCharge] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.NET_CHARGE_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.NET_CHARGE_AMT ELSE 0 END,
			[MediaRebate] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.REBATE_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.REBATE_AMT ELSE 0 END,
			[MediaAdditionalCharge] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.ADDITIONAL_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.ADDITIONAL_AMT ELSE 0 END,
			[MediaDiscount] = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ARS.DISCOUNT_AMT
								WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.DISCOUNT_AMT ELSE 0 END,
			[AdvanceIncome] = ARS.AB_INC_AMT,
			[AdvanceCommission] = ARS.AB_COMMISSION_AMT,
			[AdvanceCost] = ARS.AB_COST_AMT,
			[AdvanceRetainedSales] = ARS.AB_SALE_AMT,
			[AdvanceNonresaleAmount] = ARS.AB_NONRESALE_AMT,
			[TotalBillLessResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE 0 END,
			[CityTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.CITY_TAX_AMT ELSE 0 END,
			[CountyTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.CNTY_TAX_AMT ELSE 0 END,
			[StateTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ARS.STATE_TAX_AMT ELSE 0 END,
			[ResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE 0 END,
			[TotalBill] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) ELSE 0 END,
			[TaxAtBilling] = CASE WHEN ARS.INV_TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
			[TaxCode] = ARS.TAX_CODE,
			[CityTaxPct] = ARS.CITY_TAX_PCT,
			[CountyTaxPct] = ARS.CNTY_TAX_PCT,
			[StateTaxPct] = ARS.STATE_TAX_PCT,
			[GLXACT] = ARS.GL_XACT,
			[GLXACTDeferred] = ARS.GL_XACT_DEF,
			[GLAccountAR] = ARS.GL_ACCT_AR,
			[GLAccountARDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_AR),
			[GLAccountSales] = ARS.GL_ACCT_SALE,
			[GLAccountSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_SALE),
			[GLAccountDeferredSales] = ARS.GL_ACCT_DEF_SALE,
			[GLAccountDeferredSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_DEF_SALE),
			[GLAccountCostOfSales] = ARS.GL_ACCT_COS,
			[GLAccountCostOfSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_COS),
			[GLAccountAccruedAP] = ARS.GL_ACCT_ACC_AP,
			[GLAccountAccruedAPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_ACC_AP),
			[GLAccountAccruedCOS] = ARS.GL_ACCT_ACC_COS,
			[GLAccountAccruedCOSDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_ACC_COS),
			[GLAccountWIP] = ARS.GL_ACCT_WIP,
			[GLAccountWIPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_WIP),
			[GLAccountCityTax] = ARS.GL_ACCT_CITY,
			[GLAccountCityTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_CITY),
			[GLAccountCountyTax] = ARS.GL_ACCT_COUNTY,
			[GLAccountCountyTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_COUNTY),
			[GLAccountStateTax] = ARS.GL_ACCT_STATE,
			[GLAccountStateTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = ARS.GL_ACCT_STATE),
			[Converted] = CASE WHEN ARS.CONVERTED = 1 THEN 'Yes' ELSE 'No' END,
			[CreateDate] = AR.CREATE_DATE,
			[UserID] = AR.USERID,
			[IsVoided] = CAST(COALESCE(AR.VOID_FLAG,0) AS BIT),
			[VoidComment] = AR.VO_COMMENT,
			[BillingComment] = CASE WHEN ISNULL(CAST(BC.BILL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BC.BILL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingJobComment] = CASE WHEN ISNULL(CAST(BCJ.JOB_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCJ.JOB_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingDetailComment] = CASE WHEN ISNULL(CAST(BCD.DTL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCD.DTL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalClientComment] = CASE WHEN ISNULL(CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalFunctionComment] = CASE WHEN ISNULL(CAST(BAD.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAD.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)) ELSE NULL END,
			[CampaignComments] = CAMP.CMP_COMMENTS,
			[ClientReference] = J.JOB_CLI_REF,
			[JobComment] = J.JOB_COMMENTS,
			[JobComponentComment] = JC.JOB_COMP_COMMENTS,
			[EstimateNumber] = ESTC.ESTIMATE_NUMBER,
			[EstimateComponentNumber] = ESTC.EST_COMPONENT_NBR,
			[EstimateComment] = CASE WHEN ISNULL(ESTC.EST_LOG_COMMENT, '') <> '' THEN ESTC.EST_LOG_COMMENT ELSE NULL END,
			[EstimateComponentComment] = CASE WHEN ISNULL(ESTC.EST_COMP_COMMENT, '') <> '' THEN ESTC.EST_COMP_COMMENT ELSE NULL END,
			[EstimateQuoteComment] = CASE WHEN ISNULL(ESTC.EST_QTE_COMMENT, '') <> '' THEN ESTC.EST_QTE_COMMENT ELSE NULL END,
			[EstimateRevisionComment] = CASE WHEN ISNULL(ESTC.EST_REV_COMMENT, '') <> '' THEN ESTC.EST_REV_COMMENT ELSE NULL END,
			[EstimateFunctionComment] = CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT, '') <> '' THEN ESTC.EST_FNC_COMMENT ELSE NULL END,
			[InvoiceFooterComment] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, 'P') <> 'P'THEN C.CL_MFOOTER ELSE C.CL_FOOTER END, -- ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER),
			[BillingAddress] = AR.BILLING_ADDRESS,
			[JobTypeCode] = JC.JT_CODE,
			[JobTypeDescription] = JT.JT_DESC,
			[JobMediaDateToBill] = JC.MEDIA_BILL_DATE
			
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									  AR.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
			[dbo].[OFFICE] AS O ON O.OFFICE_CODE = ARS.OFFICE_CODE LEFT OUTER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
									 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND
									P.DIV_CODE = ARS.DIV_CODE AND
									P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN 
		    [dbo].[ACCOUNT_EXECUTIVE] AS AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = ARS.CMP_IDENTIFIER LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ARS.JOB_NUMBER LEFT OUTER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			[dbo].[JOB_TYPE] JT ON JC.JT_CODE = JT.JT_CODE LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
			[dbo].[MARKET] AS M ON M.MARKET_CODE = ARS.MARKET_CODE LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PPS ON PPS.PPPERIOD = ARS.SALE_POST_PERIOD LEFT OUTER JOIN
			[dbo].[V_AR_INVOICE_DUE_DATES] AS ARDD ON ARDD.AR_INV_NBR = ARS.AR_INV_NBR LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMPAE ON EMPAE.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
		    [dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			(SELECT 
						BH.BA_ID,
						BH.JOB_NUMBER,
						BH.JOB_COMPONENT_NBR,
						BH.AR_INV_NBR,
						[BILL_APPROVAL_COMMENT] = BH.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] AS BH 
					WHERE BH.BA_ID = (SELECT MAX(B.BA_ID) FROM [dbo].[BILL_APPR_HDR] B WHERE B.JOB_NUMBER = BH.JOB_NUMBER AND
																						     B.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR AND
																							 B.AR_INV_NBR = BH.AR_INV_NBR 
																							 )) AS BAC ON BAC.JOB_NUMBER = ARS.JOB_NUMBER AND 
																									 BAC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND 
																									 BAC.AR_INV_NBR = ARS.AR_INV_NBR LEFT OUTER JOIN
			(SELECT 
						BH.BA_ID,
						BH.JOB_NUMBER,
						BH.JOB_COMPONENT_NBR,
						BH.AR_INV_NBR,
						BILL_APPR_DTL.FNC_CODE,
						[BILL_APPROVAL_FUNCTION_COMMENT] = BILL_APPR_DTL.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] AS BH INNER JOIN
						[dbo].[BILL_APPR_DTL] ON BILL_APPR_DTL.BA_ID = BH.BA_ID AND
												 BILL_APPR_DTL.JOB_NUMBER = BH.JOB_NUMBER AND
												 BILL_APPR_DTL.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR
					WHERE BH.BA_ID = (SELECT MAX(B.BA_ID) FROM [dbo].[BILL_APPR_HDR] B WHERE B.JOB_NUMBER = BH.JOB_NUMBER AND
																						     B.JOB_COMPONENT_NBR = BH.JOB_COMPONENT_NBR AND
																							 B.AR_INV_NBR = BH.AR_INV_NBR 
																							 )) AS BAD ON BAD.JOB_NUMBER = ARS.JOB_NUMBER AND 
																									 BAD.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND 
																									 BAD.AR_INV_NBR = ARS.AR_INV_NBR AND
																									 BAD.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
		    (SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_JOB] AS BCJ ON BCJ.INV_NBR = ARS.AR_INV_NBR AND
													BCJ.JOB_NUMBER = ARS.JOB_NUMBER AND
													BCJ.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_DTL] AS BCD ON BCD.INV_NBR = ARS.AR_INV_NBR AND
													BCD.JOB_NUMBER = ARS.JOB_NUMBER AND
													BCD.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND
													BCD.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN
				(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EC.ESTIMATE_NUMBER,
						EC.EST_COMPONENT_NBR,
						ERD.FNC_CODE,
						EST_LOG_COMMENT = CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						EST_LOG_COMMENT_HTML = CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						EST_COMP_COMMENT = CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						EST_COMP_COMMENT_HTML = CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						EST_QTE_COMMENT = CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)),  
						EST_QTE_COMMENT_HTML = CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)),
						EST_REV_COMMENT = CAST(ER.EST_REV_COMMENT AS varchar(MAX)),  
						EST_REV_COMMENT_HTML = CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX)), 
						EST_FNC_COMMENT = dbo.[advfn_invoice_printing_estimate_function_comment](ERD.ESTIMATE_NUMBER, ERD.EST_COMPONENT_NBR, ERD.EST_QUOTE_NBR, ERD.EST_REV_NBR, ERD.FNC_CODE, 0), 
						EST_FNC_COMMENT_HTML = dbo.[advfn_invoice_printing_estimate_function_comment](ERD.ESTIMATE_NUMBER, ERD.EST_COMPONENT_NBR, ERD.EST_QUOTE_NBR, ERD.EST_REV_NBR, ERD.FNC_CODE, 1)
					FROM 
						[dbo].[JOB_COMPONENT] AS JC LEFT OUTER JOIN 
						[dbo].[ESTIMATE_APPROVAL] AS EA ON EA.JOB_NUMBER = JC.JOB_NUMBER AND 
														   EA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
						[dbo].[ESTIMATE_LOG] AS EL ON EL.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
															EC.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_QUOTE] AS EQ ON EQ.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
														EQ.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
														EQ.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_REV] AS ER ON ER.EST_REV_NBR = EA.EST_REVISION_NBR AND 
													  ER.EST_QUOTE_NBR = EA.EST_QUOTE_NBR AND 
													  ER.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR AND 
													  ER.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER LEFT OUTER JOIN 
						[dbo].[ESTIMATE_REV_DET] AS ERD ON ERD.EST_REV_NBR = ER.EST_REV_NBR AND 
														   ERD.EST_QUOTE_NBR = ER.EST_QUOTE_NBR AND 
														   ERD.EST_COMPONENT_NBR = ER.EST_COMPONENT_NBR AND 
														   ERD.ESTIMATE_NUMBER = ER.ESTIMATE_NUMBER
					GROUP BY 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EC.ESTIMATE_NUMBER,
						EC.EST_COMPONENT_NBR, 
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						ERD.FNC_CODE,
						CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT AS varchar(MAX)),
						CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))) AS ESTC ON ESTC.JOB_NUMBER = ARS.JOB_NUMBER AND
																			 ESTC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR AND
																			 ESTC.FNC_CODE = ARS.FNC_CODE
		WHERE
			(
			(@BreakoutCoOpBilling = 1 AND ARS.AR_INV_SEQ <> 99)
		OR
			(@BreakoutCoOpBilling = 0 AND ARS.AR_INV_SEQ = 99 OR ARS.AR_INV_SEQ = 0)
			)
		AND
			(
			(ISNULL(ARS.MEDIA_TYPE,'P') = 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			OR
			(ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			OR
			(ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)
			)
			AND
			--AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode AND
			(ARS.OFFICE_CODE IN (SELECT items FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(ARS.CL_CODE IN (SELECT items FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			(ARS.CL_CODE + '|' + ARS.DIV_CODE IN (SELECT items FROM dbo.udf_split_list(@DIVISION_LIST, ',')) OR @DIVISION_LIST IS NULL) AND
			(ARS.CL_CODE + '|' + ARS.DIV_CODE + '|' + ARS.PRD_CODE IN (SELECT items FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) OR @PRODUCT_LIST IS NULL)

		UNION ALL
		
		SELECT
			[OfficeCode] = AR.OFFICE_CODE,
			[OfficeName] = O.OFFICE_NAME,
			[ClientCode] = AR.CL_CODE,
			[ClientName] = C.CL_NAME,
			[ClientAddress] = C.CL_ADDRESS1,
			[ClientAddress2] = C.CL_ADDRESS2,
			[ClientCity] = C.CL_CITY,
			[ClientCounty] = C.CL_COUNTY,
			[ClientState] = C.CL_STATE,
			[ClientZip] = C.CL_ZIP,
			[ClientCountry] = C.CL_COUNTRY,
			[ClientBillingAddress] = C.CL_BADDRESS1,
			[ClientBillingAddress2] = C.CL_BADDRESS2,
			[ClientBillingCity] = C.CL_BCITY,
			[ClientBillingCounty] = C.CL_BCOUNTY,
			[ClientBillingState] = C.CL_BSTATE,
			[ClientBillingZip] = C.CL_BZIP,
			[ClientBillingCountry] = C.CL_BCOUNTRY,
			[DivisionCode] = AR.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = AR.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[ProductBillingAddress] = P.PRD_BILL_ADDRESS1,
			[ProductBillingAddress2] = P.PRD_BILL_ADDRESS2,
			[ProductBillingCity] = P.PRD_BILL_CITY,
			[ProductBillingCounty] = P.PRD_BILL_COUNTY,
			[ProductBillingState] = P.PRD_BILL_STATE,
			[ProductBillingZip] = P.PRD_BILL_ZIP,
			[ProductBillingCountry] = P.PRD_BILL_COUNTRY,
			[DefaultAECode] = ISNULL(AE.EMP_CODE,''),
			[DefaultAEName] = COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
			[ProductUDF1] = ISNULL(P.USER_DEFINED1,''),
			[ProductUDF2] = ISNULL(P.USER_DEFINED2,''),
			[ProductUDF3] = ISNULL(P.USER_DEFINED3,''),
			[ProductUDF4] = ISNULL(P.USER_DEFINED4,''),
			[ARPostPeriod] = AR.AR_POST_PERIOD,
			[SalePostPeriod] = AR.AR_POST_PERIOD,
			[ARPostPeriodStartDate] = PP.PPSRTDATE,
			[ARPostPeriodEndDate] = PP.PPENDDATE,
			[ARPostPeriodDescription] = PP.PPDESC,
			[ARPostPeriodGLMonth] = PP.PPGLMONTH,
			[ARPostPeriodGLYear] = PP.PPGLYEAR,
			[SalePostPeriodStartDate] = PP.PPSRTDATE,
			[SalePostPeriodEndDate] = PP.PPENDDATE,
			[SalePostPeriodDescription] = PP.PPDESC,
			[SalePostPeriodGLMonth] = PP.PPGLMONTH,
			[SalePostPeriodGLYear] = PP.PPGLYEAR,
			[InvoiceDate] = AR.AR_INV_DATE,
			[InvoiceNumber] = AR.AR_INV_NBR,
			[InvoiceSEQ] = AR.AR_INV_SEQ,
			[InvoiceType] = AR.AR_TYPE,
			[InvoiceDescription] = AR.AR_DESCRIPTION,
			[InvoiceAssignBy] = '',
			[InvoiceCategory] = ARDD.INV_CAT_DESC,
			[InvoiceDueDate] = ARDD.AR_INV_DUE_DATE,
			[MediaType] = ISNULL(AR.REC_TYPE,'P'),
			[MediaTypeDescription] = CASE WHEN ISNULL(AR.REC_TYPE, 'P') = 'P' THEN 'Production Manual Invoice'
										  WHEN ISNULL(AR.REC_TYPE, 'P') = 'M' THEN 'Media Manual Invoice' ELSE 'Production Manual Invoice' END,
			[ManualFlag] = 'Yes',
			[SalesClassCode] = AR.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[CampaignID] = NULL,
			[CampaignCode] = NULL,
			[CampaignName] = NULL,
			[ClientPO] = NULL,
			[AccountExecutiveCode] = NULL,
			[AccountExecutive] = NULL,
			[JobNumber] = NULL,
			[JobDescription] = NULL,
			[JobComponent] = NULL,
			[JobComponentDescription] = NULL,
			[FunctionType] = NULL,
			[FunctionCode] = NULL,
			[FunctionDescription] = NULL,
			[FunctionHeadingDescription] = NULL,
			[OrderNumber] = NULL,
			[OrderLine] = NULL,
			[MediaMonth] = NULL,
			[MediaYear] = NULL,
			[MediaStartDate] = NULL,
			[MediaEndDate] = NULL,
			[MediaMarket] = NULL,
			[MediaMarketDescription] = NULL,
			[InvoiceTotal] = AR.AR_INV_AMOUNT,
			[Sales] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[CostOfSales] = ISNULL(AR.AR_COS_AMT, 0),
			[GrossIncome] = (ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0))) - ISNULL(AR.AR_COS_AMT, 0),
			[DeferredSales] = 0,
			[DeferredSalesAR] = 0,
			[DeferredCostOfSales] = 0,
			[DeferredCostOfSalesAR] = 0,
			[DeferredGrossIncome] = 0,
			[DeferredGrossIncomeAR] = 0,
			[HoursOrQuantity] = 0,
			[Time] = 0,
			[IncomeOnly] = 0,
			[Commission] = ISNULL(AR.AR_COMM_AMT, 0),
			[Cost] = 0,
			[VendorTax] = 0,
			[MediaNetCharge] = 0,
			[MediaRebate] = 0,
			[MediaAdditionalCharge] = 0,
			[MediaDiscount] = 0,
			[AdvanceIncome] = 0,
			[AdvanceCommission] = 0,
			[AdvanceCost] = 0,
			[AdvanceRetainedSales] = 0,
			[AdvanceNonresaleAmount] = 0,
			[TotalBillLessResaleTax] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[CityTax] = ISNULL(AR.AR_CITY_AMT, 0),
			[CountyTax] = ISNULL(AR.AR_COUNTY_AMT, 0),
			[StateTax] = ISNULL(AR.AR_STATE_AMT, 0),
			[ResaleTax] = (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[TotalBill] = ISNULL(AR.AR_INV_AMOUNT, 0),
			[TaxAtBilling] = 'No',
			[TaxCode] = NULL,
			[CityTaxPct] = NULL,
			[CountyTaxPct] = NULL,
			[StateTaxPct] = NULL,
			[GLXACT] = AR.GLEXACT,
			[GLXACTDeferred] = NULL,
			[GLAccountAR] = AR.GLACODE_AR,
			[GLAccountARDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_AR),
			[GLAccountSales] = AR.GLACODE_SALES,
			[GLAccountSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_SALES),
			[GLAccountDeferredSales] = NULL,
			[GLAccountDeferredSalesDescription] = NULL,
			[GLAccountCostOfSales] = AR.GLACODE_COS,
			[GLAccountCostOfSalesDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_COS),
			[GLAccountAccruedAP] = NULL,
			[GLAccountAccruedAPDescription] = NULL,
			[GLAccountAccruedCOS] = NULL,
			[GLAccountAccruedCOSDescription] = NULL,
			[GLAccountWIP] = AR.GLACODE_OFFSET,
			[GLAccountWIPDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_OFFSET),
			[GLAccountCityTax] = AR.GLACODE_CITY,
			[GLAccountCityTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_CITY),
			[GLAccountCountyTax] = AR.GLACODE_COUNTY,
			[GLAccountCountyTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_COUNTY),
			[GLAccountStateTax] = AR.GLACODE_STATE,
			[GLAccountStateTaxDescription] = (SELECT GLADESC FROM #GL_ACCOUNTS GLA WHERE GLA.GLACODE = AR.GLACODE_STATE),
			[Converted] = 'No',
			[CreateDate] = AR.CREATE_DATE,
			[UserID] = AR.USERID,
			[IsVoided] = CAST(COALESCE(AR.VOID_FLAG,0) AS BIT),
			[VoidComment] = AR.VO_COMMENT,
			[BillingComment] = NULL,
			[BillingJobComment] = NULL,
			[BillingDetailComment] = NULL,
			[BillingApprovalClientComment] = NULL,
			[BillingApprovalFunctionComment] = NULL,
			[CampaignComments] = NULL,
			[ClientReference] = NULL,
			[JobComment] = NULL,
			[JobComponentComment] = NULL,
			[EstimateNumber] = NULL,
			[EstimateComponentNumber] = NULL,
			[EstimateComment] = NULL,
			[EstimateComponentComment] = NULL,
			[EstimateQuoteComment] = NULL,
			[EstimateRevisionComment] = NULL,
			[EstimateFunctionComment] = NULL,
			[InvoiceFooterComment] = NULL,
			[BillingAddress] = AR.BILLING_ADDRESS,
			[JobTypeCode] = NULL,
			[JobTypeDescription] = NULL,
			[JobMediaDateToBill] = NULL
		FROM
			[dbo].[ACCT_REC] AS AR INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND
									 D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND
									P.DIV_CODE = AR.DIV_CODE AND
									P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN 
		    [dbo].[ACCOUNT_EXECUTIVE] AS AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
				AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			[dbo].[OFFICE] AS O ON O.OFFICE_CODE = AR.OFFICE_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD LEFT OUTER JOIN
			[dbo].[V_AR_INVOICE_DUE_DATES] AS ARDD ON ARDD.AR_INV_NBR = AR.AR_INV_NBR LEFT OUTER JOIN
			[dbo].[EMPLOYEE] AS EMP ON EMP.EMP_CODE = AE.EMP_CODE
		WHERE
			AR.MANUAL_INV = 1 AND
			1 = CASE WHEN @BreakoutCoOpBilling = 1 THEN CASE WHEN AR.AR_INV_SEQ <> 99 THEN 1 ELSE 0 END
					 ELSE CASE WHEN AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0 THEN 1 ELSE 0 END END AND
			AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode AND
			(AR.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
			(AR.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
			1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (AR.CL_CODE + '|' + AR.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
			1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (AR.CL_CODE + '|' + AR.DIV_CODE + '|' + AR.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END) AS SJ
	LEFT OUTER JOIN [dbo].[V_MEDIA_HDR] VMH ON VMH.ORDER_NBR = SJ.OrderNumber
	LEFT OUTER JOIN [dbo].[VENDOR] V ON VMH.VN_CODE = V.VN_CODE
	WHERE 1 = CASE WHEN @StartingInvoiceDate IS NULL AND @EndingInvoiceDate IS NULL THEN 1
	               WHEN SJ.InvoiceDate BETWEEN @StartingInvoiceDate AND @EndingInvoiceDate THEN 1 ELSE 0 END
) detail

	END




GO