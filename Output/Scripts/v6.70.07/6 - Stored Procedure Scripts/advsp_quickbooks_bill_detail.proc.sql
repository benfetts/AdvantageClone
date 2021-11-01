CREATE PROCEDURE [dbo].[advsp_quickbooks_bill_detail]
	@AP_ID int
AS

SELECT 
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.NET_AMT,0) + COALESCE(ap.DISCOUNT_AMT,0) + COALESCE(ap.NETCHARGES,0) + COALESCE(ap.VENDOR_TAX,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_INTERNET ap
	LEFT OUTER JOIN dbo.INTERNET_HEADER h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.DISBURSED_AMT,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_MAGAZINE ap
	LEFT OUTER JOIN dbo.MAGAZINE_HEADER h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.DISBURSED_AMT,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_NEWSPAPER ap
	LEFT OUTER JOIN dbo.NEWSPAPER_HEADER h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.NET_AMT,0) + COALESCE(ap.DISCOUNT_AMT,0) + COALESCE(ap.NETCHARGES,0) + COALESCE(ap.VENDOR_TAX,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_OUTDOOR ap
	LEFT OUTER JOIN dbo.OUTDOOR_HEADER h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.EXT_NET_AMT,0) + COALESCE(ap.DISC_AMT,0) + COALESCE(ap.NETCHARGES,0) + COALESCE(ap.VENDOR_TAX,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_RADIO ap
	LEFT OUTER JOIN dbo.RADIO_HDR h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
	OrderNumber = ap.ORDER_NBR,
	OrderLineNumber = ap.ORDER_LINE_NBR,
	[Description] = CAST(h.ORDER_DESC as varchar(max)),
	Amount = COALESCE(ap.EXT_NET_AMT,0) + COALESCE(ap.DISC_AMT,0) + COALESCE(ap.NETCHARGES,0) + COALESCE(ap.VENDOR_TAX,0),
	IsOrder = CAST(1 as bit)
FROM dbo.AP_TV ap
	LEFT OUTER JOIN dbo.TV_HDR h ON ap.ORDER_NBR = h.ORDER_NBR 
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

UNION

SELECT
    OrderNumber = NULL,
	OrderLineNumber = NULL,
	[Description] = CAST(ap.AP_COMMENT as varchar(max)),
	Amount = ap.AP_GL_AMT,
	IsOrder = CAST(0 as bit)
FROM AP_GL_DIST ap
WHERE AP_ID = @AP_ID
AND COALESCE(MODIFY_DELETE, 0) = 0

GO
