CREATE PROC [advsp_media_manager_ad_serving_load_details]

	@OrderNumberLineNumberList varchar(max),
	@UserCode varchar(100),
	@AdServerID int,
	@DCProfileID bigint,
	@Debug bit = 0

AS

BEGIN

	SET NOCOUNT ON

	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit
	
	SET @HasCDPLimits = 0

	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserCode)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserCode)) > 0
		SET @HasCDPLimits = 1

	DECLARE @ORDERLINES TABLE (
		OrderNumber					int NOT NULL,
		InternetCostType			varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		InternetType				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PlacementName				varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MediaPlanDetailPackagePlacementNameID	int NULL,
		AdSizeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AdServerPlacementID			bigint NULL,
		LineNumber					smallint NOT NULL,
		AdServerID					int NOT NULL,
		ClientCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientName					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionName				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductDescription			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[OrderDescription]			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AdServerAdvertiserID]		bigint,
		[AdServerCampaignID]		bigint,
		[CampaignID]				integer NULL,
		[CampaignCode]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignName]				varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CampaignStartDate]			smalldatetime NULL,
		[CampaignEndDate]			smalldatetime NULL,
		[LandingPageName]			varchar(255) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[LandingPageURL]			varchar(max) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[VendorName]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[AdServerSiteID]			bigint NULL,
		InternetTypeDescription		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[PricingType]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		StartDate					smalldatetime NOT NULL,
		EndDate						smalldatetime NOT NULL,
		AdSizeDescription			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AdServerSizeID				bigint NULL,
		PlacementCreatedBy			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PlacementCreatedDate		smalldatetime NULL,
		PlacementRevisionBy			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PlacementRevisionDate		smalldatetime NULL,
		HasAdServerAdvertiserID		bit NOT NULL,
		HasAdServerCampaignID		bit NOT NULL,
		HasCampaignID				bit NOT NULL,
		HasAdServerSiteID			bit NOT NULL,
		VendorCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		ModifiedDate				smalldatetime NULL,
		GroupID						int NULL,
		IsCancelled					bit NOT NULL,
		PlacementManual				bit NOT NULL,
		PackageName					varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AdServerPlacementGroupID	bigint NULL,
		PackageParent				bit NOT NULL,
		IsNewPackage				bit NOT NULL
	)

	DECLARE @GROUP TABLE (
		GroupID						int IDENTITY(1,1) NOT NULL,
		OrderNumber					int NOT NULL,
		InternetCostType			varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		InternetType				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PlacementName				varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		MediaPlanDetailPackagePlacementNameID	int NULL,
		AdSizeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		LineNumbers					varchar(max) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AdServerPlacementID			bigint NULL,
		GroupRequiresUpdate			bit NULL,
		IsCancelled					bit NOT NULL,
		PlacementManual				bit NOT NULL,
		PackageName					varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AdServerPlacementGroupID	bigint NULL,
		PackageParent				bit NOT NULL
	)
	
	DECLARE @ORDER_PACKAGES TABLE (
		ORDER_NBR int NOT NULL,
		PLACEMENT_2 varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS null,
		AD_SIZE_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS null,
		PLACEMENT_NAME varchar(255) COLLATE SQL_Latin1_General_CP1_CS_AS null,
		MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID int NULL
	)

	INSERT INTO @ORDER_PACKAGES
	SELECT DISTINCT d.ORDER_NBR, COALESCE(d.PLACEMENT_2,'***NA***'), ipd.AD_SIZE_CODE, ipd.PLACEMENT_NAME, ipd.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID
	FROM dbo.INTERNET_DETAIL d
		LEFT OUTER JOIN dbo.INTERNET_PACKAGE_DETAIL ipd ON d.ORDER_NBR = ipd.ORDER_NBR AND d.LINE_NBR = ipd.LINE_NBR AND ipd.ACTIVE_REV = 1
	WHERE CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))
	AND d.ACTIVE_REV = 1

	INSERT INTO @ORDERLINES
	SELECT
		OrderNumber = h.ORDER_NBR,
		InternetCostType = d.COST_TYPE,
		InternetType = d.INTERNET_TYPE,
		PlacementName = REPLACE(REPLACE(CASE 
						WHEN NULLIF(op.PLACEMENT_NAME, '') IS NOT NULL THEN
							op.PLACEMENT_NAME 
						WHEN NULLIF(d.PLACEMENT_2, '') IS NOT NULL AND op.AD_SIZE_CODE IS NOT NULL THEN
							[dbo].[advfn_ad_server_placement_name]( m.MARKET_DESC, V.VN_NAME, d.COST_TYPE, d.HEADLINE, op.AD_SIZE_CODE, IT.OD_DESC, d.PLACEMENT_1, d.TARGET_AUDIENCE, h.ORDER_NBR, CMP.CMP_NAME, h.[START_DATE], h.END_DATE, 
								d.[URL], SUBSTRING(COALESCE(IC.INSTRUCTIONS,''),1,256), SUBSTRING(COALESCE(IC.MATL_NOTES,''),1,256), SUBSTRING(COALESCE(IC.MISC_INFO,''),1,256) )
						ELSE
							[dbo].[advfn_ad_server_placement_name]( m.MARKET_DESC, V.VN_NAME, d.COST_TYPE, d.HEADLINE, CASE WHEN ads.SIZE_CODE IS NULL THEN d.CREATIVE_SIZE 
																														ELSE ads.SIZE_DESC 
																														END, IT.OD_DESC, d.PLACEMENT_1, d.TARGET_AUDIENCE, h.ORDER_NBR, CMP.CMP_NAME, h.[START_DATE], h.END_DATE,
																														d.[URL], SUBSTRING(COALESCE(IC.INSTRUCTIONS,''),1,256), SUBSTRING(COALESCE(IC.MATL_NOTES,''),1,256), SUBSTRING(COALESCE(IC.MISC_INFO,''),1,256) )
						END, CHAR(13), ''), CHAR(10), ''),
		MediaPlanDetailPackagePlacementNameID = op.MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID,
		AdSizeCode = CASE WHEN NULLIF(d.PLACEMENT_2, '') IS NOT NULL AND op.AD_SIZE_CODE IS NOT NULL THEN 
							op.AD_SIZE_CODE
						ELSE d.SIZE
						END,
		AdServerPlacementID = d.AD_SERVER_PLACEMENT_ID,
		d.LINE_NBR,
		AdServerID = @AdServerID,
		[ClientCode] = h.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[OrderDescription] = h.ORDER_DESC,
		[AdServerAdvertiserID] = CAST(CASE WHEN ISNUMERIC(RSX.SOURCE_CL_CODE) = 1 THEN RSX.SOURCE_CL_CODE ELSE NULL END as bigint),
		[AdServerCampaignID] = CMP.AD_SERVER_CAMPAIGN_ID,
		[CampaignID] = h.CMP_IDENTIFIER,
		[CampaignCode] = CMP.CMP_CODE,
		[CampaignName] = CMP.CMP_NAME,
		[CampaignStartDate] = CMP.CMP_BEG_DATE,
		[CampaignEndDate] = CMP.CMP_END_DATE,
		[LandingPageName] = CW.WEBSITE_NAME,
		[LandingPageURL] = CW.WEBSITE_ADDRESS,
		[VendorName] = V.VN_NAME,
		[AdServerSiteID] = VDM.DC_SITE_ID,
		[InternetTypeDescription] = IT.OD_DESC,
		[PricingType] = CASE
							WHEN d.COST_TYPE = 'CPC' THEN 'PRICING_TYPE_CPC'
							WHEN d.COST_TYPE = 'CPM' THEN 'PRICING_TYPE_CPM'
							WHEN d.COST_TYPE = 'CPA' THEN 'PRICING_TYPE_CPA'
							WHEN d.COST_TYPE = 'NA' THEN 'PRICING_TYPE_FLAT_RATE_IMPRESSIONS'
						END,
		[StartDate] = d.[START_DATE],
		[EndDate] = d.END_DATE,
		[AdSizeDescription] = CASE WHEN ads.SIZE_CODE IS NULL THEN d.CREATIVE_SIZE ELSE ads.SIZE_DESC END,
		[AdServerSizeID] = ads.AD_SERVER_SIZE_ID,
		PlacementCreatedBy = d.AD_SERVER_CREATED_BY,
		PlacementCreatedDate = d.AD_SERVER_CREATED_DATETIME,
		PlacementRevisionBy = d.AD_SERVER_LAST_MODIFIED_BY,
		PlacementRevisionDate = d.AD_SERVER_LAST_MODIFIED_DATETIME,
		[HasAdServerAdvertiserID] = CAST(CASE WHEN ISNUMERIC(RSX.SOURCE_CL_CODE) = 1 THEN 1 ELSE 0 END as bit),
		[HasAdServerCampaignID] = CAST(CASE WHEN CMP.AD_SERVER_CAMPAIGN_ID IS NOT NULL THEN 1 ELSE 0 END as bit),
		[HasCampaignID] = CAST(CASE WHEN h.CMP_IDENTIFIER IS NOT NULL THEN 1 ELSE 0 END as bit),
		[HasAdServerSiteID] = CAST(CASE WHEN VDM.DC_SITE_ID IS NOT NULL THEN 1 ELSE 0 END as bit),
		[VendorCode] = h.VN_CODE,
		[ModifiedDate] = d.MODIFIED_DATE,
		GroupID = NULL,
		IsCancelled = COALESCE(d.LINE_CANCELLED, 0),
		PlacementManual = CAST(COALESCE(d.AD_SERVER_PLACEMENT_MANUAL, 0) as bit),
		PackageName = d.PLACEMENT_2,
		AdServerPlacementGroupID = d.AD_SERVER_PLACEMENT_GROUP_ID,
		PackageParent = COALESCE(d.PACKAGE_PARENT, 0),
		IsNewPackage = CAST(CASE WHEN NULLIF(d.PLACEMENT_2, '') IS NOT NULL AND (SELECT COUNT(1) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = h.ORDER_NBR AND PACKAGE_PARENT = 1) = 0 THEN 1 ELSE 0 END as bit)
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN @ORDER_PACKAGES op ON d.ORDER_NBR = op.ORDER_NBR AND COALESCE(d.PLACEMENT_2,'***NA***') COLLATE SQL_Latin1_General_CP1_CS_AS = op.PLACEMENT_2 COLLATE SQL_Latin1_General_CP1_CS_AS
		LEFT OUTER JOIN dbo.INTERNET_COMMENTS IC ON d.ORDER_NBR = IC.ORDER_NBR AND d.LINE_NBR = IC.LINE_NBR
		LEFT OUTER JOIN dbo.AD_SIZE ads ON d.SIZE = ads.SIZE_CODE AND ads.MEDIA_TYPE = 'I'
		LEFT OUTER JOIN dbo.CLIENT C ON h.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON h.CL_CODE = D.CL_CODE AND h.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON h.CL_CODE = P.CL_CODE AND h.DIV_CODE = P.DIV_CODE AND h.PRD_CODE = P.PRD_CODE
		LEFT OUTER JOIN dbo.CAMPAIGN CMP ON h.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
		LEFT OUTER JOIN dbo.AD_SERVER ADS ON CMP.AD_SERVER_ID = ADS.AD_SERVER_ID
		LEFT OUTER JOIN dbo.CL_WEBSITE CW ON CMP.CL_WEBSITE_ID = CW.WEBSITE_ID
		LEFT OUTER JOIN dbo.VENDOR V ON h.VN_CODE = V.VN_CODE
		LEFT OUTER JOIN dbo.VENDOR_DCM_MAPPING VDM ON h.VN_CODE = VDM.VN_CODE AND VDM.DC_PROFILE_ID = @DCProfileID
		LEFT OUTER JOIN dbo.INTERNET_TYPE IT ON d.INTERNET_TYPE = IT.OD_CODE AND IT.INACTIVE_FLAG = 0
		LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
		LEFT OUTER JOIN (
						SELECT CX.CL_CODE, CX.SOURCE_CL_CODE
						FROM dbo.CLIENT_XREF CX 
							INNER JOIN dbo.RECORD_SOURCE RS ON CX.RECORD_SOURCE_ID = RS.RECORD_SOURCE_ID
						WHERE RS.[NAME] = 'DoubleClick' 
						AND RS.SYSTEM_SOURCE = 1
						) RSX ON h.CL_CODE = RSX.CL_CODE
	WHERE
		COALESCE(h.[STATUS], 0) = 0
	AND	h.LOCKED_BY = @UserCode
	AND @OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
												AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
												AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ',')))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
											))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	AND
		(
			CMP.CMP_IDENTIFIER IS NULL 
		OR
			(CMP.CMP_IDENTIFIER IS NOT NULL AND (CMP.AD_SERVER_ID IS NULL OR CMP.AD_SERVER_ID = @AdServerID))
		)
		
	INSERT INTO @GROUP (OrderNumber, InternetCostType, InternetType, PlacementName, MediaPlanDetailPackagePlacementNameID, AdSizeCode, AdServerPlacementID, IsCancelled, PlacementManual, PackageName, AdServerPlacementGroupID, PackageParent)
	SELECT DISTINCT
		OrderNumber,
		InternetCostType,
		InternetType,
		PlacementName,
		MediaPlanDetailPackagePlacementNameID,
		AdSizeCode,
		AdServerPlacementID,
		IsCancelled,
		PlacementManual,
		PackageName,
		AdServerPlacementGroupID,
		PackageParent
	FROM @ORDERLINES 
	WHERE AdServerPlacementID IS NOT NULL
	GROUP BY
		OrderNumber,
		InternetCostType,
		InternetType,
		PlacementName,
		MediaPlanDetailPackagePlacementNameID,
		AdSizeCode,
		AdServerPlacementID,
		IsCancelled,
		PlacementManual,
		PackageName,
		AdServerPlacementGroupID,
		PackageParent
		
	INSERT INTO @GROUP (OrderNumber, InternetCostType, InternetType, PlacementName, MediaPlanDetailPackagePlacementNameID, AdSizeCode, IsCancelled, PlacementManual, PackageName, AdServerPlacementGroupID, PackageParent)
	SELECT DISTINCT
		ol.OrderNumber,
		ol.InternetCostType,
		ol.InternetType,
		ol.PlacementName,
		ol.MediaPlanDetailPackagePlacementNameID,
		ol.AdSizeCode,
		ol.IsCancelled,
		ol.PlacementManual,
		ol.PackageName,
		ol.AdServerPlacementGroupID,
		ol.PackageParent
	FROM @ORDERLINES ol
		LEFT OUTER JOIN @GROUP g ON g.OrderNumber = ol.OrderNumber
							   AND COALESCE(g.InternetCostType,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.InternetCostType,'') COLLATE DATABASE_DEFAULT
							   AND COALESCE(g.InternetType,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.InternetType,'') COLLATE DATABASE_DEFAULT
							   AND COALESCE(g.PlacementName,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.PlacementName,'') COLLATE DATABASE_DEFAULT
							   AND COALESCE(g.MediaPlanDetailPackagePlacementNameID,0) = COALESCE(ol.MediaPlanDetailPackagePlacementNameID,0)
							   AND COALESCE(g.AdSizeCode,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.AdSizeCode,'') COLLATE DATABASE_DEFAULT
							   AND g.IsCancelled = ol.IsCancelled
							   AND g.PlacementManual = ol.PlacementManual
							   AND COALESCE(g.PackageName,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.PackageName,'') COLLATE DATABASE_DEFAULT
							   AND COALESCE(g.AdServerPlacementGroupID,0) = COALESCE(ol.AdServerPlacementGroupID,0)
							   AND g.PackageParent = ol.PackageParent
	WHERE ol.AdServerPlacementID IS NULL
	AND g.OrderNumber IS NULL
	GROUP BY
		ol.OrderNumber,
		ol.InternetCostType,
		ol.InternetType,
		ol.PlacementName,
		ol.MediaPlanDetailPackagePlacementNameID,
		ol.AdSizeCode,
		ol.IsCancelled,
		ol.PlacementManual,
		ol.PackageName,
		ol.AdServerPlacementGroupID,
		ol.PackageParent

	UPDATE @ORDERLINES SET GroupID = g.GroupID
	FROM @ORDERLINES ol
		INNER JOIN @GROUP g ON g.OrderNumber = ol.OrderNumber
							   AND COALESCE(g.InternetCostType,'') COLLATE SQL_Latin1_General_CP1_CS_AS = COALESCE(ol.InternetCostType,'') COLLATE SQL_Latin1_General_CP1_CS_AS
							   AND COALESCE(g.InternetType,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.InternetType,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.PlacementName,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.PlacementName,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.MediaPlanDetailPackagePlacementNameID,0) = COALESCE(ol.MediaPlanDetailPackagePlacementNameID,0)
							   AND COALESCE(g.AdSizeCode,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.AdSizeCode,'') COLLATE DATABASE_DEFAULT 
							   AND (g.AdServerPlacementID = ol.AdServerPlacementID)
							   AND g.IsCancelled = ol.IsCancelled
							   AND g.PlacementManual = ol.PlacementManual
							   AND COALESCE(g.PackageName,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.PackageName,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.AdServerPlacementGroupID,0) = COALESCE(ol.AdServerPlacementGroupID,0)
							   AND g.PackageParent = ol.PackageParent

	UPDATE @ORDERLINES SET GroupID = g.GroupID
	FROM @ORDERLINES ol
		INNER JOIN @GROUP g ON g.OrderNumber = ol.OrderNumber
							   AND COALESCE(g.InternetCostType,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.InternetCostType,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.InternetType,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.InternetType,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.PlacementName,'') COLLATE DATABASE_DEFAULT = COALESCE(ol.PlacementName,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.MediaPlanDetailPackagePlacementNameID,0) = COALESCE(ol.MediaPlanDetailPackagePlacementNameID,0)
							   AND COALESCE(g.AdSizeCode,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.AdSizeCode,'') COLLATE DATABASE_DEFAULT 
							   AND g.IsCancelled = ol.IsCancelled
							   AND g.PlacementManual = ol.PlacementManual
							   AND COALESCE(g.PackageName,'') COLLATE DATABASE_DEFAULT  = COALESCE(ol.PackageName,'') COLLATE DATABASE_DEFAULT 
							   AND COALESCE(g.AdServerPlacementGroupID,0) = COALESCE(ol.AdServerPlacementGroupID,0)
							   AND g.PackageParent = ol.PackageParent
	WHERE ol.AdServerPlacementID IS NULL

	UPDATE g SET [LineNumbers] = STUFF((SELECT DISTINCT ', ' + CAST(ol.LineNumber as varchar(5))
							   FROM @ORDERLINES ol
							   WHERE g.GroupID = ol.GroupID
							   FOR XML PATH('')),1 ,2 ,'')
	FROM @GROUP g

	UPDATE @GROUP SET GroupRequiresUpdate = CASE WHEN gg.Number > 1 THEN 1 ELSE 0 END
	FROM @GROUP g
		INNER JOIN (
					SELECT COUNT(DISTINCT g.AdServerPlacementID) as Number, g.GroupID
					FROM @ORDERLINES ol
						INNER JOIN @GROUP g ON ol.GroupID = g.GroupID
					WHERE ol.PlacementManual = 0
					GROUP BY g.GroupID
					) gg ON g.GroupID = gg.GroupID

	if @Debug = 1 BEGIN
		SELECT * FROM @ORDERLINES
		SELECT * FROM @GROUP

		SELECT COUNT(DISTINCT g.AdServerPlacementID), g.GroupID
		FROM @ORDERLINES ol
			INNER JOIN @GROUP g ON ol.GroupID = g.GroupID
		GROUP BY g.GroupID
	END

	SELECT
		[RequiresUpdate] = CAST(CASE WHEN GroupRequiresUpdate = 1 THEN 1 
									WHEN AdServerPlacementManual = 0 AND (
										(
										ModifiedDate > PlacementCreatedDate) AND PlacementCreatedDate IS NOT NULL 
										AND PlacementRevisionDate IS NULL
										) OR 
										ModifiedDate > PlacementRevisionDate AND PlacementRevisionDate IS NOT NULL THEN 1
									ELSE 0 END as bit),
		*
	FROM (
		SELECT
			--[RequiresUpdate] = CAST(CASE WHEN g.RequiresUpdate = 1 THEN 1 
			--							 WHEN g.PlacementManual = 0 AND (
			--								  (
			--									MAX(ol.ModifiedDate) > MAX(ol.PlacementCreatedDate) AND MAX(ol.PlacementCreatedDate) IS NOT NULL 
			--									AND MAX(ol.PlacementRevisionDate) IS NULL
			--								  ) OR 
			--									MAX(ol.ModifiedDate) > MAX(ol.PlacementRevisionDate) AND MAX(ol.PlacementRevisionDate) IS NOT NULL) THEN 1
			--							 ELSE 0 END as bit),
			g.GroupRequiresUpdate,
			g.GroupID,
			g.OrderNumber,
			g.InternetCostType,
			g.InternetType,
			g.PlacementName,
			g.MediaPlanDetailPackagePlacementNameID,
			g.AdSizeCode,
			g.LineNumbers,
			g.IsCancelled,
			AdServerPlacementID = (SELECT MAX(AdServerPlacementID) FROM @ORDERLINES WHERE OrderNumber = g.OrderNumber AND LineNumber IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ','))),
			AdServerID = MAX(ol.AdServerID),
			ClientCode = MAX(ol.ClientCode),
			ClientName = MAX(ol.ClientName),
			DivisionCode = MAX(ol.DivisionCode),
			DivisionName = MAX(ol.DivisionName),
			ProductCode = MAX(ol.ProductCode),
			ProductDescription = MAX(ol.ProductDescription),
			OrderDescription = MAX(ol.OrderDescription),
			AdServerAdvertiserID = MAX(ol.AdServerAdvertiserID),
			AdServerCampaignID = MAX(ol.AdServerCampaignID),
			CampaignID = MAX(ol.CampaignID),
			CampaignCode = MAX(ol.CampaignCode),
			CampaignName = MAX(ol.CampaignName),
			CampaignStartDate = MAX(ol.CampaignStartDate),
			CampaignEndDate = MAX(ol.CampaignEndDate),
			LandingPageName = MAX(ol.LandingPageName),
			LandingPageURL = MAX(ol.LandingPageURL),
			VendorName = MAX(ol.VendorName),
			AdServerSiteID = MAX(ol.AdServerSiteID),
			InternetTypeDescription = MAX(ol.InternetTypeDescription),
			PricingType = MAX(ol.PricingType),
			StartDate = (SELECT MIN(StartDate) FROM @ORDERLINES WHERE OrderNumber = g.OrderNumber AND LineNumber IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ','))),
			EndDate = (SELECT MAX(EndDate) FROM @ORDERLINES WHERE OrderNumber = g.OrderNumber AND LineNumber IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ','))),
			AdSizeDescription = MAX(ol.AdSizeDescription),
			AdServerSizeID = MAX(ol.AdServerSizeID),
			PlacementCreatedBy = CASE WHEN MAX(ol.PlacementCreatedBy) IS NOT NULL THEN MAX(ol.PlacementCreatedBy)
									ELSE (SELECT TOP 1 AD_SERVER_CREATED_BY FROM dbo.INTERNET_PACKAGE_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) ORDER BY AD_SERVER_CREATED_DATETIME)
									END,
			PlacementCreatedDate = CASE WHEN MAX(ol.PlacementCreatedDate) IS NOT NULL THEN MAX(ol.PlacementCreatedDate)
									ELSE (SELECT MAX(AD_SERVER_CREATED_DATETIME) FROM dbo.INTERNET_PACKAGE_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')))
									END,
			PlacementRevisionBy = CASE WHEN MAX(ol.PlacementRevisionBy) IS NOT NULL THEN MAX(ol.PlacementRevisionBy)
									ELSE (SELECT TOP 1 AD_SERVER_LAST_MODIFIED_BY FROM dbo.INTERNET_PACKAGE_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) ORDER BY AD_SERVER_LAST_MODIFIED_BY DESC)
									END,
			PlacementRevisionDate = CASE WHEN MAX(ol.PlacementRevisionDate) IS NOT NULL THEN MAX(ol.PlacementRevisionDate)
									ELSE (SELECT MAX(AD_SERVER_LAST_MODIFIED_DATETIME) FROM dbo.INTERNET_PACKAGE_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')))
									END,
			ol.HasAdServerAdvertiserID,
			ol.HasAdServerCampaignID,
			ol.HasCampaignID,
			ol.HasAdServerSiteID,
			VendorCode = MAX(ol.VendorCode),
			ModifiedDate = MAX(ol.ModifiedDate),
			AdServerPlacementManual = g.PlacementManual,
			g.PackageName,
			g.AdServerPlacementGroupID,
			g.PackageParent,
			ol.IsNewPackage,
			Quantity = CAST((SELECT SUM(COALESCE(GUARANTEED_IMPRESS,0)) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) AND ACTIVE_REV = 1) as bigint),
			Rate = CASE
					WHEN (SELECT SUM(COALESCE(GUARANTEED_IMPRESS,0)) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) AND ACTIVE_REV = 1) = 0 THEN 0
					ELSE (SELECT SUM(COALESCE(NET_RATE,0)) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) AND ACTIVE_REV = 1) /
						 (SELECT SUM(COALESCE(GUARANTEED_IMPRESS,0)) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) AND ACTIVE_REV = 1)
					END,
			Cost = (SELECT SUM(COALESCE(EXT_NET_AMT,0)) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = g.OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(g.LineNumbers, ',')) AND ACTIVE_REV = 1)
		FROM @GROUP g
			INNER JOIN (
						SELECT *
						FROM @ORDERLINES
						) ol ON ol.GroupID = g.GroupID
		GROUP BY
			g.GroupID,
			g.OrderNumber,
			g.InternetCostType,
			g.InternetType,
			g.PlacementName,
			g.MediaPlanDetailPackagePlacementNameID,
			g.AdSizeCode,
			g.LineNumbers,
			g.IsCancelled,
			g.GroupRequiresUpdate,
			g.PlacementManual,
			g.PackageName,
			g.AdServerPlacementGroupID,
			g.PackageParent,
			ol.HasAdServerAdvertiserID,
			ol.HasAdServerCampaignID,
			ol.HasCampaignID,
			ol.HasAdServerSiteID,
			ol.IsNewPackage) details
	OPTION (RECOMPILE)
END