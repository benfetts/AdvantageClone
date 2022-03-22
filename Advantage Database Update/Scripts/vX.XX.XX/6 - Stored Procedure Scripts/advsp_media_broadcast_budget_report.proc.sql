CREATE PROCEDURE [dbo].[advsp_media_broadcast_budget_report]
	@MEDIA_BROADCAST_WORKSHEET_MARKET_ID	VARCHAR(100) = ''
	,@START_YEAR_MONTH						VARCHAR(1000) = ''
	,@END_YEAR_MONTH						VARCHAR(10) = ''
	,@USE_PRIMARY_DEMO						VARCHAR(10) = ''
	,@HEADER								VARCHAR(10) = ''
	,@LOCATION_NAME							VARCHAR(100) = ''
	,@VENDOR_FILTER							VARCHAR(100) = ''
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

	IF (@START_YEAR_MONTH IS NOT NULL)
		SET @START_DATE = CONVERT(DATE,CONVERT(VARCHAR,(CONVERT(INT,@START_YEAR_MONTH) % 100))+'/01/'+CONVERT(VARCHAR,(CONVERT(INT,@START_YEAR_MONTH) / 100)))
	ELSE
		SET @START_DATE = NULL
	
	IF (@END_YEAR_MONTH IS NOT NULL)
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

	CREATE UNIQUE INDEX HeadLineTable_MarketID ON #HeadLineTable (MEDIA_BROADCAST_WORKSHEET_MARKET_ID)

	INSERT INTO #HeadLineTable 
	SELECT 
		WORKSHEET.vint [MEDIA_BROADCAST_WORKSHEET_MARKET_ID] 
		,@START_DATE [START_DATE]
		,@END_DATE [END_DATE]
		,@PRIMARY_DEMO [USE_PRIMARY_DEMO]
	FROM
		[dbo].[charlist_to_table_int](@MEDIA_BROADCAST_WORKSHEET_MARKET_ID,',') WORKSHEET
			--INNER JOIN [dbo].[charlist_to_table_int](@START_YEAR_MONTH,',') STARTYEARMONTH
			--	ON WORKSHEET.listpos = STARTYEARMONTH.listpos
			--INNER JOIN [dbo].[charlist_to_table_int](@END_YEAR_MONTH,',') ENDYEARMONTH
			--	ON WORKSHEET.listpos = ENDYEARMONTH.listpos
			--INNER JOIN [dbo].[charlist_to_table_int](@USE_PRIMARY_DEMO,',') UPD
			--	ON WORKSHEET.listpos = UPD.listpos

	UPDATE #HeadLineTable
		SET
			START_DATE = [dbo].[advfn_broadcast_date](START_DATE,'B',HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
			,END_DATE =  [dbo].[advfn_broadcast_date](END_DATE,'E', HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID)
		FROM
			#HeadLineTable HLT

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


	CREATE TABLE #TotalsTable (
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID INT
		,BroadcastDate						DATE
		,PrimaryGRP							FLOAT
		,SecondaryGRP						FLOAT
		,Spots								INT
	)

	CREATE TABLE #MaxRevisionTable (
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID INT
		,REVISION_NUMBER					INT
	)

	INSERT INTO #MaxRevisionTable
	SELECT 
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID, 
		REVISION_NUMBER = MAX(REVISION_NUMBER) 
	FROM 
		dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL
	GROUP BY 
		MEDIA_BROADCAST_WORKSHEET_MARKET_ID

	INSERT INTO #TotalsTable
	SELECT 
		MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,CASE WHEN ((CASE WHEN (MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID =1) THEN 1 ELSE 7 END) = 7) THEN MC.BROADCAST_WEEKDATE ELSE MBW_MDD.DATE END
		,CASE
			WHEN (MBW.MEDIA_TYPE_CODE='T') THEN SUM(MBW_MD.PRIMARY_RATING * MBW_MDD.SPOTS * 1.000 )
			ELSE SUM(MBW_MD.PRIMARY_AQH_RATING * MBW_MDD.SPOTS * 1.000 )
		 END


		,CASE
			WHEN (MBW.MEDIA_TYPE_CODE='T') THEN SUM(MBW_MD.SECONDARY_RATING * MBW_MDD.SPOTS * 1.000)
			ELSE SUM(MBW_MD.SECONDARY_AQH_RATING * MBW_MDD.SPOTS * 1.000 )
		 END

		,SUM(MBW_MDD.SPOTS) 
	FROM
		dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBW_MDD
		INNER JOIN MEDIA_CALENDAR MC ON MBW_MDD.DATE = MC.DATE
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBW_MD ON MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBW_MDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
		INNER JOIN #VendorFilterTable VFT ON VFT.VN_CODE = MBW_MD.VN_CODE
		INNER JOIN #MaxRevisionTable AS MMB_WM ON MMB_WM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID AND MMB_WM.REVISION_NUMBER = MBW_MD.REVISION_NUMBER
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBW_M ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBW_MD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		INNER JOIN #HeadLineTable HLT ON HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBW_M.MEDIA_BROADCAST_WORKSHEET_ID
	WHERE 
		MBW.IS_INACTIVE = 0
		AND ((CASE WHEN ((CASE WHEN (MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID =1) THEN 1 ELSE 7 END) = 7) THEN MC.BROADCAST_WEEKDATE ELSE MBW_MDD.DATE END) BETWEEN HLT.START_DATE AND HLT.END_DATE)
	GROUP BY
		MBW.MEDIA_TYPE_CODE
		,MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,CASE WHEN ((CASE WHEN (MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID =1) THEN 1 ELSE 7 END) = 7) THEN MC.BROADCAST_WEEKDATE ELSE MBW_MDD.DATE END
		,MBW_MDD.DATE


	CREATE TABLE #GrossData(MEDIA_BROADCAST_WORKSHEET_MARKET_ID INT, BucketRow INT, Bucket INT, LastRow INT, WorkDate DATE,Spots INT, GoalGRP FLOAT, EstGRP FLOAT, BudgetIndex Float)

	INSERT INTO #GrossData (MEDIA_BROADCAST_WORKSHEET_MARKET_ID, BucketRow, Bucket, LastRow, WorkDate, Spots, GoalGRP, EstGRP, BudgetIndex)
	SELECT DISTINCT
		HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,0
		,ROW_NUMBER() OVER(PARTITION BY HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID ORDER BY TT.BroadcastDate) as Bucket
		,0 
		,TT.BroadcastDate
		,TT.Spots
		,PLANDATA.GoalGRP
		,CASE 
			WHEN (HLT.USE_PRIMARY_DEMO = 1) THEN TT.PrimaryGRP
			ELSE TT.SecondaryGRP
		END EstGRP
		,CASE 
			WHEN (HLT.USE_PRIMARY_DEMO = 1) THEN 
					CASE
						WHEN (PLANDATA.GoalGRP = 0) THEN 0.000
						ELSE TT.PrimaryGRP/PLANDATA.GoalGRP
					END
			ELSE 
				CASE
					WHEN (PLANDATA.GoalGRP = 0) THEN 0.000
					ELSE TT.SecondaryGRP/PLANDATA.GoalGRP
				END
		 END BudgetIndex

	FROM 
		MEDIA_BROADCAST_WORKSHEET MBW
		INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET MBW_M
			ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBW_M.MEDIA_BROADCAST_WORKSHEET_ID
		LEFT JOIN (
				SELECT
					MBW_MG.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					,MBW_MGD.DATE
					,SUM(MBW_MGD.GRP) GoalGRP
				FROM
					[dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL] MBW_MG
					INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_DATE] MBW_MGD
						ON MBW_MG.MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_ID = MBW_MGD.MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_ID
				GROUP BY
					MBW_MG.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					,MBW_MGD.DATE
			) PLANDATA
				ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = PLANDATA.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		INNER JOIN #HeadLineTable HLT
				ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		INNER JOIN 
			#TotalsTable TT
				ON MBW_M.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = TT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
				AND TT.BroadcastDate = [dbo].[advfn_broadcast_weekdate](PLANDATA.DATE)
	WHERE (1=1)
		AND (PLANDATA.DATE BETWEEN HLT.START_DATE and HLT.END_DATE)
	ORDER BY
		HLT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,TT.BroadcastDate
		,TT.Spots

	UPDATE #GrossData
		SET
			BucketRow = Bucket / 14
			,Bucket = Bucket % 14

	UPDATE #GrossData
		SET
			BucketRow = BucketRow -1
			,Bucket = 14
		WHERE Bucket = 0
	
	DECLARE @MaxRow INT 
	
	SELECT 
		@MaxRow = Max(BucketRow) 
	FROM #GrossData

	UPDATE #GrossData
		SET LastRow = 1
		WHERE BucketRow = @MaxRow

	SELECT 
		GDX.MEDIA_BROADCAST_WORKSHEET_MARKET_ID MediaBroadcastWorksheetMarketID
		,GDX.BucketRow
		,GDX.LastRow

		-----
		,MAX(GDX.Week1_Date) Week1Date
		,MAX(GDX.Week1_Spots) Week1Spots
		,MAX(ISNULL(GDX.Week1_GoalGRP,0)) Week1GoalGRP
		,MAX(GDX.Week1_EstGRP) Week1EstGRP
		,MAX(ISNULL(GDX.Week1_BudgetIndex,0)) Week1BudgetIndex

		-----
		,MAX(GDX.Week2_Date) Week2Date
		,MAX(GDX.Week2_Spots) Week2Spots
		,MAX(ISNULL(GDX.Week2_GoalGRP,0)) Week2GoalGRP
		,MAX(GDX.Week2_EstGRP) Week2EstGRP
		,MAX(ISNULL(GDX.Week2_BudgetIndex,0)) Week2BudgetIndex

		-----
		,MAX(GDX.Week3_Date) Week3Date
		,MAX(GDX.Week3_Spots) Week3Spots
		,MAX(ISNULL(GDX.Week3_GoalGRP,0)) Week3GoalGRP
		,MAX(GDX.Week3_EstGRP) Week3EstGRP
		,MAX(ISNULL(GDX.Week3_BudgetIndex,0)) Week3BudgetIndex

		-----
		,MAX(GDX.Week4_Date) Week4Date
		,MAX(GDX.Week4_Spots) Week4Spots
		,MAX(ISNULL(GDX.Week4_GoalGRP,0)) Week4GoalGRP
		,MAX(GDX.Week4_EstGRP) Week4EstGRP
		,MAX(ISNULL(GDX.Week4_BudgetIndex,0)) Week4BudgetIndex

		-----
		,MAX(GDX.Week5_Date) Week5Date
		,MAX(GDX.Week5_Spots) Week5Spots
		,MAX(ISNULL(GDX.Week5_GoalGRP,0)) Week5GoalGRP
		,MAX(GDX.Week5_EstGRP) Week5EstGRP
		,MAX(ISNULL(GDX.Week5_BudgetIndex,0)) Week5BudgetIndex

		-----
		,MAX(GDX.Week6_Date) Week6Date
		,MAX(GDX.Week6_Spots) Week6Spots
		,MAX(ISNULL(GDX.Week6_GoalGRP,0)) Week6GoalGRP
		,MAX(GDX.Week6_EstGRP) Week6EstGRP
		,MAX(ISNULL(GDX.Week6_BudgetIndex,0)) Week6BudgetIndex

		-----
		,MAX(GDX.Week7_Date) Week7Date
		,MAX(GDX.Week7_Spots) Week7Spots
		,MAX(ISNULL(GDX.Week7_GoalGRP,0)) Week7GoalGRP
		,MAX(GDX.Week7_EstGRP) Week7EstGRP
		,MAX(ISNULL(GDX.Week7_BudgetIndex,0)) Week7BudgetIndex

		-----
		,MAX(GDX.Week8_Date) Week8Date
		,MAX(GDX.Week8_Spots) Week8Spots
		,MAX(ISNULL(GDX.Week8_GoalGRP,0)) Week8GoalGRP
		,MAX(GDX.Week8_EstGRP) Week8EstGRP
		,MAX(ISNULL(GDX.Week8_BudgetIndex,0)) Week8BudgetIndex

		-----
		,MAX(GDX.Week9_Date) Week9Date
		,MAX(GDX.Week9_Spots) Week9Spots
		,MAX(ISNULL(GDX.Week9_GoalGRP,0)) Week9GoalGRP
		,MAX(GDX.Week9_EstGRP) Week9EstGRP
		,MAX(ISNULL(GDX.Week9_BudgetIndex,0)) Week9BudgetIndex

		-----
		,MAX(GDX.Week10_Date) Week10Date
		,MAX(GDX.Week10_Spots) Week10Spots
		,MAX(ISNULL(GDX.Week10_GoalGRP,0)) Week10GoalGRP
		,MAX(GDX.Week10_EstGRP) Week10EstGRP
		,MAX(ISNULL(GDX.Week10_BudgetIndex,0)) Week10BudgetIndex

		-----
		,MAX(GDX.Week11_Date) Week11Date
		,MAX(GDX.Week11_Spots) Week11Spots
		,MAX(ISNULL(GDX.Week11_GoalGRP,0)) Week11GoalGRP
		,MAX(GDX.Week11_EstGRP) Week11EstGRP
		,MAX(ISNULL(GDX.Week11_BudgetIndex,0)) Week11BudgetIndex

		-----
		,MAX(GDX.Week12_Date) Week12Date
		,MAX(GDX.Week12_Spots) Week12Spots
		,MAX(ISNULL(GDX.Week12_GoalGRP,0)) Week12GoalGRP
		,MAX(GDX.Week12_EstGRP) Week12EstGRP
		,MAX(ISNULL(GDX.Week12_BudgetIndex,0)) Week12BudgetIndex

		-----
		,MAX(GDX.Week13_Date) Week13Date
		,MAX(GDX.Week13_Spots) Week13Spots
		,MAX(ISNULL(GDX.Week13_GoalGRP,0)) Week13GoalGRP
		,MAX(GDX.Week13_EstGRP) Week13EstGRP
		,MAX(ISNULL(GDX.Week13_BudgetIndex,0)) Week13BudgetIndex

		-----
		,MAX(GDX.Week14_Date) Week14Date
		,MAX(GDX.Week14_Spots) Week14Spots
		,MAX(ISNULL(GDX.Week14_GoalGRP,0)) Week14GoalGRP
		,MAX(GDX.Week14_EstGRP) Week14EstGRP
		,MAX(ISNULL(GDX.Week14_BudgetIndex,0)) Week14BudgetIndex

	FROM 
				(SELECT
					GD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					,GD.BucketRow
					,GD.LastRow
		
					------
					,CASE
						WHEN (Bucket = 1) THEN MAX(WorkDate)
					 END Week1_Date
					,CASE
						WHEN (Bucket = 1) THEN MAX(Spots)
					 END Week1_Spots
					,CASE
						WHEN (Bucket = 1) THEN MAX(GoalGRP)
					 END Week1_GoalGRP
					 ,CASE
						WHEN (Bucket = 1) THEN MAX(EstGRP)
					 END Week1_EstGRP
					 ,CASE
						WHEN (Bucket = 1) THEN MAX(BudgetIndex)
					 END Week1_BudgetIndex

					 ------
					,CASE
						WHEN (Bucket = 2) THEN MAX(WorkDate)
					 END Week2_Date
					,CASE
						WHEN (Bucket = 2) THEN MAX(Spots)
					 END Week2_Spots
					,CASE
						WHEN (Bucket = 2) THEN MAX(GoalGRP)
					 END Week2_GoalGRP
					 ,CASE
						WHEN (Bucket = 2) THEN MAX(EstGRP)
					 END Week2_EstGRP
					 ,CASE
						WHEN (Bucket = 2) THEN MAX(BudgetIndex)
					 END Week2_BudgetIndex

					 ------
					,CASE
						WHEN (Bucket = 3) THEN MAX(WorkDate)
					 END Week3_Date
					,CASE
						WHEN (Bucket = 3) THEN MAX(Spots)
					 END Week3_Spots
					,CASE
						WHEN (Bucket = 3) THEN MAX(GoalGRP)
					 END Week3_GoalGRP
					 ,CASE
						WHEN (Bucket = 3) THEN MAX(EstGRP)
					 END Week3_EstGRP
					 ,CASE
						WHEN (Bucket = 3) THEN MAX(BudgetIndex)
					 END Week3_BudgetIndex

					 ------
					,CASE
						WHEN (Bucket = 4) THEN MAX(WorkDate)
					 END Week4_Date
					,CASE
						WHEN (Bucket = 4) THEN MAX(Spots)
					 END Week4_Spots
					,CASE
						WHEN (Bucket = 4) THEN MAX(GoalGRP)
					 END Week4_GoalGRP
					 ,CASE
						WHEN (Bucket = 4) THEN MAX(EstGRP)
					 END Week4_EstGRP
					 ,CASE
						WHEN (Bucket = 4) THEN MAX(BudgetIndex)
					 END Week4_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 5) THEN MAX(WorkDate)
					 END Week5_Date
					,CASE
						WHEN (Bucket = 5) THEN MAX(Spots)
					 END Week5_Spots
					,CASE
						WHEN (Bucket = 5) THEN MAX(GoalGRP)
					 END Week5_GoalGRP
					 ,CASE
						WHEN (Bucket = 5) THEN MAX(EstGRP)
					 END Week5_EstGRP
					 ,CASE
						WHEN (Bucket = 5) THEN MAX(BudgetIndex)
					 END Week5_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 6) THEN MAX(WorkDate)
					 END Week6_Date
					,CASE
						WHEN (Bucket = 6) THEN MAX(Spots)
					 END Week6_Spots
					,CASE
						WHEN (Bucket = 6) THEN MAX(GoalGRP)
					 END Week6_GoalGRP
					 ,CASE
						WHEN (Bucket = 6) THEN MAX(EstGRP)
					 END Week6_EstGRP
					 ,CASE
						WHEN (Bucket = 6) THEN MAX(BudgetIndex)
					 END Week6_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 7) THEN MAX(WorkDate)
					 END Week7_Date
					,CASE
						WHEN (Bucket = 7) THEN MAX(Spots)
					 END Week7_Spots
					,CASE
						WHEN (Bucket = 7) THEN MAX(GoalGRP)
					 END Week7_GoalGRP
					 ,CASE
						WHEN (Bucket = 7) THEN MAX(EstGRP)
					 END Week7_EstGRP
					 ,CASE
						WHEN (Bucket = 7) THEN MAX(BudgetIndex)
					 END Week7_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 8) THEN MAX(WorkDate)
					 END Week8_Date
					,CASE
						WHEN (Bucket = 8) THEN MAX(Spots)
					 END Week8_Spots
					,CASE
						WHEN (Bucket = 8) THEN MAX(GoalGRP)
					 END Week8_GoalGRP
					 ,CASE
						WHEN (Bucket = 8) THEN MAX(EstGRP)
					 END Week8_EstGRP
					 ,CASE
						WHEN (Bucket = 8) THEN MAX(BudgetIndex)
					 END Week8_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 9) THEN MAX(WorkDate)
					 END Week9_Date
					,CASE
						WHEN (Bucket = 9) THEN MAX(Spots)
					 END Week9_Spots
					,CASE
						WHEN (Bucket = 9) THEN MAX(GoalGRP)
					 END Week9_GoalGRP
					 ,CASE
						WHEN (Bucket = 9) THEN MAX(EstGRP)
					 END Week9_EstGRP
					 ,CASE
						WHEN (Bucket = 9) THEN MAX(BudgetIndex)
					 END Week9_BudgetIndex


					  ------
					,CASE
						WHEN (Bucket = 10) THEN MAX(WorkDate)
					 END Week10_Date
					,CASE
						WHEN (Bucket = 10) THEN MAX(Spots)
					 END Week10_Spots
					,CASE
						WHEN (Bucket = 10) THEN MAX(GoalGRP)
					 END Week10_GoalGRP
					 ,CASE
						WHEN (Bucket = 10) THEN MAX(EstGRP)
					 END Week10_EstGRP
					 ,CASE
						WHEN (Bucket = 10) THEN MAX(BudgetIndex)
					 END Week10_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 11) THEN MAX(WorkDate)
					 END Week11_Date
					,CASE
						WHEN (Bucket = 11) THEN MAX(Spots)
					 END Week11_Spots
					,CASE
						WHEN (Bucket = 11) THEN MAX(GoalGRP)
					 END Week11_GoalGRP
					 ,CASE
						WHEN (Bucket = 11) THEN MAX(EstGRP)
					 END Week11_EstGRP
					 ,CASE
						WHEN (Bucket = 11) THEN MAX(BudgetIndex)
					 END Week11_BudgetIndex

					 ------
					,CASE
						WHEN (Bucket = 12) THEN MAX(WorkDate)
					 END Week12_Date
					,CASE
						WHEN (Bucket = 12) THEN MAX(Spots)
					 END Week12_Spots
					,CASE
						WHEN (Bucket = 12) THEN MAX(GoalGRP)
					 END Week12_GoalGRP
					 ,CASE
						WHEN (Bucket = 12) THEN MAX(EstGRP)
					 END Week12_EstGRP
					 ,CASE
						WHEN (Bucket = 12) THEN MAX(BudgetIndex)
					 END Week12_BudgetIndex


					  ------
					,CASE
						WHEN (Bucket = 13) THEN MAX(WorkDate)
					 END Week13_Date
					,CASE
						WHEN (Bucket = 13) THEN MAX(Spots)
					 END Week13_Spots
					,CASE
						WHEN (Bucket = 13) THEN MAX(GoalGRP)
					 END Week13_GoalGRP
					 ,CASE
						WHEN (Bucket = 13) THEN MAX(EstGRP)
					 END Week13_EstGRP
					 ,CASE
						WHEN (Bucket = 13) THEN MAX(BudgetIndex)
					 END Week13_BudgetIndex

					  ------
					,CASE
						WHEN (Bucket = 14) THEN MAX(WorkDate)
					 END Week14_Date
					,CASE
						WHEN (Bucket = 14) THEN MAX(Spots)
					 END Week14_Spots
					,CASE
						WHEN (Bucket = 14) THEN MAX(GoalGRP)
					 END Week14_GoalGRP
					 ,CASE
						WHEN (Bucket = 14) THEN MAX(EstGRP)
					 END Week14_EstGRP
					 ,CASE
						WHEN (Bucket = 14) THEN MAX(BudgetIndex)
					 END Week14_BudgetIndex
				FROM 
					#GrossData GD
				GROUP BY 
					GD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
					,GD.BucketRow
					,GD.Bucket
					,GD.LastRow) GDX
		GROUP BY
			GDX.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		,GDX.BucketRow
		,GDX.LastRow


	DROP TABLE #VendorFilterTable
	DROP TABLE #HeadLineTable
	DROP TABLE #MaxRevisionTable
	DROP TABLE #GrossData
	DROP TABLE #TotalsTable

END 
GO