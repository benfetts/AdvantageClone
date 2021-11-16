if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ap_invoice_detail_pmts_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ap_invoice_detail_pmts_report]
GO

CREATE PROCEDURE [advsp_ap_invoice_detail_pmts_report] @payment_date_from varchar(30), @payment_date_to varchar(30),
	@VENDOR_LIST varchar(MAX) = NULL

AS



SET NOCOUNT ON

DECLARE @APIDS TABLE  (
	AP_ID int NOT NULL,
	AP_SEQ smallint NOT NULL
)

DECLARE @APDETAILS TABLE  (
	AP_ID int NOT NULL,
	DISBURSEMENT_TYPE char(1) NOT NULL,
	CL_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_NUMBER int NULL,
	JOB_DESC varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_COMPONENT_NBR smallint NULL,
	JOB_COMP_DESC varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_COMP varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_DESCRIPTION varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_TYPE varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PO_NUMBER int NULL,
	PO_LINE_NUMBER smallint NULL,
	AP_COMMENT varchar(max) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AR_INV_NBR int NULL,
	AR_TYPE varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AR_INV_DATE datetime NULL,
	ORDER_NBR int NULL,
	ORDER_LINE_NBR smallint NULL,
	ORDER_PERIOD varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ORDER_DESC varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GLACODE varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	NET_AMT decimal(14, 2) NULL,
	CMP_IDENTIFIER int NULL,
	VENDOR_TAX decimal(14,2) NULL,
	NON_BILLABLE smallint,
	POST_PERIOD varchar(8),
	MODIFIED_BY varchar(100),
	MODIFY_DATE smalldatetime, 
	CLIENT_PO varchar(40)
)

DECLARE @CR TABLE  (
	AR_INV_NBR int NULL,
	AR_TYPE varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AR_INV_DATE datetime NULL,
	CR_PAY_AMT decimal(14, 2) NULL,
	CR_ADJ_AMT decimal(14,2) NULL,
	BALANCE decimal(14,2) NULL
)

INSERT @APIDS
SELECT AP_ID, MAX(AP_SEQ) AP_SEQ
FROM dbo.AP_PMT_HIST H
WHERE H.AP_CHK_DATE BETWEEN @payment_date_from AND @payment_date_to 
GROUP BY AP_ID

--SELECT * FROM @APIDS

