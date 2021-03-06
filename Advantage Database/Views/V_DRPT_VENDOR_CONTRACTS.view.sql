CREATE VIEW [dbo].[V_DRPT_VENDOR_CONTRACTS]
WITH SCHEMABINDING 
AS

	SELECT
		[ID] = NEWID(),
		[VendorCode] = V.VN_CODE,
		[VendorName] = V.VN_NAME,
		[StreetAddressLine1] = V.VN_ADDRESS1,
		[StreetAddressLine2] = V.VN_ADDRESS2,
		[StreetAddressLine3] = V.VN_ADDRESS3,
		[City] = V.VN_CITY,
		[County] = V.VN_COUNTY,
		[State] = V.VN_STATE,
		[ZipCode] = V.VN_ZIP,
		[Country] = V.VN_COUNTRY,
		[Phone] = V.VN_PHONE,
		[PhoneExt] = V.VN_PHONE_EXT,
		[Fax] = V.VN_FAX_NUMBER,
		[FaxExt] = V.VN_FAX_EXTENTION,
		[PayToCode] = V.VN_PAY_TO_CODE,
		[PayToName] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_NAME ELSE P2V.VN_NAME END,
		[PayToAddressLine1] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS1 ELSE P2V.VN_ADDRESS1 END,
		[PayToAddressLine2] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS2 ELSE P2V.VN_ADDRESS2 END,
		[PayToAddressLine3] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ADDRESS3 ELSE P2V.VN_ADDRESS3 END,
		[PayToCity] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_CITY ELSE P2V.VN_CITY END,
		[PayToCounty] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_COUNTY ELSE P2V.VN_COUNTY END,
		[PayToState] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_STATE ELSE P2V.VN_STATE END,
		[PayToZipCode] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_ZIP ELSE P2V.VN_ZIP END,
		[PayToCountry] = CASE WHEN V.VN_CODE = V.VN_PAY_TO_CODE THEN V.VN_PAY_TO_COUNTRY ELSE P2V.VN_COUNTRY END,
		[PayToPhoneNumber] = V.VN_PAY_TO_PHONE,
		[PayToPhoneExt] = V.VN_PAY_TO_EXT,
		[PayToFax] = V.VN_PAY_TO_FAX_NBR,
		[PayToFaxExt] = V.VN_PAY_TO_FAX_EXT,
		[Website] = V.WEB_ADDR,
		[EmailAddress] = V.VN_EMAIL,
		[PaymentManagerEmail] = V.PYMT_MGR_EMAIL,
		[EmployeeVendorFlag] = CASE WHEN ISNULL(V.EMP_VENDOR, 0) = 1 THEN 'Y' ELSE 'N' END,
		[FederalTaxID] = V.VN_TAX_ID,
		[DefaultCategory] = V.VN_CATEGORY,
		[AccountNumber] = V.VN_ACCT_NBR,
		[OfficeCode] = V.OFFICE_CODE,
		[DefaultAPAccount] = V.GLACODE_AP,
		[DefaultExpenseAccount] = V.GLACODE_EXP,
		[CurrencyCode] = V.CURRENCY_CODE,
		[SortName] = V.VN_ALPHA_SORT,
		[DefaultFunctionCode] = V.DEF_FNC_CODE,
		[VendorTermCode] = V.VT_CODE,
		[OneCheckPerInvoice] = V.ONE_CHECK_PER_INV,
		[IsACH] = CASE WHEN ISNULL(V.ACH, 0) = 1 THEN 'Y' ELSE 'N' END,
		[ACHType] = V.ACH_TYPE,
		[VCCStatusCode] = V.VCC_STATUS,
		[VCCStatusDescription] = CASE WHEN V.VCC_STATUS = 1 THEN 'Accepted' WHEN V.VCC_STATUS = 2 THEN 'Declined' END,
		[DefaultCorrespondenceMethod] = V.DEF_CORRESPONDENCE_METHOD,
		[VCCLimit] = V.VCC_AMOUNT,
		[SendVCCWithMediaOrder] = CASE WHEN V.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Y' ELSE 'N' END,
		[Is1099] = CASE WHEN ISNULL(V.VN_1099_FLAG, 0) = 1 THEN 'Y' ELSE 'N' END,
		[Vendor1099Address1] = V.VN_1099_ADDRESS1,
		[Vendor1099Address2] = V.VN_1099_ADDRESS2,
		[Vendor1099Address3] = V.VN_1099_ADDRESS3,
		[Vendor1099City] = V.VN_1099_CITY,
		[Vendor1099State] = V.VN_1099_STATE,
		[Vendor1099Zip] = V.VN_1099_ZIP,
		[Vendor1099County] = V.VN_1099_COUNTY,
		[Vendor1099Country] = V.VN_1099_COUNTRY,
		[Vendor1099UseAddress] = V.VN_USE_1099,
		[ContractCode] = VC.VENDOR_CONTRACT_CODE,
		[ContractDescription] = VC.[DESCRIPTION],
		[ContractStartDate] = VC.[START_DATE],
		[ContractEndDate] = VC.END_DATE,
		[ContractComments] = VC.COMMENTS,
		[RenewalAlertSentDate] = VC.RENEWAL_ALERT_SENT_DATE
	FROM
		dbo.VENDOR V
	INNER JOIN
		dbo.VENDOR_CONTRACT VC ON V.VN_CODE = VC.VN_CODE
	LEFT OUTER JOIN
		dbo.VENDOR P2V ON V.VN_PAY_TO_CODE = P2V.VN_CODE
	WHERE
		VC.INACTIVE_FLAG = 0 AND
		V.VN_ACTIVE_FLAG = 1

GO