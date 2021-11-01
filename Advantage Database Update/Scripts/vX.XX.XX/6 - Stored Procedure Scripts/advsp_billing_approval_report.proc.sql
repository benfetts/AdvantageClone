--Billing Approval Query and Report Started 11/19/2020
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (Select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_billing_approval_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_billing_approval_report]

GO

CREATE PROCEDURE [dbo].[advsp_billing_approval_report](
	@include_option AS smallint = 1,
	@from_inv_date AS datetime = '1/1/1900',
	@to_inv_date AS datetime = '12/31/2900',
	@include_jobs AS smallint = 1,
	@ACCT_EXEC_LIST AS varchar(MAX) = NULL,
	@CLIENT_LIST AS varchar(MAX) = NULL,
	@DIVISION_LIST AS varchar(MAX) = NULL,
	@PRODUCT_LIST AS varchar(MAX) = NULL,
	@JOB_LIST AS varchar(MAX) = NULL,
	@USER_CODE AS varchar(100))

	--@include_option 1 = All, 2 = Billed, 3 = Unbilled
	--@from_inv_date and @to_inv_date enable and apply when @include_option = 2
	--@include_jobs 1 = Open Only, 2 = Open and Closed
	--@ACCT_EXEC_LIST applies to BILL_APPR_HDR.ACCT_EXEC for this report, not to JOB_COMPONENT.EMP_CODE

AS
BEGIN
SET NOCOUNT ON;

--==================================
--CREATE MAIN DATA TABLE
--==================================
CREATE TABLE #BillingApprovalData (
	BillingApprovalID		int NOT NULL,
	AccountExecutiveCode	varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientCode				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionCode			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductCode				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	JobNumber				int NOT NULL,
	JobComponentNumber		smallint NOT NULL,
	ARInvoiceNumber			int,
	ARInvoiceDate			datetime,
	GroupOrder				smallint,
	RecordType				varchar(12)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	UseAmountType			varchar(1)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	HeaderApprovalAmount	decimal(15,2),
	HeaderApprovalComment	varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	HeaderClientComment		varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	FunctionCode			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	DetailApprovalID		int,
	DetailApprovalAmount	decimal(15,2),
	DetailApprovalComment	varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	DetailClientComment		varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS)

--====================================
--CREATE AND POPULATE SECONDARY TABLES
--====================================
--Create list jobs for selected CDP and Open/Closed status.
CREATE TABLE #JobList (
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL)
INSERT INTO #JobList
SELECT
	jc.JOB_NUMBER,
	jc.JOB_COMPONENT_NBR
FROM dbo.JOB_LOG AS jl
JOIN dbo.advtf_user_job_limits(@USER_CODE) ul ON jl.JOB_NUMBER = ul.JOB_NUMBER
JOIN dbo.JOB_COMPONENT AS jc ON jl.JOB_NUMBER = jc.JOB_NUMBER
WHERE (
	1 = CASE WHEN @include_jobs = 1 AND (jc.JOB_PROCESS_CONTRL = 6 OR jc.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
	(jl.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST,',')) OR @CLIENT_LIST IS NULL) AND 
	1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (jl.CL_CODE+'|'+jl.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST,',')) THEN 1 ELSE 0 END AND
	1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (jl.CL_CODE+'|'+jl.DIV_CODE+'|'+jl.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST,',')) THEN 1 ELSE 0 END) AND
	(jc.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL)
GROUP BY jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR
--SELECT * FROM #JobList

--Get Billed Max BA_ID by Job/Component and AR Invoice
CREATE TABLE #MaxApprovalIDBilled (
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	AR_INV_NBR			int NULL,
	BA_ID				int NOT NULL)
IF @include_option IN (1,2)
	INSERT INTO #MaxApprovalIDBilled
	SELECT
		ah.JOB_NUMBER,
		ah.JOB_COMPONENT_NBR,
		ah.AR_INV_NBR,
		MAX(ah.BA_ID)
	FROM dbo.BILL_APPR_HDR AS ah
	JOIN #JobList AS jl ON ah.JOB_NUMBER = jl.JOB_NUMBER AND ah.JOB_COMPONENT_NBR = jl.JOB_COMPONENT_NBR
	WHERE (ah.AR_INV_NBR IS NOT NULL AND ah.INVOICE_DATE BETWEEN @from_inv_date AND @to_inv_date)
	GROUP BY ah.JOB_NUMBER, ah.JOB_COMPONENT_NBR, ah.AR_INV_NBR

