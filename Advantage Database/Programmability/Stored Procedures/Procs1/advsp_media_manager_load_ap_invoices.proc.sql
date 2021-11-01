CREATE PROC [advsp_media_manager_load_ap_invoices]
	@OrderNumber int,
	@OrderLineNumbers varchar(max),
	@MediaType varchar(1)
AS

IF @MediaType = 'I'

	SELECT
		[MediaType] = 'Internet',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = CAST(AP.IMPRESSIONS as decimal),
		[Rate] = AP.RATE,
		[NetAmount] = AP.NET_AMT,
		[DiscountAmount] = AP.DISCOUNT_AMT,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.NET_AMT, 0) - ABS(COALESCE(AP.DISCOUNT_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_INTERNET AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.INTERNET_HEADER IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

ELSE IF @MediaType = 'M'

	SELECT
		[MediaType] = 'Magazine',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = NULL,
		[Rate] = NULL,
		[NetAmount] = AP.NET_AMT,
		[DiscountAmount] = AP.DISCOUNT_LN,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.DISBURSED_AMT, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_MAGAZINE AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.MAGAZINE_HEADER IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

ELSE IF @MediaType = 'N'

	SELECT
		[MediaType] = 'Newspaper',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = AP.PRINT_LINES,
		[Rate] = AP.RATE,
		[NetAmount] = AP.NET_AMT,
		[DiscountAmount] = AP.DISCOUNT_LN,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.DISBURSED_AMT, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_NEWSPAPER AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.NEWSPAPER_HEADER IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)
	
ELSE IF @MediaType = 'O'

	SELECT
		[MediaType] = 'Out Of Home',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = NULL,
		[Rate] = NULL,
		[NetAmount] = AP.NET_AMT,
		[DiscountAmount] = AP.DISCOUNT_AMT,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.NET_AMT, 0) - ABS(COALESCE(AP.DISCOUNT_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_OUTDOOR AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.OUTDOOR_HEADER IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

ELSE IF @MediaType = 'R'

	SELECT
		[MediaType] = 'Radio',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = CAST(AP.TOTAL_SPOTS as decimal),
		[Rate] = NULL,
		[NetAmount] = AP.EXT_NET_AMT,
		[DiscountAmount] = AP.DISC_AMT,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.EXT_NET_AMT, 0) - ABS(COALESCE(AP.DISC_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_RADIO AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.RADIO_HDR IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

ELSE IF @MediaType = 'T'

	SELECT
		[MediaType] = 'TV',
		[OrderNumber] = AP.ORDER_NBR,
		[LineNumber] = AP.ORDER_LINE_NBR,
		[OrderDescription] = IH.ORDER_DESC,
		[VendorCode] = APH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = APH.AP_INV_VCHR,
		[InvoiceDate] = APH.AP_INV_DATE,
		[InvoiceDescription] = APH.AP_DESC,
		[InvoiceTotal] = APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0),
		[Hold] = CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit),
		[QTY] = CAST(AP.TOTAL_SPOTS as decimal),
		[Rate] = NULL,
		[NetAmount] = AP.EXT_NET_AMT,
		[DiscountAmount] = AP.DISC_AMT,
		[NetCharges] = AP.NETCHARGES,
		[VendorTax] = AP.VENDOR_TAX,
		[DisbursedAmount] = COALESCE(AP.EXT_NET_AMT, 0) - ABS(COALESCE(AP.DISC_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0),
		[AccountPayableID] = AP.AP_ID
	FROM dbo.AP_TV AP
		INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
		INNER JOIN dbo.TV_HDR IH ON AP.ORDER_NBR = IH.ORDER_NBR 
	WHERE
			AP.ORDER_NBR = @OrderNumber
	AND		AP.ORDER_LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderLineNumbers, ','))
	AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

GO
