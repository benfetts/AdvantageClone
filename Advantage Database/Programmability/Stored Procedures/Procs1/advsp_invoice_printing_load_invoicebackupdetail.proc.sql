CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_invoicebackupdetail]
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@AddressBlockType AS smallint,
	@PrintClientName AS bit,
	@PrintDivisionName AS bit,
	@PrintProductDescription AS bit,
	@PrintContactAfterAddress AS bit,
	@PrintFunctionType AS smallint,
	@SortFunctionByType AS smallint,
	@ApplyExchangeRate AS smallint,
	@ExchangeRateAmount AS decimal(10, 6),
	@UseInvoiceCategoryDescription AS bit,
	@InvoiceTitle AS varchar(MAX),
	@ShowCodes AS bit,
	@ContactType AS int,
	@ShowZeroFunctionAmounts AS bit,
	@IsDraft AS bit,
	@Batch AS varchar(100)
AS
BEGIN
	
	IF @IsDraft = 1 BEGIN
	
		SELECT 	
			[InvoiceNumber] = BIA.AR_INV_NBR, 
			[InvoiceSequenceNumber] = BIA.AR_INV_SEQ,
			[InvoiceDate] = BIA.AR_INV_DATE,
			[InvoiceType] = BIA.AR_TYPE,
			[FullInvoiceNumber] = RIGHT('000000' + CAST(BIA.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(BIA.AR_INV_SEQ AS varchar(4)), 4),
			[JobNumber] = BIA.JOB_NUMBER,
			[JobDescription] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + JL.JOB_DESC, 
			[ComponentNumber] = BIA.JOB_COMPONENT_NBR, 
			[ComponentDescription] = RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + JC.JOB_COMP_DESC,
			[ClientCode] = BIA.CL_CODE,
			[DivisionCode] = BIA.DIV_CODE,
			[ProductCode] = BIA.PRD_CODE,
			[SCType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN 'C'
							ELSE 'S' END,
			[FunctionType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_TYPE
								  ELSE BIA.FNC_TYPE END,
			[FunctionOrder] = CAST(CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
																			   ELSE BIA.FNC_ORDER END 
										ELSE 0 END AS smallint),
			[FunctionCode] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
								  ELSE BIA.FNC_CODE END,
			[FunctionDescription] =  CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_DESCRIPTION
										  ELSE BIA.FNC_DESCRIPTION END,
			[FunctionHeading] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_DESC
									 ELSE BIA.FNC_HEADING_DESC END,
			[FunctionHeadingOrder] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_SEQ
										  ELSE BIA.FNC_HEADING_SEQ END,
			[Type] = GFD.[Type],
			[ItemID] = GFD.[ItemID],
			[ItemSequenceID] = GFD.[ItemSequenceID],
			[ItemLineNumber] = GFD.[ItemLineNumber],
			[ItemCode] = GFD.[ItemCode],
			[Item] = GFD.[Item],
			[ItemDate] = GFD.[ItemDate],
			[ItemDetail] = GFD.[ItemDetail],
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN GFD.[HoursQuantity] ELSE NULL END
							  ELSE CASE WHEN GFD.[FunctionType] <> 'E' THEN GFD.[HoursQuantity] ELSE NULL END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN GFD.[HoursQuantity] ELSE NULL END
						   ELSE CASE WHEN GFD.[FunctionType] = 'E' THEN GFD.[HoursQuantity] ELSE NULL END END, 
			[Rate] = GFD.[Rate],
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(GFD.[NetAmount], GFD.[CommissionAmount], 1, 
												  GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 
												  1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(GFD.[CommissionAmount], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[NonResaleTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CityTax], 1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CountyTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),  
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[StateTax], 1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(GFD.[TotalAmount], @ApplyExchangeRate, @ExchangeRateAmount),
			[ClientReference] = JL.JOB_CLI_REF,
			[ClientPO] = JC.JOB_CL_PO_NBR,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
			[SalesClassCode] = JL.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
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
																											C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
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
			[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND BIA.INV_CAT IS NOT NULL THEN BIA.INV_CAT_DESC 
									 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
									 ELSE 'DRAFT INVOICE BACKUP' END,
			[CampaignID] =  JL.CMP_IDENTIFIER,
			[CampaignCode] =  CAMP.CMP_CODE,
			[CampaignName] =  CAMP.CMP_NAME,
			[Campaign] =  CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME,
			[Comment] = GFD.Comment
		FROM
			(SELECT
					--ARS.AR_FUNCTION_ID,
					ARS.FNC_TYPE,
					ARS.JOB_NUMBER,
					ARS.JOB_COMPONENT_NBR,
					ARS.CL_CODE,
					ARS.DIV_CODE,
					ARS.PRD_CODE,
					ARS.OFFICE_CODE,
					ARS.FNC_CODE,
					F.FNC_DESCRIPTION,
					[FNC_ORDER] = CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ,
					ARS.AR_INV_NBR,
					[AR_INV_SEQ] = ARS.DRAFT_INV_SEQ,
					[AR_TYPE] = 'IN',
					[AR_INV_DATE] = NULL,
					--[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
					--[RATE] = CAST(0 AS decimal(18,2)),
					--[EXT_AMT] = CAST(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) - ISNULL(ARS.COMMISSION_AMT, 0) - ISNULL(ARS.AB_COMMISSION_AMT, 0)
					--								   ELSE ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) END AS decimal(18,2)),
					--[EXT_MARKUP_AMT] = CAST(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0)
					--										  ELSE 0 END AS decimal(18,2)),
					--ARS.TAX_CODE,
					--[EXT_NONRESALE_TAX] = CAST(0 AS decimal(18,2)),
					--[EXT_STATE_RESALE] = CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)),
					--[EXT_COUNTY_RESALE] = CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)),
					--[EXT_CITY_RESALE] = CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)),
					--[LINE_TOTAL] = CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)),
					[INV_CAT] = NULL,
					[INV_CAT_DESC] = NULL,
					[CDP_CONTACT_ID] = NULL
				FROM 
					[dbo].[AR_FUNCTION] AS ARS INNER JOIN 
					[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ARS.FNC_CODE LEFT OUTER JOIN 
					[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
				WHERE 
					ARS.DRAFT_INV_SEQ <> 99 AND
					ARS.AR_INV_NBR = @InvoiceNumber AND
					ARS.DRAFT_INV_SEQ = @SequenceNumber AND
					ARS.BILLING_USER = @Batch AND
					ARS.FNC_TYPE <> 'R' AND
					ISNULL(ARS.TOTAL_BILL, 0) <> 0
				GROUP BY 
					ARS.AR_INV_NBR,
					ARS.DRAFT_INV_SEQ,
					ARS.JOB_NUMBER,
					ARS.JOB_COMPONENT_NBR,
					ARS.CL_CODE,
					ARS.DIV_CODE,
					ARS.PRD_CODE,
					ARS.OFFICE_CODE,
					ARS.FNC_TYPE,
					ARS.FNC_CODE,
					F.FNC_DESCRIPTION,
					CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ) AS BIA LEFT OUTER JOIN
			(SELECT
					[InvoiceNumber] = FD.[InvoiceNumber], 
					[InvoiceSequenceNumber] = FD.[InvoiceSequenceNumber],
					[InvoiceType] = FD.[InvoiceType],
					[JobNumber] = FD.[JobNumber],
					[ComponentNumber] = FD.[ComponentNumber],
					[Type] = FD.[Type],
					[FunctionCode] = FD.[FunctionCode],
					[FunctionDescription] = FD.[FunctionDescription],
					[FunctionType] = FD.[FunctionType],
					[TaxCode] = FD.[TaxCode],
					[ItemID] = FD.[ItemID],
					[ItemSequenceID] = FD.[ItemSequenceID],
					[ItemLineNumber] = FD.[ItemLineNumber],
					[ItemCode] = FD.[ItemCode],
					[Item] = FD.[Item],
					[ItemDate] = FD.[ItemDate],
					[ItemDetail] = FD.[ItemDetail],
					[Comment] = FD.[Comment],
					[Rate] = FD.[Rate],
					[HoursQuantity] = SUM(FD.[HoursQuantity]),
					[NetAmount] = SUM(FD.[NetAmount]),
					[CommissionAmount] = SUM(FD.[CommissionAmount]),
					[NonResaleTax] = SUM(FD.[NonResaleTax]),
					[CityTax] = SUM(FD.[CityTax]),
					[CountyTax] = SUM(FD.[CountyTax]),
					[StateTax] = SUM(FD.[StateTax]),
					[TotalAmount] = SUM(FD.[TotalAmount])
				FROM
					(SELECT		
						[InvoiceNumber] = ETD.AR_INV_NBR, 
						[InvoiceSequenceNumber] = ETD.AR_INV_SEQ,
						[InvoiceType] = ETD.AR_TYPE,
						[Type] = 'E',
						[JobNumber] = ETD.JOB_NUMBER,
						[ComponentNumber] = ETD.JOB_COMPONENT_NBR, 
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
						[Comment] = (SELECT 
											TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(4000))
										FROM 
											[dbo].[EMP_TIME_DTL_CMTS] AS ETDC
										WHERE 
											ETDC.ET_ID = ETD.ET_ID AND 
											ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
											ETDC.ET_SOURCE = 'D'),
						[Rate] = CAST(ETD.EMP_BILL_RATE AS decimal(18,2)),
						[HoursQuantity] = CAST(ETD.EMP_HOURS AS decimal(18,2)), 
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(0 AS decimal(18,2)),
						[StateTax] = CAST(ETD.EXT_STATE_RESALE AS decimal(18,2)),
						[CountyTax] = CAST(ETD.EXT_COUNTY_RESALE AS decimal(18,2)), 
						[CityTax] = CAST(ETD.EXT_CITY_RESALE AS decimal(18,2)),
						[TotalAmount] = CAST(ETD.LINE_TOTAL AS decimal(18,2)),
						[TaxCode] = ETD.TAX_CODE
					FROM
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS E ON E.EMP_CODE = ET.EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE
					WHERE
						ISNULL(ETD.BILL_HOLD_FLG, 0) = 0 AND 
						ETD.AR_INV_NBR IS NULL AND
						ETD.BILLING_USER = @Batch
										
					UNION ALL
										
					SELECT
						[InvoiceNumber] = AB.AR_INV_NBR, 
						[InvoiceSequenceNumber] = AB.AR_INV_SEQ,
						[InvoiceType] = AB.AR_TYPE,
						[Type] = 'AB',
						[JobNumber] = AB.JOB_NUMBER,
						[ComponentNumber] = AB.JOB_COMPONENT_NBR, 
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
						[Comment] = NULL,
						[Rate] = CAST(AB.RATE AS decimal(18,2)),
						[HoursQuantity] = CAST(AB.QTY_HOURS AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(AB.EXT_NONRESALE_TAX AS decimal(18,2)),
						[StateTax] = CAST(ISNULL(AB.EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL(AB.EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL(AB.EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL(AB.LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = AB.TAX_CODE
					FROM
						[dbo].[ADVANCE_BILLING] AS AB INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE
					WHERE
						AB.AR_INV_NBR IS NULL AND
						AB.BILLING_USER = @Batch
											
					UNION ALL
											
					SELECT
						[InvoiceNumber] = [IO].AR_INV_NBR, 
						[InvoiceSequenceNumber] = [IO].AR_INV_SEQ,
						[InvoiceType] = [IO].AR_TYPE,
						[Type] = 'IO',
						[JobNumber] = [IO].JOB_NUMBER,
						[ComponentNumber] = [IO].JOB_COMPONENT_NBR, 
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
						[Comment] = CAST([IO].IO_COMMENT AS varchar(4000)),
						[Rate] = CAST(0 AS decimal(18,2)),
						[HoursQuantity] = CAST([IO].IO_QTY AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) - ISNULL([IO].EXT_MARKUP_AMT, 0)
																	ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(0 AS decimal(18,2)),
						[StateTax] = CAST(ISNULL([IO].EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL([IO].EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL([IO].EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL([IO].LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = [IO].TAX_CODE
					FROM
						[dbo].[INCOME_ONLY] AS [IO] INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE
					WHERE
						[IO].AR_INV_NBR IS NULL AND
						[IO].BILLING_USER = @Batch
											
					UNION ALL
										
					SELECT
						[InvoiceNumber] = AP.AR_INV_NBR, 
						[InvoiceSequenceNumber] = AP.AR_INV_SEQ,
						[InvoiceType] = AP.AR_TYPE,
						[Type] = 'AP',
						[JobNumber] = AP.JOB_NUMBER,
						[ComponentNumber] = AP.JOB_COMPONENT_NBR, 
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
						[Comment] = CAST(APC.AP_COMMENT AS varchar(4000)),
						[Rate] = CAST(0 AS decimal(18,2)),
						[HoursQuantity] = CAST(AP.AP_PROD_QUANTITY AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) - ISNULL(AP.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(AP.EXT_NONRESALE_TAX AS decimal(18,2)),
						[StateTax] = CAST(ISNULL(AP.EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL(AP.EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL(AP.EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL(AP.LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = AP.TAX_CODE
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
						AP.BILLING_USER = @Batch) AS FD 
				GROUP BY
					FD.[InvoiceNumber], 
					FD.[InvoiceSequenceNumber],
					FD.[InvoiceType],
					FD.[Type],
					FD.[JobNumber],
					FD.[ComponentNumber], 
					FD.[FunctionCode],
					FD.[FunctionDescription],
					FD.[FunctionType],
					FD.[TaxCode],
					FD.[ItemID],
					FD.[ItemSequenceID],
					FD.[ItemLineNumber],
					FD.[ItemCode],
					FD.[Item],
					FD.[ItemDate],
					FD.[ItemDetail],
					FD.[Comment],
					FD.[Rate]) AS GFD ON GFD.[JobNumber] = BIA.JOB_NUMBER AND 
										 GFD.[ComponentNumber] = BIA.JOB_COMPONENT_NBR AND 
										 GFD.[FunctionCode] = BIA.FNC_CODE INNER JOIN
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = BIA.JOB_NUMBER INNER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = BIA.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = BIA.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = BIA.CL_CODE AND
										 D.DIV_CODE = BIA.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = BIA.CL_CODE AND 
										P.DIV_CODE = BIA.DIV_CODE AND 
										P.PRD_CODE = BIA.PRD_CODE INNER JOIN 
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
						[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = BIA.FNC_CODE INNER JOIN
				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = BIA.CDP_CONTACT_ID
		WHERE
			1 = CASE WHEN @ShowZeroFunctionAmounts = 0 AND dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), 1, 
																									ISNULL(GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 0), 1, @ApplyExchangeRate, @ExchangeRateAmount) = 0 THEN 0 ELSE 1 END
		ORDER BY
			BIA.CL_CODE,
			BIA.AR_INV_NBR, 
			BIA.AR_INV_SEQ DESC, 
			BIA.AR_TYPE,
			CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
														ELSE BIA.FNC_ORDER END 
				 ELSE 0 END,
			CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
				 ELSE BIA.FNC_CODE END

	END ELSE BEGIN

		SELECT 	
			[InvoiceNumber] = BIA.AR_INV_NBR, 
			[InvoiceSequenceNumber] = BIA.AR_INV_SEQ,
			[InvoiceDate] = BIA.AR_INV_DATE,
			[InvoiceType] = BIA.AR_TYPE,
			[FullInvoiceNumber] = RIGHT('000000' + CAST(BIA.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(BIA.AR_INV_SEQ AS varchar(4)), 4),
			[JobNumber] = BIA.JOB_NUMBER,
			[JobDescription] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + JL.JOB_DESC, 
			[ComponentNumber] = BIA.JOB_COMPONENT_NBR, 
			[ComponentDescription] = RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + JC.JOB_COMP_DESC,
			[ClientCode] = BIA.CL_CODE,
			[DivisionCode] = BIA.DIV_CODE,
			[ProductCode] = BIA.PRD_CODE,
			[SCType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN 'C'
							ELSE 'S' END,
			[FunctionType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_TYPE
								  ELSE BIA.FNC_TYPE END,
			[FunctionOrder] = CAST(CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
																			   ELSE BIA.FNC_ORDER END 
										ELSE 0 END AS smallint),
			[FunctionCode] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
								  ELSE BIA.FNC_CODE END,
			[FunctionDescription] =  CASE WHEN ISNULL(BCD.FNC_DESC_SOURCE, 1) = 0 THEN BCD.FNC_DESC
										  ELSE CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_DESCRIPTION
													ELSE BIA.FNC_DESCRIPTION END END,
			[FunctionHeading] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_DESC
									 ELSE BIA.FNC_HEADING_DESC END,
			[FunctionHeadingOrder] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_SEQ
										  ELSE BIA.FNC_HEADING_SEQ END,
			[Type] = GFD.[Type],
			[ItemID] = GFD.[ItemID],
			[ItemSequenceID] = GFD.[ItemSequenceID],
			[ItemLineNumber] = GFD.[ItemLineNumber],
			[ItemCode] = GFD.[ItemCode],
			[Item] = GFD.[Item],
			[ItemDate] = GFD.[ItemDate],
			[ItemDetail] = GFD.[ItemDetail],
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN GFD.[HoursQuantity] ELSE NULL END
							  ELSE CASE WHEN GFD.[FunctionType] <> 'E' THEN GFD.[HoursQuantity] ELSE NULL END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN GFD.[HoursQuantity] ELSE NULL END
						   ELSE CASE WHEN GFD.[FunctionType] = 'E' THEN GFD.[HoursQuantity] ELSE NULL END END, 
			[Rate] = GFD.[Rate],
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(GFD.[NetAmount], GFD.[CommissionAmount], 1, 
												  GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 
												  1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(GFD.[CommissionAmount], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[NonResaleTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CityTax], 1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CountyTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),  
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[StateTax], 1, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = dbo.advfn_invoice_printing_xchge_tax_amt(GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 1, @ApplyExchangeRate, @ExchangeRateAmount),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(GFD.[TotalAmount], @ApplyExchangeRate, @ExchangeRateAmount),
			[ClientReference] = JL.JOB_CLI_REF,
			[ClientPO] = JC.JOB_CL_PO_NBR,
			[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, ''),
			[SalesClassCode] = JL.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
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
																											C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
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
			[InvoiceCategory] = CASE WHEN @UseInvoiceCategoryDescription = 1 AND BIA.INV_CAT IS NOT NULL THEN BIA.INV_CAT_DESC 
									 WHEN @UseInvoiceCategoryDescription = 0 AND @InvoiceTitle IS NOT NULL AND DATALENGTH(@InvoiceTitle) > 0 THEN @InvoiceTitle
									 ELSE 'INVOICE BACKUP' END,
			[CampaignID] =  JL.CMP_IDENTIFIER,
			[CampaignCode] =  CAMP.CMP_CODE,
			[CampaignName] =  CAMP.CMP_NAME,
			[Campaign] =  CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME,
			[Comment] = GFD.Comment
		FROM
			(SELECT
					ARS.FNC_TYPE,
					ARS.JOB_NUMBER,
					ARS.JOB_COMPONENT_NBR,
					ARS.CL_CODE,
					ARS.DIV_CODE,
					ARS.PRD_CODE,
					ARS.OFFICE_CODE,
					ARS.FNC_CODE,
					F.FNC_DESCRIPTION,
					[FNC_ORDER] = CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ,
					ARS.AR_INV_NBR,
					ARS.AR_INV_SEQ,
					ARS.AR_TYPE,
					ARID.AR_INV_DATE,
					--[HRS_QTY] = CAST(ARS.HRS_QTY AS decimal(18,2)),
					--[RATE] = CAST(0 AS decimal(18,2)),
					--[EXT_AMT] = CAST(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) - ISNULL(ARS.COMMISSION_AMT, 0) - ISNULL(ARS.AB_COMMISSION_AMT, 0)
					--								   ELSE ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) END AS decimal(18,2)),
					--[EXT_MARKUP_AMT] = CAST(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0)
					--										  ELSE 0 END AS decimal(18,2)),
					--ARS.TAX_CODE,
					--[EXT_NONRESALE_TAX] = CAST(0 AS decimal(18,2)),
					--[EXT_STATE_RESALE] = CAST(ISNULL(ARS.STATE_TAX_AMT, 0) AS decimal(18,2)),
					--[EXT_COUNTY_RESALE] = CAST(ISNULL(ARS.CNTY_TAX_AMT, 0) AS decimal(18,2)),
					--[EXT_CITY_RESALE] = CAST(ISNULL(ARS.CITY_TAX_AMT, 0) AS decimal(18,2)),
					--[LINE_TOTAL] = CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2)),
					AR.INV_CAT,
					IC.INV_CAT_DESC,
					AR.CDP_CONTACT_ID
				FROM 
					[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
					(SELECT 
							AR.AR_INV_NBR, 
							AR.AR_TYPE, 
							[AR_POST_PERIOD] = MAX(AR.AR_POST_PERIOD), 
							[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
						FROM 
							[dbo].[ACCT_REC] AS AR
						WHERE 
							AR.AR_TYPE <> 'VO'
						GROUP BY 
							AR.AR_INV_NBR, 
							AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
												   ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
					(SELECT 
							DISTINCT 
							AJ.AR_INV_NBR,
							AR.CL_CODE,		
							AR.DIV_CODE,	
							AR.PRD_CODE,	
							AR.OFFICE_CODE	
						FROM 
							[dbo].[ARINV_JOB] AS AJ INNER JOIN 
							[dbo].[ACCT_REC] AS AR ON AR.AR_INV_SEQ = AJ.AR_INV_SEQ AND 
													  AR.AR_INV_NBR = AJ.AR_INV_NBR
						WHERE 
							AR.MANUAL_INV IS NULL
						GROUP BY 
							AJ.AR_INV_NBR, 
							AR.CL_CODE, 
							AR.DIV_CODE, 
							AR.PRD_CODE, 
							AR.OFFICE_CODE
						HAVING 
							MAX(AR.AR_TYPE) <> 'VO') AS ARI ON ARI.AR_INV_NBR = ARS.AR_INV_NBR LEFT OUTER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ARS.FNC_CODE INNER JOIN 
						[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
												  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
												  AR.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN 
						[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN 
						[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
					WHERE 
						ARS.AR_INV_NBR = @InvoiceNumber AND
						ARS.AR_INV_SEQ = @SequenceNumber AND
						ARS.FNC_TYPE <> 'R' AND
						ISNULL(ARS.TOTAL_BILL, 0) <> 0
					GROUP BY 
						ARS.AR_INV_NBR,
						ARS.AR_INV_SEQ,
						ARS.AR_TYPE,
						ARID.AR_INV_DATE,
						ARS.JOB_NUMBER,
						ARS.JOB_COMPONENT_NBR,
						ARS.CL_CODE,
						ARS.DIV_CODE,
						ARS.PRD_CODE,
						ARS.OFFICE_CODE,
						ARS.FNC_TYPE,
						ARS.FNC_CODE,
						F.FNC_DESCRIPTION,
						CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
						FH.FNC_HEADING_DESC,
						FH.FNC_HEADING_SEQ,
						AR.INV_CAT,
						IC.INV_CAT_DESC,
						AR.CDP_CONTACT_ID) AS BIA LEFT OUTER JOIN
			(SELECT
					[InvoiceNumber] = FD.[InvoiceNumber], 
					[InvoiceSequenceNumber] = FD.[InvoiceSequenceNumber],
					[InvoiceType] = FD.[InvoiceType],
					[Type] = FD.[Type],
					[JobNumber] = FD.[JobNumber],
					[ComponentNumber] = FD.[ComponentNumber],
					[FunctionCode] = FD.[FunctionCode],
					[FunctionDescription] = FD.[FunctionDescription],
					[FunctionType] = FD.[FunctionType],
					[TaxCode] = FD.[TaxCode],
					[ItemID] = FD.[ItemID],
					[ItemSequenceID] = FD.[ItemSequenceID],
					[ItemLineNumber] = FD.[ItemLineNumber],
					[ItemCode] = FD.[ItemCode],
					[Item] = FD.[Item],
					[ItemDate] = FD.[ItemDate],
					[ItemDetail] = FD.[ItemDetail],
					[Comment] = FD.[Comment],
					[Rate] = FD.[Rate],
					[HoursQuantity] = SUM(FD.[HoursQuantity]),
					[NetAmount] = SUM(FD.[NetAmount]),
					[CommissionAmount] = SUM(FD.[CommissionAmount]),
					[NonResaleTax] = SUM(FD.[NonResaleTax]),
					[CityTax] = SUM(FD.[CityTax]),
					[CountyTax] = SUM(FD.[CountyTax]),
					[StateTax] = SUM(FD.[StateTax]),
					[TotalAmount] = SUM(FD.[TotalAmount])
				FROM
					(SELECT		
						[InvoiceNumber] = ETD.AR_INV_NBR, 
						[InvoiceSequenceNumber] = ETD.AR_INV_SEQ,
						[InvoiceType] = ETD.AR_TYPE,
						[Type] = 'E',
						[JobNumber] = ETD.JOB_NUMBER,
						[ComponentNumber] = ETD.JOB_COMPONENT_NBR,
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
						[Comment] = (SELECT 
											TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(4000))
										FROM 
											[dbo].[EMP_TIME_DTL_CMTS] AS ETDC
										WHERE 
											ETDC.ET_ID = ETD.ET_ID AND 
											ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
											ETDC.ET_SOURCE = 'D'),
						[Rate] = CAST(ETD.EMP_BILL_RATE AS decimal(18,2)),
						[HoursQuantity] = CAST(ETD.EMP_HOURS AS decimal(18,2)), 
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(ETD.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(0 AS decimal(18,2)),
						[StateTax] = CAST(ETD.EXT_STATE_RESALE AS decimal(18,2)),
						[CountyTax] = CAST(ETD.EXT_COUNTY_RESALE AS decimal(18,2)), 
						[CityTax] = CAST(ETD.EXT_CITY_RESALE AS decimal(18,2)),
						[TotalAmount] = CAST(ETD.LINE_TOTAL AS decimal(18,2)),
						[TaxCode] = ETD.TAX_CODE
					FROM
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS E ON E.EMP_CODE = ET.EMP_CODE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE
					WHERE
						ISNULL(ETD.BILL_HOLD_FLG, 0) = 0 AND 
						ETD.AR_INV_NBR = @InvoiceNumber AND
						ETD.AR_INV_SEQ = @SequenceNumber
										
					UNION ALL
										
					SELECT
						[InvoiceNumber] = AB.AR_INV_NBR, 
						[InvoiceSequenceNumber] = AB.AR_INV_SEQ,
						[InvoiceType] = AB.AR_TYPE,
						[Type] = 'AB',
						[JobNumber] = AB.JOB_NUMBER,
						[ComponentNumber] = AB.JOB_COMPONENT_NBR,
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
						[Comment] = NULL,
						[Rate] = CAST(AB.RATE AS decimal(18,2)),
						[HoursQuantity] = CAST(AB.QTY_HOURS AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) - ISNULL(AB.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AB.LINE_TOTAL, 0) - ISNULL(AB.EXT_STATE_RESALE, 0) - ISNULL(AB.EXT_COUNTY_RESALE, 0) - ISNULL(AB.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AB.EXT_MARKUP_AMT, 0)
																  ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(AB.EXT_NONRESALE_TAX AS decimal(18,2)),
						[StateTax] = CAST(ISNULL(AB.EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL(AB.EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL(AB.EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL(AB.LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = AB.TAX_CODE
					FROM
						[dbo].[ADVANCE_BILLING] AS AB INNER JOIN 
						[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = AB.AR_INV_NBR AND 
													AR.AR_INV_SEQ = AB.AR_INV_SEQ AND 
													AR.AR_TYPE = AB.AR_TYPE INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AB.FNC_CODE
					WHERE
						AB.AR_INV_NBR = @InvoiceNumber AND
						AB.AR_INV_SEQ = @SequenceNumber
											
					UNION ALL
											
					SELECT
						[InvoiceNumber] = [IO].AR_INV_NBR, 
						[InvoiceSequenceNumber] = [IO].AR_INV_SEQ,
						[InvoiceType] = [IO].AR_TYPE,
						[Type] = 'IO',
						[JobNumber] = [IO].JOB_NUMBER,
						[ComponentNumber] = [IO].JOB_COMPONENT_NBR,
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
						[Comment] = CAST([IO].IO_COMMENT AS varchar(4000)),
						[Rate] = CAST(0 AS decimal(18,2)),
						[HoursQuantity] = CAST([IO].IO_QTY AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) - ISNULL([IO].EXT_MARKUP_AMT, 0)
																	ELSE ISNULL([IO].LINE_TOTAL, 0) - ISNULL([IO].EXT_STATE_RESALE, 0) - ISNULL([IO].EXT_COUNTY_RESALE, 0) - ISNULL([IO].EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL([IO].EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(0 AS decimal(18,2)),
						[StateTax] = CAST(ISNULL([IO].EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL([IO].EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL([IO].EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL([IO].LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = [IO].TAX_CODE
					FROM
						[dbo].[INCOME_ONLY] AS [IO] INNER JOIN
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE
					WHERE
						ISNULL([IO].BILL_HOLD_FLAG, 0) = 0 AND 
						[IO].AR_INV_NBR = @InvoiceNumber AND
						[IO].AR_INV_SEQ = @SequenceNumber
											
					UNION ALL
										
					SELECT
						[InvoiceNumber] = AP.AR_INV_NBR, 
						[InvoiceSequenceNumber] = AP.AR_INV_SEQ,
						[InvoiceType] = AP.AR_TYPE,
						[Type] = 'AP',
						[JobNumber] = AP.JOB_NUMBER,
						[ComponentNumber] = AP.JOB_COMPONENT_NBR,
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
						[Comment] = CAST(APC.AP_COMMENT AS varchar(4000)),
						[Rate] = CAST(0 AS decimal(18,2)),
						[HoursQuantity] = CAST(AP.AP_PROD_QUANTITY AS decimal(18,2)),
						[NetAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) - ISNULL(AP.EXT_MARKUP_AMT, 0)
																	ELSE ISNULL(AP.LINE_TOTAL, 0) - ISNULL(AP.EXT_STATE_RESALE, 0) - ISNULL(AP.EXT_COUNTY_RESALE, 0) - ISNULL(AP.EXT_CITY_RESALE, 0) END AS decimal(18,2)),
						[CommissionAmount] = CAST(CASE F.FNC_TYPE WHEN 'V' THEN ISNULL(AP.EXT_MARKUP_AMT, 0)
																		   ELSE 0 END AS decimal(18,2)),
						[NonResaleTax] = CAST(AP.EXT_NONRESALE_TAX AS decimal(18,2)),
						[StateTax] = CAST(ISNULL(AP.EXT_STATE_RESALE, 0) AS decimal(18,2)),
						[CountyTax] = CAST(ISNULL(AP.EXT_COUNTY_RESALE, 0) AS decimal(18,2)),
						[CityTax] = CAST(ISNULL(AP.EXT_CITY_RESALE, 0) AS decimal(18,2)),
						[TotalAmount] = CAST(ISNULL(AP.LINE_TOTAL, 0) AS decimal(18,2)),
						[TaxCode] = AP.TAX_CODE
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
						AP.AR_INV_SEQ = @SequenceNumber) AS FD 
				GROUP BY
					FD.[InvoiceNumber], 
					FD.[InvoiceSequenceNumber],
					FD.[InvoiceType],
					FD.[Type],
					FD.[JobNumber],
					FD.[ComponentNumber],
					FD.[FunctionCode],
					FD.[FunctionDescription],
					FD.[FunctionType],
					FD.[TaxCode],
					FD.[ItemID],
					FD.[ItemSequenceID],
					FD.[ItemLineNumber],
					FD.[ItemCode],
					FD.[Item],
					FD.[ItemDate],
					FD.[ItemDetail],
					FD.[Comment],
					FD.[Rate]) AS GFD ON GFD.[InvoiceNumber] = BIA.AR_INV_NBR AND 
										 GFD.[InvoiceSequenceNumber] = BIA.AR_INV_SEQ AND 
										 GFD.[InvoiceType] = BIA.AR_TYPE AND 
										 GFD.[JobNumber] = BIA.JOB_NUMBER AND 
										 GFD.[ComponentNumber] = BIA.JOB_COMPONENT_NBR AND 
										 GFD.[FunctionCode] = BIA.FNC_CODE INNER JOIN
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = BIA.JOB_NUMBER INNER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = BIA.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = BIA.CL_CODE  LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = BIA.CL_CODE AND
										 D.DIV_CODE = BIA.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = BIA.CL_CODE AND 
										P.DIV_CODE = BIA.DIV_CODE AND 
										P.PRD_CODE = BIA.PRD_CODE INNER JOIN 
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
						[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = BIA.FNC_CODE INNER JOIN
				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_JOB] AS BCJ ON BCJ.INV_NBR = BIA.AR_INV_NBR AND
													BCJ.JOB_NUMBER = BIA.JOB_NUMBER AND
													BCJ.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
				[dbo].[BILL_COMMENTS_DTL] AS BCD ON BCD.INV_NBR = BIA.AR_INV_NBR AND
													BCD.JOB_NUMBER = BIA.JOB_NUMBER AND
													BCD.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR AND
													BCD.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = BIA.CDP_CONTACT_ID
		WHERE
			1 = CASE WHEN @ShowZeroFunctionAmounts = 0 AND dbo.advfn_invoice_printing_xchge_net_amt(ISNULL(GFD.[NetAmount], 0), ISNULL(GFD.[CommissionAmount], 0), 1, 
																									ISNULL(GFD.[CityTax] + GFD.[CountyTax] + GFD.[StateTax], 0), 1, @ApplyExchangeRate, @ExchangeRateAmount) = 0 THEN 0 ELSE 1 END
		ORDER BY
			BIA.CL_CODE,
			BIA.AR_INV_NBR, 
			BIA.AR_INV_SEQ DESC, 
			BIA.AR_TYPE,
			CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
														ELSE BIA.FNC_ORDER END 
				 ELSE 0 END,
			CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
				 ELSE BIA.FNC_CODE END
		
	END

END


























GO