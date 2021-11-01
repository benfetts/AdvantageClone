CREATE PROCEDURE [dbo].[advsp_national_research_program_flowchart]
    @CLIENT_CODE varchar(6),
	@TIME_TYPE char(1),
	@NATIONAL_NETWORK_IDS varchar(MAX),
	@STARTDATE smalldatetime,
	@ENDDATE smalldatetime,
	@STARTHOUR smallint,
	@ENDHOUR smallint,
	@MON bit,
	@TUE bit,
	@WED bit,
	@THU bit,
	@FRI bit,
	@SAT bit,
	@SUN bit,
	@BREAKOUT_FLAG char(1),
	@REPEAT_FLAG char(1),
	@SPECIAL_FLAG char(1),
	@PREMIERE_FLAG char(1),
	@OVERNIGHT_FLAG char(1), -- means IS_PRELIMINARY from NATIONAL_DATA
	@CORRECTION_FLAG char(1),
	@STREAM varchar(2),
	@SHOW_PROGRAM_TYPES bit,
	@SHOW_AIRINGS bit,
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, 
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE READONLY,
	@NATIONAL_UNIVERSE_TYPE dbo.NATIONAL_UNIVERSE_TYPE READONLY,
	@BROADCAST_DATE_TYPE dbo.BROADCAST_DATE_TYPE READONLY,
	@SELECTED_METRIC varchar(20),
	@DEBUG bit = 0
AS

DECLARE	@HH_ADDED bit,
		@LOCAL_MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE, 
		@LOCAL_MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE,
		@LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE

INSERT INTO @LOCAL_MEDIA_DEMO_TYPE
SELECT * FROM @MEDIA_DEMO_TYPE

INSERT INTO @LOCAL_MEDIA_DEMO_DETAIL_TYPE
SELECT * FROM @MEDIA_DEMO_DETAIL_TYPE

INSERT INTO @LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE
SELECT * FROM @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE

IF EXISTS(select 1 from @LOCAL_MEDIA_DEMO_TYPE WHERE ID = 97)
	SET @HH_ADDED = 0
ELSE BEGIN
	INSERT INTO @LOCAL_MEDIA_DEMO_TYPE values(97,'Households')
	INSERT INTO @LOCAL_MEDIA_DEMO_DETAIL_TYPE values(97,44)
	INSERT INTO @LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE values(97,100)
	SET @HH_ADDED = 1
END

CREATE TABLE #RESULT (
	[ID]				int identity(1,1) NOT NULL,
	[Network]			varchar(10) NOT NULL ,
	[ProgramName]		varchar(25) NOT NULL,
	ProgramType			varchar(2) NOT NULL,
	Airings				int NOT NULL,
	[MediaDemoID]		int NOT NULL,
	[Demographic]		varchar(50) NOT NULL,
	DemographicOrder	smallint NOT NULL,
	tot_dur				int NOT NULL,
	tot_aud				bigint NOT NULL,
	tot_ue				bigint NOT NULL,
	tot_hut				bigint NOT NULL,
	tot_put				bigint NOT NULL,
	[yyyymm]			char(6) NOT NULL
)

IF @DEBUG = 1
	SELECT GETDATE() as 'START'

