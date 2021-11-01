CREATE PROCEDURE [dbo].[advsp_media_manager_load_order_comments]
	
	@OrderNumberList varchar(max)

AS

SET NOCOUNT ON

SELECT
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'M'
FROM dbo.MAGAZINE_HEADER 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))

UNION

SELECT 
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'N'
FROM dbo.NEWSPAPER_HEADER 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))

UNION

SELECT 
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'I'
FROM dbo.INTERNET_HEADER 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))

UNION

SELECT 
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'O'
FROM dbo.OUTDOOR_HEADER 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))

UNION

SELECT 
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'R'
FROM dbo.RADIO_HDR 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))

UNION

SELECT 
		[OrderNumber] = ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[OrderComment] = CAST(ORDER_COMMENT AS varchar(max)),
		[InHouseComment] = CAST(HOUSE_COMMENT AS varchar(max)),
		[OrderType] = 'T'
FROM dbo.TV_HDR 
WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumberList, ','))
ORDER BY ORDER_NBR DESC

GO
