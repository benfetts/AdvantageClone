CREATE VIEW [dbo].[V_DIGITAL_RESULTS]
WITH SCHEMABINDING
AS

	SELECT
		[ID] = DR.DIGITAL_RESULT_ID,
		[MediaPlanID] = DR.MEDIA_PLAN_ID,
		[MediaPlanDescription] = MP.[DESCRIPTION],
		[ClientCode] = DR.CL_CODE,
		[ClientName] = CASE WHEN DR.CL_CODE IS NOT NULL THEN CL.CL_NAME ELSE DR.CL_NAME END,
		[DivisionCode] = DR.DIV_CODE,
		[DivisionName] = DIV.DIV_NAME,
		[ProductCode] = DR.PRD_CODE,
		[ProductName] = PRD.PRD_DESCRIPTION,
		[JobNumber] = DR.JOB_NUMBER,
		[JobDescription] = CASE WHEN DR.JOB_NUMBER IS NOT NULL THEN JOB.JOB_DESC ELSE DR.JOB_DESC END,
		[JobComponentNumber] = DR.JOB_COMPONENT_NBR,
		[JobComponentDescription] =  CASE WHEN DR.JOB_COMPONENT_NBR IS NOT NULL THEN JC.JOB_COMP_DESC ELSE DR.JOB_COMP_DESC END,
		[EstimateID] = DR.MEDIA_PLAN_DTL_ID,
		[EstimateDescription] = MPD.NAME,
		[MediaPlanDetailLevelLineID] = DR.MEDIA_PLAN_DTL_LEVEL_LINE_ID,
		[MediaType] = DR.MEDIA_TYPE,
		[SalesClassCode] = DR.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[CampaignID] = DR.CMP_IDENTIFIER,
		[CampaignCode] = CASE WHEN DR.CMP_IDENTIFIER IS NOT NULL THEN CMP.CMP_CODE ELSE DR.CMP_CODE END,
		[CampaignName] = CASE WHEN DR.CMP_IDENTIFIER IS NOT NULL THEN CMP.CMP_NAME ELSE DR.CMP_NAME END,
		[VendorCode] = DR.VN_CODE,
		[VendorName] = CASE WHEN DR.VN_CODE IS NOT NULL THEN VN.VN_NAME ELSE DR.VN_NAME END,
		[MarketCode] = DR.MARKET_CODE,
		[MarketDescription] = CASE WHEN DR.MARKET_CODE IS NOT NULL THEN MK.MARKET_DESC ELSE DR.MARKET_DESC END,
		[AdSizeCode] = DR.AD_SIZE_CODE,
		[AdSizeDescription] = CASE WHEN DR.AD_SIZE_CODE IS NOT NULL THEN ADSZ.SIZE_DESC ELSE DR.AD_SIZE_DESC END,
		[AdNumber] = DR.AD_NBR,
		[AdNumberDescription] = CASE WHEN DR.AD_NBR IS NOT NULL THEN AD.AD_NBR_DESC ELSE DR.AD_NBR_DESC END,
		[InternetTypeCode] = DR.INTERNET_TYPE_CODE,
		[InternetTypeDescription] = CASE WHEN DR.INTERNET_TYPE_CODE IS NOT NULL THEN IT.OD_DESC ELSE DR.OD_DESC END,
		[Placement] = DR.PLACEMENT,
		[PlacementPixelSize] = DR.PLACEMENT_PX_SIZE,
		[PlacementURL] = DR.PLACEMENT_URL,
		[Creative] = DR.CREATIVE,
		[Tactic] = DR.TACTIC,
		[PagePositioning] = DR.PAGE_POSITIONING,
		[StartDate] = DR.RESULT_DATE,
		[EndDate] = DR.END_DATE,
		[NetGrossRate] = DR.NET_GROSS_RATE,
		[Units] = DR.UNITS,
		[Impressions] = DR.IMPRESSIONS,
		[ImpressionsViewable] = DR.IMPRESSIONS_VIEWABLE,
		[ImpressionsMeasurable] = DR.IMPRESSIONS_MEASUREABLE,
		[Clicks] = DR.CLICKS,
		[ClickRate] = DR.CLICK_RATE,
		[TotalConversions] = DR.TOTAL_CONVERSIONS,
		[TotalConversionsB] = DR.TOTAL_CONVERSIONS_B,
		[TotalConversionsC] = DR.TOTAL_CONVERSIONS_C,
		[Rate] = DR.RATE,
		[NetDollars] = DR.NET_DOLLARS,
		[GrossDollars] = DR.GROSS_DOLLARS,
		[TargetAudience] = DR.TARGET_AUDIENCE,
		[Leads1] = DR.LEADS1,
		[Leads2] = DR.LEADS2,
		[Calls] = DR.CALLS,
		[LikesOrganic] = DR.LIKES_ORGANIC,
		[LikesPaid] = DR.LIKES_PAID,
		[Visits] = DR.VISITS,
		[UniqueVisitors] = DR.UNIQUE_VISITORS,
		[ReachOrganic] = DR.REACH_ORGANIC,
		[ReachPaid] = DR.REACH_PAID,
		[PageViews] = DR.PAGE_VIEWS,
		[PageEngagement] = DR.PAGE_ENGAGEMENT,
		[Note] = DR.NOTE,
		[ClientSales] = DR.CLIENT_SALES,
		[PlacementID] = DR.PLACEMENT_ID,
		[AdServerSource] = DR.AD_SERVER_SOURCE,
		[DaypartCode] = DR.DAY_PART_CODE,
		[OfficeCode] = O.[OFFICE_CODE],
		[OfficeName]= O.[OFFICE_NAME]
	FROM
		dbo.DIGITAL_RESULTS DR LEFT OUTER JOIN
		dbo.MEDIA_PLAN MP ON DR.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID LEFT OUTER JOIN
		dbo.CLIENT CL ON DR.CL_CODE = CL.CL_CODE LEFT OUTER JOIN
		dbo.DIVISION DIV ON DR.CL_CODE = DIV.CL_CODE AND
							DR.DIV_CODE = DIV.DIV_CODE LEFT OUTER JOIN
		dbo.PRODUCT PRD ON DR.CL_CODE = PRD.CL_CODE AND
						   DR.DIV_CODE = PRD.DIV_CODE AND
						   DR.PRD_CODE = PRD.PRD_CODE LEFT OUTER JOIN
		dbo.JOB_LOG JOB ON DR.JOB_NUMBER = JOB.JOB_NUMBER LEFT OUTER JOIN
		dbo.JOB_COMPONENT JC ON DR.JOB_NUMBER = JC.JOB_NUMBER AND
								DR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
		dbo.MEDIA_PLAN_DTL MPD ON DR.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND
								  DR.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID LEFT OUTER JOIN 
		dbo.SALES_CLASS SC ON DR.SC_CODE = SC.SC_CODE LEFT OUTER JOIN 
		dbo.CAMPAIGN CMP ON DR.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER LEFT OUTER JOIN 
		dbo.VENDOR VN ON DR.VN_CODE = VN.VN_CODE LEFT OUTER JOIN 
		dbo.MARKET MK ON DR.MARKET_CODE = MK.MARKET_CODE LEFT OUTER JOIN 
		dbo.AD_SIZE ADSZ ON DR.AD_SIZE_CODE = ADSZ.SIZE_CODE AND
							DR.MEDIA_TYPE = ADSZ.MEDIA_TYPE LEFT OUTER JOIN
		dbo.AD_NUMBER AD ON DR.AD_NBR = AD.AD_NBR LEFT OUTER JOIN
		dbo.INTERNET_TYPE IT ON DR.INTERNET_TYPE_CODE = IT.OD_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] O ON O.[OFFICE_CODE] = JOB.[OFFICE_CODE]




GO


