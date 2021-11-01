Namespace Database.Entities

	<Table("GLTEMPLATE")>
	Public Class GLTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Name
			BaseCode
			NameDescription
			Description
			Type
			BalanceType
			CDPRequired

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(20)>
        <Column("GLTNAME", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Key>
		<Required>
		<MaxLength(30)>
        <Column("GLTBASE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BaseCode() As String
		<Required>
		<MaxLength(40)>
		<Column("GLTNAMEDESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NameDescription() As String
		<Required>
		<MaxLength(75)>
		<Column("GLTDESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(2)>
		<Column("GLTTYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Required>
		<Column("GLTBALTYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BalanceType() As Short
		<Column("GLTCDPREQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CDPRequired() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name.ToString

        End Function

#End Region

	End Class

End Namespace