SELECT *
INTO #TRPT
FROM (
	SELECT
		NA.NATIONAL_AUDIENCE_ID,
		[Network] = NA.NETWORK + CASE
									WHEN ND.DATA_TYPE IN ('NTI', 'NTIH') THEN ' (N)'
									WHEN ND.DATA_TYPE IN ('NSS', 'NSSH') THEN ' (S)'
									WHEN ND.DATA_TYPE IN ('NHI', 'NHIH') THEN ' (C)'
									END,
		[ProgramName] = NA.[PROGRAM_NAME],
		[Duration] = NA.PROGRAM_TOTAL_DURATION,
		ND.MARKET_BREAK_ID,
		AdjustedDateTime = CAST(CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < 360 THEN 
								CONVERT(char(10), DATEADD(dd, -1, AUDIENCE_DATETIME), 101)
							ELSE CONVERT(char(10), AUDIENCE_DATETIME, 101)
							END as SMALLDATETIME),
		AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), AUDIENCE_DATETIME, 101), AUDIENCE_DATETIME) < 360 THEN 
							CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) + 2400
						ELSE CAST(LEFT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), AUDIENCE_DATETIME, 108),2) as smallint)
						END,
		ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END,
		[yyyymm] = (SELECT YYYYMM FROM @BROADCAST_DATE_TYPE WHERE AUDIENCE_DATETIME BETWEEN StartDate AND EndDate)
	FROM dbo.NATIONAL_DATA ND
		INNER JOIN dbo.NATIONAL_AUDIENCE NA ON ND.NATIONAL_DATA_ID = NA.NATIONAL_DATA_ID 
        INNER JOIN dbo.advtf_national_data_ordered(@CLIENT_CODE) NDO ON NA.NATIONAL_DATA_ID = NDO.NATIONAL_DATA_ID 
        INNER JOIN (
                    SELECT CODE, VENUE_CODE
                    FROM dbo.NATIONAL_NETWORK 
                    WHERE NATIONAL_NETWORK_ID IN (select items from [udf_split_list_int](@NATIONAL_NETWORK_IDS,','))
                    ) NN ON NA.NETWORK = NN.CODE AND NA.VENUE_CODE = NN.VENUE_CODE 
	WHERE
		NA.TOTAL_PROGRAM_INDICATOR <> 'PP'
	AND	NA.TIME_TYPE = @TIME_TYPE 
	AND NA.AUDIENCE_DATETIME BETWEEN DATEADD(dd, -2, @STARTDATE) AND DATEADD(dd, 2, @ENDDATE)
	AND (
		(@MON = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '1000000')
	OR	(@TUE = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0100000')
	OR	(@WED = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0010000')
	OR	(@THU = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0001000')
	OR	(@FRI = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0000100')
	OR	(@SAT = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0000010')
	OR	(@SUN = 1 AND NA.DAYS_OF_WEEK_INDICATOR = '0000001')
		)
	AND	(
		(@BREAKOUT_FLAG = 'I')
	OR	(@BREAKOUT_FLAG = 'O' AND NA.IS_BREAKOUT = 1)
	OR	(@BREAKOUT_FLAG = 'E' AND NA.IS_BREAKOUT = 0)
		)
	AND	(
		(@REPEAT_FLAG = 'I')
	OR	(@REPEAT_FLAG = 'O' AND NA.IS_REPEAT = 1)
	OR	(@REPEAT_FLAG = 'E' AND NA.IS_REPEAT = 0)
		)
	AND	(
		(@SPECIAL_FLAG = 'I')
	OR	(@SPECIAL_FLAG = 'O' AND NA.IS_SPECIAL = 1)
	OR	(@SPECIAL_FLAG = 'E' AND NA.IS_SPECIAL = 0)
		)
	AND	(
		(@PREMIERE_FLAG = 'I')
	OR	(@PREMIERE_FLAG = 'O' AND NA.IS_PREMIERE = 1)
	OR	(@PREMIERE_FLAG = 'E' AND NA.IS_PREMIERE = 0)
		)
	AND	(
		(@OVERNIGHT_FLAG = 'I')
	OR	(@OVERNIGHT_FLAG = 'O' AND ND.IS_PRELIMINARY = 1)
	OR	(@OVERNIGHT_FLAG = 'E' AND ND.IS_PRELIMINARY = 0)
		)
	AND	(
		(@CORRECTION_FLAG = 'I')
	OR	(@CORRECTION_FLAG = 'O' AND ND.IS_CORRECTION = 1)
	OR	(@CORRECTION_FLAG = 'E' AND ND.IS_CORRECTION = 0)
		)
	AND ND.STREAM = @STREAM
	--TAKEOUT
	--AND NA.[PROGRAM_NAME] LIKE 'LATE LATE SHOW- J. CORDEN%'
	) details
WHERE
	AdjustedDateTime BETWEEN @STARTDATE AND @ENDDATE
AND	AdjustedHour >= @STARTHOUR 
AND AdjustedHour < @ENDHOUR

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #TRPT'
	--SELECT * FROM #TRPT
END

CREATE TABLE #AUD (
	[nhh] bigint NOT NULL,
	[nf2-5] bigint NOT NULL,
	[nf6-8] bigint NOT NULL,
	[nf9-11] bigint NOT NULL,
	[nf12-14] bigint NOT NULL,
	[nf15-17] bigint NOT NULL,
	[nf18-20] bigint NOT NULL,
	[nf21-24] bigint NOT NULL,
	[nf25-29] bigint NOT NULL,
	[nf30-34] bigint NOT NULL,
	[nf35-39] bigint NOT NULL,
	[nf40-44] bigint NOT NULL,
	[nf45-49] bigint NOT NULL,
	[nf50-54] bigint NOT NULL,
	[nf55-64] bigint NOT NULL,
	[nf65P] bigint NOT NULL,
	[nm2-5] bigint NOT NULL,
	[nm6-8] bigint NOT NULL,
	[nm9-11] bigint NOT NULL,
	[nm12-14] bigint NOT NULL,
	[nm15-17] bigint NOT NULL,
	[nm18-20] bigint NOT NULL,
	[nm21-24] bigint NOT NULL,
	[nm25-29] bigint NOT NULL,
	[nm30-34] bigint NOT NULL,
	[nm35-39] bigint NOT NULL,
	[nm40-44] bigint NOT NULL,
	[nm45-49] bigint NOT NULL,
	[nm50-54] bigint NOT NULL,
	[nm55-64] bigint NOT NULL,
	[nm65P] bigint NOT NULL,
	[ww18-20] bigint NOT NULL,
	[ww21-24] bigint NOT NULL,
	[ww25-34] bigint NOT NULL,
	[ww35-44] bigint NOT NULL,
	[ww45-49] bigint NOT NULL,
	[ww50-54] bigint NOT NULL,
	[ww55P] bigint NOT NULL,
	NATIONAL_AUDIENCE_ID bigint NOT NULL,
	[Network] varchar(10) NOT NULL,
	[ProgramName] varchar(25) NOT NULL,
	[Year] int NOT NULL,
	ProgramType varchar(2) NOT NULL,
	[yyyymm] char(6) NOT NULL
)

INSERT INTO #AUD
SELECT
	[nhh] = CAST(NA.HOUSEHOLD_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf2-5] = CAST(NA.FEMALES_2TO5_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf6-8] = CAST(NA.FEMALES_6TO8_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf9-11] = CAST(NA.FEMALES_9TO11_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf12-14] = CAST(NA.FEMALES_12TO14_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf15-17] = CAST(NA.FEMALES_15TO17_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf18-20] = CAST(NA.FEMALES_18TO20_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf21-24] = CAST(NA.FEMALES_21TO24_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf25-29] = CAST(NA.FEMALES_25TO29_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf30-34] = CAST(NA.FEMALES_30TO34_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf35-39] = CAST(NA.FEMALES_35TO39_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf40-44] = CAST(NA.FEMALES_40TO44_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf45-49] = CAST(NA.FEMALES_45TO49_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf50-54] = CAST(NA.FEMALES_50TO54_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf55-64] = CAST(NA.FEMALES_55TO64_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf65P] = CAST(NA.FEMALES_65PLUS_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm2-5] = CAST(NA.MALES_2TO5_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm6-8] = CAST(NA.MALES_6TO8_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm9-11] = CAST(NA.MALES_9TO11_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm12-14] = CAST(NA.MALES_12TO14_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm15-17] = CAST(NA.MALES_15TO17_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm18-20] = CAST(NA.MALES_18TO20_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm21-24] = CAST(NA.MALES_21TO24_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm25-29] = CAST(NA.MALES_25TO29_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm30-34] = CAST(NA.MALES_30TO34_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm35-39] = CAST(NA.MALES_35TO39_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm40-44] = CAST(NA.MALES_40TO44_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm45-49] = CAST(NA.MALES_45TO49_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm50-54] = CAST(NA.MALES_50TO54_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm55-64] = CAST(NA.MALES_55TO64_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm65P] = CAST(NA.MALES_65PLUS_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww18-20] = CAST(NA.WORKING_WOMEN_18TO20_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww21-24] = CAST(NA.WORKING_WOMEN_21TO24_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww25-34] = CAST(NA.WORKING_WOMEN_25TO34_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww35-44] = CAST(NA.WORKING_WOMEN_35TO44_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww45-49] = CAST(NA.WORKING_WOMEN_45TO49_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww50-54] = CAST(NA.WORKING_WOMEN_50TO54_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww55P] = CAST(NA.WORKING_WOMEN_55PLUS_AUD as bigint) * NA.PROGRAM_TOTAL_DURATION,
	NA.NATIONAL_AUDIENCE_ID,
	[Network],
	[ProgramName],
	[Year] = (SELECT [YEAR] FROM dbo.NATIONAL_YEAR WHERE AdjustedDateTime BETWEEN [START_DATE] AND END_DATE),
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END,
	[yyyymm]
FROM #TRPT t
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON t.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #AUD'
	--SELECT * FROM #AUD
END

CREATE NONCLUSTERED INDEX [IDX] ON #AUD
(
	ProgramName ASC, Network ASC, ProgramType ASC
)
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after create IDX #AUD'
	--SELECT * FROM #AUD
END
INSERT INTO #RESULT ( [Network], [ProgramName], ProgramType, Airings, [MediaDemoID], [Demographic], DemographicOrder,
	tot_dur,
	tot_aud,
	tot_ue,
	tot_hut,
	tot_put,
	[yyyymm])
SELECT Network, ProgramName, ProgramType, (SELECT COUNT(1) FROM #AUD aa WHERE a.Network = aa.Network and a.ProgramName = aa.ProgramName and a.ProgramType = aa.ProgramType), MSNRDT.MediaDemoID, MDT.[Description], MSNRDT.[Order],
	tot_dur = 0,
	tot_aud = SUM(AUD),
	tot_ue = 0,
	tot_hut = 0,
	tot_put = 0,
	[yyyymm]
FROM #AUD b
UNPIVOT
	(
		AUD
		FOR NIELSEN_DEMO_CODE in ([nhh],[nf2-5],[nf6-8],[nf9-11],[nf12-14],[nf15-17],[nf18-20],[nf21-24],[nf25-29],[nf30-34],[nf35-39],[nf40-44],[nf45-49],[nf50-54],
				[nf55-64],[nf65P],[nm2-5],[nm6-8],[nm9-11],[nm12-14],[nm15-17],[nm18-20],[nm21-24],[nm25-29],[nm30-34],[nm35-39],[nm40-44],[nm45-49],[nm50-54],[nm55-64],
				[nm65P],[ww18-20],[ww21-24],[ww25-34],[ww35-44],[ww45-49],[ww50-54],[ww55P]) 
	) a
	INNER JOIN dbo.NIELSEN_DEMO ND ON a.NIELSEN_DEMO_CODE = ND.CODE 
	INNER JOIN @LOCAL_MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID 
	INNER JOIN @LOCAL_MEDIA_DEMO_TYPE MDT ON MDT.ID = MDDT.MediaDemographicID 
	INNER JOIN @LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE MSNRDT ON MSNRDT.MediaDemoID = MDT.ID 
GROUP BY Network, ProgramName, ProgramType, MSNRDT.MediaDemoID, MDT.[Description], MSNRDT.[Order], [yyyymm]

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #RESULT'
	--SELECT * FROM #RESULT
END

CREATE NONCLUSTERED INDEX [IDX] ON #RESULT
(
	ProgramName ASC, ProgramType ASC, Network ASC, MediaDemoID ASC, [yyyymm] ASC
)

UPDATE R SET tot_dur = T.tot_dur
FROM #RESULT R
	INNER JOIN (
				SELECT SUM(Duration) as tot_dur, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType, [yyyymm] COLLATE SQL_Latin1_General_CP1_CS_AS as [yyyymm]
				FROM #TRPT
				GROUP BY Network, ProgramName, ProgramType, [yyyymm]) T ON R.Network = T.Network AND R.ProgramName = T.ProgramName AND R.ProgramType = T.ProgramType AND R.[yyyymm] = T.[yyyymm]
	
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update tot_dur'
	--SELECT * FROM #RESULT
END

DECLARE @PUT TABLE (
	[nhh] bigint NOT NULL,
	[nf2-5] bigint NOT NULL,
	[nf6-8] bigint NOT NULL,
	[nf9-11] bigint NOT NULL,
	[nf12-14] bigint NOT NULL,
	[nf15-17] bigint NOT NULL,
	[nf18-20] bigint NOT NULL,
	[nf21-24] bigint NOT NULL,
	[nf25-29] bigint NOT NULL,
	[nf30-34] bigint NOT NULL,
	[nf35-39] bigint NOT NULL,
	[nf40-44] bigint NOT NULL,
	[nf45-49] bigint NOT NULL,
	[nf50-54] bigint NOT NULL,
	[nf55-64] bigint NOT NULL,
	[nf65P] bigint NOT NULL,
	[nm2-5] bigint NOT NULL,
	[nm6-8] bigint NOT NULL,
	[nm9-11] bigint NOT NULL,
	[nm12-14] bigint NOT NULL,
	[nm15-17] bigint NOT NULL,
	[nm18-20] bigint NOT NULL,
	[nm21-24] bigint NOT NULL,
	[nm25-29] bigint NOT NULL,
	[nm30-34] bigint NOT NULL,
	[nm35-39] bigint NOT NULL,
	[nm40-44] bigint NOT NULL,
	[nm45-49] bigint NOT NULL,
	[nm50-54] bigint NOT NULL,
	[nm55-64] bigint NOT NULL,
	[nm65P] bigint NOT NULL,
	[ww18-20] bigint NOT NULL,
	[ww21-24] bigint NOT NULL,
	[ww25-34] bigint NOT NULL,
	[ww35-44] bigint NOT NULL,
	[ww45-49] bigint NOT NULL,
	[ww50-54] bigint NOT NULL,
	[ww55P] bigint NOT NULL,
	NATIONAL_AUDIENCE_ID bigint NOT NULL,
	[Network] varchar(10) NOT NULL,
	[ProgramName] varchar(25) NOT NULL,
	ProgramType varchar(2) NOT NULL,
	[yyyymm] char(6) NOT NULL
)

INSERT INTO @PUT
SELECT
	[nhh] = CAST(NA.PROGRAM_HUT as bigint) * NA.PROGRAM_TOTAL_DURATION ,
	[nf2-5] = CAST(NA.FEMALES_2TO5_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf6-8] = CAST(NA.FEMALES_6TO8_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf9-11] = CAST(NA.FEMALES_9TO11_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf12-14] = CAST(NA.FEMALES_12TO14_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf15-17] = CAST(NA.FEMALES_15TO17_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf18-20] = CAST(NA.FEMALES_18TO20_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf21-24] = CAST(NA.FEMALES_21TO24_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf25-29] = CAST(NA.FEMALES_25TO29_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf30-34] = CAST(NA.FEMALES_30TO34_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf35-39] = CAST(NA.FEMALES_35TO39_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf40-44] = CAST(NA.FEMALES_40TO44_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf45-49] = CAST(NA.FEMALES_45TO49_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf50-54] = CAST(NA.FEMALES_50TO54_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf55-64] = CAST(NA.FEMALES_55TO64_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf65P] = CAST(NA.FEMALES_65PLUS_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm2-5] = CAST(NA.MALES_2TO5_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm6-8] = CAST(NA.MALES_6TO8_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm9-11] = CAST(NA.MALES_9TO11_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm12-14] = CAST(NA.MALES_12TO14_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm15-17] = CAST(NA.MALES_15TO17_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm18-20] = CAST(NA.MALES_18TO20_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm21-24] = CAST(NA.MALES_21TO24_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm25-29] = CAST(NA.MALES_25TO29_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm30-34] = CAST(NA.MALES_30TO34_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm35-39] = CAST(NA.MALES_35TO39_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm40-44] = CAST(NA.MALES_40TO44_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm45-49] = CAST(NA.MALES_45TO49_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm50-54] = CAST(NA.MALES_50TO54_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm55-64] = CAST(NA.MALES_55TO64_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm65P] = CAST(NA.MALES_65PLUS_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww18-20] = CAST(NA.WORKING_WOMEN_18TO20_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww21-24] = CAST(NA.WORKING_WOMEN_21TO24_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww25-34] = CAST(NA.WORKING_WOMEN_25TO34_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww35-44] = CAST(NA.WORKING_WOMEN_35TO44_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww45-49] = CAST(NA.WORKING_WOMEN_45TO49_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww50-54] = CAST(NA.WORKING_WOMEN_50TO54_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww55P] = CAST(NA.WORKING_WOMEN_55PLUS_PUT as bigint) * NA.PROGRAM_TOTAL_DURATION,
	NA.NATIONAL_AUDIENCE_ID,
	[Network],
	[ProgramName],
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END,
	[yyyymm]
FROM #TRPT t
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON t.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load @PUT'
	--SELECT * FROM @PUT
END

UPDATE R SET tot_put = PUT.TOT_PUT 
FROM #RESULT R INNER JOIN 
	(
	SELECT SUM(PUT) AS TOT_PUT, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, MDDT.MediaDemographicID, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType, [yyyymm] COLLATE SQL_Latin1_General_CP1_CS_AS as [yyyymm]
	FROM @PUT
	UNPIVOT
		(
			PUT
			FOR NIELSEN_DEMO_CODE in ([nhh],[nf2-5],[nf6-8],[nf9-11],[nf12-14],[nf15-17],[nf18-20],[nf21-24],[nf25-29],[nf30-34],[nf35-39],[nf40-44],[nf45-49],[nf50-54],
					[nf55-64],[nf65P],[nm2-5],[nm6-8],[nm9-11],[nm12-14],[nm15-17],[nm18-20],[nm21-24],[nm25-29],[nm30-34],[nm35-39],[nm40-44],[nm45-49],[nm50-54],[nm55-64],
					[nm65P],[ww18-20],[ww21-24],[ww25-34],[ww35-44],[ww45-49],[ww50-54],[ww55P]) 
		) a
		INNER JOIN dbo.NIELSEN_DEMO ND ON a.NIELSEN_DEMO_CODE = ND.CODE 
		INNER JOIN @LOCAL_MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID 
	GROUP BY Network, ProgramName, ProgramType, MDDT.MediaDemographicID, [yyyymm]
	) PUT ON R.Network = PUT.Network AND R.ProgramName = PUT.ProgramName AND R.MediaDemoID = PUT.MediaDemographicID AND R.ProgramType = PUT.ProgramType AND PUT.[yyyymm] = R.[yyyymm]

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update TOT_PUT'
END

DECLARE @UE TABLE (
	[nhh] bigint NOT NULL,
	[nf2-5] bigint NOT NULL,
	[nf6-8] bigint NOT NULL,
	[nf9-11] bigint NOT NULL,
	[nf12-14] bigint NOT NULL,
	[nf15-17] bigint NOT NULL,
	[nf18-20] bigint NOT NULL,
	[nf21-24] bigint NOT NULL,
	[nf25-29] bigint NOT NULL,
	[nf30-34] bigint NOT NULL,
	[nf35-39] bigint NOT NULL,
	[nf40-44] bigint NOT NULL,
	[nf45-49] bigint NOT NULL,
	[nf50-54] bigint NOT NULL,
	[nf55-64] bigint NOT NULL,
	[nf65P] bigint NOT NULL,
	[nm2-5] bigint NOT NULL,
	[nm6-8] bigint NOT NULL,
	[nm9-11] bigint NOT NULL,
	[nm12-14] bigint NOT NULL,
	[nm15-17] bigint NOT NULL,
	[nm18-20] bigint NOT NULL,
	[nm21-24] bigint NOT NULL,
	[nm25-29] bigint NOT NULL,
	[nm30-34] bigint NOT NULL,
	[nm35-39] bigint NOT NULL,
	[nm40-44] bigint NOT NULL,
	[nm45-49] bigint NOT NULL,
	[nm50-54] bigint NOT NULL,
	[nm55-64] bigint NOT NULL,
	[nm65P] bigint NOT NULL,
	[ww18-20] bigint NOT NULL,
	[ww21-24] bigint NOT NULL,
	[ww25-34] bigint NOT NULL,
	[ww35-44] bigint NOT NULL,
	[ww45-49] bigint NOT NULL,
	[ww50-54] bigint NOT NULL,
	[ww55P] bigint NOT NULL,
	NATIONAL_AUDIENCE_ID bigint NOT NULL,
	[Network] varchar(10) NOT NULL,
	[ProgramName] varchar(25) NOT NULL,
	ProgramType varchar(2) NOT NULL,
	[yyyymm] char(6)
)

INSERT INTO @UE 
SELECT
	[nhh] = CAST(NUT.Household as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf2-5] = CAST(NUT.Females2to5 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf6-8] = CAST(NUT.Females6to8 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf9-11] = CAST(NUT.Females9to11 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf12-14] = CAST(NUT.Females12to14 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf15-17] = CAST(NUT.Females15to17 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf18-20] = CAST(NUT.Females18to20 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf21-24] = CAST(NUT.Females21to24 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf25-29] = CAST(NUT.Females25to29 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf30-34] = CAST(NUT.Females30to34 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf35-39] = CAST(NUT.Females35to39 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf40-44] = CAST(NUT.Females40to44 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf45-49] = CAST(NUT.Females45to49 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf50-54] = CAST(NUT.Females50to54 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf55-64] = CAST(NUT.Females55to64 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nf65P] = CAST(NUT.Females65Plus as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm2-5] = CAST(NUT.Males2to5 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm6-8] = CAST(NUT.Males6to8 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm9-11] = CAST(NUT.Males9to11 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm12-14] = CAST(NUT.Males12to14 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm15-17] = CAST(NUT.Males15to17 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm18-20] = CAST(NUT.Males18to20 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm21-24] = CAST(NUT.Males21to24 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm25-29] = CAST(NUT.Males25to29 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm30-34] = CAST(NUT.Males30to34 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm35-39] = CAST(NUT.Males35to39 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm40-44] = CAST(NUT.Males40to44 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm45-49] = CAST(NUT.Males45to49 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm50-54] = CAST(NUT.Males50to54 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm55-64] = CAST(NUT.Males55to64 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[nm65P] = CAST(NUT.Males65Plus as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww18-20] = CAST(NUT.WorkingWomen18to20 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww21-24] = CAST(NUT.WorkingWomen21to24 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww25-34] = CAST(NUT.WorkingWomen25to34 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww35-44] = CAST(NUT.WorkingWomen35to44 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww45-49] = CAST(NUT.WorkingWomen45to49 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww50-54] = CAST(NUT.WorkingWomen50to54 as bigint) * NA.PROGRAM_TOTAL_DURATION,
	[ww55P] = CAST(NUT.WorkingWomen55Plus as bigint) * NA.PROGRAM_TOTAL_DURATION,
	a.NATIONAL_AUDIENCE_ID,
	[Network],
	[ProgramName],
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END,
	[yyyymm]
FROM #AUD a
	INNER JOIN @NATIONAL_UNIVERSE_TYPE NUT ON a.[Year] = NUT.[Year] 
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON a.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load @UE'
	--SELECT * FROM @UE
END

UPDATE R SET tot_ue = UE.TOT_UE
FROM #RESULT R INNER JOIN 
	(
	SELECT SUM(UE) AS TOT_UE, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, MDDT.MediaDemographicID, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType, [yyyymm] COLLATE SQL_Latin1_General_CP1_CS_AS as [yyyymm]
	FROM @UE
	UNPIVOT
		(
			UE
			FOR NIELSEN_DEMO_CODE in ([nhh],[nf2-5],[nf6-8],[nf9-11],[nf12-14],[nf15-17],[nf18-20],[nf21-24],[nf25-29],[nf30-34],[nf35-39],[nf40-44],[nf45-49],[nf50-54],
					[nf55-64],[nf65P],[nm2-5],[nm6-8],[nm9-11],[nm12-14],[nm15-17],[nm18-20],[nm21-24],[nm25-29],[nm30-34],[nm35-39],[nm40-44],[nm45-49],[nm50-54],[nm55-64],
					[nm65P],[ww18-20],[ww21-24],[ww25-34],[ww35-44],[ww45-49],[ww50-54],[ww55P]) 
		) a
		INNER JOIN dbo.NIELSEN_DEMO ND ON a.NIELSEN_DEMO_CODE = ND.CODE 
		INNER JOIN @LOCAL_MEDIA_DEMO_DETAIL_TYPE MDDT ON MDDT.NielsenDemographicID = ND.NIELSEN_DEMO_ID 
	GROUP BY Network, ProgramName, ProgramType, MDDT.MediaDemographicID, [yyyymm]
	) UE  ON R.Network = UE.Network AND R.ProgramName = UE.ProgramName AND R.MediaDemoID = UE.MediaDemographicID AND R.ProgramType = UE.ProgramType AND R.[yyyymm] = UE.[yyyymm]
	
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update TOT_UE'
	select * from #RESULT
END

SELECT Network, ProgramName, ProgramType, MediaDemoID, Demographic, DemographicOrder, 
	TotalDuration = SUM(tot_dur),
	HPUT = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_put) as decimal)/CAST(SUM(tot_dur) as decimal) END/1000,
	HPUTPercent = 100 * CASE WHEN SUM(tot_dur) = 0 OR SUM(tot_ue) = 0 THEN 0 ELSE CAST(SUM(tot_put) as decimal)/CAST(SUM(tot_ue) as decimal) END,
	Impressions = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_aud) as decimal)/CAST(SUM(tot_dur) as decimal)/1000 END,
	Rating = 100 * CASE WHEN SUM(tot_ue) = 0 THEN 0 ELSE CAST(SUM(tot_aud) as decimal)/CAST(SUM(tot_ue) as decimal) END,
	--Share in class
	VPVH = CAST(0 AS int),
	Universe = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_ue) as decimal)/CAST(SUM(tot_dur) as decimal)/1000 END,
	HouseholdAdded = @HH_ADDED,
	Airings= SUM(Airings),
	[yyyymm]
