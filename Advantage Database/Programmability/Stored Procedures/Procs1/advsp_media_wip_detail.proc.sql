SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media_wip_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media_wip_detail]
GO

CREATE PROCEDURE [dbo].[advsp_media_wip_detail] (
	@end_period				varchar(6) = '219912',
	@order_option			tinyint = 1,
	@wip_option				varchar(1) = 'G',
	@OFFICE_LIST AS varchar(Max) = NULL,
	@CLIENT_LIST AS varchar(Max) = NULL,
	@DIVISION_LIST AS varchar(Max) = NULL,
	@PRODUCT_LIST AS varchar(Max) = NULL,
	@USER_CODE AS varchar(100))  

AS

--Stored procedure to extract media wip information
-- #00 01/11/18 - Initial - uses "advsp_media1_med_acc.sql (1/29/16) for data extraction
-- #01 01/25/18 - Various revisions to duplicate wip reports (notably the addition of @wip_option)
-- #02 03/01/18 - Changed @wip_option default = "G" for #300 report per JR instructions on log 735(2)-1283
-- #03 05/05/20 - Summerize Rows

--Parameters
--@end_period: cutoff period
--@order_option: 1 = open and closed, 2 = open only (not in (6,12))
--@wip_option: 'O' = Open orders, 'G' = Open Order/GL Account Orders, 'L' = Open Order/GL Account/Line Orders, 'Z' = Zero Balance Orders
--@zero_balance: (set by @wip_option - used by advsp_media1_med_acc.sql below) 0 = Orders with non zero balances, 1 = Zero balance orders only 

/* Find and comment any "DEBUG-ONLY" lines before checking in */


BEGIN
	SET NOCOUNT ON;	
	
	--SELECT @wip_option
	DECLARE @zero_balance tinyint
	SET @zero_balance = 
	CASE @wip_option
		WHEN 'Z' THEN 1
		ELSE 0
	END
	--SELECT @zero_balance		
	
	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @RestrictionsOffice AS INTEGER
	DECLARE @RestrictionCDP INT

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@USER_CODE)

	SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE
	
	SELECT @RestrictionCDP = COUNT(*) FROM dbo.SEC_CLIENT WHERE SEC_CLIENT.[USER_ID] = @USER_CODE


	--SELECT  @RestrictionsOffice '@RestrictionsOffice', @RestrictionCDP '@RestrictionCDP', @EMP_CODE '@EMP_CODE', @USER_CODE '@USER_CODE' RETURN --DEBUG-ONLY ***
	
-- ========================================================================
--	MAIN DATA TEMP TABLE (dbo.advsp_media1_med_acc)
-- ========================================================================
	CREATE TABLE #MedAccTemp(
		[ORDER_NBR]			int NOT NULL,
		[LINE_NBR]			int NULL,
		[MONTH]				tinyint NULL,
		[YEAR]				smallint NULL,
		[DISCOUNT]			decimal(15,2) NULL,
		[NETCHARGE]			decimal(15,2) NULL,
		[TAX]				decimal(15,2) NULL,
		[LINE_NET]			decimal(15,2) NULL,
		[GLACODE_WIP]		varchar(30),
		[GLEXACT]			int NULL,
		[GLESEQ_WIP]		smallint NULL,
		[TYPE]				varchar(10) NULL,
		[VN_FRL_EMP_CODE]	varchar(6) NULL,
		[AP_INV_VCHR]		varchar(20) NULL,
		[AR_INV_NBR]		int NULL,
		[AR_INV_SEQ]		smallint NULL,
		[AR_TYPE]			varchar(3) NULL,
		[PERIOD]			varchar(8) NULL,				
		[START_DATE]		smalldatetime NULL,						
		[END_DATE]			smalldatetime NULL)			
INSERT INTO #MedAccTemp EXECUTE dbo.advsp_media1_med_acc @end_period, @zero_balance, @order_option
--SELECT * FROM #MedAccTemp ORDER BY ORDER_NBR

-- ========================================================================
--	MAIN DATA TABLE (post period limited by @end_period)
-- ========================================================================
	CREATE TABLE #MedAcc(
		[ORDER_NBR]			int NOT NULL,
		[LINE_NBR]			int NULL,
		[MONTH]				tinyint NULL,
		[YEAR]				smallint NULL,
		[DISCOUNT]			decimal(15,2) NULL,
		[NETCHARGE]			decimal(15,2) NULL,
		[TAX]				decimal(15,2) NULL,
		[LINE_NET]			decimal(15,2) NULL,
		[GLACODE_WIP]		varchar(30),
		[GLEXACT]			int NULL,
		[GLESEQ_WIP]		smallint NULL,
		[TYPE]				varchar(10) NULL,
		[VN_FRL_EMP_CODE]	varchar(6) NULL,
		[AP_INV_VCHR]		varchar(20) NULL,
		[AR_INV_NBR]		int NULL,
		[AR_INV_SEQ]		smallint NULL,
		[AR_TYPE]			varchar(3) NULL,
		[PERIOD]			varchar(8) NULL,				
		[START_DATE]		smalldatetime NULL,						
		[END_DATE]			smalldatetime NULL)							
	INSERT INTO #MedAcc
	SELECT * FROM #MedAccTemp
	WHERE [PERIOD] <= @end_period
	--SELECT * FROM #MedAcc WHERE ORDER_NBR = 7 ORDER BY ORDER_NBR, LINE_NBR	
	DROP TABLE #MedAccTemp

-- ==========================================================
-- TEMP TABLE OF ORDERS WITH NON-ZERO AMOUNTS FOR FILTERING DATASET 
-- ==========================================================
CREATE TABLE #open_orders (			
	ORDER_NBR			int NOT NULL,
	LINE_NBR			int NULL,
	GLACODE_WIP			varchar(30),
	LINE_NET			decimal(15,2))

IF @wip_option = 'O' OR @wip_option = 'Z'
BEGIN 
	INSERT INTO #open_orders
	SELECT m.ORDER_NBR,
		NULL,
		NULL,
		SUM(m.LINE_NET)
	FROM #MedAcc AS m
	GROUP BY m.ORDER_NBR
	HAVING ABS(SUM(m.LINE_NET)) >= .01
