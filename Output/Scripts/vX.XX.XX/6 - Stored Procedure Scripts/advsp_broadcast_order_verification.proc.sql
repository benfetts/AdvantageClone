CREATE PROC advsp_broadcast_order_verification
	@OrderNumberLineNumbers varchar(MAX),
	@OrderYearMonths varchar(MAX),
	@OrderNumbers varchar(MAX),
	@ShowWeekOf bit,
	@debug bit = 0
AS

--set @OrderNumberLineNumbers = '1174|1'
--set	@OrderYearMonths = '1174|2019|11'
--set	@OrderNumbers = '1174' 
--set	@ShowWeekOf = 0

DECLARE @view TABLE (
	[DetailID] int NOT NULL,
	[MediaType] varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	[VendorCode] varchar(6) NOT NULL,
	[VendorName] varchar(40) NULL,
	[Vendor] varchar(50) NULL,
	[OrderNumber] int NOT NULL,
	[OrderLineNumber] smallint NULL,
	[RunDate] smalldatetime NOT NULL,
	[WeekOf] smalldatetime NULL,
	[WeekOfSpots] smallint NULL,
	[RunTime] time NOT NULL,
	[DayOfWeek] varchar(2) NULL,
	[DayOfWeekNumber] smallint NULL,
	[Length] smallint NOT NULL,
	[AdNumber] varchar(30) NULL,
	[NetworkID] varchar(10) NULL,
	[GrossRate] decimal NOT NULL,
	[Approved] smallint NULL,
	[Comment] varchar(254) NULL,
	[VariantCodes] varchar(254) NULL,
	[IsLineNumberVerified] bit NULL,
	[IsRateVerified] bit NULL,
	[IsNetworkVerified] bit NULL,
	[IsScheduleVerified] bit NULL,
	[IsDayOfWeekVerified] bit NULL,
	[IsTimeVerified] bit NULL,
	[IsTimeSeparationVerified] bit NULL,
	[IsAdNumberVerified] bit NULL,
	[IsLengthVerified] bit NULL,
	[IsSpotVerified] bit NULL,
	[IsBookendVerified] varchar(20) NULL,
	[OrderMonthNumber] smallint NULL,
	[OrderYearNumber] smallint NULL,
	[LinkLineNumber] int NULL,
	[ProgramName] varchar(40) NULL
)

DECLARE @weekof TABLE (
	OrderNumber int NOT NULL,
	OrderLineNumber smallint NOT NULL,
	WeekOf smalldatetime,
	Spots int,
	CanEdit bit DEFAULT(1)
)

INSERT INTO @view 
exec advsp_broadcast_order_dtl_verification @OrderNumberLineNumbers, 1, @OrderYearMonths, @OrderNumbers, @ShowWeekOf

DECLARE @bookend_table TABLE (
	OrderNumber int NOT NULL,
	OrderLineNumber smallint NOT NULL,
	[IsBookendVerified] varchar(20) NOT NULL,
	WeekOf smalldatetime
)

INSERT INTO @bookend_table
SELECT DISTINCT OrderNumber, OrderLineNumber, [IsBookendVerified], WeekOf
FROM @view
WHERE [IsBookendVerified] <> ''

SET DATEFIRST  1
	
INSERT INTO @weekof (OrderNumber, OrderLineNumber, WeekOf, Spots)
SELECT DISTINCT
	OrderNumber = ORDER_NBR,
	OrderLineNumber = LINE_NBR,
	WeekOf = CASE WHEN @ShowWeekOf = 1 THEN
					CASE WHEN MYDATE = 'DATE1' THEN 
						CASE WHEN DATEPART(dw, DATES) = 1 THEN DATES
						ELSE DATEADD(d, -1 * (DATEPART(dw, DATES) - 1), DATES)
						END
					ELSE DATES
					END
			 ELSE NULL
		  	 END,
	Spots = CASE WHEN @ShowWeekOf = 1 THEN SPOTS
			ELSE NULL
			END
