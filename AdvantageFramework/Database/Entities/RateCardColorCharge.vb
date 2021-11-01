Namespace Database.Entities

	<Table("RATE_CARD_COLORCHG")>
	Public Class RateCardColorCharge
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			RateCardID
			ID
			Charge
			Description
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
        <Column("COLOR_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Column("COLOR_CHARGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Color Charge")>
		Public Property Charge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("COLOR_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String

        Public Overridable Property RateCard As Database.Entities.RateCard

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RateCardID

        End Function

#End Region

	End Class

End Namespace
