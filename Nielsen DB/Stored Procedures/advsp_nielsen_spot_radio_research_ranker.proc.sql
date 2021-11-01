﻿CREATE PROCEDURE [dbo].[advsp_nielsen_spot_radio_research_ranker]
	@NIELSEN_RADIO_MARKET_NUMBER int,
	@NIELSEN_RADIO_QUALITATIVE_ID int,
	@GEO_INDICATOR smallint,
	@LISTENING_LOCATION char(1),
	@NIELSEN_RADIO_DAYPART_IDs varchar(max),
	@NIELSEN_RADIO_STATION_IDs varchar(max),
	@MEDIA_DEMO_ID int,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY,
	@MEDIA_DEMO_DETAIL_TYPE [dbo].[MEDIA_DEMO_DETAIL_TYPE] READONLY,
	@MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE [dbo].[MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE] READONLY,
	@MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE [dbo].[MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE] READONLY,
	@HOSTED_CLIENT_CODE varchar(6),
	@DEBUG bit = 0
AS
BEGIN
	DECLARE @NIELSEN_RADIO_SEGMENT_PARENT_IDs varchar(max),
			@NIELSEN_RADIO_STATION_COMBO_IDs varchar(max),
			@BOOK_NAME varchar(max),
			@ROW_COUNT int,
			@ROW_ID int,
			@MIN_AGE smallint,
			@MAX_AGE smallint,
			@NIELSEN_RADIO_REPORT_TYPE_CODE varchar(2),
			@STANDARD_CONDENSED_INDICATOR char(1),
			@INTAB_FLAG bit,
			@IS_DIARY bit,
			@COPYRIGHT varchar(36),
			@COPYRIGHT_MARKET_BOOKS varchar(max),
			@SHOW_FOOTNOTE bit,
			@SOURCE smallint,
			@SHOW_DIARY_FOOTNOTE bit
	
	DECLARE @BOOKS TABLE (
		[ID] int NOT NULL,
		[NIELSEN_RADIO_PERIOD_ID] int NOT NULL,
		[NIELSEN_RADIO_SEGMENT_PARENT_ID] int NOT NULL
	)
	
	DECLARE @BOOK_NAMES TABLE (
		[ID] int IDENTITY(1,1) NOT NULL,
		[BOOK_ID] int NOT NULL,
		[NAME] varchar(max) NULL
	)
	
	DECLARE @POPULATION TABLE (
		[Population] bigint NOT NULL,
		[NIELSEN_RADIO_SEGMENT_PARENT_ID] int NOT NULL
	)
	
	DECLARE @INTAB TABLE (
		[INTAB] bigint NULL,
		[BOOK_ID] int NOT NULL,
		[NIELSEN_RADIO_PERIOD_ID] int NOT NULL
	)
	
	DECLARE @PUR TABLE (
		[PUR] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_DAYPART_ID int NOT NULL
	)
	
	DECLARE @AQH TABLE (
		[AQH] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_DAYPART_ID int NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
		MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID int NOT NULL
	)
	
	DECLARE @CUME TABLE (
		[CUME] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_DAYPART_ID int NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL
	)
	
	DECLARE @ECUME TABLE (
		[ECUME] bigint NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		NIELSEN_RADIO_DAYPART_ID int NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL
	)
	
	DECLARE @CLIENT_PERIODS TABLE (
		NielsenRadioPeriodID int NOT NULL,
		NielsenRadioMarketNumber int NOT NULL,
		[Year] smallint NOT NULL, 
		[Month] smallint NOT NULL
	)

	IF @HOSTED_CLIENT_CODE IS NOT NULL
		INSERT @CLIENT_PERIODS 
		EXEC advsp_nielsen_spot_radio_get_client_periods @HOSTED_CLIENT_CODE

	INSERT INTO @BOOKS (ID, NIELSEN_RADIO_PERIOD_ID, NIELSEN_RADIO_SEGMENT_PARENT_ID)
	SELECT u.ID, u.NIELSEN_RADIO_PERIOD_ID, nrsp.NIELSEN_RADIO_SEGMENT_PARENT_ID
	FROM (
		SELECT ID, NielsenRadioPeriodID1, NielsenRadioPeriodID2, NielsenRadioPeriodID3, NielsenRadioPeriodID4, NielsenRadioPeriodID5
		FROM @MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE
		) t
	UNPIVOT
	(
		NIELSEN_RADIO_PERIOD_ID
		FOR [PERIOD] IN (NielsenRadioPeriodID1, NielsenRadioPeriodID2, NielsenRadioPeriodID3, NielsenRadioPeriodID4, NielsenRadioPeriodID5)
	) u
		INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_PARENT nrsp ON u.NIELSEN_RADIO_PERIOD_ID = nrsp.NIELSEN_RADIO_PERIOD_ID
		INNER JOIN dbo.NIELSEN_RADIO_PERIOD nrp ON u.NIELSEN_RADIO_PERIOD_ID = nrp.NIELSEN_RADIO_PERIOD_ID AND nrp.VALIDATED = 1
	WHERE nrsp.GEO_INDICATOR = @GEO_INDICATOR 
	AND nrsp.NIELSEN_RADIO_QUALITATIVE_ID = @NIELSEN_RADIO_QUALITATIVE_ID 
	AND (
			@HOSTED_CLIENT_CODE IS NULL
		OR
			(@HOSTED_CLIENT_CODE IS NOT NULL
			AND nrp.NIELSEN_RADIO_PERIOD_ID IN (SELECT NielsenRadioPeriodID 
												FROM @CLIENT_PERIODS
												WHERE NielsenRadioMarketNumber = @NIELSEN_RADIO_MARKET_NUMBER
												)
			)
		)

	SELECT TOP 1 @SOURCE = [SOURCE]
	FROM dbo.NIELSEN_RADIO_PERIOD
	WHERE NIELSEN_RADIO_PERIOD_ID IN (SELECT NIELSEN_RADIO_PERIOD_ID FROM @BOOKS)

	INSERT INTO @BOOK_NAMES (BOOK_ID)
	SELECT DISTINCT ID FROM @BOOKS
	
	SELECT @ROW_COUNT = COUNT(1) FROM @BOOK_NAMES
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SET @BOOK_NAME = NULL

		SELECT @BOOK_NAME = COALESCE(@BOOK_NAME + ', ', '') + UPPER(SUBSTRING([NAME], 1, 1)) + LOWER(SUBSTRING([NAME], 2, 2)) + SUBSTRING(SHORT_NAME, 5, 2)
		FROM @BOOKS b
			INNER JOIN dbo.NIELSEN_RADIO_PERIOD nrp ON b.NIELSEN_RADIO_PERIOD_ID = nrp.NIELSEN_RADIO_PERIOD_ID
		WHERE b.ID = (SELECT BOOK_ID FROM @BOOK_NAMES WHERE ID = @ROW_ID)
		ORDER BY SUBSTRING(nrp.SHORT_NAME,3,4) + SUBSTRING(nrp.SHORT_NAME,1,2)

		UPDATE @BOOK_NAMES SET NAME = @BOOK_NAME
		WHERE ID = @ROW_ID

		SET @ROW_ID = @ROW_ID + 1
	END

	SELECT @NIELSEN_RADIO_SEGMENT_PARENT_IDs = COALESCE(@NIELSEN_RADIO_SEGMENT_PARENT_IDs + ',', '') + CAST(NIELSEN_RADIO_SEGMENT_PARENT_ID as varchar)	
	FROM (SELECT DISTINCT NIELSEN_RADIO_SEGMENT_PARENT_ID FROM @BOOKS) b
	
	SELECT	@MIN_AGE = MIN(COALESCE(nd.AGE_FROM,12)), 
			@MAX_AGE = MAX(COALESCE(nd.AGE_TO,99))
	FROM @MEDIA_DEMO_DETAIL_TYPE d
		INNER JOIN dbo.NIELSEN_DEMO nd ON d.NielsenDemographicID = nd.NIELSEN_DEMO_ID 
	WHERE d.MediaDemographicID = @MEDIA_DEMO_ID

	IF @DEBUG = 1 BEGIN
		SELECT * FROM @BOOKS 
		SELECT * FROM @BOOK_NAMES 
		SELECT @NIELSEN_RADIO_SEGMENT_PARENT_IDs as '@NIELSEN_RADIO_SEGMENT_PARENT_IDs'
	END

	SELECT @NIELSEN_RADIO_STATION_COMBO_IDs = COALESCE(@NIELSEN_RADIO_STATION_COMBO_IDs + ',', '') + CAST(COMBO_ID as varchar)	
	FROM dbo.NIELSEN_RADIO_STATION 
	WHERE NIELSEN_RADIO_STATION_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_STATION_IDs, ','))
	
	IF @DEBUG = 1 BEGIN
		SELECT @NIELSEN_RADIO_STATION_COMBO_IDs as '@NIELSEN_RADIO_STATION_COMBO_IDs'
		--SELECT * FROM dbo.[advtf_nielsen_radio_universe_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID)
		--SELECT * FROM dbo.[advtf_nielsen_radio_intab_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID)
		--SELECT * FROM dbo.[advtf_nielsen_radio_pur_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_QUALITATIVE_ID)
		SELECT * FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_aqh](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE, @NIELSEN_RADIO_QUALITATIVE_ID)
		SELECT * FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_cume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @NIELSEN_RADIO_QUALITATIVE_ID)	
		SELECT * FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_ecume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @NIELSEN_RADIO_QUALITATIVE_ID)
	END
	
	IF EXISTS(SELECT 1 FROM dbo.NIELSEN_RADIO_PERIOD p
				INNER JOIN @BOOKS b ON p.NIELSEN_RADIO_PERIOD_ID = b.NIELSEN_RADIO_PERIOD_ID
				WHERE p.STANDARD_CONDENSED_INDICATOR = 'C') BEGIN
		SELECT TOP 1 @NIELSEN_RADIO_REPORT_TYPE_CODE = NIELSEN_RADIO_REPORT_TYPE_CODE, @STANDARD_CONDENSED_INDICATOR = STANDARD_CONDENSED_INDICATOR
		FROM dbo.NIELSEN_RADIO_PERIOD p
			INNER JOIN @BOOKS b ON p.NIELSEN_RADIO_PERIOD_ID = b.NIELSEN_RADIO_PERIOD_ID
		WHERE p.STANDARD_CONDENSED_INDICATOR = 'C'
	END ELSE BEGIN
		SELECT @NIELSEN_RADIO_REPORT_TYPE_CODE = NIELSEN_RADIO_REPORT_TYPE_CODE, @STANDARD_CONDENSED_INDICATOR = STANDARD_CONDENSED_INDICATOR
		FROM dbo.NIELSEN_RADIO_PERIOD 
		WHERE NIELSEN_RADIO_PERIOD_ID = (SELECT TOP 1 [NIELSEN_RADIO_PERIOD_ID] FROM @BOOKS)
	END

	IF EXISTS(
				SELECT 1 
				FROM @BOOKS b
					INNER JOIN dbo.NIELSEN_RADIO_PERIOD p ON b.NIELSEN_RADIO_PERIOD_ID = p.NIELSEN_RADIO_PERIOD_ID
				WHERE p.NIELSEN_RADIO_REPORT_TYPE_CODE IN ('1', '2', '3', '4', '6')
			 ) BEGIN
		
		SET @IS_DIARY = 1
			
	END ELSE BEGIN
		
		SET @IS_DIARY = 0

	END

	SELECT TOP 1 @COPYRIGHT = p.COPYRIGHT
	FROM @BOOKS b
		INNER JOIN dbo.NIELSEN_RADIO_PERIOD p ON b.NIELSEN_RADIO_PERIOD_ID = p.NIELSEN_RADIO_PERIOD_ID
	ORDER BY SUBSTRING(p.SHORT_NAME, 3, 4) DESC, SUBSTRING(p.SHORT_NAME, 1, 2) DESC
	
	SELECT @COPYRIGHT_MARKET_BOOKS = COALESCE(@COPYRIGHT_MARKET_BOOKS + ', ', '') + CASE WHEN @COPYRIGHT_MARKET_BOOKS IS NULL THEN m.[NAME] + ' ' + 
			CASE 
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) >= 1 and CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) <= 12 THEN SUBSTRING(DateName( month , DateAdd( month , CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) , -1 )), 1,3) + SUBSTRING(p.SHORT_NAME, 5, 2)
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) = 21 THEN 'Spr' + SUBSTRING(p.SHORT_NAME, 5, 2) + '/' + 'Fal' + CAST(CAST(SUBSTRING(p.SHORT_NAME, 5, 2) as smallint) - 1 as varchar)
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) = 22 THEN 'Fal' + SUBSTRING(p.SHORT_NAME, 5, 2) + '/' + 'Spr' + SUBSTRING(p.SHORT_NAME, 5, 2)
			ELSE UPPER(SUBSTRING(p.NAME, 1, 1)) + LOWER(SUBSTRING(p.NAME, 2, 2)) + SUBSTRING(p.SHORT_NAME, 5, 2)
			END
		ELSE
			CASE 
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) >= 1 and CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) <= 12 THEN SUBSTRING(DateName( month , DateAdd( month , CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) , -1 )), 1,3) + SUBSTRING(p.SHORT_NAME, 5, 2)
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) = 21 THEN 'Spr' + SUBSTRING(p.SHORT_NAME, 5, 2) + '/' + 'Fal' + CAST(CAST(SUBSTRING(p.SHORT_NAME, 5, 2) as smallint) - 1 as varchar)
				WHEN CAST(SUBSTRING(p.SHORT_NAME, 1, 2) as smallint) = 22 THEN 'Fal' + SUBSTRING(p.SHORT_NAME, 5, 2) + '/' + 'Spr' + SUBSTRING(p.SHORT_NAME, 5, 2)
			ELSE UPPER(SUBSTRING(p.NAME, 1, 1)) + LOWER(SUBSTRING(p.NAME, 2, 2)) + SUBSTRING(p.SHORT_NAME, 5, 2)
			END
		--REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(p.NAME, 'JANUARY', 'JAN'), 'FEBRUARY', 'FEB'), 'MARCH', 'MAR'), 'APRIL', 'APR'), 'JUNE', 'JUN'), 'JULY', 'JUL'), 'AUGUST', 'AUG'), 'SEPTEMBER', 'SEP'), 'OCTOBER', 'OCT'), 'NOVEMBER', 'NOV'), 'DECEMBER', 'DEC')
		--ELSE REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(p.NAME, 'JANUARY', 'JAN'), 'FEBRUARY', 'FEB'), 'MARCH', 'MAR'), 'APRIL', 'APR'), 'JUNE', 'JUN'), 'JULY', 'JUL'), 'AUGUST', 'AUG'), 'SEPTEMBER', 'SEP'), 'OCTOBER', 'OCT'), 'NOVEMBER', 'NOV'), 'DECEMBER', 'DEC')
		END
	FROM (
		SELECT DISTINCT b.NIELSEN_RADIO_PERIOD_ID 
		FROM @BOOKS b
		) b
		INNER JOIN dbo.NIELSEN_RADIO_PERIOD p ON b.NIELSEN_RADIO_PERIOD_ID = p.NIELSEN_RADIO_PERIOD_ID
		INNER JOIN dbo.NIELSEN_RADIO_MARKET m ON p.NIELSEN_RADIO_MARKET_NUMBER = m.NUMBER AND m.[SOURCE] = @SOURCE
	ORDER BY SUBSTRING(p.SHORT_NAME, 3, 4) DESC, SUBSTRING(p.SHORT_NAME, 1, 2) DESC
	
	IF EXISTS(
				SELECT 1
				FROM @BOOKS b
					INNER JOIN dbo.NIELSEN_RADIO_PERIOD p ON b.NIELSEN_RADIO_PERIOD_ID = p.NIELSEN_RADIO_PERIOD_ID
				WHERE p.NIELSEN_RADIO_REPORT_TYPE_CODE IN (5,7,8,9)
			 )
		SET @SHOW_FOOTNOTE = 1
	ELSE
		SET @SHOW_FOOTNOTE = 0
		
	IF EXISTS(
				SELECT 1
				FROM @BOOKS b
					INNER JOIN dbo.NIELSEN_RADIO_PERIOD p ON b.NIELSEN_RADIO_PERIOD_ID = p.NIELSEN_RADIO_PERIOD_ID
				WHERE p.NIELSEN_RADIO_REPORT_TYPE_CODE = 6
			 )
		SET @SHOW_DIARY_FOOTNOTE = 1
	ELSE
		SET @SHOW_DIARY_FOOTNOTE = 0

	IF (SELECT [dbo].[advfn_nielsen_ignore_intab_check](@NIELSEN_RADIO_QUALITATIVE_ID, @NIELSEN_RADIO_REPORT_TYPE_CODE, @STANDARD_CONDENSED_INDICATOR, @MIN_AGE, @MAX_AGE)) = 1 BEGIN
		SET @INTAB_FLAG = 0
		
		IF @DEBUG = 1
			SELECT 'ignore intab', @INTAB_FLAG as '@INTAB_FLAG'
	END ELSE BEGIN
		
		IF EXISTS(SELECT 1 FROM @INTAB WHERE INTAB < 30)
			SET @INTAB_FLAG = 1
		ELSE
			SET @INTAB_FLAG = 0

		IF @DEBUG = 1
			SELECT 'DO NOT ignore intab', @INTAB_FLAG as '@INTAB_FLAG'
	END

	INSERT INTO @INTAB ([INTAB], [BOOK_ID], [NIELSEN_RADIO_PERIOD_ID])
	SELECT SUM([INTAB]), B.ID, [NIELSEN_RADIO_PERIOD_ID]
	FROM dbo.[advtf_nielsen_radio_intab_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) I
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = I.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
		INNER JOIN @BOOKS B ON B.[NIELSEN_RADIO_SEGMENT_PARENT_ID] = I.[NIELSEN_RADIO_SEGMENT_PARENT_ID]
	GROUP BY B.ID, [NIELSEN_RADIO_PERIOD_ID]

	INSERT INTO @POPULATION ([Population], [NIELSEN_RADIO_SEGMENT_PARENT_ID])
	SELECT SUM([POPULATION]), [NIELSEN_RADIO_SEGMENT_PARENT_ID]
	FROM dbo.[advtf_nielsen_radio_universe_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) U
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = U.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
	GROUP BY [NIELSEN_RADIO_SEGMENT_PARENT_ID]
	
	INSERT INTO @PUR (PUR, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID)
	SELECT SUM([PUR]), NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID
	FROM dbo.[advtf_nielsen_radio_pur_spot_radio_research](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_QUALITATIVE_ID) P
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = P.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
	GROUP BY NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID

	INSERT INTO @AQH (AQH, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID, NIELSEN_RADIO_STATION_COMBO_ID, MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID)
	SELECT SUM(AQH), AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID
	FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_aqh](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE, @NIELSEN_RADIO_QUALITATIVE_ID) AQH
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = AQH.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
	GROUP BY AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID
	
	INSERT INTO @CUME (CUME, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID, NIELSEN_RADIO_STATION_COMBO_ID)
	SELECT SUM(CUME), AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID
	FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_cume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) AQH
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = AQH.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
	GROUP BY AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID

	INSERT INTO @ECUME (ECUME, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_DAYPART_ID, NIELSEN_RADIO_STATION_COMBO_ID)
	SELECT SUM(ECUME), AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID
	FROM dbo.[advtf_nielsen_radio_audience_spot_radio_research_ecume](@NIELSEN_RADIO_SEGMENT_PARENT_IDs, @NIELSEN_RADIO_DAYPART_IDs, @LISTENING_LOCATION, @NIELSEN_RADIO_STATION_COMBO_IDs, @NIELSEN_RADIO_QUALITATIVE_ID) AQH
		INNER JOIN dbo.NIELSEN_DEMO ND ON ND.CODE = AQH.NIELSEN_DEMO_CODE 
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID AND MDDT.MediaDemographicID = @MEDIA_DEMO_ID
	GROUP BY AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID

	IF @DEBUG = 1 BEGIN
		SELECT * FROM @POPULATION
		SELECT * FROM @PUR
		SELECT * FROM @AQH
		SELECT * FROM @CUME
		SELECT * FROM @ECUME
		SELECT * FROM @INTAB
	END

	SELECT 
		pop.[BookID],
		[Demographic] = (SELECT [Description] FROM @MEDIA_DEMO_TYPE WHERE ID = @MEDIA_DEMO_ID),
		[Population] = pop.[Population],
		[AQH],
		[AQHRating] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND( CAST( AQH as decimal) / CAST( [Population] / 100 as decimal) * 100, 1) END,
		[AQHShare] = CASE WHEN [PUR] = 0 THEN CAST(0 as decimal) ELSE ROUND( (CAST( AQH * 100 as decimal) / CAST( [PUR] as decimal)), 1) END,
		[PUR] = pur.[PUR],
		[PURPercent] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND(CAST( PUR * 100 as decimal) / CAST([Population] / 100 as decimal), 1) END,
		[Cume],
		[ExclusiveCume],
		[CumeRating] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND( CAST( [Cume] as decimal) / CAST( [Population] / 100 as decimal) * 100, 1) END,
		[CumeShare] = CASE WHEN [Population] = 0 THEN CAST(0 as decimal) ELSE CAST( [Cume] as decimal) / CAST( [Population] as decimal) * CAST(100 as decimal) END,
		[CumePercent] = CASE WHEN [Population] = 0 THEN 0 ELSE ROUND(CAST( [Cume] as decimal) / CAST( [Population] / 100 as decimal) * 100, 1) END,
		AQH.[Daypart],
		AQH.NielsenRadioDaypartID,
		AQH.NIELSEN_RADIO_STATION_COMBO_ID,
		[StationName] = NRS.[NAME],
		[StationFormat] = NRF.[NAME],
		[StationFrequency] = NRS.FREQUENCY,
		[IsSpill] = NRS.IS_SPILLIN,
		MediaSpotRadioResearchDaypartID,
		[Market] = NRM.[NAME],
		[Books] = (SELECT [NAME] FROM @BOOK_NAMES WHERE BOOK_ID = pop.[BookID]),
		[DaypartBooks] = AQH.[Daypart] + ' / ' + (SELECT [NAME] FROM @BOOK_NAMES WHERE BOOK_ID = pop.[BookID]),
		[NielsenRadioStationID] = NRS.NIELSEN_RADIO_STATION_ID,
		[Intab] = CASE	WHEN @IS_DIARY = 0 THEN CAST(COALESCE((SELECT AVG(INTAB) FROM @INTAB), 0) as bigint)
						WHEN @IS_DIARY = 1 THEN CAST(COALESCE((SELECT SUM(INTAB) FROM @INTAB), 0) as bigint)
				  END,
		[IntabFlag] = @INTAB_FLAG,
		[QualitativeName] = CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID = 1 THEN '' ELSE (SELECT [NAME] FROM dbo.NIELSEN_RADIO_QUALITATIVE WHERE NIELSEN_RADIO_QUALITATIVE_ID = @NIELSEN_RADIO_QUALITATIVE_ID) END,
		[BookCount] = CAST( (SELECT COALESCE(COUNT(1), 0) FROM @BOOKS) as int),
		[Copyright] = @COPYRIGHT,
		[CopyrightMarketBooks] = @COPYRIGHT_MARKET_BOOKS,
		[ShowFootNote] = @SHOW_FOOTNOTE,
		--trend
		TrendBookOrder = CAST(
						   (SELECT TOP 1 SUBSTRING(SHORT_NAME,3,4) + SUBSTRING(SHORT_NAME,1,2) 
							FROM dbo.NIELSEN_RADIO_PERIOD nrp
								INNER JOIN @BOOKS b ON nrp.NIELSEN_RADIO_PERIOD_ID = b.NIELSEN_RADIO_PERIOD_ID
							WHERE b.ID = pop.[BookID]
							ORDER BY 1) as int),
		[ShowDiaryFootNote] = @SHOW_DIARY_FOOTNOTE
	FROM
		(SELECT [Population] = AVG([Population]), [BookID] = B.ID
		FROM
		@BOOKS B
			INNER JOIN @POPULATION POP ON POP.NIELSEN_RADIO_SEGMENT_PARENT_ID = B.NIELSEN_RADIO_SEGMENT_PARENT_ID
		GROUP BY B.ID
		) pop

		INNER JOIN 
		(
		SELECT
			[AQH] = ROUND( AVG(AQH.[AQH]), -2) / 100,
			[NielsenRadioDaypartID] = AQH.NIELSEN_RADIO_DAYPART_ID,
			AQH.NIELSEN_RADIO_STATION_COMBO_ID,
			MediaSpotRadioResearchDaypartID = AQH.MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID,
			[BookID] = B.ID,
			[Daypart] =  NRD.NAME
		FROM @BOOKS B
			INNER JOIN @AQH AQH ON AQH.NIELSEN_RADIO_SEGMENT_PARENT_ID = B.NIELSEN_RADIO_SEGMENT_PARENT_ID
			INNER JOIN dbo.NIELSEN_RADIO_DAYPART NRD ON AQH.NIELSEN_RADIO_DAYPART_ID = NRD.NIELSEN_RADIO_DAYPART_ID
		GROUP BY B.ID, AQH.NIELSEN_RADIO_DAYPART_ID, AQH.NIELSEN_RADIO_STATION_COMBO_ID, AQH.MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID, NRD.NAME
		) AQH ON pop.BookID = AQH.BookID
		
		INNER JOIN 
		(SELECT [PUR] = ROUND( AVG([PUR]), -2) / 100, [BookID] = B.ID, PUR.NIELSEN_RADIO_DAYPART_ID
		FROM
		@BOOKS B
			INNER JOIN @PUR PUR ON PUR.NIELSEN_RADIO_SEGMENT_PARENT_ID = B.NIELSEN_RADIO_SEGMENT_PARENT_ID
		GROUP BY B.ID, PUR.NIELSEN_RADIO_DAYPART_ID
		) pur ON pur.BookID = AQH.BookID AND pur.NIELSEN_RADIO_DAYPART_ID = AQH.NielsenRadioDaypartID 

		INNER JOIN 
		(
		SELECT
			[Cume] = ROUND( AVG([CUME]), -2) / 100,
			CUME.NIELSEN_RADIO_DAYPART_ID,
			CUME.NIELSEN_RADIO_STATION_COMBO_ID,
			[BookID] = B.ID
		FROM @BOOKS B
			INNER JOIN @CUME CUME ON CUME.NIELSEN_RADIO_SEGMENT_PARENT_ID = B.NIELSEN_RADIO_SEGMENT_PARENT_ID
		GROUP BY B.ID, CUME.NIELSEN_RADIO_DAYPART_ID, CUME.NIELSEN_RADIO_STATION_COMBO_ID
		) CUME ON CUME.BookID = AQH.BookID AND CUME.NIELSEN_RADIO_DAYPART_ID = AQH.NielsenRadioDaypartID AND CUME.NIELSEN_RADIO_STATION_COMBO_ID = AQH.NIELSEN_RADIO_STATION_COMBO_ID 

		INNER JOIN 
		(
		SELECT
			[ExclusiveCume] = ROUND( AVG([ECUME]), -2) / 100,
			ECUME.NIELSEN_RADIO_DAYPART_ID,
			ECUME.NIELSEN_RADIO_STATION_COMBO_ID,
			[BookID] = B.ID
		FROM @BOOKS B
			INNER JOIN @ECUME ECUME ON ECUME.NIELSEN_RADIO_SEGMENT_PARENT_ID = B.NIELSEN_RADIO_SEGMENT_PARENT_ID
		GROUP BY B.ID, ECUME.NIELSEN_RADIO_DAYPART_ID, ECUME.NIELSEN_RADIO_STATION_COMBO_ID
		) ECUME ON ECUME.BookID = AQH.BookID AND ECUME.NIELSEN_RADIO_DAYPART_ID = AQH.NielsenRadioDaypartID AND ECUME.NIELSEN_RADIO_STATION_COMBO_ID = AQH.NIELSEN_RADIO_STATION_COMBO_ID 

		INNER JOIN dbo.NIELSEN_RADIO_STATION NRS
			ON NRS.NIELSEN_RADIO_MARKET_NUMBER = @NIELSEN_RADIO_MARKET_NUMBER AND NRS.COMBO_ID = AQH.NIELSEN_RADIO_STATION_COMBO_ID
		LEFT OUTER JOIN dbo.NIELSEN_RADIO_FORMAT NRF
			ON NRS.NIELSEN_RADIO_FORMAT_CODE = NRF.CODE
		INNER JOIN dbo.NIELSEN_RADIO_MARKET NRM ON NRM.NUMBER = @NIELSEN_RADIO_MARKET_NUMBER AND NRM.[SOURCE] = @SOURCE
END
GO
