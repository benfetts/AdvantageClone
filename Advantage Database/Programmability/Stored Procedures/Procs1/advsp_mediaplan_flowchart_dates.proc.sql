CREATE PROCEDURE [dbo].[advsp_mediaplan_flowchart_dates]
	@MediaPlanID AS int
AS

	DECLARE @StartDate smalldatetime
	DECLARE @EndDate smalldatetime

	SELECT
		@StartDate = MP.[START_DATE],
		@EndDate = MP.[END_DATE]
	FROM
		[dbo].[MEDIA_PLAN] AS MP
	WHERE 
		MP.MEDIA_PLAN_ID = @MediaPlanID

	SELECT 
		[Date] = SDMC.[DATE],
		[DateWeek] = SDMC.[WEEK],
		[DateWeekDate] = SDMC.[WEEKDATE],
		[DateMonth] = SDMC.[MONTH],
		[DateMonthName] = CASE WHEN SDMC.[MONTH] = 1 THEN 'January'
							   WHEN SDMC.[MONTH] = 2 THEN 'February'
							   WHEN SDMC.[MONTH] = 3 THEN 'March'
							   WHEN SDMC.[MONTH] = 4 THEN 'April'
							   WHEN SDMC.[MONTH] = 5 THEN 'May'
							   WHEN SDMC.[MONTH] = 6 THEN 'June'
							   WHEN SDMC.[MONTH] = 7 THEN 'July'
							   WHEN SDMC.[MONTH] = 8 THEN 'August'
							   WHEN SDMC.[MONTH] = 9 THEN 'September'
							   WHEN SDMC.[MONTH] = 10 THEN 'October'
							   WHEN SDMC.[MONTH] = 11 THEN 'November'
							   WHEN SDMC.[MONTH] = 12 THEN 'December' END,
		[DateQuarter] = SDMC.[QUARTER],
		[DateYear] = SDMC.[YEAR],
		[BroadcastDateWeek] = SDMC.BROADCAST_WEEK,
		[BroadcastDateWeekDate] = SDMC.BROADCAST_WEEKDATE,
		[BroadcastDateMonth] = SDMC.BROADCAST_MONTH,
		[BroadcastDateMonthName] = CASE WHEN SDMC.BROADCAST_MONTH = 1 THEN 'January'
										WHEN SDMC.BROADCAST_MONTH = 2 THEN 'February'
										WHEN SDMC.BROADCAST_MONTH = 3 THEN 'March'
										WHEN SDMC.BROADCAST_MONTH = 4 THEN 'April'
										WHEN SDMC.BROADCAST_MONTH = 5 THEN 'May'
										WHEN SDMC.BROADCAST_MONTH = 6 THEN 'June'
										WHEN SDMC.BROADCAST_MONTH = 7 THEN 'July'
										WHEN SDMC.BROADCAST_MONTH = 8 THEN 'August'
										WHEN SDMC.BROADCAST_MONTH = 9 THEN 'September'
										WHEN SDMC.BROADCAST_MONTH = 10 THEN 'October'
										WHEN SDMC.BROADCAST_MONTH = 11 THEN 'November'
										WHEN SDMC.BROADCAST_MONTH = 12 THEN 'December' END,
		[BroadcastDateQuarter] = SDMC.BROADCAST_QUARTER,
		[BroadcastDateYear] =  SDMC.BROADCAST_YEAR
	FROM 
		[dbo].[MEDIA_CALENDAR] AS SDMC
	WHERE 
		SDMC.[DATE] >= @StartDate 
		AND SDMC.[DATE] <= @EndDate





GO


