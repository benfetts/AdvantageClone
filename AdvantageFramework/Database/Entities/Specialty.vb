Namespace Database.Entities

	<Table("SPECIALTY")>
	Public Class Specialty
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			IsInactive
			CompanyProfile

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SPECIALTY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Boolean

        Public Overridable Property CompanyProfile As ICollection(Of Database.Entities.CompanyProfile)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
