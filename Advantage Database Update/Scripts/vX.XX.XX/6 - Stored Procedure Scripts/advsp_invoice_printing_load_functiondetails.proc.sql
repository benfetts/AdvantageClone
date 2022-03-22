CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_functiondetails]
	@ClientCode AS varchar(6),
	@DivisionCode AS varchar(6),
	@ProductCode AS varchar(6),
	@InvoiceNumber AS int,
	@InvoiceSequenceNumber AS smallint,
	@InvoiceType AS varchar(3),
	@JobNumber AS int,
	@ComponentNumber AS smallint,
	@FunctionCode AS varchar(6),
	@PrintFunctionType AS smallint,
	@ApplyExchangeRate AS smallint,
	@ExchangeRateAmount AS decimal(10, 6),
	@TotalsShowTaxSeparately AS bit,
	@TotalsShowCommissionSeparately AS bit,
	@ShowZeroFunctionAmounts AS bit,
	@IsDraft AS bit,
	@Batch AS varchar(100)
AS
BEGIN
		
	SET NOCOUNT ON

	DECLARE @PRD_CONSOL_FUNC AS smallint
	DECLARE @FunctionType AS varchar(1)

	SET @PRD_CONSOL_FUNC = NULL
	
	SELECT 
		@PRD_CONSOL_FUNC = PRD_CONSOL_FUNC
	FROM 
		[dbo].[PRODUCT] AS P 
	WHERE 
		P.CL_CODE = @ClientCode AND
		P.DIV_CODE = @DivisionCode AND
		P.PRD_CODE = @ProductCode 
		
	SET @PRD_CONSOL_FUNC = ISNULL(@PRD_CONSOL_FUNC, 0)
		
	SET @FunctionType = NULL
	
	SELECT 
		@FunctionType = FNC_TYPE
	FROM 
		[dbo].[FUNCTIONS] AS F
	WHERE 
		F.FNC_CODE = @FunctionCode
		
	IF @IsDraft = 1 BEGIN
	
		SELECT
			[Type] = GFD.[Type],
			[Item] = GFD.[Item],
			[ItemDate] = GFD.[ItemDate],
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND @PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN GFD.[Quantity] ELSE 0 END
							  ELSE CASE WHEN @FunctionType <> 'E' THEN GFD.[Quantity] ELSE 0 END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND @PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN GFD.[Quantity] ELSE 0 END
						   ELSE CASE WHEN @FunctionType = 'E' THEN GFD.[Quantity] ELSE 0 END END,
			[Rate] = dbo.advfn_invoice_printing_xchge_rate_amt(ISNULL(GFD.[Rate], 0), @ApplyExchangeRate, @ExchangeRateAmount),
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[NonResaleTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[CityTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[CountyTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[StateTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(ISNULL(GFD.[TotalAmount], 0), @ApplyExchangeRate, @ExchangeRateAmount),
			[Comment] = GFD.[Comment]
		FROM
			(SELECT
					[Type] = FD.[Type],
					[Item] = FD.[Item],
					[ItemDate] = FD.[ItemDate],
					[Quantity] = SUM(FD.[Quantity]),
					[Rate] = FD.[Rate],
					[NetAmount] = SUM(FD.[NetAmount]),
					[CommissionAmount] = SUM(FD.[CommissionAmount]),
					[NonResaleTax] = SUM(FD.[NonResaleTax]),
					[CityTax] = SUM(FD.[CityTax]),
					[CountyTax] = SUM(FD.[CountyTax]),
					[StateTax] = SUM(FD.[StateTax]),
					[TotalTax] = SUM(FD.[TotalTax]),
					[TotalAmount] = SUM(FD.[TotalAmount]),
					[Comment] = FD.[Comment]
				FROM
					(SELECT
						[Type] = 'E',
						[FunctionCode] = ETD.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = ETD.ET_ID,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = ET.EMP_CODE,
						[Item] = E.EMP_FNAME + ' ' + E.EMP_LNAME,
						[ItemDate] = ET.EMP_DATE,
						[ItemDetail] = NULL,
						[Quantity] = ETD.EMP_HOURS,  
						[Rate] = CAST(ETD.EMP_BILL_RATE AS decimal(16,4)),  
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[TaxCode] = ETD.TAX_CODE, 
						[NonResaleTax] = 0,
						[CityTax] = ETD.EXT_CITY_RESALE, 
						[CountyTax] = ETD.EXT_COUNTY_RESALE, 
						[StateTax] = ETD.EXT_STATE_RESALE, 
						[TotalTax] = ETD.EXT_CITY_RESALE + ETD.EXT_COUNTY_RESALE + ETD.EXT_STATE_RESALE,
						[TotalAmount] = ETD.LINE_TOTAL,
						[Comment] = (SELECT 
											TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(4000))
										FROM 
											[dbo].[EMP_TIME_DTL_CMTS] AS ETDC
										WHERE 
											ETDC.ET_ID = ETD.ET_ID AND 
											ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
											ETDC.ET_SOURCE = 'D')
					FROM
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS E ON E.EMP_CODE = ET.EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE
					WHERE
						ISNULL(ETD.BILL_HOLD_FLG, 0) = 0 AND 
						ETD.AR_INV_NBR IS NULL AND
						ETD.AR_INV_SEQ IS NULL AND
						ETD.AR_TYPE IS NULL AND
						ETD.JOB_NUMBER = @JobNumber AND
						ETD.JOB_COMPONENT_NBR = @ComponentNumber AND
						ETD.FNC_CODE = @FunctionCode AND
						ETD.BILLING_USER = @Batch
										
					UNION ALL
										
					SELECT
						[Type] = 'AB',
						[FunctionCode] = AB.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = NULL,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = NULL,
						[Item] = 'Advance Billing',
						[ItemDate] = AB.FINAL_DATE,
						[ItemDetail] = NULL,
						[Quantity] = AB.QTY_HOURS, 
						[Rate] = CAST(AB.RATE AS decimal(16,4)), 
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[TaxCode] = AB.TAX_CODE, 
						[NonResaleTax] = AB.EXT_NONRESALE_TAX,
						[CityTax] = AB.EXT_CITY_RESALE, 
						[CountyTax] = AB.EXT_COUNTY_RESALE, 
						[StateTax] = AB.EXT_STATE_RESALE, 
						[TotalTax] = AB.EXT_CITY_RESALE + AB.EXT_COUNTY_RESALE + AB.EXT_STATE_RESALE,
						[TotalAmount] = AB.LINE_TOTAL,
						[Comment] = NULL
					FROM
						[dbo].[ADVANCE_BILLING] AS AB INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE
					WHERE
						AB.AR_INV_NBR IS NULL AND
						AB.AR_INV_SEQ IS NULL AND
						AB.AR_TYPE IS NULL AND
						AB.JOB_NUMBER = @JobNumber AND
						AB.JOB_COMPONENT_NBR = @ComponentNumber AND
						AB.FNC_CODE = @FunctionCode AND
						AB.BILLING_USER = @Batch
											
					UNION ALL
											
					SELECT
						[Type] = 'IO',
						[FunctionCode] = [IO].FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = [IO].IO_ID,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = NULL,
						[Item] = [IO].IO_DESC,
						[ItemDate] = [IO].IO_INV_DATE,
						[ItemDetail] = [IO].IO_INV_NBR,
						[Quantity] = ISNULL([IO].IO_QTY, 0), 
						[Rate] = CAST([IO].IO_RATE AS decimal(16,4)),   
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) - ISNULL([IO].EXT_MARKUP_AMT, 0)
																	ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[TaxCode] = NULL, 
						[NonResaleTax] = 0,
						[CityTax] = [IO].EXT_CITY_RESALE, 
						[CountyTax] = [IO].EXT_COUNTY_RESALE, 
						[StateTax] = [IO].EXT_STATE_RESALE, 
						[TotalTax] = [IO].EXT_CITY_RESALE + [IO].EXT_COUNTY_RESALE + [IO].EXT_STATE_RESALE,
						[TotalAmount] = [IO].LINE_TOTAL,
						[Comment] = CAST([IO].IO_COMMENT AS varchar(4000))
					FROM
						[dbo].[INCOME_ONLY] AS [IO] INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE
					WHERE
						ISNULL([IO].BILL_HOLD_FLAG, 0) = 0 AND 
						[IO].AR_INV_NBR IS NULL AND
						[IO].AR_INV_SEQ IS NULL AND
						[IO].AR_TYPE IS NULL AND
						[IO].JOB_NUMBER = @JobNumber AND
						[IO].JOB_COMPONENT_NBR = @ComponentNumber AND
						[IO].FNC_CODE = @FunctionCode AND
						[IO].BILLING_USER = @Batch
											
					UNION ALL
										
					SELECT
						[Type] = 'AP',
						[FunctionCode] = AP.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = AP.AP_ID,
						[ItemSequenceID] = AP.AP_SEQ,
						[ItemLineNumber] = AP.LINE_NUMBER,
						[ItemCode] = APH.VN_FRL_EMP_CODE,
						[Item] = V.VN_NAME,
						[ItemDate] = APH.AP_INV_DATE,
						[ItemDetail] = APH.AP_INV_VCHR,
						[Quantity] = ISNULL(AP.AP_PROD_QUANTITY, 0), 
						[Rate] = CAST(AP.AP_PROD_RATE AS decimal(16,4)),    
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) - ISNULL(AP.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[TaxCode] = AP.TAX_CODE, 
						[NonResaleTax] = AP.EXT_NONRESALE_TAX,
						[CityTax] = AP.EXT_CITY_RESALE, 
						[CountyTax] = AP.EXT_COUNTY_RESALE, 
						[StateTax] = AP.EXT_STATE_RESALE, 
						[TotalTax] = AP.EXT_CITY_RESALE + AP.EXT_COUNTY_RESALE + AP.EXT_STATE_RESALE,
						[TotalAmount] = AP.LINE_TOTAL,
						[Comment] = CAST(APC.AP_COMMENT AS varchar(4000))
					FROM
						[dbo].[AP_PRODUCTION] AS AP INNER JOIN 
						[dbo].[AP_HEADER] AS APH ON APH.AP_ID = AP.AP_ID AND 
													APH.AP_SEQ = AP.AP_SEQ INNER JOIN 
						[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AP.FNC_CODE LEFT OUTER JOIN
						[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = AP.AP_ID AND
														   APC.LINE_NUMBER = AP.LINE_NUMBER
					WHERE
						ISNULL(AP.AP_PROD_NOBILL_FLG, 0) = 0 AND 
						ISNULL(AP.AP_PROD_BILL_HOLD, 0) = 0 AND   
						AP.AR_INV_NBR IS NULL AND
						AP.AR_INV_SEQ IS NULL AND
						AP.AR_TYPE IS NULL AND
						AP.JOB_NUMBER = @JobNumber AND
						AP.JOB_COMPONENT_NBR = @ComponentNumber AND
						AP.FNC_CODE = @FunctionCode AND
						AP.BILLING_USER = @Batch) AS FD 
				GROUP BY
					FD.[Type],
					FD.[Item],
					FD.[ItemDate],
					FD.[Rate],
					FD.[Comment]) AS GFD INNER JOIN 
				(SELECT 
						F.FNC_CODE, 
						[CONSOL_FNC] = COALESCE(SF.FNC_CONSOLIDATION, F.FNC_CONSOLIDATION, F.FNC_CODE),
						[FNC_DESCRIPTION] = COALESCE(SF.FNC_DESCRIPTION, F.FNC_DESCRIPTION, F.FNC_DESCRIPTION),
						[FNC_TYPE] = COALESCE(SF.FNC_TYPE, F.FNC_TYPE, F.FNC_TYPE),
						[FNC_ORDER] = CAST(ISNULL(COALESCE(SF.FNC_ORDER, F.FNC_ORDER, F.FNC_ORDER), 0) AS smallint),
						[FNC_HEADING_DESC] = COALESCE(SFH.FNC_HEADING_DESC, FH.FNC_HEADING_DESC, FH.FNC_HEADING_DESC),
						[FNC_HEADING_SEQ] = COALESCE(SFH.FNC_HEADING_SEQ, FH.FNC_HEADING_SEQ, FH.FNC_HEADING_SEQ)
					FROM 
						[dbo].[FUNCTIONS] AS F LEFT OUTER JOIN 
						[dbo].[FUNCTIONS] AS SF ON SF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
						[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN 
						[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = @FunctionCode
		WHERE
			1 = CASE WHEN @ShowZeroFunctionAmounts = 0 AND dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, 
																									ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount) = 0 THEN 0 ELSE 1 END
		
	END ELSE BEGIN

		SELECT
			[Type] = GFD.[Type],
			[Item] = GFD.[Item],
			[ItemDate] = GFD.[ItemDate],
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND @PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN GFD.[Quantity] ELSE 0 END
							  ELSE CASE WHEN @FunctionType <> 'E' THEN GFD.[Quantity] ELSE 0 END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND @PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN GFD.[Quantity] ELSE 0 END
						   ELSE CASE WHEN @FunctionType = 'E' THEN GFD.[Quantity] ELSE 0 END END,
			[Rate] = dbo.advfn_invoice_printing_xchge_rate_amt(ISNULL(GFD.[Rate], 0), @ApplyExchangeRate, @ExchangeRateAmount),  
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[NonResaleTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[CityTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[CountyTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[StateTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = dbo.advfn_invoice_printing_xchge_tax_amt(ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(ISNULL(GFD.[TotalAmount], 0), @ApplyExchangeRate, @ExchangeRateAmount),
			[Comment] = GFD.[Comment]
		FROM
			(SELECT
					[Type] = FD.[Type],
					[Item] = FD.[Item],
					[ItemDate] = FD.[ItemDate],
					[Quantity] = SUM(FD.[Quantity]),
					[Rate] = FD.[Rate],
					[NetAmount] = SUM(FD.[NetAmount]),
					[CommissionAmount] = SUM(FD.[CommissionAmount]),
					[NonResaleTax] = SUM(FD.[NonResaleTax]),
					[CityTax] = SUM(FD.[CityTax]),
					[CountyTax] = SUM(FD.[CountyTax]),
					[StateTax] = SUM(FD.[StateTax]),
					[TotalTax] = SUM(FD.[TotalTax]),
					[TotalAmount] = SUM(FD.[TotalAmount]),
					[Comment] = FD.[Comment]
				FROM
					(SELECT
						[Type] = 'E',
						[FunctionCode] = ETD.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = ETD.ET_ID,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = ET.EMP_CODE,
						[Item] = E.EMP_FNAME + ' ' + E.EMP_LNAME,
						[ItemDate] = ET.EMP_DATE,
						[ItemDetail] = NULL,
						[Quantity] = ETD.EMP_HOURS,  
						[Rate] = CAST(ETD.EMP_BILL_RATE AS decimal(16,4)),  
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[TaxCode] = ETD.TAX_CODE, 
						[NonResaleTax] = 0,
						[CityTax] = ETD.EXT_CITY_RESALE, 
						[CountyTax] = ETD.EXT_COUNTY_RESALE, 
						[StateTax] = ETD.EXT_STATE_RESALE, 
						[TotalTax] = ETD.EXT_CITY_RESALE + ETD.EXT_COUNTY_RESALE + ETD.EXT_STATE_RESALE,
						[TotalAmount] = ETD.LINE_TOTAL,
						[Comment] = (SELECT 
											TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(4000))
										FROM 
											[dbo].[EMP_TIME_DTL_CMTS] AS ETDC
										WHERE 
											ETDC.ET_ID = ETD.ET_ID AND 
											ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
											ETDC.ET_SOURCE = 'D')
					FROM
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS E ON E.EMP_CODE = ET.EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE
					WHERE
						ISNULL(ETD.BILL_HOLD_FLG, 0) = 0 AND 
						ETD.AR_INV_NBR = @InvoiceNumber AND
						ETD.AR_INV_SEQ = @InvoiceSequenceNumber AND
						ETD.AR_TYPE = @InvoiceType AND
						ETD.JOB_NUMBER = @JobNumber AND
						ETD.JOB_COMPONENT_NBR = @ComponentNumber AND
						ETD.FNC_CODE = @FunctionCode
										
					UNION ALL
										
					SELECT
						[Type] = 'AB',
						[FunctionCode] = AB.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = NULL,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = NULL,
						[Item] = 'Advance Billing',
						[ItemDate] = AR.AR_INV_DATE,
						[ItemDetail] = NULL,
						[Quantity] = AB.QTY_HOURS, 
						[Rate] = CAST(AB.RATE AS decimal(16,4)), 
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[TaxCode] = AB.TAX_CODE, 
						[NonResaleTax] = AB.EXT_NONRESALE_TAX,
						[CityTax] = AB.EXT_CITY_RESALE, 
						[CountyTax] = AB.EXT_COUNTY_RESALE, 
						[StateTax] = AB.EXT_STATE_RESALE, 
						[TotalTax] = AB.EXT_CITY_RESALE + AB.EXT_COUNTY_RESALE + AB.EXT_STATE_RESALE,
						[TotalAmount] = AB.LINE_TOTAL,
						[Comment] = NULL
					FROM
						[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
						[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
												  AR.AR_INV_SEQ = AB.AR_INV_SEQ AND 
												  AR.AR_TYPE = AB.AR_TYPE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE
					WHERE
						AB.AR_INV_NBR = @InvoiceNumber AND
						AB.AR_INV_SEQ = @InvoiceSequenceNumber AND
						AB.AR_TYPE = @InvoiceType AND
						AB.JOB_NUMBER = @JobNumber AND
						AB.JOB_COMPONENT_NBR = @ComponentNumber AND
						AB.FNC_CODE = @FunctionCode
											
					UNION ALL
											
					SELECT
						[Type] = 'IO',
						[FunctionCode] = [IO].FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = [IO].IO_ID,
						[ItemSequenceID] = NULL,
						[ItemLineNumber] = 0,
						[ItemCode] = NULL,
						[Item] = [IO].IO_DESC,
						[ItemDate] = [IO].IO_INV_DATE,
						[ItemDetail] = [IO].IO_INV_NBR,
						[Quantity] = ISNULL([IO].IO_QTY, 0), 
						[Rate] = CAST([IO].IO_RATE AS decimal(16,4)), 
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) - ISNULL([IO].EXT_MARKUP_AMT, 0)
																	ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[TaxCode] = NULL, 
						[NonResaleTax] = 0,
						[CityTax] = [IO].EXT_CITY_RESALE, 
						[CountyTax] = [IO].EXT_COUNTY_RESALE, 
						[StateTax] = [IO].EXT_STATE_RESALE, 
						[TotalTax] = [IO].EXT_CITY_RESALE + [IO].EXT_COUNTY_RESALE + [IO].EXT_STATE_RESALE,
						[TotalAmount] = [IO].LINE_TOTAL,
						[Comment] = CAST([IO].IO_COMMENT AS varchar(4000))
					FROM
						[dbo].[INCOME_ONLY] AS [IO] INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE
					WHERE
						ISNULL([IO].BILL_HOLD_FLAG, 0) = 0 AND 
						[IO].AR_INV_NBR = @InvoiceNumber AND
						[IO].AR_INV_SEQ = @InvoiceSequenceNumber AND
						[IO].AR_TYPE = @InvoiceType AND
						[IO].JOB_NUMBER = @JobNumber AND
						[IO].JOB_COMPONENT_NBR = @ComponentNumber AND
						[IO].FNC_CODE = @FunctionCode
											
					UNION ALL
										
					SELECT
						[Type] = 'AP',
						[FunctionCode] = AP.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[FunctionType] = F.FNC_TYPE,
						[ItemID] = AP.AP_ID,
						[ItemSequenceID] = AP.AP_SEQ,
						[ItemLineNumber] = AP.LINE_NUMBER,
						[ItemCode] = APH.VN_FRL_EMP_CODE,
						[Item] = V.VN_NAME,
						[ItemDate] = APH.AP_INV_DATE,
						[ItemDetail] = APH.AP_INV_VCHR,
						[Quantity] = ISNULL(AP.AP_PROD_QUANTITY, 0), 
						[Rate] = CAST(AP.AP_PROD_RATE AS decimal(16,4)),    
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) - ISNULL(AP.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[TaxCode] = AP.TAX_CODE, 
						[NonResaleTax] = AP.EXT_NONRESALE_TAX,
						[CityTax] = AP.EXT_CITY_RESALE, 
						[CountyTax] = AP.EXT_COUNTY_RESALE, 
						[StateTax] = AP.EXT_STATE_RESALE, 
						[TotalTax] = AP.EXT_CITY_RESALE + AP.EXT_COUNTY_RESALE + AP.EXT_STATE_RESALE,
						[TotalAmount] = AP.LINE_TOTAL,
						[Comment] = CAST(APC.AP_COMMENT AS varchar(4000))
					FROM
						[dbo].[AP_PRODUCTION] AS AP INNER JOIN 
						[dbo].[AP_HEADER] AS APH ON APH.AP_ID = AP.AP_ID AND 
													APH.AP_SEQ = AP.AP_SEQ INNER JOIN 
						[dbo].[VENDOR] AS V ON V.VN_CODE = APH.VN_FRL_EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AP.FNC_CODE LEFT OUTER JOIN
						[dbo].[AP_PROD_COMMENTS] AS APC ON APC.AP_ID = AP.AP_ID AND
														   APC.LINE_NUMBER = AP.LINE_NUMBER
					WHERE
						ISNULL(AP.AP_PROD_NOBILL_FLG, 0) = 0 AND 
						ISNULL(AP.AP_PROD_BILL_HOLD, 0) = 0 AND 
						AP.AR_INV_NBR = @InvoiceNumber AND
						AP.AR_INV_SEQ = @InvoiceSequenceNumber AND
						AP.AR_TYPE = @InvoiceType AND
						AP.JOB_NUMBER = @JobNumber AND
						AP.JOB_COMPONENT_NBR = @ComponentNumber AND
						AP.FNC_CODE = @FunctionCode) AS FD 
				GROUP BY
					FD.[Type],
					FD.[Item],
					FD.[ItemDate],
					FD.[Rate],
					FD.[Comment]) AS GFD INNER JOIN 
			(SELECT 
					F.FNC_CODE, 
					[CONSOL_FNC] = COALESCE(SF.FNC_CONSOLIDATION, F.FNC_CONSOLIDATION, F.FNC_CODE),
					[FNC_DESCRIPTION] = COALESCE(SF.FNC_DESCRIPTION, F.FNC_DESCRIPTION, F.FNC_DESCRIPTION),
					[FNC_TYPE] = COALESCE(SF.FNC_TYPE, F.FNC_TYPE, F.FNC_TYPE),
					[FNC_ORDER] = CAST(ISNULL(COALESCE(SF.FNC_ORDER, F.FNC_ORDER, F.FNC_ORDER), 0) AS smallint),
					[FNC_HEADING_DESC] = COALESCE(SFH.FNC_HEADING_DESC, FH.FNC_HEADING_DESC, FH.FNC_HEADING_DESC),
					[FNC_HEADING_SEQ] = COALESCE(SFH.FNC_HEADING_SEQ, FH.FNC_HEADING_SEQ, FH.FNC_HEADING_SEQ)
				FROM 
					[dbo].[FUNCTIONS] AS F LEFT OUTER JOIN 
					[dbo].[FUNCTIONS] AS SF ON SF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
					[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN 
					[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = @FunctionCode
		WHERE
			1 = CASE WHEN @ShowZeroFunctionAmounts = 0 AND dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), @TotalsShowCommissionSeparately, 
																				   ISNULL(GFD.[TotalTax], 0), @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount) = 0 THEN 0 ELSE 1 END
		
	END	
						
END
















GO