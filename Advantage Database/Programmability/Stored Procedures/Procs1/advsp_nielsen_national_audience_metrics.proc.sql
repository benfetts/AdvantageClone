CREATE PROCEDURE [dbo].[advsp_nielsen_national_audience_metrics]
	@MEDIA_MARKET_BREAK_ID int,
	@TIME_TYPE char(1),
	@STREAM char(2),
	@START_DATE smalldatetime,
	@START_TIME smallint,
	@END_DATE smalldatetime,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@GROUP_BY int, -- 0:None, 1:Date, 2:Network
	@SelectedMediaDemographicIDs varchar(max)
AS
BEGIN
/*
DECLARE @MEDIA_MARKET_BREAK_ID int,
		@TIME_TYPE char(1),
		@STREAM char(2),
		@START_DATE smalldatetime,
		@START_TIME smallint,
		@END_DATE smalldatetime,
		@END_TIME smallint,
		@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
		@GROUP_BY int, -- 0:None, 1:Date, 2:Network
		@SelectedMediaDemographicIDs varchar(max)

SET @MEDIA_MARKET_BREAK_ID = 1
SET @TIME_TYPE = 'P'
SET @STREAM = 'LV'
SET	@START_DATE = '2/2/2015'
SET	@START_TIME = 600
SET @END_DATE = '2/8/2015'
SET	@END_TIME = 2959
SET @SUN = 1
SET @MON = 1
SET @TUE = 1
SET @WED = 1
SET @THU = 1
SET @FRI = 1
SET @SAT = 1
SET @GROUP_BY = 0
SET @SelectedMediaDemographicIDs = '166'
*/

