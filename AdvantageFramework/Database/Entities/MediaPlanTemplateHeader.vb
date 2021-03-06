Namespace Database.Entities

    <Table("MEDIA_PLAN_TEMPLATE_HEADER")>
    Public Class MediaPlanTemplateHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_TEMPLATE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean

        Public Overridable Property MediaPlanTemplateDetails As ICollection(Of Database.Entities.MediaPlanTemplateDetail)
        Public Overridable Property MediaPlanTemplateProducts As ICollection(Of Database.Entities.MediaPlanTemplateProduct)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