FROM (
		SELECT ORDER_NBR, LINE_NBR, DATES, MYDATE, SPOTS = CASE 
															WHEN MYDATE = 'DATE1' THEN SPOTS1
															WHEN MYDATE = 'DATE2' THEN SPOTS2
															WHEN MYDATE = 'DATE3' THEN SPOTS3
															WHEN MYDATE = 'DATE4' THEN SPOTS4
															WHEN MYDATE = 'DATE5' THEN SPOTS5
															WHEN MYDATE = 'DATE6' THEN SPOTS6
															WHEN MYDATE = 'DATE7' THEN SPOTS7
															END
		FROM dbo.TV_DETAIL 
		UNPIVOT
		(
			DATES
			FOR MYDATE IN (DATE1, DATE2, DATE3, DATE4, DATE5, DATE6, DATE7)
		) D
		WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
		AND ACTIVE_REV = 1

		UNION

		SELECT ORDER_NBR, LINE_NBR, DATES, MYDATE, SPOTS = CASE 
															WHEN MYDATE = 'DATE1' THEN SPOTS1
															WHEN MYDATE = 'DATE2' THEN SPOTS2
															WHEN MYDATE = 'DATE3' THEN SPOTS3
															WHEN MYDATE = 'DATE4' THEN SPOTS4
															WHEN MYDATE = 'DATE5' THEN SPOTS5
															WHEN MYDATE = 'DATE6' THEN SPOTS6
															WHEN MYDATE = 'DATE7' THEN SPOTS7
															END
		FROM dbo.RADIO_DETAIL 
		UNPIVOT
		(
			DATES
			FOR MYDATE IN (DATE1, DATE2, DATE3, DATE4, DATE5, DATE6, DATE7)
		) D
		WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
		AND ACTIVE_REV = 1

	) dtl

IF @ShowWeekOf = 1 BEGIN
	DECLARE @DetailWeekOf TABLE (
		ID int IDENTITY(1,1) NOT NULL,
		WEEK_OF smalldatetime,
		ORDER_NBR int,
		LINE_NBR smallint
	)

	INSERT INTO @DetailWeekOf (WEEK_OF, ORDER_NBR, LINE_NBR)
	SELECT DISTINCT
		WEEK_OF = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate), ORDER_NBR, ORDER_LINE_NBR 
	FROM dbo.AP_TV_BROADCAST_DTL DTL 
	WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
	AND ORDER_LINE_NBR IS NOT NULL
	GROUP BY ORDER_NBR, ORDER_LINE_NBR, RUN_DATE

	INSERT INTO @DetailWeekOf (WEEK_OF, ORDER_NBR, LINE_NBR)
	SELECT DISTINCT
		WEEK_OF = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate), ORDER_NBR, ORDER_LINE_NBR 
	FROM dbo.AP_RADIO_BROADCAST_DTL DTL 
	WHERE ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
	AND ORDER_LINE_NBR IS NOT NULL
	GROUP BY ORDER_NBR, ORDER_LINE_NBR, RUN_DATE

	INSERT INTO @weekof	(OrderNumber, OrderLineNumber, WeekOf, Spots, CanEdit)
	SELECT ORDER_NBR, LINE_NBR, WEEK_OF, 0, 0
	FROM @DetailWeekOf c
		LEFT OUTER JOIN @weekof w ON c.WEEK_OF = w.WeekOf AND w.OrderNumber = c.ORDER_NBR AND w.OrderLineNumber = c.LINE_NBR
	WHERE w.WeekOf IS NULL
END

IF @debug = 1
	SELECT * FROM @weekof


DECLARE @OrderMaxRev TABLE (
	OrderNumber int NOT NULL,
	RevisionNumber int NOT NULL
)

INSERT INTO @OrderMaxRev (OrderNumber, RevisionNumber)
SELECT d.ORDER_NBR, MAX(md.REVISION_NUMBER)
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE d 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL md ON d.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = md.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
WHERE d.ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
GROUP BY d.ORDER_NBR

IF @debug = 1 BEGIN
	SELECT * FROM @weekof
	SELECT * FROM @OrderMaxRev
END

