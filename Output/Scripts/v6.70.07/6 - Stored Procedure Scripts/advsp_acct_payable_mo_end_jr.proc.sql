--0) 3/19/20 New data source for data set 'Month End Accounts Payable'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (Select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_acct_payable_mo_end]')
	and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_acct_payable_mo_end]

GO

CREATE PROCEDURE [dbo].[advsp_acct_payable_mo_end] (
	@office_list AS varchar(MAX) = NULL,
	@end_period AS varchar(6) = '999912',
	--@open_flag AS tinyint = 0
	--All month end reports include open AP only, @open_flag = 1
	@detail_option AS tinyint = 0,
	@aging_option AS tinyint = 1,
	@aging_date AS date = '12/31/99'
	)

	--@aging_option 1 = date to pay, 2 = invoice date    

AS
BEGIN
SET NOCOUNT ON;

--===============================
--Main Data Table
--===============================
CREATE TABLE #ap_invoice(
	AP_ID						int NOT NULL,
	AP_SEQ						smallint NOT NULL,
	[TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_NAME						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR					varchar(20)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE					smalldatetime,
	AP_DATE_PAY					smalldatetime,
	AP_TOT_AMT					decimal(14,2) NULL,
	AP_PAYMENT_HOLD				smallint NULL,
	AP_GLACODE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLADESC					varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT					int NULL,
	AP_GLESEQ					smallint NULL,
	AP_CHK_NBR					int NULL,
	AP_CHK_DATE					smalldatetime,
	AP_CHK_AMT					decimal(14,2) NULL,
	AP_DISC_AMT					decimal(14,2) NULL,
	AP_BAL_AMT					decimal(14,2) NULL,
	VENDOR_SERVICE_TAX			decimal(14,2) NULL,
	VN_PAY_TO_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_CL_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_DIV_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_PRD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_AMOUNT					decimal(15,2) NULL,
	DTL_TAX						decimal(15,2) NULL,
	DTL_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_GLACODE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_GLADESC					varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_AP_REFERENCE			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_AR_INV_NBR				int NULL,
	DTL_AR_TYPE					varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_AR_INV_DATE				smalldatetime,
	DTL_AB_REFERENCE			varchar(14) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DTL_NON_BILLABLE			varchar(12)	COLLATE SQL_Latin1_General_CP1_CS_AS)

--1. AP Summary (dbo.advsp_acct_payable_sum) open only
--Repeats AP_BAL_AMT in full on every row, but other amounts can be used in summary queries
CREATE TABLE #ap_sum (
	[TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_ID						int NOT NULL,
	AP_SEQ						smallint NOT NULL,
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE					smalldatetime,
	AP_DATE_PAY					smalldatetime,
	AP_TOT_AMT					decimal(14,2) NULL,
	PAYMENT_HOLD				smallint NULL,
	GLACODE						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT						int NULL,
	GLESEQ						smallint NULL,
	AP_CHK_NBR					int NULL,
	AP_CHK_DATE					smalldatetime,
	AP_CHK_AMT					decimal(14,2) NULL,
	AP_DISC_AMT					decimal(14,2) NULL,
	VENDOR_SERVICE_TAX			decimal(14,2) NULL,
	VN_PAY_TO_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EXCHANGE_AMOUNT_APPLIED		decimal(14,2) NULL,
	CURRENCY_RATE				decimal(12,6) NULL,
	X_AP_INV_VCHR				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	X_AP_BAL_AMT				decimal(15,2) NULL)
INSERT INTO #ap_sum EXECUTE advsp_acct_payable_sum @office_list, @end_period, @open_flag = 1

--Check Result #ap_sum
--SELECT * FROM #ap_sum
--ORDER BY AP_ID, [TYPE]

--2.a. AP Detail Temp (dbo_advsp_acct_payable_dtl)
	CREATE TABLE #ap_dtl_temp (
	[TYPE]							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_ID							int NOT NULL,
	AP_SEQ							smallint NOT NULL,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AMOUNT							decimal(15,2) NULL,
	TAX								decimal(15,2) NULL,
	PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_REFERENCE					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE						smalldatetime,
	AB_FLAG							tinyint NULL,
	NON_BILL_FLG					tinyint NULL)
IF @detail_option = 1 INSERT INTO #ap_dtl_temp EXECUTE advsp_acct_payable_dtl

