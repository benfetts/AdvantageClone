if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dataset_AR_Aging_YayPay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dataset_AR_Aging_YayPay]
GO


CREATE PROCEDURE [dbo].[usp_wv_Dataset_AR_Aging_YayPay] 
	@UserID varchar(100),
	@PeriodCutoff varchar(6),
	@AgingDate smalldatetime,
	@AgingOption smallint,
	@IncludeDetails bit = 0,
	@RecordSource Int
AS
			
	CREATE TABLE #AR_AGING
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[ARGLAccount] varchar(30),
		[GLOffice] varchar(30),
		[AROffice] varchar(30),
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40),
		[ClientStatementAddress1] varchar(40),
		[ClientStatementAddress2] varchar(40),
		[ClientStatementCityStateZip] varchar(60),
		[ClientStatementCountry] varchar(20),
		[ClientBillingAddress1] varchar(40),
		[ClientBillingAddress2] varchar(40),
		[ClientBillingCityStateZip] varchar(60),
		[ClientBillingCountry] varchar(20),
		[ClientBillingAttention] varchar(40),
		[ClientARComment] varchar(MAX),
		[ClientDaysToPayProduction] smallint,
		[ClientDaysToPayMedia] smallint,
		[DaysToPayActual] integer,
		[DaysToPayActualProd] integer,
		[DaysToPayActualMedia] integer,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40),
		[DivisionStatementAddress1] varchar(40),
		[DivisionStatementAddress2] varchar(40),
		[DivisionStatementCityStateZip] varchar(60),
		[DivisionStatementCountry] varchar(20),
		[DivisionBillingAddress1] varchar(40),
		[DivisionBillingAddress2] varchar(40),
		[DivisionBillingCityStateZip] varchar(60),
		[DivisionBillingCountry] varchar(20),
		[DivisionBillingAttention] varchar(40),
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	    [ProductDescription] varchar(40),
		[ProductStatementAddress1] varchar(40),
		[ProductStatementAddress2] varchar(40),
		[ProductStatementCityStateZip] varchar(60),
		[ProductStatementCountry] varchar(20),
		[ProductBillingAddress1] varchar(40),
		[ProductBillingAddress2] varchar(40),
		[ProductBillingCityStateZip] varchar(60),
		[ProductBillingCountry] varchar(20),
		[ProductBillingAttention] varchar(40),
		[AccountExecutiveCode] varchar(6),
		[AccountExecutive] varchar(100),
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50),
		[InvoiceNumber] int, --varchar(20),
		[InvoiceSequence] varchar(2),
		[InvoicePostingPeriod] varchar(60),
		[InvoiceDate] smalldatetime,
		[InvoiceDueDate] smalldatetime,
		[InvoiceDescription] varchar(40),
		[InvoiceRecordType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[InvoiceCategory] varchar(20),
		[InvoiceComments] varchar(MAX),
		[ARCollectionNotes] varchar(MAX),
		[TotalInvoiceAmount] decimal(15, 2),
		[CashReceipts] decimal(15, 2),
		[CRAdjustments] decimal(15, 2),
		[TotalReceiptsAndAdjustments] decimal(15, 2),
		[InvoiceBalance] decimal(15, 2),
		[Days] int,
		[Current] decimal(15, 2),
		[Aging30Days] decimal(15, 2),
		[Aging60Days] decimal(15, 2),
		[Aging90Days] decimal(15, 2),
		[Aging120PlusDays] decimal(15, 2),
		[OnAccountBalance] decimal(15, 2),
		[InvoiceBalanceWithOA] decimal(15, 2),
		[JobOrderNumberListing] varchar(MAX),
		[CRCheckNumberListing] varchar(MAX),
		[JobNumber] int,
		[JobDescription] varchar(60),
		[ClientReference] varchar(30),
		[ClientPOProduction] varchar(40),
		[JobType] varchar(10),
		[JobContact] varchar(70),
		[OrderNumber] int,
		[OrderDescription] varchar(40),
		[ClientPOMedia] varchar(25),
		[MediaDates] varchar(50),
		[InvoiceTypeDescription] varchar(30),
		[PartialPaymentIndicator] varchar(1),
		[VendorCode] varchar(6),
		[VendorName] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6),
		[CampaignName] varchar(128),
		[CampaignComment] varchar(MAX),
		[MappedAccount] varchar(100),
		[TargetAccount] varchar(100), 
		[ARGLXact] int,
		[ARGLSequenceNumber] smallint,
		[PostedToSummary] smalldatetime
    );
	CREATE TABLE #AR_AGING_TOTAL --MASTER TABLE TO RETURN
    (
	    [ID] [int] IDENTITY(1,1) NOT NULL,
		[ARGLAccount] varchar(30), 
		[MappedAccount] varchar(100),  
		[TargetAccount] varchar(100), 
		[GLOffice] varchar(30),
		[AROffice] varchar(30),
		[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[ClientDescription] varchar(40),
		[ClientStatementAddress1] varchar(40),
		[ClientStatementAddress2] varchar(40),
		[ClientStatementCityStateZip] varchar(60),
		[ClientStatementCountry] varchar(20),
		[ClientBillingAddress1] varchar(40),
		[ClientBillingAddress2] varchar(40),
		[ClientBillingCityStateZip] varchar(60),
		[ClientBillingCountry] varchar(20),
		[ClientBillingAttention] varchar(40),
		[ClientARComment] varchar(MAX),
		[ClientDaysToPayProduction] smallint,
		[ClientDaysToPayMedia] smallint,
		[DaysToPayActual] integer,
		[DaysToPayActualProd] integer,
		[DaysToPayActualMedia] integer,
		[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DivisionDescription] varchar(40),
		[DivisionStatementAddress1] varchar(40),
		[DivisionStatementAddress2] varchar(40),
		[DivisionStatementCityStateZip] varchar(60),
		[DivisionStatementCountry] varchar(20),
		[DivisionBillingAddress1] varchar(40),
		[DivisionBillingAddress2] varchar(40),
		[DivisionBillingCityStateZip] varchar(60),
		[DivisionBillingCountry] varchar(20),
		[DivisionBillingAttention] varchar(40),
		[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	    [ProductDescription] varchar(40),
		[ProductStatementAddress1] varchar(40),
		[ProductStatementAddress2] varchar(40),
		[ProductStatementCityStateZip] varchar(60),
		[ProductStatementCountry] varchar(20),
		[ProductBillingAddress1] varchar(40),
		[ProductBillingAddress2] varchar(40),
		[ProductBillingCityStateZip] varchar(60),
		[ProductBillingCountry] varchar(20),
		[ProductBillingAttention] varchar(40),
		[AccountExecutiveCode] varchar(6),
		[AccountExecutive] varchar(100),
		[ProductUDF1] varchar(50),
		[ProductUDF2] varchar(50),
		[ProductUDF3] varchar(50),
		[ProductUDF4] varchar(50),
		[ARGLXact] int,
		[ARGLSequenceNumber] smallint,
		[InvoiceNumber] int, --varchar(20),
		[InvoiceSequence] varchar(2),
		[InvoicePostingPeriod] varchar(60),
		[InvoiceDate] smalldatetime,
		[InvoiceDueDate] smalldatetime,
		[PostedToSummary] smalldatetime,
		[InvoiceDescription] varchar(40),
		[InvoiceRecordType] varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[InvoiceCategory] varchar(20),
		[InvoiceComments] varchar(MAX),
		[ARCollectionNotes] varchar(MAX),
		[TotalInvoiceAmount] decimal(15, 2),
		[CashReceipts] decimal(15, 2),
		[CRAdjustments] decimal(15, 2),
		[TotalReceiptsAndAdjustments] decimal(15, 2),
		[InvoiceBalance] decimal(15, 2),
		[Days] int,
		[Current] decimal(15, 2),
		[Aging30Days] decimal(15, 2),
		[Aging60Days] decimal(15, 2),
		[Aging90Days] decimal(15, 2),
		[Aging120PlusDays] decimal(15, 2),
		[OnAccountBalance] decimal(15, 2),
		[InvoiceBalanceWithOA] decimal(15, 2),
		[AbsoluteAmount] decimal(15, 2),
		[DebitOrCredit] varchar(6),
		[JobOrderNumberListing] varchar(MAX),
		[CRCheckNumberListing] varchar(MAX),
		[JobNumber] int,
		[JobDescription] varchar(60),
		[ClientReference] varchar(30),
		[ClientPOProduction] varchar(40),
		[JobType] varchar(10),
		[JobContact] varchar(70),
		[OrderNumber] int,
		[OrderDescription] varchar(40),
		[ClientPOMedia] varchar(25),
		[MediaDates] varchar(50),
		[InvoiceTypeDescription] varchar(30),
		[PartialPaymentIndicator] varchar(1),
		[VendorCode] varchar(6),
		[VendorName] varchar(40),
		[CampaignID] int,
		[CampaignCode] varchar(6),
		[CampaignName] varchar(128),
		[CampaignComment] varchar(MAX)
    );       

	CREATE TABLE #temp
(
	[Days]         Integer,
	ClientCode   VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	InvoiceNo    Integer,
	InvoiceDate  DATETIME,
	RecType		varchar(3)
)

	EXECUTE dbo.advsp_acct_rec_amounts @UserID, @PeriodCutoff		    

	--BIlled Information
	INSERT INTO #AR_AGING
	SELECT 
		[ARGLAccount] = amt.GLACODE,
		[GLOffice] = o2.OFFICE_NAME,
		[AROffice] = o.OFFICE_NAME,
		[ClientCode] = amt.CL_CODE,
		[ClientName] = c.CL_NAME,
		[ClientStatementAddress1] = c.CL_SADDRESS1,
		[ClientStatementAddress2] = c.CL_SADDRESS2, 
		[ClientStatementCityStateZip] = COALESCE((RTRIM(c.CL_CITY) + ' '),'') + COALESCE((RTRIM(c.CL_SSTATE) + ', '),'') + COALESCE((RTRIM(c.CL_SZIP)), ''),
		[ClientStatementCountry] = c.CL_SCOUNTRY,
		[ClientBillingAddress1] = c.CL_BADDRESS1,	
		[ClientBillingAddress2] = c.CL_BADDRESS2, 	
		[ClientBillingCityStateZip] = COALESCE((RTRIM(c.CL_BCITY) + ' '),'') + COALESCE((RTRIM(c.CL_BSTATE) + ', '),'') + COALESCE((RTRIM(c.CL_BZIP)), ''),	
		[ClientBillingCountry] = c.CL_BCOUNTRY,	
		[ClientBillingAttention] = c.CL_ATTENTION,	
		[ClientARComment] = c.CL_AR_COMMENT,	
		[ClientDaysToPayProduction] = CASE WHEN amt.REC_TYPE = 'P' OR amt.REC_TYPE = 'S' THEN ISNULL(c.CL_P_PAYDAYS, 0) ELSE 0 END,	
		[ClientDaysToPayMedia] = CASE WHEN amt.REC_TYPE <> 'P' AND amt.REC_TYPE <> 'S' THEN ISNULL(c.CL_M_PAYDAYS, 0) ELSE 0 END,	
		[DaysToPayActual] = NULL,--CASE WHEN amt.REC_TYPE = 'P' OR amt.REC_TYPE = 'S' THEN DATEDIFF([Day],dd.AR_INV_DUE_DATE, CD.[CheckDate]) ELSE 0 END + CASE WHEN amt.REC_TYPE <> 'P' AND amt.REC_TYPE <> 'S' THEN DATEDIFF([Day],dd.AR_INV_DUE_DATE, CD.[CheckDate]) ELSE 0 END,
		[DaysToPayActualProd] = NULL, --CASE WHEN amt.REC_TYPE = 'P' OR amt.REC_TYPE = 'S' THEN ISNULL(DATEDIFF([Day],dd.AR_INV_DUE_DATE, CD.[CheckDate]),0) ELSE 0 END,
		[DaysToPayActualMedia] = NULL,--CASE WHEN amt.REC_TYPE <> 'P' AND amt.REC_TYPE <> 'S' THEN ISNULL(DATEDIFF([Day],dd.AR_INV_DUE_DATE, CD.[CheckDate]),0) ELSE 0 END,
		[DivisionCode] = amt.DIV_CODE,	
		[DivisionName] = d.DIV_NAME,	
		[DivisionStatementAddress1] = d.DIV_SADDRESS1,	
		[DivisionStatementAddress2] = d.DIV_SADDRESS2, 	
		[DivisionStatementCityStateZip] = COALESCE((RTRIM(d.DIV_SCITY) + ' '),'') + COALESCE((RTRIM(d.DIV_SSTATE) + ', '),'') + COALESCE((RTRIM(d.DIV_SZIP)), ''),		
		[DivisionStatementCountry] = d.DIV_SCOUNTRY,	
		[DivisionBillingAddress1] = d.DIV_BADDRESS1,	
		[DivisionBillingAddress2] = d.DIV_BADDRESS2, 	
		[DivisionBillingCityStateZip] = COALESCE((RTRIM(d.DIV_BCITY) + ' '),'') + COALESCE((RTRIM(d.DIV_BSTATE) + ', '),'') + COALESCE((RTRIM(d.DIV_BZIP)), ''),		
		[DivisionBillingCountry] = d.DIV_BCOUNTRY,	
		[DivisionBillingAttention] = d.DIV_ATTENTION,	
		[ProductCode] = amt.PRD_CODE,	
		[ProductName] = p.PRD_DESCRIPTION,	
		[ProductStatementAddress1] = p.PRD_STATE_ADDR1,	
		[ProductStatementAddress2] = p.PRD_STATE_ADDR2,	
		[ProductStatementCityStateZip] = COALESCE((RTRIM(p.PRD_STATE_CITY) + ' '),'') + COALESCE((RTRIM(p.PRD_STATE_STATE) + ', '),'') + COALESCE((RTRIM(p.PRD_STATE_ZIP)), ''),	
		[ProductStatementCountry] = p.PRD_STATE_COUNTRY,	
		[ProductBillingAddress1] = p.PRD_BILL_ADDRESS1,	
		[ProductBillingAddress2] = p.PRD_BILL_ADDRESS2,	
		[ProductBillingCityStateZip] = COALESCE((RTRIM(p.PRD_BILL_CITY) + ' '),'') + COALESCE((RTRIM(p.PRD_BILL_STATE) + ', '),'') + COALESCE((RTRIM(p.PRD_BILL_ZIP)), ''),	
		[ProductBillingCountry] = p.PRD_BILL_COUNTRY,	
		[ProductBillingAttention] = p.PRD_ATTENTION,	
		[AECode] = AE.EMP_CODE,		
		[AE] = dbo.udf_get_empl_name(AE.EMP_CODE, 'FML'),	
		[ProductUDF1] = p.USER_DEFINED1,	
		[ProductUDF2] = p.USER_DEFINED2,	
		[ProductUDF3] = p.USER_DEFINED3,	
		[ProductUDF4] = p.USER_DEFINED4,	
		[InvoiceNumber] = amt.AR_INV_NBR,--RIGHT('000000' + CAST(amt.AR_INV_NBR AS varchar), 20),	
		[InvoiceSequence] = amt.AR_INV_SEQ,	
		[InvoicePostingPeriod] = dd.AR_POST_PERIOD,	
		[InvoiceDate] = dd.AR_INV_DATE,	
		[InvoiceDueDate] = dd.AR_INV_DUE_DATE,--#01	
		[InvoiceDescription] = amt.AR_DESCRIPTION, 	
		[InvoiceRecordType] = amt.REC_TYPE,	
		[InvoiceCategory] = dd.INV_CAT_DESC,	
		[InvoiceComments] = BC.BILL_COMMENT,	
		[ARCollectionNotes] = n.COLLECT_NOTES,	
		[TotalInvoiceAmount] = amt.AR_INV_AMOUNT,	
		[SumOfCashReceipts] = amt.CR_PAY_AMT,	
		[SumOfCRAdjustments] = amt.CR_ADJ_AMT,	
		[SumOfTotalReceipts and Adjustments] = amt.CR_TOT_AMT,	
		[Invoice Balance] = amt.AR_INV_AMOUNT - amt.CR_TOT_AMT,	
		[Days] = CASE @AgingOption WHEN 1 THEN DATEDIFF(day, dd.AR_INV_DATE, @AgingDate) ELSE DATEDIFF(day, dd.AR_INV_DUE_DATE, @AgingDate) END,--#01	
		[Current] = dbo.advfn_ar_aged_amount(dd.AR_INV_DATE, dd.AR_INV_DUE_DATE, @AgingDate, @AgingOption, 0, amt.AR_INV_AMOUNT - amt.CR_TOT_AMT),	
		[Aging30Days] = dbo.advfn_ar_aged_amount(dd.AR_INV_DATE, dd.AR_INV_DUE_DATE, @AgingDate, @AgingOption, 30, amt.AR_INV_AMOUNT - amt.CR_TOT_AMT),	
		[Aging60Days] = dbo.advfn_ar_aged_amount(dd.AR_INV_DATE, dd.AR_INV_DUE_DATE, @AgingDate, @AgingOption, 60, amt.AR_INV_AMOUNT - amt.CR_TOT_AMT),	
		[Aging90Days] = dbo.advfn_ar_aged_amount(dd.AR_INV_DATE, dd.AR_INV_DUE_DATE, @AgingDate, @AgingOption, 90, amt.AR_INV_AMOUNT - amt.CR_TOT_AMT),	
		[Aging120PlusDays] = dbo.advfn_ar_aged_amount(dd.AR_INV_DATE, dd.AR_INV_DUE_DATE, @AgingDate, @AgingOption, 120, amt.AR_INV_AMOUNT - amt.CR_TOT_AMT),	
		[SumOfOnAccountBalance] = amt.CR_OA_AMT,	
		[InvoiceBalanceWithOA] = amt.AR_INV_AMOUNT - amt.CR_TOT_AMT + amt.CR_OA_AMT,--#03, --#04
		[JobOrderNumberListing] = CASE amt.REC_TYPE WHEN 'P' THEN jl.JOB_NBR_LIST WHEN 'S' THEN jl.JOB_NBR_LIST ELSE ol.ORDER_NBR_LIST END,--#01	
		[CRCheckNumberListing] = cl.CHECK_NBR_LIST,--#01	
		[JobNumber] = j.JOB_NUMBER,	
		[JobDescription] = j.JOB_DESC,	
		[ClientReference] = j.JOB_CLI_REF,	
		[ClientPOProduction] = jc.JOB_CL_PO_NBR,	
		[JobType] = jc.JT_CODE,	
		[JobContact] = ISNULL(ch.CONT_FNAME,'') + ' ' + ISNULL(ch.CONT_LNAME,''),--#01	
		[OrderNumber] = m.ORDER_NBR,	
		[OrderDescription] = m.ORDER_DESC,	
		[ClientPOMedia] = m.CLIENT_PO,	
		[MediaDates] = dbo.advfn_media_order_dates(m.ORDER_NBR,dbo.advfn_ar_min_order_line(amt.AR_INV_NBR, m.ORDER_NBR), amt.REC_TYPE),--#01	
		[InvoiceTypeDescription] = CASE amt.REC_TYPE WHEN 'P' THEN 'Production' WHEN 'S' THEN 'Production' WHEN 'R' THEN 'Broadcast Media' WHEN 'T' THEN 'Broadcast Media' ELSE 'Print Media' END,	
		[PartialPaymentIndicator] = ISNULL(pp.PART_PMT_IND, ''),	
		[VendorCode] = m.VN_CODE,	
		[VendorName] = V.VN_NAME,	
		[CampaignID] = CASE WHEN j.CMP_IDENTIFIER IS NOT NULL AND j.CMP_IDENTIFIER <> 0 THEN j.CMP_IDENTIFIER WHEN m.CMP_ID IS NOT NULL AND m.CMP_ID <> 0 THEN m.CMP_ID ELSE NULL END,	
		[CampaignCode] = CASE WHEN j.CMP_IDENTIFIER IS NOT NULL AND j.CMP_IDENTIFIER <> 0 THEN C.CMP_CODE WHEN m.CMP_ID IS NOT NULL AND m.CMP_ID <> 0 THEN CMP.CMP_CODE ELSE NULL END,	
		[CampaignName] = CASE WHEN j.CMP_IDENTIFIER IS NOT NULL AND j.CMP_IDENTIFIER <> 0 THEN C.CMP_NAME WHEN m.CMP_ID IS NOT NULL AND m.CMP_ID <> 0 THEN CMP.CMP_NAME ELSE NULL END,	
		[CampaignComment] = CASE WHEN j.CMP_IDENTIFIER IS NOT NULL AND j.CMP_IDENTIFIER <> 0 THEN C.CMP_COMMENTS WHEN m.CMP_ID IS NOT NULL AND m.CMP_ID <> 0 THEN CMP.CMP_COMMENTS ELSE NULL END,
		[MappedAccount] = GLAX.MappedAccount,
		[TargetAccount] = GLAEX.TargetAccount,
		[GLExact] = AR.GLEXACT,
		[ARGLSequenceNumber] = AR.GLESEQ_AR,
		[PostedToSummary] = GLH.GLEHPOSTSUM
		--C.CMP_CODE AS [CampaignCode],
		--C.CMP_NAME AS [CampaignName],
		--C.CMP_COMMENTS AS [CampaignComment]	
	FROM 
		dbo.ACCT_REC_AMOUNTS AS amt
	LEFT JOIN
		dbo.ACCT_REC AS AR ON amt.AR_INV_NBR = AR.AR_INV_NBR AND
							  amt.AR_INV_SEQ = AR.AR_INV_SEQ AND
							  amt.AR_TYPE = AR.AR_TYPE
	LEFT JOIN
		dbo.GLENTHDR AS GLH ON AR.GLEXACT = GLH.GLEHXACT
	LEFT JOIN 
		dbo.OFFICE AS o ON amt.OFFICE_CODE = o.OFFICE_CODE
	LEFT JOIN 
		dbo.AR_COLL_NOTES AS n ON amt.AR_INV_NBR = n.AR_INV_NBR
								  AND amt.AR_TYPE = n.AR_TYPE	
								  AND amt.AR_INV_SEQ = n.AR_INV_SEQ	
	LEFT OUTER JOIN
		    (SELECT 
						BC.AR_INV_NBR,
						BC.AR_INV_SEQ,
						BC.BILL_COMMENT
					FROM 
						[dbo].[BILL_COMMENT] AS BC
					WHERE 
						BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = amt.AR_INV_NBR AND 
																																											  BC.AR_INV_SEQ = amt.AR_INV_SEQ
  --  LEFT JOIN 
		--dbo.BILL_COMMENT AS bc ON amt.AR_INV_NBR = bc.AR_INV_NBR
		--						  AND amt.AR_TYPE = bc.AR_TYPE	
		--						  AND amt.AR_INV_SEQ = bc.AR_INV_SEQ	
	LEFT JOIN 
		dbo.GLACCOUNT AS gl ON amt.GLACODE = gl.GLACODE
	LEFT JOIN 
		dbo.OFFICE AS o2 ON gl.GLAOFFICE = o2.OFFICE_CODE	
	LEFT JOIN 
		dbo.CLIENT AS c ON amt.CL_CODE = c.CL_CODE
	LEFT JOIN 
		dbo.DIVISION AS d ON amt.CL_CODE = d.CL_CODE 
							 AND amt.DIV_CODE = d.DIV_CODE
	LEFT JOIN 
		dbo.PRODUCT AS p ON amt.CL_CODE = p.CL_CODE	--#01
							AND amt.DIV_CODE = p.DIV_CODE
							AND amt.PRD_CODE = p.PRD_CODE
    LEFT JOIN 
		dbo.ACCOUNT_EXECUTIVE AS AE ON AE.CL_CODE = p.CL_CODE
									   AND AE.DIV_CODE = p.DIV_CODE
									   AND AE.PRD_CODE = p.PRD_CODE
									   AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1
	LEFT JOIN 
		dbo.JOB_LOG AS j ON dbo.advfn_ar_min_job(amt.AR_INV_NBR) = j.JOB_NUMBER
	LEFT JOIN 
		dbo.JOB_COMPONENT AS jc ON dbo.advfn_ar_min_job(amt.AR_INV_NBR) = jc.JOB_NUMBER
								   AND dbo.advfn_ar_min_job_comp(amt.AR_INV_NBR)	= jc.JOB_COMPONENT_NBR
	LEFT JOIN	
		dbo.V_MEDIA_HDR AS m ON dbo.advfn_ar_min_order(amt.AR_INV_NBR) = m.ORDER_NBR
	--JOIN dbo.RPT_RUNTIME_SPECS AS rs
		--ON amt.[USER_ID] = rs.[USER_ID]
	LEFT JOIN 
		dbo.V_AR_INVOICE_DUE_DATES AS dd ON amt.AR_INV_NBR = dd.AR_INV_NBR		--#01		
	LEFT JOIN 
		dbo.V_ARINV_JOB_LIST AS jl ON amt.AR_INV_NBR = jl.AR_INV_NBR	
	LEFT JOIN 
		dbo.V_ARINV_MEDIA_ORDER_LIST AS ol ON amt.AR_INV_NBR = ol.AR_INV_NBR	
	LEFT JOIN 
		dbo.CDP_CONTACT_HDR AS ch ON jc.CDP_CONTACT_ID = ch.CDP_CONTACT_ID
	LEFT JOIN 
		dbo.V_CR_CHECK_LIST AS cl ON amt.AR_INV_NBR = cl.AR_INV_NBR
	LEFT JOIN 
		dbo.V_AR_ACCT_REC_AGING_PART_PMT AS pp ON amt.[USER_ID] = pp.[USER_ID]
												  AND amt.AR_INV_NBR = pp.AR_INV_NBR
												  AND amt.AR_INV_SEQ = pp.AR_INV_SEQ	
    LEFT JOIN 
		dbo.VENDOR AS V ON m.VN_CODE = V.VN_CODE
	LEFT JOIN 
		dbo.CAMPAIGN AS C ON j.CMP_IDENTIFIER = C.CMP_IDENTIFIER
	LEFT JOIN 
		dbo.CAMPAIGN AS CMP ON m.CMP_ID = CMP.CMP_IDENTIFIER
	LEFT OUTER JOIN
		(SELECT 
			[GLACode] = GLACODE,
			[MappedAccount] = SOURCE_GLACODE
		 FROM 
			[dbo].[GLACCOUNT_XREF] 
		 WHERE
			GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @RecordSource GROUP BY GLACODE)) AS GLAX ON gl.GLACODE = GLAX.GLACode
	LEFT OUTER JOIN
		(SELECT
		 	[TargetAccount] = HDR.TARGET_GLACODE,
			[GLACode] = DTL.GLACODE
		 FROM
		 	dbo.GLACCOUNT_XREF_EXPORT HDR
		 INNER JOIN
		 	dbo.GLACCOUNT_XREF_EXPORT_DETAIL DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID
		 WHERE
			HDR.RECORD_SOURCE_ID = @RecordSource) AS GLAEX ON gl.GLACODE = GLAEX.GLACode
	--LEFT OUTER JOIN
	--	(SELECT 
	--		CRD.AR_INV_NBR,
	--		CRD.AR_INV_SEQ,
	--		CRD.AR_TYPE,
	--		[CheckDate] = MAX(CR_CHECK_DATE)
	--	FROM 
	--		CR_CLIENT CR
	--	INNER JOIN 
	--		CR_CLIENT_DTL CRD ON CR.REC_ID = CRD.REC_ID AND CR.SEQ_NBR = CRD.SEQ_NBR
	--	GROUP BY CRD.AR_INV_NBR,CRD.AR_INV_SEQ,CRD.AR_TYPE) AS CD ON CD.AR_INV_NBR = amt.AR_INV_NBR
	--																AND CD.AR_INV_SEQ = amt.AR_INV_SEQ
	--																AND CD.AR_TYPE = amt.AR_TYPE
	WHERE 
		UPPER(amt.[USER_ID]) = UPPER(@UserID) AND amt.AR_INV_NBR IS NOT NULL



	INSERT INTO #AR_AGING_TOTAL
		SELECT
			[ARGLAccount],
			[MappedAccount],
			[TargetAccount],
			[GLOffice],
			[AROffice],
			[ClientCode],
			[ClientDescription],
			[ClientStatementAddress1],
			[ClientStatementAddress2],
			[ClientStatementCityStateZip],
			[ClientStatementCountry],
			[ClientBillingAddress1],
			[ClientBillingAddress2],
			[ClientBillingCityStateZip],
			[ClientBillingCountry],
			[ClientBillingAttention],
			[ClientARComment],
			[ClientDaysToPayProduction],
			[ClientDaysToPayMedia],
			[DaysToPayActual],
			[DaysToPayActualProd],
			[DaysToPayActualMedia],
			[DivisionCode],
			[DivisionDescription],
			[DivisionStatementAddress1],
			[DivisionStatementAddress2],
			[DivisionStatementCityStateZip],
			[DivisionStatementCountry],
			[DivisionBillingAddress1],
			[DivisionBillingAddress2],
			[DivisionBillingCityStateZip],
			[DivisionBillingCountry],
			[DivisionBillingAttention],
			[ProductCode],
			[ProductDescription],
			[ProductStatementAddress1],
			[ProductStatementAddress2],
			[ProductStatementCityStateZip],
			[ProductStatementCountry],
			[ProductBillingAddress1],
			[ProductBillingAddress2],
			[ProductBillingCityStateZip],
			[ProductBillingCountry],
			[ProductBillingAttention],
			[AccountExecutiveCode],
			[AccountExecutive],
			[ProductUDF1],
			[ProductUDF2],
			[ProductUDF3],
			[ProductUDF4],
			[ARGLXact],
			[ARGLSequenceNumber],
			[InvoiceNumber],
			[InvoiceSequence],
			[InvoicePostingPeriod],
			[InvoiceDate],
			[InvoiceDueDate],
			[PostedToSummary],
			[InvoiceDescription],
			[InvoiceRecordType],
			[InvoiceCategory],
			[InvoiceComments],
			[ARCollectionNotes],
			[TotalInvoiceAmount] = SUM([TotalInvoiceAmount]),
			[CashReceipts] = SUM([CashReceipts]),
			[CRAdjustments] = SUM([CRAdjustments]),
			[TotalReceiptsAndAdjustments] = SUM([TotalReceiptsAndAdjustments]),
			[InvoiceBalance] = SUM([InvoiceBalance]),
			[Days] = SUM([Days]),
			[Current] = SUM([Current]),
			[Aging30Days] = SUM([Aging30Days]),
			[Aging60Days] = SUM([Aging60Days]),
			[Aging90Days] = SUM([Aging90Days]),
			[Aging120PlusDays] = SUM([Aging120PlusDays]),
			[OnAccountBalance] = SUM([OnAccountBalance]),
			[InvoiceBalanceWithOA] = SUM([InvoiceBalanceWithOA]),
			[AbsoluteAmount] = SUM([InvoiceBalanceWithOA]) * CASE WHEN SUM([InvoiceBalanceWithOA]) < 0 THEN -1 ELSE 1 END,
			[DebitOrCredit] = CASE WHEN SUM([InvoiceBalanceWithOA]) < 0 THEN 'Credit' ELSE 'Debit' END,
			[JobOrderNumberListing] = CASE WHEN @IncludeDetails = 1 THEN [JobOrderNumberListing] ELSE '' END,
			[CRCheckNumberListing] = CASE WHEN @IncludeDetails = 1 THEN [CRCheckNumberListing] ELSE '' END,
			[JobNumber] = CASE WHEN @IncludeDetails = 1 THEN [JobNumber] ELSE 0 END,
			[JobDescription] = CASE WHEN @IncludeDetails = 1 THEN [JobDescription] ELSE '' END,
			[ClientReference] = CASE WHEN @IncludeDetails = 1 THEN [ClientReference] ELSE '' END,
			[ClientPOProduction] = CASE WHEN @IncludeDetails = 1 THEN [ClientPOProduction] ELSE '' END,
			[JobType] = CASE WHEN @IncludeDetails = 1 THEN [JobType] ELSE '' END,
			[JobContact] = CASE WHEN @IncludeDetails = 1 THEN [JobContact] ELSE '' END,
			[OrderNumber] = CASE WHEN @IncludeDetails = 1 THEN [OrderNumber] ELSE 0 END,
			[OrderDescription] = CASE WHEN @IncludeDetails = 1 THEN [OrderDescription] ELSE '' END,
			[ClientPOMedia] = CASE WHEN @IncludeDetails = 1 THEN [ClientPOMedia] ELSE '' END,
			[MediaDates] = CASE WHEN @IncludeDetails = 1 THEN [MediaDates] ELSE '' END,
			[InvoiceTypeDescription] = CASE WHEN @IncludeDetails = 1 THEN [InvoiceTypeDescription] ELSE '' END,
			[PartialPaymentIndicator] = CASE WHEN @IncludeDetails = 1 THEN [PartialPaymentIndicator] ELSE '' END,
			[VendorCode] = CASE WHEN @IncludeDetails = 1 THEN [VendorCode] ELSE '' END,
			[VendorName] = CASE WHEN @IncludeDetails = 1 THEN [VendorName] ELSE '' END,
			[CampaignID] = CASE WHEN @IncludeDetails = 1 THEN [CampaignID] ELSE 0 END,
			[CampaignCode] = CASE WHEN @IncludeDetails = 1 THEN [CampaignCode] ELSE '' END,
			[CampaignName] = CASE WHEN @IncludeDetails = 1 THEN [CampaignName] ELSE '' END,
			[CampaignComment]  = CASE WHEN @IncludeDetails = 1 THEN [CampaignComment] ELSE '' END	
		FROM 
			#AR_AGING
		GROUP BY 
			[ARGLAccount],
			[MappedAccount],
			[TargetAccount],
			[GLOffice],
			[AROffice],
			[ClientCode],
			[ClientDescription],
			[ClientStatementAddress1],
			[ClientStatementAddress2],
			[ClientStatementCityStateZip],
			[ClientStatementCountry],
			[ClientBillingAddress1],
			[ClientBillingAddress2],
			[ClientBillingCityStateZip],
			[ClientBillingCountry],
			[ClientBillingAttention],
			[ClientARComment],
			[ClientDaysToPayProduction],
			[ClientDaysToPayMedia],
			[DaysToPayActual],
			[DaysToPayActualProd],
			[DaysToPayActualMedia],
			[DivisionCode],
			[DivisionDescription],
			[DivisionStatementAddress1],
			[DivisionStatementAddress2],
			[DivisionStatementCityStateZip],
			[DivisionStatementCountry],
			[DivisionBillingAddress1],
			[DivisionBillingAddress2],
			[DivisionBillingCityStateZip],
			[DivisionBillingCountry],
			[DivisionBillingAttention],
			[ProductCode],
			[ProductDescription],
			[ProductStatementAddress1],
			[ProductStatementAddress2],
			[ProductStatementCityStateZip],
			[ProductStatementCountry],
			[ProductBillingAddress1],
			[ProductBillingAddress2],
			[ProductBillingCityStateZip],
			[ProductBillingCountry],
			[ProductBillingAttention],
			[AccountExecutiveCode],
			[AccountExecutive],
			[ProductUDF1],
			[ProductUDF2],
			[ProductUDF3],
			[ProductUDF4],
			[ARGLXact],
			[ARGLSequenceNumber],
			[InvoiceNumber],
			[InvoiceSequence],
			[InvoicePostingPeriod],
			[InvoiceDate],
			[InvoiceDueDate],
			[PostedToSummary],
			[InvoiceDescription],
			[InvoiceRecordType],
			[InvoiceCategory],
			[InvoiceComments],
			[ARCollectionNotes],
			[JobOrderNumberListing],
			[CRCheckNumberListing],
			[JobNumber],
			[JobDescription],
			[ClientReference],
			[ClientPOProduction],
			[JobType],
			[JobContact],
			[OrderNumber],
			[OrderDescription],
			[ClientPOMedia],
			[MediaDates],
			[InvoiceTypeDescription],
			[PartialPaymentIndicator],
			[VendorCode],
			[VendorName],
			[CampaignID],
			[CampaignCode],
			[CampaignName],
			[CampaignComment]

   
   INSERT INTO #temp
	SELECT DATEDIFF([Day],MAX(ACCT_REC.AR_INV_DATE),MAX(CR_CLIENT.CR_CHECK_DATE)) AS Days,	
           ACCT_REC.CL_CODE AS ClientCode,
           ACCT_REC.AR_INV_NBR AS InvoiceNo,
           ACCT_REC.AR_INV_DATE AS InvoiceDate,
		   ACCT_REC.REC_TYPE
    FROM   ACCT_REC WITH(NOLOCK)
           INNER JOIN CR_CLIENT_DTL WITH(NOLOCK)
                ON  CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR
                    AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
                    AND CR_CLIENT_DTL.AR_TYPE = ACCT_REC.AR_TYPE
           INNER JOIN CR_CLIENT WITH(NOLOCK)
                ON  CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID
                    AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR LEFT OUTER JOIN
											  CLIENT ON ACCT_REC.CL_CODE = CLIENT.CL_CODE
	WHERE COALESCE(CR_CLIENT_DTL.POST_PERIOD,CR_CLIENT.POST_PERIOD) <= @PeriodCutoff 
	GROUP BY
           ACCT_REC.CL_CODE,
           ACCT_REC.AR_INV_NBR,
           ACCT_REC.AR_INV_DATE,
           --CR_CLIENT.CR_CHECK_DATE,
           ACCT_REC.AR_INV_SEQ,
           ACCT_REC.AR_TYPE,
           ACCT_REC.VOID_FLAG,
           ACCT_REC.OFFICE_CODE,
		   ACCT_REC.DUE_DATE,
		   CL_P_PAYDAYS,
		   CL_M_PAYDAYS,
		   ACCT_REC.REC_TYPE
    HAVING (ACCT_REC.AR_INV_SEQ <> 99) 
           AND (ACCT_REC.AR_TYPE = 'IN') 
           AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL) 
           AND (DATEDIFF([day], ACCT_REC.AR_INV_DATE, GETDATE()) < 730)

    
	UPDATE #AR_AGING_TOTAL
	SET [DaysToPayActual] = (SELECT ISNULL(AVG(B.Days) * SIGN(ABS(SIGN(AVG(B.Days)) + 1)), 0)
							   FROM   #temp B
							   WHERE  B.ClientCode = #AR_AGING_TOTAL.ClientCode)

    UPDATE #AR_AGING_TOTAL
	SET [DaysToPayActualProd] = (SELECT ISNULL(AVG(B.Days) * SIGN(ABS(SIGN(AVG(B.Days)) + 1)), 0)
							   FROM   #temp B
							   WHERE  B.ClientCode = #AR_AGING_TOTAL.ClientCode AND (B.RecType = 'P' OR RecType = 'S'))

    UPDATE #AR_AGING_TOTAL
	SET [DaysToPayActualMedia] = (SELECT ISNULL(AVG(B.Days) * SIGN(ABS(SIGN(AVG(B.Days)) + 1)), 0)
							   FROM   #temp B
							   WHERE  B.ClientCode = #AR_AGING_TOTAL.ClientCode AND (B.RecType <> 'P' AND RecType <> 'S'))

    
	SELECT invoiceId = CAST(InvoiceNumber AS varchar(12)),
		   customerId = ClientCode + ISNULL(DivisionCode,ClientCode) + ISNULL(ProductCode,ClientCode),	
		   invoiceNumber = CAST(InvoiceNumber AS varchar(12)),		   
		   dateCreated = InvoiceDate,
		   dateUpdated = '',
		   dueDate = InvoiceDueDate,
		   terms = CASE WHEN ISNULL(InvoiceRecordType, 'P') <> 'P'THEN ISNULL(C.CL_MFOOTER,'') ELSE ISNULL(C.CL_FOOTER,'') END,
		   poNumber = '',
		   amount = ISNULL(TotalInvoiceAmount,0),
		   paid = ISNULL(P.Paid,0) + ISNULL(P.Writeoff,0),
		   currency = 'USD',
		   exchangeRate = CAST(1 AS decimal),
		   discount = CAST(0 AS decimal),
		   taxTotal = CAST(0 AS decimal),-- ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0),
		   subTotal = CAST(0 AS decimal),--ISNULL(AR_INV_AMOUNT,0) - (ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0)),
		   notes = '',
		   billingCompanyName = '',
		   billingEmail = '',
		   billingPhone = '',
		   billingAddress1 = '',
		   billingAddress2 = '',
		   billingCity = '',
		   billingState = '',
		   billingZip = '',
		   taxAmount = CAST(0 AS decimal),
		   customFields = '',
		   is_deleted = ''
	FROM #AR_AGING_TOTAL
		LEFT OUTER JOIN (SELECT SUM(COALESCE(CR_PAY_AMT, 0)) AS Paid, SUM(COALESCE(CR_ADJ_AMT, 0)) AS Writeoff, AR_INV_NBR, AR_INV_SEQ 
								 FROM	dbo.CR_CLIENT_DTL
								 GROUP BY AR_INV_NBR, AR_INV_SEQ) P ON #AR_AGING_TOTAL.InvoiceNumber = P.AR_INV_NBR AND #AR_AGING_TOTAL.InvoiceSequence = P.AR_INV_SEQ
		LEFT OUTER JOIN dbo.CLIENT C ON #AR_AGING_TOTAL.ClientCode = C.CL_CODE
    --WHERE ISNULL(TotalInvoiceAmount,0) > 0 --AND (((ISNULL(TotalInvoiceAmount,0) - (Paid + Writeoff)) <> 0) OR (Paid = 0))
		
	DROP TABLE #AR_AGING;
	DROP TABLE #AR_AGING_TOTAL;