--Get Unbilled Max BA_ID by Job/Component
CREATE TABLE #MaxApprovalIDUnbilled (
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	BA_ID				int NOT NULL)
IF @include_option IN (1,3)
	INSERT INTO #MaxApprovalIDUnbilled
	SELECT
		ah.JOB_NUMBER,
		ah.JOB_COMPONENT_NBR,
		MAX(ah.BA_ID)
	FROM dbo.BILL_APPR_HDR AS ah
	JOIN #JobList AS jl ON ah.JOB_NUMBER = jl.JOB_NUMBER AND ah.JOB_COMPONENT_NBR = jl.JOB_COMPONENT_NBR
	WHERE ah.AR_INV_NBR IS NULL
	GROUP BY ah.JOB_NUMBER, ah.JOB_COMPONENT_NBR

--Get Billing Approval Header Data for selected cdp/jobs, max ba_id and selected AEs
CREATE TABLE #BillingApprovalHeader (
	BA_ID				int NOT NULL,
	ACCT_EXEC			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER			int NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	AR_INV_NBR			int NULL,
	INVOICE_DATE		datetime,
	REC_TYPE			varchar(12)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	USE_AMT_TYPE		varchar(1)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	APPROVED_AMT		decimal(15,2),
	APPR_COMMENTS		varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_COMMENTS		varchar(MAX)	COLLATE SQL_Latin1_General_CP1_CS_AS)
--Billed Approval Header Data
IF @include_option IN (1,2)
	INSERT INTO #BillingApprovalHeader
	SELECT
		ah.BA_ID,
		ah.ACCT_EXEC,
		jl.CL_CODE,
		jl.DIV_CODE,
		jl.PRD_CODE,
		ah.JOB_NUMBER,
		ah.JOB_COMPONENT_NBR,
		ah.AR_INV_NBR,
		ah.INVOICE_DATE,
		'Header',
		CASE WHEN ISNULL(ah.APPROVED_AMT,0) = 0 THEN 'D' ELSE 'H' END,
		ISNULL(ah.APPROVED_AMT,0),
		ah.APPR_COMMENTS,
		ah.CLIENT_COMMENTS
	FROM dbo.BILL_APPR_HDR AS ah
	JOIN dbo.JOB_LOG AS jl ON ah.JOB_NUMBER = jl.JOB_NUMBER
	JOIN #MaxApprovalIDBilled AS id ON ah.JOB_NUMBER = id.JOB_NUMBER AND ah.JOB_COMPONENT_NBR = id.JOB_COMPONENT_NBR AND ah.AR_INV_NBR = id.AR_INV_NBR AND ah.BA_ID = id.BA_ID
	WHERE (ah.ACCT_EXEC IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL)
--Unbilled Approval Header Data
IF @include_option IN (1,3)
	INSERT INTO #BillingApprovalHeader
	SELECT
		ah.BA_ID,
		ah.ACCT_EXEC,
		jl.CL_CODE,
		jl.DIV_CODE,
		jl.PRD_CODE,
		ah.JOB_NUMBER,
		ah.JOB_COMPONENT_NBR,
		ah.AR_INV_NBR,
		ah.INVOICE_DATE,
		'Header',
		CASE WHEN ISNULL(ah.APPROVED_AMT,0) = 0 THEN 'D' ELSE 'H' END,
		ah.APPROVED_AMT,
		ah.APPR_COMMENTS,
		ah.CLIENT_COMMENTS
	FROM dbo.BILL_APPR_HDR AS ah
	JOIN dbo.JOB_LOG AS jl ON ah.JOB_NUMBER = jl.JOB_NUMBER
	JOIN #MaxApprovalIDUnbilled AS id ON ah.JOB_NUMBER = id.JOB_NUMBER AND ah.JOB_COMPONENT_NBR = id.JOB_COMPONENT_NBR AND ah.BA_ID = id.BA_ID
	WHERE (ah.AR_INV_NBR IS NULL AND (ah.ACCT_EXEC IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL))
--SELECT * FROM #BillingApprovalHeader
--ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR, BA_ID, AR_INV_NBR

