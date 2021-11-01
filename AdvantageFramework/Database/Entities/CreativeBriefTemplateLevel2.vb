Namespace Database.Entities

	<Table("CRTV_BRF_LVL2")>
	Public Class CreativeBriefTemplateLevel2
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			CreativeBriefTemplateLevel1ID
			OrderNumber
			QueryType
			CreativeBriefTemplateLevel1
			CreativeBriefTemplateLevel3s

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("CRTV_BRF_LVL2_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Short
		<MaxLength(254)>
		<Column("CRTV_BRF_LVL2_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("CRTV_BRF_LVL1_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreativeBriefTemplateLevel1ID() As Short
		<Column("LVL2_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Short)
		<MaxLength(8)>
		<Column("QUERY_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property QueryType() As String

        Public Overridable Property CreativeBriefTemplateLevel1 As Database.Entities.CreativeBriefTemplateLevel1
        Public Overridable Property CreativeBriefTemplateLevel3s As ICollection(Of Database.Entities.CreativeBriefTemplateLevel3)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
