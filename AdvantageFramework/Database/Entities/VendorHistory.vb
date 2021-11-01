Namespace Database.Entities

	<Table("VENDOR_HISTORY")>
	Public Class VendorHistory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Action
			DateTime
			[Date]
			User
			VendorCategory
			ActiveFlag
			Code
			Name
			Address1
			Address2
			Address3
			City
			County
			State
			Country
			Zip
			Phone
			PhoneExt
			Fax
			FaxExt
			Email
			PayToCode
			PayToName
			PayToAddress1
			PayToAddress2
			PayToAddress3
			PayToCity
			PayToCounty
			PayToState
			PayToCountry
			PayToZip
			PayToPhone
			PayToPhoneExt
			PayToFax
			PayToFaxExt
			PayToEmail
			Vendor1099Address1
			Vendor1099Address2
			Vendor1099Address3
			Vendor1099City
			Vendor1099County
			Vendor1099State
			Vendor1099Country
			Vendor1099Zip
			Vendor1099Flag
			Vendor1099UseAddress
			Vendor1099Category
			DefaultTermCode
			TaxID
			SortName
			DefaultAPAccount
			DefaultExpenseAccount
			AccountNumber
			OfficeCode
			DefaultFunctionCode
			EmployeeVendor
			DefaultVendorContact
			OneCheckPerInvoice
			WebSite
			MergeNewCode
			CurrencyCode
			PaymentManagerEmail
			Currency

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("HIST_REC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(10)>
		<Column("HIST_ACTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Action() As String
		<Required>
		<MaxLength(25)>
		<Column("HIST_DATETIME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateTime() As String
		<Required>
		<Column("HIST_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property [Date]() As Date
		<Required>
		<MaxLength(100)>
		<Column("HIST_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property User() As String
		<MaxLength(1)>
		<Column("VN_CATEGORY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCategory() As String
		<Column("VN_ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ActiveFlag() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("VN_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("VN_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address1() As String
		<MaxLength(40)>
		<Column("VN_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("VN_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address3() As String
		<MaxLength(25)>
		<Column("VN_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("VN_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("VN_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("VN_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("VN_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(13)>
		<Column("VN_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Phone() As String
		<MaxLength(4)>
		<Column("VN_PHONE_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PhoneExt() As String
		<MaxLength(13)>
		<Column("VN_FAX_NUMBER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax() As String
		<MaxLength(4)>
		<Column("VN_FAX_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxExt() As String
		<MaxLength(50)>
		<Column("VN_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Email() As String
		<MaxLength(6)>
		<Column("VN_PAY_TO_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToCode() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToName() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToAddress1() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToAddress2() As String
		<MaxLength(30)>
		<Column("VN_PAY_TO_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToAddress3() As String
		<MaxLength(25)>
		<Column("VN_PAY_TO_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToCity() As String
		<MaxLength(20)>
		<Column("VN_PAY_TO_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToCounty() As String
		<MaxLength(10)>
		<Column("VN_PAY_TO_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToState() As String
		<MaxLength(20)>
		<Column("VN_PAY_TO_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToCountry() As String
		<MaxLength(10)>
		<Column("VN_PAY_TO_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToZip() As String
		<MaxLength(13)>
		<Column("VN_PAY_TO_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToPhone() As String
		<MaxLength(4)>
		<Column("VN_PAY_TO_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToPhoneExt() As String
		<MaxLength(13)>
		<Column("VN_PAY_TO_FAX_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToFax() As String
		<MaxLength(4)>
		<Column("VN_PAY_TO_FAX_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToFaxExt() As String
		<MaxLength(50)>
		<Column("VN_PAY_TO_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToEmail() As String
		<MaxLength(40)>
		<Column("VN_1099_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Address1() As String
		<MaxLength(40)>
		<Column("VN_1099_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Address2() As String
		<MaxLength(30)>
		<Column("VN_1099_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Address3() As String
		<MaxLength(25)>
		<Column("VN_1099_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099City() As String
		<MaxLength(20)>
		<Column("VN_1099_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099County() As String
		<MaxLength(10)>
		<Column("VN_1099_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099State() As String
		<MaxLength(20)>
		<Column("VN_1099_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Country() As String
		<MaxLength(10)>
		<Column("VN_1099_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Zip() As String
		<Column("VN_1099_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Flag() As Nullable(Of Short)
		<Column("VN_USE_1099")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099UseAddress() As Nullable(Of Short)
		<Column("VN_1099_INC_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Vendor1099Category() As Nullable(Of Short)
		<MaxLength(3)>
		<Column("VT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultTermCode() As String
		<MaxLength(20)>
		<Column("VN_TAX_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxID() As String
		<MaxLength(20)>
		<Column("VN_ALPHA_SORT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortName() As String
		<MaxLength(30)>
		<Column("GLACODE_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultAPAccount() As String
		<MaxLength(30)>
		<Column("GLACODE_EXP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultExpenseAccount() As String
		<MaxLength(30)>
		<Column("VN_ACCT_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumber() As String
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<MaxLength(6)>
		<Column("DEF_FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultFunctionCode() As String
		<Column("EMP_VENDOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeVendor() As Nullable(Of Integer)
		<MaxLength(4)>
		<Column("DEF_VN_CONT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultVendorContact() As String
		<Column("ONE_CHECK_PER_INV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OneCheckPerInvoice() As Nullable(Of Short)
		<MaxLength(250)>
		<Column("WEB_ADDR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebSite() As String
		<MaxLength(15)>
		<Column("MERGE_NEW_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MergeNewCode() As String
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyCode() As String
		<MaxLength(50)>
		<Column("PYMT_MGR_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerEmail() As String

        Public Overridable Property Currency As Database.Entities.Currency

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
