CREATE PROCEDURE [dbo].[advsp_national_research_program_ranker]
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
	@RANK_METRIC varchar(30),
	@MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE READONLY, 
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY,
	@MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE READONLY,
	@NATIONAL_UNIVERSE_TYPE dbo.NATIONAL_UNIVERSE_TYPE READONLY,
	@MEDIA_METRIC_TYPE dbo.MEDIA_METRIC_TYPE READONLY,
	@DEBUG bit = 0
AS
/*
declare @MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE
insert into @MEDIA_DEMO_TYPE values(136,N'Adults 18-49')
insert into @MEDIA_DEMO_TYPE values(98,N'Women 2-5')
insert into @MEDIA_DEMO_TYPE values(113,N'Men 2-5')

declare @MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE
insert into @MEDIA_DEMO_DETAIL_TYPE values(98,45)
insert into @MEDIA_DEMO_DETAIL_TYPE values(113,60)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,50)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,65)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,51)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,66)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,52)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,67)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,53)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,68)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,54)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,69)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,55)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,70)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,56)
insert into @MEDIA_DEMO_DETAIL_TYPE values(136,71)

declare @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE
insert into @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE values(136,1)
insert into @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE values(98,2)
insert into @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE values(113,3)

declare @NATIONAL_UNIVERSE_TYPE dbo.NATIONAL_UNIVERSE_TYPE
insert into @NATIONAL_UNIVERSE_TYPE values(2020,0,1,120600000,7660000,5760000,5950000,5950000,6060000,6250000,7900000,10110000,10610000,10270000,9940000,10010000,10420000,21250000,28960000,8010000,6020000,6210000,6200000,6270000,6400000,8080000,10170000,10540000,10020000,9580000,9590000,9900000,19650000,23560000,1410000,3830000,12950000,12700000,6650000,6450000,13030000)

declare @MEDIA_METRIC_TYPE dbo.MEDIA_METRIC_TYPE
insert into @MEDIA_METRIC_TYPE values ('Rating', 1)
insert into @MEDIA_METRIC_TYPE values ('Impressions', 2)
insert into @MEDIA_METRIC_TYPE values ('Share', 3)

declare @TIME_TYPE char(1),
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
	@RANK_METRIC varchar(30),
	@DEBUG bit
set @DEBUG = 0

set @TIME_TYPE='P'
set @NATIONAL_NETWORK_IDS='1'--,4,9,16'
set @STARTDATE='2020-01-06 00:00:00'
set @ENDDATE='2020-05-08 00:00:00'
set @STARTHOUR=600
set @ENDHOUR=2959
set @MON=1
set @TUE=1
set @WED=1
set @THU=1
set @FRI=1
set @SAT=1
set @SUN=1
set @BREAKOUT_FLAG='I'
set @REPEAT_FLAG='I'
set @SPECIAL_FLAG='I'
set @PREMIERE_FLAG='I'
set @OVERNIGHT_FLAG='I'
set @CORRECTION_FLAG='I'
set @STREAM='L3'
set @SHOW_PROGRAM_TYPES=0
set @SHOW_AIRINGS=0
set @RANK_METRIC='Rating'

drop table #RESULT
drop table #TRPT
drop table #OUTPUT
drop table #COMPLETE
drop table #FINAL
*/
DECLARE	@HH_ADDED bit,
		@LOCAL_MEDIA_DEMO_TYPE dbo.MEDIA_DEMO_TYPE, 
		@LOCAL_MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE,
		@LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE,
		@LOCAL_MEDIA_METRIC_TYPE dbo.MEDIA_METRIC_TYPE,
		@ORDER smallint,
		@SQL nvarchar(MAX),
		@ORDER_STR char(3),
		@COLS nvarchar(max),
		@TMP_COLS nvarchar(max)

INSERT INTO @LOCAL_MEDIA_DEMO_TYPE
SELECT * FROM @MEDIA_DEMO_TYPE

INSERT INTO @LOCAL_MEDIA_DEMO_DETAIL_TYPE
SELECT * FROM @MEDIA_DEMO_DETAIL_TYPE

INSERT INTO @LOCAL_MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE
SELECT * FROM @MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE

INSERT INTO @LOCAL_MEDIA_METRIC_TYPE
SELECT * FROM @MEDIA_METRIC_TYPE

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
	tot_put				bigint NOT NULL
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
		ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END
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
	SELECT * FROM #TRPT
END

DECLARE @AUD TABLE (
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
	ProgramType varchar(2) NOT NULL
)

INSERT INTO @AUD
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
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END
FROM #TRPT t
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON t.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load @AUD'
	SELECT * FROM @AUD
END

INSERT INTO #RESULT ( [Network], [ProgramName], ProgramType, Airings, [MediaDemoID], [Demographic], DemographicOrder,
	tot_dur,
	tot_aud,
	tot_ue,
	tot_hut,
	tot_put)
SELECT Network, ProgramName, ProgramType, (SELECT COUNT(1) FROM @AUD aa WHERE a.Network = aa.Network and a.ProgramName = aa.ProgramName), MSNRDT.MediaDemoID, MDT.[Description], MSNRDT.[Order],
	tot_dur = 0,
	tot_aud = SUM(AUD),
	tot_ue = 0,
	tot_hut = 0,
	tot_put = 0
FROM @AUD b
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
GROUP BY Network, ProgramName, ProgramType, MSNRDT.MediaDemoID, MDT.[Description], MSNRDT.[Order]

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #RESULT'
	SELECT * FROM #RESULT
END

CREATE NONCLUSTERED INDEX [IDX] ON #RESULT
(
	ProgramName ASC, ProgramType ASC, Network ASC, MediaDemoID ASC
)

UPDATE R SET tot_dur = T.tot_dur
FROM #RESULT R
	INNER JOIN (
				SELECT SUM(Duration) as tot_dur, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType
				FROM #TRPT
				GROUP BY Network, ProgramName, ProgramType) T ON R.Network = T.Network AND R.ProgramName = T.ProgramName AND R.ProgramType = T.ProgramType
	
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update tot_dur'
	SELECT * FROM #RESULT
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
	ProgramType varchar(2) NOT NULL
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
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END
FROM #TRPT t
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON t.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load @PUT'
	--SELECT * FROM @PUT
END

UPDATE R SET tot_put = PUT.TOT_PUT 
FROM #RESULT R INNER JOIN 
	(
	SELECT SUM(PUT) AS TOT_PUT, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, MDDT.MediaDemographicID, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType
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
	GROUP BY Network, ProgramName, ProgramType, MDDT.MediaDemographicID 
	) PUT ON R.Network = PUT.Network AND R.ProgramName = PUT.ProgramName AND R.MediaDemoID = PUT.MediaDemographicID AND R.ProgramType = PUT.ProgramType

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
	ProgramType varchar(2) NOT NULL
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
	ProgramType = CASE WHEN @SHOW_PROGRAM_TYPES = 1 THEN NA.PROGRAM_TYPE ELSE '' END
FROM @AUD a
	INNER JOIN @NATIONAL_UNIVERSE_TYPE NUT ON a.[Year] = NUT.[Year] 
	INNER JOIN dbo.NATIONAL_AUDIENCE NA ON a.NATIONAL_AUDIENCE_ID = NA.NATIONAL_AUDIENCE_ID 

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load @UE'
	SELECT * FROM @UE
END

UPDATE R SET tot_ue = UE.TOT_UE
FROM #RESULT R INNER JOIN 
	(
	SELECT SUM(UE) AS TOT_UE, Network COLLATE SQL_Latin1_General_CP1_CS_AS as Network, ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramName, MDDT.MediaDemographicID, ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS as ProgramType
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
	GROUP BY Network, ProgramName, ProgramType, MDDT.MediaDemographicID 
	) UE  ON R.Network = UE.Network AND R.ProgramName = UE.ProgramName AND R.MediaDemoID = UE.MediaDemographicID AND R.ProgramType = UE.ProgramType
	
IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after update TOT_UE'
	select * from #RESULT
END

