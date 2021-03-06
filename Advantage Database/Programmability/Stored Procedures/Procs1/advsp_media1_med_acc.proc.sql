IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_media1_med_acc]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media1_med_acc]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_media1_med_acc] (@period varchar(6) = '219912', @zero_balance tinyint = 1, @order_option tinyint = 1)
AS
BEGIN
	SET NOCOUNT ON;
	
-- ========================================================================
-- Stored procedure used for media status reports in Advantage and Adassist
-- #00 09/27/11 - copied from "Create_sp_media_med_acc.sql" - substituted views for old bcst and added routines for new billed bcst
-- #01 11/05/13 - v660 re-dimensioned REV_NBR fro tinyint to smallint throughout (script will also work in v650)
-- #02 07/11/14 - v660 added order start and end dates
-- #03 05/06/15 - v660 removed old media and only download unreconciled orders
-- #04 05/10/15 - v660 added identifier #MedAcc to final select statement
-- #05 05/15/15 - v660 added back old media and added period filter to resolve problem with running report for prior periods
-- #06 08/21/15 - v660 modified "#MedAccQ1" with filter to exclude reconciled orders using new variable @zero_balance (735-1816)
-- #07 11/17/15 - v660 added filter for open/closed orders (735-786)
-- #08 12/02/15 - v660 fixed outer join to AP TV and AP Radio tables - s/b inner join (735-786)
-- #09 12/09/15 - v660 un-did fix #08 (left join was correct to include old bcst), need link to #open_closed instead for old bcst (735-786
-- #-- 01/28/16 - v660 added go statements at end of script per DR request
-- #-- 01/29/16 - Removed grant statement for check in to msbin source

--@zero_balance: 0 = Exclude all "0" balance orders, 1 = Exclude reconciled orders
--@order_option: 1 = open and closed, 2 = open only
-- ========================================================================	

--  TEMP TABLE OF OPEN AND CLOSED ORDERS						--#07
	CREATE TABLE #open_closed(
		--[ORDER_TYPE] varchar(1) NOT NULL,
		--[VER_ID] tinyint NOT NULL,
		[ORDER_NBR] int NOT NULL,
		[ORD_PROCESS_CONTRL] tinyint NULL)
	INSERT INTO #open_closed	
	SELECT
		--[ORDER_TYPE],
		--[VER_ID],
		[ORDER_NBR],
		[ORD_PROCESS_CONTRL]
	FROM dbo.V_MEDIA_HDR
	WHERE (@order_option = 1	OR (@order_option = 2 AND ORD_PROCESS_CONTRL NOT IN(6, 12)))	
--SELECT * FROM #open_closed
	

--	MAIN DATA TABLE =======================================================
	CREATE TABLE #MedAcc(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] int NULL,
		[MONTH] tinyint NULL,
		[YEAR] smallint NULL,
		[DISCOUNT] decimal(15,2) NULL,
		[NETCHARGE] decimal(15,2) NULL,
		[TAX] decimal(15,2) NULL,
		[LINE_NET] decimal(15,2) NULL,
		[GLACODE_WIP] varchar(30),
		[GLEXACT] int NULL,
		[GLESEQ_WIP] smallint NULL,
		[TYPE] varchar(10) NULL,
		[VN_FRL_EMP_CODE] varchar(6) NULL,
		[AP_INV_VCHR] varchar(20) NULL,
		[AR_INV_NBR] int NULL,
		[AR_INV_SEQ] smallint NULL,
		[AR_TYPE] varchar(3) NULL,
		[PERIOD] varchar(8) NULL,				
		[START_DATE] smalldatetime NULL,						--#02
		[END_DATE] smalldatetime NULL)							--#02

