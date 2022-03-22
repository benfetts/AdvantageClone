SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (Select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_def_sales_ar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[advsp_def_sales_ar]

GO

CREATE PROCEDURE [dbo].[advsp_def_sales_ar] (
	@period_cutoff			varchar(6),
	@include_media			smallint = 1,
    @UserID                 varchar(100))

	--Parameters
	--@include_media: 1 = Production Only, 2 = Production and Media

-- August 9, 2018
-- Stored procedure to compare open deferred sales vs. open accounts receivable

AS
BEGIN
SET NOCOUNT ON;

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER, @Restrictions INT

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);

-- ====================================
-- MAIN DATA TABLE #DefSalesOpenAR
-- ====================================
CREATE TABLE #DefSalesOpenAR (
	OFFICE_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CL_CODE				varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CL_NAME				varchar(40)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DIV_NAME			varchar(40)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	PRD_DESCRIPTION		varchar(40)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AR_INV_AMOUNT		decimal(15,2) NULL,
	DEF_SALE_AMOUNT		decimal(15,2) NULL,
	CR_AMOUNT			decimal(15,2) NULL,
	AR_BALANCE			decimal(15,2) NULL)

-- ========================================
-- SECONDARY TABLE #OpenAcctRec
-- ========================================
CREATE TABLE #OpenAcctRec (
	OFFICE_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CL_CODE				varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,					
	AR_INV_NBR			integer,		
	AR_INV_SEQ			smallint,
	AR_INV_DATE			date,
	AR_INV_AMOUNT		decimal(15,2) NULL,
	CR_PAY_AMT			decimal(15,2) NULL,
	CR_ADJ_AMT			decimal(15,2) NULL,
	CR_TOTAL			decimal(15,2) NULL,
	AR_BALANCE			decimal(15,2) NULL,
	MANUAL_INV			smallint,
	VOID_FLAG			smallint)

-- =========================================
-- SECONDARY TABLE #DeferredSales
-- =========================================
CREATE TABLE #DeferredSales (
	AR_INV_NBR			integer,
	AR_INV_SEQ			smallint,
	DEFERRED_SALES		decimal(15,2) NULL,
	DEFFERED_COST		decimal(15,2) NULL)

-- =========================================
-- AUXILIARY TABLE #InvoicesAndReceipts
-- =========================================
CREATE TABLE #InvoicesAndReceipts (
	REC_TYPE			varchar(2)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CL_CODE				varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,					
	AR_INV_NBR			integer,
	AR_INV_SEQ			smallint,
	AR_TYPE				varchar(3)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE			date,
	POST_PERIOD			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AR_INV_AMOUNT		decimal(15,2) NULL,
	CR_PAY_AMT			decimal(15,2) NULL,
	CR_ADJ_AMT			decimal(15,2) NULL,
	MANUAL_INV			smallint,
	VOID_FLAG			smallint)

-- ==========================================
-- AUXILIARY TABLE #ClientReceipts
-- ==========================================
CREATE TABLE #ClientReceipts (
	AR_INV_NBR			integer,
	AR_INV_SEQ			smallint,
	AR_TYPE				varchar(3)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CR_PAY_AMT			decimal(15,2) NULL,
	CR_ADJ_AMT			decimal(15,2) NULL,
	POST_PERIOD			varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- ==========================================
-- AUXILIARY TABLE #Sales
-- ==========================================
CREATE TABLE #Sales (
	MANUAL_INV			integer,
	REC_TYPE			varchar(1)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR			integer,
	AR_INV_SEQ			smallint,
	AR_POST_PERIOD		varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	SALE_POST_PERIOD	varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AB_REC_FLAG			smallint,
	MED_REC_FLAG		smallint,	
	TOTAL_BILLED		decimal(15,2) NULL,
	TOTAL_COST			decimal(15,2) NULL,
	SALES				decimal(15,2) NULL,
	COST_OF_SALES		decimal(15,2) NULL,
	STATE_TAX			decimal(15,2) NULL,
	COUNTY_TAX			decimal(15,2) NULL,
	CITY_TAX			decimal(15,2) NULL)

