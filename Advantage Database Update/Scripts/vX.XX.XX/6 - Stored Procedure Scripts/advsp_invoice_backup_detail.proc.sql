SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO

IF EXISTS (Select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_invoice_backup_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_invoice_backup_detail]

GO

CREATE PROCEDURE [dbo].[advsp_invoice_backup_detail] (
	@start_date		datetime = '1/1/1900',
	@end_date		datetime = '12/31/2199',
	@CLIENT_LIST AS varchar(MAX) = NULL)

AS
BEGIN
SET NOCOUNT ON;

-- INVOICE BACKUP DETAIL TABLE #InvoiceBackupDetail
CREATE TABLE #InvoiceBackupDetail(
	ClientCode			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientName			varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionCode		varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionName		varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductCode			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductDescription	varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	TypeCode			varchar(2)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ARInvoiceNumber		Int NOT NULL,	
	LineNumber  		smallint NULL,
	InvoiceDate			smalldatetime,
	DueDate				smalldatetime,
	VendorCode			varchar(6)	COLLATE	SQL_Latin1_General_CP1_CS_AS,
	VendorName			varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	FunctionCode		varchar(6)	COLLATE	SQL_Latin1_General_CP1_CS_AS,
	FunctionDescription	varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	InvoiceNumber		varchar(26)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	Amount				decimal(14,2),
	JobNumber			int,
	JobComponentNbr		smallint)

-- AR INVOICE SELECTION #ARInvoiceData
CREATE TABLE #ARInvoiceData(
	ClientCode			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientName			varchar(40)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionCode		varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionName		varchar(40)	COLLATE	SQL_Latin1_General_CP1_CS_AS,
	ProductCode			varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductDescription	varchar(40)	COLLATE	SQL_Latin1_General_CP1_CS_AS,
	ARInvoiceNumber		int NOT NULL,
	InvoiceDate			smalldatetime,
	DueDate				smalldatetime,
	OrderNumber			int NULL,
	OrderLineNbr		smallint NULL,
	JobNumber			int NULL,
	JobComponentNbr		smallint NULL,
	FunctionCode		varchar(6)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	FunctionDescription	varchar(30)	COLLATE	SQL_Latin1_General_CP1_CS_AS)

DECLARE @cr_detail TABLE (
	AR_INV_NBR					int NOT NULL,
	AR_INV_SEQ					smallint NOT NULL,
	CR_PAY_AMT_TOT				decimal(15,2),
	CR_DEP_DATE_LAST			smalldatetime,
	CR_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS
	UNIQUE (AR_INV_NBR, AR_INV_SEQ) 
	)

--DECLARE @ar_cr_detail TABLE (
--	JOB_NUMBER					int,
--	JOB_COMPONENT_NBR			smallint,
--	AR_INV_NBR					int NOT NULL,
--	AR_INV_SEQ					smallint NOT NULL,
--	AR_INV_DATE					smalldatetime,
--	DUE_DATE					smalldatetime,
--	PAY_DAYS					int,
--	--JC_INV_AMOUNT				decimal(15,2),
--	AR_INV_AMOUNT				decimal(15,2),
--	CR_TOT_AMT					decimal(15,2),	/* CR_PAY_AMT + CR_ADJ_AMT */
--	CR_CHECK_DATE_LAST			smalldatetime,
--	INV_BALANCE					decimal(15,2),
--	DAYS_TO_PAY					int,
--	PENDING_CR					bit,
--	SALE_POST_PERIOD			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
--	CR_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS
--	UNIQUE (AR_INV_NBR, AR_INV_SEQ, JOB_NUMBER, JOB_COMPONENT_NBR) 
--	)

