Namespace Database.Entities

	<Table("GEN_DESC")>
	Public Class GeneralDescription
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			FieldName
			FieldDescription
			ColumnLabel

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(20)>
		<Column("FIELD_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property FieldName() As String
		<Required>
		<MaxLength(40)>
		<Column("FIELD_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FieldDescription() As String
		<MaxLength(20)>
		<Column("COL_LABEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ColumnLabel() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FieldName

        End Function

#End Region

	End Class

End Namespace
