Namespace Database.Entities

	<Table("ASSIGN_NBR")>
	Public Class AssignNumber
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ColumnName
			LastNumber
			UserCode

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(30)>
		<Column("COLUMNNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ColumnName() As String
		<Column("LAST_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastNumber() As Nullable(Of Integer)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ColumnName.ToString

        End Function

#End Region

	End Class

End Namespace
