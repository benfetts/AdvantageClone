CREATE PROCEDURE [dbo].[advsp_media_broadcast_worksheet_other_traffic_flight_summary_report]
	@MEDIA_BROADCAST_WORKSHEET_ID int, @MEDIA_BROADCAST_WORKSHEET_MARKET_ID_VENDOR_CODES varchar(max), @DATE_START date, @DATE_END date
AS
BEGIN

--declare @MEDIA_BROADCAST_WORKSHEET_ID int, @MEDIA_BROADCAST_WORKSHEET_MARKET_ID_VENDOR_CODES varchar(max), @DATE_START date, @DATE_END date
--set @MEDIA_BROADCAST_WORKSHEET_ID = 7032
--set @MEDIA_BROADCAST_WORKSHEET_MARKET_ID_VENDOR_CODES = '6051|8054,6051|wtnhtv,6051|wfsbtv,6051|wvittv,6051|wctxtv'
--set @DATE_START = '11/30/2020'
--set @DATE_END = '01/31/2021'

DECLARE @DATE_ID TABLE (
	ROWNUM int IDENTITY(0,1) NOT NULL,
	ODATE smalldatetime NOT NULL,
	CYCLE int NOT NULL,
	CYCLE_ROWNUM int NULL
)

INSERT INTO @DATE_ID (ODATE, CYCLE)
SELECT DISTINCT MBWMDD.[DATE], 0
FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
WHERE MBWM.MEDIA_BROADCAST_WORKSHEET_ID = @MEDIA_BROADCAST_WORKSHEET_ID
AND MBWMDD.[DATE] BETWEEN @DATE_START AND @DATE_END 
ORDER BY MBWMDD.[DATE]

SELECT TotalSpots = SUM(MBWMDD.SPOTS), MaxOrderNumber = MAX(MBWMDD.ORDER_NBR), alldates.ODATE, MBWMD.[LENGTH], MBWM.MARKET_CODE, MBWMD.VN_CODE,
ClientName = C.CL_NAME,
DivisionName = D.DIV_NAME,
ProductDescription = P.PRD_DESCRIPTION,
MediaBroadcastWorksheetName = MBW.[NAME],
MarketName = M.MARKET_DESC + CASE WHEN MBWM.IS_CABLE = 1 THEN ' - CA' ELSE '' END,
VendorName = V.VN_NAME,
FlightDates = CONVERT(CHAR(10),MBW.[START_DATE], 101) + ' - ' + CONVERT(CHAR(10),MBW.[END_DATE], 101),
StationName = V.VN_NAME,--CASE 
--				WHEN MBWM.IS_CABLE = 0 THEN 
--					CASE WHEN V.IS_CABLE_SYSTEM = 1 THEN MBWMD.VN_CODE
--					ELSE V.VN_NAME
--					END
--				WHEN MBWM.IS_CABLE = 1 THEN MBWMD.VN_CODE
--				ELSE '' 
--				END,
MediaBroadcastWorksheetMarketID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID,
MediaType = MBW.MEDIA_TYPE_CODE,
DemographicDescription = MD.[DESCRIPTION] 
INTO #RPT
FROM @DATE_ID alldates
	LEFT OUTER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMDD.[DATE] = alldates.ODATE 
	LEFT OUTER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
																		--AND MBWMD.REVISION_NUMBER = (SELECT MAX(REVISION_NUMBER)
																		--							FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL
																		--							WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
	LEFT OUTER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	LEFT OUTER JOIN MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID 
	LEFT OUTER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE
	LEFT OUTER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE
	LEFT OUTER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE 
	LEFT OUTER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE 
	LEFT OUTER JOIN dbo.VENDOR V ON MBWMD.VN_CODE = V.VN_CODE
	LEFT OUTER JOIN dbo.MEDIA_DEMO MD ON MD.MEDIA_DEMO_ID = MBW.PRIMARY_MEDIA_DEMO_ID 
WHERE MBWM.MEDIA_BROADCAST_WORKSHEET_ID = @MEDIA_BROADCAST_WORKSHEET_ID
AND	CAST(MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID as varchar) + '|' + MBWMD.VN_CODE IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_ID_VENDOR_CODES, ','))
GROUP BY alldates.ODATE, MBWMD.[LENGTH], MBWM.MARKET_CODE, MBWMD.VN_CODE, C.CL_NAME, D.DIV_NAME, P.PRD_DESCRIPTION, MBW.[NAME], M.MARKET_DESC, MBWM.IS_CABLE, V.VN_NAME,
MBW.[START_DATE] ,MBW.[END_DATE], V.IS_CABLE_SYSTEM, MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MBW.MEDIA_TYPE_CODE, MD.[DESCRIPTION] 

