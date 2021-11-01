Namespace Security.Database.Entities

	<Table("SEC_GROUP_SETTING")>
	Public Class GroupSetting
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GroupID
			SettingCode
			StringValue
			NumericValue
			DateValue
			Group

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_GROUP_SETTING_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Key>
		<Required>
        <Column("SEC_GROUP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GroupID() As Integer
		<Key>
		<Required>
		<MaxLength(100)>
        <Column("SETTING_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SettingCode() As String
		<MaxLength(8000)>
		<Column("STRING_VALUE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StringValue() As String
		<Column("NUMERIC_VALUE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 4)>
        Public Property NumericValue() As Nullable(Of Decimal)
		<Column("DATE_VALUE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateValue() As Nullable(Of Date)

        Public Overridable Property Group As Database.Entities.Group

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
