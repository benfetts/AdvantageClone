CREATE PROC [dbo].[advsp_media_manager_load_broadcast_invoices]
	@OrderNumber int,
	@MediaType varchar(1)
AS

CREATE TABLE #AllAPOrderLines (
    APID int NOT NULL,
    OrderNumber int NOT NULL,
    OrderLineNumber smallint NULL,
    OrderDescription varchar(40) NULL,
    [VendorCode] varchar(6) NULL,
    [InvoiceNumber] varchar(20) NULL,
    [InvoiceDate] datetime NULL,
    [InvoiceDescription] varchar(30) NULL,
    [InvoiceTotal] decimal(14,2) NULL,
    [Hold] bit NOT NULL,
    [VendorName] varchar(40) NULL
)

IF @MediaType = 'R' BEGIN

    INSERT INTO #AllAPOrderLines (APID, OrderNumber, OrderLineNumber, OrderDescription, VendorCode, InvoiceNumber, InvoiceDate, InvoiceDescription, InvoiceTotal, Hold, VendorName)
    SELECT DISTINCT d.AP_ID, d.ORDER_NBR, ORDER_LINE_NBR, IH.ORDER_DESC, APH.VN_FRL_EMP_CODE, APH.AP_INV_VCHR, APH.AP_INV_DATE, APH.AP_DESC,
        APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0), CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit), V.VN_NAME
    FROM dbo.AP_RADIO_BROADCAST_DTL d
        INNER JOIN dbo.AP_HEADER APH ON d.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
        INNER JOIN dbo.RADIO_HDR IH ON d.ORDER_NBR = IH.ORDER_NBR 
        INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
    WHERE d.ORDER_NBR = @OrderNumber
    UNION
    SELECT AP.AP_ID, AP.ORDER_NBR, ORDER_LINE_NBR, IH.ORDER_DESC, APH.VN_FRL_EMP_CODE, APH.AP_INV_VCHR, APH.AP_INV_DATE, APH.AP_DESC,
        APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0), CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit), V.VN_NAME
    FROM dbo.AP_RADIO AP
        INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
        INNER JOIN dbo.RADIO_HDR IH ON AP.ORDER_NBR = IH.ORDER_NBR 
        INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
	WHERE
		AP.ORDER_NBR = @OrderNumber
	AND	(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)
    AND AP.ORDER_LINE_NBR IS NOT NULL
    
	SELECT
		[MediaType] = 'Radio',
		[OrderNumber] = a.OrderNumber,
		[LineNumber] = a.OrderLineNumber,
		[OrderDescription],
		[VendorCode],
		[VendorName],
		[InvoiceNumber],
		[InvoiceDate],
		[InvoiceDescription],
		[InvoiceTotal],
		[Hold],
		[QTY],
        SpotQTY,
		[Rate] = NULL,
		[NetAmount],
		[DiscountAmount],
		[NetCharges],
		[VendorTax],
		[DisbursedAmount] = COALESCE([DisbursedAmount],0),
		[AccountPayableID] = a.APID
	FROM 
        #AllAPOrderLines a        
        LEFT OUTER JOIN 
            (
                SELECT
		            [OrderNumber] = AP.ORDER_NBR,
		            [LineNumber] = AP.ORDER_LINE_NBR,
		            [QTY] = SUM(CAST(COALESCE(AP.TOTAL_SPOTS,0) as decimal)),
		            [NetAmount] = SUM(COALESCE(AP.EXT_NET_AMT,0)),
		            [DiscountAmount] = SUM(COALESCE(AP.DISC_AMT,0)),
		            [NetCharges] = SUM(COALESCE(AP.NETCHARGES,0)),
		            [VendorTax] = SUM(COALESCE(AP.VENDOR_TAX,0)),
		            [DisbursedAmount] = SUM(COALESCE(AP.EXT_NET_AMT, 0) - ABS(COALESCE(AP.DISC_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0)),
		            [AccountPayableID] = AP.AP_ID
	            FROM dbo.AP_RADIO AP
	            WHERE
			            AP.ORDER_NBR = @OrderNumber
	            AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)
                GROUP BY AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.AP_ID) AP ON AP.AccountPayableID = a.APID AND AP.LineNumber = a.OrderLineNumber
        LEFT OUTER JOIN 
        (
            SELECT [SpotQTY] = count(1), AP_ID, ORDER_LINE_NBR 
            FROM dbo.AP_RADIO_BROADCAST_DTL 
            WHERE ORDER_NBR = @OrderNumber
            GROUP BY AP_ID, ORDER_LINE_NBR) spots ON spots.AP_ID = a.APID AND spots.ORDER_LINE_NBR = a.OrderLineNumber 		
		ORDER BY a.OrderLineNumber, [InvoiceNumber]

