IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_radio_audience_get_cume]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_nielsen_radio_audience_get_cume]
GO

CREATE FUNCTION [dbo].[advtf_nielsen_radio_audience_get_cume](
--declare
	@NIELSEN_RADIO_SEGMENT_PARENT_IDs varchar(max),
	@LISTENING_LOCATION char(1),
	@STATION_COMBO_TYPE smallint,
	@SelectedMediaDemographicIDs varchar(max),
	@MEDIA_DEMO_DETAIL_TYPE [dbo].[MEDIA_DEMO_DETAIL_TYPE] READONLY,
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY 
)
RETURNS
@RETURN_TABLE TABLE (
	[NIELSEN_DEMO_CODE] varchar(7) NOT NULL,
	[CUME] bigint NOT NULL,
	MEDIA_DEMO_ID int NOT NULL,
	NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
	NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
	[ID] int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
/*
	SET @NIELSEN_RADIO_SEGMENT_PARENT_IDs = '519'
		
	SET @LISTENING_LOCATION = '1' --total
	SET @STATION_COMBO_TYPE = 1 -- individual station
	
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,36)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,28)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,37)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,29)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,38)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,30)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,39)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,31)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,40)
	insert into @MEDIA_DEMO_DETAIL_TYPE values(45,32)
	
	set @SelectedMediaDemographicIDs = '45'
	
	insert into @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE values(1,1,1,1,1,1,0,0,N'05:00 AM',N'6:00 AM',500,600,N'M-F')
	insert into @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE values(2,1,1,1,1,1,0,0,N'10:00 AM',N'11:00 AM',1000,1100,N'M-F')
	--SELECT * FROM @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE
*/
	DECLARE @CUME_NUM_QHRS int,
			@REQUEST_NUM_QHRS int,
			@CUME_FACTOR decimal(5,4),
			@RNQ_COUNTER int

	DECLARE @covering_daypart TABLE (
		NIELSEN_RADIO_DAYPART_ID int NOT NULL,
		ID int NOT NULL
	)

	DECLARE @multiple_dayparts TABLE (
		TotalTime int NOT NULL,
		ID int NOT NULL,
		MIL_START_TIME smallint NOT NULL,
		NIELSEN_RADIO_DAYPART_ID int NOT NULL
	)

	DECLARE @tt TABLE (
		[251] bigint NOT NULL,
		[42] bigint NOT NULL,
		[1] bigint NOT NULL,
		[264] bigint NOT NULL,
		[8] bigint NOT NULL,
		[254] bigint NOT NULL,
		[255] bigint NOT NULL,
		[3] bigint NOT NULL,
		[4] bigint NOT NULL,
		[5] bigint NOT NULL,
		[6] bigint NOT NULL,
		[82] bigint NOT NULL,
		[7] bigint NOT NULL,
		[267] bigint NOT NULL,
		[268] bigint NOT NULL,
		[10] bigint NOT NULL,
		[11] bigint NOT NULL,
		[12] bigint NOT NULL,
		[13] bigint NOT NULL,
		[14] bigint NOT NULL,
		[15] bigint NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		ID int NOT NULL,
		[NUMBER_QUARTER_HOURS] int NOT NULL,
		[REQUEST_NUM_QHRS] int NOT NULL
	)
	
	DECLARE @tt2 TABLE (
		[251] bigint NOT NULL,
		[42] bigint NOT NULL,
		[1] bigint NOT NULL,
		[264] bigint NOT NULL,
		[8] bigint NOT NULL,
		[254] bigint NOT NULL,
		[255] bigint NOT NULL,
		[3] bigint NOT NULL,
		[4] bigint NOT NULL,
		[5] bigint NOT NULL,
		[6] bigint NOT NULL,
		[82] bigint NOT NULL,
		[7] bigint NOT NULL,
		[267] bigint NOT NULL,
		[268] bigint NOT NULL,
		[10] bigint NOT NULL,
		[11] bigint NOT NULL,
		[12] bigint NOT NULL,
		[13] bigint NOT NULL,
		[14] bigint NOT NULL,
		[15] bigint NOT NULL,
		NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
		NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
		ID int NOT NULL,
		[NUMBER_QUARTER_HOURS] int NOT NULL,
		[REQUEST_NUM_QHRS] int NOT NULL
	)
	
	INSERT INTO @tt  --get exact daypart match first
	SELECT
			[251] = a.[MALES_6TO11_CUME],
			[42] = MALES_12TO17_CUME + MALES_18TO20_CUME + MALES_18TO24_CUME + MALES_21TO24_CUME + MALES_25TO34_CUME + MALES_35TO44_CUME + MALES_35TO49_CUME + MALES_45TO49_CUME + MALES_50TO54_CUME + MALES_55TO64_CUME + MALES_65PLUS_CUME + 
					FEMALES_12TO17_CUME + FEMALES_18TO20_CUME + FEMALES_18TO24_CUME + FEMALES_21TO24_CUME + FEMALES_25TO34_CUME + FEMALES_35TO44_CUME + FEMALES_35TO49_CUME + FEMALES_45TO49_CUME + FEMALES_50TO54_CUME + FEMALES_55TO64_CUME + FEMALES_65PLUS_CUME,
			[1] = a.[MALES_12TO17_CUME],
			[264] = a.[FEMALES_6TO11_CUME],
			[8] = a.[FEMALES_12TO17_CUME],
			[254] = a.[MALES_18TO20_CUME],
			[255] = a.[MALES_21TO24_CUME],
			[3] = a.[MALES_25TO34_CUME],
			[4] = a.[MALES_35TO44_CUME],
			[5] = a.[MALES_45TO49_CUME],
			[6] = a.[MALES_50TO54_CUME],
			[82] = a.[MALES_55TO64_CUME],
			[7] = a.[MALES_65PLUS_CUME],
			[267] = a.[FEMALES_18TO20_CUME],
			[268] = a.[FEMALES_21TO24_CUME],
			[10] = a.[FEMALES_25TO34_CUME],
			[11] = a.[FEMALES_35TO44_CUME],
			[12] = a.[FEMALES_45TO49_CUME],
			[13] = a.[FEMALES_50TO54_CUME],
			[14] = a.[FEMALES_55TO64_CUME],
			[15] = a.[FEMALES_65PLUS_CUME],
			c.NIELSEN_RADIO_STATION_COMBO_ID,
			a.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			MRDT.ID,
			dp.NUMBER_QUARTER_HOURS,
			NumDays * NumHours
		FROM dbo.NIELSEN_RADIO_AUDIENCE a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
														AND c.LISTENING_LOCATION = @LISTENING_LOCATION
														AND c.STATION_COMBO_TYPE = @STATION_COMBO_TYPE
			INNER JOIN dbo.NIELSEN_RADIO_DAYPART dp ON c.NIELSEN_RADIO_DAYPART_ID = dp.NIELSEN_RADIO_DAYPART_ID AND dp.CUME = 1
			INNER JOIN (SELECT 
							ID,
							StartHour,
							EndHour, 
							Sunday,
							Monday,
							Tuesday, 
							Wednesday,
							Thursday,
							Friday,
							Saturday,
							MonFri = CASE WHEN Monday=1 OR Tuesday=1 OR Wednesday=1 OR Thursday=1 OR Friday=1 THEN 1 ELSE 0 END,
							NumDays = CAST(Monday as int) + CAST(Tuesday as int) + CAST(Wednesday as int) + CAST(Thursday as int) + CAST(Friday as int) + CAST(Saturday as int) + CAST(Sunday as int),
							NumHours = dbo.advfn_calculate_num_quarter_hours(StartHour, EndHour)
						FROM 
							@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) MRDT ON MRDT.ID > 0
			INNER JOIN (SELECT NIELSEN_RADIO_DAYPART_ID, dt.ID
						FROM dbo.NIELSEN_RADIO_DAYPART dp
							INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dt ON dt.ID > 0
						WHERE dp.MIL_START_TIME = dt.StartHour 
						AND dp.MIL_END_TIME = dt.EndHour 
						AND dp.SUNDAY = dt.Sunday 
						AND dp.MONDAY = dt.Monday
						AND dp.TUESDAY = dt.Tuesday 
						AND dp.WEDNESDAY = dt.Wednesday 
						AND dp.THURSDAY = dt.Thursday 
						AND dp.FRIDAY = dt.Friday 
						AND dp.SATURDAY = dt.Saturday) AS NRD ON NRD.NIELSEN_RADIO_DAYPART_ID = c.NIELSEN_RADIO_DAYPART_ID
															  AND NRD.ID = MRDT.ID
		WHERE NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list_int(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
		AND c.NIELSEN_RADIO_DAYPART_ID = NRD.NIELSEN_RADIO_DAYPART_ID
		
	--get daypart that covers whole request
	--INSERT INTO @covering_daypart (NIELSEN_RADIO_DAYPART_ID, ID)
	--SELECT dp.NIELSEN_RADIO_DAYPART_ID, MRDT.ID
	--FROM dbo.NIELSEN_RADIO_DAYPART dp
	--	INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE MRDT ON MRDT.ID > 0
	--WHERE dp.CUME = 1
	--AND (MRDT.Sunday = 0 OR MRDT.Sunday = dp.SUNDAY)
	--AND (MRDT.Monday = 0 OR MRDT.Monday = dp.MONDAY)
	--AND (MRDT.Tuesday = 0 OR MRDT.Tuesday = dp.TUESDAY)
	--AND (MRDT.Wednesday = 0 OR MRDT.Wednesday = dp.WEDNESDAY)
	--AND (MRDT.Thursday = 0 OR MRDT.Thursday = dp.THURSDAY)
	--AND (MRDT.Friday = 0 OR MRDT.Friday = dp.FRIDAY)
	--AND (MRDT.Saturday = 0 OR MRDT.Saturday = dp.SATURDAY)
	--AND MRDT.StartHour >= dp.MIL_START_TIME 
	--AND MRDT.EndHour <= dp.MIL_END_TIME 
	--AND MRDT.ID NOT IN (SELECT ID FROM @tt)

	--INSERT INTO @tt
	--SELECT
	--		[251] = a.[MALES_6TO11_CUME],
	--		[42] = MALES_12TO17_CUME + MALES_18TO20_CUME + MALES_18TO24_CUME + MALES_21TO24_CUME + MALES_25TO34_CUME + MALES_35TO44_CUME + MALES_35TO49_CUME + MALES_45TO49_CUME + MALES_50TO54_CUME + MALES_55TO64_CUME + MALES_65PLUS_CUME + 
	--				FEMALES_12TO17_CUME + FEMALES_18TO20_CUME + FEMALES_18TO24_CUME + FEMALES_21TO24_CUME + FEMALES_25TO34_CUME + FEMALES_35TO44_CUME + FEMALES_35TO49_CUME + FEMALES_45TO49_CUME + FEMALES_50TO54_CUME + FEMALES_55TO64_CUME + FEMALES_65PLUS_CUME,
	--		[1] = a.[MALES_12TO17_CUME],
	--		[264] = a.[FEMALES_6TO11_CUME],
	--		[8] = a.[FEMALES_12TO17_CUME],
	--		[254] = a.[MALES_18TO20_CUME],
	--		[255] = a.[MALES_21TO24_CUME],
	--		[3] = a.[MALES_25TO34_CUME],
	--		[4] = a.[MALES_35TO44_CUME],
	--		[5] = a.[MALES_45TO49_CUME],
	--		[6] = a.[MALES_50TO54_CUME],
	--		[82] = a.[MALES_55TO64_CUME],
	--		[7] = a.[MALES_65PLUS_CUME],
	--		[267] = a.[FEMALES_18TO20_CUME],
	--		[268] = a.[FEMALES_21TO24_CUME],
	--		[10] = a.[FEMALES_25TO34_CUME],
	--		[11] = a.[FEMALES_35TO44_CUME],
	--		[12] = a.[FEMALES_45TO49_CUME],
	--		[13] = a.[FEMALES_50TO54_CUME],
	--		[14] = a.[FEMALES_55TO64_CUME],
	--		[15] = a.[FEMALES_65PLUS_CUME],
	--		c.NIELSEN_RADIO_STATION_COMBO_ID,
	--		--RowMinutes = MRDT.RowDays * (CASE WHEN MRDT.EndMinutes = MRDT.StartMinutes THEN 15 ELSE CASE WHEN MRDT.EndMinutes < dp.END_MINUTE THEN MRDT.EndMinutes ELSE dp.END_MINUTE END - CASE WHEN MRDT.StartMinutes > dp.START_MINUTE THEN MRDT.StartMinutes ELSE dp.START_MINUTE END END),
	--		--MRDT.RowDays,
	--		a.NIELSEN_RADIO_SEGMENT_PARENT_ID,
	--		cdp.ID
	--	FROM dbo.NIELSEN_RADIO_AUDIENCE a
	--		INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
	--													AND c.LISTENING_LOCATION = @LISTENING_LOCATION
	--													AND c.STATION_COMBO_TYPE = @STATION_COMBO_TYPE
	--		INNER JOIN @covering_daypart cdp ON c.NIELSEN_RADIO_DAYPART_ID = cdp.NIELSEN_RADIO_DAYPART_ID
	--	WHERE NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list_int(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
	--	AND cdp.ID IN (SELECT ID FROM @covering_daypart GROUP BY ID HAVING COUNT(1) = 1)

	--get best daypart that is covered by many dayparts
	INSERT INTO @multiple_dayparts (TotalTime, ID, MIL_START_TIME, NIELSEN_RADIO_DAYPART_ID)
	SELECT 
		TotalTime = dp.MIL_END_TIME - dp.MIL_START_TIME,
		tablea.ID,
		dp.MIL_START_TIME,
		dp.NIELSEN_RADIO_DAYPART_ID 
	FROM 
		dbo.NIELSEN_RADIO_DAYPART dp
		INNER JOIN 
		(
		SELECT distinct MRDT.ID, 
			dayselection = CASE WHEN MRDT.SundayOnly = 1 THEN 1 
								WHEN MRDT.SaturdayOnly = 1 THEN 2
								WHEN MRDT.WeekendOnly = 1 THEN 3
								WHEN MRDT.WeekdaysOnly = 1 THEN 4
								WHEN MRDT.WeekdaysAndSaturday = 1 THEN 5
								ELSE 6
						END,
						MRDT.StartHour,
						MRDT.EndHour 
		FROM dbo.NIELSEN_RADIO_DAYPART dp
			INNER JOIN (SELECT 
								ID,
								StartHour,
								EndHour, 
								Sunday,
								Monday,
								Tuesday, 
								Wednesday,
								Thursday,
								Friday,
								Saturday,
								SundayOnly = CASE WHEN Sunday=1 AND Monday=0 AND Tuesday=0 AND Wednesday=0 AND Thursday=0 AND Friday=0 AND Saturday=0 THEN 1 ELSE 0 END,
								SaturdayOnly = CASE WHEN Sunday=0 AND Monday=0 AND Tuesday=0 AND Wednesday=0 AND Thursday=0 AND Friday=0 AND Saturday=1 THEN 1 ELSE 0 END,
								WeekendOnly =  CASE WHEN Sunday=1 AND Monday=0 AND Tuesday=0 AND Wednesday=0 AND Thursday=0 AND Friday=0 AND Saturday=1 THEN 1 ELSE 0 END,
								WeekdaysOnly = CASE WHEN (Monday=1 OR Tuesday=1 OR Wednesday=1 OR Thursday=1 OR Friday=1) AND Saturday=0 AND Sunday=0 THEN 1 ELSE 0 END,
								WeekdaysAndSaturday = CASE WHEN (Monday=1 OR Tuesday=1 OR Wednesday=1 OR Thursday=1 OR Friday=1) AND Saturday=1 AND Sunday=0 THEN 1 ELSE 0 END
						FROM 
							@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE) MRDT ON MRDT.ID > 0
		WHERE dp.CUME = 1
		AND (MRDT.Sunday = 0 OR MRDT.Sunday = dp.SUNDAY)
		AND (MRDT.Monday = 0 OR MRDT.Monday = dp.MONDAY)
		AND (MRDT.Tuesday = 0 OR MRDT.Tuesday = dp.TUESDAY)
		AND (MRDT.Wednesday = 0 OR MRDT.Wednesday = dp.WEDNESDAY)
		AND (MRDT.Thursday = 0 OR MRDT.Thursday = dp.THURSDAY)
		AND (MRDT.Friday = 0 OR MRDT.Friday = dp.FRIDAY)
		AND (MRDT.Saturday = 0 OR MRDT.Saturday = dp.SATURDAY)
		AND MRDT.StartHour >= dp.MIL_START_TIME 
		AND MRDT.EndHour <= dp.MIL_END_TIME 
		AND MRDT.ID NOT IN (SELECT ID FROM @tt)
		) tablea ON tablea.ID > 0
	WHERE 
		dp.CUME = 1
	AND tablea.StartHour >= dp.MIL_START_TIME 
	AND tablea.EndHour <= dp.MIL_END_TIME 
	AND (
		(tablea.dayselection = 1 AND dp.SUNDAY=1 AND dp.MONDAY=0 AND dp.TUESDAY=0 AND dp.WEDNESDAY=0 AND dp.THURSDAY=0 AND dp.FRIDAY=0 AND dp.SATURDAY=0)
	OR	(tablea.dayselection = 2 AND dp.SUNDAY=0 AND dp.MONDAY=0 AND dp.TUESDAY=0 AND dp.WEDNESDAY=0 AND dp.THURSDAY=0 AND dp.FRIDAY=0 AND dp.SATURDAY=1)
	OR	(tablea.dayselection = 3 AND dp.SUNDAY=1 AND dp.MONDAY=0 AND dp.TUESDAY=0 AND dp.WEDNESDAY=0 AND dp.THURSDAY=0 AND dp.FRIDAY=0 AND dp.SATURDAY=1)
	OR	(tablea.dayselection = 4 AND dp.SUNDAY=0 AND dp.MONDAY=1 AND dp.TUESDAY=1 AND dp.WEDNESDAY=1 AND dp.THURSDAY=1 AND dp.FRIDAY=1 AND dp.SATURDAY=0)
	OR	(tablea.dayselection = 5 AND dp.SUNDAY=0 AND dp.MONDAY=1 AND dp.TUESDAY=1 AND dp.WEDNESDAY=1 AND dp.THURSDAY=1 AND dp.FRIDAY=1 AND dp.SATURDAY=1)
	OR	(tablea.dayselection = 6 AND dp.SUNDAY=1 AND dp.MONDAY=1 AND dp.TUESDAY=1 AND dp.WEDNESDAY=1 AND dp.THURSDAY=1 AND dp.FRIDAY=1 AND dp.SATURDAY=1)
		)

	INSERT INTO @tt
	SELECT
			[251] = a.[MALES_6TO11_CUME],
			[42] = MALES_12TO17_CUME + MALES_18TO20_CUME + MALES_18TO24_CUME + MALES_21TO24_CUME + MALES_25TO34_CUME + MALES_35TO44_CUME + MALES_35TO49_CUME + MALES_45TO49_CUME + MALES_50TO54_CUME + MALES_55TO64_CUME + MALES_65PLUS_CUME + 
					FEMALES_12TO17_CUME + FEMALES_18TO20_CUME + FEMALES_18TO24_CUME + FEMALES_21TO24_CUME + FEMALES_25TO34_CUME + FEMALES_35TO44_CUME + FEMALES_35TO49_CUME + FEMALES_45TO49_CUME + FEMALES_50TO54_CUME + FEMALES_55TO64_CUME + FEMALES_65PLUS_CUME,
			[1] = a.[MALES_12TO17_CUME],
			[264] = a.[FEMALES_6TO11_CUME],
			[8] = a.[FEMALES_12TO17_CUME],
			[254] = a.[MALES_18TO20_CUME],
			[255] = a.[MALES_21TO24_CUME],
			[3] = a.[MALES_25TO34_CUME],
			[4] = a.[MALES_35TO44_CUME],
			[5] = a.[MALES_45TO49_CUME],
			[6] = a.[MALES_50TO54_CUME],
			[82] = a.[MALES_55TO64_CUME],
			[7] = a.[MALES_65PLUS_CUME],
			[267] = a.[FEMALES_18TO20_CUME],
			[268] = a.[FEMALES_21TO24_CUME],
			[10] = a.[FEMALES_25TO34_CUME],
			[11] = a.[FEMALES_35TO44_CUME],
			[12] = a.[FEMALES_45TO49_CUME],
			[13] = a.[FEMALES_50TO54_CUME],
			[14] = a.[FEMALES_55TO64_CUME],
			[15] = a.[FEMALES_65PLUS_CUME],
			c.NIELSEN_RADIO_STATION_COMBO_ID,
			a.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			MRDT.ID,
			dp.NUMBER_QUARTER_HOURS,
			NumDays * NumHours
		FROM dbo.NIELSEN_RADIO_AUDIENCE a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
														AND c.LISTENING_LOCATION = @LISTENING_LOCATION
														AND c.STATION_COMBO_TYPE = @STATION_COMBO_TYPE
			INNER JOIN (SELECT DISTINCT ID
						FROM @multiple_dayparts) MRDT ON MRDT.ID > 0 
			INNER JOIN dbo.NIELSEN_RADIO_DAYPART dp ON c.NIELSEN_RADIO_DAYPART_ID = dp.NIELSEN_RADIO_DAYPART_ID 
			INNER JOIN (SELECT
							ID,
							NumDays = CAST(Monday as int) + CAST(Tuesday as int) + CAST(Wednesday as int) + CAST(Thursday as int) + CAST(Friday as int) + CAST(Saturday as int) + CAST(Sunday as int),
							NumHours = dbo.advfn_calculate_num_quarter_hours(StartHour, EndHour)
						FROM @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE 
						) DaysHours ON DaysHours.ID = MRDT.ID
		WHERE NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list_int(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
		AND c.NIELSEN_RADIO_DAYPART_ID = (SELECT TOP 1 NIELSEN_RADIO_DAYPART_ID 
											FROM @multiple_dayparts 
											WHERE ID = MRDT.ID 
											ORDER BY TotalTime ASC, MIL_START_TIME DESC)

	INSERT INTO @tt2
	SELECT
			[251] = a.[MALES_6TO11_CUME],
			[42] = (MALES_12TO17_CUME + MALES_18TO20_CUME + MALES_18TO24_CUME + MALES_21TO24_CUME + MALES_25TO34_CUME + MALES_35TO44_CUME + MALES_35TO49_CUME + MALES_45TO49_CUME + MALES_50TO54_CUME + MALES_55TO64_CUME + MALES_65PLUS_CUME + 
					FEMALES_12TO17_CUME + FEMALES_18TO20_CUME + FEMALES_18TO24_CUME + FEMALES_21TO24_CUME + FEMALES_25TO34_CUME + FEMALES_35TO44_CUME + FEMALES_35TO49_CUME + FEMALES_45TO49_CUME + FEMALES_50TO54_CUME + FEMALES_55TO64_CUME + 
					FEMALES_65PLUS_CUME),
			[1] = a.[MALES_12TO17_CUME],
			[264] = a.[FEMALES_6TO11_CUME],
			[8] = a.[FEMALES_12TO17_CUME],
			[254] = a.[MALES_18TO20_CUME],
			[255] = a.[MALES_21TO24_CUME],
			[3] = a.[MALES_25TO34_CUME],
			[4] = a.[MALES_35TO44_CUME],
			[5] = a.[MALES_45TO49_CUME],
			[6] = a.[MALES_50TO54_CUME],
			[82] = a.[MALES_55TO64_CUME],
			[7] = a.[MALES_65PLUS_CUME],
			[267] = a.[FEMALES_18TO20_CUME],
			[268] = a.[FEMALES_21TO24_CUME],
			[10] = a.[FEMALES_25TO34_CUME],
			[11] = a.[FEMALES_35TO44_CUME],
			[12] = a.[FEMALES_45TO49_CUME],
			[13] = a.[FEMALES_50TO54_CUME],
			[14] = a.[FEMALES_55TO64_CUME],
			[15] = a.[FEMALES_65PLUS_CUME],
			c.NIELSEN_RADIO_STATION_COMBO_ID,
			a.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			MRDT.ID,
			NRD.NUMBER_QUARTER_HOURS,
			NumDays * NumHours
		FROM dbo.NIELSEN_RADIO_AUDIENCE a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
														AND c.LISTENING_LOCATION = @LISTENING_LOCATION
														AND c.STATION_COMBO_TYPE = @STATION_COMBO_TYPE
			INNER JOIN dbo.CUSTOM_CUME dp ON c.NIELSEN_RADIO_DAYPART_ID = dp.NIELSEN_RADIO_DAYPART_ID
			INNER JOIN dbo.NIELSEN_RADIO_DAYPART NRD ON c.NIELSEN_RADIO_DAYPART_ID = NRD.NIELSEN_RADIO_DAYPART_ID 
			INNER JOIN (SELECT 
							ID,
							StartHour,
							EndHour, 
							Sunday,
							Monday,
							Tuesday, 
							Wednesday,
							Thursday,
							Friday,
							Saturday,
							MonFri = CASE WHEN Monday=1 OR Tuesday=1 OR Wednesday=1 OR Thursday=1 OR Friday=1 THEN 1 ELSE 0 END,
							NumDays = CAST(Monday as int) + CAST(Tuesday as int) + CAST(Wednesday as int) + CAST(Thursday as int) + CAST(Friday as int) + CAST(Saturday as int) + CAST(Sunday as int),
							NumHours = dbo.advfn_calculate_num_quarter_hours(StartHour, EndHour)
						FROM 
							@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE
						WHERE ID NOT IN (SELECT ID FROM @tt)) MRDT ON MRDT.ID > 0
		WHERE 
			NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list_int(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
		AND	(
				(MRDT.Saturday = 1 AND MRDT.MonFri = 0 AND MRDT.Sunday = 0 AND dp.CUME_SECTION = 1)
			OR
				(MRDT.Saturday = 0 AND MRDT.MonFri = 0 AND MRDT.Sunday = 1 AND dp.CUME_SECTION = 2)
			OR
				(MRDT.Saturday = 0 AND MRDT.MonFri = 1 AND MRDT.Sunday = 0 AND dp.CUME_SECTION = 3)
			OR
				(MRDT.Saturday = 1 AND MRDT.MonFri = 1 AND MRDT.Sunday = 0 AND dp.CUME_SECTION = 4)
			OR
				(MRDT.Saturday = 0 AND MRDT.MonFri = 1 AND MRDT.Sunday = 1 AND dp.CUME_SECTION = 5)
			)
		AND (
				(dp.MIL_START_TIME BETWEEN MRDT.StartHour AND MRDT.EndHour AND dp.MIL_START_TIME <> MRDT.EndHour)
			OR
				(dp.MIL_END_TIME BETWEEN MRDT.StartHour AND MRDT.EndHour AND dp.MIL_END_TIME <> MRDT.StartHour)
			OR
				(MRDT.StartHour >= dp.MIL_START_TIME AND MRDT.EndHour <= dp.MIL_END_TIME)
			)

	INSERT INTO @tt
	SELECT [251],
		[42],
		[1],
		[264],
		[8],
		[254],
		[255],
		[3],
		[4],
		[5],
		[6],
		[82],
		[7],
		[267],
		[268],
		[10],
		[11],
		[12],
		[13],
		[14],
		[15],
		NIELSEN_RADIO_STATION_COMBO_ID,
		NIELSEN_RADIO_SEGMENT_PARENT_ID,
		ID,
		[NUMBER_QUARTER_HOURS],
		[REQUEST_NUM_QHRS]
	FROM @tt2
		
	SELECT @CUME_NUM_QHRS = SUM(NUMBER_QUARTER_HOURS), @REQUEST_NUM_QHRS = SUM([REQUEST_NUM_QHRS])
	FROM @tt
	
	IF @CUME_NUM_QHRS = @REQUEST_NUM_QHRS
		SET @CUME_FACTOR = 1
	ELSE BEGIN

		IF @CUME_NUM_QHRS > 0 BEGIN
			SET @CUME_FACTOR = 2 * 1 / CAST(@CUME_NUM_QHRS as decimal)

			SET @RNQ_COUNTER = 2

			WHILE @RNQ_COUNTER <= @REQUEST_NUM_QHRS 
			BEGIN

				SET @CUME_FACTOR = @CUME_FACTOR + 3 * (1 - @CUME_FACTOR) / CAST(@CUME_NUM_QHRS as decimal)
				SET @RNQ_COUNTER = @RNQ_COUNTER + 1

			END

		END
	END
	
	INSERT INTO @RETURN_TABLE
	SELECT
		u.NIELSEN_DEMO_CODE, u.CUME * @CUME_FACTOR, mdd.MediaDemographicID, NIELSEN_RADIO_STATION_COMBO_ID, NIELSEN_RADIO_SEGMENT_PARENT_ID, ID
	FROM (
		SELECT 
			[251] = SUM([251]),
			[42] = SUM([42]),
			[1] = SUM([1]),
			[264] = SUM([264]),
			[8] = SUM([8]),
			[254] = SUM([254]),
			[255] = SUM([255]),
			[3] = SUM([3]),
			[4] = SUM([4]),
			[5] = SUM([5]),
			[6] = SUM([6]),
			[82] = SUM([82]),
			[7] = SUM([7]),
			[267] = SUM([267]),
			[268] = SUM([268]),
			[10] = SUM([10]),
			[11] = SUM([11]),
			[12] = SUM([12]),
			[13] = SUM([13]),
			[14] = SUM([14]),
			[15] = SUM([15]),
			NIELSEN_RADIO_STATION_COMBO_ID,
			NIELSEN_RADIO_SEGMENT_PARENT_ID,
			ID
		FROM 
		(
			SELECT 
				[251],
				[42],
				[1],
				[264],
				[8],
				[254],
				[255],
				[3],
				[4],
				[5],
				[6],
				[82],
				[7],
				[267],
				[268],
				[10],
				[11],
				[12],
				[13],
				[14],
				[15],
				NIELSEN_RADIO_STATION_COMBO_ID,
				NIELSEN_RADIO_SEGMENT_PARENT_ID,
				ID
			FROM @tt
		) rawdata
		GROUP BY NIELSEN_RADIO_STATION_COMBO_ID, NIELSEN_RADIO_SEGMENT_PARENT_ID, ID
	) AUDDATA
	UNPIVOT
	(
		CUME
		FOR NIELSEN_DEMO_CODE in ([251], [42], [1], [264], [8], [254], [255], [3], [4], [5], [6], [82], [7], [267], [268], [10], [11], [12], [13], [14], [15]) 
	) u
		INNER JOIN dbo.NIELSEN_DEMO nd ON u.NIELSEN_DEMO_CODE = nd.CODE
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON nd.NIELSEN_DEMO_ID = mdd.NielsenDemographicID  
	WHERE mdd.MediaDemographicID IN (SELECT items FROM dbo.udf_split_list_int(@SelectedMediaDemographicIDs, ','))

	RETURN
END
GO

GRANT SELECT ON advtf_nielsen_radio_audience_get_cume TO PUBLIC
GO
