--7/16/2020 Stored procedure for Advantage Month End Reports combining all data from legacy series (700) accrued_liability and voucher_advance_billing.

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_accrued_liability_mo_end]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_accrued_liability_mo_end]
GO

CREATE PROCEDURE [dbo].[advsp_accrued_liability_mo_end] (
	@office_list AS varchar(4000) = '',
	@end_period varchar(6) = '999912')
AS
BEGIN
SET NOCOUNT ON;

--=============================================
--MAIN DATA TABLE #accrued_liability
--=============================================
CREATE TABLE #accrued_liability (
	OFFICE_CODE			varchar(4)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_NAME			varchar(30)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE				varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_NAME				varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_NAME			varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_DESCRIPTION		varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	SC_CODE				varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	SC_DESCRIPTION		varchar(30)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER			int NOT NULL,
	JOB_DESC			varchar(60)	COLLATE SQL_Latin1_General_CP1_CS_AS,		
	JOB_COMPONENT_NBR	smallint NOT NULL,
	JOB_COMP_DESC		varchar(60)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_CODE			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_DESCRIPTION		varchar(30)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE				varchar(30)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLADESC				varchar(75)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE			varchar(2)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_POST_PERIOD		varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE			smalldatetime,
	AR_INV_NUMBER		int,
	AR_TYPE				varchar(2)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_BILL_NET_AMT	decimal(14,2) NULL,
	AP_PROD_NET_AMT		decimal(14,2) NULL,
    AP_JOB_FLAG         tinyint,
    ACCURED_AMT_JCF     decimal(14,2) NULL)

--=============================================
--Temp Table #job_list for selected offices
--=============================================
CREATE TABLE #job_list (JOB_NUMBER int NOT NULL)
INSERT INTO #job_list
SELECT jl.JOB_NUMBER
FROM dbo.JOB_LOG AS jl
WHERE (jl.OFFICE_CODE IN (SELECT * FROM dbo.fn_charlist_to_table2(@office_list)) OR @office_list = '')
--SELECT * FROM #job_list

--=============================================
--Temp Table #adv_bill_filter advance bill jobs
--=============================================
CREATE TABLE #adv_bill_filter (
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	GLACODE				varchar(30)	COLLATE SQL_Latin1_General_CP1_CS_AS)

--=============================================
--Get Accrued Liability from Advance Billing
--=============================================
INSERT INTO #accrued_liability
SELECT
	jl.OFFICE_CODE,
	o.OFFICE_NAME,
	jl.CL_CODE,
	cl.CL_NAME,
	jl.DIV_CODE,
	dv.DIV_NAME,
	jl.PRD_CODE,
	pd.PRD_DESCRIPTION,
	jl.SC_CODE,
	sc.SC_DESCRIPTION,
	ab.JOB_NUMBER,
	jl.JOB_DESC,
	ab.JOB_COMPONENT_NBR,
	jc.JOB_COMP_DESC,
	ab.FNC_CODE,
	fn.FNC_DESCRIPTION,
	ab.GLACODE_ACC_AP,
	ga.GLADESC,
	'BL',
	CASE ISNULL(ab.AB_FLAG,0)
		WHEN 3 THEN gh.GLEHPP
		ELSE ar.AR_POST_PERIOD
	END AS AR_POST_PERIOD,
	CASE ISNULL(ab.AB_FLAG,0)
		WHEN 3 THEN gh.GLEHENTDATE
		ELSE ar.AR_INV_DATE
	END AS AR_INV_DATE,
	ab.AR_INV_NBR,
	ab.AR_TYPE,
	SUM(ISNULL(ab.ADV_BILL_NET_AMT,0)+ISNULL(ab.EXT_NONRESALE_TAX,0)),
	0 AS AP_PROD_NET_AMT,
    0,
    0
FROM dbo.ADVANCE_BILLING AS ab
JOIN #job_list AS j ON ab.JOB_NUMBER = j.JOB_NUMBER
JOIN dbo.JOB_LOG AS jl ON ab.JOB_NUMBER = jl.JOB_NUMBER
JOIN dbo.OFFICE AS o ON jl.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS sc ON jl.SC_CODE = sc.SC_CODE
JOIN dbo.CLIENT AS cl ON jl.CL_CODE = cl.CL_CODE
JOIN dbo.DIVISION AS dv ON jl.CL_CODE = dv.CL_CODE AND jl.DIV_CODE = dv.DIV_CODE
JOIN dbo.PRODUCT AS pd ON jl.CL_CODE = pd.CL_CODE AND jl.DIV_CODE = pd.DIV_CODE AND jl.PRD_CODE = pd.PRD_CODE
JOIN dbo.JOB_COMPONENT AS jc ON ab.JOB_NUMBER = jc.JOB_NUMBER AND ab.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
JOIN dbo.FUNCTIONS AS fn ON ab.FNC_CODE = fn.FNC_CODE
LEFT JOIN dbo.GLACCOUNT AS ga ON ab.GLACODE_ACC_AP = ga.GLACODE
LEFT JOIN dbo.V_AR_INVOICE_DATES AS ar ON ab.AR_INV_NBR = ar.AR_INV_NBR AND ab.AR_TYPE = ar.AR_TYPE
LEFT JOIN dbo.GLENTHDR AS gh ON ab.GLEXACT = gh.GLEHXACT
WHERE ab.GLACODE_ACC_AP IS NOT NULL
	AND ((ISNULL(ab.AB_FLAG,0) <> 3 AND ar.AR_POST_PERIOD <= @end_period)
	OR (ab.AB_FLAG = 3 AND gh.GLEHPP <= @end_period))
