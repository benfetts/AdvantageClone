Namespace Database.Entities

    <Table("MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH")>
    Public Class MediaPlanEstimateTemplateSpotLength
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            SpotLength
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <Required>
        <Column("SPOT_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SpotLength() As Short

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