INTO #OUTPUT
FROM #RESULT
GROUP BY Network, ProgramName, ProgramType, MediaDemoID, Demographic, DemographicOrder, [yyyymm]

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #OUTPUT'
	select * from #OUTPUT
END

UPDATE O SET VPVH = CASE WHEN OHH.Impressions <> 0 THEN ROUND(O.Impressions * 1000 / OHH.Impressions, 0) ELSE 0 END
FROM #OUTPUT O
	INNER JOIN #OUTPUT OHH ON O.Network = OHH.Network AND O.ProgramName = OHH.ProgramName AND OHH.MediaDemoID = 97 AND O.ProgramType = OHH.ProgramType AND OHH.[yyyymm] = O.[yyyymm]
WHERE O.MediaDemoID <> 97

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update #OUTPUT'
END

IF @HH_ADDED = 1
	DELETE #OUTPUT WHERE MediaDemoID = 97
	
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after delete #OUTPUT'
END

ALTER TABLE #OUTPUT ALTER COLUMN ProgramType varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS

SELECT
	Network, ProgramName, 
	ProgramType = CASE WHEN PT.[NAME] IS NULL THEN O.ProgramType ELSE PT.[NAME] END COLLATE SQL_Latin1_General_CP1_CS_AS,
	--MediaDemoID, 
	--Demographic, 
	--DemographicOrder, 
	--TotalDuration,
	HPUT,
	HPUTPercent,
	Impressions,
	Rating,
	Share = CASE WHEN HPUT = 0 THEN 0 ELSE Impressions * 100 / HPUT END,
	VPVH,
	Universe,
	--HouseholdAdded,
	Airings,
	YYYYMM = CAST([yyyymm] as int)