-- ==========================================
-- BEGIN DATA GATHER
-- ==========================================
-- OPEN ACCOUNTS RECEIVABLE
-- ==========================================
-- Invoices
-- ==========================================
INSERT INTO #InvoicesAndReceipts
SELECT
	'AR',
	ar.OFFICE_CODE,
	ar.CL_CODE,
	ar.DIV_CODE,
	ar.PRD_CODE,
	ar.AR_INV_NBR,
	ar.AR_INV_SEQ,
	ar.AR_TYPE,
	ar.AR_INV_DATE,
	ar.AR_POST_PERIOD,
	ar.AR_INV_AMOUNT,
	0,
	0,
	ISNULL(ar.MANUAL_INV,0),
	ISNULL(ar.VOID_FLAG,0)
FROM dbo.ACCT_REC AS ar
WHERE (AR_INV_SEQ IN (0,99) AND AR_POST_PERIOD <= @period_cutoff)

-- ===================================================================
-- Client Receipts (Join CR_DETAIL with CR_CLIENT, Set coop seq to 99)
-- ===================================================================
INSERT INTO #ClientReceipts
SELECT
	crd.AR_INV_NBR,
	CASE
		WHEN crd.AR_INV_SEQ <> 0 THEN 99
		ELSE ISNULL(crd.AR_INV_SEQ,0)
	END AS AR_INV_SEQ,
	crd.AR_TYPE,
	SUM(ISNULL(crd.CR_PAY_AMT,0)),
	SUM(ISNULL(crd.CR_ADJ_AMT,0)),
	ISNULL(crd.POST_PERIOD,cr.POST_PERIOD)
FROM dbo.CR_CLIENT_DTL AS crd
	JOIN dbo.CR_CLIENT as cr
	ON (crd.REC_ID = cr.REC_ID AND crd.SEQ_NBR = cr.SEQ_NBR)
GROUP BY crd.AR_INV_NBR, AR_INV_SEQ, crd.AR_TYPE, ISNULL(crd.POST_PERIOD,cr.POST_PERIOD)

-- ===================================================
-- Cash Receipts
-- ===================================================
INSERT INTO #InvoicesAndReceipts
SELECT
	'CR',
	ar.OFFICE_CODE,
	ar.CL_CODE,
	ar.DIV_CODE,
	ar.PRD_CODE,
	cr.AR_INV_NBR,
	cr.AR_INV_SEQ,
	cr.AR_TYPE,
	ar.AR_INV_DATE,
	cr.POST_PERIOD,
	0,
	cr.CR_PAY_AMT,
	cr.CR_ADJ_AMT,
	ISNULL(ar.MANUAL_INV,0),
	ISNULL(ar.VOID_FLAG,0)
FROM #ClientReceipts As cr
	JOIN dbo.ACCT_REC AS ar
	ON (cr.AR_INV_NBR = ar.AR_INV_NBR AND cr.AR_INV_SEQ = ar.AR_INV_SEQ AND cr.AR_TYPE = ar.AR_TYPE)
WHERE cr.POST_PERIOD <= @period_cutoff

-- ====================================
-- Open Accounts Receivable
-- ====================================
INSERT INTO #OpenAcctRec
SELECT
	ar.OFFICE_CODE,
	ar.CL_CODE,
	ar.DIV_CODE,
	ar.PRD_CODE,
	ar.AR_INV_NBR,
	ar.AR_INV_SEQ,
	ar.AR_INV_DATE,
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)),
	SUM(ISNULL(ar.CR_PAY_AMT,0)),
	SUM(ISNULL(ar.CR_ADJ_AMT,0)),
	SUM(ISNULL(ar.CR_PAY_AMT,0))+SUM(ISNULL(ar.CR_ADJ_AMT,0)),
	SUM(ISNULL(ar.AR_INV_AMOUNT,0))-(SUM(ISNULL(ar.CR_PAY_AMT,0))+SUM(ISNULL(ar.CR_ADJ_AMT,0))),
	ISNULL(ar.MANUAL_INV,0),
	MAX(ISNULL(ar.VOID_FLAG,0))
