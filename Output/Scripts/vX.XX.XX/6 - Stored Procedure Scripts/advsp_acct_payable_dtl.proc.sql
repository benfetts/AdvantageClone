-- stored procedure advsp_acct_payable_dtl to extract detail AP amounts
-- #00 12/31/09 - initial release
-- #00 01/05/10 - added GLACODE filter
-- v620 ************************************************************
-- #01 08/19/10 - added filter DELETE_FLAG <> 1 AND MODIFY_FLAG <> 1 via #ap_id_include
-- #02 08/18/12 - removed filter (#01) above, was incorrectly removing records (748-148)

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_acct_payable_dtl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_acct_payable_dtl]
GO

CREATE PROCEDURE [dbo].[advsp_acct_payable_dtl] --(@office_list varchar(4000) = NULL, @end_period varchar(6) = '999912')
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
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
	AB_FLAG							tinyint NULL,
	NON_BILL_FLG					tinyint NULL)
	
-- ==========================================================
-- TEMP TABLES
-- ==========================================================	
-- #ap_id_include (selects AP_ID's where DELETE_FLAG and MODIFY_FLAG are <> 1
CREATE TABLE #ap_id_include (AP_ID int NOT NULL, AP_SEQ smallint NOT NULL)
INSERT INTO #ap_id_include
SELECT h.AP_ID, h.AP_SEQ
FROM dbo.AP_HEADER AS h
--removed line below 8/18/12, but left #ap_id_include in script in case it is needed later
--WHERE ISNULL(h.DELETE_FLAG,0) <> 1 AND ISNULL(h.MODIFY_FLAG,0) <> 1
--SELECT * FROM #ap_id_include

-- ==========================================================
-- EXTRACTION ROUTINE
-- ==========================================================
-- AP_GL_DIST
INSERT INTO #ap_dtl
SELECT
	'G',
	h.AP_ID,
	h.AP_SEQ,
	NULL AS CL_CODE,
	NULL AS DIV_CODE,
	NULL AS PRD_CODE,
	h.AP_GL_AMT,
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'GL Acct ' + h.GLACODE,
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_GL_DIST AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ

-- AP_PRODUCTION
INSERT INTO #ap_dtl
SELECT
	'P',
	h.AP_ID,
	h.AP_SEQ,
	j.CL_CODE,
	j.DIV_CODE,
	j.PRD_CODE,
	ISNULL(h.AP_PROD_EXT_AMT,0) + ISNULL(h.EXT_NONRESALE_TAX,0),
	h.EXT_NONRESALE_TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Job ' + RTRIM(CAST(jc.JOB_NUMBER AS varchar(6))) + ' Comp ' + RTRIM(CAST(jc.JOB_COMPONENT_NBR AS varchar(6))),
	h.AR_INV_NBR,
	h.AR_TYPE,
	a.AR_INV_DATE,
	jc.AB_FLAG,
	h.AP_PROD_NOBILL_FLG
FROM #ap_id_include AS i	
JOIN dbo.AP_PRODUCTION AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.JOB_COMPONENT AS jc
	ON h.JOB_NUMBER = jc.JOB_NUMBER
	AND h.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
JOIN dbo.JOB_LOG AS j
	ON jc.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.V_AR_INVOICE_DATES AS a
	ON h.AR_INV_NBR = a.AR_INV_NBR
	AND h.AR_TYPE = a.AR_TYPE

-- AP_MAG
INSERT INTO #ap_dtl
SELECT
	'M',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	h.DISBURSED_AMT,
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_MAGAZINE AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.MAG_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_MAGAZINE
INSERT INTO #ap_dtl
SELECT
	'M',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	h.DISBURSED_AMT,
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_MAGAZINE AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.MAGAZINE_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_NEWS
INSERT INTO #ap_dtl
SELECT
	'N',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	h.DISBURSED_AMT,
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_NEWSPAPER AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.NEWS_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_NEWSPAPER
INSERT INTO #ap_dtl
SELECT
	'N',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	h.DISBURSED_AMT,
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_NEWSPAPER AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.NEWSPAPER_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_INTERNET
INSERT INTO #ap_dtl
SELECT
	'I',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISCOUNT_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_INTERNET AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.INTERNET_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_OUTDOOR
INSERT INTO #ap_dtl
SELECT
	'O',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISCOUNT_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))) + ' Line ' + RTRIM(CAST(h.ORDER_LINE_NBR AS varchar(4))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_OUTDOOR AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.OUTDOOR_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR

-- AP_RADIO
INSERT INTO #ap_dtl
SELECT
	'R',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.EXT_NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISC_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_RADIO AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.RADIO_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR 
WHERE m.REV_NBR = (SELECT MAX(m2.REV_NBR) FROM dbo.RADIO_HEADER AS m2 WHERE m.ORDER_NBR = m2.ORDER_NBR)

-- AP_RADIO (NEW)
INSERT INTO #ap_dtl
SELECT
	'R',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.EXT_NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISC_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_RADIO AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.RADIO_HDR AS m
	ON h.ORDER_NBR = m.ORDER_NBR 

-- AP_TELEVISION
INSERT INTO #ap_dtl
SELECT
	'T',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.EXT_NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISC_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_TV AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.TV_HEADER AS m
	ON h.ORDER_NBR = m.ORDER_NBR 
WHERE m.REV_NBR = (SELECT MAX(m2.REV_NBR) FROM dbo.TV_HEADER AS m2 WHERE m.ORDER_NBR = m2.ORDER_NBR)

-- AP_TELEVISION (NEW)
INSERT INTO #ap_dtl
SELECT
	'T',
	h.AP_ID,
	h.AP_SEQ,
	m.CL_CODE,
	m.DIV_CODE,
	m.PRD_CODE,
	ISNULL(h.EXT_NET_AMT,0) + ISNULL(h.NETCHARGES,0) 
		+ ISNULL(h.VENDOR_TAX,0) + ISNULL(h.DISC_AMT,0),
	NULL AS TAX,
	h.POST_PERIOD,
	h.GLACODE,
	'Order ' + RTRIM(CAST(h.ORDER_NBR AS varchar(6))),
	NULL AS AR_INV_NBR,
	NULL AS AR_INV_TYPE,
	NULL AS AR_INV_DATE,
	NULL AS AB_FLAG,
	NULL AS NON_BILL_FLAG
FROM #ap_id_include AS i	
JOIN dbo.AP_TV AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.TV_HDR AS m
	ON h.ORDER_NBR = m.ORDER_NBR 

SELECT * FROM #ap_dtl

END
GO

IF ( @@ERROR = 0 )
	GRANT EXECUTE ON [advsp_acct_payable_dtl] TO PUBLIC AS dbo
GO	
