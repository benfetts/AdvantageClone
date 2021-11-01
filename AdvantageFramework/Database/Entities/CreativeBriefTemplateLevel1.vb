Namespace Database.Entities

	<Table("CRTV_BRF_LVL1")>
	Public Class CreativeBriefTemplateLevel1
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			CreativeBriefTemplateID
			OrderNumber
			QueryType
			CreativeBriefTemplate
			CreativeBriefTemplateLevel2s

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("CRTV_BRF_LVL1_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Short
		<MaxLength(254)>
		<Column("CRTV_BRF_LVL1_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("CRTV_BRF_DEF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreativeBriefTemplateID() As Integer
		<Column("LVL1_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Short)
		<MaxLength(8)>
		<Column("QUERY_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property QueryType() As String

        Public Overridable Property CreativeBriefTemplate As Database.Entities.CreativeBriefTemplate
        Public Overridable Property CreativeBriefTemplateLevel2s As ICollection(Of Database.Entities.CreativeBriefTemplateLevel2)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
