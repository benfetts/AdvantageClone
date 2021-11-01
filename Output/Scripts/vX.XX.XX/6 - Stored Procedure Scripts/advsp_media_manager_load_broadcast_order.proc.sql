CREATE PROCEDURE [dbo].[advsp_media_manager_load_broadcast_order]
	@UserCode AS varchar(100),
	@OrderNumber AS integer,
	@LineNumbers AS varchar(MAX),
	@MediaType as char(1),
	@ShowEmptyWeeks bit = 0,
	@ExchangeRate decimal(12, 6) = 1
AS

DECLARE @LocationHeader varchar(max),
		@LocationFooter varchar(max),
		@MinWeekdate smalldatetime,
		@MaxRevision smallint,
		@MaxWeekdate smalldatetime,
		@DailyMaxWeekdate smalldatetime,
		@CreatedFromWorkSheet bit,
		@NielsenCopyrightTV bit,
		@NielsenCopyrightRadio bit

DECLARE @Details TABLE (
	StartWeek smalldatetime NULL,
	StartWeek2 smalldatetime NULL,
	StartWeek3 smalldatetime NULL,
	StartWeek4 smalldatetime NULL,
	StartWeek5 smalldatetime NULL,
	StartWeek6 smalldatetime NULL,
	StartWeek7 smalldatetime NULL,
	StartWeek8 smalldatetime NULL,
	StartWeek9 smalldatetime NULL,
	StartWeek10 smalldatetime NULL,
	StartWeek11 smalldatetime NULL,
	StartWeek12 smalldatetime NULL,
	StartWeek13 smalldatetime NULL,
	Cycle int NOT NULL,
	LineNumber int NULL,
	SpotsWeek1 int NULL,
	SpotsWeek2 int NULL,
	SpotsWeek3 int NULL,
	SpotsWeek4 int NULL,
	SpotsWeek5 int NULL,
	SpotsWeek6 int NULL,
	SpotsWeek7 int NULL,
	SpotsWeek8 int NULL,
	SpotsWeek9 int NULL,
	SpotsWeek10 int NULL,
	SpotsWeek11 int NULL,
	SpotsWeek12 int NULL,
	SpotsWeek13 int NULL,
	TotalSpots int NULL,
	MakeGoodNumber int NULL,
	CostRate decimal(16,4) NULL
)

DECLARE @LineDetails TABLE (
	OrderNumber int NOT NULL,
	Programming varchar(50) NULL,
	[Days] varchar(100) NULL,
	AirTime varchar(21) NULL,
	[Length] smallint NULL,
	--NetChargeDescription varchar(30) NULL,
	--DiscountDescription varchar(30) NULL,
	ChargeTo varchar(100) NULL,
	CableNetwork varchar(10) NULL,
	Daypart varchar(6) NULL,
	AddedValue char(2) NULL,
	Bookend varchar(8) NULL,
	Remarks varchar(254) NULL,
	LineNumber int NULL,
	PrimaryRating decimal(10,2) NULL,
	PrimaryCPP decimal(10,2) NULL,
	Demographic varchar(50) NULL,
	MakeGoodNumber int NULL,
	CreatedFromWorkSheet bit NULL,
	ShowNielsenCopyright bit NULL,
	CostRate decimal(16,4) NULL,
	[PrimaryCPM] decimal(19,2) NULL,
	[PrimaryImpressions] bigint NULL,
	LineCancelled smallint
)

DECLARE @DATE_SPOTS TABLE (
	ODATE smalldatetime NOT NULL,
	SPOTS int NOT NULL,
	LINE_NUMBER int NULL,
	ROWNUM int NULL,
	CYCLE int NULL,
	MAKEGOOD_NUMBER int NULL, 
	RATE decimal(16,4) NULL
)

DECLARE @DATE_ID TABLE (
	ROWNUM int IDENTITY(0,1) NOT NULL,
	ODATE smalldatetime NOT NULL
)

DECLARE @MBDETAIL_REV TABLE (
	REVISION_NUMBER int NOT NULL,
	MEDIA_BROADCAST_WORKSHEET_MARKET_ID int NOT NULL
)

DECLARE @MBDETAIL TABLE (
	REVISION_NUMBER int NOT NULL,
	ORDER_NBR int NOT NULL,
	ORDER_LINE_NBR int NOT NULL,
	MAKEGOOD_NUMBER int NOT NULL,
	PRIMARY_RATING decimal(10,2) NOT NULL,
	PRIMARY_CPP decimal(10,2) NOT NULL,
	PRIMARY_CPM decimal(19,2) NOT NULL,
	PRIMARY_IMPRESSIONS bigint NOT NULL,
	[DESCRIPTION] varchar(50) NULL,
	PRIMARY_AQH_RATING decimal(19,1) NOT NULL,
	PRIMARY_AQH bigint NOT NULL,
	[DAYS] varchar(100) NOT NULL
)