--	=======================================================================	
--	BROADCAST MEDIA_AMTS
--	=======================================================================
CREATE TABLE #Media_Amts ( 
	ORDER_NBR						int NULL, 
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	LINE_NET						decimal(15,2) NULL, 
	COMM_AMT						decimal(15,2) NULL, 
	REBATE_AMT						decimal(15,2) NULL, 
	LINE_DISC						decimal(15,2) NULL, 
	VENDOR_TAX						decimal(15,2) NULL, 
	STATE_TAX						decimal(15,2) NULL, 
	COUNTY_TAX						decimal(15,2) NULL, 
	CITY_TAX						decimal(15,2) NULL, 
	SPOTS							smallint NULL, 
	BILL_AMT						decimal(15,2) NULL, 
	AR_INV_NBR						int NULL, 
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	AR_INV_SEQ						smallint NULL, 
	[MONTH]							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[YEAR]							int NULL, 
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	MEDIA_TYPE						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_CITY					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_COS						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_COUNTY					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_SALES					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_STATE					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLACODE_WIP						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLESEQ_CITY						smallint NULL, 
	GLESEQ_COS						smallint NULL, 
	GLESEQ_COUNTY					smallint NULL, 
	GLESEQ_SALES					smallint NULL, 
	GLESEQ_STATE					smallint NULL, 
	GLESEQ_WIP						smallint NULL, 
	GLEXACT							int NULL, 
	GLEXACT_DEF						int NULL, 
	RECONCILE_LINE					smallint NULL, 
	DO_NOT_BILL						smallint NULL, 
	BILL_TYPE_FLAG					smallint NULL)

-- RADIO (old) ==========================================================================
INSERT INTO #Media_Amts
SELECT 
	d.ORDER_NBR, 
	d.LINE_NBR, 
	d.REV_NBR, 
	d.SEQ_NBR, 
	d.LINE_NET, 
	d.COMM_AMT, 
	d.REBATE_AMT, 
	d.LINE_DISC, 
	d.VENDOR_TAX, 
	d.STATE_TAX, 
	d.COUNTY_TAX, 
	d.CITY_TAX, 
	d.SPOTS, 
	d.BILL_AMT, 
	d.AR_INV_NBR, 
	d.AR_TYPE, 
	d.AR_INV_SEQ, 
	d.[MONTH], 
	d.[YEAR], 
	d.BILLING_USER, 
	'RADIO', 
	d.GLACODE_CITY, 
	d.GLACODE_COS, 
	d.GLACODE_COUNTY, 
	d.GLACODE_SALES, 
	d.GLACODE_STATE, 
	d.GLACODE_WIP, 
	d.GLESEQ_CITY, 
	d.GLESEQ_COS, 
	d.GLESEQ_COUNTY, 
	d.GLESEQ_SALES, 
	d.GLESEQ_STATE, 
	d.GLESEQ_WIP, 
	d.GLEXACT, 
	d.GLEXACT_DEF, 
	d.RECONCILE_LINE, 
	d.DO_NOT_BILL, 
	NULL
FROM dbo.V_RADIO_AMOUNTS AS d 
JOIN #open_closed AS oc											--#07
	ON d.ORDER_NBR = oc.ORDER_NBR									
WHERE ((d.LINE_NET <>0 Or d.LINE_DISC <>0 Or d.VENDOR_TAX <>0 Or d.BILL_AMT <> 0) AND d.AR_INV_NBR IS NOT NULL)
		OR (d.RECONCILE_LINE = 1 AND d.DO_NOT_BILL = 1)
		
-- TV (old) ==========================================================================
INSERT INTO #Media_Amts
SELECT 
	d.ORDER_NBR, 
	d.LINE_NBR, 
	d.REV_NBR, 
	d.SEQ_NBR, 
	d.LINE_NET, 
	d.COMM_AMT, 
	d.REBATE_AMT, 
	d.LINE_DISC, 
	d.VENDOR_TAX, 
	d.STATE_TAX, 
	d.COUNTY_TAX, 
	d.CITY_TAX, 
	d.SPOTS, 
	d.BILL_AMT, 
	d.AR_INV_NBR, 
	d.AR_TYPE, 
	d.AR_INV_SEQ, 
	d.[MONTH], 
	d.[YEAR], 
	d.BILLING_USER, 
	'TV', 
	d.GLACODE_CITY, 
	d.GLACODE_COS, 
	d.GLACODE_COUNTY, 
	d.GLACODE_SALES, 
	d.GLACODE_STATE, 
	d.GLACODE_WIP, 
	d.GLESEQ_CITY, 
	d.GLESEQ_COS, 
	d.GLESEQ_COUNTY, 
	d.GLESEQ_SALES, 
	d.GLESEQ_STATE, 
	d.GLESEQ_WIP, 
	d.GLEXACT, 
	d.GLEXACT_DEF, 
	d.RECONCILE_LINE, 
	d.DO_NOT_BILL, 
	NULL
FROM dbo.V_TV_AMOUNTS AS d 
JOIN #open_closed AS oc
	ON d.ORDER_NBR = oc.ORDER_NBR
