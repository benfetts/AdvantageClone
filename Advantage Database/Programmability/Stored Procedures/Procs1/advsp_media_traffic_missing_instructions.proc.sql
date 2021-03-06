CREATE PROCEDURE [dbo].[advsp_media_traffic_missing_instructions]
	@MEDIA_BROADCAST_WORKSHEET_IDs varchar(max),
	@MEDIA_BROADCAST_WORKSHEET_MARKET_ID int,
	@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs varchar(max)
AS

DECLARE @worksheet_market_vendor_dates TABLE (
	MEDIA_BROADCAST_WORKSHEET_ID int NOT NULL,
	[NAME] varchar(100) NOT NULL,
	MEDIA_BROADCAST_WORKSHEET_MARKET_ID int NOT NULL,
	VN_CODE varchar(6) NOT NULL,
	SUN smalldatetime NULL,
	MON smalldatetime NULL,
	TUE smalldatetime NULL,
	WED smalldatetime NULL,
	THU smalldatetime NULL,
	FRI smalldatetime NULL,
	SAT smalldatetime NULL
)

DECLARE @MEDIATRAFFIC_STARTDT smalldatetime

SELECT @MEDIATRAFFIC_STARTDT = CONVERT(smalldatetime, AGY_SETTINGS_VALUE)
FROM dbo.AGY_SETTINGS
WHERE AGY_SETTINGS_CODE = 'MEDIATRAFFIC_STARTDT'

INSERT INTO @worksheet_market_vendor_dates
SELECT DISTINCT MBW.MEDIA_BROADCAST_WORKSHEET_ID, MBW.[NAME], MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MBWMD.VN_CODE,
	SUN = CASE WHEN DATEPART(dw, [DATE]) = 1 AND SUNDAY = 1 THEN [DATE] END,
	MON = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND MONDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 2 AND MONDAY = 1 THEN [DATE]
		  END,
	TUE = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND TUESDAY = 1 THEN DATEADD(d,2,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 2 AND TUESDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 3 AND TUESDAY = 1 THEN [DATE]
		  END,
	WED = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND WEDNESDAY = 1 THEN DATEADD(d,3,[DATE])
			WHEN DATEPART(dw, [DATE]) = 2 AND WEDNESDAY = 1 THEN DATEADD(d,2,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 3 AND WEDNESDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 4 AND WEDNESDAY = 1 THEN [DATE]
		  END,
	THU = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND THURSDAY = 1 THEN DATEADD(d,4,[DATE])
			WHEN DATEPART(dw, [DATE]) = 2 AND THURSDAY = 1 THEN DATEADD(d,3,[DATE])
			WHEN DATEPART(dw, [DATE]) = 3 AND THURSDAY = 1 THEN DATEADD(d,2,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 4 AND THURSDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 5 AND THURSDAY = 1 THEN [DATE]
		  END,
	FRI = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND FRIDAY = 1 THEN DATEADD(d,5,[DATE])
			WHEN DATEPART(dw, [DATE]) = 2 AND FRIDAY = 1 THEN DATEADD(d,4,[DATE])
			WHEN DATEPART(dw, [DATE]) = 3 AND FRIDAY = 1 THEN DATEADD(d,3,[DATE])
			WHEN DATEPART(dw, [DATE]) = 4 AND FRIDAY = 1 THEN DATEADD(d,2,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 5 AND FRIDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 6 AND FRIDAY = 1 THEN [DATE]
		  END,
	SAT = CASE 
			WHEN DATEPART(dw, [DATE]) = 1 AND SATURDAY = 1 THEN DATEADD(d,6,[DATE])
			WHEN DATEPART(dw, [DATE]) = 2 AND SATURDAY = 1 THEN DATEADD(d,5,[DATE])
			WHEN DATEPART(dw, [DATE]) = 3 AND SATURDAY = 1 THEN DATEADD(d,4,[DATE])
			WHEN DATEPART(dw, [DATE]) = 4 AND SATURDAY = 1 THEN DATEADD(d,3,[DATE])
			WHEN DATEPART(dw, [DATE]) = 5 AND SATURDAY = 1 THEN DATEADD(d,2,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 6 AND SATURDAY = 1 THEN DATEADD(d,1,[DATE]) 
			WHEN DATEPART(dw, [DATE]) = 7 AND SATURDAY = 1 THEN [DATE]
		  END
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID AND MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 2
	INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE AND C.RESP_FOR_MEDIA_TRAFFIC_INSTRUCTION = 0
	INNER JOIN (
				SELECT MAX(MBWMD.REVISION_NUMBER) as MAXREV, MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
				FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
				GROUP BY MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID) T ON T.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND T.MAXREV = MBWMD.REVISION_NUMBER 
where 
	MBWMDD.SPOTS > 0
AND MBWMDD.IS_HIATUS = 0
AND MBWMDD.ALLOW_SPOTS_TO_BE_ENTERED = 1
AND MBWMDD.ORDER_NBR IS NOT NULL
AND (@MEDIA_BROADCAST_WORKSHEET_IDs IS NULL OR MBW.MEDIA_BROADCAST_WORKSHEET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_IDs, ',')))
AND (@MEDIA_BROADCAST_WORKSHEET_MARKET_ID IS NULL OR MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = @MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
AND (@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs IS NULL OR MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs, ',')))
AND (@MEDIATRAFFIC_STARTDT IS NULL OR (@MEDIATRAFFIC_STARTDT IS NOT NULL AND (@MEDIATRAFFIC_STARTDT BETWEEN MBW.[START_DATE] AND MBW.END_DATE) OR (@MEDIATRAFFIC_STARTDT <= MBW.[START_DATE])))

DECLARE @ALL_DATES TABLE (
	MEDIA_BROADCAST_WORKSHEET_ID int NOT NULL,
	[NAME] varchar(100) NOT NULL,
	MEDIA_BROADCAST_WORKSHEET_MARKET_ID int NOT NULL,
	VN_CODE varchar(6) NOT NULL,
	SPOTDATE smalldatetime NOT NULL
)

INSERT INTO @ALL_DATES
SELECT DISTINCT MEDIA_BROADCAST_WORKSHEET_ID, [NAME], MEDIA_BROADCAST_WORKSHEET_MARKET_ID, VN_CODE, SPOTDATE
FROM @worksheet_market_vendor_dates
UNPIVOT
(
	SPOTDATE
	FOR thedate in (SUN, MON, TUE, WED, THU, FRI, SAT)
) u

UNION

SELECT MBW.MEDIA_BROADCAST_WORKSHEET_ID, MBW.[NAME], MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MBWMD.VN_CODE, MBWMDD.[DATE] AS SPOTDATE
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID AND MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 1
	INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE AND C.RESP_FOR_MEDIA_TRAFFIC_INSTRUCTION = 0
	INNER JOIN (
				SELECT MAX(MBWMD.REVISION_NUMBER) as MAXREV, MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
				FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
				GROUP BY MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID) T ON T.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND T.MAXREV = MBWMD.REVISION_NUMBER 
where 
	MBWMDD.SPOTS > 0
AND MBWMDD.IS_HIATUS = 0
AND MBWMDD.ALLOW_SPOTS_TO_BE_ENTERED = 1
AND MBWMDD.ORDER_NBR IS NOT NULL
AND (@MEDIA_BROADCAST_WORKSHEET_IDs IS NULL OR MBW.MEDIA_BROADCAST_WORKSHEET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_IDs, ',')))
AND (@MEDIA_BROADCAST_WORKSHEET_MARKET_ID IS NULL OR MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = @MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
AND (@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs IS NULL OR MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs, ',')))
AND (@MEDIATRAFFIC_STARTDT IS NULL OR (@MEDIATRAFFIC_STARTDT IS NOT NULL AND (@MEDIATRAFFIC_STARTDT BETWEEN MBW.[START_DATE] AND MBW.END_DATE) OR (@MEDIATRAFFIC_STARTDT <= MBW.[START_DATE])))

