if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_cash_transactions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_cash_transactions]
GO

CREATE PROCEDURE [dbo].[advsp_cash_transactions] (
	@bank_list				varchar(MAX) = NULL,
	@start_period			varchar(6) = '190001',
	@end_period				varchar(6) = '219912',
	@include_receipts		bit = 1,
	@include_disbursements	bit = 1,
	@include_glentries		bit = 1,
	@cleared_option			smallint = 1,
	@statement_cutoff		datetime = '12/31/2199')

	-- Parameters
	-- @cleared_option: 1 = Cleared and uncleared, 2 = Uncleared only (as of @statement cutoff)
	-- @statement_cutoff:  Enable and apply value entered when @cleared_option = 2

-- June 19, 2018
-- Stored procedure to extract cash transactions from all optional sources
-- REF and REF_DESC: 1 = Client Receipts, 2 = Other Receipts, 3 = Cash Disbursements (checks issued and checks voided), 4 = GL Entries

AS
BEGIN
SET NOCOUNT ON;

-- ========================================
-- MAIN DATA TABLE #CashTransactions
-- ========================================
CREATE TABLE #CashTransactions(
	BK_CODE			varchar(4)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	BK_DESCRIPTION	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLACODE			varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLADESC			varchar(75)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD		varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLXACT			integer,
	REF				smallint,
	REF_DESCRIPTION	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CHECK_NBR		varchar(15)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CHECK_DATE		smalldatetime,			
	PAYEE_PAYOR		varchar(200)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AMOUNT			decimal(15,2) NULL,
	VOID_FLAG		smallint,
	VOID_PERIOD		varchar(6)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CLEARED			smallint,
	REC_STMT_DATE	datetime,
	RECON_FLAG		smallint,
	CREATE_DATE	    datetime,
    DEP_DATE        datetime)

-- ========================================
-- SECONDARY TABLE #APPmtHist
-- ========================================
CREATE TABLE #APPmtHist(
	BK_CODE			varchar(4)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AP_CHK_NBR		integer,
	GLACODE_CASH	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLEXACT			integer)

-- ========================================
-- SECONDARY TABLE #Bank
-- ========================================
CREATE TABLE #Bank(
	BK_CODE			varchar(4)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	BK_DESCRIPTION	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLACODE_CASH	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	TYPE			varchar(2)			COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- ========================================
-- SECONDARY TABLE #BankCashAccts
-- ========================================
CREATE TABLE #BankCashAccts(
	BK_CODE			varchar(4)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	BK_DESCRIPTION	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GLACODE_CASH	varchar(30)			COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- ========================================
-- BEGIN DATA GATHER

-- ========================================
-- CASH RECEIPTS
-- ========================================
-- Client Receipts
-- ========================================
IF @include_receipts = 1
	INSERT INTO #CashTransactions
	SELECT 
		cr.BK_CODE,
		bk.BK_DESCRIPTION,
		cr.GLACODE,
		gla.GLADESC,
		cr.POST_PERIOD,
		cr.GLEXACT,
		'1',
		'Cash Receipts - Client',
		cr.CR_CHECK_NBR,
		cr.CR_CHECK_DATE,
		cl.CL_NAME,
		SUM(ISNULL(cr.CR_CHECK_AMT,0)),
		NULL,
		NULL,
		cr.CLEARED,
		cr.REC_STMT_DATE,
		cr.RECON_FLAG,
		glh.GLEHENTDATE,
        cr.CR_DEP_DATE
	FROM dbo.CR_CLIENT AS cr
	JOIN dbo.BANK AS bk ON cr.BK_CODE = bk.BK_CODE
	JOIN dbo.GLACCOUNT AS gla ON cr.GLACODE = gla.GLACODE
	JOIN dbo.CLIENT AS cl ON cr.CL_CODE = cl.CL_CODE 
	LEFT OUTER JOIN dbo.GLENTHDR AS glh ON cr.GLEXACT = glh.GLEHXACT
	WHERE cr.POST_PERIOD BETWEEN @start_period AND @end_period
	GROUP BY cr.BK_CODE, bk.BK_DESCRIPTION, cr.GLACODE, gla.GLADESC, cr.POST_PERIOD, cr.GLEXACT, cr.CR_CHECK_NBR, cr.CR_CHECK_DATE, cl.CL_NAME, cr.CLEARED, cr.REC_STMT_DATE, cr.RECON_FLAG, glh.GLEHENTDATE, cr.CR_DEP_DATE
