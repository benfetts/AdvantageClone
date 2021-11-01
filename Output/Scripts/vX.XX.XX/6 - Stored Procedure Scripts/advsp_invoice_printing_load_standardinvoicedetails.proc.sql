CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_standardinvoicedetails]
	@UserCode AS varchar(100),
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
	@TotalsShowTaxSeparately AS bit,
	@TotalsShowCommissionSeparately AS bit,
	@UseInvoiceCategoryDescription AS bit,
	@InvoiceTitle AS varchar(MAX),
	@InvoiceFooterCommentType AS smallint,
	@InvoiceFooterComment AS varchar(MAX),
	@GroupingOptionInsideDescription AS varchar(MAX),
	@GroupingOptionOutsideDescription AS varchar(MAX),
	@ShowCodes AS bit,
	@ContactType AS int,
	@IsDraft AS bit,
	@Batch AS varchar(100),
	@IncludeEstimateComment AS bit,
	@IncludeEstimateComponentComment AS bit,
	@IncludeEstimateQuoteComment AS bit,
	@IncludeEstimateRevisionComment AS bit,
	@IncludeEstimateFunctionComment AS bit
AS
BEGIN

	SET NOCOUNT ON

	DECLARE @Font varchar(50), @Font2 varchar(10)	
	
	SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
	SET @Font2 = '</span>'	
	
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
			[ClientName] = C.CL_NAME,
			[DivisionCode] = BIA.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = BIA.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[SCType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN 'C'
							ELSE 'S' END,
			[FunctionType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_TYPE
								  ELSE BIA.FNC_TYPE END,
			[FunctionOrder] = CAST(CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
																			   ELSE BIA.FNC_ORDER END 
										ELSE 0 END AS smallint),
			[OriginalFunctionCode] = BIA.FNC_CODE,
			[FunctionCode] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
								  ELSE BIA.FNC_CODE END,
			[FunctionDescription] =  CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_DESCRIPTION
										  ELSE BIA.FNC_DESCRIPTION END,
			[FunctionHeading] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_DESC
									 ELSE BIA.FNC_HEADING_DESC END,
			[FunctionHeadingOrder] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_SEQ
										  ELSE BIA.FNC_HEADING_SEQ END,
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN BIA.HRS_QTY ELSE NULL END
							  ELSE CASE WHEN BIA.FNC_TYPE <> 'E' THEN BIA.HRS_QTY ELSE NULL END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN BIA.HRS_QTY ELSE NULL END
						   ELSE CASE WHEN BIA.FNC_TYPE = 'E' THEN BIA.HRS_QTY ELSE NULL END END, 
			[Rate] = BIA.RATE,
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(BIA.EXT_AMT, BIA.EXT_MARKUP_AMT, @TotalsShowCommissionSeparately, 
												  BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE, 
												  @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(BIA.EXT_MARKUP_AMT, @TotalsShowCommissionSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_NONRESALE_TAX, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_CITY_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_COUNTY_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),  
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_STATE_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = (BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount),
			[DiscountAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount) - dbo.advfn_invoice_printing_xchge_disocunt_amt(BIA.LINE_TOTAL - (BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE), BIA.FNC_CODE, C.CLIENT_DISCOUNT_CODE, JC.CLIENT_DISCOUNT_CODE, @ApplyExchangeRate, @ExchangeRateAmount),
			[BillingComment] = NULL,
			[BillingJobComment] = NULL,
			[BillingDetailComment] = NULL,
			[JobComment] = CASE WHEN ISNULL(CAST(JL.JOB_COMMENTS AS varchar(MAX)), '') <> '' THEN CAST(JL.JOB_COMMENTS AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalClientComment] = CASE WHEN ISNULL(CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalFunctionComment] = CASE WHEN ISNULL(CAST(BACF.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BACF.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)) ELSE NULL END,
			[JobComponentComment] = CASE WHEN ISNULL(CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)), '') <> '' THEN CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)) ELSE NULL END,
			[EstimateComment] = CASE WHEN @IncludeEstimateComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_LOG_COMMENT_HTML, '') <> '' THEN ESTHC.EST_LOG_COMMENT_HTML 
																				ELSE CASE WHEN ISNULL(ESTHC.EST_LOG_COMMENT, '') <> '' THEN ESTHC.EST_LOG_COMMENT 
																						  ELSE NULL END END
									 ELSE NULL END,
			[EstimateComponentComment] = CASE WHEN @IncludeEstimateComponentComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_COMP_COMMENT_HTML, '') <> '' THEN ESTHC.EST_COMP_COMMENT_HTML 
																								  ELSE CASE WHEN ISNULL(ESTHC.EST_COMP_COMMENT, '') <> '' THEN ESTHC.EST_COMP_COMMENT 
																											ELSE NULL END END
											  ELSE NULL END,
			[EstimateQuoteComment] = CASE WHEN @IncludeEstimateQuoteComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_QTE_COMMENT_HTML, '') <> '' THEN ESTHC.EST_QTE_COMMENT_HTML 
																						  ELSE CASE WHEN ISNULL(ESTHC.EST_QTE_COMMENT, '') <> '' THEN ESTHC.EST_QTE_COMMENT 
																									ELSE NULL END END
										  ELSE NULL END,
			[EstimateRevisionComment] = CASE WHEN @IncludeEstimateRevisionComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_REV_COMMENT_HTML, '') <> '' THEN ESTHC.EST_REV_COMMENT_HTML 
																								ELSE CASE WHEN ISNULL(ESTHC.EST_REV_COMMENT, '') <> '' THEN ESTHC.EST_REV_COMMENT 
																										  ELSE NULL END END
											 ELSE NULL END,
			[EstimateFunctionComment] = CASE WHEN @IncludeEstimateFunctionComment = 1 THEN CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT_HTML, '') <> '' THEN @Font + ESTC.EST_FNC_COMMENT_HTML + @Font2 
																								ELSE CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT, '') <> '' THEN @Font + ESTC.EST_FNC_COMMENT + @Font2 
																										  ELSE NULL END END
											 ELSE NULL END,
			[InvoiceDueDate] = NULL,
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
									 ELSE 'DRAFT INVOICE' END,
			[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', BIA.OFFICE_CODE, BIA.CL_CODE, BIA.DIV_CODE, BIA.PRD_CODE), C.CL_FOOTER)
										  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
										  ELSE '' END,
			[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', BIA.OFFICE_CODE, BIA.CL_CODE, BIA.DIV_CODE, BIA.PRD_CODE), 10)
												  ELSE 10 END,
			[InsideDescription] = @GroupingOptionInsideDescription,
			[OutsideDescription] = @GroupingOptionOutsideDescription,
			[CampaignID] =  JL.CMP_IDENTIFIER,
			[CampaignCode] =  CAMP.CMP_CODE,
			[CampaignName] =  CAMP.CMP_NAME,
			[Campaign] =  CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME,
			[CampaignComment] =  CAST(CAMP.CMP_COMMENTS AS varchar(MAX))
		FROM
			(SELECT
					--ARF.AR_FUNCTION_ID,
					ARF.AR_INV_NBR,
					[AR_INV_SEQ] = ARF.DRAFT_INV_SEQ,
					[AR_TYPE] = 'IN',
					ARF.JOB_NUMBER,
					ARF.JOB_COMPONENT_NBR,
					ARF.CL_CODE,
					ARF.DIV_CODE,
					ARF.PRD_CODE,
					ARF.OFFICE_CODE,
					ARF.FNC_TYPE,
					ARF.FNC_CODE,
					F.FNC_DESCRIPTION,
					[FNC_ORDER] = CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ,
					[AR_INV_DATE] = GETDATE(),
					[HRS_QTY] = CAST(SUM(ISNULL(ARF.HRS_QTY, 0)) AS decimal(18,2)),
					[RATE] = CAST(0 AS decimal(18,2)),
					[EXT_AMT] = CAST(SUM(CASE ARF.FNC_TYPE WHEN 'V' THEN ISNULL(ARF.TOTAL_BILL, 0) - ISNULL(ARF.STATE_TAX_AMT, 0) - ISNULL(ARF.CNTY_TAX_AMT, 0) - ISNULL(ARF.CITY_TAX_AMT, 0) - ISNULL(ARF.COMMISSION_AMT, 0) - ISNULL(ARF.AB_COMMISSION_AMT, 0)
													       ELSE ISNULL(ARF.TOTAL_BILL, 0) - ISNULL(ARF.STATE_TAX_AMT, 0) - ISNULL(ARF.CNTY_TAX_AMT, 0) - ISNULL(ARF.CITY_TAX_AMT, 0) END) AS decimal(18,2)),
					[EXT_MARKUP_AMT] = CAST(SUM(CASE ARF.FNC_TYPE WHEN 'V' THEN ISNULL(ARF.COMMISSION_AMT,0) + ISNULL(ARF.AB_COMMISSION_AMT,0)
															      ELSE 0 END) AS decimal(18,2)),
					--ARF.TAX_CODE,
					[EXT_NONRESALE_TAX] = CAST(0 AS decimal(18,2)),
					[EXT_STATE_RESALE] = CAST(SUM(ISNULL(ARF.STATE_TAX_AMT, 0)) AS decimal(18,2)),
					[EXT_COUNTY_RESALE] = CAST(SUM(ISNULL(ARF.CNTY_TAX_AMT, 0)) AS decimal(18,2)),
					[EXT_CITY_RESALE] = CAST(SUM(ISNULL(ARF.CITY_TAX_AMT, 0)) AS decimal(18,2)),
					[LINE_TOTAL] = CAST(SUM(ISNULL(ARF.TOTAL_BILL, 0)) AS decimal(18,2)),
					[INV_CAT] = NULL,
					[INV_CAT_DESC] = NULL,
					[CDP_CONTACT_ID] = NULL
				FROM 
					[dbo].[AR_FUNCTION] AS ARF LEFT OUTER JOIN
					[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ARF.FNC_CODE LEFT OUTER JOIN 
					[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID
				WHERE 
					ARF.DRAFT_INV_SEQ <> 99 AND
					ARF.AR_INV_NBR = @InvoiceNumber AND
					ARF.DRAFT_INV_SEQ = @SequenceNumber AND
					ARF.BILLING_USER = @Batch AND
					ARF.FNC_TYPE <> 'R'
				GROUP BY 
					ARF.AR_INV_NBR,
					ARF.DRAFT_INV_SEQ,
					ARF.JOB_NUMBER,
					ARF.JOB_COMPONENT_NBR,
					ARF.CL_CODE,
					ARF.DIV_CODE,
					ARF.PRD_CODE,
					ARF.OFFICE_CODE,
					ARF.FNC_TYPE,
					ARF.FNC_CODE,
					F.FNC_DESCRIPTION,
					CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ) AS BIA INNER JOIN 
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
					[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
			(SELECT 
						BILL_APPR_HDR.BA_ID,
						BILL_APPR_HDR.JOB_NUMBER,
						BILL_APPR_HDR.JOB_COMPONENT_NBR,
						[BILL_APPROVAL_COMMENT] = BILL_APPR_HDR.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR]) AS BAC ON BAC.BA_ID = JC.SELECTED_BA_ID AND
														 BAC.JOB_NUMBER = BIA.JOB_NUMBER AND 
														 BAC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
			(SELECT 
						BILL_APPR_HDR.BA_ID,
						BILL_APPR_HDR.JOB_NUMBER,
						BILL_APPR_HDR.JOB_COMPONENT_NBR,
						BILL_APPR_DTL.FNC_CODE,
						[BILL_APPROVAL_FUNCTION_COMMENT] = BILL_APPR_DTL.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] INNER JOIN
						[dbo].[BILL_APPR_DTL] ON BILL_APPR_DTL.BA_ID = BILL_APPR_HDR.BA_ID AND
												 BILL_APPR_DTL.JOB_NUMBER = BILL_APPR_HDR.JOB_NUMBER AND
												 BILL_APPR_DTL.JOB_COMPONENT_NBR = BILL_APPR_HDR.JOB_COMPONENT_NBR) AS BACF ON BACF.BA_ID = JC.SELECTED_BA_ID AND
																															   BACF.JOB_NUMBER = BIA.JOB_NUMBER AND 
																															   BACF.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR AND 
																															   BACF.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
			(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EST_LOG_COMMENT = CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						EST_LOG_COMMENT_HTML = CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						EST_COMP_COMMENT = CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						EST_COMP_COMMENT_HTML = CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						EST_QTE_COMMENT = CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)),  
						EST_QTE_COMMENT_HTML = CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)),
						EST_REV_COMMENT = CAST(ER.EST_REV_COMMENT AS varchar(MAX)),  
						EST_REV_COMMENT_HTML = CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))
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
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT AS varchar(MAX)),
						CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))) AS ESTHC ON ESTHC.JOB_NUMBER = BIA.JOB_NUMBER AND
																				   ESTHC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
				(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						ERD.FNC_CODE,
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
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						ERD.FNC_CODE) AS ESTC ON ESTC.JOB_NUMBER = BIA.JOB_NUMBER AND
												 ESTC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR AND
												 ESTC.FNC_CODE = BIA.FNC_CODE INNER JOIN
			[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = BIA.CDP_CONTACT_ID
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
			[ClientName] = C.CL_NAME,
			[DivisionCode] = BIA.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = BIA.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[SCType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN 'C'
							ELSE 'S' END,
			[FunctionType] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_TYPE
								  ELSE BIA.FNC_TYPE END,
			[FunctionOrder] = CAST(CASE WHEN @SortFunctionByType = 2 THEN CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_ORDER
																			   ELSE BIA.FNC_ORDER END 
										ELSE 0 END AS smallint),
			[OriginalFunctionCode] = BIA.FNC_CODE,
			[FunctionCode] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.CONSOL_FNC
								  ELSE BIA.FNC_CODE END,
			[FunctionDescription] =  CASE WHEN ISNULL(BCD.FNC_DESC_SOURCE, 1) = 0 THEN BCD.FNC_DESC
										  ELSE CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_DESCRIPTION
													ELSE BIA.FNC_DESCRIPTION END END,
			[FunctionHeading] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_DESC
									 ELSE BIA.FNC_HEADING_DESC END,
			[FunctionHeadingOrder] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN F.FNC_HEADING_SEQ
										  ELSE BIA.FNC_HEADING_SEQ END,
			[Quantity] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE <> 'E' THEN BIA.HRS_QTY ELSE NULL END
							  ELSE CASE WHEN BIA.FNC_TYPE <> 'E' THEN BIA.HRS_QTY ELSE NULL END END, 
			[Hours] = CASE WHEN @PrintFunctionType = 3 OR (@PrintFunctionType = 1 AND P.PRD_CONSOL_FUNC = 1) THEN CASE WHEN F.FNC_TYPE = 'E' THEN BIA.HRS_QTY ELSE NULL END
						   ELSE CASE WHEN BIA.FNC_TYPE = 'E' THEN BIA.HRS_QTY ELSE NULL END END, 
			[Rate] = BIA.RATE,
			[NetAmount] = dbo.advfn_invoice_printing_xchge_net_amt(BIA.EXT_AMT, BIA.EXT_MARKUP_AMT, @TotalsShowCommissionSeparately, 
												  BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE, 
												  @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CommissionAmount] = dbo.advfn_invoice_printing_xchge_commission_amt(BIA.EXT_MARKUP_AMT, @TotalsShowCommissionSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[NonResaleTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_NONRESALE_TAX, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),
			[CityTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_CITY_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[CountyTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_COUNTY_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount),  
			[StateTax] = dbo.advfn_invoice_printing_xchge_tax_amt(BIA.EXT_STATE_RESALE, @TotalsShowTaxSeparately, @ApplyExchangeRate, @ExchangeRateAmount), 
			[TotalTax] = (BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE),
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount),
			[DiscountAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount) - dbo.advfn_invoice_printing_xchge_disocunt_amt(BIA.LINE_TOTAL - (BIA.EXT_CITY_RESALE + BIA.EXT_COUNTY_RESALE + BIA.EXT_STATE_RESALE), BIA.FNC_CODE, C.CLIENT_DISCOUNT_CODE, JC.CLIENT_DISCOUNT_CODE, @ApplyExchangeRate, @ExchangeRateAmount),
			[BillingComment] = CASE WHEN ISNULL(CAST(BC.BILL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BC.BILL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingJobComment] = CASE WHEN ISNULL(CAST(BCJ.JOB_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCJ.JOB_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingDetailComment] = CASE WHEN ISNULL(CAST(BCD.DTL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BCD.DTL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[JobComment] = CASE WHEN ISNULL(CAST(JL.JOB_COMMENTS AS varchar(MAX)), '') <> '' THEN CAST(JL.JOB_COMMENTS AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalClientComment] = CASE WHEN ISNULL(CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BAC.BILL_APPROVAL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[BillingApprovalFunctionComment] = CASE WHEN ISNULL(CAST(BACF.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BACF.BILL_APPROVAL_FUNCTION_COMMENT AS varchar(MAX)) ELSE NULL END,
			[JobComponentComment] = CASE WHEN ISNULL(CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)), '') <> '' THEN CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)) ELSE NULL END,
			[EstimateComment] = CASE WHEN @IncludeEstimateComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_LOG_COMMENT_HTML, '') <> '' THEN ESTHC.EST_LOG_COMMENT_HTML 
																				ELSE CASE WHEN ISNULL(ESTHC.EST_LOG_COMMENT, '') <> '' THEN ESTHC.EST_LOG_COMMENT 
																						  ELSE NULL END END
									 ELSE NULL END,
			[EstimateComponentComment] = CASE WHEN @IncludeEstimateComponentComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_COMP_COMMENT_HTML, '') <> '' THEN ESTHC.EST_COMP_COMMENT_HTML 
																								  ELSE CASE WHEN ISNULL(ESTHC.EST_COMP_COMMENT, '') <> '' THEN ESTHC.EST_COMP_COMMENT 
																											ELSE NULL END END
											  ELSE NULL END,
			[EstimateQuoteComment] = CASE WHEN @IncludeEstimateQuoteComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_QTE_COMMENT_HTML, '') <> '' THEN ESTHC.EST_QTE_COMMENT_HTML 
																						  ELSE CASE WHEN ISNULL(ESTHC.EST_QTE_COMMENT, '') <> '' THEN ESTHC.EST_QTE_COMMENT 
																									ELSE NULL END END
										  ELSE NULL END,
			[EstimateRevisionComment] = CASE WHEN @IncludeEstimateRevisionComment = 1 THEN CASE WHEN ISNULL(ESTHC.EST_REV_COMMENT_HTML, '') <> '' THEN ESTHC.EST_REV_COMMENT_HTML 
																								ELSE CASE WHEN ISNULL(ESTHC.EST_REV_COMMENT, '') <> '' THEN ESTHC.EST_REV_COMMENT 
																										  ELSE NULL END END
											 ELSE NULL END,
			[EstimateFunctionComment] = CASE WHEN @IncludeEstimateFunctionComment = 1 THEN CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT_HTML, '') <> '' THEN @Font + ESTC.EST_FNC_COMMENT_HTML + @Font2 
																								ELSE CASE WHEN ISNULL(ESTC.EST_FNC_COMMENT, '') <> '' THEN @Font + ESTC.EST_FNC_COMMENT + @Font2 
																										  ELSE NULL END END
											 ELSE NULL END,
			[InvoiceDueDate] = ARIDD.AR_INV_DUE_DATE,
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
																   ELSE  dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
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
									 ELSE 'INVOICE' END,
			[InvoiceFooterComment] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment('Invoices', 'Standard Footer', BIA.OFFICE_CODE, BIA.CL_CODE, BIA.DIV_CODE, BIA.PRD_CODE), C.CL_FOOTER)
										  WHEN @InvoiceFooterCommentType = 3 THEN @InvoiceFooterComment 
										  ELSE '' END,
			[InvoiceFooterCommentFontSize] = CASE WHEN @InvoiceFooterCommentType = 2 THEN ISNULL(dbo.advfn_invoice_printing_comment_font_size('Invoices', 'Standard Footer', BIA.OFFICE_CODE, BIA.CL_CODE, BIA.DIV_CODE, BIA.PRD_CODE), 10)
												  ELSE 10 END,
			[InsideDescription] = @GroupingOptionInsideDescription,
			[OutsideDescription] = @GroupingOptionOutsideDescription,
			[CampaignID] =  JL.CMP_IDENTIFIER,
			[CampaignCode] =  CAMP.CMP_CODE,
			[CampaignName] =  CAMP.CMP_NAME,
			[Campaign] =  CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME,
			[CampaignComment] =  CAST(CAMP.CMP_COMMENTS AS varchar(MAX))
		FROM
			(SELECT
					--ARS.AR_SUMMARY_ID,
					ARS.AR_INV_NBR,
					ARS.AR_INV_SEQ,
					ARS.AR_TYPE,
					ARS.JOB_NUMBER,
					ARS.JOB_COMPONENT_NBR,
					ARS.CL_CODE,
					ARS.DIV_CODE,
					ARS.PRD_CODE,
					ARS.OFFICE_CODE,
					ARS.FNC_TYPE,
					ARS.FNC_CODE,
					F.FNC_DESCRIPTION,
					[FNC_ORDER] = CAST(ISNULL(F.FNC_ORDER, 0) AS smallint),
					FH.FNC_HEADING_DESC,
					FH.FNC_HEADING_SEQ,
					ARID.AR_INV_DATE,
					[HRS_QTY] = CAST(SUM(ISNULL(ARS.HRS_QTY, 0)) AS decimal(18,2)),
					[RATE] = CAST(0 AS decimal(18,2)),
					[EXT_AMT] = CAST(SUM(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) - ISNULL(ARS.COMMISSION_AMT, 0) - ISNULL(ARS.AB_COMMISSION_AMT, 0) 
														   ELSE ISNULL(ARS.TOTAL_BILL, 0) - ISNULL(ARS.STATE_TAX_AMT, 0) - ISNULL(ARS.CNTY_TAX_AMT, 0) - ISNULL(ARS.CITY_TAX_AMT, 0) END) AS decimal(18,2)),
					[EXT_MARKUP_AMT] = CAST(SUM(CASE ARS.FNC_TYPE WHEN 'V' THEN ISNULL(ARS.COMMISSION_AMT,0) + ISNULL(ARS.AB_COMMISSION_AMT,0)
																  ELSE 0 END) AS decimal(18,2)),
					--ARS.TAX_CODE,
					[EXT_NONRESALE_TAX] = CAST(SUM(ISNULL(ARS.NON_RESALE_AMT, 0)) AS decimal(18,2)),
					[EXT_STATE_RESALE] = CAST(SUM(ISNULL(ARS.STATE_TAX_AMT, 0)) AS decimal(18,2)),
					[EXT_COUNTY_RESALE] = CAST(SUM(ISNULL(ARS.CNTY_TAX_AMT, 0)) AS decimal(18,2)),
					[EXT_CITY_RESALE] = CAST(SUM(ISNULL(ARS.CITY_TAX_AMT, 0)) AS decimal(18,2)),
					[LINE_TOTAL] = CAST(SUM(ISNULL(ARS.TOTAL_BILL, 0)) AS decimal(18,2)),
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
						ARS.FNC_TYPE <> 'R'
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
						AR.CDP_CONTACT_ID) AS BIA INNER JOIN 
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
						[dbo].[FNC_HEADING] AS SFH ON SFH.FNC_HEADING_ID = SF.FNC_HEADING_ID) AS F ON F.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
				(SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = BIA.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = BIA.AR_INV_SEQ LEFT OUTER JOIN
				(SELECT 
						BILL_APPR_HDR.AR_INV_NBR,
						BILL_APPR_HDR.JOB_NUMBER,
						BILL_APPR_HDR.JOB_COMPONENT_NBR,
						[BILL_APPROVAL_COMMENT] = BILL_APPR_HDR.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR]
					WHERE 
						BILL_APPR_HDR.BA_ID = (SELECT MAX(BAC.BA_ID) FROM [dbo].[BILL_APPR_HDR] AS BAC WHERE BAC.JOB_NUMBER = BILL_APPR_HDR.JOB_NUMBER AND 
																											 BAC.JOB_COMPONENT_NBR = BILL_APPR_HDR.JOB_COMPONENT_NBR AND 
																											 BAC.AR_INV_NBR = BILL_APPR_HDR.AR_INV_NBR)) AS BAC ON BAC.AR_INV_NBR = BIA.AR_INV_NBR AND 
																																								   BAC.JOB_NUMBER = BIA.JOB_NUMBER AND 
																																								   BAC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
				(SELECT 
						BILL_APPR_HDR.AR_INV_NBR,
						BILL_APPR_HDR.JOB_NUMBER,
						BILL_APPR_HDR.JOB_COMPONENT_NBR,
						BILL_APPR_DTL.FNC_CODE,
						[BILL_APPROVAL_FUNCTION_COMMENT] = BILL_APPR_DTL.CLIENT_COMMENTS
					FROM 
						[dbo].[BILL_APPR_HDR] INNER JOIN
						[dbo].[BILL_APPR_DTL] ON BILL_APPR_DTL.BA_ID = BILL_APPR_HDR.BA_ID AND
												 BILL_APPR_DTL.JOB_NUMBER = BILL_APPR_HDR.JOB_NUMBER AND
												 BILL_APPR_DTL.JOB_COMPONENT_NBR = BILL_APPR_HDR.JOB_COMPONENT_NBR
					WHERE 
						BILL_APPR_HDR.BA_ID = (SELECT MAX(BAC.BA_ID) FROM [dbo].[BILL_APPR_HDR] AS BAC WHERE BAC.JOB_NUMBER = BILL_APPR_HDR.JOB_NUMBER AND 
																											 BAC.JOB_COMPONENT_NBR = BILL_APPR_HDR.JOB_COMPONENT_NBR AND 
																											 BAC.AR_INV_NBR = BILL_APPR_HDR.AR_INV_NBR)) AS BACF ON BACF.AR_INV_NBR = BIA.AR_INV_NBR AND 
																																								    BACF.JOB_NUMBER = BIA.JOB_NUMBER AND 
																																								    BACF.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR AND 
																																								    BACF.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
				(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						EST_LOG_COMMENT = CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						EST_LOG_COMMENT_HTML = CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						EST_COMP_COMMENT = CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						EST_COMP_COMMENT_HTML = CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						EST_QTE_COMMENT = CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)),  
						EST_QTE_COMMENT_HTML = CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)),
						EST_REV_COMMENT = CAST(ER.EST_REV_COMMENT AS varchar(MAX)),  
						EST_REV_COMMENT_HTML = CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))
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
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						CAST(EL.EST_LOG_COMMENT AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT AS varchar(MAX)),
						CAST(EL.EST_LOG_COMMENT_HTML AS varchar(MAX)), 
						CAST(EC.EST_COMP_COMMENT_HTML AS varchar(MAX)), 
						CAST(EQ.EST_QTE_COMMENT_HTML AS varchar(MAX)), 
						CAST(ER.EST_REV_COMMENT_HTML AS varchar(MAX))) AS ESTHC ON ESTHC.JOB_NUMBER = BIA.JOB_NUMBER AND
																				   ESTHC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN
				(SELECT 
						JC.JOB_NUMBER,
						JC.JOB_COMPONENT_NBR,
						ERD.FNC_CODE,
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
						ERD.EST_REV_NBR,
						ERD.EST_QUOTE_NBR,
						ERD.EST_COMPONENT_NBR,
						ERD.ESTIMATE_NUMBER,
						ERD.FNC_CODE) AS ESTC ON ESTC.JOB_NUMBER = BIA.JOB_NUMBER AND
												 ESTC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR AND
												 ESTC.FNC_CODE = BIA.FNC_CODE LEFT OUTER JOIN
				(SELECT	
						AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
						AR.AR_TYPE, 
						AR_INV_DUE_DATE = CASE WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE
											   WHEN AR.DUE_DATE IS NULL AND AR.REC_TYPE IN ('P', 'S') THEN DATEADD(DAY, ISNULL(C.CL_P_PAYDAYS, 0), AR.AR_INV_DATE)
											   ELSE DATEADD(DAY, ISNULL(C.CL_M_PAYDAYS, 0), AR.AR_INV_DATE) END
					FROM 
						[dbo].[ACCT_REC] AS AR INNER JOIN 
						[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE) AS ARIDD ON ARIDD.AR_INV_NBR = BIA.AR_INV_NBR AND 
																				   ARIDD.AR_INV_SEQ = BIA.AR_INV_SEQ AND 
																				   ARIDD.AR_TYPE = BIA.AR_TYPE INNER JOIN
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