END ELSE IF @MediaType = 'T' BEGIN

    INSERT INTO #AllAPOrderLines (APID, OrderNumber, OrderLineNumber, OrderDescription, VendorCode, InvoiceNumber, InvoiceDate, InvoiceDescription, InvoiceTotal, Hold, VendorName)
    SELECT DISTINCT d.AP_ID, d.ORDER_NBR, ORDER_LINE_NBR, IH.ORDER_DESC, APH.VN_FRL_EMP_CODE, APH.AP_INV_VCHR, APH.AP_INV_DATE, APH.AP_DESC,
        APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0), CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit), V.VN_NAME
    FROM dbo.AP_TV_BROADCAST_DTL d
        INNER JOIN dbo.AP_HEADER APH ON d.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
        INNER JOIN dbo.TV_HDR IH ON d.ORDER_NBR = IH.ORDER_NBR 
        INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
    WHERE d.ORDER_NBR = @OrderNumber
    UNION
    SELECT AP.AP_ID, AP.ORDER_NBR, ORDER_LINE_NBR, IH.ORDER_DESC, APH.VN_FRL_EMP_CODE, APH.AP_INV_VCHR, APH.AP_INV_DATE, APH.AP_DESC,
        APH.AP_INV_AMT + COALESCE(APH.AP_SALES_TAX, 0) + COALESCE(APH.AP_SHIPPING, 0), CAST(COALESCE(APH.PAYMENT_HOLD, 0) as bit), V.VN_NAME
    FROM dbo.AP_TV AP
        INNER JOIN dbo.AP_HEADER APH ON AP.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
        INNER JOIN dbo.TV_HDR IH ON AP.ORDER_NBR = IH.ORDER_NBR 
        INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE 
	WHERE
		AP.ORDER_NBR = @OrderNumber
	AND	(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)
    AND AP.ORDER_LINE_NBR IS NOT NULL
    
	SELECT
		[MediaType] = 'TV',
		[OrderNumber] = a.OrderNumber,
		[LineNumber] = a.OrderLineNumber,
		[OrderDescription],
		[VendorCode],
		[VendorName],
		[InvoiceNumber],
		[InvoiceDate],
		[InvoiceDescription],
		[InvoiceTotal],
		[Hold],
		[QTY],
        SpotQTY,
		[Rate] = NULL,
		[NetAmount],
		[DiscountAmount],
		[NetCharges],
		[VendorTax],
		[DisbursedAmount] = COALESCE([DisbursedAmount],0),
		[AccountPayableID] = a.APID
	FROM 
        #AllAPOrderLines a        
        LEFT OUTER JOIN 
            (
                SELECT
		            [OrderNumber] = AP.ORDER_NBR,
		            [LineNumber] = AP.ORDER_LINE_NBR,
		            [QTY] = SUM(CAST(COALESCE(AP.TOTAL_SPOTS,0) as decimal)),
		            [NetAmount] = SUM(COALESCE(AP.EXT_NET_AMT,0)),
		            [DiscountAmount] = SUM(COALESCE(AP.DISC_AMT,0)),
		            [NetCharges] = SUM(COALESCE(AP.NETCHARGES,0)),
		            [VendorTax] = SUM(COALESCE(AP.VENDOR_TAX,0)),
		            [DisbursedAmount] = SUM(COALESCE(AP.EXT_NET_AMT, 0) - ABS(COALESCE(AP.DISC_AMT, 0)) + COALESCE(AP.NETCHARGES, 0) + COALESCE(AP.VENDOR_TAX, 0)),
		            [AccountPayableID] = AP.AP_ID
	            FROM dbo.AP_TV AP
	            WHERE
			            AP.ORDER_NBR = @OrderNumber
	            AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)
                GROUP BY AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.AP_ID) AP ON AP.AccountPayableID = a.APID AND AP.LineNumber = a.OrderLineNumber
        LEFT OUTER JOIN 
        (
            SELECT [SpotQTY] = count(1), AP_ID, ORDER_LINE_NBR 
            FROM dbo.AP_TV_BROADCAST_DTL 
            WHERE ORDER_NBR = @OrderNumber
            GROUP BY AP_ID, ORDER_LINE_NBR) spots ON spots.AP_ID = a.APID AND spots.ORDER_LINE_NBR = a.OrderLineNumber 		
		ORDER BY a.OrderLineNumber, [InvoiceNumber]

END

GO