INTO #COMPLETE
FROM #OUTPUT O
	LEFT OUTER JOIN dbo.PROGRAM_TYPE PT ON O.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS = PT.CODE COLLATE SQL_Latin1_General_CP1_CS_AS

DECLARE @cols	AS NVARCHAR(MAX),
		@query	AS NVARCHAR(MAX),
		@cols_as AS NVARCHAR(MAX)

select @cols = STUFF((SELECT ',' + QUOTENAME(YYYYMM) 
                    from #COMPLETE
                    group by YYYYMM
					order by YYYYMM
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
--select @cols
select @cols_as = STUFF((SELECT ',SUM(' + QUOTENAME(YYYYMM) + ') as ' + QUOTENAME(YYYYMM)
                    from #COMPLETE
                    group by YYYYMM
					order by YYYYMM
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
--select @cols_as 
set @query = 'SELECT Network, ProgramName ' + CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN ', ProgramType' ELSE '' END + CASE WHEN @SHOW_AIRINGS = 1 THEN ', Airings' ELSE '' END + ',' + @cols_as + N' from 
             (
                select *
                from #COMPLETE
            ) x
            pivot 
            (
                max(' + @SELECTED_METRIC + ')
                for YYYYMM in (' + @cols + N')
            ) p 
			group by Network, ProgramName ' + CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN ', ProgramType' ELSE '' END + CASE WHEN @SHOW_AIRINGS = 1 THEN ', Airings' ELSE '' END

exec sp_executesql @query;

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'DONE'
END

GO

