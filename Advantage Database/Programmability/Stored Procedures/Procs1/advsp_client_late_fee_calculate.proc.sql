CREATE PROCEDURE [dbo].[advsp_client_late_fee_calculate]
	@UserID varchar(100), @PeriodCutoff varchar(6), @AgingDate smalldatetime, @InvoicePostPeriod varchar(6)
AS

/*
declare @UserID varchar(100), @PeriodCutoff varchar(6), @AgingDate smalldatetime
set @UserID = 'SYSADM'
set @PeriodCutoff = '201812'
set @AgingDate = '2018-11-18 00:00:00'
*/

EXECUTE dbo.advsp_acct_rec_amounts @UserID, @PeriodCutoff

SELECT
	[OfficeCode] = Amounts.OFFICE_CODE,
	[OfficeName] = o.OFFICE_NAME,
	[ClientCode] = Amounts.CL_CODE,
	[ClientName] = c.CL_NAME,
	[DivisionCode] = Amounts.DIV_CODE,
	[DivisionName] = d.DIV_NAME,
	[ProductCode] = Amounts.PRD_CODE,
	[ProductName] = p.PRD_DESCRIPTION,
	[AmountDue] = SUM(Amounts.InvoiceBalance),
	[LateFeePercent] = p.LATE_FEE_PERCENT,
	[LateFee] = ROUND(SUM(Amounts.InvoiceBalance) * p.LATE_FEE_PERCENT / 100, 2),	
	[LateFeeGLAccount] = o.GLACODE_CLIENT_LATE_PAYMENT_FEE,
	[PostPeriod] = @InvoicePostPeriod,
	[InvoiceCreatedForPostPeriod] = CAST(CASE WHEN clf.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END as bit),
	[InvoiceNumber] = clf.AR_INV_NBR,
	[FeeInvoiceAmount] = ar.AR_INV_AMOUNT,
	[InvoiceDate] = ar.AR_INV_DATE,
    [DatePosted] = ar.CREATE_DATE,
	[LateFeeLevel] = 'P',
	[EmployeeName] = ISNULL(ec.EMP_FNAME + ' ', '') + ISNULL(ec.EMP_MI + '. ', '') + ISNULL(ec.EMP_LNAME, '')
FROM (
	SELECT 
		[InvoiceBalance] = amt.AR_INV_AMOUNT - CR_TOT_AMT,
		[Days] = DATEDIFF(day, dd.AR_INV_DUE_DATE, @AgingDate),
		CL_CODE,
		DIV_CODE,
		PRD_CODE,
		OFFICE_CODE
	from ACCT_REC_AMOUNTS amt
	LEFT JOIN 
			dbo.V_AR_INVOICE_DUE_DATES AS dd ON amt.AR_INV_NBR = dd.AR_INV_NBR
	where UPPER([USER_ID]) = UPPER(@UserID)
	) Amounts
		INNER JOIN dbo.OFFICE o ON Amounts.OFFICE_CODE = o.OFFICE_CODE 
		INNER JOIN dbo.PRODUCT p ON Amounts.CL_CODE = p.CL_CODE AND Amounts.DIV_CODE = p.DIV_CODE AND Amounts.PRD_CODE = p.PRD_CODE AND p.CALC_LATE_FEE = 1 AND p.ACTIVE_FLAG = 1
		INNER JOIN dbo.CLIENT c ON Amounts.CL_CODE = c.CL_CODE AND c.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION d ON Amounts.CL_CODE = d.CL_CODE AND Amounts.DIV_CODE = d.DIV_CODE AND d.ACTIVE_FLAG = 1
		LEFT OUTER JOIN dbo.CLIENT_LATE_FEE clf ON clf.CL_CODE = p.CL_CODE AND clf.DIV_CODE = p.DIV_CODE AND clf.PRD_CODE = p.PRD_CODE AND clf.POSTPERIOD_CODE = @InvoicePostPeriod
		LEFT OUTER JOIN.dbo.ACCT_REC ar ON ar.AR_INV_NBR = clf.AR_INV_NBR AND ar.VOID_FLAG IS NULL
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON clf.EMP_CODE = ec.EMP_CODE
WHERE Amounts.[Days] > 0
GROUP BY
	Amounts.OFFICE_CODE,
	o.OFFICE_NAME,
	Amounts.CL_CODE,
	c.CL_NAME,
	Amounts.DIV_CODE,
	d.DIV_NAME,
	Amounts.PRD_CODE,
	p.PRD_DESCRIPTION,
	p.LATE_FEE_PERCENT,
	o.GLACODE_CLIENT_LATE_PAYMENT_FEE,
	clf.AR_INV_NBR,
	ar.AR_INV_AMOUNT,
	ar.AR_INV_DATE,
	ar.CREATE_DATE,
	ec.EMP_FNAME,
	ec.EMP_MI,
	ec.EMP_LNAME
	