FROM #InvoicesAndReceipts AS ar
GROUP BY ar.OFFICE_CODE, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.AR_INV_NBR, ar.AR_INV_SEQ, ar.AR_INV_DATE, ar.MANUAL_INV
HAVING (MAX(ISNULL(ar.VOID_FLAG,0))=0 OR (MAX(ISNULL(ar.VOID_FLAG,0))=1 AND SUM(ar.AR_INV_AMOUNT)<>0))

-- =======================================
-- SALES
-- =======================================
-- Production Billing
-- =======================================
INSERT INTO #Sales
SELECT
	0,
	'P',
	ars.AR_INV_NBR,
	ars.AR_INV_SEQ,
	ar.AR_POST_PERIOD,
	ars.SALE_POST_PERIOD,
	ISNULL(ars.AB_REC_FLAG,0),
	ISNULL(ars.MED_REC_FLAG,0),
	SUM(ISNULL(ars.TOTAL_BILL,0)),
	SUM(ISNULL(ars.COST_AMT,0)+ISNULL(ars.NET_CHARGE_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.DISCOUNT_AMT,0)+ISNULL(ars.AB_COST_AMT,0)+ISNULL(ars.AB_NONRESALE_AMT,0)),
	CASE
		WHEN ars.SALE_POST_PERIOD>@period_cutoff THEN 0
		WHEN (ars.SALE_POST_PERIOD<=@period_cutoff AND ars.AB_REC_FLAG<>2) THEN SUM(ISNULL(ars.EMP_TIME_AMT,0)+ISNULL(ars.INC_ONLY_AMT,0)+ISNULL(ars.COMMISSION_AMT,0)+ISNULL(ars.COST_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.AB_SALE_AMT,0))
			ELSE SUM(ISNULL(ars.EMP_TIME_AMT,0)+ISNULL(ars.INC_ONLY_AMT,0)+ISNULL(ars.COMMISSION_AMT,0)+ISNULL(ars.COST_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.AB_SALE_AMT,0)+ISNULL(ars.AB_COST_AMT,0)+ISNULL(ars.AB_INC_AMT,0)+ISNULL(ars.AB_COMMISSION_AMT,0)+ISNULL(ars.AB_NONRESALE_AMT,0))
	END AS SALES,
	CASE
		WHEN ars.SALE_POST_PERIOD>@period_cutoff THEN 0
		WHEN (ars.SALE_POST_PERIOD<=@period_cutoff AND ars.AB_REC_FLAG<>2) THEN SUM(ISNULL(ars.COST_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0))
			ELSE SUM(ISNULL(ars.COST_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.AB_COST_AMT,0)+ISNULL(ars.AB_NONRESALE_AMT,0))
	END AS COST_OF_SALES,
	SUM(ISNULL(STATE_TAX_AMT,0)),
	SUM(ISNULL(CNTY_TAX_AMT,0)),
	SUM(ISNULL(CITY_TAX_AMT,0))
FROM dbo.AR_SUMMARY AS ars
	JOIN dbo.ACCT_REC AS ar ON ars.AR_INV_NBR = ar.AR_INV_NBR AND ars.AR_INV_SEQ = ar.AR_INV_SEQ AND ars.AR_TYPE = ar.AR_TYPE
WHERE (ar.AR_POST_PERIOD<=@period_cutoff AND ISNULL(ars.MEDIA_TYPE,'P')='P')
GROUP BY ars.AR_INV_NBR, ars.AR_INV_SEQ, ar.AR_POST_PERIOD, ars.SALE_POST_PERIOD, ars.AB_REC_FLAG, ars.MED_REC_FLAG
HAVING ars.AR_INV_SEQ IN (0,99)