-- ========================================
-- Other Cash Receipts
-- ========================================
IF @include_receipts = 1
	INSERT INTO #CashTransactions
	SELECT
		cr.BK_CODE,
		bk.BK_DESCRIPTION,
		cr.GLACODE,
		gla.GLADESC,
		cr.POST_PERIOD,
		cr.GLEXACT,
		'2',
		'Cash Receipts - Other',
		cr.CR_CHECK_NBR,
		cr.CR_CHECK_DATE,
		cr.CR_DESC,
		SUM(ISNULL(cr.CR_CHECK_AMT,0)),
		NULL,
		NULL,
		cr.CLEARED,
		cr.REC_STMT_DATE,
		cr.RECON_FLAG,
		glh.GLEHENTDATE,
        cr.CR_DEP_DATE
	FROM dbo.CR_OTHER AS cr
	JOIN dbo.BANK AS bk ON cr.BK_CODE = bk.BK_CODE
	JOIN dbo.GLACCOUNT AS gla ON cr.GLACODE = gla.GLACODE
	LEFT OUTER JOIN dbo.GLENTHDR AS glh ON cr.GLEXACT = glh.GLEHXACT
	WHERE cr.POST_PERIOD BETWEEN @start_period AND @end_period
	GROUP BY cr.BK_CODE, bk.BK_DESCRIPTION, cr.GLACODE, gla.GLADESC, cr.POST_PERIOD, cr.GLEXACT, cr.CR_CHECK_NBR, cr.CR_CHECK_DATE, cr.CR_DESC, cr.CLEARED, cr.REC_STMT_DATE, cr.RECON_FLAG, glh.GLEHENTDATE, cr.CR_DEP_DATE

-- ========================================
-- CASH DISBURSEMENTS
-- ========================================
-- AP Payment History 
-- ========================================
IF @include_disbursements = 1
	INSERT INTO #APPmtHist
	SELECT
		app.BK_CODE,
		app.AP_CHK_NBR,
		app.GLACODE_CASH,
		Min(app.GLEXACT)
	FROM dbo.AP_PMT_HIST AS app
	GROUP BY app.BK_CODE, app.AP_CHK_NBR, app.GLACODE_CASH
-- ========================================
-- Checks Issued
-- ========================================
IF @include_disbursements = 1
	INSERT INTO #CashTransactions
	SELECT
		ckr.BK_CODE,
		bk.BK_DESCRIPTION,
		app.GLACODE_CASH,
		gla.GLADESC,
		ckr.POST_PERIOD,
		app.GLEXACT,
		'3',
		'Cash Disbursement',
		ckr.CHECK_NBR,
		ckr.CHECK_DATE,
		ckr.PAY_TO,
		ckr.CHECK_AMT*-1,
		NULL,
		ckr.VOID_POST_PERIOD,
		ckr.CLEARED,
		ckr.REC_STMT_DATE,
		ckr.RECON_FLAG,
		glh.GLEHENTDATE,
		NULL
	FROM dbo.CHECK_REGISTER AS ckr
	JOIN dbo.BANK AS bk ON ckr.BK_CODE = bk.BK_CODE
	LEFT JOIN #APPmtHist AS app ON (ckr.BK_CODE = app.BK_CODE AND ckr.CHECK_NBR = app.AP_CHK_NBR)
	LEFT JOIN dbo.GLACCOUNT AS gla ON app.GLACODE_CASH = gla.GLACODE
	LEFT OUTER JOIN dbo.GLENTHDR AS glh ON ckr.GLEXACT = glh.GLEHXACT
	WHERE ckr.POST_PERIOD BETWEEN @start_period AND @end_period
-- ========================================
-- Checks Voided
-- ========================================
IF @include_disbursements = 1
	INSERT INTO #CashTransactions
	SELECT
		ckr.BK_CODE,
		bk.BK_DESCRIPTION,
		app.GLACODE_CASH,
		gla.GLADESC,
		ckr.VOID_POST_PERIOD,
		app.GLEXACT,
		'3',
		'Cash Disbursement',
		ckr.CHECK_NBR,
		ckr.CHECK_DATE,
		ckr.PAY_TO,
		ckr.CHECK_AMT,
		VOID_FLAG,
		NULL,
		ckr.CLEARED,
		ckr.REC_STMT_DATE,
		ckr.RECON_FLAG,
		glh.GLEHENTDATE,
		NULL
	FROM dbo.CHECK_REGISTER AS ckr
	JOIN dbo.BANK AS bk ON ckr.BK_CODE = bk.BK_CODE
	LEFT JOIN #APPmtHist AS app ON (ckr.BK_CODE = app.BK_CODE AND ckr.CHECK_NBR = app.AP_CHK_NBR)
	LEFT JOIN dbo.GLACCOUNT AS gla ON app.GLACODE_CASH = gla.GLACODE
	LEFT OUTER JOIN dbo.GLENTHDR AS glh ON ckr.GLEXACT = glh.GLEHXACT
	WHERE ckr.VOID_POST_PERIOD BETWEEN @start_period AND @end_period

