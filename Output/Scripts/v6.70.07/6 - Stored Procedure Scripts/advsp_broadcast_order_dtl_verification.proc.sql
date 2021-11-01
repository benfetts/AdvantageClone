CREATE PROC advsp_broadcast_order_dtl_verification
	@OrderNumberLineNumbers varchar(MAX),
	@MatchAdditionalParameters bit,
	@OrderYearMonths varchar(MAX),
	@OrderNumbers varchar(MAX),
	@ShowWeekOf bit,
	@debug bit = 0
AS

DECLARE @Orders TABLE (
	ORDER_NBR int NOT NULL,
	MEDIA_TYPE_CODE varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_BROADCAST_WORKSHEET_ID int,
	VERIFY_RATE bit NOT NULL DEFAULT(0),
	VERIFY_NETWORK bit NOT NULL DEFAULT(0),
	VERIFY_SCHEDULE bit NOT NULL DEFAULT(0),
	VERIFY_DAY bit NOT NULL DEFAULT(0),
	VERIFY_TIME bit NOT NULL DEFAULT(0),
	VERIFY_TIME_SEP bit NOT NULL DEFAULT(0),
	VERIFY_AD_NUMBER bit NOT NULL DEFAULT(0),
	VERIFY_LENGTH bit NOT NULL DEFAULT(0),
	BRDCAST_DTL_VERIFICATION_SETTING_ID int,
	MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID int,
	IS_SET bit,
	ADJACENCY_BEFORE smallint NOT NULL DEFAULT(0),
	ADJACENCY_AFTER smallint NOT NULL DEFAULT(0),
	BOOKEND_MAX_SEPARATION smallint NOT NULL DEFAULT(0)
)

DECLARE @OrderTimeSettings TABLE (
	BRDCAST_DTL_VERIFICATION_SETTING_ID int,
	MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID int,
	TIME_LENGTH int,
	TIME_SEPARATION int
)

INSERT @Orders (ORDER_NBR)
SELECT items FROM dbo.udf_split_list(@OrderNumbers, ',')

UPDATE O SET MEDIA_TYPE_CODE = 'T', CL_CODE = D.CL_CODE
FROM @Orders O
	INNER JOIN dbo.TV_HDR D ON O.ORDER_NBR = D.ORDER_NBR
	
UPDATE O SET MEDIA_TYPE_CODE = 'R', CL_CODE = D.CL_CODE
FROM @Orders O
	INNER JOIN dbo.RADIO_HDR D ON O.ORDER_NBR = D.ORDER_NBR

UPDATE O SET MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
FROM @Orders O
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON O.ORDER_NBR = MBWMDD.ORDER_NBR
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID

UPDATE O SET
	VERIFY_RATE = S.VERIFY_RATE,
	VERIFY_NETWORK = S.VERIFY_NETWORK,
	VERIFY_SCHEDULE = S.VERIFY_SCHEDULE,
	VERIFY_DAY = S.VERIFY_DAY,
	VERIFY_TIME = S.VERIFY_TIME,
	VERIFY_TIME_SEP = S.VERIFY_TIME_SEP,
	VERIFY_AD_NUMBER = S.VERIFY_AD_NUMBER,
	VERIFY_LENGTH = S.VERIFY_LENGTH,
	IS_SET = 1,
	MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = S.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID,
	ADJACENCY_BEFORE = S.ADJACENCY_BEFORE,
	ADJACENCY_AFTER = S.ADJACENCY_AFTER,
	BOOKEND_MAX_SEPARATION = S.BOOKEND_MAX_SEPARATION
FROM @Orders O
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING S ON O.MEDIA_BROADCAST_WORKSHEET_ID = S.MEDIA_BROADCAST_WORKSHEET_ID
WHERE IS_SET IS NULL

UPDATE O SET
	VERIFY_RATE = S.VERIFY_RATE,
	VERIFY_NETWORK = S.VERIFY_NETWORK,
	VERIFY_SCHEDULE = S.VERIFY_SCHEDULE,
	VERIFY_DAY = S.VERIFY_DAY,
	VERIFY_TIME = S.VERIFY_TIME,
	VERIFY_TIME_SEP = S.VERIFY_TIME_SEP,
	VERIFY_AD_NUMBER = S.VERIFY_AD_NUMBER,
	VERIFY_LENGTH = S.VERIFY_LENGTH,
	IS_SET = 1,
	BRDCAST_DTL_VERIFICATION_SETTING_ID = S.SETTING_ID,
	ADJACENCY_BEFORE = S.ADJACENCY_BEFORE,
	ADJACENCY_AFTER = S.ADJACENCY_AFTER,
	BOOKEND_MAX_SEPARATION = S.BOOKEND_MAX_SEPARATION
