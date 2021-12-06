CREATE PROCEDURE [dbo].[advsp_media_manager_load_approve_invoice_orders]
	@OrderNumberLineNumberList varchar(max)
AS

CREATE TABLE #INVOICE (
	ORDER_NBR int NOT NULL,
	LINE_NBR smallint NOT NULL
)

CREATE TABLE #ORDER_DETAILS (
	MediaType varchar(20),
	ClientCode varchar(6),
	DivisionCode varchar(6),
	ProductCode varchar(6),
	VendorCode varchar(6),
	VendorName varchar(40),
	OrderNumber int,
	OrderDescription varchar(40),
	OrderQtySpots int,
	GrossOrderAmount decimal(16,2),
	NetOrderAmount decimal(16,2)
)

CREATE TABLE #AP_NET_AMOUNT (
	ORDER_NBR int NOT NULL,
	LINE_NBR int NOT NULL,
	NetInvoiceAmount decimal(16,2) NULL,
	GrossInvoiceAmount decimal(16,2) NULL,
	InvoiceQtySpots int NULL
)

INSERT #INVOICE (ORDER_NBR, LINE_NBR)
SELECT
	ORDER_NBR = SUBSTRING(items,1,CHARINDEX('|', items, 1)-1),
	LINE_NBR = SUBSTRING(items,CHARINDEX('|', items, 1)+1,20)
