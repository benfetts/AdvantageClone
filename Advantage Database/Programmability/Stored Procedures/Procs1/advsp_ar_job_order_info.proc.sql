
CREATE PROCEDURE [dbo].[advsp_ar_job_order_info]
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #job_info (
	AR_INV_NBR							int NOT NULL,
	JOB_NUMBER							int NULL,
	JOB_DESCRIPTION						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR							int NULL,
	REC_SOURCE							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS )

-- ==========================================================
-- TEMP TABLE #min_job_order
-- ==========================================================
CREATE TABLE #min_job_order (
	AR_INV_NBR							int NOT NULL,
	JOB_ORDER_NBR						int NULL,
	LINE_NBR 							smallint NULL )

-- ==========================================================
-- TEMP TABLE #max_rev_seq
-- ==========================================================
CREATE TABLE #max_rev_seq (
	ORDER_NBR							int NOT NULL,
	LINE_NBR							smallint NOT NULL,
	REV_NBR								smallint NULL,
	SEQ_NBR								smallint NULL,
	BRDCAST_YEAR						int NULL)

-- ==========================================================
-- MAIN EXTRACTION ROUTINE
-- ==========================================================
-- PRODUCTION------------------------------------------------
-- Find the minimum job for each invoice
INSERT INTO #min_job_order
SELECT 
	AR_INV_NBR,
	MIN(JOB_NUMBER),
	NULL
FROM dbo.ARINV_JOB
GROUP BY AR_INV_NBR
--SELECT * FROM #min_job_order

-- Extract the job description for the minimum job
INSERT INTO #job_info
SELECT
	m.AR_INV_NBR,
	m.JOB_ORDER_NBR,
	j.JOB_DESC,
	NULL,
	'P'
FROM #min_job_order AS m
LEFT JOIN dbo.JOB_LOG AS j
	ON m.JOB_ORDER_NBR = j.JOB_NUMBER

-- Clear the #min_job_order for use by media
DELETE #min_job_order

-- MEDIA-----------------------------------------------------
-- Find the minimum order and line number for each invoice
INSERT INTO #min_job_order
SELECT 
	d.AR_INV_NBR,
	d.ORDER_NBR,
	MIN(d.LINE_NBR)
FROM dbo.ARINV_MEDIA AS d
LEFT JOIN #job_info AS f
	ON d.AR_INV_NBR = f.AR_INV_NBR
WHERE d.ORDER_NBR = (SELECT MIN(d2.ORDER_NBR) FROM dbo.ARINV_MEDIA AS d2 WHERE d.AR_INV_NBR = d2.AR_INV_NBR)
	AND f.AR_INV_NBR IS NULL		--does not insert a record for invoices already assigned via production
GROUP BY d.AR_INV_NBR, d.ORDER_NBR
--SELECT * FROM #min_job_order

-- MAG-------------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.MAG_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.MAG_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'M'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.MAG_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- MAGAZINE--------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.MAGAZINE_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.MAGAZINE_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'M'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.MAGAZINE_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- NEWS------------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.NEWS_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.NEWS_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'N'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.NEWS_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- NEWSPAPER-------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.NEWSPAPER_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.NEWSPAPER_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'N'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.NEWSPAPER_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- INTERNET--------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.INTERNET_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.INTERNET_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'I'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.INTERNET_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- OUTDOOR---------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	NULL
FROM dbo.OUTDOOR_DETAIL AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.OUTDOOR_DETAIL AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT 
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'O'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.OUTDOOR_DETAIL AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line

-- RADIO-----------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	MIN(d.BRDCAST_YEAR)
FROM dbo.RADIO_DETAIL1 AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.RADIO_DETAIL1 AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT DISTINCT
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'R'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.RADIO_DETAIL1 AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line
-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq

-- TELEVISION------------------------------------------------
-- Find the max rev/seq for each order/line
INSERT INTO #max_rev_seq
SELECT
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	MIN(d.BRDCAST_YEAR)
FROM dbo.TV_DETAIL1 AS d
WHERE d.REV_NBR = (SELECT MIN(d2.REV_NBR) FROM dbo.TV_DETAIL1 AS d2 
	WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--SELECT * FROM #max_rev_seq

-- Extract the job description for the max rev/seq for the min order/line for the invoice
INSERT INTO #job_info
SELECT DISTINCT
	m.AR_INV_NBR,
	d.JOB_NUMBER,
	j.JOB_DESC,
	m.JOB_ORDER_NBR,
	'T'
FROM #min_job_order m						--minimum order/line for all media invoices
JOIN #max_rev_seq AS s						--filters for media type specific order/lines
	ON m.JOB_ORDER_NBR = s.ORDER_NBR
	AND m.LINE_NBR = s.LINE_NBR
JOIN dbo.TV_DETAIL1 AS d					--gets the job number from the max rev/seq
	ON s.ORDER_NBR = d.ORDER_NBR
	AND s.LINE_NBR = d.LINE_NBR
	AND s.REV_NBR = d.REV_NBR
	AND s.SEQ_NBR = d.SEQ_NBR
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER			--extracts the job desc for max rev/seq for min order/line
-- Clear #max_rev_seq for use by the next media type
DELETE #max_rev_seq	

SELECT * FROM #job_info

END

