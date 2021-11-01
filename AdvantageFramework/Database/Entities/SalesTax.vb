Namespace Database.Entities

	<Table("SALES_TAX")>
	Public Class SalesTax
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			TaxCode
			Description
			StatePercent
			CountyPercent
			CityPercent
			Resale
            ResaleNumber
            VATTaxCode
            IsInactive
			ID
			AccountPayableRadios
			AccountPayableTVs
			EmployeeTimeDetails
			OfficeSalesTaxAccounts
			AccountPayableProductions
			AccountPayableNewspapers
			AccountPayableMagazines
			RadioOrderLegacies
			TVOrderLegacies
            IncomeOnlys
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property TaxCode() As String
		<MaxLength(30)>
		<Column("TAX_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("TAX_STATE_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f4")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        Public Property StatePercent() As Nullable(Of Decimal)
		<Column("TAX_COUNTY_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f4")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        Public Property CountyPercent() As Nullable(Of Decimal)
		<Column("TAX_CITY_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f4")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        Public Property CityPercent() As Nullable(Of Decimal)
		<Column("TAX_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property Resale() As Nullable(Of Short)
		<MaxLength(20)>
		<Column("TAX_RESALE_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ResaleNumber() As String
        <MaxLength(20)>
        <Column("VAT_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VATTaxCode() As String
        <Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer

        Public Overridable Property AccountPayableRadios As ICollection(Of Database.Entities.AccountPayableRadio)
        Public Overridable Property AccountPayableTVs As ICollection(Of Database.Entities.AccountPayableTV)
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property OfficeSalesTaxAccounts As ICollection(Of Database.Entities.OfficeSalesTaxAccount)
        Public Overridable Property AccountPayableProductions As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property AccountPayableNewspapers As ICollection(Of Database.Entities.AccountPayableNewspaper)
        Public Overridable Property AccountPayableMagazines As ICollection(Of Database.Entities.AccountPayableMagazine)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TaxCode & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.SalesTax.Properties.TaxCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).SalesTaxes
                            Where Entity.TaxCode.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique tax code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