FROM dbo.udf_split_list(@OrderNumberLineNumberList, ',')

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	SUM(QTY_SPOTS)
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (NET_AMT, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISCOUNT_AMT, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN 
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							END
						  ELSE CAST(AP.NET_AMT + (AP.NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
						  END,
		QTY_SPOTS = COALESCE(AP.IMPRESSIONS, 0)
	FROM dbo.AP_INTERNET AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	NULL
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (NET_PLUS, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISCOUNT_LN, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN 
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.NET_PLUS / (1 - AP.COMM_PCT/100) as decimal(16,2))
							END
						  ELSE CAST(AP.NET_PLUS + (AP.NET_PLUS * AP.MARKUP_PCT / 100) as decimal(16,2))
						  END
	FROM dbo.AP_MAGAZINE AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	NULL
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (NET_AMT, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISCOUNT_LN, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							END
						  ELSE CAST(AP.NET_AMT + (AP.NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
						  END
	FROM dbo.AP_NEWSPAPER AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	NULL
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (NET_AMT, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISCOUNT_AMT, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN 
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2)) 
							END
						  ELSE CAST(AP.NET_AMT + (AP.NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
						  END
	FROM dbo.AP_OUTDOOR AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	0
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (EXT_NET_AMT, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISC_AMT, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN 
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.EXT_NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2)) 
							END
						  ELSE CAST(AP.EXT_NET_AMT + (AP.EXT_NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2)) 
						  END,
		QTY_SPOTS = COALESCE(AP.TOTAL_SPOTS, 0)
	FROM dbo.AP_RADIO AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #AP_NET_AMOUNT
SELECT 
	ORDER_NBR,
	LINE_NBR,
	SUM(AP_NET_AMOUNT),
	SUM(AP_GROSS_AMOUNT),
	0
FROM
	(
	SELECT
		I.ORDER_NBR,
		I.LINE_NBR,
		AP_NET_AMOUNT = COALESCE (EXT_NET_AMT, 0), -- + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0) + COALESCE(DISC_AMT, 0),
		AP_GROSS_AMOUNT = CASE WHEN NET_GROSS = 1 THEN 
							CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							ELSE
								CAST(AP.EXT_NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2)) 
							END
						  ELSE CAST(AP.EXT_NET_AMT + (AP.EXT_NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
						  END,
		QTY_SPOTS = COALESCE(AP.TOTAL_SPOTS, 0)
	FROM dbo.AP_TV AP
		INNER JOIN #INVOICE I ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	) dtl
GROUP BY ORDER_NBR, LINE_NBR

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'Internet',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = SUM(d.GUARANTEED_IMPRESS),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.INTERNET_DETAIL d
	INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.INTERNET_HEADER h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'Magazine',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = NULL, --SUM(d.QUANTITY),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.MAGAZINE_DETAIL d
	INNER JOIN #AP_NET_AMOUNT i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.MAGAZINE_HEADER h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'Newspaper',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = NULL, --SUM(d.PRINT_QUANTITY),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.NEWSPAPER_DETAIL d
	INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.NEWSPAPER_HEADER h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'Out Of Home',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = NULL, --SUM(d.QUANTITY),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.OUTDOOR_DETAIL d
	INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.OUTDOOR_HEADER h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'Radio',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = SUM(d.TOTAL_SPOTS),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.RADIO_DETAIL d
	INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.RADIO_HDR h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

INSERT #ORDER_DETAILS
SELECT
	MediaType = 'TV',
	ClientCode = h.CL_CODE,
	DivisionCode = h.DIV_CODE,
	ProductCode = h.PRD_CODE,
	VendorCode = v.VN_CODE,
	VendorName = v.VN_NAME,
	OrderNumber = h.ORDER_NBR,
	OrderDescription = h.ORDER_DESC,
	OrderQtySpots = SUM(d.TOTAL_SPOTS),
	GrossOrderAmount = SUM(d.EXT_GROSS_AMT),
	NetOrderAmount = SUM(d.EXT_NET_AMT)
FROM dbo.TV_DETAIL d
	INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN dbo.TV_HDR h ON h.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE 
GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, v.VN_CODE, v.VN_NAME, h.ORDER_NBR, h.ORDER_DESC

SELECT
	od.MediaType,
	od.ClientCode,
	od.DivisionCode,
	od.ProductCode,
	od.VendorCode,
	od.VendorName,
	od.OrderNumber,
	od.OrderDescription,
	od.OrderQtySpots,
	od.GrossOrderAmount,
	od.NetOrderAmount,
	NetInvoiceAmount = SUM(ap.NetInvoiceAmount),
	GrossInvoiceAmount = SUM(ap.GrossInvoiceAmount),
	InvoiceQtySpots = SUM(ap.InvoiceQtySpots)
FROM #ORDER_DETAILS od
	INNER JOIN #AP_NET_AMOUNT ap ON od.OrderNumber = ap.ORDER_NBR
WHERE od.MediaType NOT IN ('Radio', 'TV')
GROUP BY
	od.MediaType,
	od.ClientCode,
	od.DivisionCode,
	od.ProductCode,
	od.VendorCode,
	od.VendorName,
	od.OrderNumber,
	od.OrderDescription,
	od.OrderQtySpots,
	od.GrossOrderAmount,
	od.NetOrderAmount

UNION ALL

SELECT
	od.MediaType,
	od.ClientCode,
	od.DivisionCode,
	od.ProductCode,
	od.VendorCode,
	od.VendorName,
	od.OrderNumber,
	od.OrderDescription,
	od.OrderQtySpots,
	od.GrossOrderAmount,
	od.NetOrderAmount,
	NetInvoiceAmount = SUM(ap.NetInvoiceAmount),
	GrossInvoiceAmount = SUM(ap.GrossInvoiceAmount),
	InvoiceQtySpots = CASE 
						WHEN od.MediaType = 'TV' THEN (SELECT COUNT(1) FROM dbo.AP_TV_BROADCAST_DTL d INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.ORDER_LINE_NBR = i.LINE_NBR
															WHERE d.ORDER_NBR = od.OrderNumber)
						WHEN od.MediaType = 'Radio' THEN (SELECT COUNT(1) FROM dbo.AP_RADIO_BROADCAST_DTL d INNER JOIN #INVOICE i ON d.ORDER_NBR = i.ORDER_NBR AND d.ORDER_LINE_NBR = i.LINE_NBR
															WHERE d.ORDER_NBR = od.OrderNumber)
						ELSE 0
					  END
FROM #ORDER_DETAILS od
	INNER JOIN #AP_NET_AMOUNT ap ON od.OrderNumber = ap.ORDER_NBR
WHERE od.MediaType IN ('Radio', 'TV')
GROUP BY
	od.MediaType,
	od.ClientCode,
	od.DivisionCode,
	od.ProductCode,
	od.VendorCode,
	od.VendorName,
	od.OrderNumber,
	od.OrderDescription,
	od.OrderQtySpots,
	od.GrossOrderAmount,
	od.NetOrderAmount
	
DROP TABLE #INVOICE
DROP TABLE #ORDER_DETAILS
DROP TABLE #AP_NET_AMOUNT
GO
