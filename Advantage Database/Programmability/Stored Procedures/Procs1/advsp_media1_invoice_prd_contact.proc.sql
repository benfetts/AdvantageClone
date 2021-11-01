
CREATE PROCEDURE [dbo].[advsp_media1_invoice_prd_contact] @list_option int, @list varchar(4000)

-- currently not functional for @list_option = 1 (draft invoices) 8/11/09

AS
BEGIN
	SET NOCOUNT ON;


-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #ARInvPrdContact(
	AR_INV_NBR						int NULL,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CONT_CODE						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
--Creates a table of minimum order numbers for selected invoices or billing users
CREATE TABLE #InvoiceOrders (
	AR_INV_NBR						int NULL,
	ORDER_NBR						int NULL)
INSERT INTO #InvoiceOrders
SELECT DISTINCT
	ar.AR_INV_NBR,
	MIN(am.ORDER_NBR)
FROM fn_intlist_to_table(@list) i
INNER JOIN dbo.ACCT_REC ar
	ON i.number = ar.AR_INV_NBR
INNER JOIN dbo.ARINV_MEDIA am
	ON ar.AR_INV_NBR = am.AR_INV_NBR	
GROUP BY ar.AR_INV_NBR
--SELECT * FROM #InvoiceOrders

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
--MAGAZINE (NEW) PRODUCT CONTACT*******************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.MAGAZINE_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

--NEWSPAPER (NEW) PRODUCT CONTACT********************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.NEWSPAPER_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

--INTERNET PRODUCT CONTACT*************************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.INTERNET_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

--OUTDOOR PRODUCT CONTACT***************************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.OUTDOOR_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

--RADIO PRODUCT CONTACT**************************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.RADIO_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

--TV PRODUCT CONTACT******************************************
INSERT INTO #ARInvPrdContact
SELECT DISTINCT
	io.AR_INV_NBR,
	h.CL_CODE,
	h.DIV_CODE,
	h.PRD_CODE,
	ISNULL(pc.CONT_CODE,'ZZ')
FROM #InvoiceOrders io
INNER JOIN dbo.TV_HEADER h
	ON io.ORDER_NBR = h.ORDER_NBR
LEFT JOIN dbo.XREF_PROD_CONT pc
	ON h.CL_CODE = pc.CL_CODE
	AND	h.DIV_CODE = pc.DIV_CODE
	AND h.PRD_CODE = pc.PRD_CODE
	AND h.CLIENT_PO = pc.CLIENT_PO

SELECT * FROM #ARInvPrdContact
END

DROP TABLE #ARInvPrdContact
DROP TABLE #InvoiceOrders
