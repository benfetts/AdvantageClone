CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_mediainvoicedetail]
	@UserCode varchar(100),
	@InvoiceNumber int,
	@SequenceNumber AS smallint,
	@InvoiceType varchar(1),
	@AddressBlockType smallint,
	@PrintClientName AS bit,
	@PrintDivisionName bit,
	@PrintProductDescription bit,
	@PrintContactAfterAddress bit,
	@ApplyExchangeRate smallint,
	@ExchangeRateAmount decimal(10, 6),
	@TotalsShowTaxSeparately bit,
	@TotalsShowCommissionSeparately bit,
	@TotalsShowRebateSeparately bit,
	@UseInvoiceCategoryDescription bit,
	@InvoiceTitle varchar(MAX),
	@InvoiceFooterCommentType smallint,
	@InvoiceFooterComment varchar(MAX),
	@ShowCodes AS bit,
	@ContactType AS int,
	@IsDraft AS bit,
	@Batch AS varchar(100)
AS
BEGIN
	
	CREATE TABLE #MediaInvoiceDetails( 
		[ClientCode] varchar(6) COLLATE DATABASE_DEFAULT, 
		[ClientName] varchar(40) COLLATE DATABASE_DEFAULT, 
		[DivisionCode] varchar(6) COLLATE DATABASE_DEFAULT,
		[DivisionName] varchar(40) COLLATE DATABASE_DEFAULT, 
		[ProductCode] varchar(6) COLLATE DATABASE_DEFAULT,
		[ProductName] varchar(40) COLLATE DATABASE_DEFAULT, 
		[OfficeCode] varchar(4) COLLATE DATABASE_DEFAULT,
		[SalesClassCode] varchar(6) COLLATE DATABASE_DEFAULT,
		[SalesClassDescription] varchar(30) COLLATE DATABASE_DEFAULT,
		[MarketCode] varchar(10) COLLATE DATABASE_DEFAULT, 
		[MarketDescription] varchar(40) COLLATE DATABASE_DEFAULT,  
		[CampaignID] int,
		[CampaignCode] varchar(6) COLLATE DATABASE_DEFAULT,  
		[CampaignName] varchar(128) COLLATE DATABASE_DEFAULT, 
		[CampaignComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[OrderNumber] int,
		[OrderLineNumber] smallint, 
		[MediaType] varchar(1) COLLATE DATABASE_DEFAULT,    
		[OrderDescription] varchar(60) COLLATE DATABASE_DEFAULT,
		[InvoiceNumber] int, 
		[InvoiceSequenceNumber] smallint,
		[InvoiceType] varchar(2) COLLATE DATABASE_DEFAULT,
		[InvoiceDate] smalldatetime,
		[ClientPO] varchar(25) COLLATE DATABASE_DEFAULT, 
		[ClientReference] varchar(60) COLLATE DATABASE_DEFAULT, 
		[InvoiceCategoryCode] varchar(6) COLLATE DATABASE_DEFAULT, 
		[InvoiceCategoryDescription] varchar(20) COLLATE DATABASE_DEFAULT,
		[OrderComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[OrderHouseComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[InvoiceDueDate] smalldatetime,
		[VendorCode] varchar(6) COLLATE DATABASE_DEFAULT,
		[VendorName] varchar(40) COLLATE DATABASE_DEFAULT,
		[OrderMonths] varchar(100) COLLATE DATABASE_DEFAULT,  
		[HeaderStartDate] smalldatetime, 
		[HeaderEndDate] smalldatetime,   
		[OrderStartDate] smalldatetime, 
		[OrderEndDate] smalldatetime, 
		[OrderMonth] smallint,
		[OrderYear] smallint,
		[Headline] varchar(60) COLLATE DATABASE_DEFAULT, 
		[InsertDate] smalldatetime,
		[Material] varchar(60) COLLATE DATABASE_DEFAULT,
		[EditorialIssue] varchar(60) COLLATE DATABASE_DEFAULT,  
		[Section] varchar(60) COLLATE DATABASE_DEFAULT, 
		[Quantity] decimal(18, 2), 
		[Size] varchar(30) COLLATE DATABASE_DEFAULT, 
		[StartDates] smalldatetime, 
		[EndDates] smalldatetime,
		[CreativeSize] varchar(60) COLLATE DATABASE_DEFAULT, 
		[URL] varchar(60) COLLATE DATABASE_DEFAULT,  
		[InternetType] varchar(30) COLLATE DATABASE_DEFAULT, 
		[CopyArea] varchar(40) COLLATE DATABASE_DEFAULT, 
		[Location] varchar(60) COLLATE DATABASE_DEFAULT, 
		[OutdoorType] varchar(30) COLLATE DATABASE_DEFAULT, 
		[Programming] varchar(50) COLLATE DATABASE_DEFAULT,  
		[Length] smallint,   
		[Tag] varchar(10) COLLATE DATABASE_DEFAULT,   
		[StartTime] varchar(10) COLLATE DATABASE_DEFAULT,   
		[EndTime] varchar(10) COLLATE DATABASE_DEFAULT,
		[GuaranteedImpressions] int,
		[Monday] bit,
		[Tuesday] bit,
		[Wednesday] bit,
		[Thursday] bit,
		[Friday] bit,
		[Saturday] bit,
		[Sunday] bit,
		[NumberOfSpots] int,   
		[Remarks] varchar(254) COLLATE DATABASE_DEFAULT,
		[JobComponent] varchar(10) COLLATE DATABASE_DEFAULT,
		[JobNumber] int NULL, 
		[ComponentNumber] smallint NULL, 
		[JobDescription] varchar(60) COLLATE DATABASE_DEFAULT,
		[ComponentDescription] varchar(60) COLLATE DATABASE_DEFAULT,
		[OrderDetailComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[OrderDetailHouseComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[ExtraChargesAdditional] decimal(18, 2),
		[ExtraChargesNet] decimal(18, 2),
		[Discount] decimal(18, 2),
		[AdNumber] varchar(30) COLLATE DATABASE_DEFAULT,
		[AdNumberDescription] varchar(60) COLLATE DATABASE_DEFAULT,
		[Hours] decimal(18, 2), 
		[Rate] decimal(18, 2), 
		[RebateAmount] decimal(18, 2),
		[NetAmount] decimal(18, 2), 
		[CommissionAmount] decimal(18, 2),
		[NonResaleTax] decimal(18, 2),  
		[StateTax] decimal(18, 2),
		[CountyTax] decimal(18, 2), 
		[CityTax] decimal(18, 2), 
		[TotalTax] decimal(18, 2),
		[BillAmount] decimal(18, 2),
		[TotalAmount] decimal(18, 2),
		[BilledToDateRebateAmount] decimal(18, 2),
		[BilledToDateCommissionAmount] decimal(18, 2), 
		[BilledToDateStateTax] decimal(18, 2),
		[BilledToDateCountyTax] decimal(18, 2), 
		[BilledToDateCityTax] decimal(18, 2), 
		[BilledToDateTotalTax] decimal(18, 2), 
		[BilledToDateAmount] decimal(18, 2),
		[PriorBillAmountRebateAmount] decimal(18, 2), 
		[PriorBillAmountCommissionAmount] decimal(18, 2), 
		[PriorBillAmountStateTax] decimal(18, 2),
		[PriorBillAmountCountyTax] decimal(18, 2), 
		[PriorBillAmountCityTax] decimal(18, 2), 
		[PriorBillAmountTotalTax] decimal(18, 2), 
		[PriorBillAmount] decimal(18, 2),
		[Address] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[InvoiceCategory] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[InvoiceFooterComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[InvoiceFooterCommentFontSize] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[FullInvoiceNumber] varchar(11) COLLATE DATABASE_DEFAULT,
		[BillingComment] varchar(MAX) COLLATE DATABASE_DEFAULT,
		[CloseDate] smalldatetime,
		[VendorInvoiceCategoryID] int,
		[VendorInvoiceCategory] varchar(100) COLLATE DATABASE_DEFAULT,
		[VATNumber] varchar(50) COLLATE DATABASE_DEFAULT) 
			
	CREATE TABLE #MediaInvoiceDetailsBilledToDate( 
		[OrderNumber] int,
		[OrderLineNumber] smallint, 
		[Hours] decimal(18, 2), 
		[Rate] decimal(18, 2), 
		[RebateAmount] decimal(18, 2),
		[NetAmount] decimal(18, 2), 
		[CommissionAmount] decimal(18, 2),
		[NonResaleTax] decimal(18, 2),  
		[StateTax] decimal(18, 2),
		[CountyTax] decimal(18, 2), 
		[CityTax] decimal(18, 2), 
		[TotalTax] decimal(18, 2),
		[TotalAmount] decimal(18, 2))
		
	CREATE TABLE #MediaInvoiceDetailsPriorBillAmount( 
		[OrderNumber] int,
		[OrderLineNumber] smallint, 
		[Hours] decimal(18, 2), 
		[Rate] decimal(18, 2), 
		[RebateAmount] decimal(18, 2),
		[NetAmount] decimal(18, 2), 
		[CommissionAmount] decimal(18, 2),
		[NonResaleTax] decimal(18, 2),  
		[StateTax] decimal(18, 2),
		[CountyTax] decimal(18, 2), 
		[CityTax] decimal(18, 2), 
		[TotalTax] decimal(18, 2),
		[TotalAmount] decimal(18, 2))
		
	DECLARE @InvoiceDate AS smalldatetime	
	
	IF @IsDraft = 1 BEGIN
	
		SET @InvoiceDate = CAST(GETDATE() AS smalldatetime)
				
	END ELSE BEGIN
	
		SELECT 
			@InvoiceDate = MAX(ARID.[AR_INV_DATE]) 
		FROM 
			(SELECT 
					AR.AR_INV_NBR, 
					AR.AR_TYPE, 
					[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
					[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
				FROM 
					[dbo].[ACCT_REC] AS AR 
				WHERE 
					AR.AR_INV_NBR = @InvoiceNumber AND 
					AR.AR_TYPE <> 'VO'
				GROUP BY 
					AR.AR_INV_NBR, 
					AR.AR_TYPE) AS ARID
				
	END
	
	IF @IsDraft = 1 BEGIN
	
		INSERT INTO #MediaInvoiceDetailsBilledToDate
		SELECT
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR,
			[HRS_QTY] = CAST(SUM(ARS.HRS_QTY) AS decimal(18,2)),
			[RATE] = CAST(0 AS decimal(18,2)),
			[REBATE_AMT] = CAST(ISNULL(SUM(ARS.REBATE_AMT), 0) AS decimal(18,2)),
			[EXT_AMT] = CAST(SUM(ISNULL(ARS.COST_AMT, 0)+ ISNULL(ARS.ADDITIONAL_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) AS decimal(18,2)),
			[EXT_MARKUP_AMT] = SUM(CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) AS decimal(18,2))
														                     ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)) END),
			[EXT_NONRESALE_TAX] = CAST(ISNULL(SUM(ARS.NON_RESALE_AMT), 0) AS decimal(18,2)),
			[EXT_STATE_RESALE] = CAST(ISNULL(SUM(ARS.STATE_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_COUNTY_RESALE] = CAST(ISNULL(SUM(ARS.CNTY_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_CITY_RESALE] = CAST(ISNULL(SUM(ARS.CITY_TAX_AMT), 0) AS decimal(18,2)),
			[TOTAL_TAX] = CAST(SUM(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0)) AS decimal(18,2)),
			[LINE_TOTAL] = CAST(ISNULL(SUM(ARS.TOTAL_BILL), 0) AS decimal(18,2))
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
									  AR.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_SEQ <> 99 AND
			ARS.ORDER_NBR IN (SELECT DISTINCT ORDER_NBR FROM [dbo].[AR_FUNCTION] WHERE ORDER_NBR IS NOT NULL AND BILLING_USER LIKE @UserCode + '%')
		GROUP BY
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR	
		
	END ELSE BEGIN
	
		INSERT INTO #MediaInvoiceDetailsBilledToDate
		SELECT
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR,
			[HRS_QTY] = CAST(SUM(ARS.HRS_QTY) AS decimal(18,2)),
			[RATE] = CAST(0 AS decimal(18,2)),
			[REBATE_AMT] = CAST(ISNULL(SUM(ARS.REBATE_AMT), 0) AS decimal(18,2)),
			[EXT_AMT] = CAST(SUM(ISNULL(ARS.COST_AMT, 0)+ ISNULL(ARS.ADDITIONAL_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) AS decimal(18,2)),
			[EXT_MARKUP_AMT] = SUM(CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) AS decimal(18,2))
														                     ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)) END),
			[EXT_NONRESALE_TAX] = CAST(ISNULL(SUM(ARS.NON_RESALE_AMT), 0) AS decimal(18,2)),
			[EXT_STATE_RESALE] = CAST(ISNULL(SUM(ARS.STATE_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_COUNTY_RESALE] = CAST(ISNULL(SUM(ARS.CNTY_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_CITY_RESALE] = CAST(ISNULL(SUM(ARS.CITY_TAX_AMT), 0) AS decimal(18,2)),
			[TOTAL_TAX] = CAST(SUM(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0)) AS decimal(18,2)),
			[LINE_TOTAL] = CAST(ISNULL(SUM(ARS.TOTAL_BILL), 0) AS decimal(18,2))
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
									  AR.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_SEQ <> 99 AND
			ARS.ORDER_NBR IN (SELECT DISTINCT ORDER_NBR FROM [dbo].[AR_SUMMARY] WHERE AR_INV_NBR = @InvoiceNumber AND AR_INV_SEQ = @SequenceNumber AND ORDER_NBR IS NOT NULL)
		GROUP BY
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR	
		
	END
	
	IF @IsDraft = 1 BEGIN
	
		INSERT INTO #MediaInvoiceDetailsPriorBillAmount
		SELECT
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR,
			[HRS_QTY] = CAST(SUM(ARS.HRS_QTY) AS decimal(18,2)),
			[RATE] = CAST(0 AS decimal(18,2)),
			[REBATE_AMT] = CAST(ISNULL(SUM(ARS.REBATE_AMT), 0) AS decimal(18,2)),
			[EXT_AMT] = CAST(SUM(ISNULL(ARS.COST_AMT, 0)+ ISNULL(ARS.ADDITIONAL_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) AS decimal(18,2)),
			[EXT_MARKUP_AMT] = SUM(CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) AS decimal(18,2))
														                     ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)) END),
			[EXT_NONRESALE_TAX] = CAST(ISNULL(SUM(ARS.NON_RESALE_AMT), 0) AS decimal(18,2)),
			[EXT_STATE_RESALE] = CAST(ISNULL(SUM(ARS.STATE_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_COUNTY_RESALE] = CAST(ISNULL(SUM(ARS.CNTY_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_CITY_RESALE] = CAST(ISNULL(SUM(ARS.CITY_TAX_AMT), 0) AS decimal(18,2)),
			[TOTAL_TAX] = CAST(SUM(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0)) AS decimal(18,2)),
			[LINE_TOTAL] = CAST(ISNULL(SUM(ARS.TOTAL_BILL), 0) AS decimal(18,2))
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
									  AR.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_SEQ <> 99 AND
			ARS.ORDER_NBR IN (SELECT DISTINCT ORDER_NBR FROM [dbo].[AR_FUNCTION] WHERE ORDER_NBR IS NOT NULL AND BILLING_USER LIKE @UserCode + '%')
		GROUP BY
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR	
		
	END ELSE BEGIN
	
		INSERT INTO #MediaInvoiceDetailsPriorBillAmount
		SELECT
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR,
			[HRS_QTY] = CAST(SUM(ARS.HRS_QTY) AS decimal(18,2)),
			[RATE] = CAST(0 AS decimal(18,2)),
			[REBATE_AMT] = CAST(ISNULL(SUM(ARS.REBATE_AMT), 0) AS decimal(18,2)),
			[EXT_AMT] = CAST(SUM(ISNULL(ARS.COST_AMT, 0)+ ISNULL(ARS.ADDITIONAL_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) AS decimal(18,2)),
			[EXT_MARKUP_AMT] = SUM(CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) AS decimal(18,2))
														                     ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)) END),
			[EXT_NONRESALE_TAX] = CAST(ISNULL(SUM(ARS.NON_RESALE_AMT), 0) AS decimal(18,2)),
			[EXT_STATE_RESALE] = CAST(ISNULL(SUM(ARS.STATE_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_COUNTY_RESALE] = CAST(ISNULL(SUM(ARS.CNTY_TAX_AMT), 0) AS decimal(18,2)),
			[EXT_CITY_RESALE] = CAST(ISNULL(SUM(ARS.CITY_TAX_AMT), 0) AS decimal(18,2)),
			[TOTAL_TAX] = CAST(SUM(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0)) AS decimal(18,2)),
			[LINE_TOTAL] = CAST(ISNULL(SUM(ARS.TOTAL_BILL), 0) AS decimal(18,2))
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
									  AR.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_SEQ <> 99 AND
			ARS.ORDER_NBR IN (SELECT DISTINCT ORDER_NBR FROM [dbo].[AR_SUMMARY] WHERE AR_INV_NBR = @InvoiceNumber  AND AR_INV_SEQ = @SequenceNumber AND ORDER_NBR IS NOT NULL) AND
			ARS.AR_INV_NBR < @InvoiceNumber AND
			AR.AR_INV_DATE <= @InvoiceDate
		GROUP BY
			ARS.ORDER_NBR,
			ARS.ORDER_LINE_NBR	
		
	END
	
	IF @InvoiceType = 'M' BEGIN
	
		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				MH.MARKET_CODE,
				M.MARKET_DESC,
				MH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				MH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				MH.CLIENT_PO,
				MH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				MH.ORDER_COMMENT,
				MH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				MH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL([MOD].START_MONTHYEAR, '') <> '' AND ISNULL([MOD].END_MONTHYEAR, '') <> '' AND [MOD].START_MONTHYEAR <> [MOD].END_MONTHYEAR THEN [MOD].START_MONTHYEAR + '-' + [MOD].END_MONTHYEAR
									  ELSE ISNULL([MOD].START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = [MOD].[START_DATE], 
				[OrderEndDate] = [MOD].[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = MD.HEADLINE,
				[INSERT_DATE] = MD.[START_DATE],
				[MATERIAL] = MD.MATERIAL,
				[EDITION_ISSUE] = MD.EDITION_ISSUE,
				[SECTION] = MD.SECTION,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = MD.SIZE,
				[START_DATES] = MD.[START_DATE],
				[END_DATES] = MD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(MD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(MD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = MD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = MD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = MDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = MDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = MD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                 								           ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = MD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'M' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN
				[dbo].[MAGAZINE_DETAIL] AS MD ON MD.ORDER_NBR = ARS.ORDER_NBR AND
												 MD.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						MD.ORDER_NBR,  
						MD.LINE_NBR,   
						[REV_NBR] = MAX(MD.REV_NBR)
					FROM 
						[dbo].[MAGAZINE_DETAIL] AS MD   
					WHERE
						MD.BILLING_USER = @Batch 
					GROUP BY 
						MD.ORDER_NBR,  
						MD.LINE_NBR) AS MDD ON MDD.ORDER_NBR = MD.ORDER_NBR AND
											   MDD.LINE_NBR = MD.LINE_NBR AND
											   MDD.REV_NBR = MD.REV_NBR INNER JOIN
				(SELECT 
						MD.ORDER_NBR,  
						MD.LINE_NBR,   
						MD.REV_NBR,   
						[SEQ_NBR] = MAX(MD.SEQ_NBR)
					FROM 
						[dbo].[MAGAZINE_DETAIL] AS MD   
					WHERE
						MD.BILLING_USER = @Batch 
					GROUP BY 
						MD.ORDER_NBR,  
						MD.LINE_NBR,  
						MD.REV_NBR) AS MDSD ON MDSD.ORDER_NBR = MD.ORDER_NBR AND
											   MDSD.LINE_NBR = MD.LINE_NBR AND
											   MDSD.REV_NBR = MD.REV_NBR AND
											   MDSD.SEQ_NBR = MD.SEQ_NBR INNER JOIN
				[dbo].[MAGAZINE_HEADER] AS MH ON MH.ORDER_NBR = MD.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						[AR_INV_SEQ] = ARSD.DRAFT_INV_SEQ,  
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ,  
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_FUNCTION] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.DRAFT_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ) AS ARSD) AS [MOD] ON [MOD].ORDER_NBR = MD.ORDER_NBR AND
																  [MOD].LINE_NBR = MD.LINE_NBR LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = ARS.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = MH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = MD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = MD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = MD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = MD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = MH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[MAGAZINE_COMMENTS] AS MDC ON MDC.ORDER_NBR = MD.ORDER_NBR AND
													MDC.LINE_NBR = MD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = MD.ORDER_NBR AND
															  PBA.OrderLineNumber = MD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = MD.ORDER_NBR AND
														   BTD.OrderLineNumber = MD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
	
		END ELSE BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				MH.MARKET_CODE,
				M.MARKET_DESC,
				MH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				MH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				MH.CLIENT_PO,
				MH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				MH.ORDER_COMMENT,
				MH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				MH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL([MOD].START_MONTHYEAR, '') <> '' AND ISNULL([MOD].END_MONTHYEAR, '') <> '' AND [MOD].START_MONTHYEAR <> [MOD].END_MONTHYEAR THEN [MOD].START_MONTHYEAR + '-' + [MOD].END_MONTHYEAR
									  ELSE ISNULL([MOD].START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = [MOD].[START_DATE], 
				[OrderEndDate] = [MOD].[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = MD.HEADLINE,
				[INSERT_DATE] = MD.[START_DATE],
				[MATERIAL] = MD.MATERIAL,
				[EDITION_ISSUE] = MD.EDITION_ISSUE,
				[SECTION] = MD.SECTION,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = MD.SIZE,
				[START_DATES] = MD.[START_DATE],
				[END_DATES] = MD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(MD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(MD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = MD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = MD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = MDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = MDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = MD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                 								           ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'MAGAZINE INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = MD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'M' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[MAGAZINE_DETAIL] AS MD ON MD.ORDER_NBR = ARS.ORDER_NBR AND
												 MD.LINE_NBR = ARS.ORDER_LINE_NBR AND
												 MD.AR_INV_NBR = ARS.AR_INV_NBR AND
												 MD.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						MD.ORDER_NBR,  
						MD.LINE_NBR,   
						[REV_NBR] = MAX(MD.REV_NBR)
					FROM 
						[dbo].[MAGAZINE_DETAIL] AS MD 
					WHERE
						MD.AR_INV_NBR = @InvoiceNumber 
					GROUP BY 
						MD.ORDER_NBR,  
						MD.LINE_NBR) AS MDD ON MDD.ORDER_NBR = MD.ORDER_NBR AND
											   MDD.LINE_NBR = MD.LINE_NBR AND
											   MDD.REV_NBR = MD.REV_NBR INNER JOIN
				(SELECT 
						MD.ORDER_NBR,  
						MD.LINE_NBR,   
						MD.REV_NBR,   
						[SEQ_NBR] = MAX(MD.SEQ_NBR)
					FROM 
						[dbo].[MAGAZINE_DETAIL] AS MD 
					WHERE
						MD.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						MD.ORDER_NBR,  
						MD.LINE_NBR,  
						MD.REV_NBR) AS MDSD ON MDSD.ORDER_NBR = MD.ORDER_NBR AND
											   MDSD.LINE_NBR = MD.LINE_NBR AND
											   MDSD.REV_NBR = MD.REV_NBR AND
											   MDSD.SEQ_NBR = MD.SEQ_NBR INNER JOIN
				[dbo].[MAGAZINE_HEADER] AS MH ON MH.ORDER_NBR = MD.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						ARSD.AR_INV_SEQ,  
						ARSD.AR_TYPE,
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE,
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_SUMMARY] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.AR_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE) AS ARSD) AS [MOD] ON [MOD].ORDER_NBR = MD.ORDER_NBR AND
																 [MOD].LINE_NBR = MD.LINE_NBR  LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = MH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = MH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = MD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = MD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = MD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = MD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = MH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[MAGAZINE_COMMENTS] AS MDC ON MDC.ORDER_NBR = MD.ORDER_NBR AND
													MDC.LINE_NBR = MD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = MD.ORDER_NBR AND
															  PBA.OrderLineNumber = MD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = MD.ORDER_NBR AND
														   BTD.OrderLineNumber = MD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID

		END
	
	END ELSE IF @InvoiceType = 'N' BEGIN 

		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				NH.MARKET_CODE,
				M.MARKET_DESC,
				NH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				NH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				NH.CLIENT_PO,
				NH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				NH.ORDER_COMMENT,
				NH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				NH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(NOD.START_MONTHYEAR, '') <> '' AND ISNULL(NOD.END_MONTHYEAR, '') <> '' AND NOD.START_MONTHYEAR <> NOD.END_MONTHYEAR THEN NOD.START_MONTHYEAR + '-' + NOD.END_MONTHYEAR
									  ELSE ISNULL(NOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = NOD.[START_DATE], 
				[OrderEndDate] = NOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = ND.HEADLINE,
				[INSERT_DATE] = ND.[START_DATE],
				[MATERIAL] = ND.MATERIAL,
				[EDITION_ISSUE] = ND.EDITION_ISSUE,
				[SECTION] = ND.SECTION,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ND.SIZE,
				[START_DATES] = ND.[START_DATE],
				[END_DATES] = ND.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(ND.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(ND.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = ND.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = ND.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = NDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = ND.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = ND.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'N' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				[dbo].[NEWSPAPER_DETAIL] AS ND ON ND.ORDER_NBR = ARS.ORDER_NBR AND
												  ND.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						ND.ORDER_NBR,  
						ND.LINE_NBR,   
						[REV_NBR] = MAX(ND.REV_NBR)
					FROM 
						[dbo].[NEWSPAPER_DETAIL] AS ND   
					WHERE
						ND.BILLING_USER = @Batch  
					GROUP BY 
						ND.ORDER_NBR,  
						ND.LINE_NBR) AS NDD ON NDD.ORDER_NBR = ND.ORDER_NBR AND
											   NDD.LINE_NBR = ND.LINE_NBR AND
											   NDD.REV_NBR = ND.REV_NBR INNER JOIN
				(SELECT 
						ND.ORDER_NBR,  
						ND.LINE_NBR,   
						ND.REV_NBR,   
						[SEQ_NBR] = MAX(ND.SEQ_NBR)
					FROM 
						[dbo].[NEWSPAPER_DETAIL] AS ND   
					WHERE
						ND.BILLING_USER = @Batch  
					GROUP BY 
						ND.ORDER_NBR,  
						ND.LINE_NBR,  
						ND.REV_NBR) AS NDSD ON NDSD.ORDER_NBR = ND.ORDER_NBR AND
											   NDSD.LINE_NBR = ND.LINE_NBR AND
											   NDSD.REV_NBR = ND.REV_NBR AND
											   NDSD.SEQ_NBR = ND.SEQ_NBR INNER JOIN
				[dbo].[NEWSPAPER_HEADER] AS NH ON NH.ORDER_NBR = ND.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						[AR_INV_SEQ] = ARSD.DRAFT_INV_SEQ,  
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ,  
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_FUNCTION] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.DRAFT_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ) AS ARSD) AS NOD ON NOD.ORDER_NBR = ND.ORDER_NBR AND
																NOD.LINE_NBR = ND.LINE_NBR LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = NH.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = NH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = ND.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ND.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ND.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ND.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = NH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[NEWSPAPER_COMMENTS] AS NDC ON NDC.ORDER_NBR = ND.ORDER_NBR AND
													 NDC.LINE_NBR = ND.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = ND.ORDER_NBR AND
															  PBA.OrderLineNumber = ND.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = ND.ORDER_NBR AND
														   BTD.OrderLineNumber = ND.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END ELSE BEGIN

			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				NH.MARKET_CODE,
				M.MARKET_DESC,
				NH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				NH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				NH.CLIENT_PO,
				NH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				NH.ORDER_COMMENT,
				NH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				NH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(NOD.START_MONTHYEAR, '') <> '' AND ISNULL(NOD.END_MONTHYEAR, '') <> '' AND NOD.START_MONTHYEAR <> NOD.END_MONTHYEAR THEN NOD.START_MONTHYEAR + '-' + NOD.END_MONTHYEAR
									  ELSE ISNULL(NOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = NOD.[START_DATE], 
				[OrderEndDate] = NOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = ND.HEADLINE,
				[INSERT_DATE] = ND.[START_DATE],
				[MATERIAL] = ND.MATERIAL,
				[EDITION_ISSUE] = ND.EDITION_ISSUE,
				[SECTION] = ND.SECTION,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ND.SIZE,
				[START_DATES] = ND.[START_DATE],
				[END_DATES] = ND.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(ND.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(ND.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = ND.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = ND.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = NDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = ND.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'NEWSPAPER INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = ND.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'N' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[NEWSPAPER_DETAIL] AS ND ON ND.ORDER_NBR = ARS.ORDER_NBR AND
												  ND.LINE_NBR = ARS.ORDER_LINE_NBR AND
												  ND.AR_INV_NBR = ARS.AR_INV_NBR AND
												  ND.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						ND.ORDER_NBR,  
						ND.LINE_NBR,   
						[REV_NBR] = MAX(ND.REV_NBR)
					FROM 
						[dbo].[NEWSPAPER_DETAIL] AS ND 
					WHERE
						ND.AR_INV_NBR = @InvoiceNumber 
					GROUP BY 
						ND.ORDER_NBR,  
						ND.LINE_NBR) AS NDD ON NDD.ORDER_NBR = ND.ORDER_NBR AND
											   NDD.LINE_NBR = ND.LINE_NBR AND
											   NDD.REV_NBR = ND.REV_NBR INNER JOIN
				(SELECT 
						ND.ORDER_NBR,  
						ND.LINE_NBR,   
						ND.REV_NBR,   
						[SEQ_NBR] = MAX(ND.SEQ_NBR)
					FROM 
						[dbo].[NEWSPAPER_DETAIL] AS ND 
					WHERE
						ND.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						ND.ORDER_NBR,  
						ND.LINE_NBR,  
						ND.REV_NBR) AS NDSD ON NDSD.ORDER_NBR = ND.ORDER_NBR AND
											   NDSD.LINE_NBR = ND.LINE_NBR AND
											   NDSD.REV_NBR = ND.REV_NBR AND
											   NDSD.SEQ_NBR = ND.SEQ_NBR INNER JOIN
				[dbo].[NEWSPAPER_HEADER] AS NH ON NH.ORDER_NBR = ND.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						ARSD.AR_INV_SEQ,  
						ARSD.AR_TYPE,
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE,
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_SUMMARY] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.AR_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE) AS ARSD) AS NOD ON NOD.ORDER_NBR = ND.ORDER_NBR AND
															   NOD.LINE_NBR = ND.LINE_NBR LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = NH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = NH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = ND.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ND.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ND.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ND.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = NH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[NEWSPAPER_COMMENTS] AS NDC ON NDC.ORDER_NBR = ND.ORDER_NBR AND
													 NDC.LINE_NBR = ND.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = ND.ORDER_NBR AND
															  PBA.OrderLineNumber = ND.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = ND.ORDER_NBR AND
														   BTD.OrderLineNumber = ND.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END

	END ELSE IF @InvoiceType = 'I' BEGIN 
	
		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				IH.MARKET_CODE,
				M.MARKET_DESC,
				IH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				IH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				IH.CLIENT_PO,
				IH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				IH.ORDER_COMMENT,
				IH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				IH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(IOD.START_MONTHYEAR, '') <> '' AND ISNULL(IOD.END_MONTHYEAR, '') <> '' AND IOD.START_MONTHYEAR <> IOD.END_MONTHYEAR THEN IOD.START_MONTHYEAR + '-' + IOD.END_MONTHYEAR
									  ELSE ISNULL(IOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = IOD.[START_DATE], 
				[OrderEndDate] = IOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = ID.HEADLINE,
				[INSERT_DATE] = ID.[START_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ID.SIZE,
				[START_DATES] = ID.[START_DATE],
				[END_DATES] = ID.[END_DATE],
				[CREATIVE_SIZE] = ID.CREATIVE_SIZE,
				[URL] = ID.[URL],
				[INTERNET_TYPE] = IT.OD_DESC,
				[COPY_AREA] = ID.COPY_AREA,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = ID.GUARANTEED_IMPRESS,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(ID.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(ID.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = ID.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = ID.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = IDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NULL,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = ID.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = ID.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'I' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				[dbo].[INTERNET_DETAIL] AS ID ON ID.ORDER_NBR = ARS.ORDER_NBR AND
												 ID.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						ID.ORDER_NBR,  
						ID.LINE_NBR,   
						[REV_NBR] = MAX(ID.REV_NBR)
					FROM 
						[dbo].[INTERNET_DETAIL] AS ID    
					WHERE
						ID.BILLING_USER = @Batch 
					GROUP BY 
						ID.ORDER_NBR,  
						ID.LINE_NBR) AS IDD ON IDD.ORDER_NBR = ID.ORDER_NBR AND
											   IDD.LINE_NBR = ID.LINE_NBR AND
											   IDD.REV_NBR = ID.REV_NBR INNER JOIN
				(SELECT 
						ID.ORDER_NBR,  
						ID.LINE_NBR,   
						ID.REV_NBR,   
						[SEQ_NBR] = MAX(ID.SEQ_NBR)
					FROM 
						[dbo].[INTERNET_DETAIL] AS ID    
					WHERE
						ID.BILLING_USER = @Batch 
					GROUP BY 
						ID.ORDER_NBR,  
						ID.LINE_NBR,  
						ID.REV_NBR) AS IDSD ON IDSD.ORDER_NBR = ID.ORDER_NBR AND
											   IDSD.LINE_NBR = ID.LINE_NBR AND
											   IDSD.REV_NBR = ID.REV_NBR AND
											   IDSD.SEQ_NBR = ID.SEQ_NBR INNER JOIN
				[dbo].[INTERNET_HEADER] AS IH ON IH.ORDER_NBR = ID.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						[AR_INV_SEQ] = ARSD.DRAFT_INV_SEQ,  
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ,  
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_FUNCTION] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.DRAFT_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ) AS ARSD) AS IOD ON IOD.ORDER_NBR = ID.ORDER_NBR AND
															    IOD.LINE_NBR = ID.LINE_NBR LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = IH.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = IH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = ID.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ID.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ID.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ID.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = IH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[INTERNET_COMMENTS] AS IDC ON IDC.ORDER_NBR = ID.ORDER_NBR AND
													 IDC.LINE_NBR = ID.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				[dbo].[INTERNET_TYPE] AS IT ON IT.OD_CODE = ID.INTERNET_TYPE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = ID.ORDER_NBR AND
															  PBA.OrderLineNumber = ID.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = ID.ORDER_NBR AND
														   BTD.OrderLineNumber = ID.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END ELSE BEGIN

			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				IH.MARKET_CODE,
				M.MARKET_DESC,
				IH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				IH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				IH.CLIENT_PO,
				IH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				IH.ORDER_COMMENT,
				IH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				IH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(IOD.START_MONTHYEAR, '') <> '' AND ISNULL(IOD.END_MONTHYEAR, '') <> '' AND IOD.START_MONTHYEAR <> IOD.END_MONTHYEAR THEN IOD.START_MONTHYEAR + '-' + IOD.END_MONTHYEAR
									  ELSE ISNULL(IOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = IOD.[START_DATE], 
				[OrderEndDate] = IOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = ID.HEADLINE,
				[INSERT_DATE] = ID.[START_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ID.SIZE,
				[START_DATES] = ID.[START_DATE],
				[END_DATES] = ID.[END_DATE],
				[CREATIVE_SIZE] = ID.CREATIVE_SIZE,
				[URL] = ID.[URL],
				[INTERNET_TYPE] = IT.OD_DESC,
				[COPY_AREA] = ID.COPY_AREA,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = ID.GUARANTEED_IMPRESS,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(ID.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(ID.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = ID.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = ID.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = IDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NULL,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = ID.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'INTERNET INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = ID.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'I' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[INTERNET_DETAIL] AS ID ON ID.ORDER_NBR = ARS.ORDER_NBR AND
												 ID.LINE_NBR = ARS.ORDER_LINE_NBR AND
												 ID.AR_INV_NBR = ARS.AR_INV_NBR AND
												 ID.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						ID.ORDER_NBR,  
						ID.LINE_NBR,   
						[REV_NBR] = MAX(ID.REV_NBR)
					FROM 
						[dbo].[INTERNET_DETAIL] AS ID 
					WHERE
						ID.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						ID.ORDER_NBR,  
						ID.LINE_NBR) AS IDD ON IDD.ORDER_NBR = ID.ORDER_NBR AND
											   IDD.LINE_NBR = ID.LINE_NBR AND
											   IDD.REV_NBR = ID.REV_NBR INNER JOIN
				(SELECT 
						ID.ORDER_NBR,  
						ID.LINE_NBR,   
						ID.REV_NBR,   
						[SEQ_NBR] = MAX(ID.SEQ_NBR)
					FROM 
						[dbo].[INTERNET_DETAIL] AS ID 
					WHERE
						ID.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						ID.ORDER_NBR,  
						ID.LINE_NBR,  
						ID.REV_NBR) AS IDSD ON IDSD.ORDER_NBR = ID.ORDER_NBR AND
											   IDSD.LINE_NBR = ID.LINE_NBR AND
											   IDSD.REV_NBR = ID.REV_NBR AND
											   IDSD.SEQ_NBR = ID.SEQ_NBR INNER JOIN
				[dbo].[INTERNET_HEADER] AS IH ON IH.ORDER_NBR = ID.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						ARSD.AR_INV_SEQ,  
						ARSD.AR_TYPE,
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE,
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_SUMMARY] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.AR_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE) AS ARSD) AS IOD ON IOD.ORDER_NBR = ID.ORDER_NBR AND
															     IOD.LINE_NBR = ID.LINE_NBR LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = IH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = IH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = ID.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ID.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ID.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = ID.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = IH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[INTERNET_COMMENTS] AS IDC ON IDC.ORDER_NBR = ID.ORDER_NBR AND
													 IDC.LINE_NBR = ID.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				[dbo].[INTERNET_TYPE] AS IT ON IT.OD_CODE = ID.INTERNET_TYPE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = ID.ORDER_NBR AND
															  PBA.OrderLineNumber = ID.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = ID.ORDER_NBR AND
														   BTD.OrderLineNumber = ID.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END

	END ELSE IF @InvoiceType = 'O' BEGIN  
	
		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				OH.MARKET_CODE,
				M.MARKET_DESC,
				OH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				OH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				OH.CLIENT_PO,
				OH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				OH.ORDER_COMMENT,
				OH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				OH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(OOD.START_MONTHYEAR, '') <> '' AND ISNULL(OOD.END_MONTHYEAR, '') <> '' AND OOD.START_MONTHYEAR <> OOD.END_MONTHYEAR THEN OOD.START_MONTHYEAR + '-' + OOD.END_MONTHYEAR
									  ELSE ISNULL(OOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = OOD.[START_DATE], 
				[OrderEndDate] = OOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL,
				[HEADLINE] = OD.HEADLINE,
				[INSERT_DATE] = OD.[POST_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ADS.SIZE_DESC,
				[START_DATES] = OD.[POST_DATE],
				[END_DATES] = OD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = OD.COPY_AREA,
				[LOCATION] = OD.LOCATION,
				[OUTDOOR_TYPE] = OT.OD_DESC,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(OD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(OD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = OD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = OD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = ODC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NULL,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = OD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = OD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'O' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				[dbo].[OUTDOOR_DETAIL] AS OD ON OD.ORDER_NBR = ARS.ORDER_NBR AND
												OD.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						OD.ORDER_NBR,  
						OD.LINE_NBR,   
						[REV_NBR] = MAX(OD.REV_NBR)
					FROM 
						[dbo].[OUTDOOR_DETAIL] AS OD    
					WHERE
						OD.BILLING_USER = @Batch 
					GROUP BY 
						OD.ORDER_NBR,  
						OD.LINE_NBR) AS ODD ON ODD.ORDER_NBR = OD.ORDER_NBR AND
											   ODD.LINE_NBR = OD.LINE_NBR AND
											   ODD.REV_NBR = OD.REV_NBR INNER JOIN
				(SELECT 
						OD.ORDER_NBR,  
						OD.LINE_NBR,   
						OD.REV_NBR,   
						[SEQ_NBR] = MAX(OD.SEQ_NBR)
					FROM 
						[dbo].[OUTDOOR_DETAIL] AS OD    
					WHERE
						OD.BILLING_USER = @Batch 
					GROUP BY 
						OD.ORDER_NBR,  
						OD.LINE_NBR,  
						OD.REV_NBR) AS ODSD ON ODSD.ORDER_NBR = OD.ORDER_NBR AND
											   ODSD.LINE_NBR = OD.LINE_NBR AND
											   ODSD.REV_NBR = OD.REV_NBR AND
											   ODSD.SEQ_NBR = OD.SEQ_NBR INNER JOIN
				[dbo].[OUTDOOR_HEADER] AS OH ON OH.ORDER_NBR = OD.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						[AR_INV_SEQ] = ARSD.DRAFT_INV_SEQ,  
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ,  
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_FUNCTION] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.DRAFT_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.DRAFT_INV_SEQ) AS ARSD) AS OOD ON OOD.ORDER_NBR = OD.ORDER_NBR AND
															   OOD.LINE_NBR = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = OH.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = OH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = OD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = OD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = OD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = OD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = OH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[OUTDOOR_COMMENTS] AS ODC ON ODC.ORDER_NBR = OD.ORDER_NBR AND
												   ODC.LINE_NBR = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				[dbo].[OUTDOOR_TYPE] AS OT ON OT.OD_CODE = OD.OUTDOOR_TYPE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = OD.ORDER_NBR AND
															  PBA.OrderLineNumber = OD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = OD.ORDER_NBR AND
														   BTD.OrderLineNumber = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[AD_SIZE] AS ADS ON ADS.SIZE_CODE = OD.SIZE AND ADS.MEDIA_TYPE = 'O' LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END ELSE BEGIN

			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				OH.MARKET_CODE,
				M.MARKET_DESC,
				OH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				OH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				OH.CLIENT_PO,
				OH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				OH.ORDER_COMMENT,
				OH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				OH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = CASE WHEN ISNULL(OOD.START_MONTHYEAR, '') <> '' AND ISNULL(OOD.END_MONTHYEAR, '') <> '' AND OOD.START_MONTHYEAR <> OOD.END_MONTHYEAR THEN OOD.START_MONTHYEAR + '-' + OOD.END_MONTHYEAR
									  ELSE ISNULL(OOD.START_MONTHYEAR_YYYY, '') END,
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = OOD.[START_DATE], 
				[OrderEndDate] = OOD.[END_DATE], 
				[OrderMonth] = NULL,
				[OrderYear] = NULL, 
				[HEADLINE] = OD.HEADLINE,
				[INSERT_DATE] = OD.[POST_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = ARS.HRS_QTY,
				[SIZE] = ADS.SIZE_DESC,
				[START_DATES] = OD.[POST_DATE],
				[END_DATES] = OD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = OD.COPY_AREA,
				[LOCATION] = OD.LOCATION,
				[OUTDOOR_TYPE] = OT.OD_DESC,
				[PROGRAM] = NULL,
				[SPOT_LENGTH] = NULL,
				[TAG] = NULL,
				[START_TIME] = NULL,
				[END_TIME] = NULL,
				[GuaranteedImpressions] = NULL,
				[Monday] = NULL,
				[Tuesday] = NULL,
				[Wednesday] = NULL,
				[Thursday] = NULL,
				[Friday] = NULL,
				[Saturday] = NULL,
				[Sunday] = NULL,
				[NUMBER_OF_SPOTS] = NULL,
				[REMARKS] = NULL,
				[JobComponent] = RIGHT('000000' + CAST(OD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(OD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = OD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = OD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = ODC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = NULL,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = OD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'OUTDOOR INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = OD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'O' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[OUTDOOR_DETAIL] AS OD ON OD.ORDER_NBR = ARS.ORDER_NBR AND
												OD.LINE_NBR = ARS.ORDER_LINE_NBR AND
												OD.AR_INV_NBR = ARS.AR_INV_NBR AND
												OD.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						OD.ORDER_NBR,  
						OD.LINE_NBR,   
						[REV_NBR] = MAX(OD.REV_NBR)
					FROM 
						[dbo].[OUTDOOR_DETAIL] AS OD 
					WHERE
						OD.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						OD.ORDER_NBR,  
						OD.LINE_NBR) AS ODD ON ODD.ORDER_NBR = OD.ORDER_NBR AND
											   ODD.LINE_NBR = OD.LINE_NBR AND
											   ODD.REV_NBR = OD.REV_NBR INNER JOIN
				(SELECT 
						OD.ORDER_NBR,  
						OD.LINE_NBR,   
						OD.REV_NBR,   
						[SEQ_NBR] = MAX(OD.SEQ_NBR)
					FROM 
						[dbo].[OUTDOOR_DETAIL] AS OD 
					WHERE
						OD.AR_INV_NBR = @InvoiceNumber 
					GROUP BY 
						OD.ORDER_NBR,  
						OD.LINE_NBR,  
						OD.REV_NBR) AS ODSD ON ODSD.ORDER_NBR = OD.ORDER_NBR AND
											   ODSD.LINE_NBR = OD.LINE_NBR AND
											   ODSD.REV_NBR = OD.REV_NBR AND
											   ODSD.SEQ_NBR = OD.SEQ_NBR INNER JOIN
				[dbo].[OUTDOOR_HEADER] AS OH ON OH.ORDER_NBR = OD.ORDER_NBR  INNER JOIN 
				(SELECT
						ARSD.ORDER_NBR,  
						[LINE_NBR] = ARSD.ORDER_LINE_NBR, 
						ARSD.AR_INV_NBR, 
						ARSD.AR_INV_SEQ,  
						ARSD.AR_TYPE,
						ARSD.[START_DATE],
						ARSD.[END_DATE],
						[START_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[START_DATE], 2),
						[END_MONTHYEAR] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(2), ARSD.[END_DATE], 2),
						[START_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[START_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[START_DATE], 102),
						[END_MONTHYEAR_YYYY] = RTRIM(LTRIM(CONVERT(CHAR(4), ARSD.[END_DATE], 100))) + ' ' +  CONVERT(CHAR(4), ARSD.[END_DATE], 102)
					FROM
						(SELECT 
								ARSD.ORDER_NBR, 
								ARSD.ORDER_LINE_NBR,  
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE,
								[START_DATE] = MIN(ARSD.[START_DATE]), 
								[END_DATE] = MAX(ARSD.END_DATE) 
							FROM 
								[dbo].[AR_SUMMARY] AS ARSD 
							WHERE 
								ARSD.AR_INV_NBR = @InvoiceNumber AND
								ARSD.AR_INV_SEQ = @SequenceNumber
							GROUP BY 
								ARSD.ORDER_NBR,  
								ARSD.ORDER_LINE_NBR, 
								ARSD.AR_INV_NBR, 
								ARSD.AR_INV_SEQ,  
								ARSD.AR_TYPE) AS ARSD) AS OOD ON OOD.ORDER_NBR = OD.ORDER_NBR AND
															   OOD.LINE_NBR = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = OH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = OH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = OD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = OD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = OD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = OD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = OH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[OUTDOOR_COMMENTS] AS ODC ON ODC.ORDER_NBR = OD.ORDER_NBR AND
												   ODC.LINE_NBR = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				[dbo].[OUTDOOR_TYPE] AS OT ON OT.OD_CODE = OD.OUTDOOR_TYPE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = OD.ORDER_NBR AND
															  PBA.OrderLineNumber = OD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = OD.ORDER_NBR AND
														   BTD.OrderLineNumber = OD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[AD_SIZE] AS ADS ON ADS.SIZE_CODE = OD.SIZE AND ADS.MEDIA_TYPE = 'O' LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END

	END ELSE IF @InvoiceType = 'R' BEGIN  
	
		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				RH.MARKET_CODE,
				M.MARKET_DESC,
				RH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				RH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				RH.CLIENT_PO,
				RH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				RH.ORDER_COMMENT,
				RH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				RH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = RTRIM(LTRIM(CONVERT(CHAR(4), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 100))) + ' ' +  CONVERT(CHAR(2), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 2),
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[OrderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderMonth] = RD.MONTH_NBR,
				[OrderYear] = RD.YEAR_NBR,
				[HEADLINE] = NULL,
				[INSERT_DATE] = NULL,
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = RD.QUANTITY,
				[SIZE] = NULL,
				[START_DATES] = RD.[START_DATE],
				[END_DATES] = NULL,
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = RD.PROGRAMMING,
				[SPOT_LENGTH] = RD.[LENGTH],
				[TAG] = RD.[TAG],
				[START_TIME] = RD.[START_TIME],
				[END_TIME] = RD.[END_TIME],
				[GuaranteedImpressions] = NULL,
				[Monday] = CAST(RD.MONDAY AS bit),
				[Tuesday] = CAST(RD.TUESDAY AS bit),
				[Wednesday] = CAST(RD.WEDNESDAY AS bit),
				[Thursday] = CAST(RD.THURSDAY AS bit),
				[Friday] = CAST(RD.FRIDAY AS bit),
				[Saturday] = CAST(RD.SATURDAY AS bit),
				[Sunday] = CAST(RD.SUNDAY AS bit),
				[NUMBER_OF_SPOTS] = CAST(ARS.HRS_QTY AS int),
				[REMARKS] = RD.[REMARKS],
				[JobComponent] = RIGHT('000000' + CAST(RD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(RD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = RD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = RD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = RDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = RDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = RD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                                   		   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = RD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'R' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				[dbo].[RADIO_DETAIL] AS RD ON RD.ORDER_NBR = ARS.ORDER_NBR AND
											  RD.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						RD.ORDER_NBR,  
						RD.LINE_NBR,   
						[REV_NBR] = MAX(RD.REV_NBR)
					FROM 
						[dbo].[RADIO_DETAIL] AS RD   
					WHERE
						RD.BILLING_USER = @Batch  
					GROUP BY 
						RD.ORDER_NBR,  
						RD.LINE_NBR) AS RDD ON RDD.ORDER_NBR = RD.ORDER_NBR AND
											   RDD.LINE_NBR = RD.LINE_NBR AND
											   RDD.REV_NBR = RD.REV_NBR INNER JOIN
				(SELECT 
						RD.ORDER_NBR,  
						RD.LINE_NBR,   
						RD.REV_NBR,   
						[SEQ_NBR] = MAX(RD.SEQ_NBR)
					FROM 
						[dbo].[RADIO_DETAIL] AS RD   
					WHERE
						RD.BILLING_USER = @Batch  
					GROUP BY 
						RD.ORDER_NBR,  
						RD.LINE_NBR,  
						RD.REV_NBR) AS RDSD ON RDSD.ORDER_NBR = RD.ORDER_NBR AND
											   RDSD.LINE_NBR = RD.LINE_NBR AND
											   RDSD.REV_NBR = RD.REV_NBR AND
											   RDSD.SEQ_NBR = RD.SEQ_NBR INNER JOIN
				[dbo].[RADIO_HDR] AS RH ON RH.ORDER_NBR = RD.ORDER_NBR LEFT OUTER JOIN 
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = RH.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = RH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = RD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = RD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = RD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = RD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = RH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[RADIO_COMMENTS] AS RDC ON RDC.ORDER_NBR = RD.ORDER_NBR AND
												 RDC.LINE_NBR = RD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = RD.ORDER_NBR AND
															  PBA.OrderLineNumber = RD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = RD.ORDER_NBR AND
														   BTD.OrderLineNumber = RD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END ELSE BEGIN

			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				RH.MARKET_CODE,
				M.MARKET_DESC,
				RH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				RH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				RH.CLIENT_PO,
				RH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				RH.ORDER_COMMENT,
				RH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				RH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = RTRIM(LTRIM(CONVERT(CHAR(4), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 100))) + ' ' +  CONVERT(CHAR(2), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 2),
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[OrderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderMonth] = RD.MONTH_NBR,
				[OrderYear] = RD.YEAR_NBR,
				[HEADLINE] = NULL,
				[INSERT_DATE] = NULL,
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = RD.QUANTITY,
				[SIZE] = NULL,
				[START_DATES] = RD.[START_DATE],
				[END_DATES] = NULL,
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = RD.PROGRAMMING,
				[SPOT_LENGTH] = RD.[LENGTH],
				[TAG] = RD.[TAG],
				[START_TIME] = RD.[START_TIME],
				[END_TIME] = RD.[END_TIME],
				[GuaranteedImpressions] = NULL,
				[Monday] = CAST(RD.MONDAY AS bit),
				[Tuesday] = CAST(RD.TUESDAY AS bit),
				[Wednesday] = CAST(RD.WEDNESDAY AS bit),
				[Thursday] = CAST(RD.THURSDAY AS bit),
				[Friday] = CAST(RD.FRIDAY AS bit),
				[Saturday] = CAST(RD.SATURDAY AS bit),
				[Sunday] = CAST(RD.SUNDAY AS bit),
				[NUMBER_OF_SPOTS] = CAST(ARS.HRS_QTY AS int),
				[REMARKS] = RD.[REMARKS],
				[JobComponent] = RIGHT('000000' + CAST(RD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(RD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = RD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = RD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = RDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = RDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = RD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                                  						   ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'RADIO INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = RD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'R' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[RADIO_DETAIL] AS RD ON RD.ORDER_NBR = ARS.ORDER_NBR AND
											  RD.LINE_NBR = ARS.ORDER_LINE_NBR AND
											  RD.AR_INV_NBR = ARS.AR_INV_NBR AND
											  RD.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						RD.ORDER_NBR,  
						RD.LINE_NBR,   
						[REV_NBR] = MAX(RD.REV_NBR)
					FROM 
						[dbo].[RADIO_DETAIL] AS RD 
					WHERE
						RD.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						RD.ORDER_NBR,  
						RD.LINE_NBR) AS RDD ON RDD.ORDER_NBR = RD.ORDER_NBR AND
											   RDD.LINE_NBR = RD.LINE_NBR AND
											   RDD.REV_NBR = RD.REV_NBR INNER JOIN
				(SELECT 
						RD.ORDER_NBR,  
						RD.LINE_NBR,   
						RD.REV_NBR,   
						[SEQ_NBR] = MAX(RD.SEQ_NBR)
					FROM 
						[dbo].[RADIO_DETAIL] AS RD  
					WHERE
						RD.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						RD.ORDER_NBR,  
						RD.LINE_NBR,  
						RD.REV_NBR) AS RDSD ON RDSD.ORDER_NBR = RD.ORDER_NBR AND
											   RDSD.LINE_NBR = RD.LINE_NBR AND
											   RDSD.REV_NBR = RD.REV_NBR AND
											   RDSD.SEQ_NBR = RD.SEQ_NBR INNER JOIN
				[dbo].[RADIO_HDR] AS RH ON RH.ORDER_NBR = RD.ORDER_NBR LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = RH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = RH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = RD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = RD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = RD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = RD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = RH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[RADIO_COMMENTS] AS RDC ON RDC.ORDER_NBR = RD.ORDER_NBR AND
												 RDC.LINE_NBR = RD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = RD.ORDER_NBR AND
															  PBA.OrderLineNumber = RD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = RD.ORDER_NBR AND
														   BTD.OrderLineNumber = RD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END

	END ELSE IF @InvoiceType = 'T' BEGIN

		IF @IsDraft = 1 BEGIN
	
			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				TVH.MARKET_CODE,
				M.MARKET_DESC,
				TVH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				TVH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.DRAFT_INV_SEQ,
				[AR_TYPE] = 'IN',
				[AR_INV_DATE] = GETDATE(),
				TVH.CLIENT_PO,
				TVH.CLIENT_REF,
				[INV_CAT] = NULL,
				[INV_CAT_DESC] = NULL,
				TVH.ORDER_COMMENT,
				TVH.HOUSE_COMMENT,
				[AR_INV_DUE_DATE] = NULL,
				TVH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = RTRIM(LTRIM(CONVERT(CHAR(4), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 100))) + ' ' +  CONVERT(CHAR(2), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 2),
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[OrderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderMonth] = TVD.MONTH_NBR,
				[OrderYear] = TVD.YEAR_NBR,
				[HEADLINE] = NULL,
				[INSERT_DATE] = TVD.[START_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = TVD.QUANTITY,
				[SIZE] = NULL,
				[START_DATES] = TVD.[START_DATE],
				[END_DATES] = TVD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = TVD.PROGRAMMING,
				[SPOT_LENGTH] = TVD.[LENGTH],
				[TAG] = TVD.TAG,
				[START_TIME] = TVD.START_TIME,
				[END_TIME] = TVD.END_TIME,
				[GuaranteedImpressions] = NULL,
				[Monday] = CAST(TVD.MONDAY AS bit),
				[Tuesday] = CAST(TVD.TUESDAY AS bit),
				[Wednesday] = CAST(TVD.WEDNESDAY AS bit),
				[Thursday] = CAST(TVD.THURSDAY AS bit),
				[Friday] = CAST(TVD.FRIDAY AS bit),
				[Saturday] = CAST(TVD.SATURDAY AS bit),
				[Sunday] = CAST(TVD.SUNDAY AS bit),
				[NUMBER_OF_SPOTS] = CASE WHEN TVDU.HRS IS NOT NULL THEN CAST(TVDU.HRS AS int) ELSE CAST(ARS.HRS_QTY AS int) END, --CAST(ARS.HRS_QTY AS int),
				[REMARKS] = TVD.REMARKS,
				[JobComponent] = RIGHT('000000' + CAST(TVD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(TVD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = TVD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = TVD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = TVDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = TVDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = TVD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				[HRS_QTY] = CASE WHEN TVDU.HRS IS NOT NULL THEN CAST(TVDU.HRS AS decimal(18,2)) ELSE CAST(ARS.HRS_QTY AS decimal(18,2)) END, --CAST(ARS.HRS_QTY AS decimal(18,2)),
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
																		 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                 								           ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job'),
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'DRAFT INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.DRAFT_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = NULL,
				[CloseDate] = TVD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						[AR_TYPE] = 'IN',
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_FUNCTION] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'T' AND
						ARS.DRAFT_INV_SEQ <> 99 AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.DRAFT_INV_SEQ = @SequenceNumber AND
						ARS.BILLING_USER = @Batch 
					GROUP BY
						ARS.BILLING_USER,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.DRAFT_INV_SEQ,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				[dbo].[TV_DETAIL] AS TVD ON TVD.ORDER_NBR = ARS.ORDER_NBR AND
											TVD.LINE_NBR = ARS.ORDER_LINE_NBR INNER JOIN
				(SELECT 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,   
						[REV_NBR] = MAX(TVD.REV_NBR)
					FROM 
						[dbo].[TV_DETAIL] AS TVD   
					WHERE
						TVD.BILLING_USER = @Batch  
					GROUP BY 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR) AS TVDD ON TVDD.ORDER_NBR = TVD.ORDER_NBR AND
												 TVDD.LINE_NBR = TVD.LINE_NBR AND
												 TVDD.REV_NBR = TVD.REV_NBR INNER JOIN
				(SELECT 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,   
						TVD.REV_NBR,   
						[SEQ_NBR] = MAX(TVD.SEQ_NBR)
					FROM 
						[dbo].[TV_DETAIL] AS TVD   
					WHERE
						TVD.BILLING_USER = @Batch  
					GROUP BY 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,  
						TVD.REV_NBR) AS TVDSD ON TVDSD.ORDER_NBR = TVD.ORDER_NBR AND
												 TVDSD.LINE_NBR = TVD.LINE_NBR AND
												 TVDSD.REV_NBR = TVD.REV_NBR AND
												 TVDSD.SEQ_NBR = TVD.SEQ_NBR LEFT JOIN
					/* PJH 09/16/19 - Added */
					( SELECT A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE, SUM(A.UNITS) HRS 
					  FROM [dbo].TV_DETAIL_UNITS A JOIN [dbo].TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR AND A.SEQ_NBR = B.SEQ_NBR
					  WHERE B.AR_INV_NBR IS NULL
					  GROUP BY A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE) TVDU ON TVD.ORDER_NBR = TVDU.ORDER_NBR AND
											TVD.LINE_NBR = TVDU.LINE_NBR AND ARS.PRD_CODE = TVDU.PRD_CODE INNER JOIN

				[dbo].[TV_HDR] AS TVH ON TVH.ORDER_NBR = TVD.ORDER_NBR LEFT OUTER JOIN 
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = TVH.MARKET_CODE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = TVH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = TVD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = TVD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = TVD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = TVD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = TVH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[TV_COMMENTS] AS TVDC ON TVDC.ORDER_NBR = TVD.ORDER_NBR AND
											   TVDC.LINE_NBR = TVD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = TVD.ORDER_NBR AND
															  PBA.OrderLineNumber = TVD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = TVD.ORDER_NBR AND
														   BTD.OrderLineNumber = TVD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END ELSE BEGIN

			INSERT INTO #MediaInvoiceDetails
			SELECT 
				ARS.CL_CODE,
				C.CL_NAME,
				ARS.DIV_CODE,
				D.DIV_NAME,
				ARS.PRD_CODE,
				P.PRD_DESCRIPTION,
				ARS.OFFICE_CODE,
				ARS.SC_CODE,
				SC.SC_DESCRIPTION,
				TVH.MARKET_CODE,
				M.MARKET_DESC,
				TVH.CMP_IDENTIFIER,
				CAMP.CMP_CODE,
				CAMP.CMP_NAME,
				CAST(CAMP.CMP_COMMENTS AS varchar(MAX)),
				ARS.ORDER_NBR,
				ARS.ORDER_LINE_NBR,
				ARS.MEDIA_TYPE,
				TVH.ORDER_DESC,
				ARS.AR_INV_NBR,
				ARS.AR_INV_SEQ,
				ARS.AR_TYPE,
				ARID.AR_INV_DATE,
				TVH.CLIENT_PO,
				TVH.CLIENT_REF,
				AR.INV_CAT,
				IC.INV_CAT_DESC,
				TVH.ORDER_COMMENT,
				TVH.HOUSE_COMMENT,
				ARIDD.AR_INV_DUE_DATE,
				TVH.VN_CODE,
				V.VN_NAME,
				[ORDER_MONTHS] = RTRIM(LTRIM(CONVERT(CHAR(4), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 100))) + ' ' +  CONVERT(CHAR(2), CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 2),
				[HeaderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[HeaderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderStartDate] = CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime), 
				[OrderEndDate] = DATEADD(D,-1,DATEADD(M, DATEDIFF(M,0,CAST(CAST(ARS.MEDIA_MONTH AS varchar(2)) + '/01/' + CAST(ARS.MEDIA_YEAR AS varchar(4)) AS smalldatetime))+1,0)), 
				[OrderMonth] = TVD.MONTH_NBR,
				[OrderYear] = TVD.YEAR_NBR,
				[HEADLINE] = NULL,
				[INSERT_DATE] = TVD.[START_DATE],
				[MATERIAL] = NULL,
				[EDITION_ISSUE] = NULL,
				[SECTION] = NULL,
				[QUANTITY] = TVD.QUANTITY,
				[SIZE] = NULL,
				[START_DATES] = TVD.[START_DATE],
				[END_DATES] = TVD.[END_DATE],
				[CREATIVE_SIZE] = NULL,
				[URL] = NULL,
				[INTERNET_TYPE] = NULL,
				[COPY_AREA] = NULL,
				[LOCATION] = NULL,
				[OUTDOOR_TYPE] = NULL,
				[PROGRAM] = TVD.PROGRAMMING,
				[SPOT_LENGTH] = TVD.[LENGTH],
				[TAG] = TVD.TAG,
				[START_TIME] = TVD.START_TIME,
				[END_TIME] = TVD.END_TIME,
				[GuaranteedImpressions] = NULL,
				[Monday] = CAST(TVD.MONDAY AS bit),
				[Tuesday] = CAST(TVD.TUESDAY AS bit),
				[Wednesday] = CAST(TVD.WEDNESDAY AS bit),
				[Thursday] = CAST(TVD.THURSDAY AS bit),
				[Friday] = CAST(TVD.FRIDAY AS bit),
				[Saturday] = CAST(TVD.SATURDAY AS bit),
				[Sunday] = CAST(TVD.SUNDAY AS bit),
				/* PJH 09/16/19 - Added */
				[NUMBER_OF_SPOTS] = CAST(ARS.HRS_QTY AS int), -- CASE WHEN TVDU.HRS IS NOT NULL THEN CAST(TVDU.HRS AS int) ELSE CAST(ARS.HRS_QTY AS int) END,
				[REMARKS] = TVD.REMARKS,
				[JobComponent] = RIGHT('000000' + CAST(TVD.JOB_NUMBER AS varchar(6)), 6) + '-' + RIGHT('00' + CAST(TVD.JOB_COMPONENT_NBR AS varchar(2)), 2),
				[JOB_NUMBER] = TVD.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = TVD.JOB_COMPONENT_NBR,
				[JOB_DESC] = JL.JOB_DESC,
				[JOB_COMP_DESC] = JC.JOB_COMP_DESC,
				[ORDER_DTL_COMMENT] = TVDC.INSTRUCTIONS,
				[HOUSE_DTL_COMMENT] = TVDC.IN_HOUSE_CMTS,
				[EXTRA_CHARGE_ADDITIONAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.ADDITIONAL_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXTRA_CHARGE_NET] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.NET_CHARGE_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[DISCOUNT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ARS.DISCOUNT_AMT AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[AD_NUMBER] = TVD.AD_NUMBER,
				[AD_NBR_DESC] = AN.AD_NBR_DESC,
				/* PJH 09/16/19 - Added */
				[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)), --CASE WHEN TVDU.HRS IS NOT NULL THEN CAST(TVDU.HRS AS decimal(18,2)) ELSE CAST(ARS.HRS_QTY AS decimal(18,2)) END,
				[RATE] = CAST(0 AS decimal(18,2)),
				[REBATE_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.REBATE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_AMT] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_MARKUP_AMT] = CASE WHEN @TotalsShowRebateSeparately = 1 THEN dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount)
										ELSE dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount) END,
				[EXT_NONRESALE_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_STATE_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_COUNTY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[EXT_CITY_RESALE] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[TOTAL_TAX] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BILL_AMOUNT] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) AS decimal(18,2)), 
														                 CASE WHEN @TotalsShowRebateSeparately = 1 THEN CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2))
														                 								           ELSE CAST(ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0) + ISNULL(ARS.REBATE_AMT, 0) + ISNULL(ARS.ADDITIONAL_AMT, 0) AS decimal(18,2)) END, 
														                 @TotalsShowCommissionSeparately, 
														                 CAST(ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)), 
														                 @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[LINE_TOTAL] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
			
				[BilledToDateRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[BilledToDateAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(BTD.NetAmount, 0) AS decimal(18,2)), 
																CAST(ISNULL(BTD.CommissionAmount,0) AS decimal(18,2)), 
																@TotalsShowCommissionSeparately, 
																CAST(ISNULL(BTD.TotalTax, 0) AS decimal(18,2)), 
																@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			
				[PriorBillAmountRebateAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.RebateAmount, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCommissionAmount] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountStateTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.StateTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCountyTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CountyTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountCityTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.CityTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmountTotalTax] = dbo.advfn_invoice_printing_xchge_total_amt(CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), @ApplyExchangeRate, @ExchangeRateAmount),
				[PriorBillAmount] = dbo.advfn_invoice_printing_xchge_net_amt(CAST(ISNULL(PBA.NetAmount, 0) AS decimal(18,2)), 
															CAST(ISNULL(PBA.CommissionAmount,0) AS decimal(18,2)), 
															@TotalsShowCommissionSeparately, 
															CAST(ISNULL(PBA.TotalTax, 0) AS decimal(18,2)), 
															@TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
				[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																											OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																											OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Invoice') 
																	   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_MATTENTION,
																											C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																											C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																											D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																											D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																											D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																											P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																											P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																											P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																											CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																											CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																											CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END,
				[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND AR.INV_CAT IS NOT NULL THEN IC.INV_CAT_DESC 
										 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
										 ELSE 'TV INVOICE' END,
				[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), C.CL_MFOOTER)
											  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
											  ELSE '' END,
				[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', ARS.OFFICE_CODE, ARS.CL_CODE, ARS.DIV_CODE, ARS.PRD_CODE), 10)
													  ELSE 10 END,
				[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('0000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
				[BillingComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),
				[CloseDate] = TVD.CLOSE_DATE,
				[VendorInvoiceCategoryID] = V.VENDOR_INVOICE_CATEGORY_ID,
				[VendorInvoiceCategory] = VIC.NAME,
				[VATNumber] = C.VAT_NUMBER
			FROM 
				(SELECT
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.CLIENT_PO,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						[HRS_QTY] = SUM(ARS.HRS_QTY),
						[ADDITIONAL_AMT] = SUM(ARS.ADDITIONAL_AMT),
						[NET_CHARGE_AMT] = SUM(ARS.NET_CHARGE_AMT),  
						[DISCOUNT_AMT] = SUM(ARS.DISCOUNT_AMT),  
						[REBATE_AMT] = SUM(ARS.REBATE_AMT),  
						[COST_AMT] = SUM(ARS.COST_AMT),  
						[NON_RESALE_AMT] = SUM(ARS.NON_RESALE_AMT),  
						[AB_COMMISSION_AMT] = SUM(ARS.AB_COMMISSION_AMT),  
						[COMMISSION_AMT] = SUM(ARS.COMMISSION_AMT),  
						[STATE_TAX_AMT] = SUM(ARS.STATE_TAX_AMT),  
						[CNTY_TAX_AMT] = SUM(ARS.CNTY_TAX_AMT),  
						[CITY_TAX_AMT] = SUM(ARS.CITY_TAX_AMT),  
						[TOTAL_BILL] = SUM(ARS.TOTAL_BILL)
					FROM		
						[dbo].[AR_SUMMARY] AS ARS
					WHERE 
						ARS.MEDIA_TYPE = 'T' AND
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber
					GROUP BY
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.SC_CODE,
						ARS.MARKET_CODE,
						ARS.CMP_IDENTIFIER,
						ARS.ORDER_NBR,
						ARS.ORDER_LINE_NBR,
						ARS.MEDIA_TYPE,
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARS.MEDIA_MONTH,
						ARS.MEDIA_YEAR,
						ARS.CLIENT_PO) AS ARS INNER JOIN 
				(SELECT 
						AR.AR_INV_NBR, 
						AR.AR_TYPE, 
						[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
						[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
					FROM 
						[dbo].[ACCT_REC] AS AR 
					WHERE 
						AR.AR_INV_NBR = @InvoiceNumber
					GROUP BY 
						AR.AR_INV_NBR, 
						AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
											   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
				[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
										  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
										  AR.AR_TYPE = ARS.AR_TYPE INNER JOIN
				[dbo].[TV_DETAIL] AS TVD ON TVD.ORDER_NBR = ARS.ORDER_NBR AND
											TVD.LINE_NBR = ARS.ORDER_LINE_NBR AND 
											TVD.AR_INV_NBR = ARS.AR_INV_NBR AND
											TVD.AR_TYPE = ARS.AR_TYPE INNER JOIN
				(SELECT 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,   
						[REV_NBR] = MAX(TVD.REV_NBR)
					FROM 
						[dbo].[TV_DETAIL] AS TVD 
					WHERE
						TVD.AR_INV_NBR = @InvoiceNumber 
					GROUP BY 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR) AS TVDD ON TVDD.ORDER_NBR = TVD.ORDER_NBR AND
												 TVDD.LINE_NBR = TVD.LINE_NBR AND
												 TVDD.REV_NBR = TVD.REV_NBR INNER JOIN
				(SELECT 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,   
						TVD.REV_NBR,   
						[SEQ_NBR] = MAX(TVD.SEQ_NBR)
					FROM 
						[dbo].[TV_DETAIL] AS TVD 
					WHERE
						TVD.AR_INV_NBR = @InvoiceNumber 
					GROUP BY 
						TVD.ORDER_NBR,  
						TVD.LINE_NBR,  
						TVD.REV_NBR) AS TVDSD ON TVDSD.ORDER_NBR = TVD.ORDER_NBR AND
												 TVDSD.LINE_NBR = TVD.LINE_NBR AND
												 TVDSD.REV_NBR = TVD.REV_NBR AND
												 TVDSD.SEQ_NBR = TVD.SEQ_NBR INNER JOIN --LEFT JOIN

					--/* PJH 09/16/19 - AR_SUMMARY values should be good now. Don't need tocalculate here. */
					--( SELECT A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE, SUM(A.UNITS) HRS 
					--  FROM [dbo].TV_DETAIL_UNITS A JOIN [dbo].TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND A.REV_NBR = B.REV_NBR AND A.SEQ_NBR = B.SEQ_NBR
					--  WHERE B.AR_INV_NBR = @InvoiceNumber
					--  GROUP BY A.ORDER_NBR, A.LINE_NBR, A.PRD_CODE) TVDU ON TVD.ORDER_NBR = TVDU.ORDER_NBR AND
					--						TVD.LINE_NBR = TVDU.LINE_NBR AND ARS.PRD_CODE = TVDU.PRD_CODE INNER JOIN

				[dbo].[TV_HDR] AS TVH ON TVH.ORDER_NBR = TVD.ORDER_NBR LEFT OUTER JOIN 
				[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE LEFT OUTER JOIN
				[dbo].[MARKET] AS M ON M.MARKET_CODE = TVH.MARKET_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = ARS.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = TVH.VN_CODE LEFT OUTER JOIN
				[dbo].[AD_NUMBER] AS AN ON AN.AD_NBR = TVD.AD_NUMBER LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = TVD.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = TVD.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = TVD.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = TVH.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[TV_COMMENTS] AS TVDC ON TVDC.ORDER_NBR = TVD.ORDER_NBR AND
											   TVDC.LINE_NBR = TVD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.CL_CODE AND
										 D.DIV_CODE = ARS.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.CL_CODE AND 
										P.DIV_CODE = ARS.DIV_CODE AND 
										P.PRD_CODE = ARS.PRD_CODE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = ARS.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = ARS.AR_INV_SEQ LEFT OUTER JOIN 
				#MediaInvoiceDetailsPriorBillAmount AS PBA ON PBA.OrderNumber = TVD.ORDER_NBR AND
															  PBA.OrderLineNumber = TVD.LINE_NBR LEFT OUTER JOIN 
				#MediaInvoiceDetailsBilledToDate AS BTD ON BTD.OrderNumber = TVD.ORDER_NBR AND
														   BTD.OrderLineNumber = TVD.LINE_NBR LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[VENDOR_INVOICE_CATEGORY] AS VIC ON VIC.VENDOR_INVOICE_CATEGORY_ID = V.VENDOR_INVOICE_CATEGORY_ID
			
		END

	END  

	SELECT * FROM #MediaInvoiceDetails
	
	DROP TABLE #MediaInvoiceDetails
	DROP TABLE #MediaInvoiceDetailsBilledToDate
	DROP TABLE #MediaInvoiceDetailsPriorBillAmount
		
END


GO