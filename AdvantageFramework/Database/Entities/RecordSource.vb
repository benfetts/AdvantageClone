Namespace Database.Entities

	<Table("RECORD_SOURCE")>
	Public Class RecordSource
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
			Description
			IsSystemSource
			ClientCrossReferences
			GeneralLedgerCrossReferences
			ImportTemplates
			VendorCrossReferences

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("RECORD_SOURCE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Required>
		<Column("DESCRIPTION", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("SYSTEM_SOURCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsSystemSource() As Boolean

        Public Overridable Property ClientCrossReferences As ICollection(Of Database.Entities.ClientCrossReference)
        Public Overridable Property GeneralLedgerCrossReferences As ICollection(Of Database.Entities.GeneralLedgerCrossReference)
        Public Overridable Property ImportTemplates As ICollection(Of Database.Entities.ImportTemplate)
        Public Overridable Property VendorCrossReferences As ICollection(Of Database.Entities.VendorCrossReference)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
