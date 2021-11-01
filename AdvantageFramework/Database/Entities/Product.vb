Namespace Database.Entities

	<Table("PRODUCT")>
	Public Class Product
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            Code
            Name
            OfficeCode
            IsActive
            BillingAddress
            BillingAddress2
            BillingCity
            BillingCounty
            BillingState
            BillingZip
            BillingCountry
            BillingPhone
            BillingPhoneExtension
            BillingFax
            BillingFaxExtension
            StatementAddress
            StatementAddress2
            StatementCity
            StatementCounty
            StatementState
            StatementZip
            StatementCountry
            StatementPhone
            StatementPhoneExtension
            StatementFax
            StatementFaxExtension
            UserDefinedField1
            UserDefinedField2
            UserDefinedField3
            UserDefinedField4
            SortName
            AttentionTo
            RadioMarkup
            RadioRebate
            RadioBillNet
            RadioCommissionOnly
            RadioPrePostBill
            RadioDaysToBill
            RadioBillSetting
            RadioVendorDiscounts
            RadioBillingSetupComplete
            RadioApplyTaxUseFlags
            RadioApplyTaxLineNet
            RadioApplyTaxNetCharge
            RadioApplyTaxAddlCharge
            RadioApplyTaxCommission
            RadioApplyTaxRebate
            RadioApplyTaxNetDiscount
            TelevisionMarkup
            TelevisionRebate
            TelevisionBillNet
            TelevisionCommissionOnly
            TelevisionPrePostBill
            TelevisionDaysToBill
            TelevisionBillSetting
            TelevisionVendorDiscounts
            TelevisionBillingSetupComplete
            TelevisionApplyTaxUseFlags
            TelevisionApplyTaxLineNet
            TelevisionApplyTaxNetCharge
            TelevisionApplyTaxAddlCharge
            TelevisionApplyTaxCommission
            TelevisionApplyTaxRebate
            TelevisionApplyTaxNetDiscount
            MagazineMarkup
            MagazineRebate
            MagazineBillNet
            MagazineCommissionOnly
            MagazinePrePostBill
            MagazineDaysToBill
            MagazineBillSetting
            MagazineVendorDiscounts
            MagazineBillingSetupComplete
            MagazineApplyTaxUseFlags
            MagazineApplyTaxLineNet
            MagazineApplyTaxNetCharge
            MagazineApplyTaxAddlCharge
            MagazineApplyTaxCommission
            MagazineApplyTaxRebate
            MagazineApplyTaxNetDiscount
            NewspaperMarkup
            NewspaperRebate
            NewspaperBillNet
            NewspaperCommissionOnly
            NewspaperPrePostBill
            NewspaperDaysToBill
            NewspaperBillSetting
            NewspaperVendorDiscounts
            NewspaperBillingSetupComplete
            NewspaperApplyTaxUseFlags
            NewspaperApplyTaxLineNet
            NewspaperApplyTaxNetCharge
            NewspaperApplyTaxAddlCharge
            NewspaperApplyTaxCommission
            NewspaperApplyTaxRebate
            NewspaperApplyTaxNetDiscount
            InternetMarkup
            InternetRebate
            InternetBillNet
            InternetCommissionOnly
            InternetPrePostBill
            InternetDaysToBill
            InternetBillSetting
            InternetVendorDiscounts
            InternetBillingSetupComplete
            InternetApplyTaxUseFlags
            InternetApplyTaxLineNet
            InternetApplyTaxNetCharge
            InternetApplyTaxAddlCharge
            InternetApplyTaxCommission
            InternetApplyTaxRebate
            InternetApplyTaxNetDiscount
            OutOfHomeMarkup
            OutOfHomeRebate
            OutOfHomeBillNet
            OutOfHomeCommissionOnly
            OutOfHomePrePostBill
            OutOfHomeDaysToBill
            OutOfHomeBillSetting
            OutOfHomeVendorDiscounts
            OutOfHomeBillingSetupComplete
            OutOfHomeApplyTaxUseFlags
            OutOfHomeApplyTaxLineNet
            OutOfHomeApplyTaxNetCharge
            OutOfHomeApplyTaxAddlCharge
            OutOfHomeApplyTaxCommission
            OutOfHomeApplyTaxRebate
            OutOfHomeApplyTaxNetDiscount
            ProductionContingency
            ProductionMarkup
            ProductionEmployeeTimeBillingRate
            ProductionUseEstimateBillingRate
            ProductionConsolidateFunctions
            ProductionBillNet
            ProductionVendorDiscounts
            ProductionApprovedEstimatedRequired
            ProductionBillingSetupComplete
            ProductionTaxCode
            RadioTaxCode
            InternetTaxCode
            MagazineTaxCode
            NewspaperTaxCode
            OutOfHomeTaxCode
            TelevisionTaxCode
            ProductionEmployeeTimeBillable
            CurrencyCode
            ProductionAlertGroup
            BatchName
            AvalaraTaxExemptOverride
            CalculateLateFee
            LateFeePercent
            CDPSecurityGroupID
            Division
            Office
            Jobs
            Client
            BillingRateDetails
            EmployeeTimeForecastOfficeDetailJobComponents
            Campaigns
            AccountExecutives
            ProductCategories
            ProductSortKeys
            StandardComments
            BillingCoops
            InternetOrders
            MagazineOrders
            NewspaperOrders
            OutOfHomeOrders
            RadioOrders
            TVOrders
            Documents
            Currency
            GeneralLedgerDetails
            PartnerAllocations
            DestinationContacts
            RadioOrderLegacies
            TVOrderLegacies
            AccountReceivables
            Contracts
            MediaATBs
            DigitalResults
            CDPSecurityGroup
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.ClientCode & "|" & Me.DivisionCode & "|" & Me.Code
            End Get
        End Property
        <Key>
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <Key>
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <Key>
        <Required>
        <MaxLength(6)>
        <Column("PRD_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(40)>
        <Column("PRD_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property OfficeCode() As String
        <Column("ACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As Nullable(Of Short)
        <MaxLength(40)>
        <Column("PRD_BILL_ADDRESS1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress() As String
        <MaxLength(40)>
        <Column("PRD_BILL_ADDRESS2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress2() As String
        <MaxLength(30)>
        <Column("PRD_BILL_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCity() As String
        <MaxLength(20)>
        <Column("PRD_BILL_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCounty() As String
        <MaxLength(10)>
        <Column("PRD_BILL_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingState() As String
        <MaxLength(10)>
        <Column("PRD_BILL_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingZip() As String
        <MaxLength(20)>
        <Column("PRD_BILL_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCountry() As String
        <MaxLength(13)>
        <Column("PRD_BILL_TELEPHONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingPhone() As String
        <MaxLength(4)>
        <Column("PRD_BILL_EXTENTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingPhoneExtension() As String
        <MaxLength(13)>
        <Column("PRD_BILL_FAX", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingFax() As String
        <MaxLength(4)>
        <Column("PRD_BILL_FAX_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingFaxExtension() As String
        <MaxLength(40)>
        <Column("PRD_STATE_ADDR1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress() As String
        <MaxLength(40)>
        <Column("PRD_STATE_ADDR2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress2() As String
        <MaxLength(30)>
        <Column("PRD_STATE_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCity() As String
        <MaxLength(20)>
        <Column("PRD_STATE_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCounty() As String
        <MaxLength(10)>
        <Column("PRD_STATE_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementState() As String
        <MaxLength(10)>
        <Column("PRD_STATE_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementZip() As String
        <MaxLength(20)>
        <Column("PRD_STATE_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCountry() As String
        <MaxLength(13)>
        <Column("PRD_STATE_TELEPHON", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementPhone() As String
        <MaxLength(4)>
        <Column("PRD_STATE_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementPhoneExtension() As String
        <MaxLength(13)>
        <Column("PRD_STATE_FAX", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementFax() As String
        <MaxLength(4)>
        <Column("PRD_STATE_FAX_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementFaxExtension() As String
        <MaxLength(50)>
        <Column("USER_DEFINED1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField1() As String
        <MaxLength(50)>
        <Column("USER_DEFINED2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField2() As String
        <MaxLength(50)>
        <Column("USER_DEFINED3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField3() As String
        <MaxLength(50)>
        <Column("USER_DEFINED4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedField4() As String
        <MaxLength(20)>
        <Column("PRD_ALPHA_SORT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <MaxLength(40)>
        <Column("PRD_ATTENTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AttentionTo() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_RADIO_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property RadioMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_RADIO_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property RadioRebate() As Nullable(Of Decimal)
        <Column("PRD_RADIO_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillNet() As Nullable(Of Short)
        <Column("PRD_RADIO_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioCommissionOnly() As Nullable(Of Short)
        <Column("PRD_RADIO_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioPrePostBill() As Nullable(Of Short)
        <Column("PRD_RADIO_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioDaysToBill() As Nullable(Of Short)
        <Column("PRD_RADIO_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillSetting() As Nullable(Of Short)
        <Column("PRD_RADIO_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioVendorDiscounts() As Nullable(Of Short)
        <Column("RADIO_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioApplyTaxNetDiscount() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_TV_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property TelevisionMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_TV_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property TelevisionRebate() As Nullable(Of Decimal)
        <Column("PRD_TV_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillNet() As Nullable(Of Short)
        <Column("PRD_TV_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionCommissionOnly() As Nullable(Of Short)
        <Column("PRD_TV_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionPrePostBill() As Nullable(Of Short)
        <Column("PRD_TV_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionDaysToBill() As Nullable(Of Short)
        <Column("PRD_TV_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillSetting() As Nullable(Of Short)
        <Column("PRD_TV_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionVendorDiscounts() As Nullable(Of Short)
        <Column("TV_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_T")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionApplyTaxNetDiscount() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_MAG_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property MagazineMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_MAG_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property MagazineRebate() As Nullable(Of Decimal)
        <Column("PRD_MAG_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillNet() As Nullable(Of Short)
        <Column("PRD_MAG_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineCommissionOnly() As Nullable(Of Short)
        <Column("PRD_MAG_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazinePrePostBill() As Nullable(Of Short)
        <Column("PRD_MAG_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineDaysToBill() As Nullable(Of Short)
        <Column("PRD_MAG_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillSetting() As Nullable(Of Short)
        <Column("PRD_MAG_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineVendorDiscounts() As Nullable(Of Short)
        <Column("MAG_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_M")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineApplyTaxNetDiscount() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_NEWS_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property NewspaperMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_NEWS_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property NewspaperRebate() As Nullable(Of Decimal)
        <Column("PRD_NEWS_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillNet() As Nullable(Of Short)
        <Column("PRD_NEWS_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperCommissionOnly() As Nullable(Of Short)
        <Column("PRD_NEWS_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperPrePostBill() As Nullable(Of Short)
        <Column("PRD_NEWS_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperDaysToBill() As Nullable(Of Short)
        <Column("PRD_NEWS_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillSetting() As Nullable(Of Short)
        <Column("PRD_NEWS_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperVendorDiscounts() As Nullable(Of Short)
        <Column("NEWS_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_N")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperApplyTaxNetDiscount() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_MISC_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property InternetMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_MISC_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property InternetRebate() As Nullable(Of Decimal)
        <Column("PRD_MISC_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillNet() As Nullable(Of Short)
        <Column("PRD_MISC_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetCommissionOnly() As Nullable(Of Short)
        <Column("PRD_MISC_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetPrePostBill() As Nullable(Of Short)
        <Column("PRD_MISC_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetDaysToBill() As Nullable(Of Short)
        <Column("PRD_MISC_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillSetting() As Nullable(Of Short)
        <Column("PRD_MISC_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetVendorDiscounts() As Nullable(Of Short)
        <Column("INET_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_I")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetApplyTaxNetDiscount() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_OTDR_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property OutOfHomeMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_OTDR_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property OutOfHomeRebate() As Nullable(Of Decimal)
        <Column("PRD_OTDR_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillNet() As Nullable(Of Short)
        <Column("PRD_OTDR_COM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeCommissionOnly() As Nullable(Of Short)
        <Column("PRD_OTDR_PRE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomePrePostBill() As Nullable(Of Short)
        <Column("PRD_OTDR_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeDaysToBill() As Nullable(Of Short)
        <Column("PRD_OTDR_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillSetting() As Nullable(Of Short)
        <Column("PRD_OTDR_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeVendorDiscounts() As Nullable(Of Short)
        <Column("OOH_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeBillingSetupComplete() As Nullable(Of Short)
        <Column("USE_TAX_FLAGS_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxUseFlags() As Nullable(Of Short)
        <Column("TAXAPPLYLN_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxLineNet() As Nullable(Of Short)
        <Column("TAXAPPLYNC_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxNetCharge() As Nullable(Of Short)
        <Column("TAXAPPLYAI_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxAddlCharge() As Nullable(Of Short)
        <Column("TAXAPPLYC_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxCommission() As Nullable(Of Short)
        <Column("TAXAPPLYR_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxRebate() As Nullable(Of Short)
        <Column("TAXAPPLYND_O")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeApplyTaxNetDiscount() As Nullable(Of Short)
        <Column("PRD_CONT_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property ProductionContingency() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("PRD_PROD_MARKUP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=-9999.999)>
        Public Property ProductionMarkup() As Nullable(Of Decimal)
        <Column("PRD_BILL_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 3)>
        Public Property ProductionEmployeeTimeBillingRate() As Nullable(Of Decimal)
        <Column("USE_EST_BILL_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionUseEstimateBillingRate() As Nullable(Of Short)
        <Column("PRD_CONSOL_FUNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionConsolidateFunctions() As Nullable(Of Short)
        <Column("PRD_PROD_BILL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionBillNet() As Nullable(Of Short)
        <Column("PRD_PROD_VEN_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionVendorDiscounts() As Nullable(Of Short)
        <Column("PRD_PROD_ESTIMATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionApprovedEstimatedRequired() As Nullable(Of Short)
        <Column("PROD_SETUP_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionBillingSetupComplete() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("PRD_PROD_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_RADIO_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_MISC_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_MAG_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_NEWS_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_OTDR_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeTaxCode() As String
        <MaxLength(4)>
        <Column("PRD_TV_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionTaxCode() As String
        <Column("PRD_BILL_EMP_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        Public Property ProductionEmployeeTimeBillable() As Nullable(Of Short)
        <MaxLength(5)>
        <Column("CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <MaxLength(50)>
        <Column("EMAIL_GR_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionAlertGroup() As String
        <MaxLength(50)>
        <Column("BATCH_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BatchName() As String
        <Required>
        <Column("PRD_PROD_PAYDAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionDaysToPay() As Short
        <Required>
        <Column("AVALARA_TAX_EXEMPT_OVERRIDE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AvalaraTaxExemptOverride() As Boolean
        <Column("CALC_LATE_FEE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalculateLateFee() As Boolean
        <Column("LATE_FEE_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(5, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LateFeePercent() As Nullable(Of Decimal)
        <Column("CDP_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CDPSecurityGroupID() As Nullable(Of Integer)

        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property Jobs As ICollection(Of Database.Entities.Job)
        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property Campaigns As ICollection(Of Database.Entities.Campaign)
        Public Overridable Property AccountExecutives As ICollection(Of Database.Entities.AccountExecutive)
        Public Overridable Property ProductCategories As ICollection(Of Database.Entities.ProductCategory)
        Public Overridable Property ProductSortKeys As ICollection(Of Database.Entities.ProductSortKey)
        Public Overridable Property StandardComments As ICollection(Of Database.Entities.StandardComment)
        Public Overridable Property InternetOrders As ICollection(Of Database.Entities.InternetOrder)
        Public Overridable Property MagazineOrders As ICollection(Of Database.Entities.MagazineOrder)
        Public Overridable Property NewspaperOrders As ICollection(Of Database.Entities.NewspaperOrder)
        Public Overridable Property OutOfHomeOrders As ICollection(Of Database.Entities.OutOfHomeOrder)
        Public Overridable Property RadioOrders As ICollection(Of Database.Entities.RadioOrder)
        Public Overridable Property TVOrders As ICollection(Of Database.Entities.TVOrder)
        Public Overridable Property Currency As Database.Entities.Currency
        Public Overridable Property GeneralLedgerDetails As ICollection(Of Database.Entities.GeneralLedgerDetail)
        Public Overridable Property PartnerAllocations As ICollection(Of Database.Entities.PartnerAllocation)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property Contracts As ICollection(Of Database.Entities.Contract)
        Public Overridable Property MediaATBs As ICollection(Of Database.Entities.MediaATB)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property MediaPlans As ICollection(Of Database.Entities.MediaPlan)
        Public Overridable Property CDPSecurityGroup As Database.Entities.CDPSecurityGroup

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Product.Properties.Code.ToString

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

                Case AdvantageFramework.Database.Entities.Product.Properties.Code.ToString

                    If IsValid Then

                        If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                            IsValid = False
                            ErrorText = "Please enter a valid product code."

                        End If

                    End If

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            PropertyValue = Value

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Products
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                            Entity.ClientCode = Me.ClientCode AndAlso
                                            Entity.DivisionCode = Me.DivisionCode
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique product code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
