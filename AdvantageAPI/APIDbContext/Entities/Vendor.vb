<Table("VENDOR")>
Public Class Vendor

#Region " Constants "



#End Region

#Region " Enum "
    '


#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
	<Required>
	<MaxLength(6)>
	<Column("VN_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(40)>
	<Column("VN_NAME", TypeName:="varchar")>
	Public Property Name() As String
	<MaxLength(40)>
	<Column("VN_ADDRESS1", TypeName:="varchar")>
	Public Property StreetAddressLine1() As String
	<MaxLength(40)>
	<Column("VN_ADDRESS2", TypeName:="varchar")>
	Public Property StreetAddressLine2() As String
	<MaxLength(30)>
	<Column("VN_ADDRESS3", TypeName:="varchar")>
	Public Property StreetAddressLine3() As String
	<MaxLength(25)>
	<Column("VN_CITY", TypeName:="varchar")>
	Public Property City() As String
	<MaxLength(20)>
	<Column("VN_COUNTY", TypeName:="varchar")>
	Public Property County() As String
	<MaxLength(10)>
	<Column("VN_STATE", TypeName:="varchar")>
	Public Property State() As String
	<MaxLength(20)>
	<Column("VN_COUNTRY", TypeName:="varchar")>
	Public Property Country() As String
	<MaxLength(10)>
	<Column("VN_ZIP", TypeName:="varchar")>
	Public Property ZipCode() As String
	<MaxLength(13)>
	<Column("VN_PHONE", TypeName:="varchar")>
	Public Property PhoneNumber() As String
	<MaxLength(4)>
	<Column("VN_PHONE_EXT", TypeName:="varchar")>
	Public Property PhoneNumberExtension() As String
	<MaxLength(13)>
	<Column("VN_FAX_NUMBER", TypeName:="varchar")>
	Public Property FaxPhoneNumber() As String
	<MaxLength(4)>
	<Column("VN_FAX_EXTENTION", TypeName:="varchar")>
	Public Property FaxPhoneNumberExtension() As String
	<MaxLength(6)>
	<Column("VN_PAY_TO_CODE", TypeName:="varchar")>
	Public Property PayToCode() As String
	<MaxLength(40)>
	<Column("VN_PAY_TO_NAME", TypeName:="varchar")>
	Public Property PayToName() As String
	<MaxLength(40)>
	<Column("VN_PAY_TO_ADDRESS1", TypeName:="varchar")>
	Public Property PayToAddressLine1() As String
	<MaxLength(40)>
	<Column("VN_PAY_TO_ADDRESS2", TypeName:="varchar")>
	Public Property PayToAddressLine2() As String
	<MaxLength(30)>
	<Column("VN_PAY_TO_ADDRESS3", TypeName:="varchar")>
	Public Property PayToStreetAddressLine3() As String
	<MaxLength(25)>
	<Column("VN_PAY_TO_CITY", TypeName:="varchar")>
	Public Property PayToCity() As String
	<MaxLength(20)>
	<Column("VN_PAY_TO_COUNTY", TypeName:="varchar")>
	Public Property PayToCounty() As String
	<MaxLength(10)>
	<Column("VN_PAY_TO_STATE", TypeName:="varchar")>
	Public Property PayToState() As String
	<MaxLength(20)>
	<Column("VN_PAY_TO_COUNTRY", TypeName:="varchar")>
	Public Property PayToCountry() As String
	<MaxLength(10)>
	<Column("VN_PAY_TO_ZIP", TypeName:="varchar")>
	Public Property PayToZipCode() As String
	<MaxLength(13)>
	<Column("VN_PAY_TO_PHONE", TypeName:="varchar")>
	Public Property PayToPhoneNumber() As String
	<MaxLength(4)>
	<Column("VN_PAY_TO_EXT", TypeName:="varchar")>
	Public Property PayToPhoneNumberExtension() As String
	<MaxLength(13)>
	<Column("VN_PAY_TO_FAX_NBR", TypeName:="varchar")>
	Public Property PayToFaxPhoneNumber() As String
	<MaxLength(4)>
	<Column("VN_PAY_TO_FAX_EXT", TypeName:="varchar")>
	Public Property PayToFaxPhoneNumberExtension() As String
	<MaxLength(20)>
	<Column("VN_TAX_ID", TypeName:="varchar")>
	Public Property TaxID() As String
	<MaxLength(30)>
	<Column("VN_ACCT_NBR", TypeName:="varchar")>
	Public Property AccountNumber() As String
	<MaxLength(50)>
	<Column("VN_EMAIL", TypeName:="varchar")>
	Public Property EmailAddress() As String
	<MaxLength(50)>
	<Column("PYMT_MGR_EMAIL", TypeName:="varchar")>
	Public Property PaymentManagerEmailAddress() As String
	<Column("VN_ACTIVE_FLAG")>
	Public Property ActiveFlag() As Nullable(Of Short)
	<MaxLength(4)>
	<Column("DEF_VN_CONT", TypeName:="varchar")>
	Public Property DefaultVendorContactCode() As String
	<MaxLength(4)>
	<Column("DEF_VN_REP1", TypeName:="varchar")>
	Public Property DefaultVendorRepresentativeCode1() As String
	<MaxLength(4)>
	<Column("DEF_VN_REP2", TypeName:="varchar")>
	Public Property DefaultVendorRepresentativeCode2() As String
	<MaxLength(250)>
	<Column("WEB_ADDR", TypeName:="varchar")>
	Public Property Website() As String
	<Column("VCC_STATUS")>
	Public Property VCCStatus() As Nullable(Of Short)
	<MaxLength(4)>
	<Column("BK_CODE", TypeName:="varchar")>
	Public Property BankCode() As String
	<MaxLength(1)>
	<Column("VN_CATEGORY", TypeName:="varchar")>
	Public Property VendorCategory() As String
	<MaxLength(3)>
	<Column("VT_CODE", TypeName:="varchar")>
	Public Property VendorTermCode() As String
	<Column("HAS_SPECIAL_TERMS")>
	Public Property HasSpecialTerms() As Nullable(Of Boolean)

#End Region

#Region " Methods "



#End Region

End Class
