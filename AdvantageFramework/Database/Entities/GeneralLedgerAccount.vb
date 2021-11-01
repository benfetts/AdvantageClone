Namespace Database.Entities

	<Table("GLACCOUNT")>
	Public Class GeneralLedgerAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			Type
			CDPRequired
			Active
			DepartmentCode
			UserCode
			EnteredDate
			ModifiedDate
			BalanceType
			BaseCode
			GeneralLedgerOfficeCrossReferenceCode
			ID
			Payroll
            PurchaseOrder
            OtherCode
            AccountPayablePayments
			CashAccountPayablePayments
			AccountPayableRadios
			AccountPayableTVs
			NonBillableFunctions
			OverheadFunctions
			AccountsPayableOffices
			AccountsPayableDiscountOffices
			AccountsReceivableOffices
			CityTaxOffices
			CountyTaxOffices
			ProductionAccruedAccountsPayableOffices
			ProductionAccruedCostOfSalesOffices
			ProductionCostOfSalesOffices
			ProductionDeferredCostOfSalesOffices
			ProductionDeferredSalesOffices
			ProductionSalesOffices
			ProductionWorkInProgressOffices
			StateTaxOffices
			SuspenseOffices
			Vendors
			AccountPayableDiscountPayments
            AccountPayables
            Banks5
			Banks3
			Banks7
			Banks2
			Banks4
			Banks6
			Banks8
			Banks
			OfficeSalesClassAccounts
			OfficeSalesClassAccount2
			OfficeSalesClassAccounts3
			OfficeSalesClassAccounts4
			OfficeSalesTaxAccounts
			OfficeSalesTaxAccounts2
			OfficeSalesTaxAccounts3
			OverheadAccounts
			OverheadAccounts2
			OfficeFunctionAccounts2
			OfficeFunctionAccounts
			OfficeInterCompanies
			OfficeInterCompanies2
			OfficeSalesClassFunctionAccounts
			OfficeSalesClassFunctionAccounts2
			GeneralLedgerDetails
			AccountPayableProduction
			AccountPayableGLDistributions
			GeneralLedgerOfficeCrossReference
			PurchaseOrderDetails
			AccountPayableInternets
			AccountPayableOutOfHomes
			AccountPayableNewspapers3
			AccountPayableNewspapers
			AccountPayableNewspapers2
			AccountPayableMagazines
			AccountPayableMagazines1
			AccountPayableMagazines2
			AccountPayableRecurGeneralLedger
			AccountPayableRecurs
			AccountReceivables
			ClientCashReceipts
			ClientCashReceiptDetailsAdjustment
			ClientCashReceiptDetailsAR
			ClientCashReceiptOnAccounts
			OtherCashReceipts
			OtherCashReceiptDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property Code() As String
		<Required>
		<MaxLength(75)>
		<Column("GLADESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(2)>
		<Column("GLATYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Column("GLACDPREQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CDPRequired() As Nullable(Of Short)
		<MaxLength(1)>
		<Column("GLAACTIVE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Active() As String
		<MaxLength(5)>
		<Column("GLADEPT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentCode() As String
		<MaxLength(100)>
		<Column("GLAUSER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("GLAENTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnteredDate() As Nullable(Of Date)
		<Column("GLAMODDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("GLABALTYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BalanceType() As Nullable(Of Short)
		<MaxLength(20)>
		<Column("GLABASE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BaseCode() As String
		<MaxLength(20)>
		<Column("GLAOFFICE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerOfficeCrossReferenceCode() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Column("GLAPAYROLL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Payroll() As Nullable(Of Short)
		<Column("GLPO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrder() As Nullable(Of Short)
        <MaxLength(20)>
		<Column("GLAOTHER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OtherCode() As String

        'Public Overridable Property AccountPayableRadios As ICollection(Of Database.Entities.AccountPayableRadio)
        'Public Overridable Property AccountPayableTVs As ICollection(Of Database.Entities.AccountPayableTV)
        'Public Overridable Property NonBillableFunctions As ICollection(Of Database.Entities.Function)
        'Public Overridable Property OverheadFunctions As ICollection(Of Database.Entities.Function)
        'Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)
        'Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        'Public Overridable Property OfficeSalesClassAccounts As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        'Public Overridable Property OfficeSalesClassAccount2 As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        'Public Overridable Property OfficeSalesClassAccounts3 As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        'Public Overridable Property OfficeSalesClassAccounts4 As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        'Public Overridable Property OfficeSalesTaxAccounts As ICollection(Of Database.Entities.OfficeSalesTaxAccount)
        'Public Overridable Property OfficeSalesTaxAccounts2 As ICollection(Of Database.Entities.OfficeSalesTaxAccount)
        'Public Overridable Property OfficeSalesTaxAccounts3 As ICollection(Of Database.Entities.OfficeSalesTaxAccount)
        'Public Overridable Property OverheadAccounts As ICollection(Of Database.Entities.OverheadAccount)
        'Public Overridable Property OverheadAccounts2 As ICollection(Of Database.Entities.OverheadAccount)
        'Public Overridable Property OfficeFunctionAccounts2 As ICollection(Of Database.Entities.OfficeFunctionAccount)
        'Public Overridable Property OfficeFunctionAccounts As ICollection(Of Database.Entities.OfficeFunctionAccount)
        'Public Overridable Property OfficeInterCompanies As ICollection(Of Database.Entities.OfficeInterCompany)
        'Public Overridable Property OfficeInterCompanies2 As ICollection(Of Database.Entities.OfficeInterCompany)
        'Public Overridable Property OfficeSalesClassFunctionAccounts As ICollection(Of Database.Entities.OfficeSalesClassFunctionAccount)
        'Public Overridable Property OfficeSalesClassFunctionAccounts2 As ICollection(Of Database.Entities.OfficeSalesClassFunctionAccount)
        'Public Overridable Property GeneralLedgerDetails As ICollection(Of Database.Entities.GeneralLedgerDetail)
        'Public Overridable Property AccountPayableProduction As ICollection(Of Database.Entities.AccountPayableProduction)
        'Public Overridable Property AccountPayableGLDistributions As ICollection(Of Database.Entities.AccountPayableGLDistribution)
        Public Overridable Property GeneralLedgerOfficeCrossReference As Database.Entities.GeneralLedgerOfficeCrossReference
        'Public Overridable Property PurchaseOrderDetails As ICollection(Of Database.Entities.PurchaseOrderDetail)
        'Public Overridable Property AccountPayableInternets As ICollection(Of Database.Entities.AccountPayableInternet)
        'Public Overridable Property AccountPayableOutOfHomes As ICollection(Of Database.Entities.AccountPayableOutOfHome)
        'Public Overridable Property AccountPayableRecurGeneralLedger As ICollection(Of Database.Entities.AccountPayableRecurGeneralLedger)
        'Public Overridable Property AccountPayableRecurs As ICollection(Of Database.Entities.AccountPayableRecur)
        'Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        'Public Overridable Property ClientCashReceipts As ICollection(Of Database.Entities.ClientCashReceipt)
        'Public Overridable Property OtherCashReceipts As ICollection(Of Database.Entities.OtherCashReceipt)
        'Public Overridable Property OtherCashReceiptDetails As ICollection(Of Database.Entities.OtherCashReceiptDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

	End Class

End Namespace
