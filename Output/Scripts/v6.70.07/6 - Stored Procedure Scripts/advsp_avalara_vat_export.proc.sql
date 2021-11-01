CREATE PROCEDURE advsp_avalara_vat_export
		@StartingPostPeriodCode varchar(6),
		@EndingPostPeriodCode varchar(6),
		@CurrencyCode varchar(5),
		@AgencyVATNumber varchar(50)
AS

CREATE TABLE #vat_export (
	DocumentType char(1) NOT NULL,
	TransactionDate smalldatetime NULL,
	InvoiceNumber varchar(100) NULL,
	SupplierInvoiceNumber varchar(100) NULL,
	DocumentIndicator char(1) NULL,
	InvoiceDate smalldatetime NULL,
	Currency varchar(3) NULL,
	VATCode varchar(50) NULL,
	SupplierID varchar(50) NULL,
	SupplierName varchar(200) NULL,
	SupplierCountry varchar(2) NULL,
	SupplierVATNumberUsed varchar(50) NULL,
	CustomerID varchar(20) NULL,
	CustomerName varchar(100) NULL,
	CustomerCountry varchar(2) NULL,
	CustomerVATNumberUsed varchar(100) NULL,
	TaxableBasis decimal(19,4),
	ValueVAT decimal(19,4),
	SalesVATDueReverseCharge decimal(19,4),
	AmountVATDeducted decimal(19,4),
	AmountVATReverseCharged decimal(19,4),
	[Source] char(1) NOT NULL,
	AP_ID int NULL
)

--data from Sales Journal dataset
CREATE TABLE #excludes (
	AR_INV_NBR int NOT NULL,
)