/* PJH 09/16/20 - Changed DUE_DATE to calculate if IS NULL */
INSERT INTO #ARInvoiceData
SELECT
	ars.CL_CODE,
	cl.CL_NAME,
	ars.DIV_CODE,
	div.DIV_NAME,
	ars.PRD_CODE,
	prd.PRD_DESCRIPTION,
	ars.AR_INV_NBR,
	ar.AR_INV_DATE,
	CASE WHEN ar.DUE_DATE IS NOT NULL THEN ar.DUE_DATE ELSE CASE WHEN MAX(ar.REC_TYPE) = 'P' THEN ar.AR_INV_DATE + ISNULL(MAX(cl.CL_P_PAYDAYS),0) ELSE ar.AR_INV_DATE + ISNULL(MAX(cl.CL_M_PAYDAYS),0) END END,
	ars.ORDER_NBR,
	ars.ORDER_LINE_NBR,
	ars.JOB_NUMBER,
	ars.JOB_COMPONENT_NBR,
	ars.FNC_CODE,
	fnc.FNC_DESCRIPTION
FROM dbo.AR_SUMMARY AS ars
JOIN dbo.ACCT_REC as ar ON ars.AR_INV_NBR = ar.AR_INV_NBR AND ars.AR_INV_SEQ = ar.AR_INV_SEQ AND ars.AR_TYPE = ar.AR_TYPE
JOIN dbo.CLIENT AS cl ON ars.CL_CODE = cl.CL_CODE
JOIN dbo.DIVISION AS div ON ars.CL_CODE = div.CL_CODE AND ars.DIV_CODE = div.DIV_CODE
JOIN dbo.PRODUCT AS prd ON ars.CL_CODE = prd.CL_CODE AND ars.DIV_CODE = prd.DIV_CODE AND ars.PRD_CODE = prd.PRD_CODE
LEFT JOIN dbo.FUNCTIONS AS fnc ON ars.FNC_CODE = fnc.FNC_CODE
WHERE (ar.AR_INV_SEQ IN (0,99) AND (ar.AR_INV_DATE BETWEEN @start_date AND @end_date) AND (ar.VOID_FLAG = 0 OR ar.VOID_FLAG IS NULL))
GROUP BY ars.CL_CODE, cl.CL_NAME, ars.DIV_CODE, div.DIV_NAME, ars.PRD_CODE, prd.PRD_DESCRIPTION, ars.AR_INV_NBR, ars.ORDER_NBR, ars.ORDER_LINE_NBR, ars.JOB_NUMBER, ars.JOB_COMPONENT_NBR, ars.FNC_CODE, fnc.FNC_DESCRIPTION, ar.AR_INV_DATE, ar.DUE_DATE

INSERT INTO @cr_detail
	SELECT A.AR_INV_NBR, 0 AS AR_INV_SEQ, SUM(CR_TOT_AMT) CR_PAY_AMT_TOT, MAX(CR_DEP_DATE) CR_DEP_DATE_LAST, MAX(POST_PERIOD) MAX_POST_PERIOD FROM (
	SELECT A.AR_INV_NBR, A.AR_INV_SEQ, COALESCE(CR_PAY_AMT,0) + COALESCE(CR_ADJ_AMT, 0) CR_TOT_AMT, B.CR_DEP_DATE, A.POST_PERIOD
	FROM CR_CLIENT_DTL A 
	JOIN CR_CLIENT B ON A.REC_ID = B.REC_ID AND A.SEQ_NBR = B.SEQ_NBR
	JOIN #ARInvoiceData C ON C.ARInvoiceNumber = A.AR_INV_NBR
	) A 
	GROUP BY A.AR_INV_NBR--, A.AR_INV_SEQ

--AP HEADER MAXSEQ #APHeaderMaxSeq
CREATE TABLE #APHeaderMaxSeq(
	AP_ID	int NOT NULL,
	AP_SEQ	smallint NOT NULL)

INSERT INTO #APHeaderMaxSeq
SELECT
	ah.AP_ID,
	MAX(ah.AP_SEQ) AS AP_SEQ
FROM dbo.AP_HEADER AS ah
GROUP BY ah.AP_ID

