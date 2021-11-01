Namespace Security.Database.Entities

	<Table("SEC_GROUP")>
	Public Class Group
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			Name
			GroupApplicationAccesses
			GroupModuleAccesses
			GroupUsers
			GroupSettings
			GroupUserDefinedReportAccesses

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_GROUP_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(50)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String

        Public Overridable Property GroupApplicationAccesses As ICollection(Of Database.Entities.GroupApplicationAccess)
        Public Overridable Property GroupModuleAccesses As ICollection(Of Database.Entities.GroupModuleAccess)
        Public Overridable Property GroupUsers As ICollection(Of Database.Entities.GroupUser)
        Public Overridable Property GroupSettings As ICollection(Of Database.Entities.GroupSetting)
        Public Overridable Property GroupUserDefinedReportAccesses As ICollection(Of Database.Entities.GroupUserDefinedReportAccess)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
