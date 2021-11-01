Namespace Database.Entities

	<Table("AGENCY_COMMENTS")>
	Public Class AgencyComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Type
			Comment

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(50)>
		<Column("COMMENT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Column("COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Type

        End Function

#End Region

	End Class

End Namespace
