Namespace Database.Entities

	<Table("RATE_CARD_DTL")>
	Public Class RateCardDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			RateCardID
			ID
			Description
			By
			Rate
			Type
			ContractQuantity
			Notes
			RateCard

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("RATE_CARD_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RateCardID() As Integer
		<Key>
		<Required>
        <Column("RATE_DTL_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(60)>
		<Column("RATE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("RATE_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Rate By")>
		Public Property By() As Short
		<Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<Required>
		<Column("RATE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Rate Type")>
		Public Property Type() As Short
		<Column("CONTRACT_QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Quantity")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
		Public Property ContractQuantity() As Nullable(Of Decimal)
		<Column("RATE_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Notes() As String

        Public Overridable Property RateCard As Database.Entities.RateCard

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RateCardID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.RateCardDetail.Properties.By.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If PropertyValue Is Nothing OrElse PropertyValue = 0 Then

                            IsValid = False

                            ErrorText = "Please select rate by."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