FROM @Orders O
	INNER JOIN dbo.BRDCAST_DTL_VERIFICATION_SETTING S ON O.MEDIA_TYPE_CODE = S.MEDIA_TYPE_CODE AND O.CL_CODE = S.CL_CODE
WHERE IS_SET IS NULL

UPDATE O SET
	VERIFY_RATE = S.VERIFY_RATE,
	VERIFY_NETWORK = S.VERIFY_NETWORK,
	VERIFY_SCHEDULE = S.VERIFY_SCHEDULE,
	VERIFY_DAY = S.VERIFY_DAY,
	VERIFY_TIME = S.VERIFY_TIME,
	VERIFY_TIME_SEP = S.VERIFY_TIME_SEP,
	VERIFY_AD_NUMBER = S.VERIFY_AD_NUMBER,
	VERIFY_LENGTH = S.VERIFY_LENGTH,
	IS_SET = 1,
	BRDCAST_DTL_VERIFICATION_SETTING_ID = S.SETTING_ID,
	ADJACENCY_BEFORE = S.ADJACENCY_BEFORE,
	ADJACENCY_AFTER = S.ADJACENCY_AFTER,
	BOOKEND_MAX_SEPARATION = S.BOOKEND_MAX_SEPARATION
FROM @Orders O
	INNER JOIN dbo.BRDCAST_DTL_VERIFICATION_SETTING S ON O.MEDIA_TYPE_CODE = S.MEDIA_TYPE_CODE
WHERE IS_SET IS NULL

INSERT INTO @OrderTimeSettings (BRDCAST_DTL_VERIFICATION_SETTING_ID, MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID, TIME_LENGTH, TIME_SEPARATION)
SELECT O.BRDCAST_DTL_VERIFICATION_SETTING_ID, O.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID, TIME_LENGTH, TIME_SEPARATION
FROM @Orders O
	CROSS APPLY dbo.advtf_get_time_separation_settings(O.BRDCAST_DTL_VERIFICATION_SETTING_ID, O.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID)

IF @debug = 1 BEGIN
	SELECT * FROM @Orders
	SELECT * FROM @OrderTimeSettings
END
	
DECLARE @ActualSpots TABLE (
	OrderNumber int,
	LineNumber smallint,
	WeekOf smalldatetime,
	ActualSpots smallint,
	WeekOfSpots smallint
)

INSERT INTO @ActualSpots (ActualSpots, WeekOf, LineNumber, OrderNumber, WeekOfSpots)
SELECT COUNT(1), WeekOf, ORDER_LINE_NBR, ORDER_NBR, [WeekOfSpots]
FROM
(
	SELECT WeekOf = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate), DTL.ORDER_LINE_NBR, DTL.ORDER_NBR,
		[WeekOfSpots] = CASE 
							WHEN ORD.DATE5 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE5 THEN ORD.SPOTS5
							WHEN ORD.DATE4 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE4 THEN ORD.SPOTS4
							WHEN ORD.DATE3 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE3 THEN ORD.SPOTS3
							WHEN ORD.DATE2 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE2 THEN ORD.SPOTS2
							WHEN ORD.DATE1 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE1 THEN ORD.SPOTS1
							ELSE COALESCE(ORD.SPOTS1, 0)
						END
	FROM dbo.AP_TV_BROADCAST_DTL DTL
		LEFT OUTER JOIN dbo.TV_DETAIL ORD ON ORD.ACTIVE_REV = 1 AND DTL.ORDER_NBR = ORD.ORDER_NBR AND DTL.ORDER_LINE_NBR = ORD.LINE_NBR
	WHERE DTL.ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))

	UNION ALL

	SELECT WeekOf = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate), DTL.ORDER_LINE_NBR, DTL.ORDER_NBR,
		[WeekOfSpots] = CASE 
							WHEN ORD.DATE5 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE5 THEN ORD.SPOTS5
							WHEN ORD.DATE4 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE4 THEN ORD.SPOTS4
							WHEN ORD.DATE3 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE3 THEN ORD.SPOTS3
							WHEN ORD.DATE2 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE2 THEN ORD.SPOTS2
							WHEN ORD.DATE1 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE1 THEN ORD.SPOTS1
							ELSE COALESCE(ORD.SPOTS1, 0)
						END
	FROM dbo.AP_RADIO_BROADCAST_DTL DTL
		LEFT OUTER JOIN dbo.RADIO_DETAIL ORD ON ORD.ACTIVE_REV = 1 AND DTL.ORDER_NBR = ORD.ORDER_NBR AND DTL.ORDER_LINE_NBR = ORD.LINE_NBR
	WHERE DTL.ORDER_NBR IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ','))
) dtl
GROUP BY WeekOf, ORDER_LINE_NBR, ORDER_NBR, [WeekOfSpots]

