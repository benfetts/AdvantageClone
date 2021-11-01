Namespace Database.Entities

	<Table("IMP_PRODUCT_STAGING")>
	Public Class ImportProductStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			IsNew
			IsOnHold
			ClientCode
			DivisionCode
			Code
			Name
			AttentionTo
			BillingAddress
			BillingAddress2
			BillingCity
			BillingCounty
			BillingState
			BillingCountry
			BillingZip
			BillingPhone
			BillingPhoneExtension
			BillingFax
			BillingFaxExtension
			StatementAddress
			StatementAddress2
			StatementCity
			StatementCounty
			StatementState
			StatementCountry
			StatementZip
			StatementPhone
			StatementPhoneExtension
			StatementFax
			StatementFaxExtension
			OfficeCode
			ProductionConsolidateFunctions
			ProductionContingency
			ProductionMarkup
			ProductionBillNet
			ProductionVendorDiscounts
			ProductionApprovedEstimatedRequired
			ProductionTaxCode
			RadioRebate
			RadioBillNet
			RadioVendorDiscounts
			RadioCommissionOnly
			RadioTaxCode
			RadioDaysToBill
			RadioPrePostBill
			RadioBillSetting
			TelevisionRebate
			TelevisionBillNet
			TelevisionVendorDiscounts
			TelevisionCommissionOnly
			TelevisionTaxCode
			TelevisionDaysToBill
			TelevisionPrePostBill
			TelevisionBillSetting
			MagazineRebate
			MagazineBillNet
			MagazineVendorDiscounts
			MagazineCommissionOnly
			MagazineTaxCode
			MagazineDaysToBill
			MagazinePrePostBill
			MagazineBillSetting
			NewspaperMarkup
			NewspaperBillNet
			NewspaperVendorDiscounts
			NewspaperCommissionOnly
			NewspaperTaxCode
			NewspaperDaysToBill
			NewspaperPrePostBill
			NewspaperBillSetting
			NewspaperRebate
			OutOfHomeRebate
			InternetRebate
			RadioMarkup
			TelevisionMarkup
			MagazineMarkup
			OutOfHomeMarkup
			InternetMarkup
			OutOfHomeBillSetting
			OutOfHomeBillNet
			OutOfHomeCommissionOnly
			OutOfHomeDaysToBill
			OutOfHomePrePostBill
			OutOfHomeTaxCode
			OutOfHomeVendorDiscounts
			InternetBillSetting
			InternetBillNet
			InternetCommissionOnly
			InternetDaysToBill
			InternetPrePostBill
			InternetTaxCode
			InternetVendorDiscounts
			ProductionAlertGroup
			IsActive
			UserDefinedField1
			UserDefinedField2
			UserDefinedField3
			UserDefinedField4
			RadioApplyTaxUseFlags
			RadioApplyTaxLineNet
			RadioApplyTaxNetDiscount
			RadioApplyTaxNetCharge
			RadioApplyTaxAddlCharge
			RadioApplyTaxCommission
			RadioApplyTaxRebate
			TelevisionApplyTaxUseFlags
			TelevisionApplyTaxLineNet
			TelevisionApplyTaxNetDiscount
			TelevisionApplyTaxNetCharge
			TelevisionApplyTaxAddlCharge
			TelevisionApplyTaxCommission
			TelevisionApplyTaxRebate
			MagazineApplyTaxUseFlags
			MagazineApplyTaxLineNet
			MagazineApplyTaxNetDiscount
			MagazineApplyTaxNetCharge
			MagazineApplyTaxAddlCharge
			MagazineApplyTaxCommission
			MagazineApplyTaxRebate
			NewspaperApplyTaxUseFlags
			NewspaperApplyTaxLineNet
			NewspaperApplyTaxNetDiscount
			NewspaperApplyTaxNetCharge
			NewspaperApplyTaxAddlCharge
			NewspaperApplyTaxCommission
			NewspaperApplyTaxRebate
			OutOfHomeApplyTaxUseFlags
			OutOfHomeApplyTaxLineNet
			OutOfHomeApplyTaxNetDiscount
			OutOfHomeApplyTaxNetCharge
			OutOfHomeApplyTaxAddlCharge
			OutOfHomeApplyTaxCommission
			OutOfHomeApplyTaxRebate
			InternetApplyTaxUseFlags
			InternetApplyTaxLineNet
			InternetApplyTaxNetDiscount
			InternetApplyTaxNetCharge
			InternetApplyTaxAddlCharge
			InternetApplyTaxCommission
			InternetApplyTaxRebate
			ProductionBillingSetupComplete
			RadioBillingSetupComplete
			TelevisionBillingSetupComplete
			MagazineBillingSetupComplete
			NewspaperBillingSetupComplete
			OutOfHomeBillingSetupComplete
			InternetBillingSetupComplete
			ProductionUseEstimateBillingRate

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<Required>
		<Column("IS_NEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Boolean
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("PRD_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("PRD_ATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AttentionTo() As String
		<MaxLength(40)>
		<Column("PRD_BILL_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 1")>
		Public Property BillingAddress() As String
		<MaxLength(40)>
		<Column("PRD_BILL_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 2")>
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
		<MaxLength(20)>
		<Column("PRD_BILL_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCountry() As String
		<MaxLength(10)>
		<Column("PRD_BILL_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingZip() As String
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 1")>
		Public Property StatementAddress() As String
		<MaxLength(40)>
		<Column("PRD_STATE_ADDR2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 2")>
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
		<MaxLength(20)>
		<Column("PRD_STATE_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCountry() As String
		<MaxLength(10)>
		<Column("PRD_STATE_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementZip() As String
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
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<Column("PRD_CONSOL_FUNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ProductionConsolidateFunctions() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_CONT_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionContingency() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_PROD_MARKUP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionMarkup() As Nullable(Of Decimal)
		<Column("PRD_PROD_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductionBillNet() As Nullable(Of Short)
		<Column("PRD_PROD_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductionVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_PROD_ESTIMATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductionApprovedEstimatedRequired() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_PROD_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property ProductionTaxCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_RADIO_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioRebate() As Nullable(Of Decimal)
		<Column("PRD_RADIO_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioBillNet() As Nullable(Of Short)
		<Column("PRD_RADIO_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_RADIO_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioCommissionOnly() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_RADIO_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property RadioTaxCode() As String
		<Column("PRD_RADIO_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property RadioDaysToBill() As Nullable(Of Short)
		<Column("PRD_RADIO_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioPrePostBill() As Nullable(Of Short)
		<Column("PRD_RADIO_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioBillSetting() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_TV_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelevisionRebate() As Nullable(Of Decimal)
		<Column("PRD_TV_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionBillNet() As Nullable(Of Short)
		<Column("PRD_TV_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_TV_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionCommissionOnly() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_TV_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property TelevisionTaxCode() As String
		<Column("PRD_TV_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property TelevisionDaysToBill() As Nullable(Of Short)
		<Column("PRD_TV_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelevisionPrePostBill() As Nullable(Of Short)
		<Column("PRD_TV_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionBillSetting() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_MAG_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineRebate() As Nullable(Of Decimal)
		<Column("PRD_MAG_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineBillNet() As Nullable(Of Short)
		<Column("PRD_MAG_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_MAG_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineCommissionOnly() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_MAG_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property MagazineTaxCode() As String
		<Column("PRD_MAG_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property MagazineDaysToBill() As Nullable(Of Short)
		<Column("PRD_MAG_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazinePrePostBill() As Nullable(Of Short)
		<Column("PRD_MAG_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineBillSetting() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_NEWS_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperMarkup() As Nullable(Of Decimal)
		<Column("PRD_NEWS_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperBillNet() As Nullable(Of Short)
		<Column("PRD_NEWS_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_NEWS_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperCommissionOnly() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_NEWS_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property NewspaperTaxCode() As String
		<Column("PRD_NEWS_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property NewspaperDaysToBill() As Nullable(Of Short)
		<Column("PRD_NEWS_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperPrePostBill() As Nullable(Of Short)
		<Column("PRD_NEWS_BF_AF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperBillSetting() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_NEWS_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperRebate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_OTDR_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeRebate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_MISC_REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetRebate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_RADIO_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_TV_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_MAG_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_OTDR_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeMarkup() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PRD_MISC_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetMarkup() As Nullable(Of Decimal)
		<Column("PRD_OTDR_BF_AF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomeBillSetting() As Nullable(Of Short)
		<Column("PRD_OTDR_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeBillNet() As Nullable(Of Short)
		<Column("PRD_OTDR_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeCommissionOnly() As Nullable(Of Short)
		<Column("PRD_OTDR_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property OutOfHomeDaysToBill() As Nullable(Of Short)
		<Column("PRD_OTDR_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomePrePostBill() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_OTDR_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property OutOfHomeTaxCode() As String
		<Column("PRD_OTDR_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeVendorDiscounts() As Nullable(Of Short)
		<Column("PRD_MISC_BF_AF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetBillSetting() As Nullable(Of Short)
		<Column("PRD_MISC_BILL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetBillNet() As Nullable(Of Short)
		<Column("PRD_MISC_COM_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetCommissionOnly() As Nullable(Of Short)
		<Column("PRD_MISC_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property InternetDaysToBill() As Nullable(Of Short)
		<Column("PRD_MISC_PRE_POST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetPrePostBill() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("PRD_MISC_TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property InternetTaxCode() As String
		<Column("PRD_MISC_VEN_DISC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetVendorDiscounts() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("EMAIL_GR_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAlertGroup() As String
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsActive() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("USER_DEFINED1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User Defined Field 1")>
		Public Property UserDefinedField1() As String
		<MaxLength(50)>
		<Column("USER_DEFINED2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User Defined Field 2")>
		Public Property UserDefinedField2() As String
		<MaxLength(50)>
		<Column("USER_DEFINED3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User Defined Field 3")>
		Public Property UserDefinedField3() As String
		<MaxLength(50)>
		<Column("USER_DEFINED4", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User Defined Field 4")>
		Public Property UserDefinedField4() As String
		<Column("USE_TAX_FLAGS_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioApplyTaxRebate() As Nullable(Of Short)
		<Column("USE_TAX_FLAGS_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_T")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionApplyTaxRebate() As Nullable(Of Short)
		<Column("USE_TAX_FLAGS_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_M")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineApplyTaxRebate() As Nullable(Of Short)
		<Column("USE_TAX_FLAGS_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_N")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperApplyTaxRebate() As Nullable(Of Short)
		<Column("USE_TAX_FLAGS_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_O")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeApplyTaxRebate() As Nullable(Of Short)
		<Column("USE_TAX_FLAGS_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxUseFlags() As Nullable(Of Short)
		<Column("TAXAPPLYLN_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxLineNet() As Nullable(Of Short)
		<Column("TAXAPPLYND_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxNetDiscount() As Nullable(Of Short)
		<Column("TAXAPPLYNC_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxNetCharge() As Nullable(Of Short)
		<Column("TAXAPPLYAI_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxAddlCharge() As Nullable(Of Short)
		<Column("TAXAPPLYC_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxCommission() As Nullable(Of Short)
		<Column("TAXAPPLYR_I")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetApplyTaxRebate() As Nullable(Of Short)
		<Column("PROD_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductionBillingSetupComplete() As Nullable(Of Short)
		<Column("RADIO_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RadioBillingSetupComplete() As Nullable(Of Short)
		<Column("TV_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property TelevisionBillingSetupComplete() As Nullable(Of Short)
		<Column("MAG_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MagazineBillingSetupComplete() As Nullable(Of Short)
		<Column("NEWS_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NewspaperBillingSetupComplete() As Nullable(Of Short)
		<Column("OOH_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OutOfHomeBillingSetupComplete() As Nullable(Of Short)
		<Column("INET_SETUP_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property InternetBillingSetupComplete() As Nullable(Of Short)
		<Column("USE_EST_BILL_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductionUseEstimateBillingRate() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportProductStaging.Properties.Code.ToString

                    If Me.IsNew Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Products _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                      Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper AndAlso _
                                      Entity.DivisionCode.ToUpper = Me.DivisionCode.ToUpper
                                Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Product code already exists in the system for this client/division."

                        Else

                            Try

                                If _DataContext IsNot Nothing Then

                                    _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                End If

                            Catch ex As Exception
                                _DataContext = Nothing
                            End Try

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, Me.ClientCode, Me.DivisionCode, PropertyValue) Is Nothing Then

                            IsValid = False
                            ErrorText = "Product code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportProductStaging.Properties.Name.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a product's name."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