GROUP BY jl.OFFICE_CODE, o.OFFICE_NAME, jl.CL_CODE, cl.CL_NAME, jl.DIV_CODE, dv.DIV_NAME, jl.PRD_CODE, pd.PRD_DESCRIPTION,
	jl.SC_CODE, sc.SC_DESCRIPTION, ab.JOB_NUMBER, jl.JOB_DESC, ab.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, ab.FNC_CODE, fn.FNC_DESCRIPTION,
	ab.GLACODE_ACC_AP, ga.GLADESC, ab.AB_FLAG, gh.GLEHPP, ar.AR_POST_PERIOD, gh.GLEHENTDATE, ar.AR_INV_DATE, ab.AR_INV_NBR, ab.AR_TYPE
--SELECT * FROM #accrued_liability

--Populate #adv_bill_filter
INSERT INTO #adv_bill_filter
SELECT
	JOB_NUMBER,
	JOB_COMPONENT_NBR,
	MAX(GLACODE)
FROM #accrued_liability
WHERE REC_TYPE = 'BL'
GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR
--SELECT * FROM #adv_bill_filter

--==============================================
--Get AP Vouchers from AP Production for AB Jobs
--==============================================
INSERT INTO #accrued_liability
SELECT
	jl.OFFICE_CODE,
	o.OFFICE_NAME,
	jl.CL_CODE,
	cl.CL_NAME,
	jl.DIV_CODE,
	dv.DIV_NAME,
	jl.PRD_CODE,
	pd.PRD_DESCRIPTION,
	jl.SC_CODE,
	sc.SC_DESCRIPTION,
	ap.JOB_NUMBER,
	jl.JOB_DESC,
	ap.JOB_COMPONENT_NBR,
	jc.JOB_COMP_DESC,
	ap.FNC_CODE,
	fn.FNC_DESCRIPTION,
	j.GLACODE,
	ga.GLADESC,
	'AP',
	NULL,
	NULL,
	NULL,
	NULL,
	0 AS ADV_BILL_NET_AMT,
	SUM(ISNULL(ap.AP_PROD_EXT_AMT,0)+ISNULL(ap.EXT_NONRESALE_TAX,0)),
    0,
    0
FROM dbo.AP_PRODUCTION AS ap
JOIN #adv_bill_filter AS j ON ap.JOB_NUMBER = j.JOB_NUMBER AND ap.JOB_COMPONENT_NBR = j.JOB_COMPONENT_NBR
JOIN dbo.JOB_LOG AS jl ON ap.JOB_NUMBER = jl.JOB_NUMBER
JOIN dbo.OFFICE AS o ON jl.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS sc ON jl.SC_CODE = sc.SC_CODE
JOIN dbo.CLIENT AS cl ON jl.CL_CODE = cl.CL_CODE
JOIN dbo.DIVISION AS dv ON jl.CL_CODE = dv.CL_CODE AND jl.DIV_CODE = dv.DIV_CODE
JOIN dbo.PRODUCT AS pd ON jl.CL_CODE = pd.CL_CODE AND jl.DIV_CODE = pd.DIV_CODE AND jl.PRD_CODE = pd.PRD_CODE
JOIN dbo.JOB_COMPONENT AS jc ON ap.JOB_NUMBER = jc.JOB_NUMBER AND ap.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
JOIN dbo.FUNCTIONS AS fn ON ap.FNC_CODE = fn.FNC_CODE
LEFT JOIN dbo.GLACCOUNT AS ga ON j.GLACODE = ga.GLACODE
LEFT JOIN dbo.V_AR_INVOICE_DATES AS ar ON ap.AR_INV_NBR = ar.AR_INV_NBR AND ap.AR_TYPE = ar.AR_TYPE
LEFT JOIN dbo.GLENTHDR AS gh ON ap.GLEXACT = gh.GLEHXACT
WHERE ISNULL(ap.AP_PROD_NOBILL_FLG,0) = 0
	AND ((ISNULL(ap.AB_FLAG,0) <> 3 AND ap.AR_INV_NBR IS NULL AND ap.POST_PERIOD <= @end_period)
	OR (ap.POST_PERIOD <= @end_period AND ar.AR_POST_PERIOD > @end_period)
	OR (ap.AB_FLAG = 3 AND ap.POST_PERIOD <= @end_period AND gh.GLEHPP > @end_period))
