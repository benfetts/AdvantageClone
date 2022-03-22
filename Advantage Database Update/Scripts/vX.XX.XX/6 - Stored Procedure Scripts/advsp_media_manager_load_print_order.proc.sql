CREATE PROCEDURE [dbo].[advsp_media_manager_load_print_order]
	@UserCode AS varchar(100),
	@OrderNumber AS integer,
	@LineNumbers AS varchar(MAX),
	@MediaType as char(1),
	@ExchangeRate decimal(12, 6) = 1
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
	INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.LOCATION_ID = l.ID AND mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = @MediaType 

IF @MediaType = 'N' BEGIN

	SELECT
		[MediaType] = @MediaType,
		[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 THEN @LocationHeader ELSE NULL END,
		[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 THEN @LocationFooter ELSE NULL END,
		[PageHeaderLogoPath] = l.LOGO_PATH,
		[OrderLabel] =  CASE
							WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
							WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'NEWSPAPER QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION = 'O' AND h.REVISED_FLAG = 1 THEN 'NEWSPAPER ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																	FROM dbo.NEWSPAPER_DETAIL 
																	WHERE ORDER_NBR = @OrderNumber 
																	AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																	AND ACTIVE_REV = 1
																	AND REV_NBR > 0) THEN 'NEWSPAPER ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' THEN 'NEWSPAPER ORDER'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.REVISED_FLAG = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																	 FROM dbo.NEWSPAPER_DETAIL 
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
		[LineNumber] = RIGHT('000' + CONVERT(NVARCHAR, d.LINE_NBR), 3),
		[RevisionNumber] = d.REV_NBR,
		[Buyer] = h.BUYER,
		[OrderDescription] = h.ORDER_DESC,
		[OrderDate] = h.ORDER_DATE,
		----
		[Projected] = NULL,
		[Actual]= NULL,
		[Headline1] = CASE WHEN d.COST_TYPE = 'CPM' AND NULLIF(d.HEADLINE,'') IS NOT NULL AND mpd.HEADLINE_FLAG = 1 THEN d.HEADLINE ELSE NULL END,
        [URL] = NULL,
        [Location] = NULL,
        [CopyArea] = NULL,
        [Placement] = NULL,
        [Target] = NULL,
        [EditionIssue] = CASE WHEN mpd.EDITION_FLAG = 1 THEN d.EDITION_ISSUE ELSE NULL END,
        [Section] = CASE WHEN mpd.SECTION_FLAG = 1 THEN d.SECTION ELSE NULL END,
        [Material] = CASE WHEN mpd.MATERIAL_FLAG = 1 THEN d.MATERIAL ELSE NULL END,
        [AdNumber] = CASE WHEN mpd.AD_NUMBER_FLAG = 1 THEN d.AD_NUMBER + 
								CASE WHEN an.AD_NBR_DESC IS NOT NULL THEN ' - ' + an.AD_NBR_DESC + 
									CASE WHEN bv1.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Front: ' + bv1.BLACKPLT_VER_DESC ELSE '' END +
									CASE WHEN bv2.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Back: ' + bv2.BLACKPLT_VER_DESC ELSE '' END
								ELSE NULL END 
						  ELSE NULL END,
        [AgencyJob] = CASE WHEN mpd.JOB_NUMBER_FLAG = 1 AND d.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(NVARCHAR, d.JOB_NUMBER), 6) + '-' + RIGHT('00' + CONVERT(NVARCHAR, d.JOB_COMPONENT_NBR), 2) ELSE NULL END,
        [MaterialDue] = CASE WHEN mpd.MATL_DUE_FLAG = 1 THEN d.MATL_CLOSE_DATE ELSE NULL END,
        [SpaceClose] = CASE WHEN mpd.SPACE_CLOSE_FLAG = 1 THEN d.CLOSE_DATE ELSE NULL END,
        [Instructions] = CASE WHEN mpd.INSTRUCTIONS_FLAG = 1 THEN nc.INSTRUCTIONS ELSE NULL END,
        [OrderCopy] = CASE WHEN mpd.ORDER_COPY_FLAG = 1 THEN nc.ORDER_COPY ELSE NULL END,
        [MaterialNotes] = CASE WHEN mpd.MATL_NOTES_FLAG = 1 THEN nc.MATL_NOTES ELSE NULL END,
        [PositionInfo] = CASE WHEN mpd.POSITION_FLAG = 1 THEN nc.POSITION_INFO ELSE NULL END,
        [CloseInfo] = CASE WHEN mpd.CLOSE_INFO_FLAG = 1 THEN nc.CLOSE_INFO ELSE NULL END,
        [RateInfo] = CASE WHEN mpd.RATE_INFO_FLAG = 1 THEN nc.RATE_INFO ELSE NULL END,
        [MiscInfo] = CASE WHEN mpd.MISC_INFO_FLAG = 1 THEN nc.MISC_INFO ELSE NULL END,
		----
		[OrderComment] = h.ORDER_COMMENT,
		[RevisedCancelled] = CASE
								WHEN d.LINE_CANCELLED <> 0 THEN '**CANCELLED**'
								WHEN d.REV_NBR <> 0 AND mpd.PRINT_REVISION = 1 THEN '**REVISED**'
								ELSE NULL
							 END,
		[InsertDate] = d.[START_DATE],
		[InsertDay] = CASE WHEN mpd.MEDIA_TYPE = 'N' THEN LEFT(DATENAME(WEEKDAY,d.[START_DATE]),3) END,
		[EndDate] = d.END_DATE,
		[Size] = CASE
					WHEN d.COST_TYPE = 'CPI' AND d.PRINT_LINES <> 0 THEN CAST(CAST(d.PRINT_COLUMNS as decimal(15,2)) as varchar(20)) + ' X ' + CAST(CAST(d.PRINT_INCHES as decimal(15,2)) as varchar(20)) + ' Col/Inch'
					WHEN d.COST_TYPE = 'CPI' AND d.PRINT_LINES = 0 THEN d.SIZE
					WHEN d.COST_TYPE = 'CPL' AND d.PRINT_LINES <> 0 THEN CAST(d.PRINT_LINES as varchar(20)) + ' Lines'
					WHEN d.COST_TYPE = 'CPL' AND d.PRINT_LINES = 0 THEN d.SIZE
					WHEN d.COST_TYPE = 'NA' THEN d.SIZE
					WHEN d.COST_TYPE = 'CPM' THEN CAST(CAST(d.PRINT_LINES as decimal(15,0)) as varchar(20))
				 END, --NSPR_SIZE
				--Switch([COST_TYPE]="CPI" And [PRINT_LINES]<>0,Format([PRINT_COLUMNS],"#.00") & " X " & Format([PRINT_INCHES],"#.00") & " Col/Inch",
				--[COST_TYPE]="CPI" And [PRINT_LINES]=0,[SIZE],
				--[COST_TYPE]="CPL" And [PRINT_LINES]<>0,[PRINT_LINES] & " Lines",
				--[COST_TYPE]="CPL" And [PRINT_LINES]=0,[SIZE],
				--[COST_TYPE]="NA",[SIZE],
				--[COST_TYPE]="CPM",Format([PRINT_LINES],"#,##0")) AS NSPR_SIZE,
		[ProductionSize] = CASE WHEN mpd.PROD_SPECS_FLAG = 1 THEN d.PRODUCTION_SIZE ELSE NULL END,
		[Headline] = CASE
						WHEN d.COST_TYPE = 'CPM' THEN
							CASE WHEN h.NET_GROSS = 1 THEN 'Gross' + CASE WHEN d.RATE_TYPE = 'CPM' THEN ' CPM' ELSE ' Rate ' END + '$' + CAST(CAST(d.GROSS_RATE AS DECIMAL(16,2)) AS varchar(max))
							ELSE 'Net' + CASE WHEN d.RATE_TYPE = 'CPM' THEN ' CPM' ELSE ' Rate ' END + '$' + CAST(CAST(d.NET_RATE AS DECIMAL(16,2)) AS varchar(max)) END
						WHEN mpd.HEADLINE_FLAG = 1 AND d.COST_TYPE <> 'CPM' THEN d.HEADLINE
						ELSE NULL END,
		[Amount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN CASE WHEN h.NET_GROSS = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE d.EXT_GROSS_AMT * @ExchangeRate END ELSE 0 END - COALESCE(oc.AMOUNT, 0) * @ExchangeRate,
		[CostType] = d.COST_TYPE,
		[NetGross] = h.NET_GROSS,
		[RateType] = d.RATE_TYPE,
		[MaterialDueFlag] = mpd.MATL_DUE_FLAG,
		[HeadlineFlag] = mpd.HEADLINE_FLAG,
		[VendorTax] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NON_RESALE_AMT * @ExchangeRate ELSE 0 END,
		[LineTotalActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN 
								CASE WHEN h.NET_GROSS = 0 THEN d.LINE_TOTAL * @ExchangeRate ELSE COALESCE(d.LINE_TOTAL,0) * @ExchangeRate - COALESCE(d.COMM_AMT,0) * @ExchangeRate END
							ELSE 0
							END,
		[AgencyComment] = CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'N') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'N')
								WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
								ELSE (SELECT NEWS_COMMENT FROM dbo.AGENCY) END,
		[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'N') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'N') ELSE NULL END,
		[ColorCharge] = NULLIF(d.COLOR_CHARGE,0) * @ExchangeRate,
		[ColorDescription] = d.COLOR_DESC,
		[BleedCost] = NULL, -- BLEED_AMT MAGAZINE ONLY
		[PositionCost]= NULL, -- POSITION_AMT MAGAZINE ONLY
		[PremiumCost] = NULL, -- PREMIUM_AMT MAGAZINE ONLY
		[DiscountAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.DISCOUNT_AMT * @ExchangeRate ELSE 0 END,
		[DiscountDescription] = COALESCE(NULLIF(d.DISCOUNT_DESC,''),'Discount'),
		[CommissionActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN
								CASE WHEN h.NET_GROSS = 0 THEN 0 ELSE d.COMM_AMT * -1 * @ExchangeRate END
							 ELSE 0 
							 END,
		[SubTypeDescription] = NULL,
		[Impressions] = NULL,
		[BillTypeFlag] = d.BILL_TYPE_FLAG,
		[ShippingAddressFlag] = mpd.SHIP_ADDR_FLAG,
		[IncludeRep1] = mpd.INCLUDE_REP1,
		[RepLabel1] = mpd.REP_LABEL1,
		[IncludeRep2] = mpd.INCLUDE_REP2,
		[RepLabel2] = mpd.REP_LABEL2,
		[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
		[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
		[LocationID] = mpd.LOCATION_ID,
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
					 ELSE NULL
					 END,
		[VendorRepCode1] = h.VR_CODE,
		[VendorRepCode2] = h.VR_CODE2,
		[NetCharge] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NETCHARGE * @ExchangeRate ELSE 0 END,
		[NetChargeDescription] = COALESCE(NULLIF(d.NETCHARGE_DESC,''),'Net Charge'),
		[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
		[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
		[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
		[AdSizeDescription] = d.SIZE,
		[ClientGrossAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate ELSE 0 END,
		[NetAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE 0 END - COALESCE(oc.AMOUNT, 0) * @ExchangeRate,
		[LineClientGrossTotal] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate + COALESCE(NETCHARGE,0) * @ExchangeRate + COALESCE(DISCOUNT_AMT,0) * @ExchangeRate ELSE 0 END,
		ClientAddress1 = c.CL_ADDRESS1,
		ClientAddress2 = c.CL_ADDRESS2,
		ClientCity = c.CL_CITY,
		ClientState = c.CL_STATE,        
		ClientZip = c.CL_ZIP,
        NewspaperCirculationQty = CASE WHEN mpd.NP_INCLUDE_CIRC_QTY = 1 AND COST_TYPE = 'NA' AND RATE_TYPE = 'STD' THEN d.NP_CIRCULATION ELSE NULL END
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = @MediaType 
		LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
		LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		LEFT OUTER JOIN dbo.NEWSPAPER_COMMENTS nc ON d.ORDER_NBR = nc.ORDER_NBR AND d.LINE_NBR = nc.LINE_NBR 
		LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
		LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE 
		LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR AND an.ACTIVE = 1
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv1 ON an.DEF_BLKPLT_VER_CODE = bv1.BLACKPLT_VER_CODE AND (bv1.INACTIVE_FLAG IS NULL OR bv1.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv2 ON an.DEF_BLKPLT_VER2_CODE = bv2.BLACKPLT_VER_CODE AND (bv2.INACTIVE_FLAG IS NULL OR bv2.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		LEFT OUTER JOIN (
						SELECT AMOUNT, ORDER_NBR, LINE_NBR
						FROM dbo.NEWSPAPER_OTH_CHGS  
						WHERE CHG_TYPE = 'RC'
						) oc ON oc.ORDER_NBR = d.ORDER_NBR AND oc.LINE_NBR = d.LINE_NBR 
	WHERE
			h.ORDER_NBR = @OrderNumber 
	AND		d.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	ORDER BY d.[START_DATE], d.LINE_NBR

END ELSE IF @MediaType = 'I' BEGIN

	SELECT
		[MediaType] = @MediaType,
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
		[LineNumber] = RIGHT('000' + CONVERT(NVARCHAR, d.LINE_NBR), 3),
		[RevisionNumber] = d.REV_NBR,
		[Buyer] = h.BUYER,
		[OrderDescription] = h.ORDER_DESC,
		[OrderDate] = h.ORDER_DATE,
		----
		[Projected] = CASE WHEN d.PROJ_IMPRESSIONS IS NOT NULL AND mpd.PROJECTED_FLAG = 1 THEN REPLACE(CONVERT(VARCHAR(50), (CAST(d.PROJ_IMPRESSIONS AS money)), 1), '.00', '') + ' ' + COALESCE(NULLIF(mpd.INTERNET_QTY_OVERRIDE_TEXT,''), 'Impressions') ELSE NULL END,
		[Actual]= CASE WHEN d.ACT_IMPRESSIONS IS NOT NULL AND mpd.ACTUAL_FLAG = 1 THEN REPLACE(CONVERT(VARCHAR(50), (CAST(d.ACT_IMPRESSIONS AS money)), 1), '.00', '') + ' ' + COALESCE(NULLIF(mpd.INTERNET_QTY_OVERRIDE_TEXT,''), 'Impressions') ELSE NULL END,
		[Headline1] = CASE WHEN NULLIF(d.HEADLINE,'') IS NOT NULL AND mpd.HEADLINE_FLAG = 1 THEN d.HEADLINE ELSE NULL END,
        [URL] = CASE WHEN NULLIF(d.[URL],'') IS NOT NULL AND mpd.URL_FLAG = 1 THEN d.[URL] ELSE NULL END,
        [Location] = NULL,
        [CopyArea] = CASE WHEN NULLIF(d.COPY_AREA,'') IS NOT NULL AND mpd.COPY_AREA_FLAG = 1 THEN d.COPY_AREA ELSE NULL END,
        [Placement] = CASE WHEN mpd.PLACE1_FLAG = 1 THEN d.PLACEMENT_1 ELSE NULL END,
		[PackageName] = CASE WHEN mpd.PLACE2_FLAG = 1 THEN d.PLACEMENT_2 ELSE NULL END,
        [Target] = CASE WHEN NULLIF(d.TARGET_AUDIENCE,'') IS NOT NULL AND mpd.TARGET_FLAG = 1 THEN d.TARGET_AUDIENCE ELSE NULL END,
        [EditionIssue] = NULL,
        [Section] = NULL,
        [Material] = NULL,
        [AdNumber] = CASE WHEN mpd.AD_NUMBER_FLAG = 1 THEN d.AD_NUMBER + 
						CASE WHEN an.AD_NBR_DESC IS NOT NULL THEN ' - ' + an.AD_NBR_DESC + 
							CASE WHEN bv1.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Front: ' + bv1.BLACKPLT_VER_DESC ELSE '' END +
							CASE WHEN bv2.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Back: ' + bv2.BLACKPLT_VER_DESC ELSE '' END
						ELSE NULL END 
					ELSE NULL END,
        [AgencyJob] = CASE WHEN mpd.JOB_NUMBER_FLAG = 1 AND d.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(NVARCHAR, d.JOB_NUMBER), 6) + '-' + RIGHT('00' + CONVERT(NVARCHAR, d.JOB_COMPONENT_NBR), 2) ELSE NULL END,
        [MaterialDue] = CASE WHEN mpd.MATL_DUE_FLAG = 1 THEN d.MATL_CLOSE_DATE ELSE NULL END,
        [SpaceClose] = CASE WHEN mpd.SPACE_CLOSE_FLAG = 1 THEN d.CLOSE_DATE ELSE NULL END,
        [Instructions] = CASE WHEN mpd.INSTRUCTIONS_FLAG = 1 THEN ic.INSTRUCTIONS ELSE NULL END,
        [OrderCopy] = CASE WHEN mpd.ORDER_COPY_FLAG = 1 THEN ic.ORDER_COPY ELSE NULL END,
        [MaterialNotes] = CASE WHEN mpd.MATL_NOTES_FLAG = 1 THEN ic.MATL_NOTES ELSE NULL END,
        [PositionInfo] = NULL,
        [CloseInfo] = NULL,
        [RateInfo] = NULL,
        [MiscInfo] = CASE WHEN mpd.MISC_INFO_FLAG = 1 THEN ic.MISC_INFO ELSE NULL END,
		----
		[OrderComment] = h.ORDER_COMMENT,
		[RevisedCancelled] = CASE
								WHEN d.LINE_CANCELLED <> 0 THEN '**CANCELLED**'
								WHEN d.REV_NBR <> 0 AND mpd.PRINT_REVISION = 1 THEN '**REVISED**'
								ELSE NULL
							 END,
		[InsertDate] = d.[START_DATE],
		[InsertDay] = NULL,
		[EndDate] = d.END_DATE,
		[Size] = d.CREATIVE_SIZE, --CREATIVE_SIZE
		[ProductionSize] = NULL,
		[Headline] = NULL,
		[Amount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN CASE WHEN h.NET_GROSS = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE d.EXT_GROSS_AMT * @ExchangeRate END ELSE 0 END,
		[CostType] = d.COST_TYPE,
		[NetGross] = h.NET_GROSS,
		[RateType] = d.RATE_TYPE,
		[MaterialDueFlag] = mpd.MATL_DUE_FLAG,
		[HeadlineFlag] = mpd.HEADLINE_FLAG,
		[VendorTax] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NON_RESALE_AMT * @ExchangeRate ELSE 0 END,
		[LineTotalActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN 
								CASE WHEN h.NET_GROSS = 0 THEN d.LINE_TOTAL * @ExchangeRate ELSE COALESCE(d.LINE_TOTAL,0) * @ExchangeRate - COALESCE(d.COMM_AMT,0) * @ExchangeRate END
							ELSE 0
							END,
		[AgencyComment] = CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I')
								WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
								ELSE (SELECT INET_COMMENT FROM dbo.AGENCY) END,
		[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'I') ELSE NULL END,
		[ColorCharge] = NULL,
		[ColorDescription] = NULL,
		[BleedCost] = NULL, -- BLEED_AMT MAGAZINE ONLY
		[PositionCost]= NULL, -- POSITION_AMT MAGAZINE ONLY
		[PremiumCost] = NULL, -- PREMIUM_AMT MAGAZINE ONLY
		[DiscountAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.DISCOUNT_AMT * @ExchangeRate ELSE 0 END,
		[DiscountDescription] = COALESCE(NULLIF(d.DISCOUNT_DESC,''),'Discount'),
		[CommissionActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN
								CASE WHEN h.NET_GROSS = 0 THEN 0 ELSE d.COMM_AMT * -1 * @ExchangeRate END
							 ELSE 0 
							 END,
		[SubTypeDescription] = CASE WHEN mpd.TYPE_FLAG = 1 THEN t.OD_DESC ELSE NULL END,
		[Impressions] = CASE
							WHEN d.LINE_CANCELLED = 1 THEN NULL
							WHEN d.GUARANTEED_IMPRESS <> 0 AND mpd.GUARANTEED_FLAG = 1 AND mpd.COST_PER_FLAG = 1 THEN --AND d.COST_RATE <> 0
								CASE WHEN d.COST_TYPE = 'NA' THEN
									REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '')
								ELSE
									REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '') + ' @ ' + COALESCE(CAST(COST_RATE as VARCHAR(20)),'') + ' ' + d.COST_TYPE
								END
							WHEN d.GUARANTEED_IMPRESS <> 0 AND mpd.GUARANTEED_FLAG = 1 AND mpd.COST_PER_FLAG = 0 THEN 
								CASE 
									WHEN d.COST_TYPE = 'CPC' THEN
										REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '') + ' ' + COALESCE(NULLIF(mpd.INTERNET_QTY_OVERRIDE_TEXT,''), 'Clicks')
									WHEN d.COST_TYPE = 'CPA' THEN
										REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '') + ' ' + COALESCE(NULLIF(mpd.INTERNET_QTY_OVERRIDE_TEXT,''), 'Acquisitions')
									WHEN d.COST_TYPE = 'CPM' THEN
										REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '') + ' ' + COALESCE(NULLIF(mpd.INTERNET_QTY_OVERRIDE_TEXT,''), 'Impressions')
									ELSE
										REPLACE(CONVERT(VARCHAR(50), (CAST(d.GUARANTEED_IMPRESS AS money)), 1), '.00', '')
								END
							WHEN d.COST_RATE <> 0 AND mpd.COST_PER_FLAG = 1 THEN 
									CAST(COST_RATE as VARCHAR(20)) + ' ' + d.COST_TYPE
						END,
		[BillTypeFlag] = d.BILL_TYPE_FLAG,
		[ShippingAddressFlag] = mpd.SHIP_ADDR_FLAG,
		[IncludeRep1] = mpd.INCLUDE_REP1,
		[RepLabel1] = mpd.REP_LABEL1,
		[IncludeRep2] = mpd.INCLUDE_REP2,
		[RepLabel2] = mpd.REP_LABEL2,
		[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
		[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
		[LocationID] = mpd.LOCATION_ID,
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
					 ELSE NULL
					 END,
		[VendorRepCode1] = h.VR_CODE,
		[VendorRepCode2] = h.VR_CODE2,
		[NetCharge] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NETCHARGE * @ExchangeRate ELSE 0 END,
		[NetChargeDescription] = COALESCE(NULLIF(d.NCDESC,''),'Net Charge'),
		[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
		[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
		[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
		[ClientGrossAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate ELSE 0 END,
		[NetAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE 0 END,
		[LineClientGrossTotal] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate + COALESCE(NETCHARGE,0) * @ExchangeRate + COALESCE(DISCOUNT_AMT,0) * @ExchangeRate ELSE 0 END,
		ClientAddress1 = c.CL_ADDRESS1,
		ClientAddress2 = c.CL_ADDRESS2,
		ClientCity = c.CL_CITY,
		ClientState = c.CL_STATE,
		ClientZip = c.CL_ZIP,
        NewspaperCirculationQty = NULL
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = @MediaType 
		LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
		LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		LEFT OUTER JOIN dbo.INTERNET_COMMENTS ic ON d.ORDER_NBR = ic.ORDER_NBR AND d.LINE_NBR = ic.LINE_NBR 
		LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
		LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
		LEFT JOIN dbo.INTERNET_TYPE AS t ON d.INTERNET_TYPE = t.OD_CODE 
		LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR AND an.ACTIVE = 1
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv1 ON an.DEF_BLKPLT_VER_CODE = bv1.BLACKPLT_VER_CODE AND (bv1.INACTIVE_FLAG IS NULL OR bv1.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv2 ON an.DEF_BLKPLT_VER2_CODE = bv2.BLACKPLT_VER_CODE AND (bv2.INACTIVE_FLAG IS NULL OR bv2.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
	WHERE
			h.ORDER_NBR = @OrderNumber 
	AND		d.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	ORDER BY d.[START_DATE], d.LINE_NBR

END ELSE IF @MediaType = 'M' BEGIN

	SELECT
		[MediaType] = @MediaType,
		[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 THEN @LocationHeader ELSE NULL END,
		[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 THEN @LocationFooter ELSE NULL END,
		[PageHeaderLogoPath] = l.LOGO_PATH,
		[OrderLabel] =  CASE
							WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
							WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'MAGAZINE QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION = 'O' AND h.REVISED_FLAG = 1 THEN 'MAGAZINE ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																	FROM dbo.MAGAZINE_DETAIL 
																	WHERE ORDER_NBR = @OrderNumber 
																	AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																	AND ACTIVE_REV = 1
																	AND REV_NBR > 0) THEN 'MAGAZINE ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' THEN 'MAGAZINE ORDER'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.REVISED_FLAG = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																	 FROM dbo.MAGAZINE_DETAIL 
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
		[LineNumber] = RIGHT('000' + CONVERT(NVARCHAR, d.LINE_NBR), 3),
		[RevisionNumber] = d.REV_NBR,
		[Buyer] = h.BUYER,
		[OrderDescription] = h.ORDER_DESC,
		[OrderDate] = h.ORDER_DATE,
		----
		[Projected] = NULL,
		[Actual]= NULL,
		[Headline1] = NULL,
        [URL] = NULL,
        [Location] = NULL,
        [CopyArea] = NULL,
        [Placement] = NULL,
        [Target] = NULL,
        [EditionIssue] = CASE WHEN mpd.ISSUE_FLAG = 1 THEN d.EDITION_ISSUE ELSE NULL END,
        [Section] = CASE WHEN mpd.SECTION_FLAG = 1 THEN d.SECTION ELSE NULL END,
        [Material] = CASE WHEN mpd.MATERIAL_FLAG = 1 THEN d.MATERIAL ELSE NULL END,
        [AdNumber] = CASE WHEN mpd.AD_NUMBER_FLAG = 1 THEN d.AD_NUMBER + 
						CASE WHEN an.AD_NBR_DESC IS NOT NULL THEN ' - ' + an.AD_NBR_DESC + 
							CASE WHEN bv1.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Front: ' + bv1.BLACKPLT_VER_DESC ELSE '' END +
							CASE WHEN bv2.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Back: ' + bv2.BLACKPLT_VER_DESC ELSE '' END
						ELSE NULL END 
					ELSE NULL END,
        [AgencyJob] = CASE WHEN mpd.JOB_NUMBER_FLAG = 1 AND d.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(NVARCHAR, d.JOB_NUMBER), 6) + '-' + RIGHT('00' + CONVERT(NVARCHAR, d.JOB_COMPONENT_NBR), 2) ELSE NULL END,
        [MaterialDue] = CASE WHEN mpd.MATL_DUE_FLAG = 1 THEN d.MATL_CLOSE_DATE ELSE NULL END,
        [SpaceClose] = CASE WHEN mpd.SPACE_CLOSE_FLAG = 1 THEN d.CLOSE_DATE ELSE NULL END,
        [Instructions] = CASE WHEN mpd.INSTRUCTIONS_FLAG = 1 THEN mc.INSTRUCTIONS ELSE NULL END,
        [OrderCopy] = CASE WHEN mpd.ORDER_COPY_FLAG = 1 THEN mc.ORDER_COPY ELSE NULL END,
        [MaterialNotes] = CASE WHEN mpd.MATL_NOTES_FLAG = 1 THEN mc.MATL_NOTES ELSE NULL END,
        [PositionInfo] = CASE WHEN mpd.POSITION_FLAG = 1 THEN mc.POSITION_INFO ELSE NULL END,
        [CloseInfo] = CASE WHEN mpd.CLOSE_INFO_FLAG = 1 THEN mc.CLOSE_INFO ELSE NULL END,
        [RateInfo] = CASE WHEN mpd.RATE_INFO_FLAG = 1 THEN mc.RATE_INFO ELSE NULL END,
        [MiscInfo] = CASE WHEN mpd.MISC_INFO_FLAG = 1 THEN mc.MISC_INFO ELSE NULL END,
		----
		[OrderComment] = h.ORDER_COMMENT,
		[RevisedCancelled] = CASE
								WHEN d.LINE_CANCELLED <> 0 THEN '**CANCELLED**'
								WHEN d.REV_NBR <> 0 AND mpd.PRINT_REVISION = 1 THEN '**REVISED**'
								ELSE NULL
							 END,
		[InsertDate] = d.[START_DATE],
		[InsertDay] = NULL,
		[EndDate] = d.END_DATE,
		[Size] = d.SIZE,
		[ProductionSize] = CASE WHEN mpd.PROD_SPECS_FLAG = 1 THEN d.PRODUCTION_SIZE ELSE NULL END,
		[Headline] = CASE WHEN mpd.HEADLINE_FLAG = 1 AND NULLIF(d.HEADLINE,'') IS NOT NULL THEN d.HEADLINE ELSE NULL END,
		[Amount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN CASE WHEN h.NET_GROSS = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE d.EXT_GROSS_AMT * @ExchangeRate END ELSE 0 END,
		[CostType] = NULL,
		[NetGross] = h.NET_GROSS,
		[RateType] = NULL,
		[MaterialDueFlag] = mpd.MATL_DUE_FLAG,
		[HeadlineFlag] = mpd.HEADLINE_FLAG,
		[VendorTax] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NON_RESALE_AMT * @ExchangeRate ELSE 0 END,
		[LineTotalActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN 
								CASE WHEN h.NET_GROSS = 0 THEN d.LINE_TOTAL * @ExchangeRate ELSE COALESCE(d.LINE_TOTAL,0) * @ExchangeRate - COALESCE(d.COMM_AMT,0) * @ExchangeRate END
							ELSE 0
							END,
		[AgencyComment] = CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'M') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'M')
								WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
								ELSE (SELECT MAG_COMMENT FROM dbo.AGENCY) END,
		[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'M') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'M') ELSE NULL END,
		[ColorCharge] = NULLIF(d.COLOR_CHARGE,0) * @ExchangeRate,
		[ColorDescription] = COALESCE(NULLIF(d.COLOR_DESC,''),'Color Charge'),
		[BleedCost] = COALESCE(BLEED_AMT, 0) * @ExchangeRate,
		[PositionCost]= COALESCE(POSITION_AMT,0) * @ExchangeRate,
		[PremiumCost] = COALESCE(PREMIUM_AMT,0) * @ExchangeRate,
		[DiscountAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.DISCOUNT_AMT * @ExchangeRate ELSE 0 END,
		[DiscountDescription] = COALESCE(NULLIF(d.DISCOUNT_DESC,''),'Discount'),
		[CommissionActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN
								CASE WHEN h.NET_GROSS = 0 THEN 0 ELSE d.COMM_AMT * -1 * @ExchangeRate END
							 ELSE 0 
							 END,
		[SubTypeDescription] = NULL,
		[Impressions] = NULL,
		[BillTypeFlag] = d.BILL_TYPE_FLAG,
		[ShippingAddressFlag] = mpd.SHIP_ADDR_FLAG,
		[IncludeRep1] = mpd.INCLUDE_REP1,
		[RepLabel1] = mpd.REP_LABEL1,
		[IncludeRep2] = mpd.INCLUDE_REP2,
		[RepLabel2] = mpd.REP_LABEL2,
		[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
		[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
		[LocationID] = mpd.LOCATION_ID,
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
					 ELSE NULL
					 END,
		[VendorRepCode1] = h.VR_CODE,
		[VendorRepCode2] = h.VR_CODE2,
		[NetCharge] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NETCHARGE * @ExchangeRate ELSE 0 END,
		[NetChargeDescription] = COALESCE(NULLIF(d.NETCHARGE_DESC,''),'Net Charge'),
		[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
		[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
		[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
		[ClientGrossAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate ELSE 0 END,
		[NetAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE 0 END,
		[LineClientGrossTotal] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate + COALESCE(NETCHARGE,0) * @ExchangeRate + COALESCE(DISCOUNT_AMT,0) * @ExchangeRate ELSE 0 END,
		ClientAddress1 = c.CL_ADDRESS1,
		ClientAddress2 = c.CL_ADDRESS2,
		ClientCity = c.CL_CITY,
		ClientState = c.CL_STATE,
		ClientZip = c.CL_ZIP,
        NewspaperCirculationQty = NULL
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = @MediaType 
		LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
		LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		LEFT OUTER JOIN dbo.MAGAZINE_COMMENTS mc ON d.ORDER_NBR = mc.ORDER_NBR AND d.LINE_NBR = mc.LINE_NBR 
		LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
		LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE 
		LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR AND an.ACTIVE = 1
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv1 ON an.DEF_BLKPLT_VER_CODE = bv1.BLACKPLT_VER_CODE AND (bv1.INACTIVE_FLAG IS NULL OR bv1.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv2 ON an.DEF_BLKPLT_VER2_CODE = bv2.BLACKPLT_VER_CODE AND (bv2.INACTIVE_FLAG IS NULL OR bv2.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
	WHERE
			h.ORDER_NBR = @OrderNumber 
	AND		d.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	ORDER BY d.[START_DATE], d.LINE_NBR

END ELSE IF @MediaType = 'O' BEGIN

	SELECT
		[MediaType] = @MediaType,
		[LocationHeader] = CASE WHEN l.PRT_HEADER = 1 THEN @LocationHeader ELSE NULL END,
		[LocationFooter] = CASE WHEN l.PRT_FOOTER = 1 THEN @LocationFooter ELSE NULL END,
		[PageHeaderLogoPath] = l.LOGO_PATH,
		[OrderLabel] =  CASE
							WHEN ISNULL(mpd.MEDIA_TITLE_OVERRIDE, '') <> '' THEN mpd.MEDIA_TITLE_OVERRIDE
							WHEN mpd.TITLE_OPTION = 'O' AND h.[STATUS] = 1 THEN 'OUTDOOR QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION = 'O' AND h.REVISED_FLAG = 1 THEN 'OUTDOOR ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' AND EXISTS (SELECT 1 
																	FROM dbo.OUTDOOR_DETAIL 
																	WHERE ORDER_NBR = @OrderNumber 
																	AND LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
																	AND ACTIVE_REV = 1
																	AND REV_NBR > 0) THEN 'OUTDOOR ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION = 'O' THEN 'OUTDOOR ORDER'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.[STATUS] = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' QUOTE REQUEST'
							WHEN mpd.TITLE_OPTION <> 'O' AND h.REVISED_FLAG = 1 THEN UPPER(sc.SC_DESCRIPTION) + ' ORDER ' + CASE WHEN mpd.PRINT_REVISION = 1 THEN 'REVISION' ELSE '' END
							WHEN mpd.TITLE_OPTION <> 'O' AND EXISTS (SELECT 1 
																	 FROM dbo.OUTDOOR_DETAIL 
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
		[LineNumber] = RIGHT('000' + CONVERT(NVARCHAR, d.LINE_NBR), 3),
		[RevisionNumber] = d.REV_NBR,
		[Buyer] = h.BUYER,
		[OrderDescription] = h.ORDER_DESC,
		[OrderDate] = h.ORDER_DATE,
		----
		[Projected] = NULL,
		[Actual]= NULL,
		[Headline1] = NULL,
        [URL] = NULL,
        [Location] = CASE WHEN NULLIF(d.[LOCATION],'') IS NOT NULL AND mpd.LOCATION_FLAG = 1 THEN d.[LOCATION] ELSE NULL END,
        [CopyArea] = CASE WHEN NULLIF(d.COPY_AREA,'') IS NOT NULL AND mpd.COPY_AREA_FLAG = 1 THEN d.COPY_AREA ELSE NULL END,
        [Placement] = NULL,
        [Target] = NULL,
        [EditionIssue] = NULL,
        [Section] = NULL,
        [Material] = NULL,
        [AdNumber] = CASE WHEN mpd.AD_NUMBER_FLAG = 1 THEN d.AD_NUMBER + 
						CASE WHEN an.AD_NBR_DESC IS NOT NULL THEN ' - ' + an.AD_NBR_DESC + 
							CASE WHEN bv1.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Front: ' + bv1.BLACKPLT_VER_DESC ELSE '' END +
							CASE WHEN bv2.BLACKPLT_VER_DESC IS NOT NULL THEN CHAR(13) + 'Back: ' + bv2.BLACKPLT_VER_DESC ELSE '' END
						ELSE NULL END 
					ELSE NULL END,
        [AgencyJob] = CASE WHEN mpd.JOB_NUMBER_FLAG = 1 AND d.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(NVARCHAR, d.JOB_NUMBER), 6) + '-' + RIGHT('00' + CONVERT(NVARCHAR, d.JOB_COMPONENT_NBR), 2) ELSE NULL END,
        [MaterialDue] = CASE WHEN mpd.MATL_DUE_FLAG = 1 THEN d.MATL_CLOSE_DATE ELSE NULL END,
        [SpaceClose] = CASE WHEN mpd.SPACE_CLOSE_FLAG = 1 THEN d.CLOSE_DATE ELSE NULL END,
        [Instructions] = CASE WHEN mpd.INSTRUCTIONS_FLAG = 1 THEN oc.INSTRUCTIONS ELSE NULL END,
        [OrderCopy] = CASE WHEN mpd.ORDER_COPY_FLAG = 1 THEN oc.ORDER_COPY ELSE NULL END,
        [MaterialNotes] = CASE WHEN mpd.MATL_NOTES_FLAG = 1 THEN oc.MATL_NOTES ELSE NULL END,
        [PositionInfo] = NULL,
        [CloseInfo] = NULL,
        [RateInfo] = NULL,
        [MiscInfo] = CASE WHEN mpd.MISC_INFO_FLAG = 1 THEN oc.MISC_INFO ELSE NULL END,
		----
		[OrderComment] = h.ORDER_COMMENT,
		[RevisedCancelled] = CASE
								WHEN d.LINE_CANCELLED <> 0 THEN '**CANCELLED**'
								WHEN d.REV_NBR <> 0 AND mpd.PRINT_REVISION = 1 THEN '**REVISED**'
								ELSE NULL
							 END,
		[InsertDate] = d.[POST_DATE],
		[InsertDay] = NULL,
		[EndDate] = d.END_DATE,
		[Size] = ads.SIZE_DESC,
		[ProductionSize] = CASE WHEN mpd.TYPE_FLAG = 1 THEN NULLIF(t.OD_DESC,'') ELSE NULL END,
		[Headline] = CASE WHEN NULLIF(d.HEADLINE,'') IS NOT NULL AND mpd.HEADLINE_FLAG = 1 THEN d.HEADLINE ELSE NULL END,
		[Amount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN CASE WHEN h.NET_GROSS = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE d.EXT_GROSS_AMT * @ExchangeRate END ELSE 0 END,
		[CostType] = NULL,
		[NetGross] = h.NET_GROSS,
		[RateType] = d.RATE_TYPE,
		[MaterialDueFlag] = mpd.MATL_DUE_FLAG,
		[HeadlineFlag] = mpd.HEADLINE_FLAG,
		[VendorTax] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NON_RESALE_AMT * @ExchangeRate ELSE 0 END,
		[LineTotalActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN 
								CASE WHEN h.NET_GROSS = 0 THEN d.LINE_TOTAL * @ExchangeRate ELSE COALESCE(d.LINE_TOTAL,0) * @ExchangeRate - COALESCE(d.COMM_AMT,0) * @ExchangeRate END
							ELSE 0
							END,
		[AgencyComment] = CASE	WHEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'O') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'O')
								WHEN vc.USE_FOOTER = 1 THEN vc.FOOTER_INFO 
								ELSE (SELECT OTDR_COMMENT FROM dbo.AGENCY) END,
		[AgencyCommentFontSize] = CASE WHEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'O') IS NOT NULL THEN [dbo].[advfn_media_mgr_order_footer_comment_font_size](h.OFFICE_CODE, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, 'O') ELSE NULL END,
		[ColorCharge] = NULL,
		[ColorDescription] = NULL,
		[BleedCost] = NULL, -- BLEED_AMT MAGAZINE ONLY
		[PositionCost]= NULL, -- POSITION_AMT MAGAZINE ONLY
		[PremiumCost] = NULL, -- PREMIUM_AMT MAGAZINE ONLY
		[DiscountAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.DISCOUNT_AMT * @ExchangeRate ELSE 0 END,
		[DiscountDescription] = COALESCE(NULLIF(d.DISCOUNT_DESC,''),'Discount'),
		[CommissionActual] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN
								CASE WHEN h.NET_GROSS = 0 THEN 0 ELSE d.COMM_AMT * -1 * @ExchangeRate END
							 ELSE 0 
							 END,
		[SubTypeDescription] = t.OD_DESC,
		[Impressions] = REPLACE(CONVERT(varchar, CAST(COALESCE(d.IMPRESSIONS,0) AS money), 1),'.00',''),
		[BillTypeFlag] = d.BILL_TYPE_FLAG,
		[ShippingAddressFlag] = mpd.SHIP_ADDR_FLAG,
		[IncludeRep1] = mpd.INCLUDE_REP1,
		[RepLabel1] = mpd.REP_LABEL1,
		[IncludeRep2] = mpd.INCLUDE_REP2,
		[RepLabel2] = mpd.REP_LABEL2,
		[DefaultRep1Label] = mpd.DEF_REP_LABEL1,
		[DefaultRep2Label] = mpd.DEF_REP_LABEL2,
		[LocationID] = mpd.LOCATION_ID,
		[ChargeTo] = CASE WHEN vcc.CARD_NUMBER IS NOT NULL THEN 
						CARD_NUMBER + ' - ' + CONVERT(char(10), EXPIRATION_DATE, 101) + ' - ' + CVC_CODE
					 ELSE NULL
					 END,
		[VendorRepCode1] = h.VR_CODE,
		[VendorRepCode2] = h.VR_CODE2,
		[NetCharge] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.NETCHARGE * @ExchangeRate ELSE 0 END,
		[NetChargeDescription] = COALESCE(NULLIF(d.NCDESC,''),'Net Charge'),
		[ExcludeEmployeeSignature] = CAST(COALESCE(mpd.USE_EMP_SIG, 0) AS bit),
		[OrderHeaderCommentOption] = CAST(COALESCE(mpd.ORDER_HEADER_COMMENT_OPTION, 0) AS smallint),
		[BuyerEmployeeCode] = h.BUYER_EMP_CODE,
		[ClientGrossAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate ELSE 0 END,
		[NetAmount] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate ELSE 0 END,
		[LineClientGrossTotal] = CASE WHEN COALESCE(d.LINE_CANCELLED, 0) = 0 THEN d.EXT_NET_AMT * @ExchangeRate + COALESCE(d.COMM_AMT,0) * @ExchangeRate + COALESCE(d.ADDL_CHARGE,0) * @ExchangeRate + COALESCE(NETCHARGE,0) * @ExchangeRate + COALESCE(DISCOUNT_AMT,0) * @ExchangeRate ELSE 0 END,
		ClientAddress1 = c.CL_ADDRESS1,
		ClientAddress2 = c.CL_ADDRESS2,
		ClientCity = c.CL_CITY,
		ClientState = c.CL_STATE,
		ClientZip = c.CL_ZIP,
        NewspaperCirculationQty = NULL
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.MEDIA_PRINT_DEF mpd ON mpd.[USER_ID] = @UserCode AND mpd.MEDIA_TYPE = @MediaType 
		LEFT OUTER JOIN dbo.VENDOR_COMMENTS vc ON h.VN_CODE = vc.VN_CODE
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
		LEFT OUTER JOIN dbo.LOCATIONS l ON mpd.LOCATION_ID = l.ID
		LEFT OUTER JOIN dbo.OUTDOOR_COMMENTS oc ON d.ORDER_NBR = oc.ORDER_NBR AND d.LINE_NBR = oc.LINE_NBR 
		LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER 
		LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE 
		LEFT OUTER JOIN dbo.AD_NUMBER an ON d.AD_NUMBER = an.AD_NBR AND an.ACTIVE = 1
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv1 ON an.DEF_BLKPLT_VER_CODE = bv1.BLACKPLT_VER_CODE AND (bv1.INACTIVE_FLAG IS NULL OR bv1.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.BLACKPLT_VERSION bv2 ON an.DEF_BLKPLT_VER2_CODE = bv2.BLACKPLT_VER_CODE AND (bv2.INACTIVE_FLAG IS NULL OR bv2.INACTIVE_FLAG = 0)
		LEFT OUTER JOIN dbo.OUTDOOR_TYPE t ON d.OUTDOOR_TYPE = t.OD_CODE
		LEFT OUTER JOIN dbo.AD_SIZE ads ON d.SIZE = ads.SIZE_CODE AND ads.MEDIA_TYPE = 'O'
		LEFT OUTER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
	WHERE
			h.ORDER_NBR = @OrderNumber 
	AND		d.LINE_NBR IN (SELECT * FROM dbo.udf_split_list(@LineNumbers, ','))
	ORDER BY d.[POST_DATE], d.LINE_NBR

END
GO