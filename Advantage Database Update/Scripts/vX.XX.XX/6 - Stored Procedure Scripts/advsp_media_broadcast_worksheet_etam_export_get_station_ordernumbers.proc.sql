CREATE PROCEDURE [dbo].[advsp_media_broadcast_worksheet_etam_export_get_station_ordernumbers]
	@MEDIA_BROADCAST_WORKSHEET_ID int
AS

SELECT DISTINCT
	[NPRStationID] = V.NPR_STATION_ID,
	[OrderNumber] = MBWMDD.ORDER_NBR 
FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	INNER JOIN VENDOR V ON MBWMD.VN_CODE = V.VN_CODE AND V.NPR_STATION_ID IS NOT NULL
	INNER JOIN NPR_STATION NS ON V.NPR_STATION_ID = NS.NPR_STATION_ID AND NS.ETAM_XREF IS NOT NULL
    INNER JOIN AP_TV_BROADCAST_DTL ATVD ON ATVD.ORDER_NBR = MBWMDD.ORDER_NBR 
WHERE
	MBWM.MEDIA_BROADCAST_WORKSHEET_ID = @MEDIA_BROADCAST_WORKSHEET_ID
AND V.NPR_STATION_ID IS NOT NULL
AND MBWMDD.ORDER_NBR IS NOT NULL
