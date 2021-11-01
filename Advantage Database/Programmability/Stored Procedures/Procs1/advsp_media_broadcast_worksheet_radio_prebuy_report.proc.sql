CREATE PROCEDURE [dbo].[advsp_media_broadcast_worksheet_radio_prebuy_report]
	@MEDIA_BROADCAST_WORKSHEET_ID int, @MEDIA_BROADCAST_WORKSHEET_MARKETS varchar(max), @MEDIA_DEMO_ID int, @USE_PRIMARY_RATING bit,
	@USE_IMPRESSIONS bit, @BROADCAST_START_DATE date, @BROADCAST_END_DATE date
AS
BEGIN
	DECLARE @HAS_DATES bit, @DATE_START date, @DATE_END date

	SET @HAS_DATES = 0

	IF @BROADCAST_START_DATE IS NOT NULL BEGIN
		SET @HAS_DATES = 1
		--SET @START_YEAR_MONTH = CAST(@BROADCAST_START_YEAR_MONTH as varchar(6))
		--SET @END_YEAR_MONTH = CAST(@BROADCAST_END_YEAR_MONTH as varchar(6))
		SELECT 
			@DATE_START = @BROADCAST_START_DATE, 
			@DATE_END = @BROADCAST_END_DATE
		--SELECT @DATE_START = MIN(BRD_WEEK_START), @DATE_END = MAX(BRD_WEEK_END)
		--FROM dbo.fn_BroadcastCal2('01/01/1900')
		--WHERE (BRD_YEAR >= SUBSTRING(@START_YEAR_MONTH,1,4)	AND BRD_MONTH >= SUBSTRING(@START_YEAR_MONTH,5,2))
		--AND (BRD_YEAR <= SUBSTRING(@END_YEAR_MONTH,1,4)	AND BRD_MONTH <= SUBSTRING(@END_YEAR_MONTH,5,2))
	END

	SELECT *,
			ReportedDates = CONVERT(CHAR(10),ReportedDateStart, 101) + ' - ' + CONVERT(CHAR(10),ReportedDateEnd, 101)
	FROM (
		SELECT
			[ID] = NEWID(),
			ClientName = C.CL_NAME,
			DivisionName = D.DIV_NAME,
			ProductDescription = P.PRD_DESCRIPTION,
			MediaBroadcastWorksheetName = MBW.[NAME],
			MarketName = M.MARKET_DESC + CASE WHEN MBWM.IS_CABLE = 1 THEN ' - CA' ELSE '' END,
			VendorCode = MBWMD.VN_CODE,
			VendorName = V.VN_NAME,
			StationName = V.VN_NAME,
			FlightDates = CONVERT(CHAR(10),MBW.[START_DATE], 101) + ' - ' + CONVERT(CHAR(10),MBW.[END_DATE], 101),
			LineNumber = MBWMD.LINE_NUMBER,
			MakeGoodNumber = MBWMD.MAKEGOOD_NUMBER,
			[LineMinDate] = @DATE_START,
			[LineMaxDate] = @DATE_END,
			[Days] = MBWMD.[DAYS],
			[Time] = dbo.advfn_format_airtime(MBWMD.START_TIME, MBWMD.END_TIME),
			Program = CASE WHEN NULLIF(MBWMD.CABLE_NETWORK_STATION_CODE,'') IS NOT NULL THEN MBWMD.CABLE_NETWORK_STATION_CODE + '/' + MBWMD.PROGRAM
						ELSE MBWMD.PROGRAM END,
			Daypart = DP.[DAY_PART_CODE],
			DaypartDescription = DP.[DESCRIPTION],
			[Len] = MBWMD.[LENGTH],
			OrdSpots = (SELECT SUM(SPOTS)
						FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
						WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
						AND (
								(@HAS_DATES = 0)
							OR
								(@HAS_DATES = 1 AND MBWMDD.[DATE] between @DATE_START AND @DATE_END)
							)
						),
			SpotEstimate = CASE WHEN @USE_IMPRESSIONS = 1 THEN CASE WHEN @USE_PRIMARY_RATING = 1 THEN CAST(CAST(MBWMD.PRIMARY_AQH AS decimal(19,2)) / 100 AS decimal(19,2)) ELSE CAST(CAST(MBWMD.SECONDARY_AQH AS decimal(19,2)) / 100 AS decimal(19,2)) END
														  ELSE CASE WHEN @USE_PRIMARY_RATING = 1 THEN MBWMD.PRIMARY_AQH_RATING ELSE MBWMD.SECONDARY_AQH_RATING END END,
			Cost = (SELECT CAST(COALESCE(SUM(RATE * SPOTS), 0) as decimal(18,2))
					FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
					WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
					AND (
							(@HAS_DATES = 0)
						OR
							(@HAS_DATES = 1 AND MBWMDD.[DATE] between @DATE_START AND @DATE_END)
						)
					),
			[NielsenRadioStationComboID] = CASE WHEN MBWM.EXTERNAL_RADIO_SOURCE = 0 THEN COALESCE(V.NIELSEN_RADIO_STATION_COMBO_ID, 0)
											    WHEN MBWM.EXTERNAL_RADIO_SOURCE = 1 THEN COALESCE(V.EASTLAN_RADIO_STATION_COMBO_ID, 0)
									       END,
			NielsenMarketNumber = CASE WHEN MBWM.EXTERNAL_RADIO_SOURCE = 0 THEN 
											CASE 
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 1 THEN CAST(COALESCE(M.NIELSEN_RADIO_CODE, 0) as integer)
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 2 THEN CAST(COALESCE(M.NIELSEN_BLACK_RADIO_CODE, 0) as integer)
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 3 THEN CAST(COALESCE(M.NIELSEN_HISPANIC_RADIO_CODE, 0) as integer)
											END
									   WHEN MBWM.EXTERNAL_RADIO_SOURCE = 1 THEN 
											CASE 
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 1 THEN CAST(COALESCE(M.EASTLAN_RADIO_CODE, 0) as integer)
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 2 THEN CAST(COALESCE(M.EASTLAN_BLACK_RADIO_CODE, 0) as integer)
												WHEN MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = 3 THEN CAST(COALESCE(M.EASTLAN_HISPANIC_RADIO_CODE, 0) as integer)
											END
									   ELSE 0 END,
			DemographicDescription = (SELECT [DESCRIPTION] FROM dbo.MEDIA_DEMO WHERE MEDIA_DEMO_ID = @MEDIA_DEMO_ID),
			MediaBroadcastWorksheetMarketDetailID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID,
			MediaBroadcastWorksheetMarketID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID,
			ReportedDateStart = CASE WHEN @DATE_START IS NOT NULL AND @DATE_END IS NOT NULL THEN 
									CASE WHEN MBW.[START_DATE] > @DATE_START THEN MBW.[START_DATE] ELSE @DATE_START END
								ELSE MBW.[START_DATE]
								END,
			ReportedDateEnd =	CASE WHEN @DATE_START IS NOT NULL AND @DATE_END IS NOT NULL THEN 
									CASE WHEN MBW.[END_DATE] < @DATE_END THEN MBW.[END_DATE] ELSE @DATE_END END
								ELSE MBW.[END_DATE] 
								END,
			RatingsServiceID = MBW.RATINGS_SERVICE_ID,
			Bookend = MBWMD.BOOKEND,
			AddedValue = MBWMD.VALUE_ADDED,
			RatingSource = CASE MBWM.EXTERNAL_RADIO_SOURCE WHEN 0 THEN 'Nielsen' WHEN 1 THEN 'Eastlan' WHEN 2 THEN 'NielsenCounty' ELSE 'N/A' END,
			GeographyEthnicity = COALESCE(MBWMRG.[NAME],'') + '/' + COALESCE(MBWMRE.[NAME],''),
			[Quarter] = CASE WHEN MC.BROADCAST_QUARTER = 1 THEN 'Q1'
							 WHEN MC.BROADCAST_QUARTER = 2 THEN 'Q2'
							 WHEN MC.BROADCAST_QUARTER = 3 THEN 'Q3'
							 WHEN MC.BROADCAST_QUARTER = 4 THEN 'Q4'
							 END
		FROM dbo.MEDIA_BROADCAST_WORKSHEET MBW
			INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE
			INNER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE
			INNER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID 
			LEFT OUTER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_GEOGRAPHY MBWMRG ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_GEOGRAPHY_ID = MBWMRG.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_GEOGRAPHY_ID
			LEFT OUTER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY MBWMRE ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID = MBWMRE.MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID
			INNER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
																		 AND MBWMD.ON_HOLD = 0
																		 AND MBWMD.REVISION_NUMBER = (SELECT MAX(REVISION_NUMBER)
																									  FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL
																									  WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
			LEFT OUTER JOIN dbo.VENDOR V ON MBWMD.VN_CODE = V.VN_CODE
			LEFT OUTER JOIN dbo.DAY_PART DP ON MBWMD.DAY_PART_ID = DP.DAY_PART_ID 
			LEFT OUTER JOIN dbo.MEDIA_CALENDAR MC ON MC.[DATE] = MBW.[START_DATE]
		WHERE MBW.MEDIA_BROADCAST_WORKSHEET_ID = @MEDIA_BROADCAST_WORKSHEET_ID
		AND	(
				@MEDIA_BROADCAST_WORKSHEET_MARKETS = 'ALL'
			OR 
				(@MEDIA_BROADCAST_WORKSHEET_MARKETS <> 'ALL' AND MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKETS, ',')))
			)
	) details
	WHERE details.OrdSpots > 0
	ORDER BY details.MarketName

END
GO