Namespace Security.Database.Entities

	<Table("APP_VARS")>
	Public Class ApplicationSetting
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			ApplicationSection
			Group
			Name
			Type
			OrderNumber
			Value

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
        <Column("USERID", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Key>
		<Required>
		<MaxLength(40)>
        <Column("APPLICATION", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplicationSection() As String
		<Key>
		<Required>
		<MaxLength(10)>
        <Column("VARIABLE_GROUP", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Group() As String
		<Key>
		<Required>
		<MaxLength(30)>
        <Column("VARIABLE_NAME", Order:=3, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Required>
		<MaxLength(20)>
		<Column("VARIABLE_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Column("VARIABLE_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<MaxLength(200)>
		<Column("VARIABLE_VALUE", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Value() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

	End Class

End Namespace