SELECT Network, ProgramName, ProgramType, MediaDemoID, Demographic, DemographicOrder, 
	HPUT = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_put) as decimal)/CAST(SUM(tot_dur) as decimal) END/1000,
	HPUTPercent = 100 * CASE WHEN SUM(tot_dur) = 0 OR SUM(tot_ue) = 0 THEN 0 ELSE CAST(SUM(tot_put) as decimal)/CAST(SUM(tot_ue) as decimal) END,
	Impressions = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_aud) as decimal)/CAST(SUM(tot_dur) as decimal)/1000 END,
	Rating = 100 * CASE WHEN SUM(tot_ue) = 0 THEN 0 ELSE CAST(SUM(tot_aud) as decimal)/CAST(SUM(tot_ue) as decimal) END,
	VPVH = CAST(0 AS int),
	Universe = CASE WHEN SUM(tot_dur) = 0 THEN 0 ELSE CAST(SUM(tot_ue) as decimal)/CAST(SUM(tot_dur) as decimal)/1000 END,
	HouseholdAdded = @HH_ADDED,
	Airings= SUM(Airings)
INTO #OUTPUT
FROM #RESULT
GROUP BY Network, ProgramName, ProgramType, MediaDemoID, Demographic, DemographicOrder

IF @DEBUG = 1 BEGIN
	SELECT GETDATE() as 'after load #OUTPUT'
	select * from #OUTPUT
END

UPDATE O SET VPVH = CASE WHEN OHH.Impressions <> 0 THEN ROUND(O.Impressions * 1000 / OHH.Impressions, 0) ELSE 0 END
FROM #OUTPUT O
	INNER JOIN #OUTPUT OHH ON O.Network = OHH.Network AND O.ProgramName = OHH.ProgramName AND OHH.MediaDemoID = 97 AND O.ProgramType = OHH.ProgramType
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
	ID = IDENTITY(INT,1,1),
	Network, ProgramName, 
	ProgramType = CASE WHEN PT.[NAME] IS NULL THEN O.ProgramType ELSE PT.[NAME] END COLLATE SQL_Latin1_General_CP1_CS_AS,
	MediaDemoID, 
	Demographic, 
	DemographicOrder, 
	HPUT = ROUND(HPUT,1),
	HPUTPercent = ROUND(HPUTPercent,2),
	Impressions = ROUND(Impressions,1),
	Rating = ROUND(Rating,2),
	Share = ROUND(CASE WHEN HPUT = 0 THEN 0 ELSE Impressions * 100 / HPUT END,2),
	VPVH = ROUND(VPVH,0),
	Universe = ROUND(Universe,1),
	Airings
INTO #COMPLETE
FROM #OUTPUT O
	LEFT OUTER JOIN dbo.PROGRAM_TYPE PT ON O.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS = PT.CODE COLLATE SQL_Latin1_General_CP1_CS_AS

CREATE TABLE #FINAL (
	Network varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProgramName varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProgramType varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	Airings int,
	Demographic1 varchar(50),
	Rank1 int,
	HPUT1 decimal(12,1),
	HPUTPercent1 decimal(12,2),
	Impressions1 decimal(12,1),
	Rating1 decimal(12,2),
	Share1 decimal(12,2),
	VPVH1 int,
	Universe1 decimal(12,1)	
)

SET @SQL = 'INSERT INTO #FINAL (Network, ProgramName, ProgramType) 
						 SELECT DISTINCT Network, ProgramName, ProgramType FROM #COMPLETE'
exec sp_sqlexec @SQL;

SET @SQL = 'UPDATE F SET Airings = dtl.Airings, Demographic1 = dtl.Demographic, HPUT1 = dtl.HPUT, HPUTPercent1 = dtl.HPUTPercent, 
				Impressions1 = dtl.Impressions, Rating1 = dtl.Rating, Share1 = dtl.Share, VPVH1 = dtl.VPVH, Universe1 = dtl.Universe, Rank1 = dtl.Rank
			FROM #FINAL F 
				INNER JOIN (
						 SELECT Network, ProgramName, ProgramType, Airings, Demographic, HPUT, HPUTPercent, Impressions, Rating, Share, VPVH, Universe, 
						 RANK() OVER (ORDER BY ' + @RANK_METRIC + ' DESC) Rank
						 FROM #COMPLETE WHERE DemographicOrder = 1
						 ) dtl ON F.Network COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.Network COLLATE SQL_Latin1_General_CP1_CS_AS 
							AND F.ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS
							AND F.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS'
