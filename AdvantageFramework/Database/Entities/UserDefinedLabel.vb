Namespace Database.Entities

	<Table("UDV_LABEL")>
	Public Class UserDefinedLabel
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AssociatedTable
			Label
			IsEditable
			ValidationRule

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(19)>
		<Column("UDV_TABLE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssociatedTable() As String
		<MaxLength(20)>
		<Column("USER_LABEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Label() As String
		<Column("EDITABLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsEditable() As Nullable(Of Boolean)
		<MaxLength(254)>
		<Column("VALIDATION_RULE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ValidationRule() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AssociatedTable

        End Function

#End Region

	End Class

End Namespace