--2.b. AP Sum Select IDs (Select ap_sum AP_IDs)
CREATE TABLE #sel_ap_id (
	AP_ID						int NOT NULL,
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE					smalldatetime,
	[TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #sel_ap_id SELECT
	aps.AP_ID,
	aps.VN_FRL_EMP_CODE,
	aps.AP_INV_VCHR,
	aps.AP_INV_DATE,
	aps.[TYPE]
FROM #ap_sum AS aps
WHERE aps.[TYPE] = 'AP'
GROUP BY aps.AP_ID, aps.VN_FRL_EMP_CODE, aps.AP_INV_VCHR, aps.AP_INV_DATE, aps.[TYPE]

--Check Result #sel_ap_id
--SELECT * FROM #sel_ap_id
--ORDER BY AP_ID

--2.c AP Detail (ap_dtl for sel_ap_id)
CREATE TABLE #ap_dtl (
	[TYPE]							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_ID							int NOT NULL,
	AP_SEQ							smallint NOT NULL,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AMOUNT							decimal(15,2) NULL,
	TAX								decimal(15,2) NULL,
	PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_REFERENCE					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE						smalldatetime,
	AB_REFERENCE					varchar(14) COLLATE SQL_Latin1_General_CP1_CS_AS,
	NON_BILLABLE					varchar(12)	COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #ap_dtl SELECT
	apd.[TYPE],
	apd.AP_ID,
	apd.AP_SEQ,
	apd.CL_CODE,
	apd.DIV_CODE,
	apd.PRD_CODE,
	apd.AMOUNT,
	apd.TAX,
	apd.PERIOD,
	apd.GLACODE,
	apd.AP_REFERENCE,
	apd.AR_INV_NBR,
	apd.AR_TYPE,
	apd.AR_INV_DATE,
	CASE WHEN (apd.AB_FLAG IN (1,2,3) AND apd.AR_INV_NBR IS NULL) THEN 'Advance Billed' ELSE NULL END AS AB_REFERENCE,
	CASE WHEN apd.NON_BILL_FLG = 1 THEN 'Non Billable' ELSE NULL END AS NON_BILLABLE
FROM #ap_dtl_temp AS apd
JOIN #sel_ap_id AS sid ON apd.AP_ID = sid.AP_ID

--Check Result #ap_dtl
--SELECT * FROM #ap_dtl
--ORDER BY AP_ID, [TYPE]

--3. #ap_sum to #ap_invoice
INSERT INTO #ap_invoice SELECT
	aps.AP_ID,
	aps.AP_SEQ,
	aps.[TYPE],
	aps.VN_FRL_EMP_CODE,
	vn.VN_NAME,
	aps.AP_INV_VCHR,
	aps.AP_INV_DATE,
	aps.AP_DATE_PAY,
	aps.AP_TOT_AMT,
	aps.PAYMENT_HOLD,
	aps.GLACODE,
	gl.GLADESC,
	aps.POST_PERIOD,
	aps.GLEXACT,
	aps.GLESEQ,
	aps.AP_CHK_NBR,
	aps.AP_CHK_DATE,
	aps.AP_CHK_AMT,
	aps.AP_DISC_AMT,
	ISNULL(aps.AP_TOT_AMT,0)-(ISNULL(aps.AP_CHK_AMT,0)+ISNULL(aps.AP_DISC_AMT,0)),
	aps.VENDOR_SERVICE_TAX,
	aps.VN_PAY_TO_CODE,
	NULL,
	NULL,
	NULL,
	0.00,
	0.00,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
FROM #ap_sum AS aps
JOIN dbo.VENDOR as vn ON aps.VN_FRL_EMP_CODE = vn.VN_CODE
JOIN dbo.GLACCOUNT AS gl ON aps.GLACODE = gl.GLACODE

--Check Result ap_sum to ap_invoice
--SELECT * FROM #ap_invoice AS api
--WHERE api.[TYPE] In ('AP','CK')
--ORDER BY api.AP_ID, api.[TYPE]

--4a. Get GL ACCOUNT for Max AP_GLEXACT from #ap_invoice
 CREATE TABLE #ap_glexact (
	 AP_ID           int NOT NULL,
	 AP_GLEXACT         int NULL,
	 AP_GLESEQ         smallint NULL,
	 AP_GLACODE         varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	 AP_GLADESC         varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #ap_glexact SELECT
	 api.AP_ID,
	 api.AP_GLEXACT,
	 api.AP_GLESEQ,
	 api.AP_GLACODE,
	 api.AP_GLADESC
 FROM #ap_invoice AS api
 WHERE [TYPE]='AP' AND api.AP_GLEXACT = (SELECT MAX(api2.AP_GLEXACT) FROM #ap_invoice AS api2 WHERE api.AP_ID = api2.AP_ID AND [TYPE] = 'AP')
 GROUP BY AP_ID, AP_GLEXACT, AP_GLESEQ, AP_GLACODE, AP_GLADESC
 --SELECT * FROM #ap_glexact
 --ORDER BY AP_ID

 --4b. Get GL ACCOUNT FOR Max AP_GLESEQ from #ap_glexact
 CREATE TABLE #ap_glaccount (
	 AP_ID           int NOT NULL,
	 AP_GLACODE         varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	 AP_GLADESC         varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS)
 INSERT INTO #ap_glaccount SELECT
	 agl.AP_ID,
	 agl.AP_GLACODE,
	 agl.AP_GLADESC
 FROM #ap_glexact AS agl
 WHERE agl.AP_GLESEQ = (SELECT MAX(agl2.AP_GLESEQ) FROM #ap_glexact AS agl2 WHERE agl.AP_ID = agl2.AP_ID AND agl.AP_GLEXACT = agl2.AP_GLEXACT)
 GROUP BY AP_ID, AP_GLACODE, AP_GLADESC
 --SELECT * FROM #ap_glaccount
 --ORDER BY AP_ID

--4. Get #ap_invoice info for #ap_dtl
CREATE TABLE #ap_info (
	AP_ID						int NOT NULL,
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_NAME						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR					varchar(20)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE					smalldatetime,
	AP_DATE_PAY					smalldatetime,
	AP_PAYMENT_HOLD				smallint,
	AP_GLACODE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLADESC					varchar(75) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_PAY_TO_CODE				varchar(6))
IF @detail_option = 1 INSERT INTO #ap_info SELECT
	api.AP_ID,
	api.VN_FRL_EMP_CODE,
	api.VN_NAME,
	api.AP_INV_VCHR,
	api.AP_INV_DATE,
	api.AP_DATE_PAY,
	api.AP_PAYMENT_HOLD,
	agl.AP_GLACODE,
	agl.AP_GLADESC,
	api.VN_PAY_TO_CODE
FROM #ap_invoice AS api LEFT JOIN #ap_glaccount AS agl ON agl.AP_ID = api.AP_ID
WHERE [TYPE] = 'AP' 
GROUP BY api.AP_ID, api.VN_FRL_EMP_CODE, api.VN_NAME, api.AP_INV_VCHR, api.AP_INV_DATE, api.AP_DATE_PAY, api.AP_PAYMENT_HOLD, agl.AP_GLACODE, agl.AP_GLADESC, api.VN_PAY_TO_CODE

--Check Result ap_info
--SELECT * FROM #ap_info AS api
--ORDER BY api.AP_ID

--5. #ap_dtl to #ap_invoice
INSERT INTO #ap_invoice SELECT
	apd.AP_ID,
	apd.AP_SEQ,
	apd.[TYPE],
	api.VN_FRL_EMP_CODE,
	api.VN_NAME,
	api.AP_INV_VCHR,
	api.AP_INV_DATE,
	api.AP_DATE_PAY,
	0.00,
	api.AP_PAYMENT_HOLD,
	api.AP_GLACODE,
	api.AP_GLADESC,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	0.00,
	0.00,
	0.00,
	0.00,
	api.VN_PAY_TO_CODE,
	apd.CL_CODE,
	apd.DIV_CODE,
	apd.PRD_CODE,
	apd.AMOUNT,
	apd.TAX,
	apd.PERIOD,
	apd.GLACODE,
	gl.GLADESC,
	apd.AP_REFERENCE,
	apd.AR_INV_NBR,
	apd.AR_TYPE,
	apd.AR_INV_DATE,
	apd.AB_REFERENCE,
	apd.NON_BILLABLE
FROM #ap_dtl AS apd
JOIN #ap_info AS api ON apd.AP_ID = api.AP_ID
JOIN dbo.GLACCOUNT AS gl ON apd.GLACODE = gl.GLACODE

--Check Results ap_dtl to ap_invoice
--SELECT * FROM #ap_invoice AS api
--WHERE api.[TYPE] Not In ('AP','CK')
--ORDER BY api.AP_ID, api.[TYPE]

--Get days for aging
CREATE TABLE #aging_days(
	AP_ID				int NOT NULL,
	AGING_DAYS			int NOT NULL)