--BEGIN GET DETAIL
--PRODUCTION
--AP PRODUCTION
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	ard.FunctionCode,
	ard.FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.AP_PROD_EXT_AMT,0)+ISNULL(apd.EXT_NONRESALE_TAX,0)) AS Amount,
	MIN(ard.JobNumber),
	NULL
FROM #ARInvoiceData AS ard
JOIN dbo.AP_PRODUCTION AS apd ON ard.ARInvoiceNumber = apd.AR_INV_NBR AND ard.JobNumber = apd.JOB_NUMBER AND ard.JobComponentNbr = apd.JOB_COMPONENT_NBR AND ard.FunctionCode = apd.FNC_CODE
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ard.FunctionCode, ard.FunctionDescription, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--TIME
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'ET' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	NULL AS VendorCode,
	NULL AS VendorName,
	Null AS FunctionCode,
	Null AS FunctionDescription,
	Null AS InvoiceNumber,
	SUM(ISNULL(etd.TOTAL_BILL,0)+ISNULL(etd.EXT_MARKUP_AMT,0)) AS Amount,
	(ard.JobNumber),
	(ard.JobComponentNbr)
FROM #ARInvoiceData AS ard
JOIN dbo.EMP_TIME_DTL AS etd ON ard.ARInvoiceNumber = etd.AR_INV_NBR AND ard.JobNumber = etd.JOB_NUMBER AND ard.JobComponentNbr = etd.JOB_COMPONENT_NBR AND ard.FunctionCode = etd.FNC_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ard.InvoiceDate, ard.DueDate, ard.JobNumber, ard.JobComponentNbr

--INCOME ONLY
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'IO' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	Null AS VendorCode,
	Null AS VendorName,
	ard.FunctionCode,
	ard.FunctionDescription,
	io.IO_INV_NBR AS InvoiceNumber,
	SUM(ISNULL(io.IO_AMOUNT,0)+ISNULL(io.EXT_MARKUP_AMT,0)),
	--MIN(ard.JobNumber),
	--NULL
	(ard.JobNumber),
	(ard.JobComponentNbr)
FROM #ARInvoiceData AS ard
JOIN dbo.INCOME_ONLY AS io ON ard.ARInvoiceNumber = io.AR_INV_NBR AND ard.JobNumber = io.JOB_NUMBER AND ard.JobComponentNbr = io.JOB_COMPONENT_NBR AND ard.FunctionCode = io.FNC_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ard.FunctionCode, ard.FunctionDescription, io.IO_INV_NBR, ard.InvoiceDate,ard.DueDate, ard.JobNumber, ard.JobComponentNbr

