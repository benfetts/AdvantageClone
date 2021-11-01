if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_DRPT_NEWSPAPER_SHIPPING_LIST]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_DRPT_NEWSPAPER_SHIPPING_LIST]
GO

CREATE VIEW [dbo].[V_DRPT_NEWSPAPER_SHIPPING_LIST]

WITH SCHEMABINDING 
AS

SELECT [ID] = NEWID(),
	   [VendorCode] = VENDOR.VN_CODE,
	   [VendorName] = VENDOR.VN_NAME,
	   [Address1] = VENDOR.VN_ADDRESS1, 
	   [Address2] = VENDOR.VN_ADDRESS2, 
	   [City] = VENDOR.VN_CITY, 
	   [County] = VENDOR.VN_COUNTY, 
       [State] = VENDOR.VN_STATE, 
       [Country] = VENDOR.VN_COUNTRY, 
       [ZipCode] = VENDOR.VN_ZIP, 
       [Phone] = VENDOR.VN_PHONE, 
       [PhoneExt] = VENDOR.VN_PHONE_EXT, 
       [Fax] = VENDOR.VN_FAX_NUMBER, 
       [FaxExt] = VENDOR.VN_FAX_EXTENTION, 
       [ShippingName] = VENDOR.SHIP_NAME, 
       [ShippingAddress1] = VENDOR.SHIP_ADDR1, 
       [ShippingAddress2] = VENDOR.SHIP_ADDR2, 
       [ShippingAddress3] = VENDOR.SHIP_ADDR3, 
       [ShippingCity] = VENDOR.SHIP_CITY, 
       [ShippingCounty] = VENDOR.SHIP_COUNTY, 
       [ShippingCountry] = VENDOR.SHIP_COUNTRY, 
       [ShippingState] = VENDOR.SHIP_STATE, 
       [ShippingZip] = VENDOR.SHIP_ZIP, 
       [ShippingPhone] = VENDOR.SHIP_PHONE, 
       [ShippingPhoneExt] = VENDOR.SHIP_PHONE_EXT, 
       [VendorDefaultRep1] = VENDOR.DEF_VN_REP1, 
       [VendorDefaultRepName1] = COALESCE((RTRIM(VEN_REP.VR_FNAME) + ' '),'') + COALESCE((VEN_REP.VR_MI + '. '),'') + COALESCE(VEN_REP.VR_LNAME,''),
       [VendorDefaultRep2] = VENDOR.DEF_VN_REP2,  
       [VendorDefaultRepName2] = COALESCE((RTRIM(VEN_REP_1.VR_FNAME) + ' '),'') + COALESCE((VEN_REP_1.VR_MI + '. '),'') + COALESCE(VEN_REP_1.VR_LNAME,''),
       [OveragePct] = VENDOR.OVERAGE_PCT, 
       [Fold] = CASE WHEN VENDOR.FOLD = 1 THEN 'Yes' Else 'No' END, 
       [CampaignClient] = CAMPAIGN.CL_CODE, 
       [CampaignClientDescription] = CLIENT.CL_NAME, 
       [CampaignDivision] = CAMPAIGN.DIV_CODE, 
       [CampaignDivisionDescription] = DIVISION_1.DIV_NAME, 
       [CampaignProduct] = CAMPAIGN.PRD_CODE, 
       [CampaignProductDescription] = PRODUCT_1.PRD_DESCRIPTION, 
       [CampaignCode] = NEWSPAPER_HEADER.CMP_CODE, 
       [CampaignID] = NEWSPAPER_HEADER.CMP_IDENTIFIER, 
       [CampaignName] = CAMPAIGN.CMP_NAME, 
       [CampaignBeginDate] = CAMPAIGN.CMP_BEG_DATE, 
       [CampaignEndDate] = CAMPAIGN.CMP_END_DATE, 
       [CampaignClosed] = CAMPAIGN.CMP_CLOSED, 
       [CampaignBillingBudget] = CAMPAIGN.CMP_BILL_BUDGET, 
       [CampaignIncomeBudget] = CAMPAIGN.CMP_INC_BUDGET, 
       [CampaignComments] = CAMPAIGN.CMP_COMMENTS, 
       [CampaignAdNumber] = CAMPAIGN.AD_NBR, 
       [CampaignAdNumberExp] = AD_NUMBER.EXP_DT,
	   [CampaignMarket] = CAMPAIGN.MARKET_CODE,
	   [CampaignMarketDescription] = MARKET.MARKET_DESC, 
	   [CampaignJobNumber] = CAMPAIGN.JOB_NUMBER,
	   [CampaignJobDescription] = JOB_LOG.JOB_DESC,
       [ClientCode] = NEWSPAPER_HEADER.CL_CODE, 
       [ClientDescription] = CLIENT_1.CL_NAME,
       [DivisionCode] = NEWSPAPER_HEADER.DIV_CODE, 
       [DivisionDescription] = DIVISION.DIV_NAME,
       [ProductCode] = NEWSPAPER_HEADER.PRD_CODE,
       [ProductDescription] = PRODUCT.PRD_DESCRIPTION,
       [OrderNumber] = NEWSPAPER_HEADER.ORDER_NBR, 
       [OrderDescription] = NEWSPAPER_HEADER.ORDER_DESC, 
       [MediaType] = NEWSPAPER_HEADER.MEDIA_TYPE, 
       [ClientPO] = NEWSPAPER_HEADER.CLIENT_PO,
       [OrderDate] = NEWSPAPER_HEADER.ORDER_DATE, 
       [Buyer] = NEWSPAPER_HEADER.BUYER, 
       [OrderComment] = NEWSPAPER_HEADER.ORDER_COMMENT, 
       [HouseComment] = NEWSPAPER_HEADER.HOUSE_COMMENT, 
       [OrderMarketCode] = NEWSPAPER_HEADER.MARKET_CODE, 
       [OrderMarketDescription] = MARKET_1.MARKET_DESC, 
       [OrderRep1] = NEWSPAPER_HEADER.VR_CODE, 
       [OrderRepName1] = COALESCE((RTRIM(VEN_REP_2.VR_FNAME) + ' '),'') + COALESCE((VEN_REP_2.VR_MI + '. '),'') + COALESCE(VEN_REP_2.VR_LNAME,''), 
       [OrderRep2] = NEWSPAPER_HEADER.VR_CODE2,  
       [OrderRepName2] = COALESCE((RTRIM(VEN_REP_3.VR_FNAME) + ' '),'') + COALESCE((VEN_REP_3.VR_MI + '. '),'') + COALESCE(VEN_REP_3.VR_LNAME,''), 
       [Size] = NEWSPAPER_DETAIL.SIZE, 
       [OrderAdNumber] = NEWSPAPER_DETAIL.AD_NUMBER, 
       [OrderAdNumberDescription] = AD_NUMBER_1.AD_NBR_DESC, 
       [Headline] = NEWSPAPER_DETAIL.HEADLINE, 
       [Material] = NEWSPAPER_DETAIL.MATERIAL, 
       [EditionIssue] = NEWSPAPER_DETAIL.EDITION_ISSUE, 
       [Section] = NEWSPAPER_DETAIL.SECTION, 
       [JobNumber] = NEWSPAPER_DETAIL.JOB_NUMBER, 
       [ComponentNumber] = NEWSPAPER_DETAIL.JOB_COMPONENT_NBR, 
       [StartDate] = NEWSPAPER_DETAIL.START_DATE, 
       [EndDate] = NEWSPAPER_DETAIL.END_DATE, 
       [CloseDate] = NEWSPAPER_DETAIL.CLOSE_DATE, 
       [MatlCloseDate] = NEWSPAPER_DETAIL.MATL_CLOSE_DATE, 
       [ExtCloseDate] = NEWSPAPER_DETAIL.EXT_CLOSE_DATE, 
       [ExtMatlDate] = NEWSPAPER_DETAIL.EXT_MATL_DATE, 
       [NpCirculation] = NEWSPAPER_DETAIL.PRINT_LINES, 
       [ProductionQty] = NEWSPAPER_DETAIL.PRINT_QUANTITY, 
       [Qty] = NEWSPAPER_DETAIL.PRINT_LINES, 
       [CostType] = NEWSPAPER_DETAIL.COST_TYPE, 
       [NetRate] = NEWSPAPER_DETAIL.NET_RATE, 
       [GrossRate] = NEWSPAPER_DETAIL.GROSS_RATE, 
       [ExtNetAmount] = NEWSPAPER_DETAIL.EXT_NET_AMT, 
       [ExtGrossAmount] = NEWSPAPER_DETAIL.EXT_GROSS_AMT, 
       [CommAmount] = NEWSPAPER_DETAIL.COMM_AMT, 
       [RebateAmount] = NEWSPAPER_DETAIL.REBATE_AMT, 
       [DiscountAmount] = NEWSPAPER_DETAIL.DISCOUNT_AMT, 
       [StateAmount] = NEWSPAPER_DETAIL.STATE_AMT, 
       [CountyAmount] = NEWSPAPER_DETAIL.COUNTY_AMT, 
       [CityAmount] = NEWSPAPER_DETAIL.CITY_AMT, 
       [NonResaleAmount] = NEWSPAPER_DETAIL.NON_RESALE_AMT, 
       [AddlCharge] = NEWSPAPER_DETAIL.ADDL_CHARGE, 
       [ProdCharge] = NEWSPAPER_DETAIL.PROD_CHARGE, 
       [ColorCharge] = NEWSPAPER_DETAIL.COLOR_CHARGE, 
       [OrderTotal] = NEWSPAPER_DETAIL.LINE_TOTAL, 
       [BillingAmount] = NEWSPAPER_DETAIL.BILLING_AMT, 
       [Instructions] = NEWSPAPER_COMMENTS.INSTRUCTIONS, 
       [OrderCopy] = NEWSPAPER_COMMENTS.ORDER_COPY, 
       [MatlNotes] = NEWSPAPER_COMMENTS.MATL_NOTES, 
       [PositionInfo] = NEWSPAPER_COMMENTS.POSITION_INFO, 
       [CloseInfo] = NEWSPAPER_COMMENTS.CLOSE_INFO, 
       [RateInfo] = NEWSPAPER_COMMENTS.RATE_INFO, 
       [MiscInfo] = NEWSPAPER_COMMENTS.MISC_INFO, 
       [InHouseComments] = NEWSPAPER_COMMENTS.IN_HOUSE_CMTS