-- ========================================
-- Media Billing
-- ========================================
IF @include_media = 2
INSERT INTO #Sales
SELECT
	0,
	'M',
	ars.AR_INV_NBR,
	ars.AR_INV_SEQ,
	ar.AR_POST_PERIOD,
	ars.SALE_POST_PERIOD,
	ISNULL(ars.AB_REC_FLAG,0),
	ISNULL(ars.MED_REC_FLAG,0),
	SUM(ISNULL(ars.TOTAL_BILL,0)),
	SUM(ISNULL(ars.COST_AMT,0)+ISNULL(ars.NET_CHARGE_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.DISCOUNT_AMT,0)),
	CASE
		WHEN ars.SALE_POST_PERIOD>@period_cutoff THEN 0
		ELSE SUM(ISNULL(ars.COMMISSION_AMT,0)+ISNULL(ars.REBATE_AMT,0)+ISNULL(ars.COST_AMT,0)+ISNULL(ars.NET_CHARGE_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.DISCOUNT_AMT,0)+ISNULL(ars.ADDITIONAL_AMT,0))
	END AS SALES,
	CASE
		WHEN ars.SALE_POST_PERIOD>@period_cutoff THEN 0
		ELSE SUM(ISNULL(ars.COST_AMT,0)+ISNULL(ars.NET_CHARGE_AMT,0)+ISNULL(ars.NON_RESALE_AMT,0)+ISNULL(ars.DISCOUNT_AMT,0))
	END AS COST_OF_SALES,
	SUM(ISNULL(ars.STATE_TAX_AMT,0)),
	SUM(ISNULL(ars.CNTY_TAX_AMT,0)),
	SUM(ISNULL(ars.CITY_TAX_AMT,0))
FROM dbo.AR_SUMMARY AS ars
	JOIN dbo.ACCT_REC AS ar ON ars.AR_INV_NBR = ar.AR_INV_NBR AND ars.AR_INV_SEQ = ar.AR_INV_SEQ AND ars.AR_TYPE = ar.AR_TYPE
WHERE (ar.AR_POST_PERIOD<=@period_cutoff AND ISNULL(ars.MEDIA_TYPE,'P')<>'P')
GROUP BY ars.AR_INV_NBR, ars.AR_INV_SEQ, ar.AR_POST_PERIOD, ars.SALE_POST_PERIOD, ars.AB_REC_FLAG, ars.MED_REC_FLAG
HAVING ars.AR_INV_SEQ IN (0,99)

-- =======================================
-- Production Manual Invoices
-- =======================================
INSERT INTO #Sales
SELECT
	1,
	'P',
	ar.AR_INV_NBR,
	ar.AR_INV_SEQ,
	ar.AR_POST_PERIOD,
	ar.AR_POST_PERIOD AS SALE_POST_PERIOD,
	0,
	0,
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)),
	SUM(ISNULL(ar.AR_COS_AMT,0)),
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)-(ISNULL(ar.AR_STATE_AMT,0)+ISNULL(ar.AR_COUNTY_AMT,0)+ISNULL(ar.AR_CITY_AMT,0))),
	SUM(ISNULL(ar.AR_COS_AMT,0)),
	SUM(ISNULL(ar.AR_STATE_AMT,0)),
	SUM(ISNULL(ar.AR_COUNTY_AMT,0)),
	SUM(ISNULL(ar.AR_CITY_AMT,0))
FROM dbo.ACCT_REC AS ar
WHERE (ar.AR_POST_PERIOD <= @period_cutoff AND ISNULL(ar.MANUAL_INV,0)=1 AND ar.REC_TYPE IN ('S','P'))
GROUP BY ar.AR_INV_NBR, ar.AR_INV_SEQ, ar.AR_POST_PERIOD

-- =======================================
-- Media Manual Invoices
-- =======================================
IF @include_media = 2
INSERT INTO #Sales
SELECT
	1,
	'M',
	ar.AR_INV_NBR,
	ar.AR_INV_SEQ,
	ar.AR_POST_PERIOD,
	ar.AR_POST_PERIOD AS SALE_POST_PERIOD,
	0,
	0,
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)),
	SUM(ISNULL(ar.AR_COS_AMT,0)),
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)-(ISNULL(ar.AR_STATE_AMT,0)+ISNULL(ar.AR_COUNTY_AMT,0)+ISNULL(ar.AR_CITY_AMT,0))),
	SUM(ISNULL(ar.AR_COS_AMT,0)),
	SUM(ISNULL(ar.AR_STATE_AMT,0)),
	SUM(ISNULL(ar.AR_COUNTY_AMT,0)),
	SUM(ISNULL(ar.AR_CITY_AMT,0))
FROM dbo.ACCT_REC AS ar
WHERE (ar.AR_POST_PERIOD <= @period_cutoff AND ISNULL(ar.MANUAL_INV,0)=1 AND ar.REC_TYPE NOT IN ('S','P'))
GROUP BY ar.AR_INV_NBR, ar.AR_INV_SEQ, ar.AR_POST_PERIOD