--MEDIA
--AP INTERNET
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.NET_AMT,0)+ISNULL(apd.NETCHARGES,0)+ISNULL(apd.VENDOR_TAX,0)+ISNULL(apd.DISCOUNT_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_INTERNET AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN INTERNET_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--AP MAGAZINE
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.DISBURSED_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_MAGAZINE AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN MAGAZINE_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--AP NEWSPAPER
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.DISBURSED_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_NEWSPAPER AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN NEWSPAPER_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--AP OUTDOOR
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.NET_AMT,0)+ISNULL(apd.NETCHARGES,0)+ISNULL(apd.VENDOR_TAX,0)+ISNULL(apd.DISCOUNT_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_OUTDOOR AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN OUTDOOR_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--AP RADIO
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.EXT_NET_AMT,0)+ISNULL(apd.NETCHARGES,0)+ISNULL(apd.VENDOR_TAX,0)+ISNULL(apd.DISC_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_RADIO AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN RADIO_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

--AP TELEVISION
INSERT INTO #InvoiceBackupDetail
SELECT
	ard.ClientCode,
	ard.ClientName,
	ard.DivisionCode,
	ard.DivisionName,
	ard.ProductCode,
	ard.ProductDescription,
	'AP' AS TypeCode,
	ard.ARInvoiceNumber,
	NULL,
	ard.InvoiceDate,
	ard.DueDate,
	ah.VN_FRL_EMP_CODE AS VendorCode,
	vn.VN_NAME AS VendorName,
	'media' AS FunctionCode,
	'Media' AS FunctionDescription,
	ah.AP_INV_VCHR AS InvoiceNumber,
	SUM(ISNULL(apd.EXT_NET_AMT,0)+ISNULL(apd.NETCHARGES,0)+ISNULL(apd.VENDOR_TAX,0)+ISNULL(apd.DISC_AMT,0)) AS Amount,
	MIN(B.JOB_NUMBER) AS JobNumber,
	NULL AS JobComponentNbr
FROM #ARInvoiceData AS ard
JOIN dbo.AP_TV AS apd ON ard.OrderNumber = apd.ORDER_NBR AND ard.OrderLineNbr = apd.ORDER_LINE_NBR
JOIN TV_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR AND B.ACTIVE_REV = 1
JOIN dbo.AP_HEADER AS ah ON apd.AP_ID = ah.AP_ID
JOIN #APHeaderMaxSeq AS ahms ON ahms.AP_ID = ah.AP_ID AND ahms.AP_SEQ = ah.AP_SEQ
JOIN dbo.VENDOR AS vn ON ah.VN_FRL_EMP_CODE = vn.VN_CODE
GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ah.VN_FRL_EMP_CODE, vn.VN_NAME, ah.AP_INV_VCHR, ard.InvoiceDate,ard.DueDate

DECLARE @id int
SET @id = 0

UPDATE #InvoiceBackupDetail
SET LineNumber = @id, @id = @id + 1
--SET LineNumber = ROW_NUMBER() OVER (PARTITION BY ARInvoiceNumber ORDER BY ARInvoiceNumber)

/*************************/
 --SELECT ClientCode,
	--    ClientName,
	--	DivisionCode,
	--	DivisionName,
	--	ProductCode,
	--	ProductDescription,
	--	TypeCode,
	--	ARInvoiceNumber,
	--	LineNumber, --ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS LineNumber,
	--	InvoiceDate,
	--	DueDate,
	--	VendorCode,
	--	VendorName,
	--	FunctionCode,
	--	FunctionDescription,
	--	InvoiceNumber,
	--	Amount,
	--	InvoiceDateShort = REPLACE(CONVERT(VARCHAR(15), InvoiceDate, 1),'/',''),
	--	JobNumber,
	--	JobComponentNbr,
	--	ARInvoicePaid = CASE WHEN ISNULL(B.CR_PAY_AMT_TOT, 0) > 0 THEN 'Y' ELSE 'N' END,
	--	DateARPaid = CASE WHEN ISNULL(B.CR_PAY_AMT_TOT, 0) > 0 THEN B.CR_DEP_DATE_LAST ELSE NULL END
	--	FROM #InvoiceBackupDetail A LEFT JOIN
	--		@cr_detail B ON B.AR_INV_NBR = A.ARInvoiceNumber
	--	WHERE (ClientCode IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL)
	--	--ORDER BY ClientCode
	--	ORDER BY ARInvoiceNumber, TypeCode
/************************/

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APP' '-', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, ard.FunctionCode, ard.InvoiceNumber, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN dbo.AP_PRODUCTION AS apd ON ard.ARInvoiceNumber = apd.AR_INV_NBR AND ard.JobNumber = apd.JOB_NUMBER AND ard.FunctionCode = apd.FNC_CODE
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber	
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

--UPDATE A
--SET A.JobComponentNbr = B.JobComponentNbr
--FROM #InvoiceBackupDetail A
--    INNER JOIN (
--		SELECT 'IO' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
--		JOIN dbo.INCOME_ONLY AS io ON ard.ARInvoiceNumber = io.AR_INV_NBR AND ard.JobNumber = io.JOB_NUMBER AND ard.FunctionCode = io.FNC_CODE AND (ard.InvoiceNumber = io.IO_INV_NBR OR io.IO_INV_NBR IS NULL)
--		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber
--	) B ON A.LineNumber = B.LineNumber
--WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

--UPDATE A
--SET A.JobComponentNbr = B.JobComponentNbr
--FROM #InvoiceBackupDetail A
--    INNER JOIN (
--		SELECT 'ET' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
--		JOIN dbo.EMP_TIME_DTL AS etd ON ard.ARInvoiceNumber = etd.AR_INV_NBR AND ard.JobNumber = etd.JOB_NUMBER --AND ard.JobComponentNbr = etd.JOB_COMPONENT_NBR --AND ard.FunctionCode = etd.FNC_CODE
--		GROUP BY ard.ClientCode, ard.ClientName, ard.DivisionCode, ard.DivisionName, ard.ProductCode, ard.ProductDescription, ard.ARInvoiceNumber, ard.InvoiceDate,ard.DueDate, ard.JobNumber--, ard.InvoiceNumber
--	) B ON A.LineNumber = B.LineNumber
--WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'API' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_INTERNET AS apd 
				JOIN INTERNET_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APN' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_NEWSPAPER AS apd 
				JOIN NEWSPAPER_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APM' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_MAGAZINE AS apd 
				JOIN MAGAZINE_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0) 


UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APO' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_OUTDOOR AS apd 
				JOIN OUTDOOR_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APT' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_TV AS apd 
				JOIN TV_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)

UPDATE A
SET A.JobComponentNbr = B.JobComponentNbr
FROM #InvoiceBackupDetail A
    INNER JOIN (
		SELECT 'APR' '--', JobNumber, MIN(JOB_COMPONENT_NBR) JobComponentNbr, ARInvoiceNumber, FunctionCode, InvoiceNumber, VendorCode, MAX(ard.LineNumber) LineNumber FROM #InvoiceBackupDetail ard
		JOIN (SELECT JOB_NUMBER, JOB_COMPONENT_NBR, AR_INV_NBR FROM dbo.AP_RADIO AS apd 
				JOIN RADIO_DETAIL B ON apd.ORDER_NBR = B.ORDER_NBR AND apd.ORDER_LINE_NBR = B.LINE_NBR) D ON ard.ARInvoiceNumber = D.AR_INV_NBR AND ard.JobNumber = D.JOB_NUMBER
		GROUP BY ARInvoiceNumber, JobNumber, FunctionCode, InvoiceNumber, VendorCode
	) B ON A.LineNumber = B.LineNumber
WHERE ISNULL(A.JobComponentNbr,0) <> ISNULL(B.JobComponentNbr,0)


--SELECT * FROM #ARInvoiceData
--SELECT * FROM #APHeaderMaxSeq
 SELECT ClientCode,
	    ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductDescription,
		TypeCode,
		ARInvoiceNumber,
		LineNumber = CAST(LineNumber AS BIGINT), --ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS LineNumber,
		InvoiceDate,
		DueDate,
		VendorCode,
		VendorName,
		FunctionCode,
		FunctionDescription,
		InvoiceNumber,
		Amount,
		InvoiceDateShort = REPLACE(CONVERT(VARCHAR(15), InvoiceDate, 1),'/',''),
		JobNumber,
		JobComponentNbr,
		ARInvoicePaid = CASE WHEN ISNULL(B.CR_PAY_AMT_TOT, 0) > 0 THEN 'Y' ELSE 'N' END,
		DateARPaid = CASE WHEN ISNULL(B.CR_PAY_AMT_TOT, 0) > 0 THEN B.CR_DEP_DATE_LAST ELSE NULL END
		FROM #InvoiceBackupDetail A LEFT JOIN
			@cr_detail B ON B.AR_INV_NBR = A.ARInvoiceNumber
		WHERE (ClientCode IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL)
		--ORDER BY ClientCode
		ORDER BY ARInvoiceNumber, TypeCode

END
GO

BEGIN

	GRANT ALL ON [advsp_invoice_backup_detail] to PUBLIC AS dbo

END
GO