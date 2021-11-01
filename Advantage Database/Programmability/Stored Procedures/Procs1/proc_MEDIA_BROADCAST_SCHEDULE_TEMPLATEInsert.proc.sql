CREATE PROCEDURE [dbo].[proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATEInsert]
	@WorkSheetID		INT
	,@TemplateName		VARCHAR(50)
	,@RunDetail			BIT
	,@RunMarket			BIT	
	,@RunStation		BIT	
	,@RunWeeklyDaily	BIT
	,@Location			VARCHAR(50)
	,@ShowSecondary		BIT
	,@ShowRatings		BIT
	,@ShowComments		BIT
	,@ShowSpotCosts		BIT
	,@ShowImpressions	BIT
	,@ShowBookends		BIT
	,@ShowTotalCosts	BIT
	,@ShowCPPM			BIT
	,@ShowAddedValue	BIT
	,@ShowRF			BIT
	,@DateFrom			VARCHAR(50)
	,@DateTo			VARCHAR(50)
	,@Markets			VARCHAR(MAX)
	,@Vendors			VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[MEDIA_BROADCAST_SCHEDULE_TEMPLATE]
           ([MEDIA_BROADCAST_WORKSHEET_ID]
           ,[TEMPLATE_NAME]		
           ,[RUN_DETAIL]
           ,[RUN_MARKET]
           ,[RUN_STATION]
           ,[RUN_WEEKLY_DAILY]	 
           ,[LOCATION]
		   ,[SHOW_SECONDARY]
		   ,[SHOW_RATINGS]
		   ,[SHOW_COMMENTS]
		   ,[SHOW_SPOTCOSTS]
		   ,[SHOW_IMPRESSIONS]
		   ,[SHOW_BOOKSENDS]
		   ,[SHOW_TOTALCOSTS] 
		   ,[SHOW_CPPM]
		   ,[SHOW_ADDEDVALUE] 
		   ,[SHOW_RF]
           ,[DATE_FROM]
           ,[DATE_TO]
           ,[MARKETS]
           ,[VENDORS])
     VALUES
           (@WorkSheetID	
			,@TemplateName	
			,@RunDetail		
			,@RunMarket		
			,@RunStation	
			,@RunWeeklyDaily
			,@Location	
			,@ShowSecondary
			,@ShowRatings		
			,@ShowComments
			,@ShowSpotCosts	
			,@ShowImpressions	
			,@ShowBookends		
			,@ShowTotalCosts	
			,@ShowCPPM			
			,@ShowAddedValue	
			,@ShowRF				
			,@DateFrom		
			,@DateTo		
		    ,@Markets		
			,@Vendors)	

END

