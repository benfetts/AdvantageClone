CREATE PROCEDURE [dbo].[advsp_media_manager_load_order_line_comments]
	
	@OrderNumberLineNumberList varchar(max)

AS

SET NOCOUNT ON

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = CAST(POSITION_INFO as varchar(max)),
	[CloseInformation] = CAST(CLOSE_INFO as varchar(max)),
	[RateInformation] = CAST(RATE_INFO as varchar(max)),
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = CAST(IN_HOUSE_CMTS as varchar(max)),
	[OrderType] = 'M',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.MAGAZINE_COMMENTS C
	INNER JOIN dbo.MAGAZINE_HEADER H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

UNION

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = CAST(POSITION_INFO as varchar(max)),
	[CloseInformation] = CAST(CLOSE_INFO as varchar(max)),
	[RateInformation] = CAST(RATE_INFO as varchar(max)),
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = CAST(IN_HOUSE_CMTS as varchar(max)),
	[OrderType] = 'N',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.NEWSPAPER_COMMENTS C
	INNER JOIN dbo.NEWSPAPER_HEADER H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

UNION

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = NULL,
	[CloseInformation] = NULL,
	[RateInformation] = NULL,
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = NULL,
	[OrderType] = 'I',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.INTERNET_COMMENTS C
	INNER JOIN dbo.INTERNET_HEADER H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

UNION

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = NULL,
	[CloseInformation] = NULL,
	[RateInformation] = NULL,
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = NULL,
	[OrderType] = 'O',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.OUTDOOR_COMMENTS C
	INNER JOIN dbo.OUTDOOR_HEADER H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

UNION

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = CAST(POSITION_INFO as varchar(max)),
	[CloseInformation] = CAST(CLOSE_INFO as varchar(max)),
	[RateInformation] = CAST(RATE_INFO as varchar(max)),
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = CAST(IN_HOUSE_CMTS as varchar(max)),
	[OrderType] = 'R',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.RADIO_COMMENTS C
	INNER JOIN dbo.RADIO_HDR H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

UNION

SELECT
	[OrderNumber] = C.ORDER_NBR,
	[LineNumber] = LINE_NBR,
	[Instructions] = CAST(INSTRUCTIONS as varchar(max)),
	[OrderCopy] = CAST(ORDER_COPY as varchar(max)),
	[MaterialNotes] = CAST(MATL_NOTES as varchar(max)),
	[PositionInformation] = CAST(POSITION_INFO as varchar(max)),
	[CloseInformation] = CAST(CLOSE_INFO as varchar(max)),
	[RateInformation] = CAST(RATE_INFO as varchar(max)),
	[MiscellaneousInformation] = CAST(MISC_INFO as varchar(max)),
	[InHouseComments] = CAST(IN_HOUSE_CMTS as varchar(max)),
	[OrderType] = 'T',
	[OrderDescription] = H.ORDER_DESC 
FROM dbo.TV_COMMENTS C
	INNER JOIN dbo.TV_HDR H ON C.ORDER_NBR = H.ORDER_NBR
WHERE CAST(C.ORDER_NBR AS varchar(20)) + '|' + CAST(LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))

GO
