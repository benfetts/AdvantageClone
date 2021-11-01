
CREATE PROCEDURE [dbo].[advsp_ar_media_type]
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #media_type (
	AR_INV_NBR							int NOT NULL,
	ORDER_NBR							int NULL,
	MEDIA_TYPE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS )

-- ==========================================================
-- TEMP TABLE TO STORE MIN ORDER NUMBER FOR EACH INVOICE
-- ==========================================================
CREATE TABLE #min_order (
	AR_INV_NBR							int NOT NULL,
	ORDER_NBR							int NULL )

-- ==========================================================
-- TEMP TABLE TO STORE MAX REVISION NBR FOR RADIO/TV ORDERS
-- ==========================================================
CREATE TABLE #max_rev (
	ORDER_NBR							int NOT NULL,
	REV_NBR								smallint NULL )

-- ==========================================================
-- EXTRACTION ROUTINE FOR MIN ORDER
-- ==========================================================
INSERT INTO #min_order
SELECT
	d.AR_INV_NBR,
	MIN(d.ORDER_NBR)
FROM dbo.ARINV_MEDIA AS d
GROUP BY d.AR_INV_NBR

-- ==========================================================
-- MAIN EXTRACTION ROUTINE
-- ==========================================================
-- Magazine (Old)
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.MAG_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Magazine (New)
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.MAGAZINE_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Newspaper (Old)
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.NEWS_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Newspaper (New)
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.NEWSPAPER_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Internet
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.INTERNET_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Outdoor
INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.OUTDOOR_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR

-- Radio
INSERT INTO #max_rev
SELECT 
	h.ORDER_NBR,
	MAX(h.REV_NBR)
FROM dbo.RADIO_HEADER AS h
GROUP BY h.ORDER_NBR

INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.RADIO_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN #max_rev AS r
	ON h.ORDER_NBR = r.ORDER_NBR

DELETE #max_rev

-- Television
INSERT INTO #max_rev
SELECT 
	h.ORDER_NBR,
	MAX(h.REV_NBR)
FROM dbo.TV_HEADER AS h
GROUP BY h.ORDER_NBR

INSERT INTO #media_type 
SELECT DISTINCT 
	m.AR_INV_NBR,
	m.ORDER_NBR,
	h.MEDIA_TYPE
FROM #min_order AS m
JOIN dbo.TV_HEADER AS h
	ON m.ORDER_NBR = h.ORDER_NBR
JOIN #max_rev AS r
	ON h.ORDER_NBR = r.ORDER_NBR

DELETE #max_rev

SELECT * FROM #media_type

END