WHERE ((d.LINE_NET <>0 Or d.LINE_DISC <>0 Or d.VENDOR_TAX <>0 Or d.BILL_AMT <> 0) AND d.AR_INV_NBR IS NOT NULL)
		OR (d.RECONCILE_LINE = 1 AND d.DO_NOT_BILL = 1)

--SELECT * FROM #Media_Amts		

--	=======================================================================	
--	BILLED AMOUNTS
--	=======================================================================	
--	BROADCAST (old ) ======================================================
--	Broadcast bill flag
CREATE TABLE #broadcast_bill_flag(
	[ORDER_NBR] int NOT NULL,
	[REV_NBR] smallint NOT NULL,
	[RECONCILE_FLAG] tinyint NULL,
	[BILL_TYPE_FLAG] tinyint NULL)

INSERT INTO #broadcast_bill_flag
SELECT h.ORDER_NBR,
	h.REV_NBR,
	ISNULL(h.RECONCILE_FLAG,0),
	ISNULL(h.BILL_TYPE_FLAG,0)
FROM dbo.RADIO_HEADER h
WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.RADIO_HEADER h2
	WHERE h.ORDER_NBR = h2.ORDER_NBR)

INSERT INTO #broadcast_bill_flag
SELECT h.ORDER_NBR,
	h.REV_NBR,
	ISNULL(h.RECONCILE_FLAG,0),
	ISNULL(h.BILL_TYPE_FLAG,0)
FROM dbo.TV_HEADER h
WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.TV_HEADER h2
	WHERE h.ORDER_NBR = h2.ORDER_NBR)

--	Broadcast media billed amounts
	INSERT INTO #MedAcc
	SELECT ma.ORDER_NBR,
		0,
		dbo.fn_month_abbr_nbr(ma.[MONTH]),
		ma.[YEAR],
		ISNULL(ma.LINE_DISC,0),
		0,
		ISNULL(ma.VENDOR_TAX,0),
		(ISNULL(ma.LINE_DISC,0) + ISNULL(ma.VENDOR_TAX,0) 
			+ ma.LINE_NET) * -1,
		ma.GLACODE_WIP,
		ma.GLEXACT,
		ma.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		ma.AR_INV_NBR,
		ma.AR_INV_SEQ,
		ma.AR_TYPE,
		a.AR_POST_PERIOD,
		NULL,													--#02
		NULL													--#02
	FROM #Media_Amts ma
	JOIN #broadcast_bill_flag bf
		ON ma.ORDER_NBR = bf.ORDER_NBR
	JOIN V_AR_INVOICE_DATES a
		ON ma.AR_INV_NBR = a.AR_INV_NBR
		AND ma.AR_TYPE = a.AR_TYPE
	WHERE bf.BILL_TYPE_FLAG <> 1
		AND bf.RECONCILE_FLAG = 0

--	Broadcast media reconciled and not-billed amounts
	INSERT INTO #MedAcc
	SELECT ma.ORDER_NBR,
		0,
		dbo.fn_month_abbr_nbr(ma.[MONTH]),
		ma.[YEAR],
		ISNULL(ma.LINE_DISC,0),
		0,
		ISNULL(ma.VENDOR_TAX,0),
		(ISNULL(ma.LINE_DISC,0) + ISNULL(ma.VENDOR_TAX,0) + ISNULL(ma.LINE_NET,0)) * -1,	--JP 04/08/11
		ma.GLACODE_WIP,
		ma.GLEXACT,
		ma.GLESEQ_WIP,
		'RECONCILE',
		NULL,
		NULL,
		0,
		0,
		'IN',
		gl.GLEHPP,
		NULL,													--#02
		NULL													--#02
	FROM #Media_Amts ma
	JOIN dbo.GLENTHDR gl
		ON ma.GLEXACT = gl.GLEHXACT
	JOIN #broadcast_bill_flag bf
		ON ma.ORDER_NBR = bf.ORDER_NBR
	WHERE ma.RECONCILE_LINE = 1
		AND ma.DO_NOT_BILL = 1
		AND bf.RECONCILE_FLAG = 0