-- ============================
-- DEFERRED SALES
-- ============================
INSERT INTO #DeferredSales
SELECT
	s.AR_INV_NBR,
	s.AR_INV_SEQ,
	SUM(ISNULL(s.TOTAL_BILLED,0)-(ISNULL(s.SALES,0)+ISNULL(s.STATE_TAX,0)+ISNULL(s.COUNTY_TAX,0)+ISNULL(s.CITY_TAX,0))),
	SUM(ISNULL(s.TOTAL_COST,0)-ISNULL(s.COST_OF_SALES,0))
FROM #Sales AS s
GROUP BY s.AR_INV_NBR, s.AR_INV_SEQ

-- =================================
-- DEFERRED SALES VS. OPEN AR
-- =================================
INSERT INTO #DefSalesOpenAR
SELECT
	ar.OFFICE_CODE,
	ar.CL_CODE,
    NULL,
	ar.DIV_CODE,
    NULL,
	ar.PRD_CODE,
    NULL,
	SUM(ISNULL(ar.AR_INV_AMOUNT,0)),
	SUM(ISNULL(ds.DEFERRED_SALES,0)),
	SUM(ISNULL(ar.CR_TOTAL,0)),
	SUM(ISNULL(ar.AR_BALANCE,0))
FROM #OpenAcctRec AS ar
	LEFT JOIN #DeferredSales AS ds ON ar.AR_INV_NBR = ds.AR_INV_NBR AND ar.AR_INV_SEQ = ds.AR_INV_SEQ
GROUP BY ar.OFFICE_CODE, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE
HAVING SUM(ISNULL(ds.DEFERRED_SALES,0))<>0

