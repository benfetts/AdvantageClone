CREATE PROCEDURE [dbo].[proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATEUpdate]
	@TemplateID							INT
	,@WorkSheetID						INT
	,@TemplateName						VARCHAR(50)
	,@RunDetail							BIT
	,@RunMarket							BIT	
	,@RunStation						BIT	
	,@RunWeeklyDaily					BIT
	,@Location							VARCHAR(50)
	,@ShowSecondary						BIT
	,@ShowRatings						BIT
	,@ShowComments						BIT
	,@ShowSpotCosts						BIT
	,@ShowImpressions					BIT
	,@ShowBookends						BIT
	,@ShowTotalCosts					BIT
	,@ShowCPPM							BIT
	,@ShowAddedValue					BIT
	,@ShowRF							BIT
	,@DateFrom							VARCHAR(50)
	,@DateTo							VARCHAR(50)
	,@Markets							VARCHAR(MAX)
	,@Vendors							VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [dbo].[MEDIA_BROADCAST_SCHEDULE_TEMPLATE]
	   SET [MEDIA_BROADCAST_WORKSHEET_ID]		= @WorkSheetID
		  ,[TEMPLATE_NAME]						= @TemplateName
		  ,[RUN_DETAIL]							= @RunDetail
		  ,[RUN_MARKET]							= @RunMarket
		  ,[RUN_STATION]						= @RunStation
		  ,[RUN_WEEKLY_DAILY]					= @RunWeeklyDaily
		  ,[LOCATION]							= @Location
		  ,[SHOW_SECONDARY]						= @ShowSecondary
		  ,[SHOW_RATINGS]						= @ShowRatings	
		  ,[SHOW_COMMENTS]						= @ShowComments	
		  ,[SHOW_SPOTCOSTS]						= @ShowSpotCosts	
		  ,[SHOW_IMPRESSIONS]					= @ShowImpressions
		  ,[SHOW_BOOKSENDS]						= @ShowBookends
		  ,[SHOW_TOTALCOSTS]					= @ShowTotalCosts
		  ,[SHOW_CPPM]							= @ShowCPPM	
		  ,[SHOW_ADDEDVALUE]					= @ShowAddedValue
		  ,[DATE_FROM]							= @DateFrom
		  ,[DATE_TO]							= @DateTo
		  ,[MARKETS]							= @Markets
		  ,[VENDORS]							= @Vendors
	 WHERE (1=1)
		AND [MEDIA_BROADCAST_SCHEDULE_TEMPLATE_ID] = @TemplateID

END