exec sp_sqlexec @SQL;

select @COLS = '[Demographic],[Rank],' + STUFF((SELECT ',' + QUOTENAME([Description]) 
                    from @MEDIA_METRIC_TYPE
                    group by [Order], [Description]
					order by [Order]
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
select @COLS = REPLACE ( @COLS , ']' , '1]' ) 

SET @ORDER = 2
WHILE @ORDER <= (SELECT MAX([DemographicOrder]) FROM #COMPLETE)
BEGIN
	SET @ORDER_STR = CAST(@ORDER as char)

	select @TMP_COLS = '[Demographic],[Rank],' + STUFF((SELECT ',' + QUOTENAME([Description]) 
                    from @MEDIA_METRIC_TYPE
                    group by [Order], [Description]
					order by [Order]
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
	select @TMP_COLS = REPLACE ( @TMP_COLS , ']' ,  RTRIM(@ORDER_STR) + ']' ) 

	SET @COLS = @COLS + ',' + @TMP_COLS

	SET @SQL = 	'ALTER TABLE #FINAL ADD [Demographic' + @ORDER_STR + '] varchar(50) ' +
				'ALTER TABLE #FINAL ADD [Rank' + @ORDER_STR + '] int ' +
				'ALTER TABLE #FINAL ADD [HPUT' + @ORDER_STR + '] decimal(12,1) ' +
				'ALTER TABLE #FINAL ADD [HPUTPercent' + @ORDER_STR + '] decimal(12,2) ' +
				'ALTER TABLE #FINAL ADD [Impressions' + @ORDER_STR + '] decimal(12,1) ' +
				'ALTER TABLE #FINAL ADD [Rating' + @ORDER_STR + '] decimal(12,2) ' +
				'ALTER TABLE #FINAL ADD [Share' + @ORDER_STR + '] decimal(12,2) ' +
				'ALTER TABLE #FINAL ADD [VPVH' + @ORDER_STR + '] int ' +
				'ALTER TABLE #FINAL ADD [Universe' + @ORDER_STR + '] decimal(12,1) '
				
	exec sp_executesql @SQL;
	
	SET @SQL = 'UPDATE F SET Airings = dtl.Airings, Demographic' + @ORDER_STR + ' = dtl.Demographic, 
													HPUT' + @ORDER_STR + ' = dtl.HPUT, 
													HPUTPercent' + @ORDER_STR + ' = dtl.HPUTPercent,
													Impressions' + @ORDER_STR + ' = dtl.Impressions,
													Rating' + @ORDER_STR + ' = dtl.Rating, 
													Share' + @ORDER_STR + ' = dtl.Share, 
													VPVH' + @ORDER_STR + ' = dtl.VPVH, 
													Universe' + @ORDER_STR + ' = dtl.Universe, 
													Rank' + @ORDER_STR + ' = dtl.Rank
				FROM #FINAL F 
					INNER JOIN (
							 SELECT Network, ProgramName, ProgramType, Airings, Demographic, HPUT, HPUTPercent, Impressions, Rating, Share, VPVH, Universe, 
							 RANK() OVER (ORDER BY ' + @RANK_METRIC + ' DESC) Rank
							 FROM #COMPLETE WHERE DemographicOrder =  ' + @ORDER_STR + '
							 ) dtl ON F.Network COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.Network COLLATE SQL_Latin1_General_CP1_CS_AS 
								AND F.ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.ProgramName COLLATE SQL_Latin1_General_CP1_CS_AS
								AND F.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS = dtl.ProgramType COLLATE SQL_Latin1_General_CP1_CS_AS'
	exec sp_sqlexec @SQL;
	SET @ORDER = @ORDER + 1
END

SET @SQL = 'SELECT Network, ProgramName, ProgramType, Airings, ' + @COLS + 'FROM #FINAL ORDER BY Rank1'
exec sp_sqlexec @SQL;
GO
