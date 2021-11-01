CREATE VIEW [dbo].[V_DRPT_VENDORS]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[Code] = V.VN_CODE,
		[Name] = V.VN_NAME,
		[ActiveFlag] = V.VN_ACTIVE_FLAG,
		[StreetAddressLine1] = V.VN_ADDRESS1,
		[StreetAddressLine2] = V.VN_ADDRESS2,
		[StreetAddressLine3] = V.VN_ADDRESS3,
		[City] = V.VN_CITY,
		[County] = V.VN_COUNTY,
		[State] = V.VN_STATE,
		[ZipCode] = V.VN_ZIP,
		[Country] = V.VN_COUNTRY,
		[PhoneNumber] = V.VN_PHONE,
		[PhoneNumberExtension] = V.VN_PHONE_EXT,
		[FaxPhoneNumber] = V.VN_FAX_NUMBER,
		[FaxPhoneNumberExtension] = V.VN_FAX_EXTENTION,
		[PayToCode] = V.VN_PAY_TO_CODE,
		[PayToName] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_NAME ELSE PTV.VN_NAME END,
		[PayToAddressLine1] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS1 ELSE PTV.VN_ADDRESS1 END,
		[PayToAddressLine2] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS2 ELSE PTV.VN_ADDRESS2 END,
		[PayToStreetAddressLine3] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS3 ELSE PTV.VN_ADDRESS3 END,
		[PayToCity] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_CITY ELSE PTV.VN_CITY END,
		[PayToCounty] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_COUNTY ELSE PTV.VN_COUNTY END,
		[PayToState] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_STATE ELSE PTV.VN_STATE END,
		[PayToZipCode] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ZIP ELSE PTV.VN_ZIP END,
		[PayToCountry] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_COUNTRY ELSE PTV.VN_COUNTRY END,
		[PayToPhoneNumber] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_PHONE ELSE PTV.VN_PHONE END,
		[PayToPhoneNumberExtension] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_EXT ELSE PTV.VN_PHONE_EXT END,
		[PayToFaxPhoneNumber] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_FAX_NBR ELSE PTV.VN_FAX_NUMBER END,
		[PayToFaxPhoneNumberExtension] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_FAX_EXT ELSE PTV.VN_FAX_EXTENTION END,
		[Website] = V.WEB_ADDR,
		[FederalTaxID] = V.VN_TAX_ID,
		[EmailAddress] = V.VN_EMAIL,
		[DefaultCategory] = V.VN_CATEGORY,
		[PaymentManagerEmailAddress] = V.PYMT_MGR_EMAIL,
		[CurrencyCode] = V.CURRENCY_CODE,
		[OfficeCode] = V.OFFICE_CODE,
		[DefaultAPAccount] = V.GLACODE_AP,
		[DefaultExpenseAccount] = V.GLACODE_EXP,
		[VendorAccount] = V.VN_ACCT_NBR,
		[SortName] = V.VN_ALPHA_SORT,
		[DefaultFunctionCode] = V.DEF_FNC_CODE,
		[VendorTermCode] = V.VT_CODE,
		[OneCheckPerInvoice] = CASE WHEN V.ONE_CHECK_PER_INV = 1 THEN 'Y' ELSE 'N' END,
		[EmployeeVendor] = CASE WHEN V.EMP_VENDOR = 1 THEN 'Y' ELSE 'N' END,
		[IsACH] = CASE WHEN V.ACH = 1 THEN 'Y' ELSE 'N' END,
		[ACHType] = V.ACH_TYPE,
		[Vendor1099Flag] = CASE WHEN V.VN_1099_FLAG = 1 THEN 'Y' ELSE 'N' END,
		[UseAlternativeAddressFor1099] = CASE WHEN V.VN_USE_1099 = 1 THEN 'Y' ELSE 'N' END,
		[Vendor1099StreetAddressLine1] = V.VN_1099_ADDRESS1,
		[Vendor1099StreetAddressLine2] = V.VN_1099_ADDRESS2,
		[Vendor1099StreetAddressLine3] = V.VN_1099_ADDRESS3,
		[Vendor1099City] = V.VN_1099_CITY,
		[Vendor1099County] = V.VN_1099_COUNTY,
		[Vendor1099State] = V.VN_1099_STATE,
		[Vendor1099ZipCode] = V.VN_1099_ZIP,
		[Vendor1099Country] = V.VN_1099_COUNTRY,
		[Vendor1099Category] = CASE V.VN_1099_INC_TYPE WHEN 0 THEN 'Non Employee Compensation'
													   WHEN 1 THEN 'Other Income'
													   WHEN 2 THEN 'Rent'
													   WHEN 3 THEN 'Royalties'
													   WHEN 4 THEN 'Gross Proceeds to Attorney'
													   WHEN 5 THEN 'Medical and Health Care' END,
		[DefaultVendorRepresentativeCode1] = V.DEF_VN_REP1,
		[DefaultVendorRepresentativeCode2] = V.DEF_VN_REP2,
		[MarketCode] = V.MARKET_CODE,
		[Commission] = V.VN_COMM,
		[OveragePercent] = V.OVERAGE_PCT,
		[ColumnWidth] = V.COLUMN_SIZE,
		[Fold] = CASE WHEN V.FOLD = 1 THEN 'Y' ELSE 'N' END,
		[DefaultSalesTax] = V.DEF_SALES_TAX,
		[VendorCodeCrossReference] = V.VN_CODE_XREF,
		[UseTaxFlags] = CASE WHEN V.USE_TAX_FLAGS = 1 THEN 'Y' ELSE 'N' END,
		[TaxLineNet] = CASE WHEN V.TAXAPPLYLN = 1 THEN 'Y' ELSE 'N' END,
		[TaxNetCharge] = CASE WHEN V.TAXAPPLYNC = 1 THEN 'Y' ELSE 'N' END,
		[TaxAdditionalCharge] = CASE WHEN V.TAXAPPLYAI = 1 THEN 'Y' ELSE 'N' END,
		[TaxCommission] = CASE WHEN V.TAXAPPLYC = 1 THEN 'Y' ELSE 'N' END,
		[TaxRebate] = CASE WHEN V.TAXAPPLYR = 1 THEN 'Y' ELSE 'N' END,
		[TaxNetDiscount] = CASE WHEN V.TAXAPPLYND = 1 THEN 'Y' ELSE 'N' END,
		[DefaultUnits] = CASE V.DEF_UNITS WHEN 'M' THEN 'Monthly'
										  WHEN 'W' THEN 'Weekly'
										  WHEN 'DB' THEN 'Daily' END,
		[MaterialCloseDays] = V.MATL_CLOSE,
		[SpaceCloseDays] = V.SPACE_CLOSE,
		[Rate] = CASE WHEN V.DEF_NET_GROSS = 1 THEN 'Gross' ELSE 'Net' END,
		[Instructions] = VC.INSTRUCTIONS,
		[CloseInfo] = VC.CLOSE_INFO,
		[MiscInfo] = VC.MISC_INFO,
		[PositionInfo] = VC.POSITION_INFO,
		[MaterialNotes] = VC.MATL_NOTES,
		[RateInfo] = VC.RATE_INFO,
		[UseFooter] = CASE WHEN VC.USE_FOOTER = 1 THEN 'Y' ELSE 'N' END,
		[FooterComment] = VC.FOOTER_INFO,
		[SundayCirculation] = V.SUNDAY_CIRC,
		[DailyCirculation] = V.DAILY_CIRC,
		[PublishingFrequency] = V.PUB_FREQ,
		[Editions] = V.EDITIONS,
		[ShipToName] = V.SHIP_NAME,
		[ShipToAddress] = V.SHIP_ADDR1,
		[ShipToAddress2] = V.SHIP_ADDR2,
		[ShipToAddress3] = V.SHIP_ADDR3,
		[ShipToCity] = V.SHIP_CITY,
		[ShipToCounty] = V.SHIP_COUNTY,
		[ShipToState] = V.SHIP_STATE,
		[ShipToZip] = V.SHIP_ZIP,
		[ShipToCountry] = V.SHIP_COUNTRY,
		[ShipToPhone] = V.SHIP_PHONE,
		[ShipToPhoneExt] = V.SHIP_PHONE_EXT,
		[GeneralInfo] = VC.DLVRY_GEN_INFO,
		[AcceptedMedia] = VC.ACCEPTED_MEDIA,
		[EFileInfo] = VC.EFILE_INFO,
		[PreferredMaterial] = VC.PREF_MATL,
		[FTPUserName] = VC.FTP_USER,
		[FTPPassword] = VC.FTP_PW,
		[FTPDirectory] = VC.FTP_DIR,
		[DefaultAdSize] = V.DEF_SIZE,
		[DefaultSizeType] = V.DEF_SIZE_TYPE,
		[Cycles] = V.CYCLE,
		[CoopFlag] = V.COOP_FLAG,
		[Issues] = V.ISSUES,
		[PayToEmail] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_EMAIL ELSE PTV.VN_EMAIL END,
		[POFormat] = V.PO_FORMAT,
		[DefaultVendorContactCode] = V.DEF_VN_CONT,
		[Notes] = V.VN_NOTES,
		[AssociateWithOffice] = V.ASSOC_OFFICE,
		[DefaultBankCode] = V.BK_CODE,
		[DefaultBankDescription] = B.BK_DESCRIPTION,
		[VCCStatusCode] = V.VCC_STATUS,
		[VCCStatusDescription] = CASE WHEN V.VCC_STATUS IS NULL THEN 'Open'
									  WHEN V.VCC_STATUS = 1 THEN 'Accepted'
									  WHEN V.VCC_STATUS = 2 THEN 'Declined' ELSE 'Open' END,
		[DefaultCorrespondenceMethod] = CASE WHEN V.DEF_CORRESPONDENCE_METHOD = 1 THEN 'Email'
											 WHEN V.DEF_CORRESPONDENCE_METHOD = 2 THEN 'Print' ELSE '' END,
		[VCCAmount] = V.VCC_AMOUNT,
		[SendVCCWithMediaOrder] = V.SEND_VCC_WITH_MEDIA_ORDER,
		[LastPaymentDate] = VNLPD.LAST_PAYMENT_DATE
	FROM
		dbo.VENDOR V LEFT OUTER JOIN
		dbo.VENDOR_COMMENTS VC ON VC.VN_CODE = V.VN_CODE LEFT OUTER JOIN
		dbo.BANK B ON V.BK_CODE = B.BK_CODE LEFT OUTER JOIN
		dbo.VENDOR PTV ON PTV.VN_CODE = V.VN_PAY_TO_CODE LEFT OUTER JOIN
		(SELECT 
				[LAST_PAYMENT_DATE] = MAX(CHECK_DATE), 
				[VN_CODE] = PAY_TO_CODE 
			FROM 
				dbo.CHECK_REGISTER
			GROUP BY
				PAY_TO_CODE) AS VNLPD ON VNLPD.VN_CODE = V.VN_CODE


GO