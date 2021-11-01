Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_VENDOR_CONTRACTS")>
    Public Class VendorContractsReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            StreetAddressLine1
            StreetAddressLine2
            StreetAddressLine3
            City
            County
            State
            ZipCode
            Country
            Phone
            PhoneExt
            Fax
            FaxExt
            PayToCode
            PayToName
            PayToAddressLine1
            PayToAddressLine2
            PayToAddressLine3
            PayToCity
            PayToCounty
            PayToState
            PayToZipCode
            PayToCountry
            PayToPhoneNumber
            PayToPhoneExt
            PayToFax
            PayToFaxExt
            Website
            EmailAddress
            PaymentManagerEmail
            EmployeeVendorFlag
            FederalTaxID
            DefaultCategory
            AccountNumber
            OfficeCode
            DefaultAPAccount
            DefaultExpenseAccount
            CurrencyCode
            SortName
            DefaultFunctionCode
            VendorTermCode
            OneCheckPerInvoice
            IsACH
            ACHType
            VCCStatusCode
            VCCStatusDescription
            DefaultCorrespondenceMethod
            VCCLimit
            SendVCCWithMediaOrder
            Is1099
            Vendor1099Address1
            Vendor1099Address2
            Vendor1099Address3
            Vendor1099City
            Vendor1099State
            Vendor1099Zip
            Vendor1099County
            Vendor1099Country
            Vendor1099UseAddress
            ContractCode
            ContractDescription
            ContractStartDate
            ContractEndDate
            ContractComments
            RenewalAlertSentDate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Column("VendorCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Column("VendorName", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <Column("StreetAddressLine1", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine1() As String
        <Column("StreetAddressLine2", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine2() As String
        <Column("StreetAddressLine3", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddressLine3() As String
        <Column("City", TypeName:="varchar")>
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <Column("County", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <Column("State", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <Column("ZipCode", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ZipCode() As String
        <Column("Country", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
        <Column("Phone", TypeName:="varchar")>
        <MaxLength(13)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Phone() As String
        <Column("PhoneExt", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneExt() As String
        <Column("Fax", TypeName:="varchar")>
        <MaxLength(13)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fax() As String
        <Column("FaxExt", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxExt() As String
        <Column("PayToCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCode() As String
        <Column("PayToName", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToName() As String
        <Column("PayToAddressLine1", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine1() As String
        <Column("PayToAddressLine2", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine2() As String
        <Column("PayToAddressLine3", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddressLine3() As String
        <Column("PayToCity", TypeName:="varchar")>
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCity() As String
        <Column("PayToCounty", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCounty() As String
        <Column("PayToState", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToState() As String
        <Column("PayToZipCode", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToZipCode() As String
        <Column("PayToCountry", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCountry() As String
        <Column("PayToPhoneNumber", TypeName:="varchar")>
        <MaxLength(13)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneNumber() As String
        <Column("PayToPhoneExt", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToPhoneExt() As String
        <Column("PayToFax", TypeName:="varchar")>
        <MaxLength(13)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFax() As String
        <Column("PayToFaxExt", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToFaxExt() As String
        <Column("Website", TypeName:="varchar")>
        <MaxLength(250)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Website() As String
        <Column("EmailAddress", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailAddress() As String
        <Column("PaymentManagerEmail", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerEmail() As String
        <Column("EmployeeVendorFlag", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeVendorFlag() As String
        <Column("FederalTaxID", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FederalTaxID() As String
        <Column("DefaultCategory", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCategory() As String
        <Column("AccountNumber", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
        <Column("OfficeCode", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("DefaultAPAccount", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAPAccount() As String
        <Column("DefaultExpenseAccount", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultExpenseAccount() As String
        <Column("CurrencyCode", TypeName:="varchar")>
        <MaxLength(5)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <Column("SortName", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <Column("DefaultFunctionCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultFunctionCode() As String
        <Column("VendorTermCode", TypeName:="varchar")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTermCode() As String
        <Column("OneCheckPerInvoice")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OneCheckPerInvoice() As Short?
        <Column("IsACH", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsACH() As String
        <Column("ACHType", TypeName:="varchar")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ACHType() As String
        <Column("VCCStatusCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCStatusCode() As Short?
        <Column("VCCStatusDescription", TypeName:="varchar")>
        <MaxLength(8)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCStatusDescription() As String
        <Column("DefaultCorrespondenceMethod")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCorrespondenceMethod() As Short?
        <Column("VCCLimit")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VCCLimit() As Decimal?
        <Column("SendVCCWithMediaOrder", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SendVCCWithMediaOrder() As String
        <Column("Is1099", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Is1099() As String
        <Column("Vendor1099Address1", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Address1() As String
        <Column("Vendor1099Address2", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Address2() As String
        <Column("Vendor1099Address3", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Address3() As String
        <Column("Vendor1099City", TypeName:="varchar")>
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099City() As String
        <Column("Vendor1099State", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099State() As String
        <Column("Vendor1099Zip", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Zip() As String
        <Column("Vendor1099County", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099County() As String
        <Column("Vendor1099Country", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099Country() As String
        <Column("Vendor1099UseAddress")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor1099UseAddress() As Short?
        <Column("ContractCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractCode() As String
        <Column("ContractDescription", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractDescription() As String
        <Column("ContractStartDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractStartDate() As Date?
        <Column("ContractEndDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractEndDate() As Date?
        <Column("ContractComments", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractComments() As String
        <Column("RenewalAlertSentDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RenewalAlertSentDate() As Date?


#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