UNION ALL

SELECT
	[OfficeCode] = Amounts.OFFICE_CODE,
	[OfficeName] = o.OFFICE_NAME,
	[ClientCode] = Amounts.CL_CODE,
	[ClientName] = c.CL_NAME,
	[DivisionCode] = null,
	[DivisionName] = null,
	[ProductCode] = null,
	[ProductName] = null,
	[AmountDue] = SUM(Amounts.InvoiceBalance),
	[LateFeePercent] = c.LATE_FEE_PERCENT,
	[LateFee] = ROUND(SUM(Amounts.InvoiceBalance) * c.LATE_FEE_PERCENT / 100, 2),
	[LateFeeGLAccount] = o.GLACODE_CLIENT_LATE_PAYMENT_FEE,
	[PostPeriod] = @InvoicePostPeriod,
	[InvoiceCreatedForPostPeriod] = CAST(CASE WHEN clf.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END as bit),
	[InvoiceNumber] = clf.AR_INV_NBR,
	[FeeInvoiceAmount] = ar.AR_INV_AMOUNT,
	[InvoiceDate] = ar.AR_INV_DATE,
    [DatePosted] = ar.CREATE_DATE,
	[LateFeeLevel] = 'C',
	[EmployeeName] = ISNULL(ec.EMP_FNAME + ' ', '') + ISNULL(ec.EMP_MI + '. ', '') + ISNULL(ec.EMP_LNAME, '')
FROM (
	SELECT 
		[InvoiceBalance] = amt.AR_INV_AMOUNT - CR_TOT_AMT,
		[Days] = DATEDIFF(day, dd.AR_INV_DUE_DATE, @AgingDate),
		CL_CODE,
		DIV_CODE,
		PRD_CODE,
		OFFICE_CODE
	from ACCT_REC_AMOUNTS amt
	LEFT JOIN 
			dbo.V_AR_INVOICE_DUE_DATES AS dd ON amt.AR_INV_NBR = dd.AR_INV_NBR
	where UPPER([USER_ID]) = UPPER(@UserID)
	) Amounts
		INNER JOIN dbo.OFFICE o ON Amounts.OFFICE_CODE = o.OFFICE_CODE 
		INNER JOIN dbo.CLIENT c ON Amounts.CL_CODE = c.CL_CODE AND c.CALC_LATE_FEE = 1 AND c.ACTIVE_FLAG = 1
		LEFT OUTER JOIN dbo.CLIENT_LATE_FEE clf ON clf.CL_CODE = c.CL_CODE AND clf.DIV_CODE IS NULL AND clf.PRD_CODE IS NULL AND clf.POSTPERIOD_CODE = @InvoicePostPeriod
		LEFT OUTER JOIN.dbo.ACCT_REC ar ON ar.AR_INV_NBR = clf.AR_INV_NBR AND ar.VOID_FLAG IS NULL
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON clf.EMP_CODE = ec.EMP_CODE
WHERE Amounts.[Days] > 0
AND c.CL_CODE NOT IN (SELECT CL_CODE FROM dbo.PRODUCT WHERE CALC_LATE_FEE = 1)
GROUP BY
	Amounts.OFFICE_CODE,
	o.OFFICE_NAME,
	Amounts.CL_CODE,
	c.CL_NAME,
	c.LATE_FEE_PERCENT,
	o.GLACODE_CLIENT_LATE_PAYMENT_FEE,
	clf.AR_INV_NBR,
	ar.AR_INV_AMOUNT,
	ar.AR_INV_DATE,
	ar.CREATE_DATE,
	ec.EMP_FNAME,
	ec.EMP_MI,
	ec.EMP_LNAME

GO