INSERT INTO #excludes
SELECT DISTINCT AR_INV_NBR
FROM (
	SELECT 
		[TotalBillLessResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE CAST(0 as decimal) END,
		ARS.AR_INV_NBR
	FROM
		[dbo].[AR_SUMMARY] AS ARS INNER JOIN
		[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									AR.AR_TYPE = ARS.AR_TYPE
	) dtl
GROUP BY AR_INV_NBR
HAVING SUM(dtl.[TotalBillLessResaleTax]) = 0

INSERT INTO #vat_export
SELECT
	DocumentType = CAST(CASE WHEN InvoiceType = 'VO' THEN 2 ELSE 0 END as varchar),
	TransactionDate = InvoiceDate,
	InvoiceNumber = CAST(InvoiceNumber as varchar),
	SupplierInvoiceNumber = '',
	DocumentIndicator = '1',
	InvoiceDate = InvoiceDate,
	Currency = @CurrencyCode,
	VATCode = COALESCE(ST.VAT_TAX_CODE, ''),
	SupplierID = DB_NAME(),
	SupplierName = (SELECT NAME FROM dbo.AGENCY),
	SupplierCountry = (SELECT SUBSTRING(COUNTRY,1,2) FROM dbo.AGENCY),
	SupplierVATNumberUsed = @AgencyVATNumber,
	CustomerID = C.CL_CODE,
	CustomerName = C.CL_NAME,
	CustomerCountry = SUBSTRING(C.CL_COUNTRY,1,2),
	CustomerVATNumberUsed = C.VAT_NUMBER,
	TaxableBasis = CASE WHEN COALESCE(TaxCode,'') <> '' THEN [TotalBillLessResaleTax] ELSE CAST(0 as decimal) END,
	ValueVAT = COALESCE([ResaleTax], 0),
	SalesVATDueReverseCharge = '0',
	AmountVATDeducted = 0.00,
	AmountVATReverseCharged = 0.00,
	[Source] = 'S',
	AP_ID = NULL
FROM (
	SELECT
		[ClientCode] = ARS.CL_CODE,
		[InvoiceDate] = AR.AR_INV_DATE,
		[InvoiceNumber] = ARS.AR_INV_NBR,
		[InvoiceSEQ] = ARS.AR_INV_SEQ,
		[InvoiceType] = ARS.AR_TYPE,
		[TotalBillLessResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE CAST(0 as decimal) END,
		[ResaleTax] = CASE WHEN AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)) ELSE CAST(0 as decimal) END,
		[TaxCode] = ARS.TAX_CODE,
		[Source] = 'S'
	FROM
		[dbo].[AR_SUMMARY] AS ARS INNER JOIN
		[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									AR.AR_TYPE = ARS.AR_TYPE
	WHERE
		1 = 
			--CASE WHEN @BreakoutCoOpBilling = 1 THEN 
			--	CASE WHEN ARS.AR_INV_SEQ <> 99 THEN 1 ELSE 0 END
			--ELSE 
				CASE WHEN ARS.AR_INV_SEQ = 99 OR ARS.AR_INV_SEQ = 0 THEN 1 ELSE 0 END 
			--END 
	AND
		1 = CASE WHEN ISNULL(ARS.MEDIA_TYPE,'P') = 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 1
				 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND ARS.SALE_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 1
				 WHEN ISNULL(ARS.MEDIA_TYPE,'P') <> 'P' AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode THEN 1
			ELSE 0 END 
	AND AR.AR_INV_NBR NOT IN (SELECT AR_INV_NBR FROM #excludes)

	UNION ALL

	SELECT
		[ClientCode] = AR.CL_CODE,
		[InvoiceDate] = AR.AR_INV_DATE,
		[InvoiceNumber] = AR.AR_INV_NBR,
		[InvoiceSEQ] = AR.AR_INV_SEQ,
		[InvoiceType] = AR.AR_TYPE,
		[TotalBillLessResaleTax] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
		[ResaleTax] = (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
		[TaxCode] = NULL,
		[Source] = 'S'
	FROM
		[dbo].[ACCT_REC] AS AR
	WHERE
		AR.MANUAL_INV = 1 AND
		1 = 
			--CASE WHEN @BreakoutCoOpBilling = 1 THEN 
			--	CASE WHEN AR.AR_INV_SEQ <> 99 THEN 1 ELSE 0 END
			--ELSE 
				CASE WHEN AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0 THEN 1 ELSE 0 END 
			--END 
	AND AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode
	AND	AR.AR_INV_NBR NOT IN (SELECT AR_INV_NBR FROM #excludes)
) Detail
	LEFT OUTER JOIN	[dbo].[CLIENT] AS C ON C.CL_CODE = Detail.ClientCode 
	LEFT OUTER JOIN dbo.SALES_TAX ST ON ST.TAX_CODE = Detail.TaxCode 
	
--data from AP Invoice Detail dataset
INSERT INTO #vat_export
SELECT
	DocumentType = 1,
	TransactionDate = H.AP_INV_DATE,
	InvoiceNumber = H.AP_INV_VCHR,
	SupplierInvoiceNumber = H.AP_INV_VCHR,
	DocumentIndicator = '1',
	InvoiceDate = H.AP_INV_DATE,
	Currency = @CurrencyCode,
	VATCode = (SELECT TOP 1 F.VAT_TAX_CODE 
				FROM dbo.AP_PRODUCTION APP
					LEFT OUTER JOIN dbo.FUNCTIONS F ON APP.FNC_CODE = F.FNC_CODE AND COALESCE(F.VAT_TAX_CODE, '') <> ''
				WHERE AP_ID = H.AP_ID 
				ORDER BY COALESCE(MODIFY_DELETE, 0)),
	SupplierID = H.VN_FRL_EMP_CODE,
	SupplierName = V.VN_NAME,
	SupplierCountry = SUBSTRING(V.VN_COUNTRY,1,2),
	SupplierVATNumberUsed = V.VAT_NUMBER,
	CustomerID = DB_NAME(),
	CustomerName = (SELECT NAME FROM dbo.AGENCY),
	CustomerCountry = (SELECT SUBSTRING(COUNTRY,1,2) FROM dbo.AGENCY),
	CustomerVATNumberUsed = @AgencyVATNumber,
	TaxableBasis = H.AP_INV_AMT,
	ValueVAT = H.AP_SALES_TAX,
	SalesVATDueReverseCharge = 0.00,
	AmountVATDeducted = H.AP_SALES_TAX,
	AmountVATReverseCharged = 0.00,
	[Source] = 'P',
	AP_ID = H.AP_ID
FROM dbo.AP_HEADER H
	INNER JOIN dbo.VENDOR V ON H.VN_FRL_EMP_CODE = V.VN_CODE
WHERE
	H.POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode 

UPDATE V SET DocumentType = 3
FROM #vat_export V
	INNER JOIN dbo.AP_HEADER H ON V.AP_ID = H.AP_ID AND H.DELETE_FLAG IS NOT NULL
WHERE V.[Source] = 'P'

UPDATE V SET AmountVATDeducted = TaxableBasis * .2,	AmountVATReverseCharged = TaxableBasis * .2
FROM #vat_export V
WHERE V.VATCode IN ('V3', 'V7')

--final select
SELECT 
	TaxableBasis = CASE WHEN DocumentType = 2 THEN ABS(SUM(TaxableBasis)) ELSE SUM(TaxableBasis) END,
	ValueVAT = CASE WHEN DocumentType = 2 THEN ABS(SUM(ValueVAT)) ELSE SUM(ValueVAT) END,
	DocumentType,
	TransactionDate,
	InvoiceNumber,
	SupplierInvoiceNumber,
	DocumentIndicator,
	InvoiceDate,
	Currency,
	VATCode,
	SupplierID,
	SupplierName,
	SupplierCountry,
	SupplierVATNumberUsed,
	CustomerID,
	CustomerName,
	CustomerCountry,
	CustomerVATNumberUsed,
	SalesVATDueReverseCharge = CASE WHEN DocumentType = 2 THEN ABS(SUM(SalesVATDueReverseCharge)) ELSE SUM(SalesVATDueReverseCharge) END,
	AmountVATDeducted = CASE WHEN DocumentType = 2 THEN ABS(SUM(AmountVATDeducted)) ELSE SUM(AmountVATDeducted) END,
	AmountVATReverseCharged = CASE WHEN DocumentType = 2 THEN ABS(SUM(AmountVATReverseCharged)) ELSE SUM(AmountVATReverseCharged) END,
	[Source]
FROM #vat_export
GROUP BY
	DocumentType,
	TransactionDate,
	InvoiceNumber,
	SupplierInvoiceNumber,
	DocumentIndicator,
	InvoiceDate,
	Currency,
	VATCode,
	SupplierID,
	SupplierName,
	SupplierCountry,
	SupplierVATNumberUsed,
	CustomerID,
	CustomerName,
	CustomerCountry,
	CustomerVATNumberUsed,
	[Source]
GO
