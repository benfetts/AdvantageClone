Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_PRODUCTS")>
    Public Class ProductReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            OfficeName
            NewBusiness
            BillingAddress1
            BillingAddress2
            BillingCity
            BillingCounty
            BillingState
            BillingZip
            BillingCountry
            BillingPhone
            BillingPhoneExt
            BillingFax
            BillingFaxExt
            StatementAddress1
            StatementAddress2
            StatementCity
            StatementCounty
            StatementState
            StatementZip
            StatementCountry
            StatementPhone
            StatementPhoneExt
            StatementFax
            StatementFaxExt
            SortName
            AttentionLine
            CurrencyCode
            UserDefinedField1
            UserDefinedField2
            UserDefinedField3
            UserDefinedField4
            ProductionContingency
            ProductionMarkup
            ProductionEmployeeTimeBillingRate
            ProductionUseEstimateBillingRate
            ProductionTaxCode
            ProductionAlertGroup
            ProductionConsolidateFunctions
            ProductionBillNet
            ProductionVendorDiscounts
            ProductionApprovedEstimatedRequired
            ProductionBillingSetupComplete
            RadioPrePostBill
            RadioMarkup
            RadioRebate
            RadioBillNet
            RadioCommissionOnly
            RadioDaysToBill
            RadioBillSetting
            RadioVendorDiscounts
            RadioTaxCode
            RadioBillingSetupComplete
            RadioApplyTaxUseFlags
            RadioApplyTaxLineNet
            RadioApplyTaxNetCharge
            RadioApplyTaxAddlCharge
            RadioApplyTaxCommission
            RadioApplyTaxRebate
            RadioApplyTaxNetDiscount
            TelevisionPrePostBill
            TelevisionMarkup
            TelevisionRebate
            TelevisionBillNet
            TelevisionCommissionOnly
            TelevisionDaysToBill
            TelevisionBillSetting
            TelevisionVendorDiscounts
            TelevisionTaxCode
            TelevisionBillingSetupComplete
            TelevisionApplyTaxUseFlags
            TelevisionApplyTaxLineNet
            TelevisionApplyTaxNetCharge
            TelevisionApplyTaxAddlCharge
            TelevisionApplyTaxCommission
            TelevisionApplyTaxRebate
            TelevisionApplyTaxNetDiscount
            MagazinePrePostBill
            MagazineMarkup
            MagazineRebate
            MagazineBillNet
            MagazineCommissionOnly
            MagazineDaysToBill
            MagazineBillSetting
            MagazineVendorDiscounts
            MagazineTaxCode
            MagazineBillingSetupComplete
            MagazineApplyTaxUseFlags
            MagazineApplyTaxLineNet
            MagazineApplyTaxNetCharge
            MagazineApplyTaxAddlCharge
            MagazineApplyTaxCommission
            MagazineApplyTaxRebate
            MagazineApplyTaxNetDiscount
            NewspaperPrePostBill
            NewspaperMarkup
            NewspaperRebate
            NewspaperBillNet
            NewspaperCommissionOnly
            NewspaperDaysToBill
            NewspaperBillSetting
            NewspaperVendorDiscounts
            NewspaperTaxCode
            NewspaperBillingSetupComplete
            NewspaperApplyTaxUseFlags
            NewspaperApplyTaxLineNet
            NewspaperApplyTaxNetCharge
            NewspaperApplyTaxAddlCharge
            NewspaperApplyTaxCommission
            NewspaperApplyTaxRebate
            NewspaperApplyTaxNetDiscount
            InternetPrePostBill
            InternetMarkup
            InternetRebate
            InternetBillNet
            InternetCommissionOnly
            InternetDaysToBill
            InternetBillSetting
            InternetVendorDiscounts
            InternetTaxCode
            InternetBillingSetupComplete
            InternetApplyTaxUseFlags
            InternetApplyTaxLineNet
            InternetApplyTaxNetCharge
            InternetApplyTaxAddlCharge
            InternetApplyTaxCommission
            InternetApplyTaxRebate
            InternetApplyTaxNetDiscount
            OutOfHomePrePostBill
            OutOfHomeMarkup
            OutOfHomeRebate
            OutOfHomeBillNet
            OutOfHomeCommissionOnly
            OutOfHomeDaysToBill
            OutOfHomeBillSetting
            OutOfHomeVendorDiscounts
            OutOfHomeTaxCode
            OutOfHomeBillingSetupComplete
            OutOfHomeApplyTaxUseFlags
            OutOfHomeApplyTaxLineNet
            OutOfHomeApplyTaxNetCharge
            OutOfHomeApplyTaxAddlCharge
            OutOfHomeApplyTaxCommission
            OutOfHomeApplyTaxRebate
            OutOfHomeApplyTaxNetDiscount
            IsActive
            DefaultAECode
            DefaultAEName
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description

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
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
        <Required>
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <Required>
        <MaxLength(1)>
        <Column("NewBusiness", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewBusiness() As String
        <MaxLength(40)>
        <Column("BillingAddress1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress1() As String
        <MaxLength(40)>
        <Column("BillingAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress2() As String
        <MaxLength(30)>
        <Column("BillingCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCity() As String
        <MaxLength(20)>
        <Column("BillingCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCounty() As String
        <MaxLength(10)>
        <Column("BillingState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingState() As String
        <MaxLength(10)>
        <Column("BillingZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingZip() As String
        <MaxLength(20)>
        <Column("BillingCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCountry() As String
        <MaxLength(13)>
        <Column("BillingPhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingPhone() As String
        <MaxLength(4)>
        <Column("BillingPhoneExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingPhoneExt() As String
        <MaxLength(13)>
        <Column("BillingFax", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingFax() As String
        <MaxLength(4)>
        <Column("BillingFaxExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingFaxExt() As String
        <MaxLength(40)>
        <Column("StatementAddress1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress1() As String
        <MaxLength(40)>
        <Column("StatementAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress2() As String
        <MaxLength(30)>
        <Column("StatementCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCity() As String
        <MaxLength(20)>
        <Column("StatementCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCounty() As String
        <MaxLength(10)>
        <Column("StatementState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementState() As String
        <MaxLength(10)>
        <Column("StatementZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementZip() As String
        <MaxLength(20)>
        <Column("StatementCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCountry() As String
        <MaxLength(13)>
        <Column("StatementPhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementPhone() As String
        <MaxLength(4)>
        <Column("StatementPhoneExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementPhoneExt() As String
        <MaxLength(13)>
        <Column("StatementFax", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementFax() As String
        <MaxLength(4)>
        <Column("StatementFaxExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementFaxExt() As String
        <MaxLength(20)>
        <Column("SortName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <MaxLength(40)>
        <Column("AttentionLine", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AttentionLine() As String
        <MaxLength(5)>
        <Column("CurrencyCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <MaxLength(50)>
        <Column("UserDefinedField1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField1() As String
        <MaxLength(50)>
        <Column("UserDefinedField2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField2() As String
        <MaxLength(50)>
        <Column("UserDefinedField3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField3() As String
        <MaxLength(50)>
        <Column("UserDefinedField4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField4() As String
        <Column("ProductionContingency")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionContingency() As Nullable(Of Decimal)
        <Column("ProductionMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionMarkup() As Nullable(Of Decimal)
        <Column("ProductionEmployeeTimeBillingRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionEmployeeTimeBillingRate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("ProductionUseEstimateBillingRate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionUseEstimateBillingRate() As String
        <MaxLength(4)>
        <Column("ProductionTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionTaxCode() As String
        <MaxLength(50)>
        <Column("ProductionAlertGroup", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionAlertGroup() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductionConsolidateFunctions", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionConsolidateFunctions() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductionBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductionVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionVendorDiscounts() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductionApprovedEstimatedRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionApprovedEstimatedRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductionBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionBillingSetupComplete() As String
        <Required>
        <MaxLength(9)>
        <Column("RadioPrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioPrePostBill() As String
        <Column("RadioMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioMarkup() As Nullable(Of Decimal)
        <Column("RadioRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("RadioBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioCommissionOnly() As String
        <Column("RadioDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(21)>
        <Column("RadioBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioVendorDiscounts() As String
        <MaxLength(4)>
        <Column("RadioTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("RadioApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(9)>
        <Column("TelevisionPrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionPrePostBill() As String
        <Column("TelevisionMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionMarkup() As Nullable(Of Decimal)
        <Column("TelevisionRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("TelevisionBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionCommissionOnly() As String
        <Column("TelevisionDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(21)>
        <Column("TelevisionBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionVendorDiscounts() As String
        <MaxLength(4)>
        <Column("TelevisionTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("TelevisionApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(9)>
        <Column("MagazinePrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazinePrePostBill() As String
        <Column("MagazineMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineMarkup() As Nullable(Of Decimal)
        <Column("MagazineRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("MagazineBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineCommissionOnly() As String
        <Column("MagazineDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(21)>
        <Column("MagazineBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineVendorDiscounts() As String
        <MaxLength(4)>
        <Column("MagazineTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("MagazineApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(9)>
        <Column("NewspaperPrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperPrePostBill() As String
        <Column("NewspaperMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperMarkup() As Nullable(Of Decimal)
        <Column("NewspaperRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("NewspaperBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperCommissionOnly() As String
        <Column("NewspaperDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(21)>
        <Column("NewspaperBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperVendorDiscounts() As String
        <MaxLength(4)>
        <Column("NewspaperTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("NewspaperApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(9)>
        <Column("InternetPrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetPrePostBill() As String
        <Column("InternetMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetMarkup() As Nullable(Of Decimal)
        <Column("InternetRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("InternetBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetCommissionOnly() As String
        <Column("InternetDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(17)>
        <Column("InternetBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetVendorDiscounts() As String
        <MaxLength(4)>
        <Column("InternetTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("InternetApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(9)>
        <Column("OutOfHomePrePostBill", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomePrePostBill() As String
        <Column("OutOfHomeMarkup")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeMarkup() As Nullable(Of Decimal)
        <Column("OutOfHomeRebate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeRebate() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeBillNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillNet() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeCommissionOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeCommissionOnly() As String
        <Column("OutOfHomeDaysToBill")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeDaysToBill() As Nullable(Of Short)
        <Required>
        <MaxLength(17)>
        <Column("OutOfHomeBillSetting", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillSetting() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeVendorDiscounts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeVendorDiscounts() As String
        <MaxLength(4)>
        <Column("OutOfHomeTaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeTaxCode() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeBillingSetupComplete", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillingSetupComplete() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxUseFlags", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxUseFlags() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxLineNet", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxLineNet() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxNetCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxNetCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxAddlCharge", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxAddlCharge() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxCommission", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxCommission() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxRebate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxRebate() As String
        <Required>
        <MaxLength(1)>
        <Column("OutOfHomeApplyTaxNetDiscount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxNetDiscount() As String
        <Required>
        <MaxLength(1)>
        <Column("IsActive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As String
        <MaxLength(6)>
        <Column("DefaultAECode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAECode() As String
        <MaxLength(64)>
        <Column("DefaultAEName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAEName() As String

        <Column("ClientType1Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 1 Code")>
        Public Property ClientType1Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType1Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
        Public Property ClientType1Description() As String

        <Column("ClientType2Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 2 Code")>
        Public Property ClientType2Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType2Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
        Public Property ClientType2Description() As String

        <Column("ClientType3Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 3 Code")>
        Public Property ClientType3Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType3Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
        Public Property ClientType3Description() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
