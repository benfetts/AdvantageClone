CREATE PROCEDURE [dbo].[advsp_media_traffic_instruction_copy_get_worksheet_markets]
	@MEDIA_TRAFFIC_REVISION_ID int
AS

BEGIN

--declare @MEDIA_TRAFFIC_REVISION_ID int
--set @MEDIA_TRAFFIC_REVISION_ID = 12

DECLARE @MARKET_REVISION TABLE (
		MaxRevisionNumber int NOT NULL,
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID int NOT NULL
	)

INSERT INTO @MARKET_REVISION (MaxRevisionNumber, MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
SELECT 	
	RevisionNumber = MAX(REVISION_NUMBER),
	MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
GROUP BY MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID


DECLARE	@MEDIA_TYPE_CODE char(1),
		@CL_CODE varchar(6)
	
SELECT @MEDIA_TYPE_CODE = MBW.MEDIA_TYPE_CODE, @CL_CODE = MBW.CL_CODE
FROM dbo.MEDIA_TRAFFIC_REVISION MTR
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC MBWMT ON MTR.MEDIA_TRAFFIC_ID = MBWMT.MEDIA_TRAFFIC_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID 
WHERE MTR.MEDIA_TRAFFIC_REVISION_ID = @MEDIA_TRAFFIC_REVISION_ID

SELECT DISTINCT 
	[MediaBroadcastWorksheetMarketID] = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID,
	[Name] = MBW.[NAME],
	MediaBroadcastWorksheetID = MBW.MEDIA_BROADCAST_WORKSHEET_ID,
	[ClientCode] = MBW.CL_CODE,
	[ClientName] = C.CL_NAME,
	[DivisionCode] = MBW.DIV_CODE,
	[DivisionName] = D.DIV_NAME,
	[ProductCode] = MBW.PRD_CODE,
	[ProductName] = P.PRD_DESCRIPTION,
	[MarketCode] = MBWM.MARKET_CODE,
	[MarketDescription] = M.MARKET_DESC,
	[StartDate] = MBW.[START_DATE],
	[EndDate] = MBW.END_DATE,
	[IsInactive] = MBW.IS_INACTIVE,
	[IsCable] = MBWM.IS_CABLE
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID AND MBW.IS_INACTIVE = 0
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
	INNER JOIN @MARKET_REVISION MR ON MR.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND MBWMD.REVISION_NUMBER = MR.MaxRevisionNumber
	INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE
	INNER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE
	INNER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE
	INNER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE
WHERE 
	MBW.MEDIA_TYPE_CODE = @MEDIA_TYPE_CODE 
AND MBW.CL_CODE = @CL_CODE 
AND MBWMDD.ORDER_NBR IS NOT NULL
AND MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID NOT IN (SELECT MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
													FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC MBWMT
														INNER JOIN dbo.MEDIA_TRAFFIC_REVISION MTR ON MTR.MEDIA_TRAFFIC_ID = MBWMT.MEDIA_TRAFFIC_ID
													WHERE MTR.MEDIA_TRAFFIC_REVISION_ID = @MEDIA_TRAFFIC_REVISION_ID)

END
