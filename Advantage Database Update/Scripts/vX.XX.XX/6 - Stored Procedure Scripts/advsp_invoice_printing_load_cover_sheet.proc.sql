CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_cover_sheet]
	@UserCode AS varchar(100),
	@InvoiceNumbers AS varchar(MAX),
	@IsDraft AS bit,
	@Batches AS varchar(MAX)
AS
BEGIN
			
	IF @IsDraft = 1 BEGIN
			
		SELECT 
			[InvoiceNumber] = ARS.[InvoiceNumber],
			[InvoiceSequenceNumber] = ARS.[InvoiceSequenceNumber], 
			[InvoiceDate] = ARS.[InvoiceDate],
			[InvoiceType] = ARS.[InvoiceType],
			[FullInvoiceNumber] = ARS.[FullInvoiceNumber],
			[InvoiceAmount] = ARS.[InvoiceAmount], 
			[InvoiceDescription] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
										WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
										WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
										WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN 'Newspaper'
										WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN 'Magazine'
										WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN 'Internet'
										WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN 'Outdoor'
										WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN 'Radio'
										WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN 'TV' END,		
			[InvoiceClassification] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN 'Production'
										   WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN 'Production'
										   WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN 'Production'
										   ELSE 'Media' END,
			[RecordType] = ARS.[RecordType],
			[RecordTypeDescription] = ARS.[RecordTypeDescription],
			[ClientCode] = ARS.[ClientCode],
			[DivisionCode] = ARS.[DivisionCode],
			[ProductCode] = ARS.[ProductCode], 
			[Address] = CASE WHEN C.CL_INV_BY = 6 OR (ARS.[DivisionCode] IS NULL AND ARS.[ProductCode] IS NULL) THEN dbo.advfn_invoice_printing_address(1, 0, 1, 1, 1, 0,  
																						  C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																						  C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																						  C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																						  D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																						  D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																						  D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																						  P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																						  P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																						  P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																						  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) 
							WHEN C.CL_INV_BY = 7 OR (ARS.[ProductCode] IS NULL) THEN dbo.advfn_invoice_printing_address(2, 0, 1, 1, 1, 0,  
																						 C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																						 C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																						 C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																						 D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																						 D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																						 D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																						 P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																						 P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																						 P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																						 NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) 
							ELSE dbo.advfn_invoice_printing_address(3, 0, 1, 1, 1, 0,  
																	C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																	C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																	C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																	D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																	D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																	D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																	P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																	P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																	P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																	NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) END,
			[LocationCode] = CL.[LocationCode],
			[PageHeaderComment] = CASE WHEN L.PRT_HDR = 1 THEN L.LOC_HDR ELSE '' END,
			[PageFooterComment] = CASE WHEN L.PRT_FTR = 1 THEN L.LOC_FTR ELSE '' END,
			[PageHeaderLogoPath] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH ELSE '' END,
			[PageHeaderLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH_LAND ELSE '' END,
			[PageFooterLogoPath] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_2 ELSE '' END,
			[PageFooterLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_LAND_2 ELSE '' END,
			[JobNumber] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Newspaper', 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Magazine', 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Internet', 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Outdoor', 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Radio', 1)
							   WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'TV', 1) END,
			[JobDescription] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Newspaper', 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Magazine', 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Internet', 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Outdoor', 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Radio', 1)
									WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'TV', 1) END,
			[ClientPO] = [dbo].[advfn_invoice_printing_load_coversheet_clientpo](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ISNULL(ARS.[RecordType], ''), 1),
			[FooterComment] = [dbo].[advfn_invoice_printing_coversheet_comment]('Invoices Coversheet', 'Standard Footer', ARS.[OfficeCode], ARS.[ClientCode], ARS.[DivisionCode], ARS.[ProductCode]),
			[ShowPageHeaderLogo] = CAST(CASE WHEN L.LOGO_LOCATION = 'C' THEN 1 ELSE 0 END AS bit),
			[ShowPageFooterLogo] = CAST(CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN 1 ELSE 0 END AS bit)
		FROM 
			(SELECT 
					[InvoiceNumber] = ARF.AR_INV_NBR,
					[InvoiceSequenceNumber] = ARF.DRAFT_INV_SEQ, 
					[InvoiceDate] = GETDATE(),
					[InvoiceType] = 'IN',  
					[FullInvoiceNumber] = RIGHT('000000' + CAST(ARF.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(ARF.DRAFT_INV_SEQ AS varchar(4)), 4),
					[InvoiceAmount] = SUM(ISNULL(ARF.TOTAL_BILL, 0)), 
					[RecordType] = ARF.MEDIA_TYPE,
					[RecordTypeDescription] = CASE WHEN ISNULL(ARF.MEDIA_TYPE, '') = '' THEN 'Production'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'P' THEN 'Production'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'S' THEN 'Production'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'N' THEN 'Newspaper'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'M' THEN 'Magazine'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'I' THEN 'Internet'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'O' THEN 'Outdoor'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'R' THEN 'Radio'
												   WHEN ISNULL(ARF.MEDIA_TYPE, '') = 'T' THEN 'TV' END,
					[ClientCode] = ARF.CL_CODE,
					[DivisionCode] = ARF.DIV_CODE,
					[ProductCode] = ARF.PRD_CODE,
					[OfficeCode] = ARF.OFFICE_CODE
				FROM
					[dbo].[AR_FUNCTION] AS ARF
				WHERE 
					ARF.BILLING_USER IN (SELECT INBRS.vstr FROM dbo.fn_charlist_to_table2(@Batches) AS INBRS) AND
					ARF.AR_INV_NBR IN (SELECT INBRS.number FROM dbo.fn_intlist_to_table(@InvoiceNumbers) AS INBRS)
				GROUP BY 
					ARF.AR_INV_NBR,
					ARF.DRAFT_INV_SEQ, 
					ARF.MEDIA_TYPE,
					ARF.CL_CODE, 
					ARF.DIV_CODE, 
					ARF.PRD_CODE, 
					ARF.OFFICE_CODE) AS ARS INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.[ClientCode] LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.[ClientCode] AND
									 D.DIV_CODE = ARS.[DivisionCode]  LEFT OUTER JOIN 
			[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.ClientCode AND 
									P.DIV_CODE = ARS.DivisionCode AND 
									P.PRD_CODE = ARS.ProductCode INNER JOIN
			(SELECT 
					[ClientCode] = C.CL_CODE,
					[LocationCode] = CASE WHEN ISNULL(C.INVOICE_LOCATION_ID, '') <> '' THEN C.INVOICE_LOCATION_ID
											WHEN ISNULL(CD.PRT_LOC_PG_FTR_DEF, '') <> '' THEN CD.PRT_LOC_PG_FTR_DEF
											WHEN ISNULL(AD.PRT_LOC_PG_FTR_DEF, '') <> '' THEN AD.PRT_LOC_PG_FTR_DEF
											WHEN ISNULL(OT.PRT_LOC_PG_FTR_DEF, '') <> '' THEN OT.PRT_LOC_PG_FTR_DEF END
				FROM 
					[dbo].[CLIENT] AS C LEFT OUTER JOIN 
					[dbo].[PROD_INV_DEF] AS CD ON CD.CL_CODE = C.CL_CODE CROSS JOIN 
					[dbo].[PROD_INV_DEF] AS AD CROSS JOIN 
					[dbo].[PROD_INV_DEF] AS OT
				WHERE 
					AD.CLIENT_OR_DEF = 1 AND 
					OT.CLIENT_OR_DEF = 0) AS CL ON CL.ClientCode = C.CL_CODE LEFT OUTER JOIN 
			[dbo].[advtf_location_query]() AS L ON L.LOC_ID = CL.[LocationCode]
		ORDER BY 1 DESC

	END ELSE BEGIN
		
		SELECT 
			[InvoiceNumber] = ARS.[InvoiceNumber],
			[InvoiceSequenceNumber] = ARS.[InvoiceSequenceNumber], 
			[InvoiceDate] = ARS.[InvoiceDate],
			[InvoiceType] = ARS.[InvoiceType],
			[FullInvoiceNumber] = ARS.[FullInvoiceNumber],
			[InvoiceAmount] = ARS.[InvoiceAmount], 
			[InvoiceDescription] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
										WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
										WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_job_descriptions](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
										WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN 'Newspaper'
										WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN 'Magazine'
										WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN 'Internet'
										WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN 'Outdoor'
										WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN 'Radio'
										WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN 'TV' END,		
			[InvoiceClassification] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN 'Production'
										   WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN 'Production'
										   WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN 'Production'
										   ELSE 'Media' END,
			[RecordType] = ARS.[RecordType],
			[RecordTypeDescription] = ARS.[RecordTypeDescription],
			[ClientCode] = ARS.[ClientCode],
			[DivisionCode] = ARS.[DivisionCode],
			[ProductCode] = ARS.[ProductCode], 
			[Address] = CASE WHEN C.CL_INV_BY = 6 OR (ARS.[DivisionCode] IS NULL AND ARS.[ProductCode] IS NULL) THEN dbo.advfn_invoice_printing_address(1, 0, 1, 1, 1, 0,  
																						  C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																						  C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																						  C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																						  D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																						  D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																						  D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																						  P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																						  P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																						  P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																						  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) 
							WHEN C.CL_INV_BY = 7 OR (ARS.[ProductCode] IS NULL) THEN dbo.advfn_invoice_printing_address(2, 0, 1, 1, 1, 0,  
																						 C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																						 C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																						 C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																						 D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																						 D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																						 D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																						 P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																						 P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																						 P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																						 NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) 
							ELSE dbo.advfn_invoice_printing_address(3, 0, 1, 1, 1, 0,  
																	C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																	C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																	C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																	D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																	D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																	D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																	P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																	P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																	P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																	NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL) END,
			[LocationCode] = CL.[LocationCode],
			[PageHeaderComment] = CASE WHEN L.PRT_HDR = 1 THEN L.LOC_HDR ELSE '' END,
			[PageFooterComment] = CASE WHEN L.PRT_FTR = 1 THEN L.LOC_FTR ELSE '' END,
			[PageHeaderLogoPath] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH ELSE '' END,
			[PageHeaderLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH_LAND ELSE '' END,
			[PageFooterLogoPath] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_2 ELSE '' END,
			[PageFooterLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_LAND_2 ELSE '' END,
			[JobNumber] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Newspaper', 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Magazine', 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Internet', 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Outdoor', 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Radio', 0)
							   WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_number](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'TV', 0) END,
			[JobDescription] = CASE WHEN ISNULL(ARS.[RecordType], '') = '' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'P' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'S' THEN [dbo].[advfn_invoice_printing_load_coversheet_job_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'N' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Newspaper', 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'M' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Magazine', 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'I' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Internet', 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'O' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Outdoor', 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'R' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'Radio', 0)
									WHEN ISNULL(ARS.[RecordType], '') = 'T' THEN [dbo].[advfn_invoice_printing_load_coversheet_order_description](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ARS.[RecordType], 'TV', 0) END,
			[ClientPO] = [dbo].[advfn_invoice_printing_load_coversheet_clientpo](ARS.[InvoiceNumber], ARS.[InvoiceSequenceNumber], ISNULL(ARS.[RecordType], ''), 0),
			[FooterComment] = [dbo].[advfn_invoice_printing_coversheet_comment]('Invoices Coversheet', 'Standard Footer', ARS.[OfficeCode], ARS.[ClientCode], ARS.[DivisionCode], ARS.[ProductCode]),
			[ShowPageHeaderLogo] = CAST(CASE WHEN L.LOGO_LOCATION = 'C' THEN 1 ELSE 0 END AS bit),
			[ShowPageFooterLogo] = CAST(CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN 1 ELSE 0 END AS bit)
		FROM 
			(SELECT 
					[InvoiceNumber] = ARS.AR_INV_NBR,
					[InvoiceSequenceNumber] = ARS.AR_INV_SEQ, 
					[InvoiceDate] = ARID.AR_INV_DATE,
					[InvoiceType] = ARS.AR_TYPE,  
					[FullInvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
					[InvoiceAmount] = SUM(ISNULL(ARS.TOTAL_BILL, 0)), 
					[RecordType] = ARS.MEDIA_TYPE,
					[RecordTypeDescription] = CASE WHEN ISNULL(ARS.MEDIA_TYPE, '') = '' THEN 'Production'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'P' THEN 'Production'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'S' THEN 'Production'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'N' THEN 'Newspaper'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'M' THEN 'Magazine'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'I' THEN 'Internet'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'O' THEN 'Outdoor'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'R' THEN 'Radio'
												   WHEN ISNULL(ARS.MEDIA_TYPE, '') = 'T' THEN 'TV' END,
					[ClientCode] = AR.CL_CODE,
					[DivisionCode] = AR.DIV_CODE,
					[ProductCode] = AR.PRD_CODE,
					[OfficeCode] = AR.OFFICE_CODE
				FROM
					[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
					(SELECT 
							AR.AR_INV_NBR, 
							AR.AR_TYPE, 
							[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
						FROM 
							[dbo].[ACCT_REC] AS AR
						WHERE
							AR.AR_INV_NBR IN (SELECT INBRS.number FROM dbo.fn_intlist_to_table(@InvoiceNumbers) AS INBRS) AND
							AR.AR_TYPE <> 'VO'
						GROUP BY 
							AR.AR_INV_NBR, 
							AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
													ARID.AR_TYPE = ARS.AR_TYPE INNER JOIN 
					[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
												AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND
												AR.AR_TYPE = ARS.AR_TYPE LEFT OUTER JOIN 
					(SELECT DISTINCT AR_INV_NBR FROM [dbo].[AR_SUMMARY] WHERE AR_TYPE = 'VO') AS ARSVO ON ARSVO.AR_INV_NBR = ARS.AR_INV_NBR
				WHERE 
					(AR.MANUAL_INV IS NULL OR 
						AR.MANUAL_INV = 0) AND
					ARSVO.AR_INV_NBR IS NULL AND
					NOT EXISTS (SELECT * 
								FROM [dbo].[BILLING] AS B 
								WHERE B.BILLING_USER NOT LIKE @UserCode + '%'  AND ARS.AR_INV_NBR >= B.FIRST_INV AND ARS.AR_INV_NBR <= B.LAST_INV)
				GROUP BY 
					ARS.AR_INV_NBR,
					ARS.AR_INV_SEQ,
					ARS.AR_TYPE, 
					ARID.AR_INV_DATE, 
					ARS.MEDIA_TYPE,
					AR.CL_CODE,
					AR.DIV_CODE,
					AR.PRD_CODE,
					AR.OFFICE_CODE) AS ARS INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = ARS.[ClientCode] LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = ARS.[ClientCode] AND
									 D.DIV_CODE = ARS.[DivisionCode]  LEFT OUTER JOIN 
			[dbo].[PRODUCT] AS P ON P.CL_CODE = ARS.ClientCode AND 
									P.DIV_CODE = ARS.DivisionCode AND 
									P.PRD_CODE = ARS.ProductCode INNER JOIN
			(SELECT 
					[ClientCode] = C.CL_CODE,
					[LocationCode] = CASE WHEN ISNULL(C.INVOICE_LOCATION_ID, '') <> '' THEN C.INVOICE_LOCATION_ID
											WHEN ISNULL(CD.PRT_LOC_PG_FTR_DEF, '') <> '' THEN CD.PRT_LOC_PG_FTR_DEF
											WHEN ISNULL(AD.PRT_LOC_PG_FTR_DEF, '') <> '' THEN AD.PRT_LOC_PG_FTR_DEF
											WHEN ISNULL(OT.PRT_LOC_PG_FTR_DEF, '') <> '' THEN OT.PRT_LOC_PG_FTR_DEF END
				FROM 
					[dbo].[CLIENT] AS C LEFT OUTER JOIN 
					[dbo].[PROD_INV_DEF] AS CD ON CD.CL_CODE = C.CL_CODE CROSS JOIN 
					[dbo].[PROD_INV_DEF] AS AD CROSS JOIN 
					[dbo].[PROD_INV_DEF] AS OT
				WHERE 
					AD.CLIENT_OR_DEF = 1 AND 
					OT.CLIENT_OR_DEF = 0) AS CL ON CL.ClientCode = C.CL_CODE LEFT OUTER JOIN 
			[dbo].[advtf_location_query]() AS L ON L.LOC_ID = CL.[LocationCode]
		ORDER BY 1 DESC

	END

END









GO