--========================
--POPULATE MAIN DATA TABLE
--========================
--Append Billing Approval Header to Billing Approval Data
INSERT INTO #BillingApprovalData
SELECT
	BA_ID,
	ACCT_EXEC,
	CL_CODE,
	DIV_CODE,
	PRD_CODE,
	JOB_NUMBER,
	JOB_COMPONENT_NBR,
	AR_INV_NBR,
	INVOICE_DATE,
	1,
	REC_TYPE,
	USE_AMT_TYPE,
	ISNULL(APPROVED_AMT,0),
	APPR_COMMENTS,
	CLIENT_COMMENTS,
	NULL,
	NULL,
	0.00,
	NULL,
	NULL
FROM #BillingApprovalHeader

--Append Billing Approval Detail to Billing Approval Data
INSERT INTO #BillingApprovalData
SELECT
	ba.BillingApprovalID,
	ba.AccountExecutiveCode,
	ba.ClientCode,
	ba.DivisionCode,
	ba.ProductCode,
	ba.JobNumber,
	ba.JobComponentNumber,
	ba.ARInvoiceNumber,
	ba.ARInvoiceDate,
	2,
	'Detail',
	ba.UseAmountType,
	0,
	NULL,
	NULL,
	ad.FNC_CODE,
	ad.BA_DTL_ID,
	ISNULL(ad.APPROVED_AMT,0),
	ad.FNC_COMMENTS,
	ad.CLIENT_COMMENTS
FROM #BillingApprovalData AS ba
JOIN dbo.BILL_APPR_DTL AS ad ON ad.BA_ID = ba.BillingApprovalID AND ad.JOB_NUMBER = ba.JobNumber AND ad.JOB_COMPONENT_NBR = ba.JobComponentNumber

UPDATE #BillingApprovalData 
SET HeaderApprovalAmount = (SELECT SUM(DetailApprovalAmount) FROM #BillingApprovalData bh WHERE bh.BillingApprovalID = #BillingApprovalData.BillingApprovalID AND bh.JobNumber = #BillingApprovalData.JobNumber AND bh.JobComponentNumber = #BillingApprovalData.JobComponentNumber)
WHERE RecordType = 'Header'

--===================
--QUERY / REPORT DATA
--===================
SELECT
	AccountExecutiveCode,
	emp.EMP_FNAME AS AEFirstName,
	emp.EMP_LNAME AS AELastName,
	COALESCE((RTRIM(emp.EMP_FNAME) + ' '),'') + COALESCE(emp.EMP_LNAME,'') AS AEName,
	ClientCode,
	cl.CL_NAME AS ClientName,
	DivisionCode,
	div.DIV_NAME AS DivisionName,
	ProductCode,
	prd.PRD_DESCRIPTION AS ProductDescription,
	JobNumber,
	jl.JOB_DESC AS JobDescription,
	JobComponentNumber,
	jc.JOB_COMP_DESC AS JobComponentDescription,
	BillingApprovalID,
    BillingBatchID = bill.BA_BATCH_ID,
	ARInvoiceNumber,
	ARInvoiceDate,
	GroupOrder,
	RecordType,
	HeaderApprovalAmount,
	HeaderApprovalComment,
	HeaderClientComment,
	FunctionCode,
	fnc.FNC_DESCRIPTION AS FunctionDescription,
	DetailApprovalID,
	DetailApprovalAmount,
	DetailApprovalComment,
	DetailClientComment
FROM #BillingApprovalData AS ba
JOIN dbo.EMPLOYEE AS emp ON emp.EMP_CODE = ba.AccountExecutiveCode
JOIN dbo.CLIENT AS cl ON cl.CL_CODE = ba.ClientCode
JOIN dbo.DIVISION AS div ON div.CL_CODE = ba.ClientCode AND div.DIV_CODE = ba.DivisionCode
JOIN dbo.PRODUCT AS prd ON prd.CL_CODE = ba.ClientCode AND prd.DIV_CODE = ba.DivisionCode AND prd.PRD_CODE = ba.ProductCode
JOIN dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = ba.JobNumber
JOIN dbo.JOB_COMPONENT AS jc ON jc.JOB_NUMBER = ba.JobNumber AND jc.JOB_COMPONENT_NBR = ba.JobComponentNumber
LEFT JOIN dbo.FUNCTIONS AS fnc ON fnc.FNC_CODE = ba.FunctionCode
LEFT JOIN dbo.BILL_APPR AS bill ON bill.BA_ID = ba.BillingApprovalID
ORDER BY AccountExecutiveCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, ARInvoiceNumber, GroupOrder, FunctionCode

END
GO

BEGIN

	GRANT ALL ON [advsp_billing_approval_report] TO PUBLIC AS dbo

END
GO