--select * from [advtf_nielsen_national_tv_audience_get_aud](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs)
--select * from [advtf_nielsen_national_tv_audience_get_hutput](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs)
--  drop table #NIELSEN_NATIONAL_RESULTS 
	CREATE TABLE #NIELSEN_NATIONAL_RESULTS (
		[MEDIA_DEMO_ID]		int NOT NULL,
		[Network]			char(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[Date]				smalldatetime NULL,
		[ProgramName]		varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[EpisodeName]		varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[StartTime]			smallint NULL,
		[EndTime]			smallint NULL,		
		[D]					bigint NOT NULL,
		[U]					bigint NOT NULL,
		[A]					bigint NOT NULL,
		[H]					bigint NOT NULL
	)

	IF @GROUP_BY = 0 BEGIN
		INSERT #NIELSEN_NATIONAL_RESULTS ( [MEDIA_DEMO_ID], [Network], [Date], ProgramName, EpisodeName, StartTime, EndTime, D, U, A, H )
		SELECT
			audience.MEDIA_DEMO_ID,
			audience.Network,
			audience.[Date],
			audience.ProgramName,
			audience.EpisodeName,
			audience.StartTime,
			audience.EndTime,
			D = audience.ProgramDuration,
			U = SUM(ProgramDuration * UE),
			A = SUM(AudProgramDuraction),
			H = 0
		FROM 
			(
			SELECT 
					MEDIA_DEMO_ID,
					Network, 
					[Date], 
					ProgramName, 
					EpisodeName, 
					StartTime, 
					EndTime,
					ProgramDuration,
					AudProgramDuraction = aud * ProgramDuration,
					UE = uni.ue
			FROM dbo.[advtf_nielsen_national_tv_audience_get_aud](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																	@SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
				INNER JOIN (
							SELECT nielsen_demo_code, [start_date], end_date, ue
							FROM [dbo].[advtf_nielsen_national_tv_universe_get](@MEDIA_MARKET_BREAK_ID)
							) uni ON f.nielsen_demo_code = uni.nielsen_demo_code AND f.[Date] BETWEEN uni.[start_date] AND uni.end_date
			) audience
		
		GROUP BY
			audience.MEDIA_DEMO_ID,
			audience.Network, 
			audience.[Date], 
			audience.ProgramName, 
			audience.EpisodeName, 
			audience.StartTime, 
			audience.EndTime,
			audience.ProgramDuration

		CREATE NONCLUSTERED INDEX a ON #NIELSEN_NATIONAL_RESULTS (MEDIA_DEMO_ID, Network, [Date], ProgramName, EpisodeName, StartTime, EndTime, D)

		UPDATE T SET H = hutput.H
		FROM #NIELSEN_NATIONAL_RESULTS T
			INNER JOIN (
						SELECT
								MEDIA_DEMO_ID,
								Network,
								[Date],
								ProgramName,
								EpisodeName,
								StartTime,
								EndTime,
								ProgramDuration,
								H = SUM(hutput * ProgramDuration)
						FROM dbo.[advtf_nielsen_national_tv_audience_get_hutput](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																				 @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
						GROUP BY
								MEDIA_DEMO_ID,
								Network,
								[Date],
								ProgramName,
								EpisodeName,
								StartTime,
								EndTime,
								ProgramDuration
						) hutput ON hutput.MEDIA_DEMO_ID = T.MEDIA_DEMO_ID
									AND hutput.[Network] = T.[Network]
									AND hutput.[Date] = T.[Date]
									AND hutput.[ProgramName] = T.[ProgramName]
									AND hutput.[EpisodeName] = T.[EpisodeName]
									AND hutput.[StartTime] = T.[StartTime]
									AND hutput.[EndTime] = T.[EndTime]
									AND hutput.ProgramDuration = T.D

	END ELSE IF @GROUP_BY = 1 BEGIN
		INSERT #NIELSEN_NATIONAL_RESULTS ( [MEDIA_DEMO_ID], [Date], D, U, A, H )
		SELECT
			audience.MEDIA_DEMO_ID, 
			audience.[Date],
			D = SUM(audience.ProgramDuration),
			U = SUM(audience.UE),
			A = SUM(audience.AudProgramDuraction),
			H = 0
		FROM 
			(
			SELECT
					MEDIA_DEMO_ID,
					[Date],
					ProgramDuration = ProgramDuration,
					AudProgramDuraction = aud * ProgramDuration,
					UE = uni.ue * ProgramDuration
			FROM dbo.[advtf_nielsen_national_tv_audience_get_aud](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																	@SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
				INNER JOIN (
							SELECT nielsen_demo_code, [start_date], end_date, ue
							FROM [dbo].[advtf_nielsen_national_tv_universe_get](@MEDIA_MARKET_BREAK_ID)
							) uni ON f.nielsen_demo_code = uni.nielsen_demo_code AND f.[Date] BETWEEN uni.[start_date] AND uni.end_date 
			) audience
		GROUP BY
			MEDIA_DEMO_ID, 
			[Date]

		CREATE NONCLUSTERED INDEX b ON #NIELSEN_NATIONAL_RESULTS (MEDIA_DEMO_ID, [Date])

		UPDATE T SET H = hutput.H
		FROM #NIELSEN_NATIONAL_RESULTS T
			INNER JOIN (
						SELECT
								MEDIA_DEMO_ID,
								[Date], 
								H = SUM(hutput * ProgramDuration)
						FROM dbo.[advtf_nielsen_national_tv_audience_get_hutput](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																				 @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
						GROUP BY
								MEDIA_DEMO_ID,
								[Date]
						) hutput ON hutput.MEDIA_DEMO_ID = T.MEDIA_DEMO_ID 
									AND hutput.[Date] = T.[Date]

	END ELSE IF @GROUP_BY = 2 BEGIN
		INSERT #NIELSEN_NATIONAL_RESULTS ( [MEDIA_DEMO_ID], [Network], D, U, A, H )
		SELECT
			audience.MEDIA_DEMO_ID,
			audience.Network,
			D = SUM(audience.ProgramDuration),
			U = SUM(audience.UE),
			A = SUM(audience.AudProgramDuraction),
			H = 0
		FROM 
			(
			SELECT 
					MEDIA_DEMO_ID,
					Network, 
					ProgramDuration = ProgramDuration,
					AudProgramDuraction = aud * ProgramDuration,
					UE = uni.ue * ProgramDuration
			FROM dbo.[advtf_nielsen_national_tv_audience_get_aud](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																	@SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
				INNER JOIN (
							SELECT nielsen_demo_code, [start_date], end_date, ue
							FROM [dbo].[advtf_nielsen_national_tv_universe_get](@MEDIA_MARKET_BREAK_ID)
							) uni ON f.nielsen_demo_code = uni.nielsen_demo_code AND f.[Date] BETWEEN uni.[start_date] AND uni.end_date 
			) audience
		GROUP BY
			MEDIA_DEMO_ID,
			Network

		CREATE NONCLUSTERED INDEX c ON #NIELSEN_NATIONAL_RESULTS (MEDIA_DEMO_ID, Network)

		UPDATE T SET H = hutput.H
		FROM #NIELSEN_NATIONAL_RESULTS T
			INNER JOIN (
						SELECT
								MEDIA_DEMO_ID,
								Network,
								H = SUM(hutput * ProgramDuration)
						FROM dbo.[advtf_nielsen_national_tv_audience_get_hutput](@MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME,
																				 @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @SelectedMediaDemographicIDs) f
						GROUP BY MEDIA_DEMO_ID,
								Network
						) hutput ON hutput.MEDIA_DEMO_ID = T.MEDIA_DEMO_ID
									AND hutput.Network = T.Network

	END

	SELECT
		MediaDemoDescription = md.[DESCRIPTION],
		[Network],
		[Date],
		[ProgramName],
		[EpisodeName],
		[StartTime],
		[EndTime],
		[Universe] = CASE WHEN D = 0 THEN 0 ELSE CAST( U/D as decimal) END,
		[Impressions] = CASE WHEN D = 0 THEN 0 ELSE CAST( A/D as decimal) END,
		[Rating] = CASE WHEN D = 0 OR U = 0 THEN 0 ELSE 100 * CAST( A/D as decimal) / cast ( U/D as decimal ) / cast ( 1000 as decimal ) END,
		[Share] = CASE WHEN D = 0 OR H = 0 THEN 0 ELSE 100 * CAST( A/D as decimal) / cast ( H/D as decimal ) END,
		[HUT_PCT] = CASE WHEN D = 0 OR u = 0 THEN 0 ELSE 100 * CAST( H/D as decimal) / cast ( U/D as decimal ) / cast ( 1000 as decimal ) END
		--, D, U, A, H
	FROM #NIELSEN_NATIONAL_RESULTS r
		INNER JOIN dbo.MEDIA_DEMO md ON r.MEDIA_DEMO_ID = md.MEDIA_DEMO_ID
END
GO
