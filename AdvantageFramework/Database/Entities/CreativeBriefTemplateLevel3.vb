Namespace Database.Entities

	<Table("CRTV_BRF_LVL3")>
	Public Class CreativeBriefTemplateLevel3
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			CreativeBriefTemplateLevel2ID
			OrderNumber
			QueryType
			CreativeBriefTemplateLevel2
			CreativeBriefDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("CRTV_BRF_LVL3_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Short
		<MaxLength(254)>
		<Column("CRTV_BRF_LVL3_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("CRTV_BRF_LVL2_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreativeBriefTemplateLevel2ID() As Short
		<Column("LVL3_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Short)
		<MaxLength(8)>
		<Column("QUERY_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property QueryType() As String

        Public Overridable Property CreativeBriefTemplateLevel2 As Database.Entities.CreativeBriefTemplateLevel2
        Public Overridable Property CreativeBriefDetails As ICollection(Of Database.Entities.CreativeBriefDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