--	Radio net charges
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		0,														--1/20/2011
		0,
		d.BRDCAST_YEAR,
		0,
		ISNULL(d.NETCHARGES,0),
		ISNULL(d.VENDOR_TAX_NC,0),
		(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0)) * -1,		
		gl.NC_GLACODE_WIP,
		gl.NC_GLEXACT,
		gl.NC_GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		NULL,													--#02
		NULL													--#02
	FROM dbo.RADIO_DETAIL1 d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	JOIN #broadcast_bill_flag bf
		ON d.ORDER_NBR = bf.ORDER_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	JOIN dbo.RADIO_GL gl
		ON d.ORDER_NBR = gl.ORDER_NBR
		AND d.LINE_NBR = gl.LINE_NBR
		AND d.REV_NBR = gl.REV_NBR
		AND d.SEQ_NBR = gl.SEQ_NBR
		AND d.BRDCAST_YEAR = gl.BRDCAST_YEAR
	WHERE bf.BILL_TYPE_FLAG <> 1 
		AND bf.RECONCILE_FLAG = 0
		AND ISNULL(d.NETCHARGES,0)<>0

--	TV net charges
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		0,				--1/20/2011
		0,
		d.BRDCAST_YEAR,
		0,
		ISNULL(d.NETCHARGES,0),
		ISNULL(d.VENDOR_TAX_NC,0),
		(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0)) * -1,		
		gl.NC_GLACODE_WIP,
		gl.NC_GLEXACT,
		gl.NC_GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		NULL,													--#02
		NULL													--#02
	FROM dbo.TV_DETAIL1 d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	JOIN #broadcast_bill_flag bf
		ON d.ORDER_NBR = bf.ORDER_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	JOIN dbo.TV_GL gl
		ON d.ORDER_NBR = gl.ORDER_NBR
		AND d.LINE_NBR = gl.LINE_NBR
		AND d.REV_NBR = gl.REV_NBR
		AND d.SEQ_NBR = gl.SEQ_NBR
		AND d.BRDCAST_YEAR = gl.BRDCAST_YEAR
	WHERE bf.BILL_TYPE_FLAG <> 1 
		AND bf.RECONCILE_FLAG = 0
		AND ISNULL(d.NETCHARGES,0)<>0

--	MAGAZINE ===========================================================
--	Magazine dates for active rev
	CREATE TABLE #magazine_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,
		[END_DATE] smalldatetime NULL)							--#02

	INSERT INTO #magazine_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.START_DATE,
		d.END_DATE												--#02
	FROM dbo.MAGAZINE_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1

--	Magazine media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ ISNULL(d.EXT_NET_AMT,0)) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.MAGAZINE_DETAIL d
	JOIN #magazine_dates dt
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE ISNULL(d.BILL_TYPE_FLAG,0) <> 1

--	NEWSPAPER ===========================================================
--	Newspaper dates for active rev
	CREATE TABLE #newspaper_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,
		[END_DATE] smalldatetime NULL)							--#02

	INSERT INTO #newspaper_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.START_DATE,
		d.END_DATE												--#02
	FROM dbo.NEWSPAPER_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1	

--	Newspaper media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ d.EXT_NET_AMT) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.NEWSPAPER_DETAIL d
	JOIN #newspaper_dates dt
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE d.BILL_TYPE_FLAG <> 1

--	OUTDOOR ==========================================================
-- Outdoor dates for active rev 
	CREATE TABLE #outdoor_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,
		[END_DATE] smalldatetime NULL)							--#02

	INSERT INTO #outdoor_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.POST_DATE,
		d.END_DATE												--#02
	FROM dbo.OUTDOOR_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1	

--	Outdoor media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ d.EXT_NET_AMT) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.OUTDOOR_DETAIL d
	JOIN #outdoor_dates dt
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE d.BILL_TYPE_FLAG <> 1

--	INTERNET ===========================================================
--	Internet dates for active rev
	CREATE TABLE #internet_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,
		[END_DATE] smalldatetime NULL)							--#02

	INSERT INTO #internet_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.START_DATE,
		d.END_DATE												--#02
	FROM dbo.INTERNET_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1	

--	Internet media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ d.EXT_NET_AMT) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.INTERNET_DETAIL d
	JOIN #internet_dates dt
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE d.BILL_TYPE_FLAG <> 1

--	NEWS ===========================================================
--	News maximum sequence number
	CREATE TABLE #news_max_seq(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL)

	INSERT INTO #news_max_seq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.NEWS_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.NEWS_DETAIL d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR 

