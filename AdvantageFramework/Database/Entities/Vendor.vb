Namespace Database.Entities

    <Table("VENDOR")>
    Public Class Vendor
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            StreetAddressLine1
            StreetAddressLine2
            StreetAddressLine3
            City
            County
            State
            Country
            ZipCode
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
            PayToCountry
            PayToZipCode
            PayToPhoneNumber
            PayToPhoneNumberExtension
            PayToFaxPhoneNumber
            PayToFaxPhoneNumberExtension
            VendorTermCode
            TaxID
            Vendor1099Flag
            VendorCategory
            DefaultAPAccount
            Notes
            DefaultExpenseAccount
            AssociateWithOffice
            OfficeCode
            Vendor1099StreetAddressLine1
            Vendor1099StreetAddressLine2
            Vendor1099StreetAddressLine3
            Vendor1099City
            Vendor1099State
            Vendor1099ZipCode
            Vendor1099County
            Vendor1099Country
            UseAlternativeAddressFor1099
            AccountNumber
            FunctionCode
            EmployeeVendor
            OneCheckPerInvoice
            EmailAddress
            PaymentManagerEmailAddress
            ActiveFlag
            DefaultVendorContactCode
            DefaultAdSize
            CurrencyCode
            DefaultVendorRepresentativeCode1
            DefaultVendorRepresentativeCode2
            MarketCode
            InternetCategory
            MagazineCategory
            NewspaperCategory
            OutOfHomeCategory
            RadioCategory
            TVCategory
            ProductionCategory
            SortName
            POFormat
            DefaultSalesTax
            Website
            PayToEmail
            ShipToName
            ShipToAddress
            ShipToAddress2
            ShipToAddress3
            ShipToCity
            ShipToCounty
            ShipToState
            ShipToCountry
            ShipToZip
            Vendor1099Category
            IsACH
            ACHType
            Commission
            ColumnSize
            OveragePercent
            Fold
            UseTaxFlags
            TaxCommission
            TaxLineNet
            TaxNetDiscount
            TaxNetCharge
            TaxRebate
            TaxAdditionalCharge
            VendorCodeCrossReference
            MaterialCloseDays
            SpaceCloseDays
            DailyCirculation
            SundayCirculation
            Editions
            PublishingFrequency
            Issues
            DefaultUnits
            DefaultNetGross
            CoopFlag
            Cycles
            DefaultSizeType
            ShipToPhone
            ShipToPhoneExt
            VCCStatus
            BankCode
            HasSpecialTerms
            ServiceTaxType
            ServiceTaxEnabled
            ServiceTaxWaiver
            ServiceTaxRate
            ServiceTaxWaiverExpirationDate
            VendorServiceTaxID
            DefaultCorrespondenceMethod
            VCCAmount
            SendVCCWithMediaOrder
            Markup
            VendorInvoiceCategoryID
            IsCableSystem
            NielsenTVStationCode
            NielsenRadioStationComboID
            NCCTVSyscodeID
            EastlanRadioStationComboID
            ComscoreTVStationID
            IsNielsenSubsciber
            IsComscoreSubsciber
            VATNumber
            CallLetters
            Band
            CanadianVendorType
            NPRStationID
            UseAlternativeNameFor1099
            Vendor1099Name
            IsComboRadioStation
            [Function]
            VendorTerm
            GeneralLedgerAccount
            StandardComments
            InternetOrders
            MagazineOrders
            NewspaperOrders
            OutOfHomeOrders
            RadioOrders
            TVOrders
            VendorContacts
            DefaultVendorContact
            AccountPayables
            MediaSpecsHeader
            Currency
            Associates
            VendorPricings
            RateCards
            Office
            Market
            VendorSortKeys
            PurchaseOrders
            VendorComment
            MediaPlanDetailLevelLineTags
            RadioOrderLegacies
            TVOrderLegacies
            MediaATBRevisionDetails
            DigitalResults
            VendorInvoiceCategory
            ComscoreTVStation
            VendorMarkets
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(40)>
        <Column("VN_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <MaxLength(40)>
        <Column("VN_ADDRESS1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine1() As String
        <MaxLength(40)>
        <Column("VN_ADDRESS2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine2() As String
        <MaxLength(30)>
        <Column("VN_ADDRESS3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine3() As String
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
        Public Property ZipCode() As String
        <MaxLength(13)>
        <Column("VN_PHONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneNumber() As String
        <MaxLength(4)>
        <Column("VN_PHONE_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneNumberExtension() As String
        <MaxLength(13)>
        <Column("VN_FAX_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxPhoneNumber() As String
        <MaxLength(4)>
        <Column("VN_FAX_EXTENTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxPhoneNumberExtension() As String
        <MaxLength(6)>
        <Column("VN_PAY_TO_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PayToCode() As String
        <MaxLength(40)>
        <Column("VN_PAY_TO_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToName() As String
        <MaxLength(40)>
        <Column("VN_PAY_TO_ADDRESS1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine1() As String
        <MaxLength(40)>
        <Column("VN_PAY_TO_ADDRESS2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine2() As String
        <MaxLength(30)>
        <Column("VN_PAY_TO_ADDRESS3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToStreetAddressLine3() As String
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
        Public Property PayToZipCode() As String
        <MaxLength(13)>
        <Column("VN_PAY_TO_PHONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneNumber() As String
        <MaxLength(4)>
        <Column("VN_PAY_TO_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneNumberExtension() As String
        <MaxLength(13)>
        <Column("VN_PAY_TO_FAX_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFaxPhoneNumber() As String
        <MaxLength(4)>
        <Column("VN_PAY_TO_FAX_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFaxPhoneNumberExtension() As String
        <MaxLength(3)>
        <Column("VT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorTermCode() As String
        <MaxLength(20)>
        <Column("VN_TAX_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxID() As String
        <Column("VN_1099_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Flag() As Nullable(Of Short)
        <MaxLength(1)>
        <Column("VN_CATEGORY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCategory() As String
        <MaxLength(30)>
        <Column("GLACODE_AP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DefaultAPAccount() As String
        <Column("VN_NOTES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String
        <MaxLength(30)>
        <Column("GLACODE_EXP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultExpenseAccount() As String
        <Column("ASSOC_OFFICE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssociateWithOffice() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(40)>
        <Column("VN_1099_ADDRESS1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine1() As String
        <MaxLength(40)>
        <Column("VN_1099_ADDRESS2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine2() As String
        <MaxLength(30)>
        <Column("VN_1099_ADDRESS3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099StreetAddressLine3() As String
        <MaxLength(25)>
        <Column("VN_1099_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099City() As String
        <MaxLength(10)>
        <Column("VN_1099_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099State() As String
        <MaxLength(10)>
        <Column("VN_1099_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099ZipCode() As String
        <MaxLength(20)>
        <Column("VN_1099_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099County() As String
        <MaxLength(20)>
        <Column("VN_1099_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Country() As String
        <Column("VN_USE_1099")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseAlternativeAddressFor1099() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("VN_ACCT_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
        <MaxLength(6)>
        <Column("DEF_FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <Column("EMP_VENDOR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeVendor() As Nullable(Of Integer)
        <Column("ONE_CHECK_PER_INV")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OneCheckPerInvoice() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("VN_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailAddress() As String
        <MaxLength(50)>
        <Column("PYMT_MGR_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerEmailAddress() As String
        <Column("VN_ACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ActiveFlag() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("DEF_VN_CONT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultVendorContactCode() As String
        <MaxLength(10)>
        <Column("DEF_SIZE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAdSize() As String
        <MaxLength(5)>
        <Column("CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <MaxLength(4)>
        <Column("DEF_VN_REP1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultVendorRepresentativeCode1() As String
        <MaxLength(4)>
        <Column("DEF_VN_REP2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultVendorRepresentativeCode2() As String
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <Column("IN_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetCategory() As Nullable(Of Short)
        <Column("MG_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineCategory() As Nullable(Of Short)
        <Column("NP_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperCategory() As Nullable(Of Short)
        <Column("OD_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeCategory() As Nullable(Of Short)
        <Column("RD_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioCategory() As Nullable(Of Short)
        <Column("TV_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TVCategory() As Nullable(Of Short)
        <Column("PRD_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionCategory() As Nullable(Of Short)
        <MaxLength(20)>
        <Column("VN_ALPHA_SORT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <MaxLength(4)>
        <Column("PO_FORMAT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property POFormat() As String
        <MaxLength(4)>
        <Column("DEF_SALES_TAX", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultSalesTax() As String
        <MaxLength(250)>
        <Column("WEB_ADDR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Website() As String
        <MaxLength(50)>
        <Column("VN_PAY_TO_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToEmail() As String
        <MaxLength(40)>
        <Column("SHIP_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToName() As String
        <MaxLength(40)>
        <Column("SHIP_ADDR1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToAddress() As String
        <MaxLength(40)>
        <Column("SHIP_ADDR2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToAddress2() As String
        <MaxLength(40)>
        <Column("SHIP_ADDR3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToAddress3() As String
        <MaxLength(25)>
        <Column("SHIP_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToCity() As String
        <MaxLength(20)>
        <Column("SHIP_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToCounty() As String
        <MaxLength(10)>
        <Column("SHIP_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToState() As String
        <MaxLength(20)>
        <Column("SHIP_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToCountry() As String
        <MaxLength(10)>
        <Column("SHIP_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToZip() As String
        <Column("VN_1099_INC_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Category() As Nullable(Of Short)
        <Column("ACH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsACH() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("ACH_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ACHType() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("VN_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3")>
        Public Property Commission() As Nullable(Of Decimal)
        <Column("COLUMN_SIZE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 2)>
        Public Property ColumnSize() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("OVERAGE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3")>
        Public Property OveragePercent() As Nullable(Of Decimal)
        <Column("FOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fold() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseTaxFlags() As Nullable(Of Short)
        <Column("TAXAPPLYC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYLN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxNetDiscount() As Nullable(Of Short)
        <Column("TAXAPPLYNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYAI")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxAdditionalCharge() As Nullable(Of Short)
        <MaxLength(12)>
        <Column("VN_CODE_XREF", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCodeCrossReference() As String
        <Column("MATL_CLOSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=32767)>
        Public Property MaterialCloseDays() As Nullable(Of Short)
        <Column("SPACE_CLOSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=32767)>
        Public Property SpaceCloseDays() As Nullable(Of Short)
        <Column("DAILY_CIRC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DailyCirculation() As Nullable(Of Integer)
        <Column("SUNDAY_CIRC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SundayCirculation() As Nullable(Of Integer)
        <Column("EDITIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Editions() As String
        <MaxLength(250)>
        <Column("PUB_FREQ", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PublishingFrequency() As String
        <Column("ISSUES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Issues() As Nullable(Of Integer)
        <MaxLength(2)>
        <Column("DEF_UNITS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultUnits() As String
        <Column("DEF_NET_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultNetGross() As Nullable(Of Short)
        <Column("COOP_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CoopFlag() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("CYCLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Cycles() As String
        <MaxLength(1)>
        <Column("DEF_SIZE_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultSizeType() As String
        <MaxLength(13)>
        <Column("SHIP_PHONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToPhone() As String
        <MaxLength(4)>
        <Column("SHIP_PHONE_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShipToPhoneExt() As String
        <Column("VCC_STATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCStatus() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("BK_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankCode() As String
        <Column("HAS_SPECIAL_TERMS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HasSpecialTerms() As Nullable(Of Boolean)
        <Column("SERVICE_TAX_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceTaxType() As Nullable(Of Short)
        <Column("SERVICE_TAX_ENABLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceTaxEnabled() As Nullable(Of Boolean)
        <Column("SERVICE_TAX_WAIVER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceTaxWaiver() As Nullable(Of Boolean)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(5, 3)>
        <Column("SERVICE_TAX_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3", UseMaxValue:=True, MaxValue:=99.999, UseMinValue:=True, MinValue:=0)>
        Public Property ServiceTaxRate() As Nullable(Of Decimal)
        <Column("SERVICE_TAX_WAIVER_EXPIRATION_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceTaxWaiverExpirationDate() As Nullable(Of Date)
        <Column("VENDOR_SERVICE_TAX_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorServiceTaxID() As Nullable(Of Integer)
        <Column("DEF_CORRESPONDENCE_METHOD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <Column("VCC_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="VCC Limit")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property VCCAmount() As Nullable(Of Decimal)
        <Required>
        <Column("SEND_VCC_WITH_MEDIA_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SendVCCWithMediaOrder() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("VN_MARKUP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3")>
        Public Property Markup() As Nullable(Of Decimal)
        <Column("VENDOR_INVOICE_CATEGORY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorInvoiceCategoryID() As Nullable(Of Integer)
        <Column("IS_CABLE_SYSTEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCableSystem() As Boolean
        <Column("NIELSEN_TV_STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenTVStationCode() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_STATION_COMBO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenRadioStationComboID() As Nullable(Of Integer)
        <Column("NCC_TV_SYSCODE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NCCTVSyscodeID() As Nullable(Of Integer)
        <Column("EASTLAN_RADIO_STATION_COMBO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EastlanRadioStationComboID() As Nullable(Of Integer)
        <Column("COMSCORE_TV_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreTVStationID() As Nullable(Of Integer)
        <Column("IS_NIELSEN_SUBSCRIBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNielsenSubsciber() As Boolean
        <Column("IS_COMSCORE_SUBSCRIBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsComscoreSubsciber() As Boolean
        <MaxLength(50)>
        <Column("VAT_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VATNumber() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(4)>
        <Column("CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CallLetters() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(2)>
        <Column("BAND", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Band() As String
        <Column("CANADIAN_VENDOR_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CanadianVendorType() As Integer
        <Column("NPR_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NPRStationID() As Nullable(Of Integer)
        <Column("VN_1099_USE_ALT_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property UseAlternativeNameFor1099() As Boolean
        <MaxLength(40)>
        <Column("VN_1099_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Name() As String
        <Required>
        <Column("IS_COMBO_RADIO_STATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsComboRadioStation() As Boolean

        Public Overridable Property [Function] As Database.Entities.Function
        Public Overridable Property VendorTerm As Database.Entities.VendorTerm
        <ForeignKey("DefaultAPAccount")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property StandardComments As ICollection(Of Database.Entities.StandardComment)
        Public Overridable Property InternetOrders As ICollection(Of Database.Entities.InternetOrder)
        Public Overridable Property MagazineOrders As ICollection(Of Database.Entities.MagazineOrder)
        Public Overridable Property NewspaperOrders As ICollection(Of Database.Entities.NewspaperOrder)
        Public Overridable Property OutOfHomeOrders As ICollection(Of Database.Entities.OutOfHomeOrder)
        Public Overridable Property RadioOrders As ICollection(Of Database.Entities.RadioOrder)
        Public Overridable Property TVOrders As ICollection(Of Database.Entities.TVOrder)
        Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        Public Overridable Property MediaSpecsHeader As ICollection(Of Database.Entities.MediaSpecsHeader)
        Public Overridable Property Currency As Database.Entities.Currency
        Public Overridable Property Associates As ICollection(Of Database.Entities.Associate)
        Public Overridable Property VendorPricings As ICollection(Of Database.Entities.VendorPricing)
        Public Overridable Property RateCards As ICollection(Of Database.Entities.RateCard)
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property Market As Database.Entities.Market
        Public Overridable Property VendorSortKeys As ICollection(Of Database.Entities.VendorSortKey)
        Public Overridable Property PurchaseOrders As ICollection(Of Database.Entities.PurchaseOrder)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property MediaATBRevisionDetails As ICollection(Of Database.Entities.MediaATBRevisionDetail)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property VendorInvoiceCategory As Database.Entities.VendorInvoiceCategory
        <ForeignKey("ComscoreTVStationID")>
        Public Overridable Property ComscoreTVStation As Database.Entities.ComscoreTVStation
        Public Overridable Property VendorMarkets As ICollection(Of Database.Entities.VendorMarket)
        <ForeignKey("VendorCode")>
        Public Overridable Property VendorComboRadioStations As ICollection(Of Database.Entities.VendorComboRadioStation)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                    ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                    ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() = False AndAlso IsValid = False AndAlso Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                        ErrorText = ""
                        IsValid = True

                    End If

            End Select

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Vendors
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique vendor code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