GROUP BY jl.OFFICE_CODE, o.OFFICE_NAME, jl.CL_CODE, cl.CL_NAME, jl.DIV_CODE, dv.DIV_NAME, jl.PRD_CODE, pd.PRD_DESCRIPTION,
	jl.SC_CODE, sc.SC_DESCRIPTION, ap.JOB_NUMBER, jl.JOB_DESC, ap.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, ap.FNC_CODE, fn.FNC_DESCRIPTION,
	j.GLACODE, ga.GLADESC
HAVING ABS(SUM(ISNULL(ap.AP_PROD_EXT_AMT,0)+ISNULL(ap.EXT_NONRESALE_TAX,0))) >= 0.01

--Final Filter Jobs with Accrued Liability >0 Only
CREATE TABLE #accrued_liability_filter (
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL)
INSERT INTO #accrued_liability_filter
SELECT JOB_NUMBER, JOB_COMPONENT_NBR
FROM #accrued_liability
GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR
HAVING ABS(SUM(ISNULL(ADV_BILL_NET_AMT,0))) >=0.01


CREATE TABLE #accrued_sum (
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	AL_AMT				decimal(15,2) NULL,
	AP_AMT				decimal(15,2) NULL)

INSERT INTO #accrued_sum
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, SUM(ADV_BILL_NET_AMT), SUM(AP_PROD_NET_AMT)
FROM #accrued_liability GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR


UPDATE #accrued_liability
SET AP_JOB_FLAG = CASE WHEN (SELECT AL_AMT FROM #accrued_sum WHERE JOB_NUMBER = #accrued_liability.JOB_NUMBER AND JOB_COMPONENT_NBR = #accrued_liability.JOB_COMPONENT_NBR) < (SELECT AP_AMT FROM #accrued_sum WHERE JOB_NUMBER = #accrued_liability.JOB_NUMBER AND JOB_COMPONENT_NBR = #accrued_liability.JOB_COMPONENT_NBR) THEN 1 ELSE 0 END


CREATE TABLE #accrued_function (
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
    FNC_CODE			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	AC_AMT				decimal(15,2) NULL)

INSERT INTO #accrued_function
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, SUM(ADV_BILL_NET_AMT)
FROM #accrued_liability GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE


UPDATE #accrued_liability
SET ACCURED_AMT_JCF = (SELECT AC_AMT FROM #accrued_function WHERE JOB_NUMBER = #accrued_liability.JOB_NUMBER AND JOB_COMPONENT_NBR = #accrued_liability.JOB_COMPONENT_NBR AND FNC_CODE = #accrued_liability.FNC_CODE)



--Final Query
SELECT
	[ID] = NEWID(),
	a.OFFICE_CODE AS [OfficeCode],
	a.OFFICE_NAME AS [OfficeName],
	a.CL_CODE AS [ClientCode],
	a.CL_NAME AS [ClientName],
	a.DIV_CODE AS [DivisionCode],
	a.DIV_NAME AS [DivisionName],
	a.PRD_CODE AS [ProductCode],
	a.PRD_DESCRIPTION AS [ProductDescription],
	a.SC_CODE AS [SalesClassCode],
	a.SC_DESCRIPTION AS [SalesClassDescription],
	a.JOB_NUMBER AS [JobNumber],
	a.JOB_DESC AS [JobDescription],
	a.JOB_COMPONENT_NBR AS [JobComponentNumber],
	a.JOB_COMP_DESC AS [JobComponentDescription],
	a.FNC_CODE AS [FunctionCode],
	a.FNC_DESCRIPTION AS [FunctionDescription],
	a.GLACODE AS [GLAccoountCode],
	a.GLADESC AS [GLAccountDesc],
	a.REC_TYPE AS [RecordType],
	a.AR_POST_PERIOD AS [ARPostingPeriod],
	a.AR_INV_DATE AS [ARInvoiceDate],
	a.AR_INV_NUMBER AS [ARInvoiceNumber],
	a.AR_TYPE AS [ARType],
	a.ADV_BILL_NET_AMT AS [AccruedLiabilityAmount],
	a.AP_PROD_NET_AMT AS [APInvoiceAmount],
    a.AP_JOB_FLAG AS [APLimitedJobFlag],
    a.ACCURED_AMT_JCF AS [AccruedLiabilityAmountFunction]
FROM #accrued_liability AS a
JOIN #accrued_liability_filter AS af ON a.JOB_NUMBER = af.JOB_NUMBER AND a.JOB_COMPONENT_NBR = af.JOB_COMPONENT_NBR
ORDER BY a.GLACODE, a.CL_CODE, a.DIV_CODE, a.PRD_CODE, a.JOB_NUMBER, a.JOB_COMPONENT_NBR, a.FNC_CODE, a.REC_TYPE DESC, a.AR_POST_PERIOD,
	a.AR_INV_DATE, a.AR_INV_NUMBER, a.AR_TYPE

END
GO

BEGIN

	GRANT ALL ON [advsp_accrued_liability_mo_end] to PUBLIC AS dbo

END
GO