--	News dates for max sequence
	CREATE TABLE #news_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL)

	INSERT INTO #news_dates
	SELECT ms.ORDER_NBR,
		ms.LINE_NBR,
		ms.REV_NBR,
		ms.SEQ_NBR,
		d.INSERT_DATE
	FROM #news_max_seq ms
	JOIN dbo.NEWS_DETAIL d
		ON ms.ORDER_NBR = d.ORDER_NBR
		AND ms.LINE_NBR = d.LINE_NBR
		AND ms.REV_NBR = d.REV_NBR
		AND ms.SEQ_NBR = d.SEQ_NBR	
		
--	News media billed amounts
	INSERT INTO #MedAcc
	SELECT ba.ORDER_NBR,
		ba.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(ba.LINE_DISC,0),
		ISNULL(ba.NETCHARGES,0),
		ISNULL(ba.VENDOR_TAX,0),
		(ISNULL(ba.LINE_DISC,0) + ISNULL(ba.NETCHARGES,0) + ISNULL(ba.VENDOR_TAX,0)
			+ ba.LINE_NET) * -1,
		ba.GLACODE_WIP,
		ba.GLEXACT,
		ba.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		ba.AR_INV_NBR,
		ISNULL(ba.AR_INV_SEQ,0),
		ba.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.INSERT_DATE											--#02
	FROM dbo.MEDIA_BILL_AMTS ba
	JOIN #news_dates dt
		ON ba.ORDER_NBR = dt.ORDER_NBR
		AND ba.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON ba.AR_INV_NBR = a.AR_INV_NBR
		AND ba.AR_TYPE = a.AR_TYPE
	WHERE ba.BILL_COMM_NET <> 1
		AND ba.MEDIA_TYPE = 'NEWS'
		AND ISNULL(ba.AR_INV_SEQ, 0) <> 99

--	MAG ===========================================================
--	Mag maximum sequence number
	CREATE TABLE #mag_max_seq(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL)

	INSERT INTO #mag_max_seq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.MAG_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.MAG_DETAIL d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR) 
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR

--	Mag dates for max sequence
	CREATE TABLE #mag_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL)

	INSERT INTO #mag_dates
	SELECT ms.ORDER_NBR,
		ms.LINE_NBR,
		ms.REV_NBR,
		ms.SEQ_NBR,
		d.INSERT_DATE
	FROM #mag_max_seq ms
	JOIN dbo.MAG_DETAIL d
		ON ms.ORDER_NBR = d.ORDER_NBR
		AND ms.LINE_NBR = d.LINE_NBR
		AND ms.REV_NBR = d.REV_NBR
		AND ms.SEQ_NBR = d.SEQ_NBR

--	Mag media billed amounts
	INSERT INTO #MedAcc
	SELECT ba.ORDER_NBR,
		ba.LINE_NBR,
		MONTH(dt.[INSERT_DATE]),
		YEAR(dt.[INSERT_DATE]),
		ISNULL(ba.LINE_DISC,0),
		ISNULL(ba.NETCHARGES,0),
		ISNULL(ba.VENDOR_TAX,0),
		(ISNULL(ba.LINE_DISC,0) + ISNULL(ba.NETCHARGES,0) + ISNULL(ba.VENDOR_TAX,0)
			+ ba.LINE_NET) * -1,
		ba.GLACODE_WIP,
		ba.GLEXACT,
		ba.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		ba.AR_INV_NBR,
		ISNULL(ba.AR_INV_SEQ,0),
		ba.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.INSERT_DATE											--#02
	FROM dbo.MEDIA_BILL_AMTS ba
	JOIN #mag_dates dt
		ON ba.ORDER_NBR = dt.ORDER_NBR
		AND ba.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON ba.AR_INV_NBR = a.AR_INV_NBR
		AND ba.AR_TYPE = a.AR_TYPE
	WHERE ba.BILL_COMM_NET <> 1
		AND ba.MEDIA_TYPE = 'MAG'
		AND ISNULL(ba.AR_INV_SEQ, 0) <> 99
		
--	RADIO (new) ===========================================================
--	Radio dates for active rev
	CREATE TABLE #radio_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,			
		[END_DATE] smalldatetime NULL,							--#02			
		[MONTH_NBR] int NULL,
		[YEAR_NBR] int NULL)

	INSERT INTO #radio_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.START_DATE,
		d.END_DATE,												--#02
		d.MONTH_NBR,
		d.YEAR_NBR
	FROM dbo.RADIO_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1	

