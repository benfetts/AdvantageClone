CREATE PROCEDURE [dbo].[advsp_comscore_tv_worksheet_rating]
	@MARKET_NUMBER int,
	@SHARE_BOOK_ID int,
	@SIU_BOOK_ID int,
	@STATION_CODES varchar(max),
	@PRIMARY_DEMO_NUMBER int,
	@SECONDARY_DEMO_NUMBER int,
	@MEDIA_SPOT_TV_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_DAYTIME_TYPE READONLY
AS
BEGIN

--declare @MARKET_NUMBER int,
--		@SHARE_BOOK_ID int,
--		@SIU_BOOK_ID int,
--		@STATION_CODES varchar(max),
--		@PRIMARY_DEMO_NUMBER int,
--		@SECONDARY_DEMO_NUMBER int,
--		@MEDIA_SPOT_TV_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_DAYTIME_TYPE

--set @MARKET_NUMBER=510
--set @SHARE_BOOK_ID=51
----set @SIU_BOOK_ID=41
--set @STATION_CODES='4625'
--set @PRIMARY_DEMO_NUMBER = 652
--set @SECONDARY_DEMO_NUMBER = 46524

--insert into @MEDIA_SPOT_TV_DAYTIME_TYPE values(2,1,1,1,1,1,0,0,N'05:00 AM',N'06:00 AM',500,600,N'M-F',NULL)

	DECLARE @ADJUST_MINUTES smallint
	SET @ADJUST_MINUTES = 180	
	
	DECLARE @tt TABLE (
		[Share] decimal(10,4) NOT NULL,
		[Rating] decimal(10,4) NOT NULL,
		[Impressions] bigint NOT NULL,
		[HPUT] decimal(10,4) NOT NULL,
		[Universe] bigint NOT NULL,
		[ProgramName] varchar(141) NOT NULL,
		[StationCode] int NOT NULL,
		[MediaBroadcastWorksheetMarketDetailID] int NOT NULL,
		[BookID] int NOT NULL,
		[ComscoreMeetsDemoThreshold] bit NOT NULL,
		[ComscoreMeetsHighQualityDemoThreshold] bit NOT NULL,
		[ComscoreDemoNumber] int NOT NULL,
		[BookName] varchar(100) NOT NULL,
		[AvgAud] decimal(10,4) NOT NULL,
		[SIU] decimal(10,4) NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[Share] = SUM(a.SHARE * MINUTEPART) / SUM(MINUTEPART),
		[Rating] = CAST(0 as decimal),
		[Impressions] = CAST(0 as bigint),
		[HPUT] = CAST(0 as decimal),
		[Universe] = MAX(a.UNIVERSE),
		[ProgramName] = '',
		[StationCode] = a.STATION_NUMBER,
		[MediaBroadcastWorksheetMarketDetailID] = a.ID, --media_spot_tv_research_daytime_id
		[BookID] = a.COMSCORE_TV_BOOK_ID,
		[ComscoreMeetsDemoThreshold] = MIN(CAST(a.MEETS_DEMO_THRESHOLD as int)),
		[ComscoreMeetsHighQualityDemoThreshold] = MIN(CAST(a.MEETS_HQ_DEMO_THRESHOLD as int)),
		[ComscoreDemoNumber] = a.DEMO_NUMBER,
		[BookName] = '',
		[AvgAud] = SUM(a.AVG_AUD * MINUTEPART) / CAST(SUM(MINUTEPART) as decimal),
		[SIU] = SUM(a.SIU * MINUTEPART) / CAST(SUM(MINUTEPART) as decimal)
		--[stream] = a.STREAM
	FROM (
	
		SELECT
			a.SHARE,
			a.AVG_AUD,
			a.SIU,
			a.UNIVERSE,
			a.MEETS_DEMO_THRESHOLD,
			a.MEETS_HQ_DEMO_THRESHOLD,
			a.STATION_NUMBER,
			a.STREAM,
			a.COMSCORE_TV_BOOK_ID,
			d.ID,
			NUMBER_DAYS = CAST(d.Sunday as smallint) + CAST(d.Monday as smallint) + CAST(d.Tuesday as smallint) + CAST(d.Wednesday as smallint) + CAST(d.Thursday as smallint) + CAST(d.Friday as smallint) + CAST(d.Saturday as smallint),
			MINUTEPART = CASE
							WHEN datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),QTR_HR) between -15 and -1 THEN
									15 + datediff(mi,CAST(convert(char(10),a.AdjustedDateTime,110) + ' ' + d.StartTime as smalldatetime),QTR_HR) 
							WHEN datediff(mi,QTR_HR,CAST(convert(char(10),a.QTR_HR,110) + ' ' + d.EndTime as smalldatetime)) between 1 and 14 THEN
									datediff(mi,QTR_HR,CAST(convert(char(10),a.QTR_HR,110) + ' ' + d.EndTime as smalldatetime))
							ELSE 15 END,
			a.QTR_HR,
			a.DEMO_NUMBER,
			d.StartHour, d.EndHour, d.Sunday, d.Monday, d.Tuesday, d.Wednesday, d.Thursday, d.Friday, d.Saturday 
		FROM (
				SELECT
					d.SHARE,
					d.AVG_AUD,
					d.SIU,
					d.UNIVERSE,
					d.MEETS_DEMO_THRESHOLD,
					d.MEETS_HQ_DEMO_THRESHOLD,
					h.STATION_NUMBER,
					b.STREAM,
					d.QTR_HR,
					AdjustedDateTime = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HR, 101), QTR_HR) < @ADJUST_MINUTES THEN 
									CONVERT(char(10), DATEADD(dd, -1, QTR_HR), 101)
							   ELSE CONVERT(char(10), QTR_HR, 101)
							   END,
					AdjustedHour = CASE WHEN DATEDIFF(mi, CONVERT(char(10), QTR_HR, 101), QTR_HR) < @ADJUST_MINUTES THEN 
										CAST(LEFT(CONVERT(char(5), QTR_HR, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HR, 108),2) as smallint) + 2400
								   ELSE CAST(LEFT(CONVERT(char(5), QTR_HR, 108),2) as smallint) * 100 + CAST(RIGHT(CONVERT(char(5), QTR_HR, 108),2) as smallint)
								   END,
					b.COMSCORE_TV_BOOK_ID,
					h.DEMO_NUMBER 
				FROM dbo.COMSCORE_CACHE_DETAIL d (NOLOCK)
					INNER JOIN dbo.COMSCORE_CACHE_HEADER h (NOLOCK) ON d.COMSCORE_CACHE_HEADER_ID = h.COMSCORE_CACHE_HEADER_ID 
					INNER JOIN dbo.COMSCORE_TV_BOOK b (NOLOCK) ON d.QTR_HR BETWEEN b.START_DATETIME AND b.END_DATETIME
													 AND (b.COMSCORE_TV_BOOK_ID = @SHARE_BOOK_ID OR (@SIU_BOOK_ID IS NOT NULL AND b.COMSCORE_TV_BOOK_ID = @SIU_BOOK_ID))
				WHERE h.MARKET_NUMBER = @MARKET_NUMBER
				AND h.STATION_NUMBER IN (SELECT items FROM dbo.udf_split_list(@STATION_CODES, ','))
				AND (h.DEMO_NUMBER = @PRIMARY_DEMO_NUMBER OR (@SECONDARY_DEMO_NUMBER IS NOT NULL AND h.DEMO_NUMBER = @SECONDARY_DEMO_NUMBER))
				AND d.UNIVERSE <> 0
			 ) a
				INNER JOIN @MEDIA_SPOT_TV_DAYTIME_TYPE d ON 1=1 --ON d.MEDIA_SPOT_TV_RESEARCH_ID = @MEDIA_SPOT_TV_RESEARCH_ID 
			WHERE 
				a.AdjustedHour >= d.StartHour 
				AND a.AdjustedHour < d.EndHour 
				AND (
						(d.Sunday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 1)
					OR	(d.Monday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 2)
					OR	(d.Tuesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 3)
					OR	(d.Wednesday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 4)
					OR	(d.Thursday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 5)
					OR	(d.Friday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 6)
					OR	(d.Saturday = 1 AND DATEPART(dw, a.AdjustedDateTime) = 7)
					)

		) a
	GROUP BY a.STATION_NUMBER, a.STREAM, a.COMSCORE_TV_BOOK_ID, a.ID, a.DEMO_NUMBER --,a.NUMBER_DAYS,

	--select * from @tt

	IF @SIU_BOOK_ID IS NOT NULL BEGIN

		--update Share specific HPUT, Rating, Impressions
		UPDATE r SET HPUT = h.SIU
		FROM @tt r
			INNER JOIN @tt h ON r.StationCode = h.StationCode AND r.ComscoreDemoNumber = h.ComscoreDemoNumber AND r.MediaBroadcastWorksheetMarketDetailID = h.MediaBroadcastWorksheetMarketDetailID
		WHERE r.BookID = @SHARE_BOOK_ID 
		AND h.BookID = @SIU_BOOK_ID 

		UPDATE r SET Rating = r.Share * r.HPUT / 100.0, Impressions = ROUND((r.Share * r.HPUT / 100.0) * r.Universe / 100.0, 0)
		FROM @tt r
			--INNER JOIN @tt h ON r.StationCode = h.StationCode AND r.ComscoreDemoNumber = h.ComscoreDemoNumber 
		WHERE r.BookID = @SHARE_BOOK_ID 
		--AND h.BookID = @SIU_BOOK_ID 
		
		--update SIU specific HPUT, Rating, Impressions
		UPDATE h SET HPUT = h.SIU
		FROM @tt h
		WHERE h.BookID = @SIU_BOOK_ID 

		UPDATE h SET Rating = h.Share * h.HPUT / 100.0, Impressions = ROUND((h.Share * h.HPUT / 100.0) * h.Universe / 100.0, 0)
		FROM @tt h
		WHERE h.BookID = @SIU_BOOK_ID 

	END ELSE BEGIN
	
		UPDATE r SET HPUT = r.SIU, Rating = CASE WHEN r.Universe = 0 THEN 0 ELSE r.AvgAud * 100.0 / r.Universe END, 
						Impressions = ROUND(r.AvgAud, 0) --do not divide by 1000 since worksheet does it!
		FROM @tt r
			INNER JOIN @tt h ON r.StationCode = h.StationCode AND r.ComscoreDemoNumber = h.ComscoreDemoNumber 
		WHERE r.BookID = @SHARE_BOOK_ID 

	END

	UPDATE r SET [ProgramName] = dbo.[advfn_comscore_program_get](@MARKET_NUMBER, r.BookID, r.StationCode, r.ComscoreDemoNumber,
																	 StartHour, EndHour, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday) 
	FROM @tt r
		INNER JOIN @MEDIA_SPOT_TV_DAYTIME_TYPE d ON r.MediaBroadcastWorksheetMarketDetailID = d.ID 
	WHERE r.BookID = @SHARE_BOOK_ID 


	UPDATE h SET LAST_ACCESSED = getdate()
	FROM dbo.COMSCORE_CACHE_HEADER h
	WHERE h.MARKET_NUMBER = @MARKET_NUMBER 
	AND h.STATION_NUMBER IN (SELECT items FROM dbo.udf_split_list(@STATION_CODES, ','))
	AND (h.DEMO_NUMBER = @PRIMARY_DEMO_NUMBER OR (@SECONDARY_DEMO_NUMBER IS NOT NULL AND h.DEMO_NUMBER = @SECONDARY_DEMO_NUMBER))
	AND (h.COMSCORE_TV_BOOK_ID = @SHARE_BOOK_ID OR (@SIU_BOOK_ID IS NOT NULL AND h.COMSCORE_TV_BOOK_ID = @SIU_BOOK_ID))

	SELECT * FROM @tt
	WHERE BookID = @SHARE_BOOK_ID

END
GO
