Namespace Database.Entities

    <Table("MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER")>
    Public Class MediaPlanEstimateTemplateQuarter
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            Quarter
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <Required>
        <Column("QUARTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Quarter() As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarterValue

        <ForeignKey("MediaPlanEstimateTemplateID")>
        Public Overridable Property MediaPlanEstimateTemplate As Database.Entities.MediaPlanEstimateTemplate

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