SELECT
		@LocationHeader = 
				CASE WHEN PRT_NAME = 1 AND [NAME] IS NOT NULL THEN COALESCE([NAME],'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR1 = 1 AND ADDRESS1 IS NOT NULL THEN COALESCE(ADDRESS1,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR2 = 1 AND ADDRESS2 IS NOT NULL THEN COALESCE(ADDRESS2,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_CITY = 1 AND CITY IS NOT NULL THEN COALESCE(CITY,'') + ', ' ELSE '' END +
				CASE WHEN PRT_STATE = 1 AND [STATE] IS NOT NULL THEN COALESCE([STATE],'') + ' ' ELSE '' END +
				CASE WHEN PRT_ZIP = 1 AND ZIP IS NOT NULL THEN COALESCE(ZIP,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_PHONE = 1 AND PHONE IS NOT NULL THEN COALESCE(PHONE,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_FAX = 1 AND FAX IS NOT NULL THEN COALESCE(FAX,'') + ' Fax ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_EMAIL = 1 AND EMAIL IS NOT NULL THEN COALESCE(EMAIL,'') + ' ' + CHAR(149) + ' ' ELSE '' END,
		@LocationFooter = 
				CASE WHEN PRT_NAME_FTR = 1 AND [NAME] IS NOT NULL THEN COALESCE([NAME],'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR1_FTR = 1 AND ADDRESS1 IS NOT NULL THEN COALESCE(ADDRESS1,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR2_FTR = 1 AND ADDRESS2 IS NOT NULL THEN COALESCE(ADDRESS2,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_CITY_FTR = 1 AND CITY IS NOT NULL THEN COALESCE(CITY,'') + ', ' ELSE '' END +
				CASE WHEN PRT_STATE_FTR = 1 AND [STATE] IS NOT NULL THEN COALESCE([STATE],'') + ' ' ELSE '' END +
				CASE WHEN PRT_ZIP_FTR = 1 AND ZIP IS NOT NULL THEN COALESCE(ZIP,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_PHONE_FTR = 1 AND PHONE IS NOT NULL THEN COALESCE(PHONE,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_FAX_FTR = 1 AND FAX IS NOT NULL THEN COALESCE(FAX,'') + ' Fax ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_EMAIL_FTR = 1 AND EMAIL IS NOT NULL THEN COALESCE(EMAIL,'') + ' ' + CHAR(149) + ' ' ELSE '' END
FROM dbo.LOCATIONS l
	INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.LOCATION_ID = l.ID AND UPPER(mpd.[USER_ID]) = UPPER(@UserCode) AND mpd.MEDIA_TYPE = @MediaType 

SET DATEFIRST 1;

SET @CreatedFromWorkSheet = 0
SET @NielsenCopyrightTV = 0
set @NielsenCopyrightRadio = 0

IF EXISTS(SELECT 1 FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD
		INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
		WHERE ORDER_NBR = @OrderNumber)
	SET @CreatedFromWorkSheet = 1
	
INSERT INTO @MBDETAIL_REV
SELECT 
	MAX(REVISION_NUMBER) as REVISION_NUMBER, 
	MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
FROM 
	[dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD
	INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
WHERE
	MBWMDD.ORDER_NBR = @OrderNumber
GROUP BY 
	MBWMDD.ORDER_NBR, 
	MBWMDD.ORDER_LINE_NBR, 
	MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID


INSERT INTO @MBDETAIL
SELECT MAX(MBWMD.REVISION_NUMBER) as REVISION_NUMBER, MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR, MBWMD.MAKEGOOD_NUMBER, MBWMD.PRIMARY_RATING, MBWMD.PRIMARY_CPP, MBWMD.PRIMARY_CPM, MBWMD.PRIMARY_IMPRESSIONS, MD.[DESCRIPTION],
	MBWMD.PRIMARY_AQH_RATING, MBWMD.PRIMARY_AQH, MBWMD.[DAYS]
FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD
	INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	INNER JOIN @MBDETAIL_REV MBD_REV ON MBD_REV.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND MBD_REV.REVISION_NUMBER = MBWMD.REVISION_NUMBER
	INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET] MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID 
	LEFT OUTER JOIN [dbo].[MEDIA_DEMO] MD ON MD.MEDIA_DEMO_ID = MBW.PRIMARY_MEDIA_DEMO_ID 
WHERE MBWMDD.ORDER_NBR = @OrderNumber
GROUP BY MBWMDD.ORDER_NBR, MBWMDD.ORDER_LINE_NBR, MBWMD.MAKEGOOD_NUMBER, MBWMD.PRIMARY_RATING, MBWMD.PRIMARY_CPP, MBWMD.PRIMARY_CPM, MBWMD.PRIMARY_IMPRESSIONS, MD.[DESCRIPTION],
	MBWMD.PRIMARY_AQH_RATING, MBWMD.PRIMARY_AQH, MBWMD.[DAYS]

IF EXISTS(SELECT 1
		FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD
			INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
		WHERE ORDER_NBR = @OrderNumber
		AND SHAREBOOK_NIELSEN_TV_BOOK_ID IS NOT NULL
		AND MBWMD.REVISION_NUMBER = (SELECT TOP 1 REVISION_NUMBER FROM @MBDETAIL))
	SET @NielsenCopyrightTV = 1

IF EXISTS(SELECT 1
		FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD
			INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
			INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
		WHERE ORDER_NBR = @OrderNumber
		AND NIELSEN_RADIO_PERIOD_ID1 IS NOT NULL
		AND MBWMD.REVISION_NUMBER = (SELECT TOP 1 REVISION_NUMBER FROM @MBDETAIL))
	SET @NielsenCopyrightRadio = 1

IF @MediaType = 'T' BEGIN

	INSERT @DATE_SPOTS (ODATE, SPOTS, LINE_NUMBER, MAKEGOOD_NUMBER, RATE)
	SELECT DATEX, SUM(SPOTS), LINENUM, MAKEGOOD_NUMBER, CALCRATE
	FROM (
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE1) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE1) -1), DATE1) ELSE DATE1 END,
				SPOTS = SPOTS1, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND DATE1 IS NOT NULL
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		UNION ALL 
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE2) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE2) -1), DATE2) ELSE DATE2 END,
				SPOTS = SPOTS2, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND DATE2 IS NOT NULL
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE3) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE3) -1), DATE3) ELSE DATE3 END,
				SPOTS = SPOTS3, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE3 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE4) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE4) -1), DATE4) ELSE DATE4 END,
				SPOTS = SPOTS4, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE4 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE5) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE5) -1), DATE5) ELSE DATE5 END,
				SPOTS = SPOTS5, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE5 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE6) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE6) -1), DATE6) ELSE DATE6 END,
				SPOTS = SPOTS6, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE6 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE7) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE7) -1), DATE7) ELSE DATE7 END,
				SPOTS = SPOTS7, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.TV_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE7 IS NOT NULL
	) details
	GROUP BY DATEX, SPOTS, LINENUM, MAKEGOOD_NUMBER, CALCRATE

	IF @ShowEmptyWeeks = 1
		INSERT @DATE_SPOTS (ODATE, SPOTS)
		SELECT BRD_WEEK_START, 0
		FROM dbo.fn_BroadcastCal2('01/01/2000')
		WHERE BRD_WEEK_START >= (SELECT MIN([START_DATE]) FROM dbo.TV_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1)
		AND BRD_WEEK_END <= (SELECT MAX(END_DATE) FROM dbo.TV_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1)
		AND BRD_WEEK_START NOT IN (SELECT DISTINCT ODATE FROM @DATE_SPOTS)

	INSERT INTO @DATE_ID (ODATE) 
	SELECT DISTINCT ODATE
	FROM @DATE_SPOTS
	ORDER BY ODATE

	UPDATE @DATE_SPOTS SET ROWNUM = di.ROWNUM 
	FROM @DATE_SPOTS ds
		INNER JOIN @DATE_ID di ON ds.ODATE = di.ODATE 

	UPDATE @DATE_SPOTS SET CYCLE = ROWNUM / 13, ROWNUM = ROWNUM % 13
	
	SELECT
			@MinWeekdate = MIN(MinWeekdate),
			@MaxRevision = MAX(REV_NBR),
			@MaxWeekdate = MAX(WeekdateEnd),
			@DailyMaxWeekdate = MAX(MaxWeekdate)
	FROM (
		SELECT 
			[Weekdate] = weekdate,
			dtl.REV_NBR,
			[WeekdateEnd] = DATEADD(d,6,weekdate),
			MinWeekdate = (
				SELECT MIN(D)
				FROM (VALUES (DATE1), (DATE2), (DATE3), (DATE4), (DATE5), (DATE6), (DATE7)) AS v (D)
			),
			MaxWeekdate = (
				SELECT MAX(D)
				FROM (VALUES (DATE1), (DATE2), (DATE3), (DATE4), (DATE5), (DATE6), (DATE7)) AS v (D)
			)
		FROM dbo.TV_DETAIL dtl
			INNER JOIN dbo.fn_BroadcastCal() bc ON dtl.YEAR_NBR = bc.brd_year
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		--AND COALESCE(LINE_CANCELLED, 0) = 0
		AND (
			(dtl.DATE1 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE2 IS NOT NULL AND dtl.DATE2 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE3 IS NOT NULL AND dtl.DATE3 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE4 IS NOT NULL AND dtl.DATE4 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE5 IS NOT NULL AND dtl.DATE5 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE6 IS NOT NULL AND dtl.DATE6 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE7 IS NOT NULL AND dtl.DATE7 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			)
	) Weekdates
	
	INSERT @Details
	SELECT DISTINCT
		[StartWeek] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 0 AND COALESCE(MAKEGOOD_NUMBER,0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek2] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 1 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek3] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 2 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek4] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 3 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek5] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 4 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek6] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 5 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek7] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 6 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek8] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 7 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek9] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 8 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek10] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 9 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek11] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 10 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek12] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 11 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek13] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 12 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[Cycle] = ds.CYCLE,
		[LineNumber] = ds.LINE_NUMBER, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		[MakeGoodNumber] = ds.MAKEGOOD_NUMBER,
		CostRate = ds.RATE
	FROM @DATE_SPOTS ds
	
	UPDATE dtl SET 
		SpotsWeek1 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 0 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek2 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 1 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek3 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 2 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek4 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 3 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek5 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 4 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek6 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 5 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek7 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 6 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek8 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 7 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek9 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 8 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek10 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 9 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek11 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 10 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek12 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 11 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek13 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 12 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0))
	FROM @Details dtl

	INSERT @LineDetails 
	SELECT DISTINCT
		OrderNumber = dtl.ORDER_NBR,
		[Programming] = ISNULL(PROGRAMMING, ''),
		[Days] = CASE 
					WHEN EXISTS(SELECT 1 FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR) THEN
						(SELECT [DAYS] FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR)
					ELSE
						CASE
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 AND dtl.SATURDAY = 1 AND  dtl.SUNDAY = 1 THEN 'M-Su'
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 AND dtl.SATURDAY = 1 THEN 'M-Sa'
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 THEN 'M-F'
							ELSE
								CASE dtl.MONDAY
									WHEN 1 THEN 'M'
									ELSE ''
								END +
								CASE dtl.TUESDAY
									WHEN 1 THEN 'Tu'
									ELSE ''
								END +
								CASE dtl.WEDNESDAY
									WHEN 1 THEN 'W'
									ELSE ''
								END +
								CASE dtl.THURSDAY
									WHEN 1 THEN 'Th'
									ELSE ''
								END +
								CASE dtl.FRIDAY
									WHEN 1 THEN 'F'
									ELSE ''
								END +
								CASE dtl.SATURDAY
									WHEN 1 THEN 'Sa'
									ELSE ''
								END +
								CASE dtl.SUNDAY
									WHEN 1 THEN 'Su'
									ELSE ''
								END
							END
					END,
		[AirTime] = CASE WHEN ISDATE(dtl.START_TIME) = 1 AND ISDATE(END_TIME) = 1 THEN
						CASE WHEN DATEPART(mi,START_TIME) = 0 THEN 
							CASE WHEN DATEPART(hh,START_TIME) = 0 THEN '12a-'
									WHEN DATEPART(hh,START_TIME) > 12 THEN CAST(DATEPART(hh,START_TIME) - 12 as varchar) + 'p-'
									WHEN DATEPART(hh,START_TIME) = 12 THEN CAST(DATEPART(hh,START_TIME) as varchar) + 'p-'
									ELSE CAST(DATEPART(hh,START_TIME) as varchar) + 'a-'
									END
						ELSE 
							CASE WHEN DATEPART(hh,START_TIME) = 0 THEN '12' + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'a-'
	 								WHEN DATEPART(hh,START_TIME) > 12 THEN CAST(DATEPART(hh,START_TIME) - 12 as varchar) + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'p-'
									WHEN DATEPART(hh,START_TIME) = 12 THEN CAST(DATEPART(hh,START_TIME) as varchar) + 'p-'
									ELSE CAST(DATEPART(hh,START_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'a-'
									END
						END +
						CASE WHEN DATEPART(mi,END_TIME) = 0 THEN 
							CASE WHEN DATEPART(hh,END_TIME) = 0 THEN '12a'
									WHEN DATEPART(hh,END_TIME) > 12 THEN CAST(DATEPART(hh,END_TIME) - 12 as varchar) + 'p'
									WHEN DATEPART(hh,END_TIME) = 12 THEN CAST(DATEPART(hh,END_TIME) as varchar) + 'p'
									ELSE CAST(DATEPART(hh,END_TIME) as varchar) + 'a'
									END
						ELSE 
							CASE WHEN DATEPART(hh,END_TIME) = 0 THEN '12' + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'a'
	 								WHEN DATEPART(hh,END_TIME) > 12 THEN CAST(DATEPART(hh,END_TIME) - 12 as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'p'
									WHEN DATEPART(hh,END_TIME) = 12 THEN CAST(DATEPART(hh,END_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'p'
									ELSE CAST(DATEPART(hh,END_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'a'
									END
						END
					ELSE dtl.START_TIME + '-' + dtl.END_TIME
					END,
		[Length] = dtl.[LENGTH],
		--NetChargeDescription = COALESCE(NULLIF(dtl.NCDESC,''),'Net Charge'),
		--DiscountDescription = COALESCE(NULLIF(dtl.DISCOUNT_DESC,''),'Discount'),
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
						ELSE NULL
						END,
		[CableNetwork] = dtl.CABLE_NETWORK_STATION_CODE,
		[Daypart] = dp.DAY_PART_CODE,
		[AddedValue] = CASE WHEN dtl.ADDED_VALUE = 1 THEN 'AV' ELSE NULL END,
		[Bookend] = CASE WHEN dtl.BOOKEND = 1 THEN 'Bookend' ELSE NULL END,
		[Remarks] = COALESCE(dtl.REMARKS,''),
		[LineNumber] = COALESCE(dtl.LINK_LINE_NUMBER, dtl.LINE_NBR),
		[PrimaryRating] = (SELECT PRIMARY_RATING FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[PrimaryCPP] = (SELECT PRIMARY_CPP FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		Demographic = (SELECT [DESCRIPTION] FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[MakeGoodNumber] = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[CreatedFromWorkSheet] = @CreatedFromWorkSheet,
		[ShowNielsenCopyright] = @NielsenCopyrightTV,
		CostRate = dtl.RATE * @ExchangeRate,
		[PrimaryCPM] = (SELECT PRIMARY_CPM FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[PrimaryImpressions] = (SELECT PRIMARY_IMPRESSIONS FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		LineCancelled = COALESCE(dtl.LINE_CANCELLED, 0)
	FROM dbo.TV_DETAIL dtl
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON dtl.ORDER_NBR = vcc.ORDER_NBR AND dtl.LINE_NBR = vcc.LINE_NBR 
		LEFT OUTER JOIN dbo.DAY_PART dp ON dtl.DAY_PART_ID = dp.DAY_PART_ID
	WHERE dtl.ORDER_NBR = @OrderNumber
	AND dtl.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	AND dtl.ACTIVE_REV = 1
	--AND COALESCE(LINE_CANCELLED, 0) = 0

	SELECT 
		[OrderNumber],
		[ClientName],
		[DivisionName],
		[ProductionDescription],
		[CampaignName],
		[FlightDates],
		[MarketName],
		[Buyer],
		[OrderDescription],
		[NetGross],
		[VendorCode],
		[VendorName],
		[VendorRepCode1],
		[VendorRepCode2],
		[PrintDate],
		[AgencyComment],
		[AgencyCommentFontSize],
		[MaxRevision],
		[OrderLabel],
		[LocationHeader],
		[LocationFooter],
		[ShowShippingAddress],
		[PageHeaderLogoPath],
		[IncludeRep1],
		[RepLabel1],
		[IncludeRep2],
		[RepLabel2],
		[DefaultRep1Label],
		[DefaultRep2Label],
		[ExcludeEmployeeSignature],
		[OrderHeaderComment],
		Cycle,
		Programming,
		[Days],
		AirTime,
		[Length],
		CostRate,
		--NetChargeDescription,
		--DiscountDescription,
		ChargeTo,
		StartWeek,
		[OrderHeaderCommentOption],
		[BuyerEmployeeCode],
		CableNetwork,
		Daypart,
		AddedValue,
		Bookend,
		Remarks,
		PrimaryRating,
		PrimaryCPP,
		Demographic,
		SeparationPolicy,
		MakeGoodNumber,
		CreatedFromWorkSheet,
		MaxWeekdate,
		ShowNielsenCopyright,
		[FlightStartDate],
		[FlightEndDate],
		StartWeek2,
		StartWeek3,
		StartWeek4,
		StartWeek5,
		StartWeek6,
		StartWeek7,
		StartWeek8,
		StartWeek9,
		StartWeek10,
		StartWeek11,
		StartWeek12,
		StartWeek13,
		PrimaryCPM,
		PrimaryImpressions,
		SpotsWeek1 = CAST(SUM(SpotsWeek1) as int),
		SpotsWeek2 = CAST(SUM(SpotsWeek2) as int),
		SpotsWeek3 = CAST(SUM(SpotsWeek3) as int),
		SpotsWeek4 = CAST(SUM(SpotsWeek4) as int),
		SpotsWeek5 = CAST(SUM(SpotsWeek5) as int),
		SpotsWeek6 = CAST(SUM(SpotsWeek6) as int),
		SpotsWeek7 = CAST(SUM(SpotsWeek7) as int),
		SpotsWeek8 = CAST(SUM(SpotsWeek8) as int),
		SpotsWeek9 = CAST(SUM(SpotsWeek9) as int),
		SpotsWeek10 = CAST(SUM(SpotsWeek10) as int),
		SpotsWeek11 = CAST(SUM(SpotsWeek11) as int),
		SpotsWeek12 = CAST(SUM(SpotsWeek12) as int),
		SpotsWeek13 = CAST(SUM(SpotsWeek13) as int),
		TotalSpots = CAST(SUM(TotalSpots) as int),
		GRP = CAST(SUM(TotalSpots) as int) * COALESCE(PrimaryRating, 0),
		Amount = CAST(SUM(TotalSpots) as int) * COALESCE(CostRate, 0),
		MediaType = @MediaType,
		LineNumber = MIN(LineNumber),
		LineCancelled,
		ClientAddress1,
		ClientAddress2,
		ClientCity,
		ClientState,
		ClientZip
	FROM (
		SELECT
			[OrderNumber] = h.ORDER_NBR,
			[ClientName] = CASE WHEN mpd.PRINT_CLIENT_NAME = 1 THEN c.CL_NAME ELSE NULL END,
			[DivisionName] = CASE WHEN (mpd.PRINT_DIVISION_NAME = 1 AND c.CL_NAME <> d.DIV_NAME) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND mpd.PRINT_DIVISION_NAME = 1) THEN d.DIV_NAME ELSE NULL END,
			[ProductionDescription] = CASE WHEN (mpd.PRINT_PRODUCT_DESCRIPTION = 1 AND d.DIV_NAME <> p.PRD_DESCRIPTION) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND COALESCE(mpd.PRINT_DIVISION_NAME, 0) = 0 AND mpd.PRINT_PRODUCT_DESCRIPTION = 1) THEN p.PRD_DESCRIPTION ELSE NULL END,
			[CampaignName] = cmp.CMP_NAME,
			[FlightDates] = CASE WHEN UNITS = 'BM' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@MaxWeekdate,101) + '  (' + CAST((DATEDIFF(DAY, @MinWeekdate, @MaxWeekdate) + 1) / 7 as varchar(4)) + ' weeks)'
								 WHEN UNITS = 'CM' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@MaxWeekdate,101) + '  (' + CAST(DATEDIFF(WK, @MinWeekdate, @MaxWeekdate) as varchar) + ' weeks)'
								 WHEN UNITS = 'DB' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@DailyMaxWeekdate,101)
							END,
			[MarketName] = m.MARKET_DESC,
			[Buyer] = h.BUYER,
			[OrderDescription] = h.ORDER_DESC,
			[NetGross] = h.NET_GROSS,
			[VendorCode] = h.VN_CODE,
			[VendorName] = v.VN_NAME,
			[VendorRepCode1] = h.VR_CODE,
			[VendorRepCode2] = h.VR_CODE2,
			[PrintDate] = CASE mpd.DATE_OVERRIDE + 1
							WHEN 1 THEN getdate() 
							WHEN 2 THEN h.ORDER_DATE
							WHEN 3 THEN h.CREATE_DATE END,
			[AgencyComment] = CAST(CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'T') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'T')
									WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
									ELSE (SELECT TV_COMMENT FROM dbo.AGENCY) END as varchar(MAX)),
			[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'T') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'T') ELSE NULL END,
			[MaxRevision] = @MaxRevision,
			[OrderLabel] =  CASE
								WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
								WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'TELEVISION QUOTE REQUEST'
								WHEN mpd.TITLE_OPTION = 'O' AND @MaxRevision > 0 THEN 'TELEVISION ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																		FROM dbo.TV_DETAIL 
																		WHERE ORDER_NBR = @OrderNumber 
																		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		AND ACTIVE_REV = 1
																		AND REV_NBR > 0) THEN 'TELEVISION ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																		FROM dbo.TV_DETAIL 
																		WHERE ORDER_NBR = @OrderNumber 
																		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		AND ACTIVE_REV = 1
																		AND LINE_CANCELLED = 1) THEN 'TELEVISION ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' THEN 'TELEVISION ORDER'
								WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
								WHEN mpd.TITLE_OPTION <> 'O' AND @MaxRevision > 0 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																		 FROM dbo.TV_DETAIL 
																		 WHERE ORDER_NBR = @OrderNumber 
																		 AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		 AND ACTIVE_REV = 1
																		 AND REV_NBR > 0) THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																		 FROM dbo.TV_DETAIL 
																		 WHERE ORDER_NBR = @OrderNumber 
																		 AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		 AND ACTIVE_REV = 1
																		 AND LINE_CANCELLED = 1) THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER'
							END,
			[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 AND LEN(@LocationHeader) > 1 THEN LEFT(@LocationHeader, LEN(@LocationHeader) - 1) ELSE NULL END,
			[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 AND LEN(@LocationFooter) > 1 THEN LEFT(@LocationFooter, LEN(@LocationFooter) - 1) ELSE NULL END,
			[ShowShippingAddress] = mpd.SHIP_ADDR_FLAG,
			[PageHeaderLogoPath] = l.LOGO_PATH_LAND,
			[IncludeRep1] = mpd.INCLUDE_REP1,
			[RepLabel1] = mpd.REP_LABEL1,
			[IncludeRep2] = mpd.INCLUDE_REP2,
			[RepLabel2] = mpd.REP_LABEL2,
			[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
			[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
			[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
			[OrderHeaderComment] = CAST(h.ORDER_COMMENT as varchar(MAX)),
			D.SpotsWeek1,
			D.SpotsWeek2,
			D.SpotsWeek3,
			D.SpotsWeek4,
			D.SpotsWeek5,
			D.SpotsWeek6,
			D.SpotsWeek7,
			D.SpotsWeek8,
			D.SpotsWeek9,
			D.SpotsWeek10,
			D.SpotsWeek11,
			D.SpotsWeek12,
			D.SpotsWeek13,
			TotalSpots = COALESCE(D.SpotsWeek1,0) + COALESCE(D.SpotsWeek2,0) + COALESCE(D.SpotsWeek3,0) + COALESCE(D.SpotsWeek4,0) + COALESCE(D.SpotsWeek5,0) + COALESCE(D.SpotsWeek6,0) +
				COALESCE(D.SpotsWeek7,0) + COALESCE(D.SpotsWeek8,0) + COALESCE(D.SpotsWeek9,0) + COALESCE(D.SpotsWeek10,0) + COALESCE(D.SpotsWeek11,0) + COALESCE(D.SpotsWeek12,0) + COALESCE(D.SpotsWeek13,0),
			D.Cycle,
			LD.Programming,
			[Days] = NULLIF(LD.[Days],''),
			LD.AirTime,
			LD.[Length],
			D.CostRate,
			--LD.NetChargeDescription,
			--LD.DiscountDescription,
			LD.ChargeTo,
			StartWeek = CASE WHEN D.StartWeek IS NULL THEN (SELECT TOP 1 StartWeek FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek IS NOT NULL)
						ELSE D.StartWeek
						END,
			[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
			[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
			LD.CableNetwork,
			LD.Daypart,
			AddedValue = CASE WHEN mpd.ADDED_VALUE = 1 THEN NULLIF(LD.AddedValue,'') ELSE NULL END,
			Bookend = CASE WHEN mpd.BOOKENDS = 1 THEN LD.Bookend ELSE NULL END,
			LD.Remarks,
			D.LineNumber,
			LD.PrimaryRating,
			LD.PrimaryCPP,
			LD.Demographic,
			SeparationPolicy = CASE WHEN mpd.SEPARATION_POLICY = 1 THEN [dbo].[advfn_spot_separation_policy](@OrderNumber, @MediaType) ELSE NULL END,
			MakeGoodNumber = COALESCE(D.MakeGoodNumber, 0),
			CreatedFromWorkSheet = CAST(COALESCE(LD.CreatedFromWorkSheet, 0) as bit),
			MaxWeekdate = @MaxWeekdate,
			ShowNielsenCopyright = CAST(COALESCE(LD.ShowNielsenCopyright, 0) as bit),
			[FlightStartDate] = h.[START_DATE],
			[FlightEndDate] = h.END_DATE,
			StartWeek2 = CASE WHEN D.StartWeek2 IS NULL THEN (SELECT TOP 1 StartWeek2 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek2 IS NOT NULL)
						ELSE D.StartWeek2
						END,
			StartWeek3 = CASE WHEN D.StartWeek3 IS NULL THEN (SELECT TOP 1 StartWeek3 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek3 IS NOT NULL)
						ELSE D.StartWeek3
						END,
			StartWeek4 = CASE WHEN D.StartWeek4 IS NULL THEN (SELECT TOP 1 StartWeek4 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek4 IS NOT NULL)
						ELSE D.StartWeek4
						END,
			StartWeek5 = CASE WHEN D.StartWeek5 IS NULL THEN (SELECT TOP 1 StartWeek5 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek5 IS NOT NULL)
						ELSE D.StartWeek5
						END,
			StartWeek6 = CASE WHEN D.StartWeek6 IS NULL THEN (SELECT TOP 1 StartWeek6 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek6 IS NOT NULL)
						ELSE D.StartWeek6
						END,
			StartWeek7 = CASE WHEN D.StartWeek7 IS NULL THEN (SELECT TOP 1 StartWeek7 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek7 IS NOT NULL)
						ELSE D.StartWeek7
						END,
			StartWeek8 = CASE WHEN D.StartWeek8 IS NULL THEN (SELECT TOP 1 StartWeek8 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek8 IS NOT NULL)
						ELSE D.StartWeek8
						END,
			StartWeek9 = CASE WHEN D.StartWeek9 IS NULL THEN (SELECT TOP 1 StartWeek9 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek9 IS NOT NULL)
						ELSE D.StartWeek9
						END,
			StartWeek10 = CASE WHEN D.StartWeek10 IS NULL THEN (SELECT TOP 1 StartWeek10 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek10 IS NOT NULL)
						ELSE D.StartWeek10
						END,
			StartWeek11 = CASE WHEN D.StartWeek11 IS NULL THEN (SELECT TOP 1 StartWeek11 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek11 IS NOT NULL)
						ELSE D.StartWeek11
						END,
			StartWeek12 = CASE WHEN D.StartWeek12 IS NULL THEN (SELECT TOP 1 StartWeek12 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek12 IS NOT NULL)
						ELSE D.StartWeek12
						END,
			StartWeek13 = CASE WHEN D.StartWeek13 IS NULL THEN (SELECT TOP 1 StartWeek13 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek13 IS NOT NULL)
						ELSE D.StartWeek13
						END,
			LD.PrimaryCPM,
			LD.PrimaryImpressions,
			LD.LineCancelled,
			ClientAddress1 = c.CL_ADDRESS1,
			ClientAddress2 = c.CL_ADDRESS2,
			ClientCity = c.CL_CITY,
			ClientState = c.CL_STATE,        
			ClientZip = c.CL_ZIP
		FROM
			@Details D
				INNER JOIN @LineDetails LD ON D.LineNumber = LD.LineNumber AND COALESCE(D.MakeGoodNumber, 0) = COALESCE(LD.MakeGoodNumber, 0) AND D.CostRate = LD.CostRate
				INNER JOIN dbo.TV_HDR h ON h.ORDER_NBR = LD.OrderNumber 
				LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE 
				INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
				INNER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE 
				INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE 
				INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON UPPER(mpd.[USER_ID]) = UPPER(@UserCode) AND mpd.MEDIA_TYPE = @MediaType 
				LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
				LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE 
				LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
				LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
				LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		WHERE h.ORDER_NBR = @OrderNumber
	) Details
	GROUP BY
		[OrderNumber],
		[ClientName],
		[DivisionName],
		[ProductionDescription],
		[CampaignName],
		[FlightDates],
		[MarketName],
		[Buyer],
		[OrderDescription],
		[NetGross],
		[VendorCode],
		[VendorName],
		[VendorRepCode1],
		[VendorRepCode2],
		[PrintDate],
		[AgencyComment],
		[AgencyCommentFontSize],
		[MaxRevision],
		[OrderLabel],
		[LocationHeader],
		[LocationFooter],
		[ShowShippingAddress],
		[PageHeaderLogoPath],
		[IncludeRep1],
		[RepLabel1],
		[IncludeRep2],
		[RepLabel2],
		[DefaultRep1Label],
		[DefaultRep2Label],
		[ExcludeEmployeeSignature],
		[OrderHeaderComment],
		Cycle,
		Programming,
		[Days],
		AirTime,
		[Length],
		CostRate,
		--NetChargeDescription,
		--DiscountDescription,
		ChargeTo,
		StartWeek,
		[OrderHeaderCommentOption],
		[BuyerEmployeeCode],
		CableNetwork,
		Daypart,
		AddedValue,
		Bookend,
		Remarks,
		PrimaryRating,
		PrimaryCPP,
		Demographic,
		SeparationPolicy,
		MakeGoodNumber,
		CreatedFromWorkSheet,
		MaxWeekdate,
		ShowNielsenCopyright,
		[FlightStartDate],
		[FlightEndDate],
		StartWeek2,
		StartWeek3,
		StartWeek4,
		StartWeek5,
		StartWeek6,
		StartWeek7,
		StartWeek8,
		StartWeek9,
		StartWeek10,
		StartWeek11,
		StartWeek12,
		StartWeek13,
		PrimaryCPM,
		PrimaryImpressions,
		LineCancelled,
		ClientAddress1,
		ClientAddress2,
		ClientCity,
		ClientState,
		ClientZip
	ORDER BY 
		Cycle

END ELSE IF @MediaType = 'R' BEGIN

	INSERT @DATE_SPOTS (ODATE, SPOTS, LINE_NUMBER, MAKEGOOD_NUMBER, RATE)
	SELECT DATEX, SUM(SPOTS), LINENUM, MAKEGOOD_NUMBER, CALCRATE
	FROM (
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE1) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE1) -1), DATE1) ELSE DATE1 END,
				SPOTS = SPOTS1, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND DATE1 IS NOT NULL
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		UNION ALL 
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE2) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE2) -1), DATE2) ELSE DATE2 END,
				SPOTS = SPOTS2, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND DATE2 IS NOT NULL
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE3) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE3) -1), DATE3) ELSE DATE3 END,
				SPOTS = SPOTS3, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE3 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE4) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE4) -1), DATE4) ELSE DATE4 END,
				SPOTS = SPOTS4, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE4 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE5) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE5) -1), DATE5) ELSE DATE5 END,
				SPOTS = SPOTS5, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE5 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE6) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE6) -1), DATE6) ELSE DATE6 END,
				SPOTS = SPOTS6, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE6 IS NOT NULL
		UNION ALL
		SELECT DATEX = CASE WHEN DATEPART(dw, DATE7) <> 1 THEN DATEADD(d, - (DATEPART(dw, DATE7) -1), DATE7) ELSE DATE7 END,
				SPOTS = SPOTS7, LINENUM = COALESCE(LINK_LINE_NUMBER, LINE_NBR),
			MAKEGOOD_NUMBER = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
			CALCRATE = RATE * @ExchangeRate
		FROM dbo.RADIO_DETAIL dtl
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		AND DATE7 IS NOT NULL
	) details
	GROUP BY DATEX, SPOTS, LINENUM, MAKEGOOD_NUMBER, CALCRATE
	
	IF @ShowEmptyWeeks = 1
		INSERT @DATE_SPOTS (ODATE, SPOTS)
		SELECT BRD_WEEK_START, 0
		FROM dbo.fn_BroadcastCal2('01/01/2000')
		WHERE BRD_YEAR BETWEEN (SELECT MIN(YEAR_NBR) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1) AND (SELECT MAX(YEAR_NBR) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1)
		AND BRD_MONTH BETWEEN (SELECT MIN(MONTH_NBR) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1) AND (SELECT MAX(MONTH_NBR) FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1)
		AND BRD_WEEK_START NOT IN (SELECT DISTINCT ODATE FROM @DATE_SPOTS)

	INSERT INTO @DATE_ID (ODATE) 
	SELECT DISTINCT ODATE
	FROM @DATE_SPOTS
	ORDER BY ODATE

	UPDATE @DATE_SPOTS SET ROWNUM = di.ROWNUM 
	FROM @DATE_SPOTS ds
		INNER JOIN @DATE_ID di ON ds.ODATE = di.ODATE 

	UPDATE @DATE_SPOTS SET CYCLE = ROWNUM / 13, ROWNUM = ROWNUM % 13
	
	SELECT
			@MinWeekdate = MIN(MinWeekdate),
			@MaxRevision = MAX(REV_NBR),
			@MaxWeekdate = MAX(WeekdateEnd),
			@DailyMaxWeekdate = MAX(MaxWeekdate)
	FROM (
		SELECT 
			[Weekdate] = weekdate,
			dtl.REV_NBR,
			[WeekdateEnd] = DATEADD(d,6,weekdate),
			MinWeekdate = (
				SELECT MIN(D)
				FROM (VALUES (DATE1), (DATE2), (DATE3), (DATE4), (DATE5), (DATE6), (DATE7)) AS v (D)
			),
			MaxWeekdate = (
				SELECT MAX(D)
				FROM (VALUES (DATE1), (DATE2), (DATE3), (DATE4), (DATE5), (DATE6), (DATE7)) AS v (D)
			)
		FROM dbo.RADIO_DETAIL dtl
			INNER JOIN dbo.fn_BroadcastCal() bc ON dtl.YEAR_NBR = bc.brd_year
		WHERE ORDER_NBR = @OrderNumber
		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
		AND ACTIVE_REV = 1
		--AND COALESCE(LINE_CANCELLED, 0) = 0
		AND (
			(dtl.DATE1 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE2 IS NOT NULL AND dtl.DATE2 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE3 IS NOT NULL AND dtl.DATE3 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE4 IS NOT NULL AND dtl.DATE4 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE5 IS NOT NULL AND dtl.DATE5 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE6 IS NOT NULL AND dtl.DATE6 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			OR
			(dtl.DATE7 IS NOT NULL AND dtl.DATE7 BETWEEN weekdate AND DATEADD(d,6,weekdate))
			)
	) Weekdates
	
	INSERT @Details
	SELECT DISTINCT
		[StartWeek] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 0 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek2] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 1 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek3] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 2 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek4] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 3 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek5] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 4 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek6] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 5 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek7] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 6 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek8] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 7 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek9] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 8 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek10] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 9 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek11] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 10 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek12] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 11 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[StartWeek13] = (SELECT MIN(ODATE) FROM @DATE_SPOTS WHERE CYCLE = ds.CYCLE AND ROWNUM = 12 AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(ds.MAKEGOOD_NUMBER, 0)),
		[Cycle] = ds.CYCLE,
		[LineNumber] = ds.LINE_NUMBER, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		[MakeGoodNumber] = ds.MAKEGOOD_NUMBER,
		CostRate = ds.RATE
	FROM @DATE_SPOTS ds
	
	UPDATE dtl SET 
		SpotsWeek1 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 0 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek2 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 1 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek3 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 2 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek4 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 3 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek5 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 4 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek6 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 5 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek7 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 6 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek8 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 7 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek9 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 8 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek10 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 9 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek11 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 10 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek12 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 11 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0)),
		SpotsWeek13 = (SELECT SUM(SPOTS) FROM @DATE_SPOTS WHERE CYCLE = dtl.Cycle AND LINE_NUMBER = dtl.LineNumber AND ROWNUM = 12 AND RATE = dtl.CostRate AND COALESCE(MAKEGOOD_NUMBER, 0) = COALESCE(dtl.MakeGoodNumber, 0))
	FROM @Details dtl

	INSERT @LineDetails 
	SELECT DISTINCT
		OrderNumber = dtl.ORDER_NBR,
		[Programming] = ISNULL(PROGRAMMING, ''),
		[Days] = CASE
					WHEN EXISTS(SELECT 1 FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR) THEN
						(SELECT [DAYS] FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR)
					ELSE
						CASE
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 AND dtl.SATURDAY = 1 AND  dtl.SUNDAY = 1 THEN 'M-Su'
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 AND dtl.SATURDAY = 1 THEN 'M-Sa'
							WHEN dtl.MONDAY = 1 AND dtl.TUESDAY = 1 AND dtl.WEDNESDAY = 1 AND dtl.THURSDAY = 1 AND dtl.FRIDAY = 1 THEN 'M-F'
							ELSE
								CASE dtl.MONDAY
									WHEN 1 THEN 'M'
									ELSE ''
								END +
								CASE dtl.TUESDAY
									WHEN 1 THEN 'Tu'
									ELSE ''
								END +
								CASE dtl.WEDNESDAY
									WHEN 1 THEN 'W'
									ELSE ''
								END +
								CASE dtl.THURSDAY
									WHEN 1 THEN 'Th'
									ELSE ''
								END +
								CASE dtl.FRIDAY
									WHEN 1 THEN 'F'
									ELSE ''
								END +
								CASE dtl.SATURDAY
									WHEN 1 THEN 'Sa'
									ELSE ''
								END +
								CASE dtl.SUNDAY
									WHEN 1 THEN 'Su'
									ELSE ''
								END
							END
					END,
		[AirTime] = CASE WHEN ISDATE(dtl.START_TIME) = 1 AND ISDATE(END_TIME) = 1 THEN
						CASE WHEN DATEPART(mi,START_TIME) = 0 THEN 
							CASE WHEN DATEPART(hh,START_TIME) = 0 THEN '12a-'
									WHEN DATEPART(hh,START_TIME) > 12 THEN CAST(DATEPART(hh,START_TIME) - 12 as varchar) + 'p-'
									WHEN DATEPART(hh,START_TIME) = 12 THEN CAST(DATEPART(hh,START_TIME) as varchar) + 'p-'
									ELSE CAST(DATEPART(hh,START_TIME) as varchar) + 'a-'
									END
						ELSE 
							CASE WHEN DATEPART(hh,START_TIME) = 0 THEN '12' + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'a-'
	 								WHEN DATEPART(hh,START_TIME) > 12 THEN CAST(DATEPART(hh,START_TIME) - 12 as varchar) + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'p-'
									WHEN DATEPART(hh,START_TIME) = 12 THEN CAST(DATEPART(hh,START_TIME) as varchar) + 'p-'
									ELSE CAST(DATEPART(hh,START_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,START_TIME) as varchar), 2) + 'a-'
									END
						END +
						CASE WHEN DATEPART(mi,END_TIME) = 0 THEN 
							CASE WHEN DATEPART(hh,END_TIME) = 0 THEN '12a'
									WHEN DATEPART(hh,END_TIME) > 12 THEN CAST(DATEPART(hh,END_TIME) - 12 as varchar) + 'p'
									WHEN DATEPART(hh,END_TIME) = 12 THEN CAST(DATEPART(hh,END_TIME) as varchar) + 'p'
									ELSE CAST(DATEPART(hh,END_TIME) as varchar) + 'a'
									END
						ELSE 
							CASE WHEN DATEPART(hh,END_TIME) = 0 THEN '12' + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'a'
	 								WHEN DATEPART(hh,END_TIME) > 12 THEN CAST(DATEPART(hh,END_TIME) - 12 as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'p'
									WHEN DATEPART(hh,END_TIME) = 12 THEN CAST(DATEPART(hh,END_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'p'
									ELSE CAST(DATEPART(hh,END_TIME) as varchar) + RIGHT('00' + CAST(DATEPART(mi,END_TIME) as varchar), 2) + 'a'
									END
						END
					ELSE dtl.START_TIME + '-' + dtl.END_TIME
					END,
		[Length] = dtl.[LENGTH],
		--NetChargeDescription = COALESCE(NULLIF(dtl.NCDESC,''),'Net Charge'),
		--DiscountDescription = COALESCE(NULLIF(dtl.DISCOUNT_DESC,''),'Discount'),
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
						ELSE NULL
						END,
		[CableNetwork] = NULL,
		[Daypart] = dp.DAY_PART_CODE,
		[AddedValue] = CASE WHEN dtl.ADDED_VALUE = 1 THEN 'AV' ELSE '' END,
		[Bookend] = NULL,
		[Remarks] = COALESCE(dtl.REMARKS,''),
		[LineNumber] = COALESCE(dtl.LINK_LINE_NUMBER, dtl.LINE_NBR),
		[PrimaryRating] = (SELECT PRIMARY_AQH_RATING FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[PrimaryCPP] = (SELECT PRIMARY_CPP FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		Demographic = (SELECT [DESCRIPTION] FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[MakeGoodNumber] = (SELECT MAKEGOOD_NUMBER FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[CreatedFromWorkSheet] = @CreatedFromWorkSheet,
		[ShowNielsenCopyright] = @NielsenCopyrightRadio,
		CostRate = dtl.RATE * @ExchangeRate,
		[PrimaryCPM] = (SELECT PRIMARY_CPM FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		[PrimaryImpressions] = (SELECT PRIMARY_AQH FROM @MBDETAIL WHERE ORDER_NBR = dtl.ORDER_NBR AND ORDER_LINE_NBR = dtl.LINE_NBR),
		LineCancelled = COALESCE(dtl.LINE_CANCELLED, 0)
	FROM dbo.RADIO_DETAIL dtl
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON dtl.ORDER_NBR = vcc.ORDER_NBR AND dtl.LINE_NBR = vcc.LINE_NBR 
		LEFT OUTER JOIN dbo.DAY_PART dp ON dtl.DAY_PART_ID = dp.DAY_PART_ID
	WHERE dtl.ORDER_NBR = @OrderNumber
	AND dtl.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	AND ACTIVE_REV = 1
	--AND COALESCE(LINE_CANCELLED, 0) = 0


	SELECT
		[OrderNumber],
		[ClientName],
		[DivisionName],
		[ProductionDescription],
		[CampaignName],
		[FlightDates],
		[MarketName],
		[Buyer],
		[OrderDescription],
		[NetGross],
		[VendorCode],
		[VendorName],
		[VendorRepCode1],
		[VendorRepCode2],
		[PrintDate],
		[AgencyComment],
		[AgencyCommentFontSize],
		[MaxRevision],
		[OrderLabel],
		[LocationHeader],
		[LocationFooter],
		[ShowShippingAddress],
		[PageHeaderLogoPath],
		[IncludeRep1],
		[RepLabel1],
		[IncludeRep2],
		[RepLabel2],
		[DefaultRep1Label],
		[DefaultRep2Label],
		[ExcludeEmployeeSignature],
		[OrderHeaderComment],
		Cycle,
		Programming,
		[Days],
		AirTime,
		[Length],
		CostRate,
		--NetChargeDescription,
		--DiscountDescription,
		ChargeTo,
		StartWeek,
		[OrderHeaderCommentOption],
		[BuyerEmployeeCode],
		CableNetwork,
		Daypart,
		AddedValue,
		Bookend,
		Remarks,
		PrimaryRating,
		PrimaryCPP,
		Demographic,
		SeparationPolicy,
		MakeGoodNumber,
		CreatedFromWorkSheet,
		MaxWeekdate,
		ShowNielsenCopyright,
		[FlightStartDate],
		[FlightEndDate],
		StartWeek2,
		StartWeek3,
		StartWeek4,
		StartWeek5,
		StartWeek6,
		StartWeek7,
		StartWeek8,
		StartWeek9,
		StartWeek10,
		StartWeek11,
		StartWeek12,
		StartWeek13,
		PrimaryCPM,
		PrimaryImpressions,
		SpotsWeek1 = CAST(SUM(SpotsWeek1) as int),
		SpotsWeek2 = CAST(SUM(SpotsWeek2) as int),
		SpotsWeek3 = CAST(SUM(SpotsWeek3) as int),
		SpotsWeek4 = CAST(SUM(SpotsWeek4) as int),
		SpotsWeek5 = CAST(SUM(SpotsWeek5) as int),
		SpotsWeek6 = CAST(SUM(SpotsWeek6) as int),
		SpotsWeek7 = CAST(SUM(SpotsWeek7) as int),
		SpotsWeek8 = CAST(SUM(SpotsWeek8) as int),
		SpotsWeek9 = CAST(SUM(SpotsWeek9) as int),
		SpotsWeek10 = CAST(SUM(SpotsWeek10) as int),
		SpotsWeek11 = CAST(SUM(SpotsWeek11) as int),
		SpotsWeek12 = CAST(SUM(SpotsWeek12) as int),
		SpotsWeek13 = CAST(SUM(SpotsWeek13) as int),
		TotalSpots = CAST(SUM(TotalSpots) as int),
		GRP = CAST(SUM(TotalSpots) as int) * COALESCE(PrimaryRating, 0),
		Amount = CAST(SUM(TotalSpots) as int) * COALESCE(CostRate, 0),
		MediaType = @MediaType,
		LineNumber = MIN(LineNumber),
		LineCancelled,
		ClientAddress1,
		ClientAddress2,
		ClientCity,
		ClientState,
		ClientZip
	FROM (
		SELECT
			[OrderNumber] = h.ORDER_NBR,
			[ClientName] = CASE WHEN mpd.PRINT_CLIENT_NAME = 1 THEN c.CL_NAME ELSE NULL END,
			[DivisionName] = CASE WHEN (mpd.PRINT_DIVISION_NAME = 1 AND c.CL_NAME <> d.DIV_NAME) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND mpd.PRINT_DIVISION_NAME = 1) THEN d.DIV_NAME ELSE NULL END,
			[ProductionDescription] = CASE WHEN (mpd.PRINT_PRODUCT_DESCRIPTION = 1 AND d.DIV_NAME <> p.PRD_DESCRIPTION) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND COALESCE(mpd.PRINT_DIVISION_NAME, 0) = 0 AND mpd.PRINT_PRODUCT_DESCRIPTION = 1) THEN p.PRD_DESCRIPTION ELSE NULL END,
			[CampaignName] = cmp.CMP_NAME,
			[FlightDates] = CASE WHEN UNITS = 'BM' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@MaxWeekdate,101) + '  (' + CAST((DATEDIFF(DAY, @MinWeekdate, @MaxWeekdate) + 1) / 7 as varchar(4)) + ' weeks)'
								 WHEN UNITS = 'CM' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@MaxWeekdate,101) + '  (' + CAST(DATEDIFF(WK, @MinWeekdate, @MaxWeekdate) as varchar) + ' weeks)'
								 WHEN UNITS = 'DB' THEN CONVERT(CHAR(10),@MinWeekdate,101) + ' - ' + CONVERT(char(10),@DailyMaxWeekdate,101)
							END,
			[MarketName] = m.MARKET_DESC,
			[Buyer] = h.BUYER,
			[OrderDescription] = h.ORDER_DESC,
			[NetGross] = h.NET_GROSS,
			[VendorCode] = h.VN_CODE,
			[VendorName] = v.VN_NAME,
			[VendorRepCode1] = h.VR_CODE,
			[VendorRepCode2] = h.VR_CODE2,
			[PrintDate] = CASE mpd.DATE_OVERRIDE + 1
							WHEN 1 THEN getdate() 
							WHEN 2 THEN h.ORDER_DATE
							WHEN 3 THEN h.CREATE_DATE END,
			[AgencyComment] = CAST(CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'R') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'R')
									WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
									ELSE (SELECT RADIO_COMMENT FROM dbo.AGENCY) END as varchar(MAX)),
			[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'R') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'R') ELSE NULL END,
			[MaxRevision] = @MaxRevision,
			[OrderLabel] =  CASE
								WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
								WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'RADIO QUOTE REQUEST'
								WHEN mpd.TITLE_OPTION = 'O' AND @MaxRevision > 0 THEN 'RADIO ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																		FROM dbo.RADIO_DETAIL 
																		WHERE ORDER_NBR = @OrderNumber 
																		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		AND ACTIVE_REV = 1
																		AND REV_NBR > 0) THEN 'RADIO ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																		FROM dbo.RADIO_DETAIL 
																		WHERE ORDER_NBR = @OrderNumber 
																		AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		AND ACTIVE_REV = 1
																		AND LINE_CANCELLED = 1) THEN 'RADIO ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION = 'O' THEN 'RADIO ORDER'
								WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
								WHEN mpd.TITLE_OPTION <> 'O' AND @MaxRevision > 0 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																		 FROM dbo.RADIO_DETAIL 
																		 WHERE ORDER_NBR = @OrderNumber 
																		 AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		 AND ACTIVE_REV = 1
																		 AND REV_NBR > 0) THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																		 FROM dbo.RADIO_DETAIL 
																		 WHERE ORDER_NBR = @OrderNumber 
																		 AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																		 AND ACTIVE_REV = 1
																		 AND LINE_CANCELLED = 1) THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
								WHEN mpd.TITLE_OPTION <> 'O' THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER'
							END,
			[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 AND LEN(@LocationHeader) > 1 THEN LEFT(@LocationHeader, LEN(@LocationHeader) - 1) ELSE NULL END,
			[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 AND LEN(@LocationFooter) > 1 THEN LEFT(@LocationFooter, LEN(@LocationFooter) - 1) ELSE NULL END,
			[ShowShippingAddress] = mpd.SHIP_ADDR_FLAG,
			[PageHeaderLogoPath] = l.LOGO_PATH_LAND,
			[IncludeRep1] = mpd.INCLUDE_REP1,
			[RepLabel1] = mpd.REP_LABEL1,
			[IncludeRep2] = mpd.INCLUDE_REP2,
			[RepLabel2] = mpd.REP_LABEL2,
			[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
			[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
			[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
			[OrderHeaderComment] = CAST(h.ORDER_COMMENT as varchar(MAX)),
			D.SpotsWeek1,
			D.SpotsWeek2,
			D.SpotsWeek3,
			D.SpotsWeek4,
			D.SpotsWeek5,
			D.SpotsWeek6,
			D.SpotsWeek7,
			D.SpotsWeek8,
			D.SpotsWeek9,
			D.SpotsWeek10,
			D.SpotsWeek11,
			D.SpotsWeek12,
			D.SpotsWeek13,
			TotalSpots = COALESCE(D.SpotsWeek1,0) + COALESCE(D.SpotsWeek2,0) + COALESCE(D.SpotsWeek3,0) + COALESCE(D.SpotsWeek4,0) + COALESCE(D.SpotsWeek5,0) + COALESCE(D.SpotsWeek6,0) +
				COALESCE(D.SpotsWeek7,0) + COALESCE(D.SpotsWeek8,0) + COALESCE(D.SpotsWeek9,0) + COALESCE(D.SpotsWeek10,0) + COALESCE(D.SpotsWeek11,0) + COALESCE(D.SpotsWeek12,0) + COALESCE(D.SpotsWeek13,0),
			D.Cycle,
			LD.Programming,
			[Days] = NULLIF(LD.[Days],''),
			LD.AirTime,
			LD.[Length],
			D.CostRate,
			--LD.NetChargeDescription,
			--LD.DiscountDescription,
			LD.ChargeTo,
			StartWeek = CASE WHEN D.StartWeek IS NULL THEN (SELECT TOP 1 StartWeek FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek IS NOT NULL)
						ELSE D.StartWeek
						END,
			[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
			[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
			LD.CableNetwork,
			LD.Daypart,
			AddedValue = CASE WHEN mpd.ADDED_VALUE = 1 THEN NULLIF(LD.AddedValue,'') ELSE NULL END,
			Bookend = CASE WHEN mpd.BOOKENDS = 1 THEN LD.Bookend ELSE NULL END,
			LD.Remarks,
			D.LineNumber,
			LD.PrimaryRating,
			LD.PrimaryCPP,
			LD.Demographic,
			SeparationPolicy = CASE WHEN mpd.SEPARATION_POLICY = 1 THEN [dbo].[advfn_spot_separation_policy](@OrderNumber, @MediaType) ELSE NULL END,
			MakeGoodNumber = COALESCE(D.MakeGoodNumber, 0),
			CreatedFromWorkSheet = CAST(COALESCE(LD.CreatedFromWorkSheet, 0) as bit),
			MaxWeekdate = @MaxWeekdate,
			ShowNielsenCopyright = CAST(COALESCE(LD.ShowNielsenCopyright, 0) as bit),
			[FlightStartDate] = h.[START_DATE],
			[FlightEndDate] = h.END_DATE,
			StartWeek2 = CASE WHEN D.StartWeek2 IS NULL THEN (SELECT TOP 1 StartWeek2 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek2 IS NOT NULL)
						ELSE D.StartWeek2
						END,
			StartWeek3 = CASE WHEN D.StartWeek3 IS NULL THEN (SELECT TOP 1 StartWeek3 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek3 IS NOT NULL)
						ELSE D.StartWeek3
						END,
			StartWeek4 = CASE WHEN D.StartWeek4 IS NULL THEN (SELECT TOP 1 StartWeek4 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek4 IS NOT NULL)
						ELSE D.StartWeek4
						END,
			StartWeek5 = CASE WHEN D.StartWeek5 IS NULL THEN (SELECT TOP 1 StartWeek5 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek5 IS NOT NULL)
						ELSE D.StartWeek5
						END,
			StartWeek6 = CASE WHEN D.StartWeek6 IS NULL THEN (SELECT TOP 1 StartWeek6 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek6 IS NOT NULL)
						ELSE D.StartWeek6
						END,
			StartWeek7 = CASE WHEN D.StartWeek7 IS NULL THEN (SELECT TOP 1 StartWeek7 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek7 IS NOT NULL)
						ELSE D.StartWeek7
						END,
			StartWeek8 = CASE WHEN D.StartWeek8 IS NULL THEN (SELECT TOP 1 StartWeek8 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek8 IS NOT NULL)
						ELSE D.StartWeek8
						END,
			StartWeek9 = CASE WHEN D.StartWeek9 IS NULL THEN (SELECT TOP 1 StartWeek9 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek9 IS NOT NULL)
						ELSE D.StartWeek9
						END,
			StartWeek10 = CASE WHEN D.StartWeek10 IS NULL THEN (SELECT TOP 1 StartWeek10 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek10 IS NOT NULL)
						ELSE D.StartWeek10
						END,
			StartWeek11 = CASE WHEN D.StartWeek11 IS NULL THEN (SELECT TOP 1 StartWeek11 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek11 IS NOT NULL)
						ELSE D.StartWeek11
						END,
			StartWeek12 = CASE WHEN D.StartWeek12 IS NULL THEN (SELECT TOP 1 StartWeek12 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek12 IS NOT NULL)
						ELSE D.StartWeek12
						END,
			StartWeek13 = CASE WHEN D.StartWeek13 IS NULL THEN (SELECT TOP 1 StartWeek13 FROM @Details t WHERE t.Cycle = D.Cycle AND t.StartWeek13 IS NOT NULL)
						ELSE D.StartWeek13
						END,
			LD.PrimaryCPM,
			LD.PrimaryImpressions,
			LD.LineCancelled,
			ClientAddress1 = c.CL_ADDRESS1,
			ClientAddress2 = c.CL_ADDRESS2,
			ClientCity = c.CL_CITY,
			ClientState = c.CL_STATE,        
			ClientZip = c.CL_ZIP
		FROM
			@Details D
				INNER JOIN @LineDetails LD ON D.LineNumber = LD.LineNumber AND COALESCE(D.MakeGoodNumber, 0) = COALESCE(LD.MakeGoodNumber, 0) AND D.CostRate = LD.CostRate
				INNER JOIN dbo.RADIO_HDR h ON h.ORDER_NBR = LD.OrderNumber 
				LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE 
				INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
				INNER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE 
				INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE 
				INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON UPPER(mpd.[USER_ID]) = UPPER(@UserCode) AND mpd.MEDIA_TYPE = @MediaType 
				LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
				LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE 
				LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
				LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
				LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		WHERE h.ORDER_NBR = @OrderNumber
	) Details
	GROUP BY
		[OrderNumber],
		[ClientName],
		[DivisionName],
		[ProductionDescription],
		[CampaignName],
		[FlightDates],
		[MarketName],
		[Buyer],
		[OrderDescription],
		[NetGross],
		[VendorCode],
		[VendorName],
		[VendorRepCode1],
		[VendorRepCode2],
		[PrintDate],
		[AgencyComment],
		[AgencyCommentFontSize],
		[MaxRevision],
		[OrderLabel],
		[LocationHeader],
		[LocationFooter],
		[ShowShippingAddress],
		[PageHeaderLogoPath],
		[IncludeRep1],
		[RepLabel1],
		[IncludeRep2],
		[RepLabel2],
		[DefaultRep1Label],
		[DefaultRep2Label],
		[ExcludeEmployeeSignature],
		[OrderHeaderComment],
		Cycle,
		Programming,
		[Days],
		AirTime,
		[Length],
		CostRate,
		--NetChargeDescription,
		--DiscountDescription,
		ChargeTo,
		StartWeek,
		[OrderHeaderCommentOption],
		[BuyerEmployeeCode],
		CableNetwork,
		Daypart,
		AddedValue,
		Bookend,
		Remarks,
		PrimaryRating,
		PrimaryCPP,
		Demographic,
		SeparationPolicy,
		MakeGoodNumber,
		CreatedFromWorkSheet,
		MaxWeekdate,
		ShowNielsenCopyright,
		[FlightStartDate],
		[FlightEndDate],
		StartWeek2,
		StartWeek3,
		StartWeek4,
		StartWeek5,
		StartWeek6,
		StartWeek7,
		StartWeek8,
		StartWeek9,
		StartWeek10,
		StartWeek11,
		StartWeek12,
		StartWeek13,
		PrimaryCPM,
		PrimaryImpressions,
		LineCancelled,
		ClientAddress1,
		ClientAddress2,
		ClientCity,
		ClientState,
		ClientZip
	ORDER BY 
		Cycle
END
GO