IF @debug = 1
	SELECT * FROM @ActualSpots

SELECT 
	[DetailID] = D.[ID],
	D.[MediaType],
	D.[VendorCode],
	D.[VendorName],
	D.[Vendor],
	D.[OrderNumber],
  	D.[OrderLineNumber],
  	D.[RunDate],
	D.[WeekOf],
	D.[WeekOfSpots],
  	D.[RunTime],
  	D.[DayOfWeek],
	D.[DayOfWeekNumber],
  	D.[Length],
  	D.[AdNumber],
  	D.[NetworkID],
  	D.[GrossRate],
	D.[Approved],
	D.[Comment],
	D.[VariantCodes],
	D.[IsLineNumberVerified],
  	D.[IsRateVerified],
  	D.[IsNetworkVerified],
  	D.[IsScheduleVerified],
  	D.[IsDayOfWeekVerified],
  	D.[IsTimeVerified],
  	D.[IsTimeSeparationVerified],
  	D.[IsAdNumberVerified],
  	D.[IsLengthVerified],
	D.[IsSpotVerified],
	D.[IsBookendVerified],
	D.[OrderMonthNumber],
	D.[OrderYearNumber],
	D.[WorksheetLineNumber],
	D.[ProgramName]
FROM
	(SELECT 
		C.[ID],
		C.[LineItemCount],
		C.[LineItemLineNumber],
		C.[MediaType],
		C.[VendorCode],
		C.[VendorName],
		C.[Vendor],
		C.[OrderNumber],
  		C.[OrderLineNumber],
  		C.[RunDate],
  		C.[RunTime],
  		C.[DayOfWeek],
		C.[DayOfWeekNumber],
  		C.[Length],
  		C.[AdNumber],
  		C.[NetworkID],
  		C.[GrossRate],
		C.[Approved],
		C.[Comment],
		[VariantCodes] = CASE WHEN LEN(C.[VariantCodes]) > 0 THEN SUBSTRING(C.[VariantCodes], 1, LEN(C.[VariantCodes]) - 2) ELSE '' END,
		C.[IsRateVerified],
		C.[IsNetworkVerified],
		C.[IsScheduleVerified],
		C.[IsDayOfWeekVerified],
		C.[IsTimeVerified],
		C.[IsTimeSeparationVerified],
		C.[IsAdNumberVerified],
		C.[IsLengthVerified],
		C.[IsSpotVerified],
		C.[IsBookendVerified],
		C.[MatchingOrderLines],
		C.[IsLineNumberVerified],
		[OrderMonthNumber] = CASE WHEN C.[MatchingOrderLines] <> 1 THEN NULL ELSE C.[OrderMonthNumber] END,
		[OrderYearNumber] = CASE WHEN C.[MatchingOrderLines] <> 1 THEN NULL ELSE C.[OrderYearNumber] END,
		C.[WeekOf],
		C.[WeekOfSpots],
		C.[WorksheetLineNumber],
		C.[ProgramName]
	FROM
		(SELECT
			B.[ID],
			B.[LineItemCount],
			B.[LineItemLineNumber],
			B.[MediaType],
			B.[VendorCode],
			B.[VendorName],
			B.[Vendor],
			B.[OrderNumber],
  			B.[OrderLineNumber],
  			B.[RunDate],
  			B.[RunTime],
  			B.[DayOfWeek],
			B.[DayOfWeekNumber],
  			B.[Length],
  			B.[AdNumber],
  			B.[NetworkID],
  			B.[GrossRate],
			B.[Approved],
			B.[Comment],
			[VariantCodes] = CASE
								WHEN B.IsLineNumberVerified = 1 THEN 
									CASE B.[IsRateVerified]
 											WHEN 1 THEN ''
 											ELSE 'Rate | '
 										END + 
 										CASE B.[IsNetworkVerified]
 											WHEN 1 THEN ''
 											ELSE 'Network | '
 										END + 
 										CASE B.[IsScheduleVerified]
 											WHEN 1 THEN ''
 											ELSE 'Sched | '
 										END + 
 										CASE B.[IsDayOfWeekVerified]
 											WHEN 1 THEN ''
 											ELSE 'Day | '
 										END + 
 										CASE B.[IsTimeVerified]
 											WHEN 1 THEN ''
 											ELSE 'Time | '
 										END + 
 										CASE B.[IsTimeSeparationVerified]
 											WHEN 1 THEN ''
 											ELSE 'Time Sep | '
 										END + 
 										CASE B.[IsAdNumberVerified]
 											WHEN 1 THEN ''
 											ELSE 'AdNbr | '
 										END + 
 										CASE B.[IsLengthVerified]
 											WHEN 1 THEN ''
 											ELSE 'Length | '
 										END +
										CASE B.[IsSpotVerified]
 											WHEN 1 THEN ''
 											ELSE 'Spot | '
 										END +
										CASE WHEN B.[IsBookendVerified] = '' THEN ''
											ELSE B.[IsBookendVerified]
										END 
								ELSE 'Unmatched | '
								END,
  			B.[IsRateVerified],
  			B.[IsNetworkVerified],
  			B.[IsScheduleVerified],
  			B.[IsDayOfWeekVerified],
  			B.[IsTimeVerified],
  			B.[IsTimeSeparationVerified],
  			B.[IsAdNumberVerified],
  			B.[IsLengthVerified],
			B.[IsSpotVerified],
			B.[IsBookendVerified],
			B.[IsAllVerified],
			B.[IsLineNumberVerified],
			[MatchingOrderLines] = COUNT(CASE WHEN B.OrderLineNumber IS NOT NULL OR B.IsAllVerified = 1 THEN 1 END) OVER (PARTITION BY B.ID, B.MediaType),
			[TotalOrderLines] = COUNT(1) OVER (PARTITION BY B.ID, B.MediaType),
			B.[OrderMonthNumber],
			B.[OrderYearNumber],
			B.[WeekOf],
			B.[WeekOfSpots],
			B.[WorksheetLineNumber],
			B.[ProgramName]
		FROM
			(SELECT
				[ID],
				[LineItemCount],
				[LineItemLineNumber],
				[MediaType],
				[VendorCode],
				[VendorName],
				[Vendor],
 				[OrderNumber],
  				[OrderLineNumber],
  				[RunDate],
  				[RunTime],
  				[DayOfWeek],
				[DayOfWeekNumber],
  				[Length],
  				[AdNumber],
  				[NetworkID],
  				[GrossRate],
				[Approved],
				[Comment],
  				[IsRateVerified] = CONVERT(BIT, [IsRateVerified]),
  				[IsNetworkVerified] = CONVERT(BIT, [IsNetworkVerified]),
  				[IsScheduleVerified] = CONVERT(BIT, [IsScheduleVerified]),
  				[IsDayOfWeekVerified] = CONVERT(BIT, [IsDayOfWeekVerified]),
  				[IsTimeVerified] = CONVERT(BIT, [IsTimeVerified]),
  				[IsTimeSeparationVerified] = CONVERT(BIT, [IsTimeSeparationVerified]),
  				[IsAdNumberVerified] = CONVERT(BIT, [IsAdNumberVerified]),
  				[IsLengthVerified] = CONVERT(BIT, [IsLengthVerified]),
				[IsSpotVerified] = CONVERT(BIT, [IsSpotVerified]),
				[IsBookendVerified],
				[IsAllVerified] = CONVERT(BIT, CASE 
													WHEN [IsRateVerified] = 1 AND [IsNetworkVerified] = 1 AND [IsScheduleVerified] = 1 AND 
															[IsDayOfWeekVerified] = 1 AND [IsTimeVerified] = 1 AND [IsTimeSeparationVerified] = 1 AND 
															[IsAdNumberVerified] = 1 AND [IsLengthVerified] = 1	AND [IsSpotVerified] = 1 AND [IsBookendVerified] = ''
															THEN 1 
													ELSE 0 
											END),												
				[IsLineNumberVerified] = CONVERT(BIT, CASE WHEN [OrderLineNumber] IS NOT NULL THEN 1 ELSE 0 END),
				[OrderMonthNumber],
				[OrderYearNumber],
				[WeekOf],
				[WeekOfSpots],
				[WorksheetLineNumber],
				[ProgramName]
			FROM
				(SELECT 
 					BrdOrd.[ID],
					[LineItemCount] = COUNT(1) OVER (PARTITION BY ID, MediaType),
					[LineItemLineNumber] = ROW_NUMBER() OVER (PARTITION BY ID, MediaType ORDER BY ID),
  					BrdOrd.[MediaType],
					BrdOrd.[VendorCode],
					BrdOrd.[VendorName],
					BrdOrd.[Vendor],
 					BrdOrd.[OrderNumber],
 					BrdOrd.[OrderLineNumber],
 					BrdOrd.[OfficeCode],
 					BrdOrd.[RunDate],
 					BrdOrd.[RunTime],
 					[DayOfWeek] = CASE BrdOrd.[DayOfWeekNumber]
 									WHEN 1 THEN 'M'
 									WHEN 2 THEN 'T'
 									WHEN 3 THEN 'W'
 									WHEN 4 THEN 'Th'
 									WHEN 5 THEN 'F'
 									WHEN 6 THEN 'Sa'
 									WHEN 7 THEN 'Su'
 									END,
 					BrdOrd.[DayOfWeekNumber],
 					BrdOrd.[Length],
 					BrdOrd.[AdNumber],
 					BrdOrd.[NetworkID],
 					BrdOrd.[GrossRate],
 					BrdOrd.[Approved],
 					BrdOrd.[Comment],
   					[IsRateVerified] = CASE 
 											WHEN S.VERIFY_RATE = 0 THEN 1
 											WHEN BrdOrd.IsNetOrder = 1 AND BrdOrd.NetRate = ISNULL(BrdOrd.OrderNetRate, 0) THEN 1 
											WHEN BrdOrd.IsNetOrder = 0 AND BrdOrd.GrossRate = ISNULL(BrdOrd.OrderGrossRate, 0) THEN 1 
 											ELSE 0 
 										END,
   					[IsNetworkVerified] = CASE 
 											WHEN S.VERIFY_NETWORK = 0 OR BrdOrd.MediaType = 'Radio' THEN 1 
 											WHEN UPPER(ISNULL(BrdOrd.NetworkID, '')) = UPPER(ISNULL(BrdOrd.OrderNetworkID, '')) THEN 1 
 											ELSE 0 
 											END,
   					[IsScheduleVerified] = CASE  
 												WHEN S.VERIFY_SCHEDULE = 0 THEN 1 
 												WHEN BrdOrd.RunDate >= BrdOrd.OrderStartDate AND BrdOrd.RunDate <= BrdOrd.OrderEndDate THEN 1 
 												ELSE 0 
 											END,
   					[IsDayOfWeekVerified] = CASE 
 												WHEN S.VERIFY_DAY = 0 THEN 1
 												ELSE ISNULL(
 														CASE BrdOrd.DayOfWeekNumber 
 															WHEN 1 THEN BrdOrd.OrderMonday 
 															WHEN 2 THEN BrdOrd.OrderTuesday
 															WHEN 3 THEN BrdOrd.OrderWednesday 
 															WHEN 4 THEN BrdOrd.OrderThursday  
 															WHEN 5 THEN BrdOrd.OrderFriday 
 															WHEN 6 THEN BrdOrd.OrderSaturday  
 															WHEN 7 THEN BrdOrd.OrderSunday  
 															ELSE 0 
 														END, 0)
 												END,
   					[IsTimeVerified] = CASE 
 											WHEN S.VERIFY_TIME = 0 THEN 1
 											WHEN ISDATE(BrdOrd.OrderStartTime) = 1 AND ISDATE(BrdOrd.OrderEndTime) = 1 THEN
												CASE 
													WHEN BrdOrd.RunTime BETWEEN DATEADD(n, S.ADJACENCY_BEFORE * -1, CONVERT(TIME, BrdOrd.OrderStartTime)) AND 
														CASE WHEN CONVERT(TIME, BrdOrd.OrderEndTime) = '00:00:00.0000000' THEN dateadd(ss,-1,CONVERT(TIME, BrdOrd.OrderEndTime))
														ELSE DATEADD(n, S.ADJACENCY_AFTER, CONVERT(TIME, BrdOrd.OrderEndTime))
														END THEN 1
													WHEN CAST(BrdOrd.OrderEndTime as time) < CAST(BrdOrd.OrderStartTime as time) AND BrdOrd.RunTime BETWEEN '00:00:00.0000000' AND DATEADD(n, S.ADJACENCY_AFTER, CONVERT(TIME, BrdOrd.OrderEndTime)) THEN 1
													WHEN CAST(BrdOrd.OrderEndTime as time) < CAST(BrdOrd.OrderStartTime as time) AND BrdOrd.RunTime BETWEEN DATEADD(n, S.ADJACENCY_BEFORE * -1, CONVERT(TIME, BrdOrd.OrderStartTime)) AND '23:59:59.0000000' THEN 1
 												ELSE 0 
												END
											ELSE 0
 										END,
   					[IsTimeSeparationVerified] = CASE 
 													WHEN S.VERIFY_TIME_SEP = 0 OR ISNULL(TS.TIME_SEPARATION, 0) = 0 OR BrdOrd.[IsOrderLineBookend] = 1 THEN 1
 													WHEN dbo.advfn_time_sep_verify(BrdOrd.ID, BrdOrd.MediaType, TS.TIME_SEPARATION) = 1 THEN 1 
 													ELSE 0 
 													END, 
   					[IsAdNumberVerified] = CASE 
 												WHEN S.VERIFY_AD_NUMBER = 0 THEN 1
 												WHEN ISNULL(BrdOrd.AdNumber, '') = ISNULL(BrdOrd.OrderAdNumber, '') THEN 1 
 												ELSE 0 
 											END,
   					[IsLengthVerified] = CASE
 											WHEN S.VERIFY_LENGTH = 0 THEN 1
 											WHEN ISNULL(BrdOrd.[Length], 0) = ISNULL(BrdOrd.OrderLength, 0) THEN 1 
 											ELSE 0 
 											END,
					[IsSpotVerified] = 
										--CASE WHEN @ShowWeekOf = 0 THEN
										--	CASE WHEN EXISTS(SELECT 1 FROM @ActualSpots WHERE OrderNumber = BrdOrd.OrderNumber AND LineNumber = BrdOrd.OrderLineNumber AND ActualSpots <> WeekOfSpots) THEN 0 ELSE 1 END
										--ELSE 
											CASE WHEN WeekOfSpots = (SELECT ActualSpots FROM @ActualSpots WHERE OrderNumber = BrdOrd.OrderNumber AND LineNumber = BrdOrd.OrderLineNumber AND WeekOf = BrdOrd.WeekOf) THEN 1 ELSE 0 END,
										--END,
					[IsBookendVerified] = CASE
											WHEN BrdOrd.[IsOrderLineBookend] = 1 THEN
												--CASE WHEN 
												dbo.advfn_bookend_verify(BrdOrd.ID, BrdOrd.MediaType, S.BOOKEND_MAX_SEPARATION, S.VERIFY_TIME_SEP, COALESCE(TS.TIME_SEPARATION, 0)) --= 1 THEN 1
												--ELSE 0
												--END
											ELSE ''
											END,
					BrdOrd.[OrderMonthNumber],
					BrdOrd.[OrderYearNumber],
					BrdOrd.[WeekOf],
					BrdOrd.[WeekOfSpots],
					BrdOrd.[WorksheetLineNumber],
					BrdOrd.ClientCode,
					BrdOrd.[ProgramName]
				FROM
 					(SELECT
  						[ID] = DTL.DTL_ID,					
  						[MediaType] = 'TV',
						[VendorCode] = V.VN_CODE,
						[VendorName] = V.VN_NAME,
						[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
    					[OrderNumber] = DTL.ORDER_NBR,
						[OrderLineNumber] = DTL.ORDER_LINE_NBR,
 						[OfficeCode] = ORH.OFFICE_CODE,
    					[RunDate] = DTL.RUN_DATE,
    					[RunTime] = DTL.TIME_OF_DAY,
  						[DayOfWeekNumber] = DTL.DAY_OF_WEEK,
    					[Length] = DTL.[LENGTH],
    					[AdNumber] = DTL.AD_NUMBER,
    					[NetworkID] = DTL.NETWORK_ID,
    					[GrossRate] = DTL.GROSS_RATE,
  						[Approved] = DTL.APPROVED,
  						[Comment] = DTL.COMMENT,
 						[TotalSpots] = Spots.TOTAL_SPOTS,
  						[OrderGrossRate] = ORD.GROSS_RATE,
  						[OrderNetworkID] = COALESCE(NULLIF(ORD.CABLE_NETWORK_STATION_CODE,''), NULLIF(ORD.NETWORK_ID,'')),
  						[OrderStartDate] = ORD.[START_DATE],
  						[OrderEndDate] = ORD.END_DATE,
  						[OrderMonday] = ORD.MONDAY,
  						[OrderTuesday] = ORD.TUESDAY,
  						[OrderWednesday] = ORD.WEDNESDAY,
  						[OrderThursday] = ORD.THURSDAY,
  						[OrderFriday] = ORD.FRIDAY,
  						[OrderSaturday] = ORD.SATURDAY,
  						[OrderSunday] = ORD.SUNDAY,
  						[OrderStartTime] = ORD.START_TIME,
  						[OrderEndTime] = ORD.END_TIME,
  						[OrderAdNumber] = ORD.AD_NUMBER,
  						[OrderLength] = ORD.[LENGTH],
  						[OrderTotalSpots] = ORD.TOTAL_SPOTS,
						[OrderMonthNumber] = ORD.MONTH_NBR,
						[OrderYearNumber] = ORD.YEAR_NBR,
						[IsOrderLineBookend] = ORD.BOOKEND,
						[WeekOf] = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate),
						[WeekOfSpots] = CASE 
											WHEN ORD.DATE5 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE5 THEN ORD.SPOTS5
											WHEN ORD.DATE4 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE4 THEN ORD.SPOTS4
											WHEN ORD.DATE3 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE3 THEN ORD.SPOTS3
											WHEN ORD.DATE2 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE2 THEN ORD.SPOTS2
											WHEN ORD.DATE1 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE1 THEN ORD.SPOTS1
											ELSE COALESCE(ORD.SPOTS1, 0)
										END,
						WorksheetLineNumber = ORD.LINK_LINE_NUMBER,
						ClientCode = ORH.CL_CODE,
						IsNetOrder = CASE WHEN COALESCE(ORH.NET_GROSS, 1) = 0 THEN 1 ELSE 0 END,
						[NetRate] = DTL.NET_RATE,
						[OrderNetRate] = ORD.NET_RATE,
						[ProgramName] = DTL.[PROGRAM_NAME]
 					FROM
    					dbo.AP_TV_BROADCAST_DTL DTL
							INNER JOIN dbo.AP_HEADER APH ON DTL.AP_ID = APH.AP_ID AND DTL.AP_SEQ = APH.AP_SEQ
							LEFT OUTER JOIN dbo.TV_DETAIL ORD ON ORD.ACTIVE_REV = 1 AND DTL.ORDER_NBR = ORD.ORDER_NBR AND DTL.ORDER_LINE_NBR = ORD.LINE_NBR
							INNER JOIN dbo.TV_HDR ORH ON DTL.ORDER_NBR = ORH.ORDER_NBR
							LEFT OUTER JOIN	dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE
							LEFT OUTER JOIN
								(SELECT
   									H.ORDER_NBR,
   									H.ORDER_LINE_NBR,
   									TOTAL_SPOTS = COUNT(1)
   									FROM
   										dbo.AP_TV_BROADCAST_DTL D
   											INNER JOIN
   											(SELECT DISTINCT
												AP_ID,
												ORDER_NBR,
												ORDER_LINE_NBR
												FROM
													dbo.AP_TV
												WHERE
													MODIFY_DELETE IS NULL) H ON D.AP_ID = H.AP_ID AND
    																		D.ORDER_NBR = H.ORDER_NBR AND
																			D.ORDER_LINE_NBR = H.ORDER_LINE_NBR
   									GROUP BY
   									H.ORDER_NBR,
   									H.ORDER_LINE_NBR
								) Spots ON DTL.ORDER_NBR = Spots.ORDER_NBR AND DTL.ORDER_LINE_NBR = Spots.ORDER_LINE_NBR
					WHERE DTL.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumbers, ','))

 					UNION ALL
  
 					SELECT
  						[ID] = DTL.DTL_ID,
  						[MediaType] = 'Radio',
						[VendorCode] = V.VN_CODE,
						[VendorName] = V.VN_NAME,
						[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
    					[OrderNumber] = DTL.ORDER_NBR,
						[OrderLineNumber] = DTL.ORDER_LINE_NBR,
 						[OfficeCode] = ORH.OFFICE_CODE,
 						[RunDate] = DTL.RUN_DATE,
    					[RunTime] = DTL.TIME_OF_DAY,
  						[DayOfWeekNumber] = DTL.DAY_OF_WEEK,
    					[Length] = DTL.[LENGTH],
    					[AdNumber] = DTL.AD_NUMBER,
    					[NetworkID] = NULL,
    					[GrossRate] = DTL.GROSS_RATE,
  						[Approved] = DTL.APPROVED,
  						[Comment] = DTL.COMMENT,
 						[TotalSpots] = Spots.TOTAL_SPOTS,
  						[OrderGrossRate] = ORD.GROSS_RATE,
  						[OrderNetworkID] = NULL,
  						[OrderStartDate] = ORD.[START_DATE],
  						[OrderEndDate] = ORD.END_DATE,
  						[OrderMonday] = ORD.MONDAY,
  						[OrderTuesday] = ORD.TUESDAY,
  						[OrderWednesday] = ORD.WEDNESDAY,
  						[OrderThursday] = ORD.THURSDAY,
  						[OrderFriday] = ORD.FRIDAY,
  						[OrderSaturday] = ORD.SATURDAY,
  						[OrderSunday] = ORD.SUNDAY,
  						[OrderStartTime] = ORD.START_TIME,
  						[OrderEndTime] = ORD.END_TIME,
  						[OrderAdNumber] = ORD.AD_NUMBER,
  						[OrderLength] = ORD.[LENGTH],
  						[OrderTotalSpots] = ORD.TOTAL_SPOTS,
						[OrderMonthNumber] = ORD.MONTH_NBR,
						[OrderYearNumber] = ORD.YEAR_NBR,
						[IsOrderLineBookend] = 0,
						[WeekOf] = (SELECT MAX(weekdate) FROM dbo.fn_BroadcastCal() WHERE DTL.RUN_DATE >= weekdate),
						[WeekOfSpots] = CASE 
											WHEN ORD.DATE5 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE5 THEN ORD.SPOTS5
											WHEN ORD.DATE4 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE4 THEN ORD.SPOTS4
											WHEN ORD.DATE3 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE3 THEN ORD.SPOTS3
											WHEN ORD.DATE2 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE2 THEN ORD.SPOTS2
											WHEN ORD.DATE1 IS NOT NULL AND DTL.RUN_DATE >= ORD.DATE1 THEN ORD.SPOTS1
											ELSE COALESCE(ORD.SPOTS1, 0)
										END,
						WorksheetLineNumber = ORD.LINK_LINE_NUMBER,
						ClientCode = ORH.CL_CODE,
						IsNetOrder = CASE WHEN COALESCE(ORH.NET_GROSS, 1) = 0 THEN 1 ELSE 0 END,
						[NetRate] = DTL.NET_RATE,
						[OrderNetRate] = ORD.NET_RATE,
						[ProgramName] = ''
 					FROM
    					dbo.AP_RADIO_BROADCAST_DTL DTL
							INNER JOIN dbo.AP_HEADER APH ON DTL.AP_ID = APH.AP_ID AND DTL.AP_SEQ = APH.AP_SEQ
 							LEFT OUTER JOIN dbo.RADIO_DETAIL ORD ON ORD.ACTIVE_REV = 1 AND DTL.ORDER_NBR = ORD.ORDER_NBR AND DTL.ORDER_LINE_NBR = ORD.LINE_NBR
							INNER JOIN dbo.RADIO_HDR ORH ON DTL.ORDER_NBR = ORH.ORDER_NBR
							LEFT OUTER JOIN	dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE
 							LEFT OUTER JOIN
   								(SELECT 
   									H.ORDER_NBR,
   									H.ORDER_LINE_NBR,
   									TOTAL_SPOTS = COUNT(1)
   									FROM
   										dbo.AP_RADIO_BROADCAST_DTL D
   											INNER JOIN
											(SELECT DISTINCT
												AP_ID,
												ORDER_NBR,
												ORDER_LINE_NBR
												FROM
													dbo.AP_RADIO
												WHERE
												MODIFY_DELETE IS NULL) H ON D.AP_ID = H.AP_ID AND
    																		D.ORDER_NBR = H.ORDER_NBR AND
																			D.ORDER_LINE_NBR = H.ORDER_LINE_NBR
   									GROUP BY
   									H.ORDER_NBR,
   									H.ORDER_LINE_NBR
								) Spots ON DTL.ORDER_NBR = Spots.ORDER_NBR AND DTL.ORDER_LINE_NBR = Spots.ORDER_LINE_NBR
					WHERE DTL.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumbers, ','))
					) BrdOrd
						LEFT OUTER JOIN
 							@Orders S ON S.MEDIA_TYPE_CODE = SUBSTRING(BrdOrd.MediaType, 1,1) AND S.ORDER_NBR = BrdOrd.OrderNumber
						LEFT OUTER JOIN
							@OrderTimeSettings TS
								ON (S.BRDCAST_DTL_VERIFICATION_SETTING_ID = TS.BRDCAST_DTL_VERIFICATION_SETTING_ID OR S.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = TS.MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID)
								AND (BrdOrd.[Length] = TS.TIME_LENGTH OR TS.TIME_LENGTH IS NULL)
						--	dbo.TIME_SEPARATION_SETTING TS ON S.SETTING_ID = TS.BRDCAST_DTL_VERIFICATION_SETTING_ID AND
						--										BrdOrd.[Length] = TS.TIME_LENGTH
				) A 
				WHERE
					1 = CASE WHEN @MatchAdditionalParameters = 0 AND CAST(A.OrderNumber as varchar) + '|' + CAST(A.OrderLineNumber as varchar) IN (SELECT items FROM dbo.udf_split_list(@OrderNumberLineNumbers, ',')) THEN 1
							 WHEN @MatchAdditionalParameters = 1 AND CAST(A.OrderNumber as varchar) + '|' + CAST(A.OrderYearNumber as varchar) + '|' + CAST(A.OrderMonthNumber as varchar) IN (SELECT items FROM dbo.udf_split_list(@OrderYearMonths, ',')) THEN 1
							 WHEN @MatchAdditionalParameters = 1 AND A.OrderNumber IN (SELECT items FROM dbo.udf_split_list(@OrderNumbers, ',')) AND A.OrderLineNumber IS NULL THEN 1
						END
			) B
		) C
	) D
	WHERE
		D.OrderLineNumber IS NOT NULL OR (D.MatchingOrderLines <> 1 AND D.OrderLineNumber IS NULL AND D.LineItemLineNumber = 1)
GO
