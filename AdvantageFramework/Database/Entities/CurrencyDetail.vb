Namespace Database.Entities

	<Table("CURRENCY_DETAIL")>
	Public Class CurrencyDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			CurrencyCode
			ExchangeRate
            ExchangeDate
            CurrencyCodeComparison
            Currency
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CURRENCY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CurrencyCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 6)>
		<Column("EXCHANGE_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n6")>
		Public Property ExchangeRate() As Decimal
		<Required>
		<Column("EXCHANGE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="G")>
		Public Property ExchangeDate() As Date
        <Required>
        <Column("CURRENCY_CODE_COMPARISON", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CurrencyCodeComparison() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 6)>
        <Column("RECIPROCAL_EXCHANGE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n6", IsReadOnlyColumn:=True, CustomColumnCaption:="Reciprocal Rate")>
        Public Property ReciprocalExchangeRate() As Decimal

        Public Overridable Property Currency As Database.Entities.Currency

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.CurrencyDetail.Properties.ExchangeRate.ToString

                    If CDec(Value) <= 0 Then

                        IsValid = False
                        ErrorText = "Please enter an exchange rate greater than 0.000000."

                    End If

                Case AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCodeComparison.ToString

                    If Value = Me.CurrencyCode Then

                        IsValid = False
                        ErrorText = "Currency comparison code must not be the same as currency code."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
