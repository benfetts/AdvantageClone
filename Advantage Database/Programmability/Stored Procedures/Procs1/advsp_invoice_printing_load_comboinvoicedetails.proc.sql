CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_comboinvoicedetails]
	@UserCode AS varchar(100),
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@AddressBlockType AS smallint,
	@PrintClientName AS bit,
	@PrintDivisionName AS bit,
	@PrintProductDescription AS bit,
	@PrintContactAfterAddress AS bit,
	@ApplyExchangeRate AS smallint,
	@ExchangeRateAmount AS decimal(10, 6),
	@UseInvoiceCategoryDescription AS bit,
	@InvoiceTitle AS varchar(MAX),
	@InvoiceFooterCommentType AS smallint,
	@InvoiceFooterComment AS varchar(MAX),
	@ShowCodes AS bit,
	@ContactType AS int,
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
			[MediaType] =  ISNULL(BIA.MEDIA_TYPE, 'P'),
			[ClientCode] = BIA.CL_CODE,
			[DivisionCode] = BIA.DIV_CODE,
			[ProductCode] = BIA.PRD_CODE,
			[BillingComment] = NULL,
			[InvoiceDueDate] = NULL,
			[ClientPO] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JC.JOB_CL_PO_NBR
							  ELSE BIA.CLIENT_PO END,
			[SalesClassCode] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JL.SC_CODE
									ELSE BIA.SC_CODE END,
			[SalesClassDescription] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN SC.SC_DESCRIPTION
										   ELSE BIA.SC_DESCRIPTION END,
			[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN C.CL_ATTENTION ELSE C.CL_MATTENTION END,
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
																											C.CL_CODE, C.CL_NAME, CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN C.CL_ATTENTION ELSE C.CL_MATTENTION END,
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
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount),
			[ClientReference] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JL.JOB_CLI_REF
									 ELSE OI.CLIENT_REF END,
			[AccountExecutive] = CASE WHEN (BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S')) AND EMP.EMP_CODE IS NOT NULL THEN CASE WHEN EMP.EMP_MI IS NULL THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE(EMP.EMP_LNAME, '')
																																		   ELSE COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') END 
									  ELSE NULL END,
			[Campaign] =  CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN CASE WHEN CAMP.CMP_CODE IS NOT NULL THEN CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME ELSE NULL END
							   ELSE CASE WHEN OCAMP.CMP_CODE IS NOT NULL THEN OCAMP.CMP_CODE + ' - ' + OCAMP.CMP_NAME ELSE NULL END END
		FROM
			(SELECT
					ARF.AR_FUNCTION_ID,
					ARF.JOB_NUMBER,
					ARF.JOB_COMPONENT_NBR,
					ARF.ORDER_NBR, 
					ARF.ORDER_LINE_NBR,
					ARF.CL_CODE,
					ARF.DIV_CODE,
					ARF.PRD_CODE,
					ARF.OFFICE_CODE,
					ARF.AR_INV_NBR,
					[AR_INV_SEQ] = ARF.DRAFT_INV_SEQ,
					[AR_TYPE] = 'IN',
					[AR_INV_DATE] = GETDATE(),
					[INV_CAT] = NULL,
					[INV_CAT_DESC] = NULL,
					[CDP_CONTACT_ID] = NULL,
					[SC_CODE] = ARF.SC_CODE,
					[SC_DESCRIPTION] = SC.SC_DESCRIPTION,
					[CLIENT_PO] = ARF.CLIENT_PO,
					ARF.MEDIA_TYPE,
					[LINE_TOTAL] = CAST(ISNULL(ARF.TOTAL_BILL, 0) AS decimal(18,2))
				FROM 
					[dbo].[AR_FUNCTION] AS ARF LEFT OUTER JOIN
					[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARF.SC_CODE
				WHERE 
					ARF.DRAFT_INV_SEQ <> 99 AND
					ARF.AR_INV_NBR = @InvoiceNumber AND
					ARF.DRAFT_INV_SEQ = @SequenceNumber AND 
					ARF.BILLING_USER = @Batch AND
					(ARF.FNC_TYPE IS NULL OR ARF.FNC_TYPE <> 'R')) AS BIA LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = BIA.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = BIA.JOB_NUMBER AND
											JC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			[dbo].[CLIENT] AS C ON C.CL_CODE = BIA.CL_CODE LEFT OUTER JOIN 
			[dbo].[DIVISION] AS D ON D.CL_CODE = BIA.CL_CODE AND
										D.DIV_CODE = BIA.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = BIA.CL_CODE AND 
									P.DIV_CODE = BIA.DIV_CODE AND 
									P.PRD_CODE = BIA.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = BIA.CDP_CONTACT_ID LEFT OUTER JOIN
			(SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.MAGAZINE_HEADER UNION ALL
				SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.NEWSPAPER_HEADER UNION ALL
				SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.INTERNET_HEADER UNION ALL
				SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.OUTDOOR_HEADER UNION ALL
				SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.RADIO_HDR UNION ALL 
				SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.TV_HDR) AS OI ON OI.ORDER_NBR = BIA.ORDER_NBR LEFT OUTER JOIN
			[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN
			[dbo].[CAMPAIGN] AS OCAMP ON OCAMP.CMP_IDENTIFIER = OI.CMP_IDENTIFIER
		ORDER BY
			BIA.CL_CODE,
			BIA.AR_INV_NBR, 
			BIA.AR_INV_SEQ DESC, 
			BIA.AR_TYPE, 
			BIA.MEDIA_TYPE
	
	END ELSE BEGIN

		SELECT 	
			[InvoiceNumber] = BIA.AR_INV_NBR, 
			[InvoiceSequenceNumber] = BIA.AR_INV_SEQ,
			[InvoiceDate] = BIA.AR_INV_DATE,
			[InvoiceType] = BIA.AR_TYPE,
			[FullInvoiceNumber] = RIGHT('000000' + CAST(BIA.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(BIA.AR_INV_SEQ AS varchar(4)), 4),
			[MediaType] =  ISNULL(BIA.MEDIA_TYPE, 'P'),
			[ClientCode] = BIA.CL_CODE,
			[DivisionCode] = BIA.DIV_CODE,
			[ProductCode] = BIA.PRD_CODE,
			[BillingComment] = CASE WHEN ISNULL(CAST(BC.BILL_COMMENT AS varchar(MAX)), '') <> '' THEN CAST(BC.BILL_COMMENT AS varchar(MAX)) ELSE NULL END,
			[InvoiceDueDate] = ARIDD.AR_INV_DUE_DATE,
			[ClientPO] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JC.JOB_CL_PO_NBR
							  ELSE BIA.CLIENT_PO END,
			[SalesClassCode] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JL.SC_CODE
									ELSE BIA.SC_CODE END,
			[SalesClassDescription] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN SC.SC_DESCRIPTION
											ELSE BIA.SC_DESCRIPTION END,
			[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																											C.CL_CODE, C.CL_NAME, CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN C.CL_ATTENTION ELSE C.CL_MATTENTION END,
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
																											C.CL_CODE, C.CL_NAME, CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN C.CL_ATTENTION ELSE C.CL_MATTENTION END,
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
			[TotalAmount] = dbo.advfn_invoice_printing_xchge_total_amt(BIA.LINE_TOTAL, @ApplyExchangeRate, @ExchangeRateAmount),
			[ClientReference] = CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN JL.JOB_CLI_REF
									 ELSE OI.CLIENT_REF END,
			[AccountExecutive] = CASE WHEN (BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S')) AND EMP.EMP_CODE IS NOT NULL THEN CASE WHEN EMP.EMP_MI IS NULL THEN COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE(EMP.EMP_LNAME, '')
																																		   ELSE COALESCE((RTRIM(EMP.EMP_FNAME) + ' '), '') + COALESCE((EMP.EMP_MI + '. '), '') + COALESCE(EMP.EMP_LNAME, '') END 
									  ELSE NULL END,
			[Campaign] =  CASE WHEN BIA.MEDIA_TYPE IS NULL OR BIA.MEDIA_TYPE IN ('P', 'S') THEN CASE WHEN CAMP.CMP_CODE IS NOT NULL THEN CAMP.CMP_CODE + ' - ' + CAMP.CMP_NAME ELSE NULL END
							   ELSE CASE WHEN OCAMP.CMP_CODE IS NOT NULL THEN OCAMP.CMP_CODE + ' - ' + OCAMP.CMP_NAME ELSE NULL END END
		FROM
			(SELECT
					ARS.AR_SUMMARY_ID,
					ARS.JOB_NUMBER,
					ARS.JOB_COMPONENT_NBR,
					ARS.ORDER_NBR, 
					ARS.ORDER_LINE_NBR,
					ARS.CL_CODE,
					ARS.DIV_CODE,
					ARS.PRD_CODE,
					ARS.OFFICE_CODE,
					ARS.AR_INV_NBR,
					ARS.AR_INV_SEQ,
					ARS.AR_TYPE,
					ARID.AR_INV_DATE,
					AR.INV_CAT,
					IC.INV_CAT_DESC,
					AR.CDP_CONTACT_ID,
					[SC_CODE] = ARS.SC_CODE,
					[SC_DESCRIPTION] = SC.SC_DESCRIPTION,
					[CLIENT_PO] = ARS.CLIENT_PO,
					ARS.MEDIA_TYPE,
					[LINE_TOTAL] = CAST(ISNULL(ARS.TOTAL_BILL, 0) AS decimal(18,2))
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
					[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
												AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
												AR.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN 
					[dbo].[INVOICE_CATEGORY] AS IC ON IC.INV_CAT = AR.INV_CAT LEFT OUTER JOIN
					[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = ARS.SC_CODE
				WHERE 
					ARS.AR_INV_NBR = @InvoiceNumber AND
					ARS.AR_INV_SEQ = @SequenceNumber AND
					(ARS.FNC_TYPE IS NULL OR ARS.FNC_TYPE <> 'R')) AS BIA LEFT OUTER JOIN 
				[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = BIA.JOB_NUMBER LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = BIA.JOB_NUMBER AND
											   JC.JOB_COMPONENT_NBR = BIA.JOB_COMPONENT_NBR LEFT OUTER JOIN 
				[dbo].[CLIENT] AS C ON C.CL_CODE = BIA.CL_CODE LEFT OUTER JOIN 
				[dbo].[DIVISION] AS D ON D.CL_CODE = BIA.CL_CODE AND
											D.DIV_CODE = BIA.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = BIA.CL_CODE AND 
										P.DIV_CODE = BIA.DIV_CODE AND 
										P.PRD_CODE = BIA.PRD_CODE LEFT OUTER JOIN
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
																				   ARIDD.AR_TYPE = BIA.AR_TYPE LEFT OUTER JOIN
				[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = JL.SC_CODE LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN 
				[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = BIA.CDP_CONTACT_ID LEFT OUTER JOIN
				(SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.MAGAZINE_HEADER UNION ALL
				 SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.NEWSPAPER_HEADER UNION ALL
				 SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.INTERNET_HEADER UNION ALL
				 SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.OUTDOOR_HEADER UNION ALL
				 SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.RADIO_HDR UNION ALL 
				 SELECT ORDER_NBR, CLIENT_REF, CMP_IDENTIFIER FROM dbo.TV_HDR) AS OI ON OI.ORDER_NBR = BIA.ORDER_NBR LEFT OUTER JOIN
				[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER LEFT OUTER JOIN
				[dbo].[CAMPAIGN] AS OCAMP ON OCAMP.CMP_IDENTIFIER = OI.CMP_IDENTIFIER
		ORDER BY
			BIA.CL_CODE,
			BIA.AR_INV_NBR, 
			BIA.AR_INV_SEQ DESC, 
			BIA.AR_TYPE
	
	END

END



























GO