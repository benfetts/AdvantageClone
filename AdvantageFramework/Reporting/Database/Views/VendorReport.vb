Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_VENDORS")>
    Public Class VendorReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            ActiveFlag
            StreetAddressLine1
            StreetAddressLine2
            StreetAddressLine3
            City
            County
            State
            ZipCode
            Country
            PhoneNumber
            PhoneNumberExtension
            FaxPhoneNumber
            FaxPhoneNumberExtension
            PayToCode
            PayToName
            PayToAddressLine1
            PayToAddressLine2
            PayToStreetAddressLine3
            PayToCity
            PayToCounty
            PayToState
            PayToZipCode
            PayToCountry
            PayToPhoneNumber
            PayToPhoneNumberExtension
            PayToFaxPhoneNumber
            PayToFaxPhoneNumberExtension
            Website
            FederalTaxID
            EmailAddress
            DefaultCategory
            PaymentManagerEmailAddress
            CurrencyCode
            OfficeCode
            DefaultAPAccount
            DefaultExpenseAccount
            VendorAccount
            SortName
            DefaultFunctionCode
            VendorTermCode
            OneCheckPerInvoice
            EmployeeVendor
            IsACH
            ACHType
            Vendor1099Flag
            UseAlternativeAddressFor1099
            Vendor1099StreetAddressLine1
            Vendor1099StreetAddressLine2
            Vendor1099StreetAddressLine3
            Vendor1099City
            Vendor1099County
            Vendor1099State
            Vendor1099ZipCode
            Vendor1099Country
            Vendor1099Category
            DefaultVendorRepresentativeCode1
            DefaultVendorRepresentativeCode2
            MarketCode
            Commission
            OveragePercent
            ColumnWidth
            Fold
            DefaultSalesTax
            VendorCodeCrossReference
            UseTaxFlags
            TaxLineNet
            TaxNetCharge
            TaxAdditionalCharge
            TaxCommission
            TaxRebate
            TaxNetDiscount
            DefaultUnits
            MaterialCloseDays
            SpaceCloseDays
            Rate
            Instructions
            CloseInfo
            MiscInfo
            PositionInfo
            MaterialNotes
            RateInfo
            UseFooter
            FooterComment
            SundayCirculation
            DailyCirculation
            PublishingFrequency
            Editions
            ShipToName
            ShipToAddress
            ShipToAddress2
            ShipToAddress3
            ShipToCity
            ShipToCounty
            ShipToState
            ShipToZip
            ShipToCountry
            ShipToPhone
            ShipToPhoneExt
            GeneralInfo
            AcceptedMedia
            EFileInfo
            PreferredMaterial
            FTPUserName
            FTPPassword
            FTPDirectory
            DefaultAdSize
            DefaultSizeType
            Cycles
            CoopFlag
            Issues
            PayToEmail
            POFormat
            DefaultVendorContactCode
            Notes
            AssociateWithOffice
            DefaultBankCode
            DefaultBankDescription
            VCCStatusCode
            VCCStatusDescription
            DefaultCorrespondenceMethod
            VCCAmount
            SendVCCWithMediaOrder
			LastPaymentDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <MaxLength(6)>
        <Column("Code", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
        <MaxLength(40)>
        <Column("Name", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
        <Column("ActiveFlag")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActiveFlag() As Nullable(Of Short)
        <MaxLength(40)>
        <Column("StreetAddressLine1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine1() As String
        <MaxLength(40)>
        <Column("StreetAddressLine2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine2() As String
        <MaxLength(30)>
        <Column("StreetAddressLine3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine3() As String
        <MaxLength(25)>
        <Column("City", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <MaxLength(20)>
        <Column("County", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <MaxLength(10)>
        <Column("State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <MaxLength(10)>
        <Column("ZipCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ZipCode() As String
        <MaxLength(20)>
        <Column("Country", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
        <MaxLength(13)>
        <Column("PhoneNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneNumber() As String
        <MaxLength(4)>
        <Column("PhoneNumberExtension", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneNumberExtension() As String
        <MaxLength(13)>
        <Column("FaxPhoneNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxPhoneNumber() As String
        <MaxLength(4)>
        <Column("FaxPhoneNumberExtension", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxPhoneNumberExtension() As String
        <MaxLength(6)>
        <Column("PayToCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCode() As String
        <MaxLength(40)>
        <Column("PayToName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToName() As String
        <MaxLength(40)>
        <Column("PayToAddressLine1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine1() As String
        <MaxLength(40)>
        <Column("PayToAddressLine2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine2() As String
        <MaxLength(30)>
        <Column("PayToStreetAddressLine3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToStreetAddressLine3() As String
        <MaxLength(25)>
        <Column("PayToCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCity() As String
        <MaxLength(20)>
        <Column("PayToCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCounty() As String
        <MaxLength(10)>
        <Column("PayToState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToState() As String
        <MaxLength(10)>
        <Column("PayToZipCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToZipCode() As String
        <MaxLength(20)>
        <Column("PayToCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCountry() As String
        <MaxLength(13)>
        <Column("PayToPhoneNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneNumber() As String
        <MaxLength(4)>
        <Column("PayToPhoneNumberExtension", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneNumberExtension() As String
        <MaxLength(13)>
        <Column("PayToFaxPhoneNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFaxPhoneNumber() As String
        <MaxLength(4)>
        <Column("PayToFaxPhoneNumberExtension", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFaxPhoneNumberExtension() As String
        <MaxLength(250)>
        <Column("Website", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Website() As String
        <MaxLength(20)>
        <Column("FederalTaxID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FederalTaxID() As String
        <MaxLength(50)>
        <Column("EmailAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailAddress() As String
        <MaxLength(1)>
        <Column("DefaultCategory", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCategory() As String
        <MaxLength(50)>
        <Column("PaymentManagerEmailAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerEmailAddress() As String
        <MaxLength(5)>
        <Column("CurrencyCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("DefaultAPAccount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAPAccount() As String
        <MaxLength(30)>
        <Column("DefaultExpenseAccount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultExpenseAccount() As String
        <MaxLength(30)>
        <Column("VendorAccount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAccount() As String
        <MaxLength(20)>
        <Column("SortName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <MaxLength(6)>
        <Column("DefaultFunctionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultFunctionCode() As String
        <MaxLength(3)>
        <Column("VendorTermCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTermCode() As String
        <Required>
        <MaxLength(1)>
        <Column("OneCheckPerInvoice", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OneCheckPerInvoice() As String
        <Required>
        <MaxLength(1)>
        <Column("EmployeeVendor", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeVendor() As String
        <Required>
        <MaxLength(1)>
        <Column("IsACH", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsACH() As String
        <MaxLength(3)>
        <Column("ACHType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ACHType() As String
        <Required>
        <MaxLength(1)>
        <Column("Vendor1099Flag", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Flag() As String
        <Required>
        <MaxLength(1)>
        <Column("UseAlternativeAddressFor1099", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseAlternativeAddressFor1099() As String
        <MaxLength(40)>
        <Column("Vendor1099StreetAddressLine1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine1() As String
        <MaxLength(40)>
        <Column("Vendor1099StreetAddressLine2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine2() As String
        <MaxLength(30)>
        <Column("Vendor1099StreetAddressLine3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine3() As String
        <MaxLength(25)>
        <Column("Vendor1099City", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099City() As String
        <MaxLength(20)>
        <Column("Vendor1099County", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099County() As String
        <MaxLength(10)>
        <Column("Vendor1099State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099State() As String
        <MaxLength(10)>
        <Column("Vendor1099ZipCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099ZipCode() As String
        <MaxLength(20)>
        <Column("Vendor1099Country", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Country() As String
        <MaxLength(26)>
        <Column("Vendor1099Category", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Category() As String
        <MaxLength(4)>
        <Column("DefaultVendorRepresentativeCode1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultVendorRepresentativeCode1() As String
        <MaxLength(4)>
        <Column("DefaultVendorRepresentativeCode2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultVendorRepresentativeCode2() As String
        <MaxLength(10)>
        <Column("MarketCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <Column("Commission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Commission() As Nullable(Of Decimal)
        <Column("OveragePercent")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OveragePercent() As Nullable(Of Decimal)
        <Column("ColumnWidth")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColumnWidth() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("Fold", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fold() As String
        <MaxLength(4)>
        <Column("DefaultSalesTax", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultSalesTax() As String
        <MaxLength(12)>
        <Column("VendorCodeCrossReference", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCodeCrossReference() As String
        <Required>
        <MaxLength(1)>
        <Column("UseTaxFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseTaxFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxAdditionalCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxAdditionalCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxNetDiscount() As String
        <MaxLength(7)>
        <Column("DefaultUnits", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultUnits() As String
        <Column("MaterialCloseDays")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MaterialCloseDays() As Nullable(Of Short)
        <Column("SpaceCloseDays")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SpaceCloseDays() As Nullable(Of Short)
        <Required>
        <MaxLength(5)>
        <Column("Rate", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Rate() As String
		<Column("Instructions")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Instructions() As String
		<Column("CloseInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseInfo() As String
		<Column("MiscInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiscInfo() As String
		<Column("PositionInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PositionInfo() As String
		<Column("MaterialNotes")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialNotes() As String
		<Column("RateInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateInfo() As String
		<Required>
		<MaxLength(1)>
		<Column("UseFooter", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseFooter() As String
		<Column("FooterComment")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FooterComment() As String
		<Column("SundayCirculation")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SundayCirculation() As Nullable(Of Integer)
		<Column("DailyCirculation")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DailyCirculation() As Nullable(Of Integer)
		<MaxLength(250)>
		<Column("PublishingFrequency", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PublishingFrequency() As String
		<Column("Editions")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Editions() As String
		<MaxLength(40)>
		<Column("ShipToName", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToName() As String
		<MaxLength(40)>
		<Column("ShipToAddress", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToAddress() As String
		<MaxLength(40)>
		<Column("ShipToAddress2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToAddress2() As String
		<MaxLength(40)>
		<Column("ShipToAddress3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToAddress3() As String
		<MaxLength(25)>
		<Column("ShipToCity", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToCity() As String
		<MaxLength(20)>
		<Column("ShipToCounty", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToCounty() As String
		<MaxLength(10)>
		<Column("ShipToState", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToState() As String
		<MaxLength(10)>
		<Column("ShipToZip", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToZip() As String
		<MaxLength(20)>
		<Column("ShipToCountry", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToCountry() As String
		<MaxLength(13)>
		<Column("ShipToPhone", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToPhone() As String
		<MaxLength(4)>
		<Column("ShipToPhoneExt", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShipToPhoneExt() As String
		<Column("GeneralInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralInfo() As String
		<MaxLength(250)>
		<Column("AcceptedMedia", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AcceptedMedia() As String
		<MaxLength(250)>
		<Column("EFileInfo", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EFileInfo() As String
		<MaxLength(250)>
		<Column("PreferredMaterial", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PreferredMaterial() As String
		<MaxLength(100)>
		<Column("FTPUserName", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPUserName() As String
		<MaxLength(100)>
		<Column("FTPPassword", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPPassword() As String
		<MaxLength(100)>
		<Column("FTPDirectory", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPDirectory() As String
		<MaxLength(10)>
		<Column("DefaultAdSize", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultAdSize() As String
		<MaxLength(1)>
		<Column("DefaultSizeType", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultSizeType() As String
		<MaxLength(3)>
		<Column("Cycles", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Cycles() As String
		<Column("CoopFlag")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CoopFlag() As Nullable(Of Short)
		<Column("Issues")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Issues() As Nullable(Of Integer)
		<MaxLength(50)>
		<Column("PayToEmail", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToEmail() As String
		<MaxLength(4)>
		<Column("POFormat", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POFormat() As String
		<MaxLength(4)>
		<Column("DefaultVendorContactCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultVendorContactCode() As String
		<Column("Notes")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String
        <Column("AssociateWithOffice")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssociateWithOffice() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("DefaultBankCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultBankCode() As String
        <MaxLength(30)>
        <Column("DefaultBankDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultBankDescription() As String
        <Column("VCCStatusCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCStatusCode() As Nullable(Of Short)
        <Required>
        <MaxLength(8)>
        <Column("VCCStatusDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCStatusDescription() As String
        <Required>
        <MaxLength(5)>
        <Column("DefaultCorrespondenceMethod", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCorrespondenceMethod() As String
        <Column("VCCAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="VCC Limit")>
        Public Property VCCAmount() As Nullable(Of Decimal)
        <Required>
        <Column("SendVCCWithMediaOrder")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SendVCCWithMediaOrder() As Boolean
		<Column("LastPaymentDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastPaymentDate() As Nullable(Of Date)


#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
