if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_DRPT_PRODUCTS]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_DRPT_PRODUCTS]
GO

CREATE VIEW [dbo].[V_DRPT_PRODUCTS]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[ClientCode] = P.CL_CODE,  
		[ClientName] = C.CL_NAME, 
		[DivisionCode] = P.DIV_CODE,
		[DivisionName] = D.DIV_NAME, 
		[ProductCode] = P.PRD_CODE, 
		[ProductName] = P.PRD_DESCRIPTION, 
		[OfficeCode] = P.OFFICE_CODE, 
		[OfficeName] = O.OFFICE_NAME, 
		[NewBusiness] = CASE WHEN C.NEW_BUSINESS = 1 THEN 'Y' ELSE 'N' END,
		[IsActive] = CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 1 AND ISNULL(D.ACTIVE_FLAG, 0) = 1 THEN 
							CASE WHEN ISNULL(P.ACTIVE_FLAG, 0) = 1 THEN 'Y' ELSE 'N' END 
					 ELSE 'N' END,
		[DefaultAECode] = AE.EMP_CODE,
		[DefaultAEName] = COALESCE((RTRIM(EMP.EMP_FNAME)+' '),'')+COALESCE((EMP.EMP_MI+'. '),'')+COALESCE(EMP.EMP_LNAME,''),
		[BillingAddress1] = P.PRD_BILL_ADDRESS1,
		[BillingAddress2] = P.PRD_BILL_ADDRESS2,
		[BillingCity] = P.PRD_BILL_CITY,
		[BillingCounty] = P.PRD_BILL_COUNTY,
		[BillingState] = P.PRD_BILL_STATE,
		[BillingZip] = P.PRD_BILL_ZIP,
		[BillingCountry] = P.PRD_BILL_COUNTRY,
		[BillingPhone] = P.PRD_BILL_TELEPHONE,
		[BillingPhoneExt] = P.PRD_BILL_EXTENTION,
		[BillingFax] = P.PRD_BILL_FAX,
		[BillingFaxExt] = P.PRD_BILL_FAX_EXT,
		[StatementAddress1] = P.PRD_STATE_ADDR1,
		[StatementAddress2] = P.PRD_STATE_ADDR2,
		[StatementCity] = P.PRD_STATE_CITY,
		[StatementCounty] = P.PRD_STATE_COUNTY,
		[StatementState] = P.PRD_STATE_STATE,
		[StatementZip] = P.PRD_STATE_ZIP,
		[StatementCountry] = P.PRD_STATE_COUNTRY,
		[StatementPhone] = P.PRD_STATE_TELEPHON,
		[StatementPhoneExt] = P.PRD_STATE_EXT,
		[StatementFax] = P.PRD_STATE_FAX,
		[StatementFaxExt] = P.PRD_STATE_FAX_EXT,
		[SortName] = P.PRD_ALPHA_SORT,
		[AttentionLine] = P.PRD_ATTENTION,
		[CurrencyCode] = P.CURRENCY_CODE,
		[UserDefinedField1] = P.USER_DEFINED1,
		[UserDefinedField2] = P.USER_DEFINED2,
		[UserDefinedField3] = P.USER_DEFINED3,
		[UserDefinedField4] = P.USER_DEFINED4,
		
		[ProductionContingency] = P.PRD_CONT_PCT,
		[ProductionMarkup] = P.PRD_PROD_MARKUP,
		[ProductionEmployeeTimeBillingRate] = P.PRD_BILL_RATE,
		[ProductionUseEstimateBillingRate] = CASE WHEN P.USE_EST_BILL_RATE = 1 THEN 'Y' ELSE 'N' END,
		[ProductionTaxCode] = P.PRD_PROD_TAX_CODE,
		[ProductionAlertGroup] = P.EMAIL_GR_CODE,
		[ProductionConsolidateFunctions] = CASE WHEN P.PRD_CONSOL_FUNC = 1 THEN 'Y' ELSE 'N' END,
		[ProductionBillNet] = CASE WHEN P.PRD_PROD_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[ProductionVendorDiscounts] = CASE WHEN P.PRD_PROD_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[ProductionApprovedEstimatedRequired] = CASE WHEN P.PRD_PROD_ESTIMATE = 1 THEN 'Y' ELSE 'N' END,
		[ProductionBillingSetupComplete] = CASE WHEN P.PROD_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		
		[RadioPrePostBill] = CASE WHEN P.PRD_RADIO_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[RadioMarkup] = P.PRD_RADIO_COMM,
		[RadioRebate] = P.PRD_RADIO_REBATE,
		[RadioBillNet] = CASE WHEN P.PRD_RADIO_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[RadioCommissionOnly] = CASE WHEN P.PRD_RADIO_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[RadioDaysToBill] = P.PRD_RADIO_DAYS,
		[RadioBillSetting] = CASE P.PRD_RADIO_BF_AF WHEN 2 THEN 'After Broadcast Date'
													WHEN 3 THEN 'Before Close Date' 
													ELSE 'Before Broadcast Date' END,
		[RadioVendorDiscounts] = CASE WHEN P.PRD_RADIO_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[RadioTaxCode] = P.PRD_RADIO_TAX_CODE,
		[RadioBillingSetupComplete] = CASE WHEN P.RADIO_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_R = 1 THEN 'Y' ELSE 'N' END,
		[RadioApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_R = 1 THEN 'Y' ELSE 'N' END,

		[TelevisionPrePostBill] = CASE WHEN P.PRD_TV_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[TelevisionMarkup] = P.PRD_TV_COMM,
		[TelevisionRebate] = P.PRD_TV_REBATE,
		[TelevisionBillNet] = CASE WHEN P.PRD_TV_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionCommissionOnly] = CASE WHEN P.PRD_TV_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionDaysToBill] = P.PRD_TV_DAYS,
		[TelevisionBillSetting] = CASE P.PRD_TV_BF_AF WHEN 2 THEN 'After Broadcast Date'
													  WHEN 3 THEN 'Before Close Date'
													  ELSE 'Before Broadcast Date' END,
		[TelevisionVendorDiscounts] = CASE WHEN P.PRD_TV_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionTaxCode] = P.PRD_TV_TAX_CODE,
		[TelevisionBillingSetupComplete] = CASE WHEN P.TV_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_T = 1 THEN 'Y' ELSE 'N' END,
		[TelevisionApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_T = 1 THEN 'Y' ELSE 'N' END,

		[MagazinePrePostBill] = CASE WHEN P.PRD_MAG_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[MagazineMarkup] = P.PRD_MAG_COMM,
		[MagazineRebate] = P.PRD_MAG_REBATE,
		[MagazineBillNet] = CASE WHEN P.PRD_MAG_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[MagazineCommissionOnly] = CASE WHEN P.PRD_MAG_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[MagazineDaysToBill] = P.PRD_MAG_DAYS,
		[MagazineBillSetting] = CASE P.PRD_MAG_BF_AF WHEN 2 THEN 'After Insertion Date'
													  WHEN 3 THEN 'Before Close Date'
													  ELSE 'Before Insertion Date' END,
		[MagazineVendorDiscounts] = CASE WHEN P.PRD_MAG_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[MagazineTaxCode] = P.PRD_MAG_TAX_CODE,
		[MagazineBillingSetupComplete] = CASE WHEN P.MAG_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_M = 1 THEN 'Y' ELSE 'N' END,
		[MagazineApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_M = 1 THEN 'Y' ELSE 'N' END,

		[NewspaperPrePostBill] = CASE WHEN P.PRD_NEWS_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[NewspaperMarkup] = P.PRD_NEWS_COMM,
		[NewspaperRebate] = P.PRD_NEWS_REBATE,
		[NewspaperBillNet] = CASE WHEN P.PRD_NEWS_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperCommissionOnly] = CASE WHEN P.PRD_NEWS_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperDaysToBill] = P.PRD_NEWS_DAYS,
		[NewspaperBillSetting] = CASE P.PRD_NEWS_BF_AF WHEN 2 THEN 'After Insertion Date'
													  WHEN 3 THEN 'Before Close Date'
													  ELSE 'Before Insertion Date' END,
		[NewspaperVendorDiscounts] = CASE WHEN P.PRD_NEWS_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperTaxCode] = P.PRD_NEWS_TAX_CODE,
		[NewspaperBillingSetupComplete] = CASE WHEN P.NEWS_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_N = 1 THEN 'Y' ELSE 'N' END,
		[NewspaperApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_N = 1 THEN 'Y' ELSE 'N' END,

		[InternetPrePostBill] = CASE WHEN P.PRD_MISC_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[InternetMarkup] = P.PRD_MISC_COMM,
		[InternetRebate] = P.PRD_MISC_REBATE,
		[InternetBillNet] = CASE WHEN P.PRD_MISC_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[InternetCommissionOnly] = CASE WHEN P.PRD_MISC_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[InternetDaysToBill] = P.PRD_MISC_DAYS,
		[InternetBillSetting] = CASE P.PRD_MISC_BF_AF WHEN 2 THEN 'After Run Date'
													  WHEN 3 THEN 'Before Close Date'
													  ELSE 'Before Run Date' END,
		[InternetVendorDiscounts] = CASE WHEN P.PRD_MISC_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[InternetTaxCode] = P.PRD_MISC_TAX_CODE,
		[InternetBillingSetupComplete] = CASE WHEN P.INET_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_I = 1 THEN 'Y' ELSE 'N' END,
		[InternetApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_I = 1 THEN 'Y' ELSE 'N' END,

		[OutOfHomePrePostBill] = CASE WHEN P.PRD_OTDR_PRE_POST = 2 THEN 'Post Bill' ELSE 'PreBill' END,
		[OutOfHomeMarkup] = P.PRD_OTDR_COMM,
		[OutOfHomeRebate] = P.PRD_OTDR_REBATE,
		[OutOfHomeBillNet] = CASE WHEN P.PRD_OTDR_BILL_NET = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeCommissionOnly] = CASE WHEN P.PRD_OTDR_COM_ONLY = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeDaysToBill] = P.PRD_OTDR_DAYS,
		[OutOfHomeBillSetting] = CASE P.PRD_OTDR_BF_AF WHEN 2 THEN 'After Post Date'
													  WHEN 3 THEN 'Before Close Date'
													  ELSE 'Before Post Date' END,
		[OutOfHomeVendorDiscounts] = CASE WHEN P.PRD_OTDR_VEN_DISC = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeTaxCode] = P.PRD_OTDR_TAX_CODE,
		[OutOfHomeBillingSetupComplete] = CASE WHEN P.OOH_SETUP_COMPLETE = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxUseFlags] = CASE WHEN P.USE_TAX_FLAGS_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxLineNet] = CASE WHEN P.TAXAPPLYLN_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxNetCharge] = CASE WHEN P.TAXAPPLYNC_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxAddlCharge] = CASE WHEN P.TAXAPPLYAI_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxCommission] = CASE WHEN P.TAXAPPLYC_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxRebate] = CASE WHEN P.TAXAPPLYR_O = 1 THEN 'Y' ELSE 'N' END,
		[OutOfHomeApplyTaxNetDiscount] = CASE WHEN P.TAXAPPLYND_O = 1 THEN 'Y' ELSE 'N' END,
		[ClientType1Code] = CP.CLIENT_TYPE1_ID,
		[ClientType1Description] = CT1.[DESCRIPTION],
		[ClientType2Code] = CP.CLIENT_TYPE2_ID,
		[ClientType2Description] = CT2.[DESCRIPTION],
		[ClientType3Code] = CP.CLIENT_TYPE3_ID,
		[ClientType3Description] = CT3.[DESCRIPTION]

	FROM
		dbo.PRODUCT P INNER JOIN
		dbo.DIVISION D ON P.DIV_CODE = D.DIV_CODE AND P.CL_CODE = D.CL_CODE INNER JOIN
		dbo.CLIENT C ON P.CL_CODE = C.CL_CODE INNER JOIN
		dbo.OFFICE O ON P.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN
		dbo.ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			 dbo.EMPLOYEE_CLOAK AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
		dbo.COMPANY_PROFILE CP ON CP.PRD_CODE = P.PRD_CODE AND CP.DIV_CODE = P.DIV_CODE AND CP.CL_CODE = P.CL_CODE LEFT OUTER JOIN
		dbo.CLIENT_TYPE1 CT1 ON CT1.CLIENT_TYPE1_ID = CP.CLIENT_TYPE1_ID LEFT OUTER JOIN
		dbo.CLIENT_TYPE2 CT2 ON CT2.CLIENT_TYPE2_ID = CP.CLIENT_TYPE2_ID LEFT OUTER JOIN
		dbo.CLIENT_TYPE3 CT3 ON CT3.CLIENT_TYPE3_ID = CP.CLIENT_TYPE3_ID
GO