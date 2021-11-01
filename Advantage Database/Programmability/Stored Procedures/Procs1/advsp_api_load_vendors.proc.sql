CREATE PROCEDURE [dbo].[advsp_api_load_vendors]
	@IncludeInactive BIT,
	@NonMedia BIT = 1,
	@Magazine BIT = 1,
	@Newspaper BIT = 1,
	@Radio BIT = 1,
	@Television BIT = 1,
	@OutOfHome BIT = 1,
	@Internet BIT = 1,
	@NonClient BIT = 1
AS
BEGIN
		
	SELECT
		[Code] = V.VN_CODE,
		[Name] = V.VN_NAME,
		[StreetAddressLine1] = V.VN_ADDRESS1,
		[StreetAddressLine2] = V.VN_ADDRESS2,
		[StreetAddressLine3] = V.VN_ADDRESS3,
		[City] = V.VN_CITY,
		[County] = V.VN_COUNTY,
		[State] = V.VN_STATE,
		[Country] = V.VN_COUNTRY,
		[ZipCode] = V.VN_ZIP,
		[PhoneNumber] = V.VN_PHONE,
		[PhoneNumberExtension] = V.VN_PHONE_EXT,
		[FaxPhoneNumber] = V.VN_FAX_NUMBER,
		[FaxPhoneNumberExtension] = V.VN_FAX_EXTENTION,
		[PayToCode] = V.VN_PAY_TO_CODE,
		[PayToName] = V.VN_PAY_TO_NAME,
		[PayToAddressLine1] = V.VN_PAY_TO_ADDRESS1,
		[PayToAddressLine2] = V.VN_PAY_TO_ADDRESS2,
		[PayToStreetAddressLine3] = V.VN_PAY_TO_ADDRESS3,
		[PayToCity] = V.VN_PAY_TO_CITY,
		[PayToCounty] = V.VN_PAY_TO_COUNTY,
		[PayToState] = V.VN_PAY_TO_STATE,
		[PayToCountry] = V.VN_PAY_TO_COUNTRY,
		[PayToZipCode] = V.VN_PAY_TO_ZIP,
		[PayToPhoneNumber] = V.VN_PAY_TO_PHONE,
		[PayToPhoneNumberExtension] = V.VN_PAY_TO_EXT,
		[PayToFaxPhoneNumber] = V.VN_PAY_TO_FAX_NBR,
		[PayToFaxPhoneNumberExtension] = V.VN_PAY_TO_FAX_EXT,
		[TaxID] = V.VN_TAX_ID,
		[AccountNumber] = V.VN_ACCT_NBR,
		[EmailAddress] = V.VN_EMAIL,
		[PaymentManagerEmailAddress] = V.PYMT_MGR_EMAIL,
		[ActiveFlag] = V.VN_ACTIVE_FLAG,
		[DefaultVendorContactCode] = V.DEF_VN_CONT,
		[DefaultVendorRepresentativeCode1] = V.DEF_VN_REP1,
		[DefaultVendorRepresentativeCode2] = V.DEF_VN_REP2,
		[Website] = V.WEB_ADDR,
		[VCCStatus] = V.VCC_STATUS,
		[BankCode] = V.BK_CODE,
		[VendorCategory] = V.VN_CATEGORY,
		[VendorTermCode] = V.VT_CODE,
		[HasSpecialTerms] = V.HAS_SPECIAL_TERMS
	FROM
		dbo.VENDOR V
	WHERE
		1 = CASE WHEN @IncludeInactive = 1 THEN 1 WHEN V.VN_ACTIVE_FLAG = 1 THEN 1 ELSE 0 END AND
		(
			(@Internet = 1 AND (V.VN_CATEGORY = 'I' OR V.IN_CATEGORY = 1)) OR
			(@Magazine = 1 AND (V.VN_CATEGORY = 'M' OR V.MG_CATEGORY = 1)) OR
			(@Newspaper = 1 AND (V.VN_CATEGORY = 'N' OR V.NP_CATEGORY = 1)) OR
			(@OutOfHome = 1 AND (V.VN_CATEGORY = 'O' OR V.OD_CATEGORY = 1)) OR
			(@Radio = 1 AND (V.VN_CATEGORY = 'R' OR V.RD_CATEGORY = 1)) OR
			(@Television = 1 AND (V.VN_CATEGORY = 'T' OR V.TV_CATEGORY = 1)) OR
			(@NonMedia = 1 AND V.VN_CATEGORY = 'P') OR
			(@NonClient = 1 AND V.VN_CATEGORY = 'Z')
		)

END