FROM         [dbo].VEN_REP AS VEN_REP_3 RIGHT OUTER JOIN
                      [dbo].VEN_REP AS VEN_REP_2 RIGHT OUTER JOIN
                      [dbo].AD_NUMBER AS AD_NUMBER_1 RIGHT OUTER JOIN
                      [dbo].CLIENT AS CLIENT_1 INNER JOIN
                      [dbo].DIVISION ON CLIENT_1.CL_CODE = [dbo].DIVISION.CL_CODE RIGHT OUTER JOIN
                      [dbo].NEWSPAPER_DETAIL INNER JOIN
                      [dbo].NEWSPAPER_COMMENTS ON [dbo].NEWSPAPER_DETAIL.ORDER_NBR = [dbo].NEWSPAPER_COMMENTS.ORDER_NBR AND 
                      [dbo].NEWSPAPER_DETAIL.LINE_NBR = [dbo].NEWSPAPER_COMMENTS.LINE_NBR INNER JOIN
                      [dbo].NEWSPAPER_HEADER ON [dbo].NEWSPAPER_DETAIL.ORDER_NBR = [dbo].NEWSPAPER_HEADER.ORDER_NBR INNER JOIN
                      [dbo].VENDOR ON [dbo].NEWSPAPER_HEADER.VN_CODE = [dbo].VENDOR.VN_CODE INNER JOIN
                      [dbo].PRODUCT ON [dbo].NEWSPAPER_HEADER.CL_CODE = [dbo].PRODUCT.CL_CODE AND [dbo].NEWSPAPER_HEADER.DIV_CODE = [dbo].PRODUCT.DIV_CODE AND 
                      [dbo].NEWSPAPER_HEADER.PRD_CODE = [dbo].PRODUCT.PRD_CODE ON [dbo].DIVISION.DIV_CODE = [dbo].PRODUCT.DIV_CODE AND 
                      [dbo].DIVISION.CL_CODE = [dbo].PRODUCT.CL_CODE LEFT OUTER JOIN
                      [dbo].DIVISION AS DIVISION_1 RIGHT OUTER JOIN
                      [dbo].CLIENT RIGHT OUTER JOIN
                      [dbo].CAMPAIGN ON [dbo].CLIENT.CL_CODE = [dbo].CAMPAIGN.CL_CODE ON DIVISION_1.CL_CODE = [dbo].CAMPAIGN.CL_CODE AND 
                      DIVISION_1.DIV_CODE = [dbo].CAMPAIGN.DIV_CODE LEFT OUTER JOIN
                      [dbo].PRODUCT AS PRODUCT_1 ON [dbo].CAMPAIGN.CL_CODE = PRODUCT_1.CL_CODE AND [dbo].CAMPAIGN.DIV_CODE = PRODUCT_1.DIV_CODE AND 
                      [dbo].CAMPAIGN.PRD_CODE = PRODUCT_1.PRD_CODE ON [dbo].NEWSPAPER_HEADER.CMP_IDENTIFIER = [dbo].CAMPAIGN.CMP_IDENTIFIER ON 
                      AD_NUMBER_1.AD_NBR = [dbo].NEWSPAPER_DETAIL.AD_NUMBER LEFT OUTER JOIN
                      [dbo].AD_NUMBER ON [dbo].CAMPAIGN.AD_NBR = [dbo].AD_NUMBER.AD_NBR LEFT OUTER JOIN
                      [dbo].MARKET ON [dbo].CAMPAIGN.MARKET_CODE = [dbo].MARKET.MARKET_CODE LEFT OUTER JOIN
                      [dbo].MARKET AS MARKET_1 ON [dbo].NEWSPAPER_HEADER.MARKET_CODE = MARKET_1.MARKET_CODE LEFT OUTER JOIN
                      [dbo].VEN_REP ON [dbo].VENDOR.VN_CODE = [dbo].VEN_REP.VN_CODE AND [dbo].VENDOR.DEF_VN_REP1 = [dbo].VEN_REP.VR_CODE LEFT OUTER JOIN
                      [dbo].VEN_REP AS VEN_REP_1 ON [dbo].VENDOR.VN_CODE = VEN_REP_1.VN_CODE AND [dbo].VENDOR.DEF_VN_REP2 = VEN_REP_1.VR_CODE ON 
                      VEN_REP_2.VN_CODE = [dbo].NEWSPAPER_HEADER.VN_CODE AND VEN_REP_2.VR_CODE = [dbo].NEWSPAPER_HEADER.VR_CODE ON 
                      VEN_REP_3.VN_CODE = [dbo].NEWSPAPER_HEADER.VN_CODE AND VEN_REP_3.VR_CODE = [dbo].NEWSPAPER_HEADER.VR_CODE2 LEFT OUTER JOIN
					  [dbo].JOB_LOG ON [dbo].CAMPAIGN.JOB_NUMBER = [dbo].JOB_LOG.JOB_NUMBER

					  

WHERE (NEWSPAPER_DETAIL.ACTIVE_REV = 1)
		
