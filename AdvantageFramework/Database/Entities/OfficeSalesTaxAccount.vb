Namespace Database.Entities

	<Table("OFF_TAX_ACCTS")>
	Public Class OfficeSalesTaxAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OfficeCode
			SalesTaxCode
			StateTaxGLACode
			CountyTaxGLACode
			CityTaxGLACode
			GeneralLedgerAccount
			GeneralLedgerAccount2
			GeneralLedgerAccount3
			Office
			SalesTax

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
        <Column("OFFICE_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<Key>
		<Required>
		<MaxLength(4)>
        <Column("TAX_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Tax Code", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property SalesTaxCode() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_TAX_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="State Tax", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property StateTaxGLACode() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_TAX_CNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="County Tax", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property CountyTaxGLACode() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_TAX_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="City Tax", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property CityTaxGLACode() As String

        Public Overridable Property Office As Database.Entities.Office
        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode

        End Function

#End Region

	End Class

End Namespace