END

IF @wip_option = 'G'
BEGIN
	INSERT INTO #open_orders
	SELECT m.ORDER_NBR,
		NULL,
		ISNULL(m.GLACODE_WIP,''),
		SUM(m.LINE_NET)
	FROM #MedAcc AS m
	GROUP BY m.ORDER_NBR, GLACODE_WIP
	HAVING ABS(SUM(m.LINE_NET)) >= .01
END

IF @wip_option = 'L'
BEGIN
	INSERT INTO #open_orders
	SELECT m.ORDER_NBR,
		ISNULL(m.LINE_NBR,0),
		ISNULL(m.GLACODE_WIP,''),
		SUM(m.LINE_NET)
	FROM #MedAcc AS m
	GROUP BY m.ORDER_NBR, ISNULL(LINE_NBR,0), GLACODE_WIP
	HAVING ABS(SUM(m.LINE_NET)) >= .01
END
--SELECT * FROM #open_orders ORDER BY ORDER_NBR

-- ==========================================================
-- TEMP TABLE FOR PAYMENT FLAG
-- ==========================================================
-- Part 1 (invoice list)
CREATE TABLE #order_invoices (AR_INV_NBR int NULL)
INSERT INTO #order_invoices
SELECT DISTINCT m.AR_INV_NBR
FROM #MedAcc AS m
WHERE m.AR_INV_NBR IS NOT NULL
--SELECT * FROM #order_invoices ORDER BY AR_INV_NBR

-- Part 2 (invoice amount, cash receipts amounts and payment flag)
CREATE TABLE #payment_flag(
	AR_INV_NBR					int,
	AR_INV_SEQ					smallint,
	AR_TYPE						varchar(3),
	--AR_INV_AMOUNT				decimal(15,2),
	--CR_TOT_AMT				decimal(15,2),
	PAYMENT_FLAG				smallint)
INSERT INTO #payment_flag	
SELECT
	a.AR_INV_NBR,
	a.AR_INV_SEQ,
	a.AR_TYPE,
	--a.AR_INV_AMOUNT, 
	--SUM(ISNULL(c.CR_PAY_AMT,0) + ISNULL(c.CR_ADJ_AMT,0)),
	CASE 
		WHEN SUM(ISNULL(c.CR_PAY_AMT,0) + ISNULL(c.CR_ADJ_AMT,0)) = 0 THEN 0
		WHEN SUM(ISNULL(c.CR_PAY_AMT,0) + ISNULL(c.CR_ADJ_AMT,0)) = a.AR_INV_AMOUNT THEN 1
		ELSE 2
	END
FROM dbo.ACCT_REC AS a
JOIN #order_invoices AS i
	ON a.AR_INV_NBR = i.AR_INV_NBR
LEFT JOIN dbo.CR_CLIENT_DTL AS c
	ON a.AR_INV_NBR = c.AR_INV_NBR
	AND a.AR_INV_SEQ = c.AR_INV_SEQ
	AND a.AR_TYPE = c.AR_TYPE
WHERE a.REC_TYPE <> 'P'
	AND ISNULL(a.MANUAL_INV,0) = 0	
	AND a.AR_TYPE = 'IN'
GROUP BY a.AR_INV_NBR, a.AR_INV_SEQ, a.AR_TYPE, a.AR_INV_AMOUNT
DROP TABLE #order_invoices
--SELECT * FROM #payment_flag	ORDER BY AR_INV_NBR

-- ==========================================================
-- TEMP TABLE FOR AGING PERIOD 
-- ==========================================================
-- Part 1 (billing and AP posting periods)
CREATE TABLE #aging_period_temp1(
	ORDER_NBR					int,
	LINE_NBR					int,
	BILLING_PERIOD				varchar(6),
	AP_PERIOD					varchar(6))
INSERT INTO #aging_period_temp1
SELECT
	m.ORDER_NBR,
	ISNULL(m.LINE_NBR,0),
	CASE m.[TYPE]
		WHEN 'BILLING' THEN m.PERIOD
		ELSE ''
	END,
	CASE m.[TYPE]
		WHEN 'AP' THEN m.PERIOD
		ELSE ''
	END	
FROM #MedAcc AS m
--SELECT * FROM #aging_period_temp1

-- Part 2 (max billing and AP period for each order/line)
CREATE TABLE #aging_period_temp2(
	ORDER_NBR					int,
	LINE_NBR					int,
	BILLING_PERIOD				varchar(6),
	AP_PERIOD					varchar(6))	
INSERT INTO #aging_period_temp2
SELECT DISTINCT
	m.ORDER_NBR,
	m.LINE_NBR,
	MAX(m.BILLING_PERIOD),
	MAX(m.AP_PERIOD)
FROM #aging_period_temp1 AS m	
GROUP BY m.ORDER_NBR, m.LINE_NBR
DROP TABLE #aging_period_temp1
--SELECT * FROM #aging_period_temp2 ORDER BY ORDER_NBR, LINE_NBR	

-- Part 3 (select max ap period if max billing period is null)
CREATE TABLE #aging_period(
	ORDER_NBR					int,
	LINE_NBR					int,
	AGING_PERIOD				varchar(6))	
INSERT INTO #aging_period
SELECT DISTINCT
	m.ORDER_NBR,
	m.LINE_NBR,
	CASE m.BILLING_PERIOD
		WHEN '' THEN m.AP_PERIOD
		ELSE m.BILLING_PERIOD
	END	
FROM #aging_period_temp2 AS m	
GROUP BY m.ORDER_NBR, m.LINE_NBR, m.BILLING_PERIOD, m.AP_PERIOD

--SELECT * FROM #aging_period ORDER BY ORDER_NBR, LINE_NBR		

DECLARE @endperioddate smalldatetime = NULL
SET @endperioddate = (SELECT PPENDDATE FROM POSTPERIOD WHERE PPPERIOD = @end_period)
--SELECT @endperioddate

--	=======================================================================	
--  FINAL QUERY
--	=======================================================================

