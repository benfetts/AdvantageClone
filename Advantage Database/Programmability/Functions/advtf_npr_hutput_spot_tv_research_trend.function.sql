CREATE FUNCTION [dbo].[advtf_npr_hutput_spot_tv_research_trend](
	@MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID int,
    @START_DATE smalldatetime,
    @END_DATE smalldatetime
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[avg_hutput] decimal(21,2) NOT NULL,
	[media_spot_tv_research_daytime_id] INT NOT NULL,
    [AdjustedDateTime] smalldatetime NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @ADJUST_MINUTES smallint
	SET @ADJUST_MINUTES = 120
	
	DECLARE @tt TABLE (
        [homes] decimal(21,2) NOT NULL,
		[pp2P] decimal(21,2) NOT NULL,
		[pm2P] decimal(21,2) NOT NULL,
		[pm2-5] decimal(21,2) NOT NULL,
		[pm6-11] decimal(21,2) NOT NULL,
		[pm12-14] decimal(21,2) NOT NULL,
		[pm15-17] decimal(21,2) NOT NULL,
		[pm18-20] decimal(21,2) NOT NULL,
		[pm21-24] decimal(21,2) NOT NULL,
		[pm25-34] decimal(21,2) NOT NULL,
		[pm35-44] decimal(21,2) NOT NULL,
		[pm45-49] decimal(21,2) NOT NULL,
		[pm50-54] decimal(21,2) NOT NULL,
		[pm55-64] decimal(21,2) NOT NULL,
		[pm65P] decimal(21,2) NOT NULL,
		[pf2P] decimal(21,2) NOT NULL,
		[pf2-5] decimal(21,2) NOT NULL,
		[pf6-11] decimal(21,2) NOT NULL,
		[pf12-14] decimal(21,2) NOT NULL,
		[pf15-17] decimal(21,2) NOT NULL,
		[pf18-20] decimal(21,2) NOT NULL,
		[pf21-24] decimal(21,2) NOT NULL,
		[pf25-34] decimal(21,2) NOT NULL,
		[pf35-44] decimal(21,2) NOT NULL,
		[pf45-49] decimal(21,2) NOT NULL,
		[pf50-54] decimal(21,2) NOT NULL,
		[pf55-64] decimal(21,2) NOT NULL,
		[pf65P] decimal(21,2) NOT NULL,
		[pww] decimal(21,2) NOT NULL,
		[media_spot_tv_research_daytime_id] INT NOT NULL,
        [AdjustedDateTime] smalldatetime NOT NULL
	)

	INSERT INTO @tt
	SELECT CAST( SUM([homes] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pp2P] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pm2P] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm2-5] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm6-11] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm12-14] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm15-17] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm18-10] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm21-24] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm25-34] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm35-44] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pm45-49] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm50-54] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm55-64] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pm65P] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pf2P] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pf2-5] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf6-11] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf12-14] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf15-17] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf18-10] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf21-24] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf25-34] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf35-44] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
        CAST( SUM([pf45-49] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf50-54] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf55-64] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pf65P] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		CAST( SUM([pww] * MINUTEPART) as decimal(14,4)) / CAST( SUM(MINUTEPART) as decimal(14,4)),
		[media_spot_tv_research_daytime_id],
        [AdjustedDateTime]
	FROM (
		SELECT
			[homes] = CAST(AVG(CAST(a.HOMES_HUT as decimal(14,4))) as int),
            [pp2P] = CAST(AVG(CAST(a.PEOPLE_2PLUS_PUT as decimal(14,4))) as int),
            [pm2P] = CAST(AVG(CAST(a.MALES_2PLUS_PUT as decimal(14,4))) as int),
			[pm2-5] = CAST(AVG(CAST(a.MALES_2TO5_PUT as decimal(14,4))) as int),
			[pm6-11] = CAST(AVG(CAST(a.MALES_6TO11_PUT as decimal(14,4))) as int),
			[pm12-14] = CAST(AVG(CAST(a.MALES_12TO14_PUT as decimal(14,4))) as int),
			[pm15-17] = CAST(AVG(CAST(a.MALES_15TO17_PUT as decimal(14,4))) as int),
			[pm18-10] = CAST(AVG(CAST(a.MALES_18TO20_PUT as decimal(14,4))) as int),
			[pm21-24] = CAST(AVG(CAST(a.MALES_21TO24_PUT as decimal(14,4))) as int),
			[pm25-34] = CAST(AVG(CAST(a.MALES_25TO34_PUT as decimal(14,4))) as int),
			[pm35-44] = CAST(AVG(CAST(a.MALES_35TO44_PUT as decimal(14,4))) as int),
            [pm45-49] = CAST(AVG(CAST(a.MALES_45TO49_PUT as decimal(14,4))) as int),
			[pm50-54] = CAST(AVG(CAST(a.MALES_50TO54_PUT as decimal(14,4))) as int),
			[pm55-64] = CAST(AVG(CAST(a.MALES_55TO64_PUT as decimal(14,4))) as int),
			[pm65P] = CAST(AVG(CAST(a.MALES_65PLUS_PUT as decimal(14,4))) as int),
            [pf2P] = CAST(AVG(CAST(a.FEMALES_2PLUS_PUT as decimal(14,4))) as int),
			[pf2-5] = CAST(AVG(CAST(a.FEMALES_2TO5_PUT as decimal(14,4))) as int),
			[pf6-11] = CAST(AVG(CAST(a.FEMALES_6TO11_PUT as decimal(14,4))) as int),
			[pf12-14] = CAST(AVG(CAST(a.FEMALES_12TO14_PUT as decimal(14,4))) as int),
			[pf15-17] = CAST(AVG(CAST(a.FEMALES_15TO17_PUT as decimal(14,4))) as int),
			[pf18-10] = CAST(AVG(CAST(a.FEMALES_18TO20_PUT as decimal(14,4))) as int),
			[pf21-24] = CAST(AVG(CAST(a.FEMALES_21TO24_PUT as decimal(14,4))) as int),
			[pf25-34] = CAST(AVG(CAST(a.FEMALES_25TO34_PUT as decimal(14,4))) as int),
			[pf35-44] = CAST(AVG(CAST(a.FEMALES_35TO44_PUT as decimal(14,4))) as int),
            [pf45-49] = CAST(AVG(CAST(a.FEMALES_45TO49_PUT as decimal(14,4))) as int),
			[pf50-54] = CAST(AVG(CAST(a.FEMALES_50TO54_PUT as decimal(14,4))) as int),
			[pf55-64] = CAST(AVG(CAST(a.FEMALES_55TO64_PUT as decimal(14,4))) as int),
			[pf65P] = CAST(AVG(CAST(a.FEMALES_65PLUS_PUT as decimal(14,4))) as int),
			[pww] = CAST(AVG(CAST(a.WORKING_WOMEN_PUT as decimal(14,4))) as int),
			[media_spot_tv_research_daytime_id] = a.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID,
			AdjustedHour,
			MINUTEPART,
            [AdjustedDateTime]
		FROM
			(SELECT 
				HOMES_HUT,
                PEOPLE_2PLUS_PUT,
                MALES_2PLUS_PUT,
				MALES_2TO5_PUT,
				MALES_6TO11_PUT,
				MALES_12TO14_PUT,
				MALES_15TO17_PUT,
				MALES_18TO20_PUT,
				MALES_21TO24_PUT,
				MALES_25TO34_PUT,
				MALES_35TO44_PUT,
                MALES_45TO49_PUT,
				MALES_50TO54_PUT,
				MALES_55TO64_PUT,
				MALES_65PLUS_PUT,
                FEMALES_2PLUS_PUT,
				FEMALES_2TO5_PUT,
				FEMALES_6TO11_PUT,
				FEMALES_12TO14_PUT,
				FEMALES_15TO17_PUT,
				FEMALES_18TO20_PUT,
				FEMALES_21TO24_PUT,
				FEMALES_25TO34_PUT,
				FEMALES_35TO44_PUT,
                FEMALES_45TO49_PUT,
				FEMALES_50TO54_PUT,
				FEMALES_55TO64_PUT,
				FEMALES_65PLUS_PUT,
				WORKING_WOMEN_PUT,
				d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID,
				MINUTEPART = CASE
								WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),AdjustedDateTime) between -15 and -1 THEN
										15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.START_TIME as smalldatetime),AdjustedDateTime) 
								WHEN datediff(mi,AdjustedDateTime,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.END_TIME as smalldatetime)) between 1 and 14 THEN
										datediff(mi,AdjustedDateTime,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.END_TIME as smalldatetime))
								ELSE 15 END,
				a.AdjustedDateTime,
				a.AdjustedHour
			FROM 
				(SELECT
					HOMES_HUT,
                    PEOPLE_2PLUS_PUT,
                    MALES_2PLUS_PUT,
					MALES_2TO5_PUT,
					MALES_6TO11_PUT,
					MALES_12TO14_PUT,
					MALES_15TO17_PUT,
					MALES_18TO20_PUT,
					MALES_21TO24_PUT,
					MALES_25TO34_PUT,
					MALES_35TO44_PUT,
                    MALES_45TO49_PUT,
					MALES_50TO54_PUT,
					MALES_55TO64_PUT,
					MALES_65PLUS_PUT,
                    FEMALES_2PLUS_PUT,
					FEMALES_2TO5_PUT,
					FEMALES_6TO11_PUT,
					FEMALES_12TO14_PUT,
					FEMALES_15TO17_PUT,
					FEMALES_18TO20_PUT,
					FEMALES_21TO24_PUT,
					FEMALES_25TO34_PUT,
					FEMALES_35TO44_PUT,
                    FEMALES_45TO49_PUT,
					FEMALES_50TO54_PUT,
					FEMALES_55TO64_PUT,
					FEMALES_65PLUS_PUT,
					WORKING_WOMEN_PUT,
					AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
											CONVERT(char(10), DATEADD(dd, -1, [DATE]), 101)
									   ELSE CONVERT(char(10), [DATE], 101)
									   END,
					AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), [DATE], 101), [DATE]) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), [DATE], 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), [DATE], 108),2) as smallint)
								   END
				FROM dbo.NPR_HUTPUT h
                WHERE [DATE] BETWEEN DATEADD(d,-1,@START_DATE) AND DATEADD(d,2,@END_DATE)
				 ) a
					INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME d ON d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID
				WHERE
					a.AdjustedHour >= d.START_HOUR
				AND a.AdjustedHour < CASE WHEN d.END_HOUR = d.START_HOUR THEN d.END_HOUR + 15 ELSE d.END_HOUR END
                AND a.AdjustedDateTime BETWEEN @START_DATE AND @END_DATE
				AND	(
					(d.SUNDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
				OR	(d.MONDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
				OR	(d.TUESDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
				OR	(d.WEDNESDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
				OR	(d.THURSDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
				OR	(d.FRIDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
				OR	(d.SATURDAY = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
					)
			) a

		GROUP BY a.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID, AdjustedHour, MINUTEPART, AdjustedDateTime

		) suma
	GROUP BY [media_spot_tv_research_daytime_id], AdjustedDateTime

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_hutput, u.media_spot_tv_research_daytime_id, AdjustedDateTime
	FROM @tt
	UNPIVOT
	(
		avg_hutput
		for nielsen_demo_code in ([homes],[pp2P],[pm2P],[pm2-5],[pm6-11],[pm12-14],[pm15-17],[pm18-20],[pm21-24],[pm25-34],[pm35-44],[pm45-49],[pm50-54],[pm55-64],[pm65P],
            [pf2P],[pf2-5],[pf6-11],[pf12-14],[pf15-17],[pf18-20],[pf21-24],[pf25-34],[pf35-44],[pf45-49],[pf50-54],[pf55-64],[pf65P],[pww])
	) u

	RETURN
END
GO