SELECT * 
INTO #dataset
FROM (
SELECT
		[ID] = NEWID(),
		[VendorCode] = H.VN_FRL_EMP_CODE,
		[VendorName],
		[VendorAddress1],
		[VendorAddress2],
		[VendorAddress3],
		[VendorCity],
		[VendorCounty],
		[VendorState],
		[VendorZip],
		[VendorCountry],
		[VendorPhone],
		[VendorPhoneExt],
		[VendorFaxNumber],
		[VendorFaxExt],
		[VendorEmail],
		[VendorPayToCode],
		[VendorPayToName],
		[VendorPayToAddress1],
		[VendorPayToAddress2],
		[VendorPayToAddress3],
		[VendorPayToCity],
		[VendorPayToCounty],
		[VendorPayToState],
		[VendorPayToZip],
		[VendorPayToCountry],
		[VendorPayToPhone],
		[VendorPayToPhoneExt],
		[VendorPayToFax],
		[VendorPayToFaxExt],
		[VendorPayToEmail],
		[VendorDefaultCategory],
		[VendorOfficeCode],
		[VendorOfficeName],
		[VendorVCCStatus],
		[VendorBankCode],
		[VendorBankName],
		[BankOfficeCode] = BANK.OFFICE_CODE,
		[BankOfficeName] = CAST(NULL AS varchar(100)),
		[VendorSpecialTerms],
		[VendorNotes] = CAST([VendorNotes] AS VARCHAR(MAX)),
		[VendorServiceTaxCode] = VST.CODE,
		[VendorServiceTaxDescription] = VST.[DESCRIPTION],
		[EmployeeVendor] = CASE WHEN EMP_VENDOR = 1 THEN 'Yes' ELSE 'No' END,
			[VendorFederalTaxID],
			[VendorIs1099],
		[SubjectToVST] = CASE WHEN ISNULL(H.SERVICE_TAX_ENABLED,0) = 0 THEN 'No' ELSE 'Yes' END,	
			[VSTType] = CAST([VSTType] as varchar(20)),
			[VSTRate],
			[VSTThreshold] = VST.THRESHOLD,
			[VSTTaxWaiver],
			[VSTWaiverExpiration],
		[APIdentifier] = H.AP_ID,
		[APType] = CASE WHEN EMP_VENDOR = 1 THEN 'E' ELSE H.AP_TYPE END,
		[InvoiceNumber] = H.AP_INV_VCHR,
		[APDescription] = H.AP_DESC,
			[InvoiceIs1099] = CASE WHEN ISNULL(H.FLAG_1099, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[InvoiceDate] = H.AP_INV_DATE,
		[DateToPay] = H.AP_DATE_PAY,
		[PostingPeriod] = H.POST_PERIOD,
		[APGLXact] = H.GLEXACT,
		[APGLAccountCode] = H.GLACODE,
		[APGLAccountDescription] = G.GLADESC,
		[InvoiceAmount] = SUM(H.AP_INV_AMT) , --[TotalAmount] = SUM(COALESCE(APH.VENDOR_TAX,0) + COALESCE(APH.NET_AMT,0)),
		--[PaidToVendor] = SUM(COALESCE(Payment.TotalPaid, 0)),
		[TotalPaidAmount] = SUM(ISNULL(Payment.TotalPaid, 0) + ISNULL(Payment.VendorServiceTax, 0)),	
		--[TotalTaxAmount] = SUM(ISNULL(Payment.VendorServiceTax, 0)),	
		[PMTNumber] = APH.AP_CHK_NBR,
		[PMTDate] = APH.AP_CHK_DATE,	
		[BankCode] = APH.BK_CODE,
		[BankDescription] = BANK.BK_DESCRIPTION,
		--[BalanceDue] = (SELECT SUM(CAST(ISNULL(AH.AP_INV_AMT, 0) + ISNULL(AH.AP_SHIPPING, 0) + ISNULL(AH.AP_SALES_TAX, 0) AS decimal(16,2))) FROM AP_HEADER AH WHERE AH.AP_ID = H.AP_ID GROUP BY AH.AP_ID) 
		--				- SUM((ISNULL(Payment.TotalPaid, 0) + ISNULL(Payment.VendorServiceTax, 0) + ISNULL(Payment.DiscountAmount, 0))),
		[BalanceDue] = (SUM(Invoice.TOT_INV_AMT)) 
						- SUM(((Payment.TotalPaid) + (Payment.VendorServiceTax) + (Payment.DiscountAmount))),
			[PMTDiscountAmount] = SUM(ISNULL(APH.AP_DISC_AMT,0)),
			[PMTNetAmount] = SUM(ISNULL(APH.AP_CHK_AMT,0) + ISNULL(APH.AP_DISC_AMT,0)),
			[PMTVendorServiceTaxableAmount] = SUM(ISNULL(APH.VENDOR_TAXABLE_AMOUNT,0)),
			[PMTVendorServiceTaxAmount] = SUM(ISNULL(APH.VENDOR_SERVICE_TAX,0)),
			[TotalPmtAmount] = SUM(ISNULL(APH.AP_CHK_AMT,0) + ISNULL(APH.VENDOR_SERVICE_TAX,0)),  /* <<<<<<<<<<<<<<<<<<<<< ??????? ????????? ????????? ?????????? ?????????? ?????? */
			[VSTGLCode] = APH.GLACODE_WH,
			[DiscountGLCode] = APH.GLACODE_DISC,
			[PMTPostPeriod] = APH.POST_PERIOD

FROM dbo.AP_HEADER H
	INNER JOIN @APIDS Ids ON Ids.AP_ID = H.AP_ID AND Ids.AP_SEQ = H.AP_SEQ
	LEFT OUTER JOIN dbo.GLACCOUNT G ON H.GLACODE = G.GLACODE 
	LEFT OUTER JOIN (
				SELECT
						[VendorName] = V.VN_NAME,
						[VendorAddress1] = V.VN_ADDRESS1,
						[VendorAddress2] = V.VN_ADDRESS2,
						[VendorAddress3] = V.VN_ADDRESS3,
						[VendorCity] = V.VN_CITY,
						[VendorCounty] = V.VN_COUNTY,
						[VendorState] = V.VN_STATE,
						[VendorZip] = V.VN_ZIP,
						[VendorCountry] = V.VN_COUNTRY,
						[VendorPhone] = V.VN_PHONE,
						[VendorPhoneExt] = V.VN_PHONE_EXT,
						[VendorFaxNumber] = V.VN_FAX_NUMBER,
						[VendorFaxExt] = V.VN_FAX_EXTENTION,
						[VendorEmail] = V.VN_EMAIL,
						[VendorDefaultCategory] = V.VN_CATEGORY,
						[VendorAccountNumber] = V.VN_ACCT_NBR,
						[VendorOfficeCode] = V.OFFICE_CODE,
						[VendorOfficeName] = O.OFFICE_NAME,
						[VendorPayToCode] = V.VN_PAY_TO_CODE,
						V.VN_CODE,
						[VendorPayToName] = V1.VN_PAY_TO_NAME,
						[VendorPayToAddress1] = V1.VN_PAY_TO_ADDRESS1,
						[VendorPayToAddress2] = V1.VN_PAY_TO_ADDRESS2,
						[VendorPayToAddress3] = V1.VN_PAY_TO_ADDRESS3,
						[VendorPayToCity] = V1.VN_PAY_TO_CITY,
						[VendorPayToCounty] = V1.VN_PAY_TO_COUNTY,
						[VendorPayToState] = V1.VN_PAY_TO_STATE,
						[VendorPayToZip] = V1.VN_PAY_TO_ZIP,
						[VendorPayToCountry] = V1.VN_PAY_TO_COUNTRY,
						[VendorPayToPhone] = V1.VN_PAY_TO_PHONE,
						[VendorPayToPhoneExt] = V1.VN_PAY_TO_EXT,
						[VendorPayToFax] = V1.VN_PAY_TO_FAX_NBR,
						[VendorPayToFaxExt] = V1.VN_PAY_TO_FAX_EXT,
						[VendorPayToEmail] = V1.VN_EMAIL,
						EMP_VENDOR = COALESCE(V.EMP_VENDOR, 0),
						[VendorVCCStatus] = CASE WHEN ISNULL(V.VCC_STATUS, 0) = 0 THEN 'Open'
													WHEN V.VCC_STATUS = 1 THEN 'Accepted'
													WHEN V.VCC_STATUS = 2 THEN 'Declined'
											END,
						[VendorBankCode] = V.BK_CODE,
						[VendorBankName] = B.BK_DESCRIPTION,
						[VendorSpecialTerms] = CASE WHEN V.HAS_SPECIAL_TERMS = 1 THEN 'Y' ELSE 'N' END,
						[VendorNotes] = V.VN_NOTES,
							[VendorFederalTaxID] = V.VN_TAX_ID,
							[VendorIs1099] = CASE WHEN ISNULL(V.VN_1099_FLAG, 0) = 1 THEN 'Yes' ELSE 'No' END,
							[VSTType] = CASE V.SERVICE_TAX_TYPE WHEN 1 THEN 'PR Resident' WHEN 2 THEN 'US Resident' WHEN 3 THEN 'Non Resident' ELSE CAST(V.SERVICE_TAX_TYPE AS varchar(20)) END,
							[VSTRate] = V.SERVICE_TAX_RATE,
							[VSTTaxWaiver] = CASE WHEN ISNULL(V.SERVICE_TAX_WAIVER, 0) = 1 THEN 'Yes' ELSE 'No' END,
							[VSTWaiverExpiration] = V.SERVICE_TAX_WAIVER_EXPIRATION_DATE,
							[VendorServiceTaxID] = V.VENDOR_SERVICE_TAX_ID
				FROM dbo.VENDOR V
					LEFT OUTER JOIN dbo.OFFICE O ON V.OFFICE_CODE = O.OFFICE_CODE
					LEFT OUTER JOIN dbo.VENDOR V1 ON V.VN_PAY_TO_CODE = V1.VN_CODE 
					LEFT OUTER JOIN dbo.BANK B ON V.BK_CODE = B.BK_CODE
				) V ON H.VN_FRL_EMP_CODE = V.VN_CODE 
	LEFT OUTER JOIN dbo.VENDOR_SERVICE_TAX VST ON V.VendorServiceTaxID = VST.VENDOR_SERVICE_TAX_ID
	LEFT OUTER JOIN (
					SELECT	[TotalPaid] = SUM(COALESCE(AP_CHK_AMT, 0)),
							[DiscountAmount] = SUM(COALESCE(AP_DISC_AMT,0)),
							[VendorServiceTax] = SUM(COALESCE(VENDOR_SERVICE_TAX,0)),
							A.AP_ID
					FROM dbo.AP_PMT_HIST A JOIN @APIDS B ON A.AP_ID = B.AP_ID
					/* Sum all payments related to the given AP_ID - No Date Limits */
					GROUP BY A.AP_ID
					) Payment ON Payment.AP_ID = H.AP_ID
	LEFT OUTER JOIN (
					SELECT SUM(
								CAST(ISNULL(A.AP_INV_AMT, 0) + ISNULL(A.AP_SHIPPING, 0) + ISNULL(A.AP_SALES_TAX, 0) AS decimal(16,2)
								)
							) AS TOT_INV_AMT, A.AP_ID
					FROM AP_HEADER A JOIN @APIDS B ON A.AP_ID = B.AP_ID GROUP BY A.AP_ID
					/* Sum all seq's related to the given AP_ID - No Date Limits */
					) Invoice ON Invoice.AP_ID = H.AP_ID
	INNER JOIN dbo.AP_PMT_HIST APH ON  H.AP_ID = APH.AP_ID --AND H.GLEXACT = APH.GLEXACT  --LastCheck.AP_ID = APH.AP_ID AND LastCheck.MaxGLEXACT = APH.GLEXACT 
	INNER JOIN CHECK_REGISTER CHR ON CHR.BK_CODE = APH.BK_CODE AND CHR.CHECK_NBR = APH.AP_CHK_NBR AND (CHR.VOID_FLAG IS NULL OR CHR.VOID_FLAG = 0)

	LEFT OUTER JOIN dbo.BANK ON BANK.BK_CODE = APH.BK_CODE

GROUP BY H.VN_FRL_EMP_CODE,
		[VendorName],
		[VendorAddress1],
		[VendorAddress2],
		[VendorAddress3],
		[VendorCity],
		[VendorCounty],
		[VendorState],
		[VendorZip],
		[VendorCountry],
		[VendorPhone],
		[VendorPhoneExt],
		[VendorFaxNumber],
		[VendorFaxExt],
		[VendorEmail],
		[VendorPayToCode],
		[VendorPayToName],
		[VendorPayToAddress1],
		[VendorPayToAddress2],
		[VendorPayToAddress3],
		[VendorPayToCity],
		[VendorPayToCounty],
		[VendorPayToState],
		[VendorPayToZip],
		[VendorPayToCountry],
		[VendorPayToPhone],
		[VendorPayToPhoneExt],
		[VendorPayToFax],
		[VendorPayToFaxExt],
		[VendorPayToEmail],
		[VendorDefaultCategory],
		[VendorAccountNumber],
		[VendorOfficeCode],
		[VendorOfficeName],
		[VendorVCCStatus],
		[VendorBankCode],
		[VendorBankName],
		 BANK.OFFICE_CODE,
		[VendorSpecialTerms],
		CAST([VendorNotes] AS VARCHAR(MAX)),
		VST.CODE,
		VST.[DESCRIPTION],
		CASE WHEN EMP_VENDOR = 1 THEN 'Yes' ELSE 'No' END,
			[VendorFederalTaxID],
			[VendorIs1099],
		CASE WHEN ISNULL(H.SERVICE_TAX_ENABLED,0) = 0 THEN 'No' ELSE 'Yes' END,	
			[VSTType],
			[VSTRate],
			[VST].[THRESHOLD],
			[VSTTaxWaiver],
			[VSTWaiverExpiration],			
		H.AP_ID,
		CASE WHEN EMP_VENDOR = 1 THEN 'E' ELSE H.AP_TYPE END,
		H.AP_INV_VCHR,
		H.AP_DESC,
			H.FLAG_1099,
		H.CREATE_DATE,
		H.CREATED_BY,
        H.MODIFIED_BY,
        H.MODIFY_DATE,
        H.BATCH_NAME,
		H.AP_INV_DATE,
		H.AP_DATE_PAY,
		H.POST_PERIOD,
		H.GLEXACT,
		H.GLACODE,
		G.GLADESC,
		CAST(COALESCE(H.PAYMENT_HOLD, 0) AS bit),
		APH.AP_CHK_NBR,
		APH.AP_CHK_DATE,	
		APH.BK_CODE,
		BANK.BK_DESCRIPTION,
			APH.GLACODE_WH,
			APH.GLACODE_DISC,
			APH.POST_PERIOD

) A
OPTION (RECOMPILE)

UPDATE A
SET A.[BankOfficeName] = B.OFFICE_NAME
FROM #dataset A
    INNER JOIN OFFICE B ON
        A.[BankOfficeCode] = B.OFFICE_CODE

SELECT * FROM #dataset
WHERE (VendorPayToCode IN (SELECT * FROM dbo.udf_split_list(@VENDOR_LIST, ',')) OR @VENDOR_LIST IS NULL)


GO