IF @RestrictionsOffice > 0 AND @RestrictionCDP > 0
BEGIN
	SELECT 
	[ID] = NEWID(),
	[OfficeCode]				= p.OFFICE_CODE,
	[OfficeDescription]		= o.OFFICE_NAME,
	[CDPSortCode]				= h.CL_CODE + ' ' + h.DIV_CODE + ' ' + h.PRD_CODE,
	[ClientCode]				= h.CL_CODE,
	[ClientName]				= c.CL_NAME,
	[DivisionCode]				= h.DIV_CODE,
	[DivisionName]				= d.DIV_NAME,
	[ProductCode]				= h.PRD_CODE,
	[ProductDescription]		= p.PRD_DESCRIPTION,
	[VendorCode]				= h.VN_CODE,
	[VendorName]				= v.VN_NAME,
	[SalesClassCode]			= h.MEDIA_TYPE,
	[SalesClassDescription]	= s.SC_DESCRIPTION,
	[ClientPO]					= h.CLIENT_PO,
	[OrderType]				= h.ORDER_TYPE,
	[OrderNumber]				= m.ORDER_NBR,
	[LineNumber]				= ISNULL(m.LINE_NBR,0),
	[OrderDescription]			= h.ORDER_DESC,
	[OrderStartDate]			= CASE WHEN @wip_option = 'L' THEN m.[START_DATE] ELSE h.[START_DATE] END,
	[OrderEndDate]			= CASE WHEN @wip_option = 'L' THEN m.[END_DATE] ELSE h.[END_DATE] END,
	[OrderProcessingControl]	= h.ORD_PROCESS_CONTRL,
	[OrderProcessingStatus]	= CASE h.ORD_PROCESS_CONTRL
									WHEN 1 THEN 'All Processing'
									WHEN 2 THEN 'No Processing'
									WHEN 3 THEN 'AP & Billing'
									WHEN 4 THEN 'AP, Time & Billing'
									WHEN 5 THEN 'Billing Only'
									WHEN 6 THEN 'Closed'
									WHEN 7 THEN 'Time & Billing'
									WHEN 8 THEN 'AP, Time, IO & Billing'
									WHEN 9 THEN 'AP, IO & Billing'
									WHEN 10 THEN 'IO & Billing'
									WHEN 11 THEN 'Time, IO & Billing'
									WHEN 12 THEN 'Archive'
									WHEN 13 THEN 'AP Only'
									END,
	[TransactionType]			= m.[TYPE],
	[GLAccountCode]			= m.GLACODE_WIP,
	[GLAccountDescription]	= a.GLADESC,
	[GLXact]					= m.GLEXACT,
	[GLSequence]				= m.GLESEQ_WIP,
	[Reference]					= CASE m.[TYPE]
									WHEN 'BILLING' THEN 'Invoice # '  + CAST(m.AR_INV_NBR AS varchar)
									WHEN 'AP' THEN 'Ven ' + h.VN_CODE	+ ' Inv # '	+ m.AP_INV_VCHR COLLATE DATABASE_DEFAULT
									ELSE ''
									END,
	[BillingMonthYear]		= dbo.advfn_period_to_month_year(ag.AGING_PERIOD),			
	[BilledAmount]				= CASE m.[TYPE]
									WHEN 'BILLING' THEN m.LINE_NET
									ELSE 0
									END,
	[AccountsPayableAmount]	= CASE m.[TYPE]
									WHEN 'AP' THEN m.LINE_NET
									WHEN 'RECONCILE' THEN m.LINE_NET
									ELSE 0
									END,
	[BalanceAmount]			= m.LINE_NET,
	--[Order Period]			= CAST (m.[YEAR] * 100 + m.[MONTH] AS varchar),		--based on order start date
	--[Actual Entry Period]		= m.PERIOD,											--actual posting period for AR or AP entry
	[PostingPeriod]			= ag.AGING_PERIOD,									--max AR period period for order/line (AP period if null)
	[PostingPeriodEndDate]	= LEFT(DATENAME(m, pp.PPENDDATE),3) + ' ' + DATENAME(yyyy, pp.PPENDDATE),
	[CurrentAmount]			= CASE
									WHEN pp.PPENDDATE >= @endperioddate THEN m.LINE_NET 
									ELSE 0
									END,								
	[ThirtyDays]					= CASE
									WHEN (pp.PPENDDATE < @endperioddate AND pp.PPENDDATE >= DATEADD(DAY,-30,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END	,									
	[SixtyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-30,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-60,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[NinetyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-60,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-90,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,								
	[OneHundredTwentyDays]		= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-90,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,							
	[Over120Days]				= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[CashReceived]				= CASE ISNULL(f.PAYMENT_FLAG,0) 
									WHEN 0 THEN 'None'			
									WHEN 1 THEN 'Full'			
									WHEN 2 THEN 'Partial'		
									END,
    [BillingPeriod] = (SELECT BILLING_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR),
    [APPeriod] = (SELECT AP_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR)
	
INTO #temp
													
FROM #MedAcc AS m
LEFT JOIN #open_orders AS op
	ON m.ORDER_NBR = op.ORDER_NBR
JOIN dbo.V_MEDIA_HDR AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN dbo.CLIENT AS c
	ON h.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON h.CL_CODE = d.CL_CODE
	AND h.DIV_CODE = d.DIV_CODE
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
JOIN dbo.OFFICE AS o
	ON p.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS s
	ON h.MEDIA_TYPE = s.SC_CODE
JOIN dbo.VENDOR AS v
	ON h.VN_CODE = v.VN_CODE	
LEFT JOIN dbo.GLACCOUNT AS a								
	ON m.GLACODE_WIP = a.GLACODE COLLATE DATABASE_DEFAULT
LEFT JOIN #payment_flag AS f
	ON m.AR_INV_NBR = f.AR_INV_NBR
	AND m.AR_INV_SEQ = f.AR_INV_SEQ
	AND m.AR_TYPE = f.AR_TYPE
LEFT JOIN #aging_period AS ag
	ON m.ORDER_NBR = ag.ORDER_NBR
	AND ISNULL(m.LINE_NBR,0) = ag.LINE_NBR
JOIN dbo.POSTPERIOD AS pp									
	ON ag.AGING_PERIOD = pp.PPPERIOD COLLATE DATABASE_DEFAULT
	INNER JOIN SEC_CLIENT ON p.CL_CODE = SEC_CLIENT.CL_CODE AND p.DIV_CODE = SEC_CLIENT.DIV_CODE AND p.PRD_CODE = SEC_CLIENT.PRD_CODE
	INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = p.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
WHERE ((@zero_balance =	1 AND op.ORDER_NBR IS NULL) 	
	OR (@zero_balance = 0 AND @wip_option = 'O' AND m.ORDER_NBR = op.ORDER_NBR)								
	OR (@zero_balance = 0 AND @wip_option = 'G' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP)
	OR (@zero_balance = 0 AND @wip_option = 'L' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP 
		AND ISNULL(m.LINE_NBR,0) = op.LINE_NBR)) AND
		1 = CASE WHEN @RestrictionCDP = 0 THEN 1 WHEN UPPER(SEC_CLIENT.[USER_ID]) = UPPER(@USER_CODE) AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END AND
		(p.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(p.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE + '|' + p.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END
ELSE IF @RestrictionsOffice > 0 AND @RestrictionCDP = 0
BEGIN
	SELECT 
	[ID] = NEWID(),
	[OfficeCode]				= p.OFFICE_CODE,
	[OfficeDescription]		= o.OFFICE_NAME,
	[CDPSortCode]				= h.CL_CODE + ' ' + h.DIV_CODE + ' ' + h.PRD_CODE,
	[ClientCode]				= h.CL_CODE,
	[ClientName]				= c.CL_NAME,
	[DivisionCode]				= h.DIV_CODE,
	[DivisionName]				= d.DIV_NAME,
	[ProductCode]				= h.PRD_CODE,
	[ProductDescription]		= p.PRD_DESCRIPTION,
	[VendorCode]				= h.VN_CODE,
	[VendorName]				= v.VN_NAME,
	[SalesClassCode]			= h.MEDIA_TYPE,
	[SalesClassDescription]	= s.SC_DESCRIPTION,
	[ClientPO]					= h.CLIENT_PO,
	[OrderType]				= h.ORDER_TYPE,
	[OrderNumber]				= m.ORDER_NBR,
	[LineNumber]				= ISNULL(m.LINE_NBR,0),
	[OrderDescription]			= h.ORDER_DESC,
	[OrderStartDate]			= CASE WHEN @wip_option = 'L' THEN m.[START_DATE] ELSE h.[START_DATE] END,
	[OrderEndDate]			= CASE WHEN @wip_option = 'L' THEN m.[END_DATE] ELSE h.[END_DATE] END,
	[OrderProcessingControl]	= h.ORD_PROCESS_CONTRL,
	[OrderProcessingStatus]	= CASE h.ORD_PROCESS_CONTRL
									WHEN 1 THEN 'All Processing'
									WHEN 2 THEN 'No Processing'
									WHEN 3 THEN 'AP & Billing'
									WHEN 4 THEN 'AP, Time & Billing'
									WHEN 5 THEN 'Billing Only'
									WHEN 6 THEN 'Closed'
									WHEN 7 THEN 'Time & Billing'
									WHEN 8 THEN 'AP, Time, IO & Billing'
									WHEN 9 THEN 'AP, IO & Billing'
									WHEN 10 THEN 'IO & Billing'
									WHEN 11 THEN 'Time, IO & Billing'
									WHEN 12 THEN 'Archive'
									WHEN 13 THEN 'AP Only'
									END,
	[TransactionType]			= m.[TYPE],
	[GLAccountCode]			= m.GLACODE_WIP,
	[GLAccountDescription]	= a.GLADESC,
	[GLXact]					= m.GLEXACT,
	[GLSequence]				= m.GLESEQ_WIP,
	[Reference]					= CASE m.[TYPE]
									WHEN 'BILLING' THEN 'Invoice # '  + CAST(m.AR_INV_NBR AS varchar)
									WHEN 'AP' THEN 'Ven ' + h.VN_CODE	+ ' Inv # '	+ m.AP_INV_VCHR COLLATE DATABASE_DEFAULT
									ELSE ''
									END,
	[BillingMonthYear]		= dbo.advfn_period_to_month_year(ag.AGING_PERIOD),			
	[BilledAmount]				= CASE m.[TYPE]
									WHEN 'BILLING' THEN m.LINE_NET
									ELSE 0
									END,
	[AccountsPayableAmount]	= CASE m.[TYPE]
									WHEN 'AP' THEN m.LINE_NET
									WHEN 'RECONCILE' THEN m.LINE_NET
									ELSE 0
									END,
	[BalanceAmount]			= m.LINE_NET,
	--[Order Period]			= CAST (m.[YEAR] * 100 + m.[MONTH] AS varchar),		--based on order start date
	--[Actual Entry Period]		= m.PERIOD,											--actual posting period for AR or AP entry
	[PostingPeriod]			= ag.AGING_PERIOD,									--max AR period period for order/line (AP period if null)
	[PostingPeriodEndDate]	= LEFT(DATENAME(m, pp.PPENDDATE),3) + ' ' + DATENAME(yyyy, pp.PPENDDATE),
	[CurrentAmount]			= CASE
									WHEN pp.PPENDDATE >= @endperioddate THEN m.LINE_NET 
									ELSE 0
									END,								
	[ThirtyDays]					= CASE
									WHEN (pp.PPENDDATE < @endperioddate AND pp.PPENDDATE >= DATEADD(DAY,-30,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END	,									
	[SixtyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-30,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-60,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[NinetyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-60,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-90,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,								
	[OneHundredTwentyDays]		= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-90,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,							
	[Over120Days]				= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[CashReceived]				= CASE ISNULL(f.PAYMENT_FLAG,0) 
									WHEN 0 THEN 'None'			
									WHEN 1 THEN 'Full'			
									WHEN 2 THEN 'Partial'		
									END,
    [BillingPeriod] = (SELECT BILLING_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR),
    [APPeriod] = (SELECT AP_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR)
	
INTO #temp2
												
FROM #MedAcc AS m
LEFT JOIN #open_orders AS op
	ON m.ORDER_NBR = op.ORDER_NBR
JOIN dbo.V_MEDIA_HDR AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN dbo.CLIENT AS c
	ON h.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON h.CL_CODE = d.CL_CODE
	AND h.DIV_CODE = d.DIV_CODE
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
JOIN dbo.OFFICE AS o
	ON p.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS s
	ON h.MEDIA_TYPE = s.SC_CODE
JOIN dbo.VENDOR AS v
	ON h.VN_CODE = v.VN_CODE	
LEFT JOIN dbo.GLACCOUNT AS a								
	ON m.GLACODE_WIP = a.GLACODE COLLATE DATABASE_DEFAULT
LEFT JOIN #payment_flag AS f
	ON m.AR_INV_NBR = f.AR_INV_NBR
	AND m.AR_INV_SEQ = f.AR_INV_SEQ
	AND m.AR_TYPE = f.AR_TYPE
LEFT JOIN #aging_period AS ag
	ON m.ORDER_NBR = ag.ORDER_NBR
	AND ISNULL(m.LINE_NBR,0) = ag.LINE_NBR
JOIN dbo.POSTPERIOD AS pp									
	ON ag.AGING_PERIOD = pp.PPPERIOD COLLATE DATABASE_DEFAULT
	INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = p.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
WHERE ((@zero_balance =	1 AND op.ORDER_NBR IS NULL) 	
	OR (@zero_balance = 0 AND @wip_option = 'O' AND m.ORDER_NBR = op.ORDER_NBR)								
	OR (@zero_balance = 0 AND @wip_option = 'G' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP)
	OR (@zero_balance = 0 AND @wip_option = 'L' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP 
		AND ISNULL(m.LINE_NBR,0) = op.LINE_NBR)) AND
		(p.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(p.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE + '|' + p.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
	
END
ELSE IF @RestrictionsOffice = 0 AND @RestrictionCDP > 0
BEGIN
	SELECT 
	[ID] = NEWID(),
	[OfficeCode]				= p.OFFICE_CODE,
	[OfficeDescription]		= o.OFFICE_NAME,
	[CDPSortCode]				= h.CL_CODE + ' ' + h.DIV_CODE + ' ' + h.PRD_CODE,
	[ClientCode]				= h.CL_CODE,
	[ClientName]				= c.CL_NAME,
	[DivisionCode]				= h.DIV_CODE,
	[DivisionName]				= d.DIV_NAME,
	[ProductCode]				= h.PRD_CODE,
	[ProductDescription]		= p.PRD_DESCRIPTION,
	[VendorCode]				= h.VN_CODE,
	[VendorName]				= v.VN_NAME,
	[SalesClassCode]			= h.MEDIA_TYPE,
	[SalesClassDescription]	= s.SC_DESCRIPTION,
	[ClientPO]					= h.CLIENT_PO,
	[OrderType]				= h.ORDER_TYPE,
	[OrderNumber]				= m.ORDER_NBR,
	[LineNumber]				= ISNULL(m.LINE_NBR,0),
	[OrderDescription]			= h.ORDER_DESC,
	[OrderStartDate]			= CASE WHEN @wip_option = 'L' THEN m.[START_DATE] ELSE h.[START_DATE] END,
	[OrderEndDate]			= CASE WHEN @wip_option = 'L' THEN m.[END_DATE] ELSE h.[END_DATE] END,
	[OrderProcessingControl]	= h.ORD_PROCESS_CONTRL,
	[OrderProcessingStatus]	= CASE h.ORD_PROCESS_CONTRL
									WHEN 1 THEN 'All Processing'
									WHEN 2 THEN 'No Processing'
									WHEN 3 THEN 'AP & Billing'
									WHEN 4 THEN 'AP, Time & Billing'
									WHEN 5 THEN 'Billing Only'
									WHEN 6 THEN 'Closed'
									WHEN 7 THEN 'Time & Billing'
									WHEN 8 THEN 'AP, Time, IO & Billing'
									WHEN 9 THEN 'AP, IO & Billing'
									WHEN 10 THEN 'IO & Billing'
									WHEN 11 THEN 'Time, IO & Billing'
									WHEN 12 THEN 'Archive'
									WHEN 13 THEN 'AP Only'
									END,
	[TransactionType]			= m.[TYPE],
	[GLAccountCode]			= m.GLACODE_WIP,
	[GLAccountDescription]	= a.GLADESC,
	[GLXact]					= m.GLEXACT,
	[GLSequence]				= m.GLESEQ_WIP,
	[Reference]					= CASE m.[TYPE]
									WHEN 'BILLING' THEN 'Invoice # '  + CAST(m.AR_INV_NBR AS varchar)
									WHEN 'AP' THEN 'Ven ' + h.VN_CODE	+ ' Inv # '	+ m.AP_INV_VCHR COLLATE DATABASE_DEFAULT
									ELSE ''
									END,
	[BillingMonthYear]		= dbo.advfn_period_to_month_year(ag.AGING_PERIOD),			
	[BilledAmount]				= CASE m.[TYPE]
									WHEN 'BILLING' THEN m.LINE_NET
									ELSE 0
									END,
	[AccountsPayableAmount]	= CASE m.[TYPE]
									WHEN 'AP' THEN m.LINE_NET
									WHEN 'RECONCILE' THEN m.LINE_NET
									ELSE 0
									END,
	[BalanceAmount]			= m.LINE_NET,
	--[Order Period]			= CAST (m.[YEAR] * 100 + m.[MONTH] AS varchar),		--based on order start date
	--[Actual Entry Period]		= m.PERIOD,											--actual posting period for AR or AP entry
	[PostingPeriod]			= ag.AGING_PERIOD,									--max AR period period for order/line (AP period if null)
	[PostingPeriodEndDate]	= LEFT(DATENAME(m, pp.PPENDDATE),3) + ' ' + DATENAME(yyyy, pp.PPENDDATE),
	[CurrentAmount]			= CASE
									WHEN pp.PPENDDATE >= @endperioddate THEN m.LINE_NET 
									ELSE 0
									END,								
	[ThirtyDays]					= CASE
									WHEN (pp.PPENDDATE < @endperioddate AND pp.PPENDDATE >= DATEADD(DAY,-30,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END	,									
	[SixtyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-30,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-60,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[NinetyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-60,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-90,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,								
	[OneHundredTwentyDays]		= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-90,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,							
	[Over120Days]				= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[CashReceived]				= CASE ISNULL(f.PAYMENT_FLAG,0) 
									WHEN 0 THEN 'None'			
									WHEN 1 THEN 'Full'			
									WHEN 2 THEN 'Partial'		
									END,
    [BillingPeriod] = (SELECT BILLING_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR),
    [APPeriod] = (SELECT AP_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR)	

INTO #temp3	
												
FROM #MedAcc AS m
LEFT JOIN #open_orders AS op
	ON m.ORDER_NBR = op.ORDER_NBR
JOIN dbo.V_MEDIA_HDR AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN dbo.CLIENT AS c
	ON h.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON h.CL_CODE = d.CL_CODE
	AND h.DIV_CODE = d.DIV_CODE
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
JOIN dbo.OFFICE AS o
	ON p.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS s
	ON h.MEDIA_TYPE = s.SC_CODE
JOIN dbo.VENDOR AS v
	ON h.VN_CODE = v.VN_CODE	
LEFT JOIN dbo.GLACCOUNT AS a								
	ON m.GLACODE_WIP = a.GLACODE COLLATE DATABASE_DEFAULT
LEFT JOIN #payment_flag AS f
	ON m.AR_INV_NBR = f.AR_INV_NBR
	AND m.AR_INV_SEQ = f.AR_INV_SEQ
	AND m.AR_TYPE = f.AR_TYPE
LEFT JOIN #aging_period AS ag
	ON m.ORDER_NBR = ag.ORDER_NBR
	AND ISNULL(m.LINE_NBR,0) = ag.LINE_NBR
JOIN dbo.POSTPERIOD AS pp									
	ON ag.AGING_PERIOD = pp.PPPERIOD COLLATE DATABASE_DEFAULT
	INNER JOIN SEC_CLIENT ON p.CL_CODE = SEC_CLIENT.CL_CODE AND p.DIV_CODE = SEC_CLIENT.DIV_CODE AND p.PRD_CODE = SEC_CLIENT.PRD_CODE
WHERE ((@zero_balance =	1 AND op.ORDER_NBR IS NULL) 	
	OR (@zero_balance = 0 AND @wip_option = 'O' AND m.ORDER_NBR = op.ORDER_NBR)								
	OR (@zero_balance = 0 AND @wip_option = 'G' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP)
	OR (@zero_balance = 0 AND @wip_option = 'L' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP 
		AND ISNULL(m.LINE_NBR,0) = op.LINE_NBR)) AND
		1 = CASE WHEN @RestrictionCDP = 0 THEN 1 WHEN UPPER(SEC_CLIENT.[USER_ID]) = UPPER(@USER_CODE) AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END AND
		(p.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(p.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE + '|' + p.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END
ELSE
BEGIN
	SELECT 
	[ID] = NEWID(),
	[OfficeCode]				= p.OFFICE_CODE,
	[OfficeDescription]		= o.OFFICE_NAME,
	[CDPSortCode]				= h.CL_CODE + ' ' + h.DIV_CODE + ' ' + h.PRD_CODE,
	[ClientCode]				= h.CL_CODE,
	[ClientName]				= c.CL_NAME,
	[DivisionCode]				= h.DIV_CODE,
	[DivisionName]				= d.DIV_NAME,
	[ProductCode]				= h.PRD_CODE,
	[ProductDescription]		= p.PRD_DESCRIPTION,
	[VendorCode]				= h.VN_CODE,
	[VendorName]				= v.VN_NAME,
	[SalesClassCode]			= h.MEDIA_TYPE,
	[SalesClassDescription]	= s.SC_DESCRIPTION,
	[ClientPO]					= h.CLIENT_PO,
	[OrderType]				= h.ORDER_TYPE,
	[OrderNumber]				= m.ORDER_NBR,
	[LineNumber]				= ISNULL(m.LINE_NBR,0),
	[OrderDescription]			= h.ORDER_DESC,
	[OrderStartDate]			= CASE WHEN @wip_option = 'L' THEN m.[START_DATE] ELSE h.[START_DATE] END,
	[OrderEndDate]			= CASE WHEN @wip_option = 'L' THEN m.[END_DATE] ELSE h.[END_DATE] END,
	[OrderProcessingControl]	= h.ORD_PROCESS_CONTRL,
	[OrderProcessingStatus]	= CASE h.ORD_PROCESS_CONTRL
									WHEN 1 THEN 'All Processing'
									WHEN 2 THEN 'No Processing'
									WHEN 3 THEN 'AP & Billing'
									WHEN 4 THEN 'AP, Time & Billing'
									WHEN 5 THEN 'Billing Only'
									WHEN 6 THEN 'Closed'
									WHEN 7 THEN 'Time & Billing'
									WHEN 8 THEN 'AP, Time, IO & Billing'
									WHEN 9 THEN 'AP, IO & Billing'
									WHEN 10 THEN 'IO & Billing'
									WHEN 11 THEN 'Time, IO & Billing'
									WHEN 12 THEN 'Archive'
									WHEN 13 THEN 'AP Only'
									END,
	[TransactionType]			= m.[TYPE],
	[GLAccountCode]			= m.GLACODE_WIP,
	[GLAccountDescription]	= a.GLADESC,
	[GLXact]					= m.GLEXACT,
	[GLSequence]				= m.GLESEQ_WIP,
	[Reference]					= CASE m.[TYPE]
									WHEN 'BILLING' THEN 'Invoice # '  + CAST(m.AR_INV_NBR AS varchar)
									WHEN 'AP' THEN 'Ven ' + h.VN_CODE	+ ' Inv # '	+ m.AP_INV_VCHR COLLATE DATABASE_DEFAULT
									ELSE ''
									END,
	[BillingMonthYear]		= dbo.advfn_period_to_month_year(ag.AGING_PERIOD),			
	[BilledAmount]				= CASE m.[TYPE]
									WHEN 'BILLING' THEN m.LINE_NET
									ELSE 0
									END,
	[AccountsPayableAmount]	= CASE m.[TYPE]
									WHEN 'AP' THEN m.LINE_NET
									WHEN 'RECONCILE' THEN m.LINE_NET
									ELSE 0
									END,
	[BalanceAmount]			= m.LINE_NET,
	--[Order Period]			= CAST (m.[YEAR] * 100 + m.[MONTH] AS varchar),		--based on order start date
	--[Actual Entry Period]		= m.PERIOD,											--actual posting period for AR or AP entry
	[PostingPeriod]			= ag.AGING_PERIOD,									--max AR period period for order/line (AP period if null)
	[PostingPeriodEndDate]	= LEFT(DATENAME(m, pp.PPENDDATE),3) + ' ' + DATENAME(yyyy, pp.PPENDDATE),
	[CurrentAmount]			= CASE
									WHEN pp.PPENDDATE >= @endperioddate THEN m.LINE_NET 
									ELSE 0
									END,								
	[ThirtyDays]					= CASE
									WHEN (pp.PPENDDATE < @endperioddate AND pp.PPENDDATE >= DATEADD(DAY,-30,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END	,									
	[SixtyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-30,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-60,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[NinetyDays]					= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-60,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-90,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,								
	[OneHundredTwentyDays]		= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-90,@endperioddate) AND pp.PPENDDATE >= DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,							
	[Over120Days]				= CASE
									WHEN (pp.PPENDDATE < DATEADD(DAY,-120,@endperioddate)) THEN m.LINE_NET 
									ELSE 0
									END,									
	[CashReceived]				= CASE ISNULL(f.PAYMENT_FLAG,0) 
									WHEN 0 THEN 'None'			
									WHEN 1 THEN 'Full'			
									WHEN 2 THEN 'Partial'		
									END,
    [BillingPeriod] = (SELECT BILLING_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR),
    [APPeriod] = (SELECT AP_PERIOD FROM #aging_period_temp2 WHERE m.ORDER_NBR = #aging_period_temp2.ORDER_NBR AND m.LINE_NBR = #aging_period_temp2.LINE_NBR)
	
INTO #temp4	
													
FROM #MedAcc AS m
LEFT JOIN #open_orders AS op
	ON m.ORDER_NBR = op.ORDER_NBR
JOIN dbo.V_MEDIA_HDR AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN dbo.CLIENT AS c
	ON h.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON h.CL_CODE = d.CL_CODE
	AND h.DIV_CODE = d.DIV_CODE
JOIN dbo.PRODUCT AS p
	ON h.CL_CODE = p.CL_CODE
	AND h.DIV_CODE = p.DIV_CODE
	AND h.PRD_CODE = p.PRD_CODE
JOIN dbo.OFFICE AS o
	ON p.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.SALES_CLASS AS s
	ON h.MEDIA_TYPE = s.SC_CODE
JOIN dbo.VENDOR AS v
	ON h.VN_CODE = v.VN_CODE	
LEFT JOIN dbo.GLACCOUNT AS a								
	ON m.GLACODE_WIP = a.GLACODE COLLATE DATABASE_DEFAULT
LEFT JOIN #payment_flag AS f
	ON m.AR_INV_NBR = f.AR_INV_NBR
	AND m.AR_INV_SEQ = f.AR_INV_SEQ
	AND m.AR_TYPE = f.AR_TYPE
LEFT JOIN #aging_period AS ag
	ON m.ORDER_NBR = ag.ORDER_NBR
	AND ISNULL(m.LINE_NBR,0) = ag.LINE_NBR
JOIN dbo.POSTPERIOD AS pp									
	ON ag.AGING_PERIOD = pp.PPPERIOD COLLATE DATABASE_DEFAULT
WHERE ((@zero_balance =	1 AND op.ORDER_NBR IS NULL) 	
	OR (@zero_balance = 0 AND @wip_option = 'O' AND m.ORDER_NBR = op.ORDER_NBR)								
	OR (@zero_balance = 0 AND @wip_option = 'G' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP)
	OR (@zero_balance = 0 AND @wip_option = 'L' AND m.ORDER_NBR = op.ORDER_NBR AND ISNULL(m.GLACODE_WIP,'') = op.GLACODE_WIP 
		AND ISNULL(m.LINE_NBR,0) = op.LINE_NBR)) AND
		(p.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
		(p.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (p.CL_CODE + '|' + p.DIV_CODE + '|' + p.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END


-- #03 05/05/20 - Summerize Rows

--IF @RestrictionsOffice > 0 AND @RestrictionCDP > 0
--ELSE IF @RestrictionsOffice > 0 AND @RestrictionCDP = 0	--#2
--ELSE IF @RestrictionsOffice = 0 AND @RestrictionCDP > 0	--#3
--ELSE

IF OBJECT_ID('TempDB.dbo.#Temp') IS NOT NULL
BEGIN
	--SELECT '#temp'  --DEBUG-ONLY
	SELECT
  		[ID] = NEWID(),
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		SUM(ISNULL(BilledAmount,0)) BilledAmount,
		SUM(ISNULL(AccountsPayableAmount,0)) AccountsPayableAmount,
		SUM(ISNULL(BalanceAmount,0)) BalanceAmount,
		[PostingPeriod],
		[PostingPeriodEndDate],
		SUM(ISNULL(CurrentAmount,0)) CurrentAmount,								
		SUM(ISNULL(ThirtyDays,0)) ThirtyDays,									
		SUM(ISNULL(SixtyDays,0)) SixtyDays,									
		SUM(ISNULL(NinetyDays,0)) NinetyDays,								
		SUM(ISNULL(OneHundredTwentyDays,0)) OneHundredTwentyDays,							
		SUM(ISNULL(Over120Days,0)) Over120Days,									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
	FROM #temp
	GROUP BY
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		--[BilledAmount],
		--[AccountsPayableAmount],
		--[BalanceAmount],
		[PostingPeriod],
		[PostingPeriodEndDate],
		--[CurrentAmount],								
		--[ThirtyDays],									
		--[SixtyDays],									
		--[NinetyDays],								
		--[OneHundredTwentyDays],							
		--[Over120Days],									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
				
	ORDER BY 
		[CDPSortCode],
		[OrderNumber],
		[LineNumber]
END
IF OBJECT_ID('TempDB.dbo.#Temp2') IS NOT NULL
BEGIN
	--SELECT '#temp2'  --DEBUG-ONLY
	SELECT
  		[ID] = NEWID(),
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		SUM(ISNULL(BilledAmount,0)) BilledAmount,
		SUM(ISNULL(AccountsPayableAmount,0)) AccountsPayableAmount,
		SUM(ISNULL(BalanceAmount,0)) BalanceAmount,
		[PostingPeriod],
		[PostingPeriodEndDate],
		SUM(ISNULL(CurrentAmount,0)) CurrentAmount,								
		SUM(ISNULL(ThirtyDays,0)) ThirtyDays,									
		SUM(ISNULL(SixtyDays,0)) SixtyDays,									
		SUM(ISNULL(NinetyDays,0)) NinetyDays,								
		SUM(ISNULL(OneHundredTwentyDays,0)) OneHundredTwentyDays,							
		SUM(ISNULL(Over120Days,0)) Over120Days,									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
	FROM #temp2
	GROUP BY
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		--[BilledAmount],
		--[AccountsPayableAmount],
		--[BalanceAmount],
		[PostingPeriod],
		[PostingPeriodEndDate],
		--[CurrentAmount],								
		--[ThirtyDays],									
		--[SixtyDays],									
		--[NinetyDays],								
		--[OneHundredTwentyDays],							
		--[Over120Days],									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
				
	ORDER BY 
		[CDPSortCode],
		[OrderNumber],
		[LineNumber]
END
IF OBJECT_ID('TempDB.dbo.#Temp3') IS NOT NULL
BEGIN
	--SELECT '#temp3'  --DEBUG-ONLY
	SELECT
  		[ID] = NEWID(),
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		SUM(ISNULL(BilledAmount,0)) BilledAmount,
		SUM(ISNULL(AccountsPayableAmount,0)) AccountsPayableAmount,
		SUM(ISNULL(BalanceAmount,0)) BalanceAmount,
		[PostingPeriod],
		[PostingPeriodEndDate],
		SUM(ISNULL(CurrentAmount,0)) CurrentAmount,								
		SUM(ISNULL(ThirtyDays,0)) ThirtyDays,									
		SUM(ISNULL(SixtyDays,0)) SixtyDays,									
		SUM(ISNULL(NinetyDays,0)) NinetyDays,								
		SUM(ISNULL(OneHundredTwentyDays,0)) OneHundredTwentyDays,							
		SUM(ISNULL(Over120Days,0)) Over120Days,									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
	FROM #temp3
	GROUP BY
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		--[BilledAmount],
		--[AccountsPayableAmount],
		--[BalanceAmount],
		[PostingPeriod],
		[PostingPeriodEndDate],
		--[CurrentAmount],								
		--[ThirtyDays],									
		--[SixtyDays],									
		--[NinetyDays],								
		--[OneHundredTwentyDays],							
		--[Over120Days],									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
				
	ORDER BY 
		[CDPSortCode],
		[OrderNumber],
		[LineNumber]
END
IF OBJECT_ID('TempDB.dbo.#Temp4') IS NOT NULL
BEGIN
	--SELECT '#temp4'  --DEBUG-ONLY
	SELECT
  		[ID] = NEWID(),
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		SUM(ISNULL(BilledAmount,0)) BilledAmount,
		SUM(ISNULL(AccountsPayableAmount,0)) AccountsPayableAmount,
		SUM(ISNULL(BalanceAmount,0)) BalanceAmount,
		[PostingPeriod],
		[PostingPeriodEndDate],
		SUM(ISNULL(CurrentAmount,0)) CurrentAmount,								
		SUM(ISNULL(ThirtyDays,0)) ThirtyDays,									
		SUM(ISNULL(SixtyDays,0)) SixtyDays,									
		SUM(ISNULL(NinetyDays,0)) NinetyDays,								
		SUM(ISNULL(OneHundredTwentyDays,0)) OneHundredTwentyDays,							
		SUM(ISNULL(Over120Days,0)) Over120Days,									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
	FROM #temp4
	GROUP BY
		[OfficeCode],
		[OfficeDescription],
		[CDPSortCode],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[OrderType],
		[OrderNumber],
		[LineNumber],
		[OrderDescription],
		[OrderStartDate],
		[OrderEndDate],
		[OrderProcessingControl],
		[OrderProcessingStatus],
		[TransactionType],
		[GLAccountCode],
		[GLAccountDescription],
		[GLXact],
		[GLSequence],
		[Reference],
		[BillingMonthYear],			
		--[BilledAmount],
		--[AccountsPayableAmount],
		--[BalanceAmount],
		[PostingPeriod],
		[PostingPeriodEndDate],
		--[CurrentAmount],								
		--[ThirtyDays],									
		--[SixtyDays],									
		--[NinetyDays],								
		--[OneHundredTwentyDays],							
		--[Over120Days],									
		[CashReceived],
		[BillingPeriod],
		[APPeriod] 
				
	ORDER BY 
		[CDPSortCode],
		[OrderNumber],
		[LineNumber]
END



--ORDER BY m.ORDER_NBR, ISNULL(m.LINE_NBR	,0)
	
END

DROP TABLE #aging_period_temp2

GO

--IF @@ERROR = 0
--BEGIN
--	--IF NOT EXISTS( SELECT * FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = 'Create_advsp_media_wip_detail_180110' )
--	--	INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
--	--	    SELECT COALESCE( VERSION_ID, 'v7.02.01' ), 'Create_advsp_media_wip_detail.sql', 
--	--			'Adds stored procedure advsp_media_wip_detail', 'Create_advsp_media_wip_detail_18010'
--	--			FROM dbo.ADVAN_UPDATE
--	GRANT ALL ON [advsp_media_wip_detail] TO PUBLIC AS dbo
--END
--GO