SELECT
	[MediaType],
	[VendorCode],
	[VendorName],
	[Vendor],
	[OrderNumber],
 	[OrderLineNumber],
	[WeekOf],
	[RevisionNumber] = [OrderRevisionNumber],
	[SequenceNumber] = [OrderSequenceNumber],
 	[StartDate] = CASE WHEN IsDaily = 1 AND @ShowWeekOf = 1 AND CanEdit = 0 THEN [WeekOf] ELSE [OrderStartDate] END,
 	[EndDate] = CASE WHEN IsDaily = 1 AND @ShowWeekOf = 1 AND CanEdit = 0 THEN DATEADD(d, 6, [WeekOf]) ELSE [OrderEndDate] END,
	[StartTime] = [OrderStartTime],
	[EndTime] = [OrderEndTime],
 	[Days] = CASE WHEN [CanEdit] = 0 THEN bogusweeks.[DAYS] ELSE COALESCE(mbw.[DAYS], f.[Days]) END,
 	[Length] = [OrderLength],
 	[AdNumber] = [OrderAdNumber],
 	[NetworkID] = [OrderNetworkID],
 	[GrossRate] = [OrderGrossRate],
 	[Spots] = [OrderTotalSpots],
	[ActualSpots] = [ActualSpots],
	[MatchedSpots] = CASE WHEN [CanEdit] = 0 THEN 0 ELSE [MatchedSpots] END,
 	[VariantCodes] = CASE 
						WHEN [CanEdit] = 0 THEN 'Spot' 
					 ELSE 
						CASE 
							WHEN [ActualSpots] = 0 THEN 'No Detail' 
							WHEN LEN([VariantCodes]) > 0 THEN SUBSTRING([VariantCodes], 1, LEN([VariantCodes]) - 2) 
							ELSE '' 
						END
					 END,
	[OrderMonthNumber] = [OrderMonthNumber],
	[OrderYearNumber] = [OrderYearNumber],
	[IsBookend] = mbw.BOOKEND,
	[IsHiatus] = mbw.IS_HIATUS,
	[AllowSpotsToBeEntered] = mbw.ALLOW_SPOTS_TO_BE_ENTERED,
	[Daypart] = CASE WHEN [CanEdit] = 0 THEN bogusweeks.DAY_PART_ID ELSE mbw.DAY_PART_ID END,
	[Program] = CASE WHEN [CanEdit] = 0 THEN bogusweeks.PROGRAM ELSE mbw.PROGRAM END,
	[EstimatedGRP] = mbw.PRIMARY_RATING,
	[EstimatedImpressions],
	[WorksheetLineNumber] = mbw.LINE_NUMBER,
	[IsDaily],
	[CanEdit],
    CAST([Monday] as bit),
	CAST([Tuesday] as bit),
	CAST([Wednesday] as bit),
	CAST([Thursday] as bit),
	CAST([Friday] as bit),
	CAST([Saturday] as bit),
	CAST([Sunday] as bit),
    [WorksheetMakegoodNumber] = mbw.MAKEGOOD_NUMBER