INSERT INTO #aging_days SELECT
	api.AP_ID,
	CASE 
		WHEN @aging_option = 2 THEN DATEDIFF(day,MAX(api.AP_DATE_PAY),@aging_date)
		ELSE DATEDIFF(day,MAX(api.AP_INV_DATE),@aging_date)
	END AS AGING_DAYS
FROM #ap_invoice AS api
GROUP BY api.AP_ID

--Check Result aging_days
--SELECT * FROM #aging_days AS ad
--ORDER BY ad.AP_ID

--Get open ap ids
CREATE TABLE #open_apids(
	AP_ID				int NOT NULL)
INSERT INTO #open_apids SELECT
	ap.AP_ID
FROM #ap_invoice AS ap
--WHERE ABS(SUM(ISNULL(ap.AP_BAL_AMT,0))) >=0.01
GROUP BY ap.AP_ID
HAVING (SUM(ISNULL(ap.AP_BAL_AMT,0)) <=-0.01 OR SUM(ISNULL(ap.AP_BAL_AMT,0))>=0.01)

--Check Results open_ids
--SELECT * FROM #open_apids
--ORDER BY AP_ID

--Get Result #ap_invoice
IF @detail_option = 1
	SELECT
		[ID] = NEWID(),
		[APIdentifier] = ap.AP_ID,
		[APSequence] = ap.AP_SEQ,
		[APType] = ap.[TYPE],
		[APDescription] = AP_HEADER.AP_DESC,
		[VendorCode] = ap.VN_FRL_EMP_CODE,
		[VendorName] = ap.VN_NAME,
		[VendorPayToCode] = ap.VN_PAY_TO_CODE,
		[VendorPayToName] = v.VN_NAME,
		[InvoiceNumber] = ap.AP_INV_VCHR,
		[InvoiceDate] = ap.AP_INV_DATE ,
		[DateToPay] = ap.AP_DATE_PAY,
		[APInvoiceAgingDays] = DATEDIFF(day,ap.AP_INV_DATE,@aging_date),
		[DaysToPayAging] = DATEDIFF(day,ap.AP_DATE_PAY,@aging_date),
		[TotalAmount] = ISNULL(ap.AP_TOT_AMT,0),
		[PaymentHold] = CASE WHEN ISNULL(ap.AP_PAYMENT_HOLD,0) = 1 THEN 'Yes' ELSE 'No' END,
		[GLAccountCode] = ap.AP_GLACODE,
		[GLAccountDescription] = ap.AP_GLADESC,
		[Period] = ap.AP_PERIOD,
		[APGlexact] = ap.AP_GLEXACT,
		[APGlseq] = ap.AP_GLESEQ,
		[CheckNumber] = ap.AP_CHK_NBR,
		[CheckDate] = ap.AP_CHK_DATE,
		[CheckAmount] = ISNULL(ap.AP_CHK_AMT,0),
		[DiscountAmount] = ISNULL(ap.AP_DISC_AMT,0),
		[VendorServiceTax] = ISNULL(ap.VENDOR_SERVICE_TAX,0),
		[BalanceAmount] = ISNULL(ap.AP_TOT_AMT,0) - (ISNULL(ap.AP_CHK_AMT,0) +  ISNULL(ap.AP_DISC_AMT,0) + ISNULL(ap.VENDOR_SERVICE_TAX,0)),
		[AgingDays] = ag.AGING_DAYS,
		[CurrentAmount] = CASE WHEN ag.AGING_DAYS <= 0 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[ThirtyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 1 AND 30 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[SixtyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 31 AND 60 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[NinetyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 61 AND 90 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END, 
		[OverNinetyDays] = CASE WHEN ag.AGING_DAYS > 90 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[ClientCode] = ap.DTL_CL_CODE,
		[DivisionCode] = ap.DTL_DIV_CODE,
		[ProductCode] = ap.DTL_PRD_CODE,
		[DetailAmount] = ISNULL(ap.DTL_AMOUNT,0),
		[DetailTax] = ISNULL(ap.DTL_TAX,0),
		[DetailPeriod] = ap.DTL_PERIOD,
		[DetailGLAccountCode] = ap.DTL_GLACODE,
		[DetailGLAccountDescription] = ap.DTL_GLADESC,
		[DetailReference] = ap.DTL_AP_REFERENCE,
		[DetailARInvoiceNumber] = ap.DTL_AR_INV_NBR,
		[DetailARType] = ap.DTL_AR_TYPE,
		[DetailARInvoiceDate] = ap.DTL_AR_INV_DATE,
		[DetailABReference] = ap.DTL_AB_REFERENCE,
		[DetailNonBillable] = ap.DTL_NON_BILLABLE
	FROM #ap_invoice As ap
	JOIN #aging_days AS ag ON ag.AP_ID = ap.AP_ID
	JOIN #open_apids AS oap ON oap.AP_ID = ap.AP_ID
	LEFT OUTER JOIN AP_HEADER ON AP_HEADER.AP_ID = ap.AP_ID AND AP_HEADER.AP_SEQ = ap.AP_SEQ
	LEFT OUTER JOIN VENDOR AS v ON ap.VN_PAY_TO_CODE = v.VN_CODE
	ORDER BY ap.VN_FRL_EMP_CODE, ap.AP_ID, ap.AP_INV_VCHR, ap.[TYPE], ap.AP_SEQ
ELSE
	SELECT
		[ID] = NEWID(),
		[APIdentifier] = ap.AP_ID,
		[APSequence] = ap.AP_SEQ,
		[APType] = ap.[TYPE],
		[APDescription] = AP_HEADER.AP_DESC,
		[VendorCode] = ap.VN_FRL_EMP_CODE,
		[VendorName] = ap.VN_NAME,
		[VendorPayToCode] = ap.VN_PAY_TO_CODE,
		[VendorPayToName] = v.VN_NAME,
		[InvoiceNumber] = ap.AP_INV_VCHR,
		[InvoiceDate] = ap.AP_INV_DATE ,
		[DateToPay] = ap.AP_DATE_PAY,
		[APInvoiceAgingDays] = DATEDIFF(day,ap.AP_INV_DATE,@aging_date),
		[DaysToPayAging] = DATEDIFF(day,ap.AP_DATE_PAY,@aging_date),
		[TotalAmount] = ISNULL(ap.AP_TOT_AMT,0),
		[PaymentHold] = CASE WHEN ISNULL(ap.AP_PAYMENT_HOLD,0) = 1 THEN 'Yes' ELSE 'No' END,
		[GLAccountCode] = ap.AP_GLACODE,
		[GLAccountDescription] = ap.AP_GLADESC,
		[Period] = ap.AP_PERIOD,
		[APGlexact] = ap.AP_GLEXACT,
		[APGlseq] = ap.AP_GLESEQ,
		[CheckNumber] = ap.AP_CHK_NBR,
		[CheckDate] = ap.AP_CHK_DATE,
		[CheckAmount] = ISNULL(ap.AP_CHK_AMT,0),
		[DiscountAmount] = ISNULL(ap.AP_DISC_AMT,0),
		[VendorServiceTax] = ISNULL(ap.VENDOR_SERVICE_TAX,0),
		[BalanceAmount] = ISNULL(ap.AP_TOT_AMT,0) - (ISNULL(ap.AP_CHK_AMT,0) +  ISNULL(ap.AP_DISC_AMT,0) + ISNULL(ap.VENDOR_SERVICE_TAX,0)),
		[AgingDays] = ag.AGING_DAYS,
		[CurrentAmount] = CASE WHEN ag.AGING_DAYS <= 0 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[ThirtyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 1 AND 30 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[SixtyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 31 AND 60 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END,
		[NinetyDays] = CASE WHEN ag.AGING_DAYS BETWEEN 61 AND 90 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END, 
		[OverNinetyDays] = CASE WHEN ag.AGING_DAYS > 90 THEN ISNULL(ap.AP_BAL_AMT,0) ELSE 0 END
	FROM #ap_invoice AS ap
	JOIN #aging_days AS ag ON ag.AP_ID = ap.AP_ID
	JOIN #open_apids AS oap ON oap.AP_ID = ap.AP_ID
	LEFT OUTER JOIN AP_HEADER ON AP_HEADER.AP_ID = ap.AP_ID AND AP_HEADER.AP_SEQ = ap.AP_SEQ 
	LEFT OUTER JOIN VENDOR AS v ON ap.VN_PAY_TO_CODE = v.VN_CODE
	ORDER BY ap.VN_FRL_EMP_CODE, ap.AP_ID, ap.AP_INV_VCHR, ap.[TYPE], ap.AP_SEQ

END
GO

BEGIN

	GRANT ALL ON [advsp_acct_payable_mo_end] to PUBLIC AS dbo

END
GO