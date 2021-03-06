CREATE PROCEDURE [dbo].[advsp_ar_select_client_invoices_for_void]
	@EmployeeCode AS varchar(6), @UserCode AS varchar(100)
AS

CREATE TABLE #INVOICES (
	InvoiceNumber int NOT NULL,
	InvoiceDate smalldatetime NULL,
	PostPeriodCode varchar(6) NULL,
	ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ClientName varchar(40) NULL,
	InvoiceAmount decimal(15,2) NULL,
	[Description] varchar(40) NULL,
	IsManualInvoice bit NOT NULL,
	RecordType varchar(1) NULL,
	AvaTaxPosted  bit NOT NULL,
	DivisionCode  varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode  varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	OfficeCode  varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    QuickBooks bit NOT NULL
)

INSERT INTO #INVOICES
SELECT DISTINCT
	InvoiceNumber = AR_INV_NBR,
	InvoiceDate = AR_INV_DATE,
	PostPeriodCode = AR_POST_PERIOD,
	ClientCode = INVOICES.CL_CODE,
	ClientName = C.CL_NAME,
	InvoiceAmount = AR_INV_AMOUNT,
	[Description] = AR_DESCRIPTION,
	IsManualInvoice = CAST(COALESCE(MANUAL_INV,0) AS bit),
	RecordType = REC_TYPE,
	AvaTaxPosted = CAST(CASE WHEN (SELECT COUNT(1) FROM dbo.AR_SUMMARY ARS WHERE ARS.AR_INV_NBR = INVOICES.AR_INV_NBR AND ARS.AVATAX_POSTED = 1) > 0 THEN 1
						ELSE 0 END AS bit),
	DivisionCode = INVOICES.DIV_CODE,
	ProductCode = INVOICES.PRD_CODE,
	OfficeCode = INVOICES.OFFICE_CODE,
    QuickBooks = CASE WHEN QUICKBOOKS_INVOICE_ID IS NOT NULL THEN 1 ELSE 0 END
FROM (
	SELECT DISTINCT AR_INV_NBR, AR_INV_DATE, AR_POST_PERIOD, CL_CODE, AR_INV_AMOUNT, AR_DESCRIPTION, MANUAL_INV, REC_TYPE, DIV_CODE, PRD_CODE, OFFICE_CODE, QUICKBOOKS_INVOICE_ID
	FROM dbo.ACCT_REC
	WHERE (VOID_FLAG IS NULL OR VOID_FLAG = 0)
	AND AR_INV_SEQ <> 99
	AND AR_INV_NBR NOT IN (
		SELECT DISTINCT AR_INV_NBR
		FROM dbo.ACCT_REC
		WHERE (VOID_FLAG IS NULL OR VOID_FLAG = 0)
		AND AR_INV_SEQ = 99
	)
	AND AR_INV_NBR NOT IN (
		SELECT	AR_INV_NBR
		FROM	dbo.CR_CLIENT_DTL
		GROUP BY AR_INV_NBR 
		HAVING SUM(COALESCE(CR_PAY_AMT,0)) <> 0 OR SUM(COALESCE(CR_ADJ_AMT,0)) <> 0 
	)
	AND AR_INV_NBR IN (
		SELECT DISTINCT AR_INV_NBR 
		FROM dbo.AR_SUMMARY
		WHERE CONVERTED IS NULL OR CONVERTED = 0
	)

	UNION

	SELECT DISTINCT AR_INV_NBR, AR_INV_DATE, AR_POST_PERIOD, CL_CODE, AR_INV_AMOUNT, AR_DESCRIPTION, MANUAL_INV, REC_TYPE, DIV_CODE, PRD_CODE, OFFICE_CODE, QUICKBOOKS_INVOICE_ID
	FROM dbo.ACCT_REC
	WHERE (VOID_FLAG IS NULL OR VOID_FLAG = 0)
	AND AR_INV_SEQ = 99
	AND AR_INV_NBR NOT IN (
		SELECT	AR_INV_NBR
		FROM	dbo.CR_CLIENT_DTL
		GROUP BY AR_INV_NBR 
		HAVING SUM(COALESCE(CR_PAY_AMT,0)) <> 0 OR SUM(COALESCE(CR_ADJ_AMT,0)) <> 0 
	)
	AND AR_INV_NBR IN (
		SELECT DISTINCT AR_INV_NBR 
		FROM dbo.AR_SUMMARY
		WHERE CONVERTED IS NULL OR CONVERTED = 0
	)
	
	UNION

	SELECT DISTINCT AR_INV_NBR, AR_INV_DATE, AR_POST_PERIOD, CL_CODE, AR_INV_AMOUNT, AR_DESCRIPTION, MANUAL_INV, REC_TYPE, DIV_CODE, PRD_CODE, OFFICE_CODE, QUICKBOOKS_INVOICE_ID
	FROM dbo.ACCT_REC
	WHERE (VOID_FLAG IS NULL OR VOID_FLAG = 0)
	AND MANUAL_INV = 1
	AND AR_INV_NBR NOT IN (
		SELECT	AR_INV_NBR
		FROM	dbo.CR_CLIENT_DTL
		GROUP BY AR_INV_NBR 
		HAVING SUM(COALESCE(CR_PAY_AMT,0)) <> 0 OR SUM(COALESCE(CR_ADJ_AMT,0)) <> 0 
	)) AS INVOICES
		INNER JOIN dbo.CLIENT C ON INVOICES.CL_CODE = C.CL_CODE
WHERE INVOICES.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))

declare @ranges CURSOR,
        @first int,
        @last int

SET @ranges = CURSOR FOR
SELECT FIRST_INV, LAST_INV
FROM dbo.BILLING
WHERE FIRST_INV IS NOT NULL
AND LAST_INV IS NOT NULL

OPEN @ranges
FETCH NEXT FROM @ranges INTO @first, @last

WHILE @@FETCH_STATUS = 0
BEGIN
    DELETE #INVOICES WHERE InvoiceNumber BETWEEN @first and @last
    FETCH NEXT FROM @ranges INTO @first, @last
END
CLOSE @ranges
DEALLOCATE @ranges

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE [USER_ID] = @UserCode) > 0
	SELECT *
	FROM #INVOICES I
		INNER JOIN dbo.SEC_CLIENT SC ON SC.[USER_ID] = @UserCode AND
										I.ClientCode = SC.CL_CODE AND 
										(I.DivisionCode IS NULL OR I.DivisionCode = SC.DIV_CODE) AND
										(I.ProductCode IS NULL OR I.ProductCode = SC.PRD_CODE)
	ORDER BY InvoiceDate DESC, InvoiceNumber DESC
ELSE
	SELECT *
	FROM #INVOICES
	ORDER BY InvoiceDate DESC, InvoiceNumber DESC