-- ========================================
-- GENERAL LEDGER ENTRIES
-- ========================================
-- Bank 
-- ========================================
IF @include_glentries = 1
	INSERT INTO #Bank
	SELECT
		bk.BK_CODE,
		bk.BK_DESCRIPTION,
		bk.GLACODE_AR_CASH,
		'AR'
	FROM dbo.BANK AS bk

	UNION ALL SELECT
		bk.BK_CODE,
		bk.BK_DESCRIPTION,
		bk.GLACODE_AP_CASH,
		'AP'
	FROM dbo.BANK AS bk
-- ========================================
-- Bank Cash Accounts
-- ========================================
IF @include_glentries = 1
	INSERT INTO #BankCashAccts
	SELECT
		bk.BK_CODE,
		bk.BK_DESCRIPTION,
		bk.GLACODE_CASH
	FROM #Bank AS bk
	GROUP BY bk.BK_CODE, bk.BK_DESCRIPTION, bk.GLACODE_CASH
-- ========================================
-- General Ledger Entries
-- ========================================
IF @include_glentries = 1
	INSERT INTO #CashTransactions
	SELECT
		bk.BK_CODE,
		bk.BK_DESCRIPTION,
		bk.GLACODE_CASH,
		gla.GLADESC,
		glh.GLEHPP,
		gld.GLETXACT,
		'4',
		'General Ledger Entry',
		gld.GLETXACT,
		glh.GLEHENTDATE,
		gld.GLETREM,
		gld.GLETAMT,
		NULL,
		NULL,
		gld.CLEARED,
		gld.REC_STMT_DATE,
		gld.RECON_FLAG,
		glh.GLEHENTDATE,
		NULL
	FROM dbo.GLENTTRL AS gld
	JOIN dbo.GLENTHDR AS glh ON gld.GLETXACT = glh.GLEHXACT
	JOIN #BankCashAccts AS bk ON gld.GLETCODE = bk.GLACODE_CASH
	JOIN dbo.GLACCOUNT AS gla ON bk.GLACODE_CASH = gla.GLACODE
	WHERE (glh.GLEHPP BETWEEN @start_period AND @end_period AND glh.GLEHPOSTSUM IS NOT NULL AND gld.GLETSOURCE NOT IN ('CC','CR','MC','OR','VC'))

IF @cleared_option = 2
	SELECT  BK_CODE AS BankCode ,
 BK_DESCRIPTION AS BankDescription ,
 GLACODE AS GLAccountCode ,
 GLADESC AS GLAccountDescription ,
 POST_PERIOD AS PostPeriod ,
 GLXact ,
 Ref ,
 REF_DESCRIPTION AS RefDescription ,
 CHECK_NBR AS CheckNumber ,
 CHECK_DATE AS CheckDate ,
 PAYEE_PAYOR AS PayeePayor ,
 AMOUNT ,
 CASE WHEN ISNULL(VOID_FLAG,0) = 0 THEN 'No' ELSE 'Yes' END AS VoidFlag ,
 VOID_PERIOD AS VoidPeriod ,
 CASE WHEN ISNULL(Cleared,0) = 0 THEN 'No' ELSE 'Yes' END AS Cleared ,
 REC_STMT_DATE AS RecStmtDate ,
 CASE WHEN ISNULL(RECON_FLAG,0) = 0 THEN 'No' ELSE 'Yes' END AS ReconFlag,
 CREATE_DATE AS DateOfEntry,
 DEP_DATE AS DepositDate FROM #CashTransactions AS ct
	WHERE ((ct.BK_CODE IN (SELECT * FROM dbo.udf_split_list (@bank_list, ',')) OR @bank_list IS NULL) AND (ct.REC_STMT_DATE > @statement_cutoff OR ct.REC_STMT_DATE IS NULL))
	ELSE
		SELECT  BK_CODE AS BankCode ,
 BK_DESCRIPTION AS BankDescription ,
 GLACODE AS GLAccountCode ,
 GLADESC AS GLAccountDescription ,
 POST_PERIOD AS PostPeriod ,
 GLXact ,
 Ref ,
 REF_DESCRIPTION AS RefDescription ,
 CHECK_NBR AS CheckNumber ,
 CHECK_DATE AS CheckDate ,
 PAYEE_PAYOR AS PayeePayor ,
 AMOUNT  ,
 CASE WHEN ISNULL(VOID_FLAG,0) = 0 THEN 'No' ELSE 'Yes' END  AS VoidFlag ,
 VOID_PERIOD AS VoidPeriod ,
 CASE WHEN ISNULL(Cleared,0) = 0 THEN 'No' ELSE 'Yes' END AS Cleared ,
 REC_STMT_DATE AS RecStmtDate ,
 CASE WHEN ISNULL(RECON_FLAG,0) = 0 THEN 'No' ELSE 'Yes' END AS ReconFlag,
 CREATE_DATE AS DateOfEntry,
 DEP_DATE AS DepositDate  FROM #CashTransactions AS ct
		WHERE (ct.BK_CODE IN (SELECT * FROM dbo.udf_split_list (@bank_list, ',')) OR @bank_list IS NULL)

END
GO