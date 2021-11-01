Namespace Security.Database.Entities

	<Table("SEC_APPLICATION")>
	Public Class Application
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			Name
			ApplicationModules
			GroupApplicationAccesses
			UserApplicationAccesses
			ClientPortalUserApplicationAccesses

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_APPLICATION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(100)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String

        Public Overridable Property ApplicationModules As ICollection(Of Database.Entities.ApplicationModule)
        Public Overridable Property GroupApplicationAccesses As ICollection(Of Database.Entities.GroupApplicationAccess)
        Public Overridable Property UserApplicationAccesses As ICollection(Of Database.Entities.UserApplicationAccess)
        Public Overridable Property ClientPortalUserApplicationAccesses As ICollection(Of Database.Entities.ClientPortalUserApplicationAccess)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
