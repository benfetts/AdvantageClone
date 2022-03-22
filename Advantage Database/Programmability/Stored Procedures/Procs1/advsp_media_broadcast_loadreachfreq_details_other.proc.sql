CREATE PROCEDURE [dbo].[advsp_media_broadcast_loadreachfreq_details_other]
	@MEDIA_BROADCAST_WORKSHEET_MARKET_ID	VARCHAR(1000) = ''
	,@START_YEAR_MONTH						VARCHAR(10) = NULL
	,@END_YEAR_MONTH						VARCHAR(10) = NULL
	,@USE_PRIMARY_DEMO						VARCHAR(10) = ''
	,@VENDOR_FILTER							VARCHAR(MAX) = ''
	,@EXACT_START_DATE						SMALLDATETIME = NULL
	,@EXACT_END_DATE						SMALLDATETIME = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @Today DATE = GETDATE()
	
	CREATE TABLE #VendorFilterTable (VN_CODE VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CS_AS)

	CREATE UNIQUE INDEX VendorFilterTable_MarketID ON #VendorFilterTable (VN_CODE)

	DECLARE @START_DATE DATE
	DECLARE @END_DATE	DATE
	DECLARE @PRIMARY_DEMO INT

	IF @EXACT_START_DATE IS NOT NULL 
		SET @START_DATE = @EXACT_START_DATE
	ELSE IF (@START_YEAR_MONTH IS NOT NULL)
		SET @START_DATE = CONVERT(DATE,CONVERT(VARCHAR,(CONVERT(INT,@START_YEAR_MONTH) % 100))+'/01/'+CONVERT(VARCHAR,(CONVERT(INT,@START_YEAR_MONTH) / 100)))
	ELSE
		SET @START_DATE = NULL
	
	IF @EXACT_END_DATE IS NOT NULL 
		SET @END_DATE = @EXACT_END_DATE
	ELSE IF (@END_YEAR_MONTH IS NOT NULL)
		SET @END_DATE = DATEADD(DAY,-1,DATEADD(MONTH,1,CONVERT(DATE,CONVERT(VARCHAR,(CONVERT(INT,@END_YEAR_MONTH) % 100))+'/01/'+CONVERT(VARCHAR,(CONVERT(INT,@END_YEAR_MONTH) / 100)))))
	ELSE
		SET @END_DATE = NULL
	
	IF (@USE_PRIMARY_DEMO IS NOT NULL)
		SET @PRIMARY_DEMO = 1
	ELSE
		SET @PRIMARY_DEMO = 0

	CREATE TABLE #HeadLineTable (
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID INT
		,START_DATE							DATE
		,END_DATE							DATE
		,USE_PRIMARY_DEMO					INT
	)

	CREATE UNIQUE INDEX MarketID ON #HeadLineTable (MEDIA_BROADCAST_WORKSHEET_MARKET_ID)

	INSERT INTO #HeadLineTable 
	SELECT 
		WORKSHEET.vint	[MEDIA_BROADCAST_WORKSHEET_MARKET_ID]
		,@START_DATE	[START_DATE]
		,@END_DATE		[END_DATE]
		,@PRIMARY_DEMO	[USE_PRIMARY_DEMO]
	FROM
		[dbo].[charlist_to_table_int](@MEDIA_BROADCAST_WORKSHEET_MARKET_ID,',') WORKSHEET
			

	--UPDATE #HeadLineTable
	--	SET
	--		START_DATE = [dbo].[advfn_broadcast_date](START_DATE,'B',HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
	--		,END_DATE = [dbo].[advfn_broadcast_date](END_DATE,'E', HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
	--	FROM
	--		#HeadLineTable HLT

	DECLARE @HighestVersion AS TABLE (
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID INT
		,VN_CODE VARCHAR(10)
		,ORDER_NUMBER	VARCHAR(10)
		,REVISION_NUMBER INT)

	INSERT INTO @HighestVersion
	  SELECT 
		MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,VN_CODE
		,''
		,MAX(REVISION_NUMBER) REVISION_NUMBER
	  FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBW_MD WITH (NOLOCK)
			INNER JOIN #HeadLineTable HLT
				ON MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	  GROUP BY
		MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,VN_CODE
	  ORDER BY 
		MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,VN_CODE

	IF (LEN(@VENDOR_FILTER) = 0)
		BEGIN			
			INSERT INTO #VendorFilterTable
			SELECT DISTINCT
				MBW_MD.VN_CODE
			FROM 
				MEDIA_BROADCAST_WORKSHEET MBW WITH (NOLOCK)
					INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET MBW_M WITH (NOLOCK)
						ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
					INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBW_MD WITH (NOLOCK)
						ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					INNER JOIN #HeadLineTable HLT
						ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
			WHERE (1=1)
				AND MBW.IS_INACTIVE = 0
		END
	ELSE
		BEGIN
			INSERT INTO #VendorFilterTable
			SELECT
				VF.vstr
			FROM 
				dbo.charlist_to_table_tsa(@VENDOR_FILTER,',') VF
		END

	SELECT

	-- Filters

		MBW.MEDIA_TYPE_CODE										MediaTypeCode
		,MBW.MEDIA_BROADCAST_WORKSHEET_ID						MediaBroadcastWorksheetID
		,MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID				MediaBroadCastWorksheetMarketID
		,V.NIELSEN_RADIO_STATION_COMBO_ID						VendorRadioStationComboID
		,V.[NIELSEN_TV_STATION_CODE]							VendorNielsenTVStationCode
		,MBW_MD.CABLE_NETWORK_NIELSEN_TV_STATION_CODE			CableNetworkNielsenTVStationCode
		,MBW_MD.VN_CODE											VendorCode
	
	--Line Data
		
		,MBW_M.SHAREBOOK_NIELSEN_TV_BOOK_ID						SharebookNielsenTVBookID
		,MBW_M.NIELSEN_RADIO_PERIOD_ID1							NeilsenRadioPeriodID1
		,MBW_M.NIELSEN_RADIO_PERIOD_ID2							NeilsenRadioPeriodID2
		,MBW_M.IS_CABLE											IsCable
		,CASE 
			WHEN (MBW_M.IS_CABLE = 1) THEN M.MARKET_DESC + ' (Cable)'
			ELSE M.MARKET_DESC
		 END													MarketDescription
		,MBW_MD.ON_HOLD											OnHold
		,MBW_MDD.SPOTS											Spots
		,MBW_MD.PRIMARY_IMPRESSIONS								PrimaryBuyImpressions
		,MBW_MD.PRIMARY_CUME_IMPRESSIONS					    PrimaryCumeImpressions
		,MBW_MD.PRIMARY_CUME									PrimaryCume
		,MBW_MD.PRIMARY_UNIVERSE								PrimaryUniverse
		,MBW_MD.PRIMARY_RATING									PrimaryRating
		,MBW_MD.BOOK_PRIMARY_RATING								PrimaryBookRating
		,MBW_MD.PRIMARY_AQH										PrimaryAQH
		,MBW_MD.PRIMARY_AQH_RATING								PrimaryAQHRating
		,MBW_MD.BOOK_PRIMARY_AQH_RATING							PrimaryBookAQHRating
		,MBW_MD.PRIMARY_GRP										PrimaryGRP
		,MBW_MD.PRIMARY_REACH									PrimaryReach

		,MBW_MD.SECONDARY_IMPRESSIONS							SecondaryBuyImpressions
		,MBW_MD.SECONDARY_CUME_IMPRESSIONS					    SecondaryCumeImpressions
		,MBW_MD.SECONDARY_CUME								    SecondaryCume
		,MBW_MD.SECONDARY_UNIVERSE								SecondaryUniverse
		,MBW_MD.SECONDARY_RATING								SecondaryRating
		,MBW_MD.BOOK_SECONDARY_RATING							SecondaryBookRating
		,MBW_MD.SECONDARY_AQH									SecondaryAQH
		,MBW_MD.SECONDARY_AQH_RATING							SecondaryAQHRating
		,MBW_MD.BOOK_SECONDARY_AQH_RATING						SecondaryBookAQHRating
		,MBW_MD.SECONDARY_GRP									SecondaryGRP
		,MBW_MD.SECONDARY_REACH									SecondaryReach
		
		
	FROM
		[dbo].[MEDIA_BROADCAST_WORKSHEET] MBW WITH (NOLOCK)
				INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBW_M WITH (NOLOCK)
					ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBW_M.MEDIA_BROADCAST_WORKSHEET_ID
				LEFT JOIN [dbo].[MARKET] M WITH (NOLOCK)
					ON MBW_M.MARKET_CODE = M.MARKET_CODE
				INNER JOIN #HeadLineTable HLT
					ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
				INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBW_MD WITH (NOLOCK)
					ON MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					INNER JOIN #VendorFilterTable VFT
						ON MBW_MD.VN_CODE = VFT.VN_CODE
					INNER JOIN @HighestVersion HV
						ON MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = HV.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
							AND MBW_MD.VN_CODE = HV.VN_CODE
							AND MBW_MD.REVISION_NUMBER = HV.REVISION_NUMBER
				INNER JOIN (SELECT 
									MDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID,
									SPOTS = SUM(MDD.SPOTS)
								FROM
									[dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MDD WITH (NOLOCK) 
									INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MD ON MD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
									INNER JOIN #HeadLineTable HLT ON HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
								WHERE 
									MDD.DATE BETWEEN HLT.START_DATE AND HLT.END_DATE
								GROUP BY
									MDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID) MBW_MDD ON MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBW_MDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
				LEFT JOIN VENDOR V
					ON MBW_MD.VN_CODE = V.VN_CODE
	WHERE (1=1)
			AND (MBW.IS_INACTIVE = 0)
			-- Filters
			AND (MBW_MD.ON_HOLD = 0)
		
ORDER BY
		MBW.MEDIA_TYPE_CODE							
		,MBW.MEDIA_BROADCAST_WORKSHEET_ID			
		,MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID	
		,MBW_MD.VN_CODE								
		
END
GO


