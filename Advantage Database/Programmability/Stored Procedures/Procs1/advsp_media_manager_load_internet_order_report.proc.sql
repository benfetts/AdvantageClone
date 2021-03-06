CREATE PROCEDURE [dbo].[advsp_media_manager_load_internet_order_report]
	@UserCode AS varchar(100),
	@OrderNumber AS integer,
	@LineNumbers AS varchar(MAX)
AS

DECLARE @LocationHeader varchar(max),
		@LocationFooter varchar(max)

SELECT
		@LocationHeader = 
				CASE WHEN PRT_NAME = 1 AND NAME IS NOT NULL THEN COALESCE(NAME,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR1 = 1 AND ADDRESS1 IS NOT NULL THEN COALESCE(ADDRESS1,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR2 = 1 AND ADDRESS2 IS NOT NULL THEN COALESCE(ADDRESS2,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_CITY = 1 AND CITY IS NOT NULL THEN COALESCE(CITY,'') + ', ' ELSE '' END +
				CASE WHEN PRT_STATE = 1 AND [STATE] IS NOT NULL THEN COALESCE([STATE],'') + ' ' ELSE '' END +
				CASE WHEN PRT_ZIP = 1 AND ZIP IS NOT NULL THEN COALESCE(ZIP,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_PHONE = 1 AND PHONE IS NOT NULL THEN COALESCE(PHONE,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_FAX = 1 AND FAX IS NOT NULL THEN COALESCE(FAX,'') + ' Fax ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_EMAIL = 1 AND EMAIL IS NOT NULL THEN COALESCE(EMAIL,'') + ' ' + CHAR(149) + ' ' ELSE '' END,
		@LocationFooter = 
				CASE WHEN PRT_NAME_FTR = 1 AND NAME IS NOT NULL THEN COALESCE(NAME,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR1_FTR = 1 AND ADDRESS1 IS NOT NULL THEN COALESCE(ADDRESS1,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_ADDR2_FTR = 1 AND ADDRESS2 IS NOT NULL THEN COALESCE(ADDRESS2,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_CITY_FTR = 1 AND CITY IS NOT NULL THEN COALESCE(CITY,'') + ', ' ELSE '' END +
				CASE WHEN PRT_STATE_FTR = 1 AND [STATE] IS NOT NULL THEN COALESCE([STATE],'') + ' ' ELSE '' END +
				CASE WHEN PRT_ZIP_FTR = 1 AND ZIP IS NOT NULL THEN COALESCE(ZIP,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_PHONE_FTR = 1 AND PHONE IS NOT NULL THEN COALESCE(PHONE,'') + ' ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_FAX_FTR = 1 AND FAX IS NOT NULL THEN COALESCE(FAX,'') + ' Fax ' + CHAR(149) + ' ' ELSE '' END +
				CASE WHEN PRT_EMAIL_FTR = 1 AND EMAIL IS NOT NULL THEN COALESCE(EMAIL,'') + ' ' + CHAR(149) + ' ' ELSE '' END
FROM dbo.LOCATIONS l
	INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.LOCATION_ID = l.ID AND UPPER(mpd.[USER_ID]) = UPPER(@UserCode) AND mpd.MEDIA_TYPE = 'I' 

SELECT
	[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 THEN @LocationHeader ELSE NULL END,
	[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 THEN @LocationFooter ELSE NULL END,
	[PageHeaderLogoPath] = l.LOGO_PATH,
	[OrderLabel] =  CASE
						WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
						WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'INTERNET QUOTE REQUEST'
						WHEN mpd.TITLE_OPTION = 'O' AND h.REVISED_FLAG = 1 THEN 'INTERNET ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
						WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																FROM dbo.INTERNET_DETAIL 
																WHERE ORDER_NBR = @OrderNumber 
																AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																AND ACTIVE_REV = 1
																AND REV_NBR > 0) THEN 'INTERNET ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
						WHEN mpd.TITLE_OPTION = 'O' THEN 'INTERNET ORDER'
						WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
						WHEN mpd.TITLE_OPTION <> 'O' AND h.REVISED_FLAG = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
						WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																	FROM dbo.INTERNET_DETAIL 
																	WHERE ORDER_NBR = @OrderNumber 
																	AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																	AND ACTIVE_REV = 1
																	AND REV_NBR > 0) THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
						WHEN mpd.TITLE_OPTION <> 'O' THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER'
						END,
	[PrintDate] = CASE mpd.DATE_OVERRIDE + 1
					WHEN 1 THEN getdate() 
					WHEN 2 THEN h.ORDER_DATE
					WHEN 3 THEN h.MODIFIED_DATE END,
	[VendorCode] = h.VN_CODE,
	[VendorName] = v.VN_NAME,
	[ClientName] = CASE WHEN mpd.PRINT_CLIENT_NAME = 1 THEN c.CL_NAME ELSE NULL END,
	[DivisionName] = CASE WHEN (mpd.PRINT_DIVISION_NAME = 1 AND c.CL_NAME <> div.DIV_NAME) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND mpd.PRINT_DIVISION_NAME = 1) THEN div.DIV_NAME ELSE NULL END,
	[ProductionDescription] = CASE WHEN (mpd.PRINT_PRODUCT_DESCRIPTION = 1 AND div.DIV_NAME <> p.PRD_DESCRIPTION) OR (COALESCE(mpd.PRINT_CLIENT_NAME, 0) = 0 AND COALESCE(mpd.PRINT_DIVISION_NAME, 0) = 0 AND mpd.PRINT_PRODUCT_DESCRIPTION = 1) THEN p.PRD_DESCRIPTION ELSE NULL END,
	[CampaignName] = CASE WHEN mpd.CAMPAIGN_FLAG = 1 THEN cmp.CMP_NAME ELSE NULL END,
	[MarketName] = CASE WHEN mpd.MARKET_FLAG = 1 THEN m.MARKET_DESC ELSE NULL END,
	[OrderNumber] = h.ORDER_NBR,
	[Buyer] = h.BUYER,
	[OrderDescription] = h.ORDER_DESC,
	[OrderDate] = h.ORDER_DATE,
	--[Instructions] = CASE WHEN mpd.INSTRUCTIONS_FLAG = 1 THEN ic.INSTRUCTIONS ELSE NULL END,
    --[OrderCopy] = CASE WHEN mpd.ORDER_COPY_FLAG = 1 THEN ic.ORDER_COPY ELSE NULL END,
    --[MaterialNotes] = CASE WHEN mpd.MATL_NOTES_FLAG = 1 THEN ic.MATL_NOTES ELSE NULL END,
    --[MiscInfo] = CASE WHEN mpd.MISC_INFO_FLAG = 1 THEN ic.MISC_INFO ELSE NULL END,
	--[AdNumber] = CASE WHEN mpd.AD_NUMBER_FLAG = 1 THEN d.AD_NUMBER + 
				--	CASE WHEN an.AD_NBR_DESC IS NOT NULL THEN ' - ' + an.AD_NBR_DESC + 
				--		CASE WHEN bv1.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Front: ' + bv1.BLACKPLT_VER_DESC ELSE '' END +
				--		CASE WHEN bv2.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Back: ' + bv2.BLACKPLT_VER_DESC ELSE '' END
				--	ELSE NULL END 
				--ELSE NULL END,

	---- old detail start
	
	--[LineNumber] = RIGHT('000' + CONVERT(NVARCHAR, d.LINE_NBR), 3),
	--[RevisionNumber] = d.REV_NBR,
	--[Projected] = CASE WHEN d.PROJ_IMPRESSIONS IS NOT NULL AND mpd.PROJECTED_FLAG = 1 THEN REPLACE(CONVERT(VARCHAR(50), (CAST(d.PROJ_IMPRESSIONS AS money)), 1), '.00', '') + ' Impressions' ELSE NULL END,
	--[Actual]= CASE WHEN d.ACT_IMPRESSIONS IS NOT NULL AND mpd.ACTUAL_FLAG = 1 THEN REPLACE(CONVERT(VARCHAR(50), (CAST(d.ACT_IMPRESSIONS AS money)), 1), '.00', '') + ' Impressions' ELSE NULL END,
	--[Headline1] = CASE WHEN NULLIF(d.HEADLINE,'') IS NOT NULL AND mpd.HEADLINE_FLAG = 1 THEN d.HEADLINE ELSE NULL END,
 --   [URL] = CASE WHEN NULLIF(d.[URL],'') IS NOT NULL AND mpd.URL_FLAG = 1 THEN d.[URL] ELSE NULL END,
 --   [CopyArea] = CASE WHEN NULLIF(d.COPY_AREA,'') IS NOT NULL AND mpd.COPY_AREA_FLAG = 1 THEN d.COPY_AREA ELSE NULL END,
 --   [Placement] = CASE WHEN mpd.PLACE1_FLAG = 1 THEN d.PLACEMENT_1 ELSE NULL END,
	--[PackageName] = CASE WHEN mpd.PLACE2_FLAG = 1 THEN d.PLACEMENT_2 ELSE NULL END,
 --   [Target] = CASE WHEN NULLIF(d.TARGET_AUDIENCE,'') IS NOT NULL AND mpd.TARGET_FLAG = 1 THEN d.TARGET_AUDIENCE ELSE NULL END,
 --   [AgencyJob] = CASE WHEN mpd.JOB_NUMBER_FLAG = 1 AND d.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(NVARCHAR, d.JOB_NUMBER), 6) + '-' + RIGHT('00' + CONVERT(NVARCHAR, d.JOB_COMPONENT_NBR), 2) ELSE NULL END,
 --   [MaterialDue] = CASE WHEN mpd.MATL_DUE_FLAG = 1 THEN d.MATL_CLOSE_DATE ELSE NULL END,
 --   [SpaceClose] = CASE WHEN mpd.SPACE_CLOSE_FLAG = 1 THEN d.CLOSE_DATE ELSE NULL END,
	--[RevisedCancelled] = CASE
	--						WHEN d.LINE_CANCELLED <> 0 THEN '**CANCELLED**'
	--						WHEN d.REV_NBR <> 0 AND mpd.PRINT_REVISION = 1 THEN '**REVISED**'
	--						ELSE NULL
	--						END,
	--[InsertDate] = d.[START_DATE],
	--[EndDate] = d.END_DATE,
	--[Size] = d.CREATIVE_SIZE,
	--[Amount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN CASE WHEN h.NET_GROSS = 0 THEN d.EXT_NET_AMT ELSE d.EXT_GROSS_AMT END ELSE 0 END,
	--[CostType] = d.COST_TYPE,
	--[RateType] = d.RATE_TYPE,
	[VendorTax] = (SELECT SUM(NON_RESALE_AMT) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 AND COALESCE(LINE_CANCELLED, 0) = 0),
			--CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NON_RESALE_AMT ELSE 0 END,
	--[LineTotalActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN 
	--						CASE WHEN h.NET_GROSS = 0 THEN d.LINE_TOTAL ELSE COALESCE(d.LINE_TOTAL,0) - COALESCE(d.COMM_AMT,0) END
	--					ELSE 0
	--					END,
	[DiscountAmount] = (SELECT SUM(DISCOUNT_AMT) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 AND COALESCE(LINE_CANCELLED, 0) = 0),
			--CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.DISCOUNT_AMT ELSE 0 END,
	[DiscountDescription] = (SELECT TOP 1 COALESCE(NULLIF(DISCOUNT_DESC,''),'Discount') FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 ORDER BY DISCOUNT_DESC DESC),
			--COALESCE(NULLIF(d.DISCOUNT_DESC,''),'Discount'),
	[CommissionActual] = (SELECT SUM(COMM_AMT * -1) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 AND COALESCE(LINE_CANCELLED, 0) = 0 AND h.NET_GROSS <> 0),
					--CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN
					--		CASE WHEN h.NET_GROSS = 0 THEN 0 ELSE d.COMM_AMT * -1 END
					--ELSE 0 
					--END,
	--[BillTypeFlag] = d.BILL_TYPE_FLAG,
	[NetCharge] = (SELECT SUM(NETCHARGE) FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 AND COALESCE(LINE_CANCELLED, 0) = 0),
			--CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NETCHARGE ELSE 0 END,
	[NetChargeDescription] = (SELECT TOP 1 COALESCE(NULLIF(NCDESC,''),'Net Charge') FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @OrderNumber AND ACTIVE_REV = 1 ORDER BY NCDESC DESC),
			--COALESCE(NULLIF(d.NCDESC,''),'Net Charge'),

	---- old detail end
	[OrderComment] = h.ORDER_COMMENT,
	[NetGross] = h.NET_GROSS,
	[MaterialDueFlag] = mpd.MATL_DUE_FLAG,
	[HeadlineFlag] = mpd.HEADLINE_FLAG,
	[AgencyComment] = CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I')
							WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
							ELSE (SELECT INET_COMMENT FROM dbo.AGENCY) END,
	[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') ELSE NULL END,
	
	--[SubTypeDescription] = CASE WHEN mpd.TYPE_FLAG = 1 THEN t.OD_DESC ELSE NULL END,
	
	[ShippingAddressFlag] = mpd.SHIP_ADDR_FLAG,
	[IncludeRep1] = mpd.INCLUDE_REP1,
	[RepLabel1] = mpd.REP_LABEL1,
	[IncludeRep2] = mpd.INCLUDE_REP2,
	[RepLabel2] = mpd.REP_LABEL2,
	[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
	[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
	[LocationID] = mpd.LOCATION_ID,
	--[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
	--				CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
	--				ELSE NULL
	--				END,
	[VendorRepCode1] = h.VR_CODE,
	[VendorRepCode2] = h.VR_CODE2,
	[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
	[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
	[BuyerEmployeeCode] = h.BUYER_EMP_CODE,

	--new detail
	detail.[TargetGroup],
	detail.[Target],
	detail.[LineMarketCode],
	detail.[Dimensions],
	detail.[CostStructure],
	detail.[Package],
	detail.[URL],
	detail.[Units],
	detail.[StartDate],
	detail.[EndDate],
	detail.[Cost],
	detail.[LineMarketDescription],
	detail.[Placement],
	[Instructions] = ic.INSTRUCTIONS,
	--[Instructions] = (select STUFF
	--			(
	--				(
	--					SELECT ',' + INSTRUCTIONS
	--					FROM (SELECT DISTINCT CAST(INSTRUCTIONS as varchar(max)) as INSTRUCTIONS FROM INTERNET_COMMENTS 
	--					WHERE ORDER_NBR = @OrderNumber AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))) t
	--					FOR XML PATH('')
	--				), 1, 1, ''
	--			)),
	LineCancelled = CAST(detail.LineCancelled as bit),
	ClientAddress1 = c.CL_ADDRESS1,
	ClientAddress2 = c.CL_ADDRESS2,
	ClientCity = c.CL_CITY,
	ClientState = c.CL_STATE,        
	ClientZip = c.CL_ZIP
FROM dbo.INTERNET_HEADER h
	INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
	INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
	INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
	INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
	INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = 'I' 
	LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
	LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
	LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
	LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
	LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
	--LEFT JOIN dbo.INTERNET_TYPE AS t ON d.INTERNET_TYPE = t.OD_CODE 
	--LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR AND an.ACTIVE = 1
	--LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv1 ON an.DEF_BLKPLT_VER_CODE = bv1.BLACKPLT_VER_CODE AND (bv1.INACTIVE_FLAG IS NULL OR bv1.INACTIVE_FLAG = 0)
	--LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv2 ON an.DEF_BLKPLT_VER2_CODE = bv2.BLACKPLT_VER_CODE AND (bv2.INACTIVE_FLAG IS NULL OR bv2.INACTIVE_FLAG = 0)
	--LEFT OUTER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
	INNER JOIN (
				SELECT
					[TargetGroup] = NEWID(),
					[Target] = COALESCE(TARGET_AUDIENCE,''),
					[LineMarketDescription] = m.MARKET_DESC,
					[Dimensions] = COALESCE(CREATIVE_SIZE,''),
					[CostStructure] = COALESCE(COST_TYPE,''),
					[Package] = COALESCE(PLACEMENT_2,''),
					[URL] = COALESCE([URL],''),
					[Units] = SUM(GUARANTEED_IMPRESS),
					[StartDate] = MIN(id.[START_DATE]),
					[EndDate] = MAX(id.END_DATE),
					[Cost] = SUM(CASE WHEN h.NET_GROSS = 0 THEN id.EXT_NET_AMT ELSE id.EXT_GROSS_AMT END),
					[LineMarketCode] = id.MARKET_CODE,
					[Placement] = COALESCE(PLACEMENT_1,''),
					id.ORDER_NBR,
					LineCancelled = COALESCE(id.LINE_CANCELLED, 0)
				FROM dbo.INTERNET_DETAIL id
						INNER JOIN dbo.INTERNET_HEADER h ON h.ORDER_NBR = id.ORDER_NBR
					LEFT OUTER JOIN dbo.MARKET m ON id.MARKET_CODE = m.MARKET_CODE
				WHERE id.ORDER_NBR = @OrderNumber
				AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
				AND ACTIVE_REV = 1
				--AND COALESCE(id.LINE_CANCELLED, 0) = 0
				GROUP BY 
					COALESCE(TARGET_AUDIENCE,''),
					m.MARKET_DESC,
					COALESCE(CREATIVE_SIZE,''),
					COALESCE(COST_TYPE,''),
					COALESCE(PLACEMENT_2,''),
					COALESCE([URL],''),
					id.MARKET_CODE,
					COALESCE(PLACEMENT_1,''),
					id.ORDER_NBR,
					COALESCE(id.LINE_CANCELLED, 0)
				) detail ON h.ORDER_NBR = detail.ORDER_NBR
	LEFT OUTER JOIN (
				SELECT
					MIN(LINE_NBR) as LINE_NBR,
					COALESCE(TARGET_AUDIENCE,'') as TARGET_AUDIENCE,
					MARKET_CODE,
					COALESCE(CREATIVE_SIZE,'') as CREATIVE_SIZE,
					COALESCE(COST_TYPE,'') as COST_TYPE,
					COALESCE(PLACEMENT_2,'') as PLACEMENT_2,
					COALESCE([URL],'') as [URL],
					COALESCE(PLACEMENT_1,'') as PLACEMENT_1,
					LINE_CANCELLED
				FROM dbo.INTERNET_DETAIL
				WHERE ORDER_NBR = @OrderNumber
				AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
				AND ACTIVE_REV = 1
				--AND COALESCE(LINE_CANCELLED, 0) = 0
				GROUP BY 
					COALESCE(TARGET_AUDIENCE,''),
					MARKET_CODE,
					COALESCE(CREATIVE_SIZE,''),
					COALESCE(COST_TYPE,''),
					COALESCE(PLACEMENT_2,''),
					COALESCE([URL],''),
					COALESCE(PLACEMENT_1,''),
					LINE_CANCELLED
				) lines ON COALESCE(lines.TARGET_AUDIENCE,'') = COALESCE(detail.[Target],'')
						AND COALESCE(lines.MARKET_CODE,'') = COALESCE(detail.[LineMarketCode],'')
						AND COALESCE(lines.CREATIVE_SIZE,'') = COALESCE(detail.[Dimensions],'')
						AND COALESCE(lines.COST_TYPE,'') = COALESCE(detail.[CostStructure],'')
						AND COALESCE(lines.PLACEMENT_2,'') = COALESCE(detail.[Package],'')
						AND COALESCE(lines.[URL],'') = COALESCE(detail.[URL],'')
						AND COALESCE(lines.PLACEMENT_1,'') = COALESCE(detail.[Placement],'')
						AND COALESCE(lines.LINE_CANCELLED,0) = COALESCE(detail.[LineCancelled],0)
	LEFT OUTER JOIN dbo.INTERNET_COMMENTS ic ON ic.ORDER_NBR = @OrderNumber AND ic.LINE_NBR = lines.LINE_NBR
WHERE
		h.ORDER_NBR = @OrderNumber 
GO