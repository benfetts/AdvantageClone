CREATE PROCEDURE [dbo].[proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATELoad]
	@WorkSheetID		INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [MEDIA_BROADCAST_SCHEDULE_TEMPLATE_ID]	TemplateID
		  ,[MEDIA_BROADCAST_WORKSHEET_ID]			WorksheetID
		  ,[TEMPLATE_NAME]							TemplateName
		  ,[RUN_DETAIL]								RunDetail
		  ,[RUN_MARKET]								RunMarket
		  ,[RUN_STATION]							RunStation
		  ,[RUN_WEEKLY_DAILY]						RunWeeklyDaily
		  ,[LOCATION]								Location
		  ,[SHOW_SECONDARY]							ShowSecondary
		  ,[SHOW_RATINGS]							ShowRatings
		  ,[SHOW_COMMENTS]							ShowComments
		  ,[SHOW_SPOTCOSTS]							ShowSpotCosts
		  ,[SHOW_IMPRESSIONS]						ShowImpressions
		  ,[SHOW_BOOKSENDS]							ShowBookends
		  ,[SHOW_TOTALCOSTS]						ShowTotalCosts
	      ,[SHOW_CPPM]								ShowCPPM
		  ,[SHOW_ADDEDVALUE]						ShowAddedValue
		  ,[SHOW_RF]								ShowRF
		  ,[DATE_FROM]								DateFrom
		  ,[DATE_TO]								DateTo
		  ,[MARKETS]								Markets
		  ,[VENDORS]								Vendors
	  FROM [dbo].[MEDIA_BROADCAST_SCHEDULE_TEMPLATE]
	  WHERE (1=1)
		AND [MEDIA_BROADCAST_WORKSHEET_ID] = @WorkSheetID


END