--	Radio (new) media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		dt.MONTH_NBR,	--JR modified from MONTH(dt.[INSERT_DATE])
		dt.YEAR_NBR,		--JR modified from YEAR(dt.[INSERT_DATE])
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ d.EXT_NET_AMT) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.RADIO_DETAIL d
	JOIN #radio_dates dt	--JR fix join from internet_dates to radio_dates 9/20/11
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE d.BILL_TYPE_FLAG <> 1

--	TV (new) ===========================================================
--	TV dates for active rev
	CREATE TABLE #tv_dates(
		[ORDER_NBR] int NOT NULL,
		[LINE_NBR] smallint NOT NULL,
		[REV_NBR] smallint NOT NULL,
		[SEQ_NBR] tinyint NOT NULL,
		[INSERT_DATE] smalldatetime NULL,
		[END_DATE] smalldatetime NULL,							--#02	
		[MONTH_NBR] int NULL,
		[YEAR_NBR] int NULL)

	INSERT INTO #tv_dates
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.START_DATE,
		d.END_DATE,												--#02
		d.MONTH_NBR,
		d.YEAR_NBR
	FROM dbo.TV_DETAIL d
	JOIN #open_closed AS oc										--#07
		ON d.ORDER_NBR = oc.ORDER_NBR
	WHERE d.ACTIVE_REV = 1	

--	TV (new) media billed amounts
	INSERT INTO #MedAcc
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		dt.MONTH_NBR,	--JR modified from MONTH(dt.[INSERT_DATE])
		dt.YEAR_NBR,		--JR modified from YEAR(dt.[INSERT_DATE)
		ISNULL(d.DISCOUNT_AMT,0),
		ISNULL(d.NETCHARGE,0),
		ISNULL(d.NON_RESALE_AMT,0),
		(ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.NON_RESALE_AMT,0) 
			+ d.EXT_NET_AMT) * -1,
		d.GLACODE_WIP,
		d.GLEXACT,
		d.GLESEQ_WIP,
		'BILLING',
		NULL,
		NULL,
		d.AR_INV_NBR,
		ISNULL(d.AR_INV_SEQ,0),
		d.AR_TYPE,
		a.AR_POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.TV_DETAIL d
	JOIN #tv_dates dt	--JR fix join from internet_dates to radio_dates 9/20/11
		ON d.ORDER_NBR = dt.ORDER_NBR
		AND d.LINE_NBR = dt.LINE_NBR
	JOIN V_AR_INVOICE_DATES a
		ON d.AR_INV_NBR = a.AR_INV_NBR
		AND d.AR_TYPE = a.AR_TYPE
	WHERE d.BILL_TYPE_FLAG <> 1


--	=======================================================================	
--	ACCOUNTS PAYABLE
--	=====================================================================