UPDATE ds SET CYCLE = ROWNUM / 13, CYCLE_ROWNUM = ROWNUM % 13
FROM @DATE_ID ds

select DISTINCT
	ClientName,
	DivisionName,
	ProductDescription,
	MediaBroadcastWorksheetName,
	MarketName,
	VendorName,
	FlightDates,
	StationName,
	MediaBroadcastWorksheetMarketID,
	DemographicDescription,
	MediaType,
	Cycle = CYCLE, 
	[Len] = r.[LENGTH],
	MarketCode = r.MARKET_CODE, 
	VendorCode = r.VN_CODE,
	Week1 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 0),
	Week2 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 1),
	Week3 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 2),
	Week4 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 3),
	Week5 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 4),
	Week6 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 5),
	Week7 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 6),
	Week8 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 7),
	Week9 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 8),
	Week10 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 9),
	Week11 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 10),
	Week12 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 11),
	Week13 = (SELECT ODATE FROM @DATE_ID WHERE CYCLE = d.CYCLE AND CYCLE_ROWNUM = 12),
	SpotsWeek1 = '',
	SpotsWeek2 = '',
	SpotsWeek3 = '',
	SpotsWeek4 = '',
	SpotsWeek5 = '',
	SpotsWeek6 = '',
	SpotsWeek7 = '',
	SpotsWeek8 = '',
	SpotsWeek9 = '',
	SpotsWeek10 = '',
	SpotsWeek11 = '',
	SpotsWeek12 = '',
	SpotsWeek13 = '',
    @MEDIA_BROADCAST_WORKSHEET_ID as MediaBroadcastWorksheetID
INTO #RPT2
from #RPT r
	INNER JOIN @DATE_ID d on r.ODATE = d.ODATE 

UPDATE r2 SET
	SpotsWeek1 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week1 = x.ODATE),''),
	SpotsWeek2 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week2 = x.ODATE),''),
	SpotsWeek3 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week3 = x.ODATE),''),
	SpotsWeek4 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week4 = x.ODATE),''),
	SpotsWeek5 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week5 = x.ODATE),''),
	SpotsWeek6 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week6 = x.ODATE),''),
	SpotsWeek7 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week7 = x.ODATE),''),
	SpotsWeek8 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week8 = x.ODATE),''),
	SpotsWeek9 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week9 = x.ODATE),''),
	SpotsWeek10 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week10 = x.ODATE),''),
	SpotsWeek11 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week11 = x.ODATE),''),
	SpotsWeek12 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week12 = x.ODATE),''),
	SpotsWeek13 = COALESCE((SELECT CASE WHEN x.TotalSpots>0 AND x.MaxOrderNumber IS NOT NULL THEN 'X' ELSE '' END FROM #RPT x WHERE r2.[Len] = x.[LENGTH] AND r2.MarketCode = x.MARKET_CODE AND r2.VendorCode = x.VN_CODE AND r2.Week13 = x.ODATE),'')
FROM #RPT2 r2

select * from #RPT2

drop table #RPT
drop table #RPT2

END

GO