UPDATE #DefSalesOpenAR
SET CL_NAME = (SELECT CL_NAME FROM CLIENT WHERE CLIENT.CL_CODE = #DefSalesOpenAR.CL_CODE)
WHERE CL_NAME IS NULL

UPDATE #DefSalesOpenAR
SET DIV_NAME = (SELECT DIV_NAME FROM DIVISION WHERE DIVISION.CL_CODE = #DefSalesOpenAR.CL_CODE AND DIVISION.DIV_CODE = #DefSalesOpenAR.DIV_CODE)
WHERE DIV_NAME IS NULL

UPDATE #DefSalesOpenAR
SET PRD_DESCRIPTION = (SELECT PRD_DESCRIPTION FROM PRODUCT WHERE PRODUCT.CL_CODE = #DefSalesOpenAR.CL_CODE AND PRODUCT.DIV_CODE = #DefSalesOpenAR.DIV_CODE AND PRODUCT.PRD_CODE = #DefSalesOpenAR.PRD_CODE)
WHERE PRD_DESCRIPTION IS NULL

--SELECT * FROM #DefSalesOpenAR

IF @RestrictionsOffice > 0
	BEGIN
        IF @Restrictions > 0
        BEGIN
            SELECT #DefSalesOpenAR.OFFICE_CODE AS OfficeCode,
                   O.OFFICE_NAME AS OfficeName,
                   #DefSalesOpenAR.CL_CODE AS ClientCode,
                   #DefSalesOpenAR.CL_NAME AS ClientName,
                   #DefSalesOpenAR.DIV_CODE AS DivisionCode,
                   #DefSalesOpenAR.DIV_NAME AS DivisionName,
                   #DefSalesOpenAR.PRD_CODE AS ProductCode,
                   #DefSalesOpenAR.PRD_DESCRIPTION AS ProductName,
                   AR_INV_AMOUNT AS ARInvoiceAmount,
                   DEF_SALE_AMOUNT AS DeferredSales,
                   CR_AMOUNT AS ClientReceiptsTotal,
                   AR_BALANCE AS ARBalance  
            FROM #DefSalesOpenAR INNER JOIN
			     OFFICE O ON O.OFFICE_CODE = #DefSalesOpenAR.OFFICE_CODE INNER JOIN 
                 EMP_OFFICE ON #DefSalesOpenAR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE INNER JOIN 
                 SEC_CLIENT ON #DefSalesOpenAR.CL_CODE = SEC_CLIENT.CL_CODE AND #DefSalesOpenAR.DIV_CODE = SEC_CLIENT.DIV_CODE AND #DefSalesOpenAR.PRD_CODE = SEC_CLIENT.PRD_CODE
            WHERE SEC_CLIENT.[USER_ID] = @UserId  AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0)
          
        END
        ELSE
        BEGIN
            SELECT #DefSalesOpenAR.OFFICE_CODE AS OfficeCode,
                   O.OFFICE_NAME AS OfficeName,
                   #DefSalesOpenAR.CL_CODE AS ClientCode,
                   #DefSalesOpenAR.CL_NAME AS ClientName,
                   #DefSalesOpenAR.DIV_CODE AS DivisionCode,
                   #DefSalesOpenAR.DIV_NAME AS DivisionName,
                   #DefSalesOpenAR.PRD_CODE AS ProductCode,
                   #DefSalesOpenAR.PRD_DESCRIPTION AS ProductName,
                   AR_INV_AMOUNT AS ARInvoiceAmount,
                   DEF_SALE_AMOUNT AS DeferredSales,
                   CR_AMOUNT AS ClientReceiptsTotal,
                   AR_BALANCE AS ARBalance  
            FROM #DefSalesOpenAR INNER JOIN
			     OFFICE O ON O.OFFICE_CODE = #DefSalesOpenAR.OFFICE_CODE INNER JOIN 
                 EMP_OFFICE ON #DefSalesOpenAR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
        END		
	END
Else 
    BEGIN
        IF @Restrictions > 0
        BEGIN
            SELECT #DefSalesOpenAR.OFFICE_CODE AS OfficeCode,
                   O.OFFICE_NAME AS OfficeName,
                   #DefSalesOpenAR.CL_CODE AS ClientCode,
                   #DefSalesOpenAR.CL_NAME AS ClientName,
                   #DefSalesOpenAR.DIV_CODE AS DivisionCode,
                   #DefSalesOpenAR.DIV_NAME AS DivisionName,
                   #DefSalesOpenAR.PRD_CODE AS ProductCode,
                   #DefSalesOpenAR.PRD_DESCRIPTION AS ProductName,
                   AR_INV_AMOUNT AS ARInvoiceAmount,
                   DEF_SALE_AMOUNT AS DeferredSales,
                   CR_AMOUNT AS ClientReceiptsTotal,
                   AR_BALANCE AS ARBalance  
            FROM #DefSalesOpenAR INNER JOIN
			     OFFICE O ON O.OFFICE_CODE = #DefSalesOpenAR.OFFICE_CODE INNER JOIN 
                 SEC_CLIENT ON #DefSalesOpenAR.CL_CODE = SEC_CLIENT.CL_CODE AND #DefSalesOpenAR.DIV_CODE = SEC_CLIENT.DIV_CODE AND #DefSalesOpenAR.PRD_CODE = SEC_CLIENT.PRD_CODE
            WHERE SEC_CLIENT.[USER_ID] = @UserId  AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0)            
        END
        ELSE
        BEGIN
            SELECT #DefSalesOpenAR.OFFICE_CODE AS OfficeCode,
                   O.OFFICE_NAME AS OfficeName,
                   #DefSalesOpenAR.CL_CODE AS ClientCode,
                   #DefSalesOpenAR.CL_NAME AS ClientName,
                   #DefSalesOpenAR.DIV_CODE AS DivisionCode,
                   #DefSalesOpenAR.DIV_NAME AS DivisionName,
                   #DefSalesOpenAR.PRD_CODE AS ProductCode,
                   #DefSalesOpenAR.PRD_DESCRIPTION AS ProductName,
                   AR_INV_AMOUNT AS ARInvoiceAmount,
                   DEF_SALE_AMOUNT AS DeferredSales,
                   CR_AMOUNT AS ClientReceiptsTotal,
                   AR_BALANCE AS ARBalance  
            FROM #DefSalesOpenAR INNER JOIN
			     OFFICE O ON O.OFFICE_CODE = #DefSalesOpenAR.OFFICE_CODE
        END
    END
END
GO

BEGIN

	GRANT ALL ON [advsp_def_sales_ar] TO PUBLIC AS dbo

END
GO