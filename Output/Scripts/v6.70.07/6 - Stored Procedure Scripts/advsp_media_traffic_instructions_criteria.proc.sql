CREATE PROCEDURE [dbo].[advsp_media_traffic_instructions_criteria]
	@INCLUDE_INACTIVE_WORKSHEETS bit,
	@START_DATE smalldatetime,
	@END_DATE smalldatetime,
	@CRITERIA_TYPE smallint -- 0: traffic instructions, 1: missing traffic instructions
AS
/*
	declare 	@SPOT_START_DATE smalldatetime,
				@SPOT_END_DATE smalldatetime

	set @SPOT_START_DATE = '01/01/2019'
	set @SPOT_END_DATE = '12/31/2020'
*/
	DECLARE @MARKET_REVISION TABLE (
		MaxRevisionNumber int NOT NULL,
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID int NOT NULL
	)

	INSERT INTO @MARKET_REVISION (MaxRevisionNumber, MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
	SELECT 	
		RevisionNumber = MAX(REVISION_NUMBER),
		MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	WHERE MBWMDD.[DATE] BETWEEN @START_DATE AND @END_DATE
	GROUP BY MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID

	SELECT 
		MediaBroadcastWorksheetMarketID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID,
		MediaTypeCode = MBW.MEDIA_TYPE_CODE,
		MediaBroadcastWorksheetID = MBW.MEDIA_BROADCAST_WORKSHEET_ID,
		[Name] = MBW.[NAME],
		ClientCode = MBW.CL_CODE,
		ClientName = C.CL_NAME,
		DivisionCode = MBW.DIV_CODE,
		DivisionName = D.DIV_NAME,
		ProductCode = MBW.PRD_CODE,
		ProductName = P.PRD_DESCRIPTION,
		StartDate = MBW.[START_DATE],
		EndDate = MBW.END_DATE,
		IsInactive = MBW.IS_INACTIVE,
		IsCable = MBWM.IS_CABLE,
		MarketCode = MBWM.MARKET_CODE,
		MarketDescription = M.MARKET_DESC,
		MediaBroadcastWorksheetRevisionNumber = MR.MaxRevisionNumber 
	FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM 
		INNER JOIN @MARKET_REVISION MR ON MR.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID 
		INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE AND (@CRITERIA_TYPE = 0 OR (@CRITERIA_TYPE = 1 AND C.RESP_FOR_MEDIA_TRAFFIC_INSTRUCTION = 0))
		INNER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE
		INNER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE
	WHERE MBW.IS_INACTIVE = 0
	OR (MBW.IS_INACTIVE = 1 AND @INCLUDE_INACTIVE_WORKSHEETS = 1)

	GO