--select * from @ALL_DATES

SELECT DISTINCT
	[WorksheetID] = AD.MEDIA_BROADCAST_WORKSHEET_ID,
	[WorksheetName] = AD.[NAME], 
	[WorksheetMarketID] = AD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, 
	[VendorCode] = AD.VN_CODE,
	[VendorName] = V.VN_NAME,
	[SpotDate] = AD.SPOTDATE, 
	[IsMissing] = CAST(1 as bit)
INTO #MISSING_TRAFFIC
FROM @ALL_DATES AD
	INNER JOIN dbo.VENDOR V ON AD.VN_CODE = V.VN_CODE

UPDATE MT SET IsMissing = 0
FROM #MISSING_TRAFFIC MT
	INNER JOIN (
				SELECT MBWMT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MTV.VN_CODE, MTR.REVISION_NUMBER, 
					MTR.[START_DATE], MTR.END_DATE, MTR.[DESCRIPTION], MTR.MEDIA_TRAFFIC_ID, MTR.MEDIA_TRAFFIC_REVISION_ID 
				FROM dbo.MEDIA_TRAFFIC_REVISION MTR
					INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC MBWMT ON MBWMT.MEDIA_TRAFFIC_ID = MTR.MEDIA_TRAFFIC_ID 
					INNER JOIN dbo.MEDIA_TRAFFIC_VENDOR MTV ON MTR.MEDIA_TRAFFIC_REVISION_ID = MTV.MEDIA_TRAFFIC_REVISION_ID 
					INNER JOIN (
								SELECT MAX(REVISION_NUMBER) as MAXREV, MEDIA_TRAFFIC_ID 
								FROM dbo.MEDIA_TRAFFIC_REVISION 
								GROUP BY MEDIA_TRAFFIC_ID) T ON T.MEDIA_TRAFFIC_ID = MTR.MEDIA_TRAFFIC_ID AND T.MAXREV = MTR.REVISION_NUMBER
				) COVERED ON MT.WorksheetMarketID = COVERED.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND MT.VendorCode = COVERED.VN_CODE 
WHERE MT.SpotDate BETWEEN COVERED.[START_DATE] AND COVERED.END_DATE 

SELECT
	ID = NEWID(),
	[WorksheetID],
	[WorksheetName], 
	[ClientCode] = MBW.CL_CODE,
	[ClientName] = C.CL_NAME,
	[DivisionCode] = MBW.DIV_CODE,
	[DivisionName] = D.DIV_NAME,
	[ProductCode] = MBW.PRD_CODE,
	[ProductName] = P.PRD_DESCRIPTION,
	[MarketCode] = MBWM.MARKET_CODE,
	[MarketDescription] = M.MARKET_DESC,
	[WorksheetMarketID], 
	[VendorCode],
	[VendorName],
	[SpotDate]
FROM #MISSING_TRAFFIC MT
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MT.WorksheetID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MT.WorksheetMarketID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE
	INNER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE
	INNER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE
	INNER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE
WHERE IsMissing = 1
ORDER BY VendorName, SpotDate 

DROP TABLE #MISSING_TRAFFIC 
