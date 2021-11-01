CREATE PROCEDURE [dbo].[advsp_broadcast_weeks]
	@CutoffDate varchar(10) = '12/30/1996'
AS

SELECT
	BroadcastYear = BRD_YEAR,
	BroadcastMonth = BRD_MONTH,
	BroadcastWeekStart = BRD_WEEK_START,
	BroadcastWeekEnd = BRD_WEEK_END,
	MonthAbbrevisation = MONTH_NAME,
	WeekNumber = WEEK_NBR,
	MonthYear = MMYYYY,
	YearMonth = CAST(BRD_YEAR as varchar(4)) + RIGHT('0' + CAST(BRD_MONTH as varchar(2)), 2)
FROM 
	dbo.fn_BroadcastCal2(@CutoffDate)