--	Radio AP ========================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,	--JR modified from Null 9/20/11 to pull populate for new broadcast
		CASE ap.REWRITE_FLAG
			WHEN 1 THEN dt.MONTH_NBR
			ELSE dbo.fn_month_abbr_nbr(ap.BRDCAST_MONTH)
			END AS [MONTH],
		CASE ap.REWRITE_FLAG
			WHEN 1 THEN dt.YEAR_NBR
			ELSE ap.BRDCAST_YEAR
			END AS [YEAR],
		ISNULL(ap.DISC_AMT,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISC_AMT,0) + ISNULL(ap.NETCHARGES,0) + ISNULL(ap.VENDOR_TAX,0)
			+ ISNULL(EXT_NET_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_RADIO ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	LEFT JOIN #radio_dates dt									--#08, #09
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR
	JOIN #open_closed AS oc										--#09
		ON ap.ORDER_NBR = oc.ORDER_NBR	
	WHERE ISNULL(ap.RECONCILE_FLAG,0) = 0

--	TV AP ==========================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,	--JR modified from Null 9/20/11 to populate for new broadcast
		CASE ap.REWRITE_FLAG
			WHEN 1 THEN dt.MONTH_NBR
			ELSE dbo.fn_month_abbr_nbr(ap.BRDCAST_MONTH)
			END AS [MONTH],
		CASE ap.REWRITE_FLAG
			WHEN 1 THEN dt.YEAR_NBR
			ELSE ap.BRDCAST_YEAR
			END AS [YEAR],
		ISNULL(ap.DISC_AMT,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISC_AMT,0) + ISNULL(ap.NETCHARGES,0) + ISNULL(ap.VENDOR_TAX,0)
			+ ISNULL(EXT_NET_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_TV ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	LEFT JOIN #tv_dates dt										--#08, #09
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR
	JOIN #open_closed AS oc										--#09
		ON ap.ORDER_NBR = oc.ORDER_NBR	
	WHERE ISNULL(ap.RECONCILE_FLAG,0) = 0


--	Magazine AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_LN,0) + ISNULL(ap.DISCOUNT_NC,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISBURSED_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_MAGAZINE ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #magazine_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR

--	Newspaper AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_LN,0) + ISNULL(ap.DISCOUNT_NC,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISBURSED_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_NEWSPAPER ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #newspaper_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR

--	Outdoor AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_AMT,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISCOUNT_AMT,0) + ISNULL(ap.NETCHARGES,0) + ISNULL(ap.VENDOR_TAX,0)
			+ ISNULL(ap.NET_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_OUTDOOR ap		
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #outdoor_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR

--	Internet AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_AMT,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISCOUNT_AMT,0) + ISNULL(ap.NETCHARGES,0) + ISNULL(ap.VENDOR_TAX,0)
			+ ISNULL(ap.NET_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.END_DATE												--#02
	FROM dbo.AP_INTERNET ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #internet_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR

--	Mag AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_LN,0) + ISNULL(ap.DISCOUNT_NC,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISBURSED_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.INSERT_DATE											--#02
	FROM dbo.AP_MAGAZINE ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #mag_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR

--	News AP ===============================================================
	INSERT INTO #MedAcc
	SELECT ap.ORDER_NBR,
		ap.ORDER_LINE_NBR,
		MONTH(dt.INSERT_DATE),
		YEAR(dt.INSERT_DATE),
		ISNULL(ap.DISCOUNT_LN,0) + ISNULL(ap.DISCOUNT_NC,0),
		ISNULL(ap.NETCHARGES,0),
		ISNULL(ap.VENDOR_TAX,0),
		ISNULL(ap.DISBURSED_AMT,0),
		ap.GLACODE,
		ap.GLEXACT,
		ap.GLESEQ,
		'AP',
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		NULL,
		NULL,
		NULL,
		ap.POST_PERIOD,
		dt.INSERT_DATE,											--#02
		dt.INSERT_DATE											--#02
	FROM dbo.AP_NEWSPAPER ap
	JOIN dbo.AP_HEADER ah
		ON ap.AP_ID = ah.AP_ID
		AND ap.AP_SEQ = ah.AP_SEQ
	JOIN #news_dates dt
		ON ap.ORDER_NBR = dt.ORDER_NBR
		AND ap.ORDER_LINE_NBR = dt.LINE_NBR


	-- Creates a table of open orders							--#03
	CREATE TABLE #MedAccQ1(
		ORDER_NBR					int NULL,
		LINE_NET					decimal(15,2) NULL)
		
	IF @zero_balance = 0										--#06 (exclude all 0 balance orders)
		BEGIN
			INSERT INTO #MedAccQ1
			SELECT
				m.ORDER_NBR,
				SUM(m.LINE_NET)
			FROM #MedAcc AS m
			WHERE m.PERIOD <= @period							--#05
			GROUP BY m.ORDER_NBR
			HAVING SUM(m.LINE_NET) <= -.01 OR SUM(m.LINE_NET) >= .01 
		END
	ELSE														--#06 (exclude reconciled orders)
		BEGIN
			INSERT INTO #MedAccQ1
			SELECT
				m.ORDER_NBR,
				0												--#06 SUM(m.LINE_NET)
			FROM #MedAcc AS m
			JOIN dbo.V_MEDIA_HDR2 AS h
			ON m.ORDER_NBR = h.ORDER_NBR
			WHERE m.PERIOD <= @period							--#05
				AND ISNULL(h.RECONCILE_FLAG,0) = 0				
			GROUP BY m.ORDER_NBR	
		END	
				
	--Final SELECT statement									--#03
	SELECT #MedAcc.* 
	FROM #MedAcc
	JOIN #MedAccQ1
	ON #MedAcc.ORDER_NBR = #MedAccQ1.ORDER_NBR
	
END
GO

