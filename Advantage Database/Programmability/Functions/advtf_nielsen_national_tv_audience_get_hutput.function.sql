CREATE FUNCTION [dbo].[advtf_nielsen_national_tv_audience_get_hutput](
	@MEDIA_MARKET_BREAK_ID int,
	@TIME_TYPE char(1),
	@STREAM char(2),
	@START_DATE smalldatetime,
	@START_TIME smallint,
	@END_DATE smalldatetime,
	@END_TIME smallint,
	@SUN bit, @MON bit, @TUE bit, @WED bit, @THU bit, @FRI bit, @SAT bit,
	@SelectedMediaDemographicIDs varchar(max)
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[Network] char(6) NOT NULL,
	[Date] smalldatetime NOT NULL,
	[ProgramName] varchar(25) NOT NULL,
	[EpisodeName] varchar(32) NOT NULL,
	[StartTime] smallint NOT NULL,
	[EndTime] smallint NOT NULL,
	[ProgramDuration] smallint NOT NULL,
	[hutput] bigint NOT NULL,
	MEDIA_DEMO_ID int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.Network, u.[Date], u.ProgramName, u.EpisodeName, u.StartTime, u.EndTime, u.ProgramDuration, u.hutput, mdd.MEDIA_DEMO_ID
	FROM (
		SELECT
			[Network] = NETWORK,
			[Date] = AUDIENCE_DATE,
			[ProgramName] = [PROGRAM_NAME],
			[EpisodeName] = EPISODE_NAME,
			[StartTime] = AUDIENCE_TIME,
			[EndTime] = AUDIENCE_TIME + (PROGRAM_DURATION / 60 * 100) + (PROGRAM_DURATION % 60),
			[ProgramDuration] = PROGRAM_DURATION,
			[nhh] = a.HOUSEHOLD_HUT,
			[nf2-5] = a.FEMALES_2TO5_PUT,
			[nf6-8] = a.FEMALES_6TO8_PUT,
			[nf9-11] = a.FEMALES_9TO11_PUT,
			[nf12-14] = a.FEMALES_12TO14_PUT,
			[nf15-17] = a.FEMALES_15TO17_PUT,
			[nf18-20] = a.FEMALES_18TO20_PUT,
			[nf21-24] = a.FEMALES_21TO24_PUT,
			[nf25-29] = a.FEMALES_25TO29_PUT,
			[nf30-34] = a.FEMALES_30TO34_PUT,
			[nf35-39] = a.FEMALES_35TO39_PUT,
			[nf40-44] = a.FEMALES_40TO44_PUT,
			[nf45-49] = a.FEMALES_45TO49_PUT,
			[nf50-54] = a.FEMALES_50TO54_PUT,
			[nf55-64] = a.FEMALES_55TO64_PUT,
			[nf65P] = a.FEMALES_65PLUS_PUT,
			[nm2-5] = a.MALES_2TO5_PUT,
			[nm6-8] = a.MALES_6TO8_PUT,
			[nm9-11] = a.MALES_9TO11_PUT,
			[nm12-14] = a.MALES_12TO14_PUT,
			[nm15-17] = a.MALES_15TO17_PUT,
			[nm18-20] = a.MALES_18TO20_PUT,
			[nm21-24] = a.MALES_21TO24_PUT,
			[nm25-29] = a.MALES_25TO29_PUT,
			[nm30-34] = a.MALES_30TO34_PUT,
			[nm35-39] = a.MALES_35TO39_PUT,
			[nm40-44] = a.MALES_40TO44_PUT,
			[nm45-49] = a.MALES_45TO49_PUT,
			[nm50-54] = a.MALES_50TO54_PUT,
			[nm55-64] = a.MALES_55TO64_PUT,
			[nm65P] = a.MALES_65PLUS_PUT,
			[ww18-20] = a.WORKING_WOMEN_18TO20_PUT,
			[ww21-24] = a.WORKING_WOMEN_21TO24_PUT,
			[ww25-34] = a.WORKING_WOMEN_25TO34_PUT,
			[ww35-44] = a.WORKING_WOMEN_35TO44_PUT,
			[ww45-49] = a.WORKING_WOMEN_45TO49_PUT,
			[ww50-54] = a.WORKING_WOMEN_50TO54_PUT,
			[ww55P] = a.WORKING_WOMEN_55PLUS_PUT
		FROM dbo.NIELSEN_NATIONAL_TV_AUDIENCE a
		WHERE MEDIA_MARKET_BREAK_ID = @MEDIA_MARKET_BREAK_ID
		AND TIME_TYPE = @TIME_TYPE 
		AND STREAM = @STREAM 
		AND AUDIENCE_DATE BETWEEN @START_DATE AND @END_DATE
		AND AUDIENCE_TIME >= @START_TIME 
		AND AUDIENCE_TIME < @END_TIME 
		AND (
				(@SUN = 1 AND DATEPART(dw, AUDIENCE_DATE) = 1)
			OR	(@MON = 1 AND DATEPART(dw, AUDIENCE_DATE) = 2)
			OR	(@TUE = 1 AND DATEPART(dw, AUDIENCE_DATE) = 3)
			OR	(@WED = 1 AND DATEPART(dw, AUDIENCE_DATE) = 4)
			OR	(@THU = 1 AND DATEPART(dw, AUDIENCE_DATE) = 5)
			OR	(@FRI = 1 AND DATEPART(dw, AUDIENCE_DATE) = 6)
			OR	(@SAT = 1 AND DATEPART(dw, AUDIENCE_DATE) = 7)
			)
	) hutdata
	UNPIVOT
	(
		hutput
		for nielsen_demo_code in ([nhh], [nf2-5], [nf6-8], [nf9-11], [nf12-14], [nf15-17], [nf18-20], [nf21-24], [nf25-29], [nf30-34], [nf35-39], [nf40-44],
			[nf45-49], [nf50-54], [nf55-64], [nf65P], [nm2-5], [nm6-8], [nm9-11], [nm12-14], [nm15-17], [nm18-20], [nm21-24], [nm25-29], [nm30-34], [nm35-39],
			[nm40-44], [nm45-49], [nm50-54], [nm55-64], [nm65P], [ww18-20], [ww21-24], [ww25-34], [ww35-44], [ww45-49], [ww50-54], [ww55P]) 
	) u
		INNER JOIN dbo.NIELSEN_DEMO nd ON u.nielsen_demo_code = nd.CODE
		INNER JOIN dbo.MEDIA_DEMO_DETAIL mdd ON nd.NIELSEN_DEMO_ID = mdd.NIELSEN_DEMO_ID 
	WHERE mdd.MEDIA_DEMO_ID IN (SELECT items FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	RETURN
END
GO