FROM
	(SELECT
		[MediaType],
		[VendorCode],
		[VendorName],
		[Vendor],
 		Ord.[OrderNumber],
 		Ord.[OrderLineNumber],
		[OrderRevisionNumber],
		[OrderSequenceNumber],
 		[OrderStartDate],
 		[OrderEndDate],
		[OrderStartTime],
		[OrderEndTime],
 		[Days] = CASE WHEN LEN([Days]) > 1 THEN SUBSTRING([Days], 1, LEN([Days]) -1) ELSE '' END,
 		[OrderLength],
 		[OrderAdNumber],
 		[OrderNetworkID],
 		[OrderGrossRate],
 		[OrderTotalSpots] = COALESCE([OrderTotalSpots], w.Spots),
		--[MatchedSpots] = ISNULL(C.MatchedSpots, 0),
		MatchedSpots = (SELECT Count(CASE WHEN ISNULL(VariantCodes, '') = '' THEN 1 END) FROM @view v WHERE Ord.OrderNumber = v.OrderNumber AND Ord.OrderLineNumber = v.OrderLineNumber AND (@ShowWeekOf = 0 OR Ord.WeekOf = v.WeekOf AND @ShowWeekOf = 1)),
		[ActualSpots] = ISNULL( (SELECT COUNT(1) FROM @view v WHERE Ord.OrderNumber = v.OrderNumber AND Ord.OrderLineNumber = v.OrderLineNumber AND (@ShowWeekOf = 0 OR Ord.WeekOf = v.WeekOf AND @ShowWeekOf = 1)), 0),
 		[VariantCodes] = CASE CAST(C.[IsRateVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Rate | '
  							END + 
  							CASE CAST(C.[IsNetworkVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Network | '
  							END + 
  							CASE CAST(C.[IsScheduleVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Sched | '
  							END + 
  							CASE CAST(C.[IsDayOfWeekVerified] as  bit)
  							WHEN 1 THEN ''
  							ELSE 'Day | '
  							END + 
  							CASE CAST(C.[IsTimeVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Time | '
  							END + 
  							CASE CAST(C.[IsTimeSeparationVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Time Sep | '
  							END + 
  							CASE CAST(C.[IsAdNumberVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'AdNbr | '
  							END + 
  							CASE CAST(C.[IsLengthVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Length | '
  							END + 
							CASE CAST(C.[IsSpotVerified] as bit)
  							WHEN 1 THEN ''
  							ELSE 'Spot | '
  							END +
							--CASE WHEN C.[IsBookendVerified] = '' THEN ''
							--	ELSE C.[IsBookendVerified]
							--END,
							CASE
								WHEN (SELECT COUNT(1) FROM @bookend_table bt WHERE bt.OrderNumber = Ord.OrderNumber AND bt.OrderLineNumber = Ord.OrderLineNumber AND (@ShowWeekOf = 0 OR (@ShowWeekOf = 1 AND bt.WeekOf = Ord.WeekOf))) = 0 THEN 
									''
								WHEN (SELECT COUNT(1) FROM @bookend_table bt WHERE bt.OrderNumber = Ord.OrderNumber AND bt.OrderLineNumber = Ord.OrderLineNumber AND (@ShowWeekOf = 0 OR (@ShowWeekOf = 1 AND bt.WeekOf = Ord.WeekOf))) = 1 THEN
									(SELECT [IsBookendVerified] FROM @bookend_table bt WHERE bt.OrderNumber = Ord.OrderNumber AND bt.OrderLineNumber = Ord.OrderLineNumber AND (@ShowWeekOf = 0 OR (@ShowWeekOf = 1 AND bt.WeekOf = Ord.WeekOf)))
								WHEN (SELECT COUNT(1) FROM @bookend_table bt WHERE bt.OrderNumber = Ord.OrderNumber AND bt.OrderLineNumber = Ord.OrderLineNumber AND (@ShowWeekOf = 0 OR (@ShowWeekOf = 1 AND bt.WeekOf = Ord.WeekOf))) = 2 THEN
									'Bookend Sep | Time Sep | '
							END,
		[OrderMonthNumber] = [OrderMonthNumber],
		[OrderYearNumber] = [OrderYearNumber],
		Ord.[WeekOf],
		Ord.[IsDaily],
		Ord.[CanEdit],
        [Monday],
		[Tuesday],
		[Wednesday],
		[Thursday],
		[Friday],
		[Saturday],
		[Sunday]
	FROM
		(SELECT
			OrdDtl.[MediaType],
			OrdDtl.[VendorCode],
			OrdDtl.[VendorName],
			OrdDtl.[Vendor],
			OrdDtl.[OrderNumber],
  			OrdDtl.[OrderLineNumber],
			[OrderRevisionNumber],
			[OrderSequenceNumber],
  			[OrderStartDate],
  			[OrderEndDate],
			[OrderStartTime], -- = CASE WHEN ISDATE([OrderStartTime]) = 1 THEN CAST([OrderStartTime] AS TIME) ELSE NULL END,
			[OrderEndTime], -- = CASE WHEN ISDATE([OrderEndTime]) = 1 THEN CAST([OrderEndTime] AS TIME) ELSE NULL END,
  			[Days] = CASE WHEN COUNT(CASE WHEN Monday = 1 THEN 1 END) > 0 THEN 'M, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Tuesday = 1 THEN 1 END) > 0 THEN 'Tu, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Wednesday = 1 THEN 1 END) > 0 THEN 'W, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Thursday = 1 THEN 1 END) > 0 THEN 'Th, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Friday = 1 THEN 1 END) > 0 THEN 'F, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Saturday = 1 THEN 1 END) > 0 THEN 'Sa, ' ELSE '' END + 
  							CASE WHEN COUNT(CASE WHEN Sunday = 1 THEN 1 END) > 0 THEN 'Su, ' ELSE '' END,
  			[OrderLength],
  			[OrderAdNumber],
  			[OrderNetworkID],
  			[OrderGrossRate],
  			[OrderTotalSpots],
			[OrderMonthNumber] = OrdDtl.[OrderMonthNumber],
			[OrderYearNumber] = OrdDtl.[OrderYearNumber],
			[WeekOf] = OrdDtl.[WeekOf],
			OrdDtl.IsDaily,
			OrdDtl.CanEdit,
            [Monday],
			[Tuesday],
			[Wednesday],
			[Thursday],
			[Friday],
			[Saturday],
			[Sunday]
		FROM
			(SELECT
				[MediaType] = 'TV',
				[VendorCode] = V.VN_CODE,
				[VendorName] = V.VN_NAME,
				[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
				[OrderNumber] = H.ORDER_NBR,
  				[OrderLineNumber] = H.LINE_NBR,
				[OrderRevisionNumber] = H.REV_NBR,
				[OrderSequenceNumber] = H.SEQ_NBR,
  				[OrderStartDate] = H.[START_DATE],
  				[OrderEndDate] = H.END_DATE,
				[OrderStartTime] = H.START_TIME,
				[OrderEndTime] = H.END_TIME,
				[OrderGrossRate] = CASE WHEN COALESCE(HDR.NET_GROSS,1) = 1 THEN H.GROSS_RATE ELSE H.NET_RATE END,
				[OrderLength] = H.[LENGTH],
				[OrderAdNumber] = H.AD_NUMBER,
				[OrderNetworkID] = COALESCE(NULLIF(H.CABLE_NETWORK_STATION_CODE,''), NULLIF(H.NETWORK_ID,'')),
				[OrderTotalSpots] = CASE WHEN @ShowWeekOf = 0 THEN H.TOTAL_SPOTS ELSE NULL END,
				[Monday] = H.MONDAY,
				[Tuesday] = H.TUESDAY,
				[Wednesday] = H.WEDNESDAY,
				[Thursday] = H.THURSDAY,
				[Friday] = H.FRIDAY,
				[Saturday] = H.SATURDAY,
				[Sunday] = H.SUNDAY,
				[OrderMonthNumber] = H.MONTH_NBR,
				[OrderYearNumber] = H.YEAR_NBR,
				[WeekOf] = w.WeekOf,
				[IsDaily] = CAST(CASE WHEN H.BUY_TYPE = 'DB' THEN 1 ELSE 0 END as bit),
				[CanEdit] = w.CanEdit
			FROM
				dbo.TV_DETAIL H
					INNER JOIN	
						dbo.TV_HDR HDR ON H.ORDER_NBR = HDR.ORDER_NBR
					INNER JOIN	
						dbo.VENDOR V ON HDR.VN_CODE = V.VN_CODE
					INNER JOIN
						(SELECT DISTINCT
							ORDER_NBR
							FROM
							dbo.AP_TV_BROADCAST_DTL) DORD ON H.ORDER_NBR = DORD.ORDER_NBR
					INNER JOIN @weekof w ON H.ORDER_NBR = w.OrderNumber AND H.LINE_NBR = w.OrderLineNumber 
			WHERE
				H.ACTIVE_REV = 1
            AND H.ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))

			UNION ALL

			SELECT
				[MediaType] = 'Radio',
				[VendorCode] = V.VN_CODE,
				[VendorName] = V.VN_NAME,
				[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
				[OrderNumber] = H.ORDER_NBR,
  				[OrderLineNumber] = H.LINE_NBR,
				[OrderRevisionNumber] = H.REV_NBR,
				[OrderSequenceNumber] = H.SEQ_NBR,
  				[OrderStartDate] = H.[START_DATE],
  				[OrderEndDate] = H.END_DATE,
				[OrderStartTime] = H.START_TIME,
				[OrderEndTime] = H.END_TIME,
				[OrderGrossRate] = CASE WHEN COALESCE(HDR.NET_GROSS,1) = 1 THEN H.GROSS_RATE ELSE H.NET_RATE END,
				[OrderLength] = H.[LENGTH],
				[OrderAdNumber] = H.AD_NUMBER,
				[OrderNetworkID] = NULL,
				[OrderTotalSpots] = CASE WHEN @ShowWeekOf = 0 THEN H.TOTAL_SPOTS ELSE NULL END,
				[Monday] = H.MONDAY,
				[Tuesday] = H.TUESDAY,
				[Wednesday] = H.WEDNESDAY,
				[Thursday] = H.THURSDAY,
				[Friday] = H.FRIDAY,
				[Saturday] = H.SATURDAY,
				[Sunday] = H.SUNDAY,
				[OrderMonthNumber] = H.MONTH_NBR,
				[OrderYearNumber] = H.YEAR_NBR,
				[WeekOf] = w.WeekOf,
				[IsDaily] = CAST(CASE WHEN H.BUY_TYPE = 'DB' THEN 1 ELSE 0 END as bit),
				[CanEdit] = w.CanEdit
			FROM
				dbo.RADIO_DETAIL H
					INNER JOIN	
						dbo.RADIO_HDR HDR ON H.ORDER_NBR = HDR.ORDER_NBR
					INNER JOIN	
						dbo.VENDOR V ON HDR.VN_CODE = V.VN_CODE
					INNER JOIN
						(SELECT DISTINCT
							ORDER_NBR
							FROM
							dbo.AP_RADIO_BROADCAST_DTL) DORD ON H.ORDER_NBR = DORD.ORDER_NBR
					INNER JOIN @weekof w ON H.ORDER_NBR = w.OrderNumber AND H.LINE_NBR = w.OrderLineNumber 
			WHERE
				H.ACTIVE_REV = 1
            AND H.ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))

			) OrdDtl
		GROUP BY
			OrdDtl.VendorCode,
			OrdDtl.VendorName,
			OrdDtl.Vendor,
			OrdDtl.MediaType,
			OrdDtl.OrderNumber,
			OrdDtl.OrderLineNumber,
			OrdDtl.OrderRevisionNumber,
			OrdDtl.OrderSequenceNumber,
			OrdDtl.OrderStartDate,
			OrdDtl.OrderEndDate,
			OrdDtl.OrderStartTime,
			OrdDtl.OrderEndTime,
			OrdDtl.OrderLength,
			OrdDtl.OrderAdNumber,
			OrdDtl.OrderNetworkID,
			OrdDtl.OrderGrossRate,
			OrdDtl.OrderTotalSpots,
			OrdDtl.OrderMonthNumber,
			OrdDtl.OrderYearNumber,
			OrdDtl.WeekOf,
			OrdDtl.IsDaily,
			OrdDtl.CanEdit,
            [Monday],
			[Tuesday],
			[Wednesday],
			[Thursday],
			[Friday],
			[Saturday],
			[Sunday]
			) Ord LEFT OUTER JOIN
			(SELECT	
					OrderNumber,
					OrderLineNumber,
					WeekOf = CASE WHEN @ShowWeekOf = 0 THEN NULL ELSE WeekOf END,
					[IsRateVerified] = MIN(CAST(IsRateVerified as int)),
  					[IsNetworkVerified] = MIN(CAST(IsNetworkVerified as int)),
  					[IsScheduleVerified] = MIN(CAST(IsScheduleVerified as int)),
  					[IsDayOfWeekVerified] = MIN(CAST(IsDayOfWeekVerified as int)),
  					[IsTimeVerified] = MIN(CAST(IsTimeVerified as int)),
  					[IsTimeSeparationVerified] = MIN(CAST(IsTimeSeparationVerified as int)),
  					[IsAdNumberVerified] = MIN(CAST(IsAdNumberVerified as int)),
  					[IsLengthVerified] = MIN(CAST(IsLengthVerified as  int)),
					[IsSpotVerified] = MIN(CAST(IsSpotVerified as  int))
					--[IsBookendVerified] = MAX([IsBookendVerified])
				FROM
					@view
				GROUP BY
					OrderNumber,
					OrderLineNumber,
					CASE WHEN @ShowWeekOf = 0 THEN NULL ELSE WeekOf END) C ON Ord.OrderNumber = C.OrderNumber AND Ord.OrderLineNumber = C.OrderLineNumber AND (@ShowWeekOf = 0 OR (Ord.WeekOf = C.WeekOf AND @ShowWeekOf = 1))
				INNER JOIN @weekof w ON Ord.OrderNumber = w.OrderNumber AND Ord.OrderLineNumber = w.OrderLineNumber AND (@ShowWeekOf = 0 OR (Ord.WeekOf = w.WeekOf AND @ShowWeekOf = 1))
		WHERE
			1 = CASE WHEN CAST(Ord.OrderNumber as varchar) + '|' + CAST(Ord.OrderYearNumber as varchar) + '|' + CAST(Ord.OrderMonthNumber as varchar) IN (SELECT items FROM dbo.udf_split_list(@OrderYearMonths, ',')) THEN 1
					 WHEN CAST(Ord.OrderNumber as varchar) + '|' + CAST(Ord.OrderLineNumber as varchar) IN (SELECT items FROM dbo.udf_split_list(@OrderNumberLineNumbers, ',')) THEN 1
				END

	) f
	LEFT OUTER JOIN (
		SELECT 
				d.ORDER_NBR,
				d.ORDER_LINE_NBR,
				[DATE] = CASE WHEN @ShowWeekOf = 1 THEN d.[DATE] ELSE NULL END,
				md.BOOKEND,
				d.IS_HIATUS,
				d.ALLOW_SPOTS_TO_BE_ENTERED,
				md.DAY_PART_ID,
				md.PROGRAM,
				md.PRIMARY_RATING,
				[EstimatedImpressions] = CASE WHEN mbw.MEDIA_TYPE_CODE = 'T' THEN CAST(md.PRIMARY_IMPRESSIONS as decimal) / 1000
											  WHEN mbw.MEDIA_TYPE_CODE = 'R' THEN CAST(CAST(md.PRIMARY_AQH as decimal) / 100 as int)
											END,
				md.LINE_NUMBER,
				md.[DAYS],
				MAX(md.REVISION_NUMBER) as maxrevnbr,
                md.MAKEGOOD_NUMBER
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE d 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL md ON d.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = md.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET mbwm ON mbwm.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = md.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET mbw ON mbw.MEDIA_BROADCAST_WORKSHEET_ID = mbwm.MEDIA_BROADCAST_WORKSHEET_ID
			INNER JOIN @OrderMaxRev o ON d.ORDER_NBR = o.OrderNumber AND md.REVISION_NUMBER = o.RevisionNumber
		GROUP BY 
				d.ORDER_NBR,
				d.ORDER_LINE_NBR,
				CASE WHEN @ShowWeekOf = 1 THEN d.[DATE] ELSE NULL END,
				md.BOOKEND,
				d.IS_HIATUS,
				d.ALLOW_SPOTS_TO_BE_ENTERED,
				md.DAY_PART_ID,
				md.PROGRAM,
				md.PRIMARY_RATING,
				md.PRIMARY_IMPRESSIONS,
				md.PRIMARY_AQH,
				md.LINE_NUMBER,
				md.[DAYS],
				mbw.MEDIA_TYPE_CODE,
                md.MAKEGOOD_NUMBER
		) mbw ON f.OrderNumber = mbw.ORDER_NBR AND f.OrderLineNumber = mbw.ORDER_LINE_NBR AND (@ShowWeekOf = 0 OR (@ShowWeekOf = 1 AND mbw.[DATE] BETWEEN f.WeekOf AND DATEADD(DAY, 6, f.WeekOf)))
	LEFT OUTER JOIN (
		SELECT DISTINCT
				d.ORDER_NBR,
				d.ORDER_LINE_NBR,
				--d.[DATE],
				--md.BOOKEND,
				--d.IS_HIATUS,
				--d.ALLOW_SPOTS_TO_BE_ENTERED,
				md.DAY_PART_ID,
				md.PROGRAM,
				--md.PRIMARY_RATING,
				--[EstimatedImpressions] = CAST(md.PRIMARY_IMPRESSIONS as decimal) / 1000,
				--md.LINE_NUMBER,
				md.[DAYS],
				MAX(md.REVISION_NUMBER) as maxrevnbr
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE d 
			INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL md ON d.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = md.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
			INNER JOIN @OrderMaxRev o ON d.ORDER_NBR = o.OrderNumber AND md.REVISION_NUMBER = o.RevisionNumber
		GROUP BY
				d.ORDER_NBR,
				d.ORDER_LINE_NBR,
				--d.[DATE],
				--md.BOOKEND,
				--d.IS_HIATUS,
				--d.ALLOW_SPOTS_TO_BE_ENTERED,
				md.DAY_PART_ID,
				md.PROGRAM,
				--md.PRIMARY_RATING,
				--md.PRIMARY_IMPRESSIONS,
				--md.LINE_NUMBER,
				md.[DAYS]
		) bogusweeks ON f.OrderNumber = bogusweeks.ORDER_NBR AND f.OrderLineNumber = bogusweeks.ORDER_LINE_NBR --AND mbw.[DATE] BETWEEN f.WeekOf AND DATEADD(DAY, 6, f.WeekOf)
    WHERE mbw.LINE_NUMBER IS NOT NULL
	ORDER BY
		[OrderNumber],
 		[OrderLineNumber],
		[WeekOf]

GO