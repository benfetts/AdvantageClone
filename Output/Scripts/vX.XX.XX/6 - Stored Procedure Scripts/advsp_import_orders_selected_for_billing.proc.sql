IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_import_orders_selected_for_billing]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_import_orders_selected_for_billing]
GO


CREATE PROCEDURE [dbo].[advsp_import_orders_selected_for_billing] 
@order_type varchar(2),
@media_interface varchar(254)


AS

/*
DECLARE @order_type varchar(2)

DECLARE @StartTime AS DATETIME = GETDATE()
DECLARE @RetCount int

SET @order_type = 'I'

EXEC @RetCount = [dbo].[advsp_import_orders_selected_for_billing] @order_type

SELECT @RetCount RETURN_CODE
*/

--DECLARE @StartTime AS DATETIME = GETDATE()
DECLARE @RetCount int

DECLARE @list TABLE(
	MEDIA_INTERFACE varchar(2)
	)

SET @order_type = UPPER(LEFT(@order_type,1))

INSERT INTO @list
	SELECT * FROM dbo.udf_split_list(@media_interface, ',')

--SELECT * FROM @list

CREATE TABLE #TempOrdersSelectedForBilling
([ORDER_NBR] int,[LINE_NBR] int, [SELECTED_FOR_BILLING] bit)

--CREATE CLUSTERED INDEX ix_TempOrdersSelectedForBilling ON #TempOrdersSelectedForBilling ([ORDER_NBR],[LINE_NBR]);

IF @order_type IN ('I', 'N', 'M', 'O')
INSERT INTO #TempOrdersSelectedForBilling 
SELECT ORDER_NBR, LINE_NBR, 0
FROM PRINT_ORDER A JOIN PRINT_IMPORT_XREF B ON A.[ACCT_ORD_NBR] = B.[IMPORT_ORDER_NBR] AND CAST(A.[ITEM_NBR] AS INT) = B.[IMPORT_LINE_NBR]
		JOIN @list C ON A.MEDIA_INTERFACE = C.MEDIA_INTERFACE
WHERE A.[POST_FLAG] IN (0) AND A.MEDIA_TYPE = @order_type

IF @order_type IN ('T', 'R')
INSERT INTO #TempOrdersSelectedForBilling 
SELECT ORDER_NBR, B.LINE_NBR, 0
FROM BRDCAST_IMPORT A JOIN BRD_IMPORT_XREF B ON A.[LINK_ID] = B.[IMPORT_ORDER_NBR] AND CAST(A.[LINE_NBR] AS INT) = B.[IMPORT_LINE_NBR]
		JOIN @list C ON A.MEDIA_INTERFACE = C.MEDIA_INTERFACE
WHERE A.[POST_FLAG] IN (0) AND A.MEDIA_TYPE = @order_type

--CREATE CLUSTERED INDEX ix_TempOrdersSelectedForBilling ON #TempOrdersSelectedForBilling ([ORDER_NBR],[LINE_NBR]);

IF @order_type IN ('I')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN INTERNET_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN INTERNET_HEADER B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

IF @order_type IN ('N')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN NEWSPAPER_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN NEWSPAPER_HEADER B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

IF @order_type IN ('M')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN MAGAZINE_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN MAGAZINE_HEADER B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

IF @order_type IN ('O')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN OUTDOOR_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN OUTDOOR_HEADER B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

IF @order_type IN ('T')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN TV_HDR B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

IF @order_type IN ('R')
UPDATE A
SET A.[SELECTED_FOR_BILLING] = 1
FROM #TempOrdersSelectedForBilling A
    --INNER JOIN RADIO_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR AND B.BILLING_USER IS NOT NULL
	INNER JOIN RADIO_HDR B ON A.ORDER_NBR = B.ORDER_NBR AND (B.BCC_ID IS NOT NULL OR LOCKED_BY IS NOT NULL)

--SELECT DATEDIFF(ms,@StartTime,GETDATE()) TIMER

--SELECT * FROM #TempOrdersSelectedForBilling

SELECT @RetCount = COUNT(*) FROM #TempOrdersSelectedForBilling WHERE SELECTED_FOR_BILLING > 0

DROP TABLE #TempOrdersSelectedForBilling 

RETURN @RetCount

GO

GRANT EXECUTE ON [advsp_import_orders_selected_for_billing] TO PUBLIC AS dbo
GO